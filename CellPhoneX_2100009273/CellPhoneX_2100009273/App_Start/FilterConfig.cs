using System.Web;
using System.Web.Mvc;

namespace CellPhoneX_2100009273
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
