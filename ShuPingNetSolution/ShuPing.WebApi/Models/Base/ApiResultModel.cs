using Infrastructure;
using Infrastructure.Base;
using ShuPing.Infrastructure.StatusEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShuPing.WebApi.Models.Base
{
    /// <summary>
    /// WebApi返回结果类
    /// </summary>
    public class ApiResultModel : ApiResultModelBase
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }
    }

    /// <summary>
    /// WebApi返回结果类
    /// </summary>
    public class ApiResultModel<T> : ApiResultModelBase where T : class
    {
        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }
        public static ApiResultModel<T> CreateError(string message = "FAILURE")
        {
            return new ApiResultModel<T>
            {
                IsSuccess = false,
                Message = message
            };
        }

        public static ApiResultModel<T> CreateSuccess(T data)
        {
            return new ApiResultModel<T>
            {
                IsSuccess = true,
                Message = "SUCCESS",
                Data = data,
                StatusCode = StatusCode.成功
            };
        }
    }
}