using System.Web;
using System.Web.Mvc;

namespace ITSpark_AlameerAshraf
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
