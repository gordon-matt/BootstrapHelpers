namespace VortexSoft.Bootstrap
{
    public class Tabs : HtmlElement
    {
        internal string InternalPanelTag { get; private set; }

        internal string InternalTabTemplate { get; private set; }

        internal string InternalActiveTabTemplate { get; private set; }

        public Tabs()
            : this(TabPosition.Top, null)
        {
        }

        public Tabs(TabPosition position)
            : this(position, null)
        {
        }

        public Tabs(TabPosition position, object htmlAttributes)
            : base("div", htmlAttributes)
        {
            switch (position)
            {
                case TabPosition.Left: EnsureClass("tabbable tabs-left"); break;
                case TabPosition.Right: EnsureClass("tabbable tabs-right"); break;

                //case TabPosition.Bottom: EnsureClass("tabbable tabs-bottom"); break;
            }

            this.InternalTabTemplate = @"<li><a data-toggle=""tab"" href=""#{href}"">#{label}</a></li>";
            this.InternalActiveTabTemplate = @"<li class=""active""><a data-toggle=""tab"" href=""#{href}"">#{label}</a></li>";
            this.InternalPanelTag = "div";
        }
    }
}