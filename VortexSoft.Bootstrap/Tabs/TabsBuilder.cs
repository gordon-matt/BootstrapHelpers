using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    public class TabsBuilder<TModel> : BuilderBase<TModel, Tabs>
    {
        private bool isHeaderClosed;
        private Queue<string> tabIds;
        private bool writingContent;
        private string activeTabId;

        private bool isFirstTab = true;

        internal TabsBuilder(HtmlHelper<TModel> htmlHelper, Tabs tabs)
            : base(htmlHelper, tabs)
        {
            this.tabIds = new Queue<string>();
            this.isHeaderClosed = false;
            this.writingContent = false;
            base.textWriter.Write(@"<ul class=""nav nav-tabs"">");
        }

        //public void AjaxTab(string label, string url)
        //{
        //    if (string.IsNullOrWhiteSpace(label))
        //    {
        //        throw new ArgumentNullException("label");
        //    }
        //    if (string.IsNullOrWhiteSpace(url))
        //    {
        //        throw new ArgumentNullException("url");
        //    }

        //    this.CheckBuilderState();
        //    this.WriteTab(label, url, false);
        //}

        public TabsPanel BeginPanel()
        {
            this.writingContent = true;
            this.CloseHeader();
            if (this.tabIds.Count == 0)
            {
                throw new InvalidOperationException("Tab definition not found. Use AddTab before creating a new panel.");
            }

            string tabId = this.tabIds.Dequeue();
            if (tabId == activeTabId)
            {
                base.textWriter.Write(@"<div class=""tab-content"">");
                isFirstTab = false;
                return new TabsPanel(base.textWriter, base.element.InternalPanelTag, tabId, true);
            }

            return new TabsPanel(base.textWriter, base.element.InternalPanelTag, tabId);
        }

        private void CheckBuilderState()
        {
            if (this.writingContent)
            {
                throw new InvalidOperationException("Tab definition cannot be mixed with content panels.");
            }
        }

        private void CloseHeader()
        {
            if (!this.isHeaderClosed)
            {
                base.textWriter.Write("</ul>");
                this.isHeaderClosed = true;
            }
        }

        public override void Dispose()
        {
            this.CloseHeader();

            // Close Tab Content Div:
            base.textWriter.Write("</div>");
            base.Dispose();
        }

        public void Tab(string label, string id)
        {
            if (string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentNullException("label");
            }
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            this.CheckBuilderState();
            string tabId = HtmlHelper.GenerateIdFromName(id);
            this.tabIds.Enqueue(tabId);

            if (isFirstTab)
            {
                activeTabId = tabId;
                this.WriteTab(label, "#" + tabId, true);
                isFirstTab = false;
            }
            else
            {
                this.WriteTab(label, "#" + tabId, false);
            }
        }

        private void WriteTab(string label, string href, bool isActive)
        {
            if (isActive)
            {
                base.textWriter.Write(base.element.InternalActiveTabTemplate.Replace("#{label}", label).Replace("#{href}", href));
            }
            else
            {
                base.textWriter.Write(base.element.InternalTabTemplate.Replace("#{label}", label).Replace("#{href}", href));
            }
        }
    }
}