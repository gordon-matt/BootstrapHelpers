using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class CarouselBuilder<TModel> : BuilderBase<TModel, Carousel>
    {
        private readonly UrlHelper urlHelper;
        private bool isFirstItem = true;

        internal CarouselBuilder(HtmlHelper<TModel> htmlHelper, Carousel carousel)
            : base(htmlHelper, carousel)
        {
            this.urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);
            base.textWriter.Write(@"<div class=""carousel-inner"">");
        }

        public void Item(string url, string altText)
        {
            if (isFirstItem)
            {
                base.textWriter.Write(@"<div class=""item active"">");
                isFirstItem = false;
            }
            else
            {
                base.textWriter.Write(@"<div class=""item"">");
            }

            base.textWriter.Write(string.Format(@"<img src=""{0}"" alt=""{1}"" />", urlHelper.Content(url), altText));
            base.textWriter.Write("</div>");
        }

        public CarouselCaptionPanel ItemWithCaption(string url, string altText, object htmlAttributes = null)
        {
            if (isFirstItem)
            {
                base.textWriter.Write(@"<div class=""item active"">");
                isFirstItem = false;
            }
            else
            {
                base.textWriter.Write(@"<div class=""item"">");
            }

            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttributes(HtmlAttributesUtility.ObjectToHtmlAttributesDictionary(htmlAttributes));
            imgBuilder.MergeAttribute("src", urlHelper.Content(url));
            imgBuilder.MergeAttribute("alt", altText);
            base.textWriter.Write(imgBuilder.ToString(TagRenderMode.SelfClosing));
            return new CarouselCaptionPanel(base.textWriter);
        }

        public override void Dispose()
        {
            base.textWriter.Write("</div>");

            base.textWriter.Write(string.Format(@"<a class=""left carousel-control"" data-slide=""prev"" href=""#{0}"">‹</a>", base.element.Id));
            base.textWriter.Write(string.Format(@"<a class=""right carousel-control"" data-slide=""next"" href=""#{0}"">›</a>", base.element.Id));

            base.textWriter.Write(base.element.EndTag);

            base.textWriter.Write(string.Format(
@"<script type=""text/javascript"">
    $(document).ready(function(){{
        $('#{0}').carousel({{
            interval: {1}
        }})
    }});
</script>", base.element.Id, base.element.Interval));
        }
    }
}