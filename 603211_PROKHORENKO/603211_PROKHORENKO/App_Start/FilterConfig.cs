using System.Web;
using System.Web.Mvc;

namespace _603211_PROKHORENKO
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
