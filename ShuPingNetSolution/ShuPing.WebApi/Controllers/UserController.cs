using ShuPing.Entity;
using ShuPing.WebApi.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StatusEnum = ShuPing.Infrastructure.StatusEnum;

namespace ShuPing.WebApi.Controllers
{
    /// <summary>
    /// 用户操作相关接口
    /// </summary>
    public class UserController : ApiController
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

        //[Route("User/Login")]
        [HttpGet]
        public ApiResultModel Login()
        {
            var result = new ApiResultModel()
            {
                IsSuccess = true,
                StatusCode = StatusEnum.StatusCodeEnum.Success,
                Message = "用户登录成功"
            };
            return result;
        }
	}
}