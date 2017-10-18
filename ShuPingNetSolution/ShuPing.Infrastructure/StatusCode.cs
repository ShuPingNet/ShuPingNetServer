using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuPing.Infrastructure.StatusEnum
{
   
    public enum StatusCode : int
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        成功 = 200,
        /// <summary>
        /// 请求失败
        /// </summary>
        失败 = 403,
        /// <summary>
        /// 接口异常
        /// </summary>
        接口异常 = 500,
    }
}
