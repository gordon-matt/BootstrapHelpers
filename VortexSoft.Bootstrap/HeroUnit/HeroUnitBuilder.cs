using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class HeroUnitBuilder<TModel> : BuilderBase<TModel, HeroUnit>
    {
        internal HeroUnitBuilder(HtmlHelper<TModel> htmlHelper, HeroUnit heroUnit)
            : base(htmlHelper, heroUnit)
        {
            base.textWriter.Write("<h1>");
            base.textWriter.Write(heroUnit.Heading);
            base.textWriter.Write("</h1>");

            base.textWriter.Write("<p>");
            base.textWriter.Write(heroUnit.Tagline);
            base.textWriter.Write("</p>");

            base.textWriter.Write("<p>");
        }

        public override void Dispose()
        {
            base.textWriter.Write("</p>");
            base.Dispose();
        }
    }
}