using ShuPing.Entity;
using ShuPing.WebApi.Attributes;
using ShuPing.WebApi.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StatusEnum = ShuPing.Infrastructure.StatusEnum;

namespace ShuPing.WebApi.Controllers
{
    /// <summary>
    /// 用户操作相关接口
    /// </summary>

    public class UserController : BaseController
    {
        /// <summary>
        /// 用户注册接口
        /// </summary>
        /// <returns></returns>
        //[Route("User/Register")]
        [HttpPost]
        public ApiResultModel Register(UserEntity entity)
        {
            var result = new ApiResultModel()
            {
                IsSuccess = false,
                Message = "用户注册失败",
                StatusCode = StatusEnum.StatusCodeEnum.Error
            };
            return result;
        }

        [LoggingActionFilter]
        [ApiSecurityFilter]
        [HttpGet]
        public ApiResultModel Login(UserLogOnEntity entity)
        {
            //检测cookie是否创建
            HttpContext context = HttpContext.Current;
            HttpCookie cookie = context.Request.Cookies.Get("_user");
            if (null == cookie)
            {
                cookie = new HttpCookie("_user");
                cookie.Value = "xuhb";
                cookie.Expires.AddMinutes(5);
                context.Response.SetCookie(cookie);
            }
            else
            {
                string value = cookie.Value;
                cookie.Expires.AddMinutes(5);
            }

            var result = new ApiResultModel()
            {
                IsSuccess = true,
                StatusCode = StatusEnum.StatusCodeEnum.Success,
                Message = "用户登录成功"
            };

            //result.IsSuccess = false;
            return result;
        }
	}
}