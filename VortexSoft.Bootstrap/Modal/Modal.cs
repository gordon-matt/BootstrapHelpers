namespace VortexSoft.Bootstrap
{
    public class Modal : HtmlElement
    {
        public Modal()
            : this(null)
        {
        }

        public Modal(object htmlAttributes)
            : base("div", htmlAttributes)
        {
            EnsureClass("modal hide");
        }
    }
}