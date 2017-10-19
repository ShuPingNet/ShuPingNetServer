using Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Infrastructure.StatusEnum
{
    public enum StatusCodeEnum : int
    {
        /// <summary>
        /// 请求(或处理)成功
        /// </summary>
        [Text("请求(或处理)成功")]
        Success = 200,

        /// <summary>
        /// 内部请求出错
        /// </summary>
        [Text("内部请求出错")]
        Error = 500,

        /// <summary>
        /// 未授权标识
        /// </summary>
        [Text("未授权标识")]
        Unauthorized = 401,

        /// <summary>
        /// 请求参数不完整或不正确
        /// </summary>
        [Text("请求参数不完整或不正确")]
        ParameterError = 400,

        /// <summary>
        /// 请求TOKEN失效
        /// </summary>
        [Text("请求TOKEN失效")]
        TokenInvalid = 403,

        /// <summary>
        /// HTTP请求类型不合法
        /// </summary>
        [Text("HTTP请求类型不合法")]
        HttpMehtodError = 405,

        /// <summary>
        /// HTTP请求不合法
        /// </summary>
        [Text("HTTP请求不合法,请求参数可能被篡改")]
        HttpRequestError = 406,

        /// <summary>
        /// HTTP请求不合法
        /// </summary>
        [Text("该URL已经失效")]
        URLExpireError = 407,
    }
}
