using Infrastructure.Resource;
using ShuPing.Entity;
using ShuPing.Infrastructure.StatusEnum;
using System;
using Infrastructure.Extension;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft.Json;
using Infrastructure.Common;
using System.Collections.Specialized;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace ShuPing.WebApi.Attributes
{
    /// <summary>
    /// 验证请求Action的合法性
    /// </summary>
    public class ApiSecurityFilter: ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            ResultMessage retMsg = null;
            var request = actionContext.Request;
            string method = request.Method.Method.ToUpper();
            string staffid = String.Empty, timestamp = string.Empty, nonce = string.Empty, signature = string.Empty;
            int id = 0;
            if (request.Headers.Contains(StringResource.StaffId))
            {
                staffid = HttpUtility.UrlDecode(request.Headers.GetValues(StringResource.StaffId).FirstOrDefault());
            }

            if (request.Headers.Contains(StringResource.TimeStamp))
            {
                timestamp = HttpUtility.UrlDecode(request.Headers.GetValues(StringResource.TimeStamp).FirstOrDefault());
            }

            if (request.Headers.Contains(StringResource.Nonce))
            {
                nonce = HttpUtility.UrlDecode(request.Headers.GetValues(StringResource.Nonce).FirstOrDefault());
            }

            if (request.Headers.Contains(StringResource.Signature))
            {
                signature = HttpUtility.UrlDecode(request.Headers.GetValues(StringResource.Signature).FirstOrDefault());
            }

            //验证参数合法性
            if(actionContext.ActionDescriptor.ActionName == StringResource.GetToken)
            {
                if(ValidateParameters(out id))
                {
                    retMsg = new ResultMessage();
                    retMsg.StatusCode = (int)StatusCodeEnum.ParameterError;
                    retMsg.Data = string.Empty;
                    retMsg.Info = StatusCodeEnum.ParameterError.GetEnumText();

                    actionContext.Response = HttpResponseExtension.toJson(JsonConvert.SerializeObject(retMsg));
                    base.OnActionExecuting(actionContext);
                    return;
                }
            }
            else
            {
                base.OnActionExecuting(actionContext);
                return;
            }

            if(ValidateParameters(out id))
            {
                retMsg = new ResultMessage();
                retMsg.StatusCode = (int)StatusCodeEnum.ParameterError;
                retMsg.Info = StatusCodeEnum.ParameterError.GetEnumText();
                retMsg.Data = string.Empty;

                actionContext.Response = HttpResponseExtension.toJson(JsonConvert.SerializeObject(retMsg));
                base.OnActionExecuting(actionContext);
                return;
            }

            //验证时间戳是否过期
            double ts1 = 0;
            double ts2 = 0;

            ts2 = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds;
            double ts = ts2 - ts1;
            bool timespanValidate = double.TryParse(timestamp, out ts1);
            bool flag = ts > int.Parse(WebSettingsConfig.UrlExpireTime) * 1000;

            if(flag || (!timespanValidate))
            {
                retMsg = new ResultMessage();
                retMsg.StatusCode = (int)StatusCodeEnum.URLExpireError;
                retMsg.Info = StatusCodeEnum.URLExpireError.GetEnumText();
                retMsg.Data = string.Empty;

                actionContext.Response = HttpResponseExtension.toJson(JsonConvert.SerializeObject(retMsg));
                base.OnActionExecuting(actionContext);
                return;   
            }

            //验证Token有效性
            Token token = (Token)HttpRuntime.Cache.Get(id.ToString());
            string signToken = string.Empty;
            if(null == HttpRuntime.Cache.Get(id.ToString()))
            {
                retMsg = new ResultMessage();
                retMsg.StatusCode = (int)StatusCodeEnum.TokenInvalid;
                retMsg.Info = StatusCodeEnum.TokenInvalid.GetEnumText();
                retMsg.Data = string.Empty;
            }
            else
            {
                signToken = token.SignToken.ToString();
            }

            //根据请求类型（POST/GET）拼接参数

            NameValueCollection form = HttpContext.Current.Request.QueryString;
            string data = string.Empty;
            switch (method)
            {
                case StringResource.Post:
                    string resp = string.Empty;
                    Stream stream = HttpContext.Current.Request.InputStream;
                    StreamReader reader = new StreamReader(stream);
                    resp = reader.ReadToEnd();
                    data = resp;
                    break;
                case StringResource.Get:
                    IDictionary<string, string> dic = new Dictionary<string, string>();
                    for (int i = 0; i < form.Count; i++)
                    {
                        string key = form.Keys[i];
                        dic.Add(key, form[key]);
                    }
                    //排序
                    IDictionary<string, string> sortDic = new SortedDictionary<string, string>(dic);
                    IEnumerator<KeyValuePair<string,string>> kvp = sortDic.GetEnumerator();

                    StringBuilder queryUrl = new StringBuilder();
                    StringBuilder query = new StringBuilder();

                    while (kvp.MoveNext())
                    {
                        var item = kvp.Current;
                        query.Append(item.Key);
                        query.Append(item.Value);
                    }
                    data = query.ToString();
                    break;
                default:
                    retMsg = new ResultMessage();
                    retMsg.StatusCode = (int)StatusCodeEnum.HttpMehtodError;
                    retMsg.Info = StatusCodeEnum.HttpMehtodError.GetEnumText();
                    retMsg.Data =string.Empty;
                    actionContext.Response = HttpResponseExtension.toJson(JsonConvert.SerializeObject(retMsg));
                    base.OnActionExecuting(actionContext);
                    return;
            }

            bool signSuccess = SignExtension.Validate(timestamp, nonce, id, signToken, data, signature);
            if (signSuccess)
            {
                retMsg = new ResultMessage();
                retMsg.StatusCode = (int)StatusCodeEnum.HttpRequestError;
                retMsg.Info = StatusCodeEnum.HttpRequestError.GetEnumText();
                retMsg.Data = string.Empty;
                actionContext.Response = HttpResponseExtension.toJson(JsonConvert.SerializeObject(retMsg));
                base.OnActionExecuting(actionContext);
                return;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        /// <summary>
        /// 验证验签数据
        /// </summary>
        /// <param name="staffId"></param>
        /// <returns></returns>
        private bool ValidateParameters(out int staffId)
        {
            var ret = false;
            if (string.IsNullOrEmpty(StringResource.Nonce) || string.IsNullOrEmpty(StringResource.Signature) || string.IsNullOrEmpty(StringResource.TimeStamp) || !int.TryParse(StringResource.StaffId, out staffId))
            {
                staffId = 0;
                ret = true;
            }
            return ret;
        }
    }
}