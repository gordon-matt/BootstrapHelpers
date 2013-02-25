using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class ThumbnailBuilder<TModel> : BuilderBase<TModel, Thumbnail>
    {
        internal ThumbnailBuilder(HtmlHelper<TModel> htmlHelper, Thumbnail thumbnail)
            : base(htmlHelper, thumbnail)
        {
            var urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            base.textWriter.Write(base.element.InternalImageTemplate
                .Replace("#{src}", urlHelper.Content(thumbnail.ImageSource))
                .Replace("#{alt}", thumbnail.ImageAltText));
        }

        public ThumbnailCaptionPanel BeginCaptionPanel()
        {
            return new ThumbnailCaptionPanel(base.textWriter);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}