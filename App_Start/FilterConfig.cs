using System.Web;
using System.Web.Mvc;

namespace MuniraJiva_webMobi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
