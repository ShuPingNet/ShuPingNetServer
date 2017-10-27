using ShuPing.Entity;
using ShuPing.Infrastructure.StatusEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Infrastructure.Extension;
using Newtonsoft.Json;
using System.Text;

namespace ShuPing.WebApi.Controllers
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    public class BaseController : ApiController
    {
        /// <summary>
        /// 获取Token用于验证请求
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetToken(string staff)
        {
            ResultMessage msg = null;
            int staffMsg = 0;

            //检测staff合法性
            if (string.IsNullOrEmpty(staff) || !int.TryParse(staff, out staffMsg))
            {
                msg = new ResultMessage();
                msg.StatusCode = (int)StatusCodeEnum.ParameterError;
                msg.Info = StatusCodeEnum.ParameterError.GetEnumText();
                msg.Data = string.Empty;

                return HttpResponseExtension.toJson(JsonConvert.SerializeObject(msg));
            }

            //从Cache中获取Token，如果为空则创建Token 
            Token token = (Token)HttpRuntime.Cache.Get(staffMsg.ToString());
            if (null == token)
            {
                token = new Token();
                token.StaffId = staffMsg;
                token.SignToken = Guid.NewGuid();
                token.ExpireTime = DateTime.Now.AddDays(1);
                HttpRuntime.Cache.Insert(staffMsg.ToString(), token, null, token.ExpireTime, TimeSpan.Zero);
            }

            //返回信息
            msg.StatusCode = (int)StatusCodeEnum.Success;
            msg.Info = token.StaffId.ToString();
            msg.Data = token;
            return HttpResponseExtension.toJson(JsonConvert.SerializeObject(msg));
        }

        /// <summary>
        /// Get请求参数处理
        /// </summary>
        /// <param name="parames"></param>
        /// <returns></returns>
        [HttpGet]
        public Tuple<string, string> GetQueryString(Dictionary<string, string> parames)
        {
            if (parames == null || parames.Count == 0)
            {
                return new Tuple<string, string>("", "");
            }

            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sort = new SortedDictionary<string, string>(parames);
            IEnumerator<KeyValuePair<string, string>> kvp = sort.GetEnumerator();

            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder("");
            StringBuilder queryString = new StringBuilder("");

            while (kvp.MoveNext())
            {
                string key = kvp.Current.Key;
                string value = kvp.Current.Value;
                if (!string.IsNullOrEmpty(key))
                {
                    //签名参数
                    query.Append(key).Append(value);
                    //Url参数
                    queryString.Append("&").Append(key).Append("=").Append(value);
                }
            }
            return new Tuple<string, string>(query.ToString(), queryString.ToString().Substring(1, queryString.Length - 1));
        }
    }
}