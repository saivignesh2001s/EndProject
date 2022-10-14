using System.Web;
using System.Web.Mvc;

namespace SimplilearnPhase3EndProject
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
