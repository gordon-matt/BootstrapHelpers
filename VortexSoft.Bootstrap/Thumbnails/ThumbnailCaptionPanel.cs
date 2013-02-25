using System;
using System.IO;

namespace VortexSoft.Bootstrap
{
    public class ThumbnailCaptionPanel : IDisposable
    {
        private readonly TextWriter textWriter;

        internal ThumbnailCaptionPanel(TextWriter writer)
        {
            this.textWriter = writer;
            this.textWriter.Write(@"<div class=""caption"">");
        }

        public void Dispose()
        {
            this.textWriter.Write("</div>");
        }
    }
}