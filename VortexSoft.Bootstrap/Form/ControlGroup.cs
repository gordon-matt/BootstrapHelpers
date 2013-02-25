using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace VortexSoft.Bootstrap
{
    public class ControlGroup<TModel> : IDisposable
    {
        private readonly TextWriter textWriter;
        private readonly HtmlHelper<TModel> htmlHelper;

        internal ControlGroup(TextWriter writer, HtmlHelper<TModel> htmlHelper)
        {
            this.textWriter = writer;
            this.textWriter.Write(@"<div class=""control-group"">");
            this.htmlHelper = htmlHelper;
        }

        #region Label

        public void ControlLabel(string expression)
        {
            ControlLabel(expression, new RouteValueDictionary());
        }

        public void ControlLabel(string expression, object htmlAttributes)
        {
            ControlLabel(expression, htmlAttributes == null ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttributes));
        }

        public void ControlLabel(string expression, IDictionary<string, object> htmlAttributes)
        {
            EnsureHtmlAttribute(htmlAttributes, "class", "control-label");
            this.textWriter.Write(htmlHelper.Label(expression, htmlAttributes));
        }

        public void ControlLabel(string expression, string labelText)
        {
            ControlLabel(expression, labelText, null);
        }

        public void ControlLabel(string expression, string labelText, object htmlAttributes)
        {
            ControlLabel(expression, labelText, htmlAttributes == null ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttributes));
        }

        public void ControlLabel(string expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            EnsureHtmlAttribute(htmlAttributes, "class", "control-label");
            this.textWriter.Write(htmlHelper.Label(expression, labelText, htmlAttributes));
        }

        public void ControlLabelFor<TValue>(Expression<Func<TModel, TValue>> expression)
        {
            ControlLabelFor(expression, new RouteValueDictionary());
        }

        public void ControlLabelFor<TValue>(Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            ControlLabelFor(expression, htmlAttributes == null ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttributes));
        }

        public void ControlLabelFor<TValue>(Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            EnsureHtmlAttribute(htmlAttributes, "class", "control-label");
            this.textWriter.Write(htmlHelper.LabelFor(expression, htmlAttributes));
        }

        public void ControlLabelFor<TValue>(Expression<Func<TModel, TValue>> expression, string labelText)
        {
            ControlLabelFor(expression, labelText, null);
        }

        public void ControlLabelFor<TValue>(Expression<Func<TModel, TValue>> expression, string labelText, object htmlAttributes)
        {
            ControlLabelFor(expression, labelText, htmlAttributes == null ? new RouteValueDictionary() : new RouteValueDictionary(htmlAttributes));
        }

        public void ControlLabelFor<TValue>(Expression<Func<TModel, TValue>> expression, string labelText, IDictionary<string, object> htmlAttributes)
        {
            EnsureHtmlAttribute(htmlAttributes, "class", "control-label");
            this.textWriter.Write(htmlHelper.LabelFor(expression, labelText, htmlAttributes));
        }

        #endregion Label

        public ControlsSection BeginControlsSection()
        {
            return new ControlsSection(this.textWriter);
        }

        public void Dispose()
        {
            this.textWriter.Write("</div>");
        }

        protected void EnsureHtmlAttribute(IDictionary<string, object> attributes, string key, string value)
        {
            if (attributes == null)
            {
                attributes = new RouteValueDictionary();
            }

            if (attributes.ContainsKey(key))
            {
                attributes[key] += " " + value;
            }
            else
            {
                attributes.Add(key, value);
            }
        }
    }
}