using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class ModalBuilder<TModel> : BuilderBase<TModel, Modal>
    {
        internal ModalBuilder(HtmlHelper<TModel> htmlHelper, Modal modal)
            : base(htmlHelper, modal)
        {
        }

        public ModalSectionPanel BeginHeader()
        {
            return new ModalSectionPanel(ModalSection.Header, base.textWriter);
        }

        public ModalSectionPanel BeginBody()
        {
            return new ModalSectionPanel(ModalSection.Body, base.textWriter);
        }

        public ModalSectionPanel BeginFooter()
        {
            return new ModalSectionPanel(ModalSection.Footer, base.textWriter);
        }
    }
}