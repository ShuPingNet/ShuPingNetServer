using ShuPing.Entity;
using ShuPing.WebApi.Attributes;
using ShuPing.WebApi.Models.Base;
using Infrastructure.Resource;
using System.Web.Http;
using StatusEnum = ShuPing.Infrastructure.StatusEnum;

namespace ShuPing.WebApi.Controllers
{
    /// <summary>
    /// 用户操作相关接口
    /// </summary>
    [LoggingActionFilter]
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户注册接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiResultModel Register(UserEntity entity)
        {
            var result = new ApiResultModel()
            {
                IsSuccess = false,
                Message = StringResource.RegisterFail,
                StatusCode = StatusEnum.StatusCodeEnum.Error
            };
            return result;
        }

        /// <summary>
        /// 用户登录接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResultModel Login(UserLogOnEntity entity)
        {
            //检测cookie是否创建
            HttpContext context = HttpContext.Current;
            HttpCookie cookie =  context.Request.Cookies.Get("_user");
            if(null == cookie)
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
                IsSuccess = false,
                StatusCode = StatusEnum.StatusCodeEnum.Error,
                Message = StringResource.LoginFail
            };

            result.IsSuccess = false;
            return result;
        }
	}
}