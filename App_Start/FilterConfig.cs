using System.Web;
using System.Web.Mvc;

namespace Mvc_StoredProcedure_create
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
