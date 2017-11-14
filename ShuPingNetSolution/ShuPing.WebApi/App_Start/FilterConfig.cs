using ShuPing.WebApi.Attributes;
using System.Web;
using System.Web.Mvc;

namespace ShuPing.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
