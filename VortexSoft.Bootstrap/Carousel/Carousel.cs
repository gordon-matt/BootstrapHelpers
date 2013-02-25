using System;
using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class Carousel : HtmlElement
    {
        public string Id { get; set; }

        public uint Interval { get; set; }

        public Carousel(string id, bool slide = true, uint interval = 3500)
            : this(id, null, slide, interval)
        {
        }

        public Carousel(string id, object htmlAttributes, bool slide = true, uint interval = 3500)
            : base("div", htmlAttributes)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            this.Id = HtmlHelper.GenerateIdFromName(id);
            EnsureHtmlAttribute("id", this.Id);

            if (slide)
            {
                EnsureClass("carousel slide");
            }
            else
            {
                EnsureClass("carousel");
            }

            this.Interval = interval;
        }
    }
}