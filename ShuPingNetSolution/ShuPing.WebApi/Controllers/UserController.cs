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
        public ApiResultModel Login()
        {
            var result = new ApiResultModel()
            {
                IsSuccess = false,
                StatusCode = StatusEnum.StatusCodeEnum.Error,
                Message = StringResource.LoginFail
            };

            //验证登录逻辑

            result.IsSuccess = true;
            result.StatusCode = StatusEnum.StatusCodeEnum.Success;
            result.Message = StringResource.LoginSuucess;
            return result;
        }
	}
}