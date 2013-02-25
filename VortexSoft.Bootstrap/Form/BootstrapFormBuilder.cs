using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace VortexSoft.Bootstrap
{
    public class BootstrapFormBuilder<TModel> : BuilderBase<TModel, BootstrapForm>
    {
        internal BootstrapFormBuilder(HtmlHelper<TModel> htmlHelper, BootstrapForm form)
            : base(htmlHelper, form)
        {
        }

        public ControlGroup<TModel> BeginControlGroup()
        {
            return new ControlGroup<TModel>(base.textWriter, htmlHelper);
        }

        #region Horizontal (Normal) Form

        #region CheckBox

        public void CheckBoxControlGroup(string name)
        {
            WriteControlGroup(name, htmlHelper.CheckBox(name));
        }

        public void CheckBoxControlGroup(string name, bool isChecked)
        {
            WriteControlGroup(name, htmlHelper.CheckBox(name, isChecked));
        }

        public void CheckBoxControlGroup(string name, object htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.CheckBox(name, htmlAttributes));
        }

        public void CheckBoxControlGroup(string name, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.CheckBox(name, htmlAttributes));
        }

        public void CheckBoxControlGroup(string name, bool isChecked, object htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.CheckBox(name, isChecked, htmlAttributes));
        }

        public void CheckBoxControlGroup(string name, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.CheckBox(name, isChecked, htmlAttributes));
        }

        public void CheckBoxControlGroupFor(Expression<Func<TModel, bool>> expression)
        {
            WriteControlGroup(expression, htmlHelper.CheckBoxFor(expression));
        }

        public void CheckBoxControlGroupFor(Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.CheckBoxFor(expression, htmlAttributes));
        }

        public void CheckBoxControlGroupFor(Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.CheckBoxFor(expression, htmlAttributes));
        }

        #endregion CheckBox

        #region DropDownList

        public void DropDownListControlGroup(string name)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name));
        }

        public void DropDownListControlGroup(string name, IEnumerable<SelectListItem> selectList)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name, selectList));
        }

        public void DropDownListControlGroup(string name, string optionLabel)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name, optionLabel));
        }

        public void DropDownListControlGroup(string name, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name, selectList, htmlAttributes));
        }

        public void DropDownListControlGroup(string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name, selectList, htmlAttributes));
        }

        public void DropDownListControlGroup(string name, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name, selectList, optionLabel));
        }

        public void DropDownListControlGroup(string name, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name, selectList, optionLabel, htmlAttributes));
        }

        public void DropDownListControlGroup(string name, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.DropDownList(name, selectList, optionLabel, htmlAttributes));
        }

        public void DropDownListControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList)
        {
            WriteControlGroup(expression, htmlHelper.DropDownListFor(expression, selectList));
        }

        public void DropDownListControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.DropDownListFor(expression, selectList, htmlAttributes));
        }

        public void DropDownListControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.DropDownListFor(expression, selectList, htmlAttributes));
        }

        public void DropDownListControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel)
        {
            WriteControlGroup(expression, htmlHelper.DropDownListFor(expression, selectList, optionLabel));
        }

        public void DropDownListControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes));
        }

        public void DropDownListControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes));
        }

        #endregion DropDownList

        #region Password

        public void PasswordControlGroup(string name)
        {
            WriteControlGroup(name, htmlHelper.Password(name));
        }

        public void PasswordControlGroup(string name, object value)
        {
            WriteControlGroup(name, htmlHelper.Password(name, value));
        }

        public void PasswordControlGroup(string name, object value, object htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.Password(name, value, htmlAttributes));
        }

        public void PasswordControlGroup(string name, object value, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.Password(name, value, htmlAttributes));
        }

        public void PasswordControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            WriteControlGroup(expression, htmlHelper.PasswordFor(expression));
        }

        public void PasswordControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.PasswordFor(expression, htmlAttributes));
        }

        public void PasswordControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.PasswordFor(expression, htmlAttributes));
        }

        #endregion Password

        #region TextBox

        public void TextBoxControlGroup(string name)
        {
            WriteControlGroup(name, htmlHelper.TextBox(name));
        }

        public void TextBoxControlGroup(string name, object value)
        {
            WriteControlGroup(name, htmlHelper.TextBox(name, value));
        }

        public void TextBoxControlGroup(string name, object value, object htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.TextBox(name, value, htmlAttributes));
        }

        public void TextBoxControlGroup(string name, object value, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.TextBox(name, value, htmlAttributes));
        }

        public void TextBoxControlGroup(string name, object value, string format)
        {
            WriteControlGroup(name, htmlHelper.TextBox(name, value, format));
        }

        public void TextBoxControlGroup(string name, object value, string format, object htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.TextBox(name, value, format, htmlAttributes));
        }

        public void TextBoxControlGroup(string name, object value, string format, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(name, htmlHelper.TextBox(name, value, format, htmlAttributes));
        }

        public void TextBoxControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            WriteControlGroup(expression, htmlHelper.TextBoxFor(expression));
        }

        public void TextBoxControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.TextBoxFor(expression, htmlAttributes));
        }

        public void TextBoxControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.TextBoxFor(expression, htmlAttributes));
        }

        public void TextBoxControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, string format)
        {
            WriteControlGroup(expression, htmlHelper.TextBoxFor(expression, format));
        }

        public void TextBoxControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, string format, object htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.TextBoxFor(expression, format, htmlAttributes));
        }

        public void TextBoxControlGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, string format, IDictionary<string, object> htmlAttributes)
        {
            WriteControlGroup(expression, htmlHelper.TextBoxFor(expression, format, htmlAttributes));
        }

        #endregion TextBox

        #endregion Horizontal (Normal) Form

        #region Inline Form

        public void LabelledCheckBoxFor(Expression<Func<TModel, bool>> expression)
        {
            var builder = new TagBuilder("label");
            builder.AddCssClass("checkbox");
            builder.InnerHtml = string.Concat(
                htmlHelper.CheckBoxFor(expression).ToString(),
                ExpressionHelper.GetExpressionText(expression));
            textWriter.Write(builder.ToString());
        }

        public void LabelledCheckBoxFor(Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {
            var builder = new TagBuilder("label");
            builder.AddCssClass("checkbox");
            builder.InnerHtml = string.Concat(
                htmlHelper.CheckBoxFor(expression, htmlAttributes).ToString(),
                ExpressionHelper.GetExpressionText(expression));
            textWriter.Write(builder.ToString());
        }

        public void LabelledCheckBoxFor(Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("label");
            builder.AddCssClass("checkbox");
            builder.InnerHtml = string.Concat(
                htmlHelper.CheckBoxFor(expression, htmlAttributes).ToString(),
                ExpressionHelper.GetExpressionText(expression));
            textWriter.Write(builder.ToString());
        }

        #endregion Inline Form

        private void WriteControlGroup(string name, MvcHtmlString controlHtml)
        {
            using (var group = BeginControlGroup())
            {
                group.ControlLabel(name);
                using (var controls = group.BeginControlsSection())
                {
                    base.textWriter.Write(controlHtml);
                }
            }
        }

        private void WriteControlGroup<TProperty>(Expression<Func<TModel, TProperty>> expression, MvcHtmlString controlHtml)
        {
            using (var group = BeginControlGroup())
            {
                group.ControlLabelFor(expression);
                using (var controls = group.BeginControlsSection())
                {
                    base.textWriter.Write(controlHtml);
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}