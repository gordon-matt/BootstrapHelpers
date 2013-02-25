using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class SubNavBarBuilder<TModel> : BuilderBase<TModel, SubNavBar>
    {
        internal SubNavBarBuilder(HtmlHelper<TModel> htmlHelper, SubNavBar subNavBar)
            : base(htmlHelper, subNavBar)
        {
            base.textWriter.Write(@"<ul class=""nav nav-pills"">");
        }

        public void Item(string text, string href, string cssClass = "")
        {
            base.textWriter.Write(base.element.InternalItemTemplate
                .Replace("#{text}", text)
                .Replace("#{href}", href)
                .Replace("#{css}", cssClass));
        }

        public void DropDownItem(string text, IEnumerable<BootstrapListItem> items)
        {
            var builder = new TagBuilder("li");
            builder.AddCssClass("dropdown");

            var sb = new StringBuilder();
            sb.Append(@"<a class=""dropdown-toggle"" href=""#"" data-toggle=""dropdown"">");
            sb.Append(text);
            sb.Append(@"<b class=""caret""></b></a><ul class=""dropdown-menu"">");

            foreach (var item in items)
            {
                sb.AppendFormat(@"<li><a href=""{0}"">{1}</a></li>", item.Url, item.Text);
            }

            sb.Append("</ul>");

            builder.InnerHtml = sb.ToString();

            base.textWriter.Write(builder.ToString());
        }

        public override void Dispose()
        {
            base.textWriter.Write("</ul>");
            base.Dispose();
        }
    }
}