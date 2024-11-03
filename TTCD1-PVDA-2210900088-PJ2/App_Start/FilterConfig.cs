using System.Web;
using System.Web.Mvc;

namespace TTCD1_PVDA_2210900088_PJ2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
