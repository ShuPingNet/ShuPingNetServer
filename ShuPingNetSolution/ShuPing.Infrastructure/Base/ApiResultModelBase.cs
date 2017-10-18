using ShuPing.Infrastructure.StatusEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Base
{
    public class ApiResultModelBase
    {
        /// <summary>
        /// 本次调用是否成功
        /// </summary>
        public virtual bool IsSuccess { get; set; } 

        /// <summary>
        /// 返回Message
        /// </summary>
        public virtual string Message { get; set; }

        /// <summary>
        /// 返回状态
        /// </summary>
        public virtual StatusCode StatusCode { get; set; }
    }
}
