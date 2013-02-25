using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public interface IDynamicFormBuilder<TModel>
    {
        MvcHtmlString Build(TModel model);
    }
}