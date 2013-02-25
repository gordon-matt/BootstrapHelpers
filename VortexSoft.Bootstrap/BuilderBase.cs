using System;
using System.IO;
using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public abstract class BuilderBase<TModel, T> : IDisposable where T : HtmlElement
    {
        // Fields
        protected readonly T element;

        protected readonly TextWriter textWriter;
        protected readonly HtmlHelper<TModel> htmlHelper;

        // Methods
        internal BuilderBase(HtmlHelper<TModel> htmlHelper, T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            this.element = element;
            this.textWriter = htmlHelper.ViewContext.Writer;
            this.textWriter.Write(this.element.StartTag);
            this.htmlHelper = htmlHelper;
        }

        public virtual void Dispose()
        {
            this.textWriter.Write(this.element.EndTag);
        }
    }
}