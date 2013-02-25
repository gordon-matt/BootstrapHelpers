namespace VortexSoft.Bootstrap
{
    public class Thumbnail : HtmlElement
    {
        internal string InternalImageTemplate { get; private set; }

        public string ImageSource { get; set; }

        public string ImageAltText { get; set; }

        public Thumbnail(string src, string alt)
            : this(src, alt, null, null)
        {
        }

        public Thumbnail(string src, string alt, object divHtmlAttributes, object imgHtmlAttributes)
            : base("div", divHtmlAttributes)
        {
            this.InternalImageTemplate = @"<img src=""#{src}"" alt=""#{alt}"" />";
            this.ImageSource = src;
            this.ImageAltText = alt;
            EnsureClass("thumbnail");
        }
    }
}