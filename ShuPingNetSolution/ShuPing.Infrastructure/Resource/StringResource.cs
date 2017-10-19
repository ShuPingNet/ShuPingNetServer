using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Resource
{
    public class StringResource
    {
        #region 安全验证相关参数
        /// <summary>
        /// 唯一标识
        /// </summary>
        public static readonly string StaffId = "staffid";
        /// <summary>
        /// 时间戳
        /// </summary>
        public static readonly string TimeStamp = "timestamp";
        /// <summary>
        /// Guid
        /// </summary>
        public static readonly string Nonce = "nonce";
        /// <summary>
        /// 验签
        /// </summary>
        public static readonly string Signature = "signature";
        /// <summary>
        /// 
        /// </summary>
        public static readonly string GetToken = "GetToken";

        #endregion
        #region 请求方式
        public const  string Get = "GET";
        public const  string Post = "POST";
        #endregion


        #region 日志记录相关参数
        public const string Stopwatch = "[Stopwatch]";
        #endregion

    }
}
