using System;
using System.Web.Mvc;
using System.Web.UI;
using JQueryUIHelpers;

namespace VortexSoft.Bootstrap.Demo.Web.UI
{
    public class CustomDynamicFormBuilder<TModel> : BootstrapDynamicFormBuilder<TModel>
    {
        public CustomDynamicFormBuilder(HtmlHelper<TModel> helper)
            : base(helper)
        {
        }

        protected override void RenderDateTime(HtmlTextWriter writer, System.Reflection.PropertyInfo property, object value, bool isRequired)
        {
            //TODO: add validation

            var dt = Convert.ToDateTime(value);
            var datePicker = helper.JQueryUI().Datepicker(property.Name, dt).ChangeYear(true).ChangeMonth(true);
            writer.Write(datePicker.ToHtmlString());
        }
    }
}