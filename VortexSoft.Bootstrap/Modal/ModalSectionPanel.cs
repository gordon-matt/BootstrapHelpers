using System;
using System.IO;

namespace VortexSoft.Bootstrap
{
    internal enum ModalSection
    {
        Header,
        Body,
        Footer
    }

    public class ModalSectionPanel : IDisposable
    {
        private readonly TextWriter textWriter;

        internal ModalSectionPanel(ModalSection section, TextWriter writer)
        {
            this.textWriter = writer;

            switch (section)
            {
                case ModalSection.Header: this.textWriter.Write(@"<div class=""modal-header"">"); break;
                case ModalSection.Body: this.textWriter.Write(@"<div class=""modal-body"">"); break;
                case ModalSection.Footer: this.textWriter.Write(@"<div class=""modal-footer"">"); break;
            }
        }

        public void Dispose()
        {
            this.textWriter.Write("</div>");
        }
    }
}