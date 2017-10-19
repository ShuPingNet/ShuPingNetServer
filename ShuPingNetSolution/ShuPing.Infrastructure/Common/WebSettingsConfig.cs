using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common
{
    public class WebSettingsConfig
    {
        /// <summary>
        /// 设置过期时间
        /// </summary>
        public static string UrlExpireTime
        {
            get
            {
                return "10";
            }
        }
    }
}
