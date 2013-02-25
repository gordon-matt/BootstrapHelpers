using System;
using System.IO;
using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class ButtonGroup : IDisposable
    {
        private readonly TextWriter textWriter;

        internal ButtonGroup(TextWriter writer)
        {
            this.textWriter = writer;
            this.textWriter.Write(@"<div class=""btn-group"">");
        }

        public void Button(string text, BootstrapNamedColor cssClass)
        {
            Button(text, cssClass, null);
        }

        public void Button(string text, BootstrapNamedColor cssClass, string onClick)
        {
            Button(text, cssClass, onClick, null);
        }

        public void Button(string text, BootstrapNamedColor cssClass, string onClick, object htmlAttributes)
        {
            var builder = new TagBuilder("input");
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("value", text);

            if (!string.IsNullOrEmpty(onClick))
            {
                builder.MergeAttribute("onclick", onClick);
            }

            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            switch (cssClass)
            {
                case BootstrapNamedColor.Important: builder.AddCssClass("btn btn-danger"); break;
                case BootstrapNamedColor.Default: builder.AddCssClass("btn"); break;
                case BootstrapNamedColor.Info: builder.AddCssClass("btn btn-info"); break;
                case BootstrapNamedColor.Inverse: builder.AddCssClass("btn btn-inverse"); break;
                case BootstrapNamedColor.Primary: builder.AddCssClass("btn btn-primary"); break;
                case BootstrapNamedColor.Success: builder.AddCssClass("btn btn-success"); break;
                case BootstrapNamedColor.Warning: builder.AddCssClass("btn btn-warning"); break;
                default: builder.AddCssClass("btn"); break;
            }

            this.textWriter.Write(builder.ToString(TagRenderMode.SelfClosing));
        }

        public void Dispose()
        {
            this.textWriter.Write("</div>");
        }
    }
}