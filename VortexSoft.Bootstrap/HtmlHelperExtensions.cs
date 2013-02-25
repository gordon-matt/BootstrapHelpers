using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public static class HtmlHelperExtensions
    {
        public static Bootstrap<TModel> Bootstrap<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new Bootstrap<TModel>(htmlHelper);
        }
    }
}