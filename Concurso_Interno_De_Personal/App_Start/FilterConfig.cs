using System.Web;
using System.Web.Mvc;

namespace Concurso_Interno_De_Personal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
