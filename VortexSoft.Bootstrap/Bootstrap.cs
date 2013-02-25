using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace VortexSoft.Bootstrap
{
    public class Bootstrap<TModel>
    {
        private readonly HtmlHelper<TModel> helper;

        internal Bootstrap(HtmlHelper<TModel> helper)
        {
            this.helper = helper;
        }

        #region Accordion

        public AccordionBuilder<TModel> Begin(Accordion accordion)
        {
            if (accordion == null)
            {
                throw new ArgumentNullException("accordion");
            }

            return new AccordionBuilder<TModel>(this.helper, accordion);
        }

        #endregion Accordion

        #region Badge

        public MvcHtmlString Badge(string text, BootstrapNamedColor color, object htmlAttributes = null)
        {
            var builder = new TagBuilder("span");

            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            switch (color)
            {
                case BootstrapNamedColor.Important: builder.AddCssClass("badge badge-important"); break;
                case BootstrapNamedColor.Default: builder.AddCssClass("badge"); break;
                case BootstrapNamedColor.Info: builder.AddCssClass("badge badge-info"); break;
                case BootstrapNamedColor.Inverse: builder.AddCssClass("badge badge-inverse"); break;
                case BootstrapNamedColor.Primary: builder.AddCssClass("badge badge-primary"); break;
                case BootstrapNamedColor.Success: builder.AddCssClass("badge badge-success"); break;
                case BootstrapNamedColor.Warning: builder.AddCssClass("badge badge-warning"); break;
                default: builder.AddCssClass("badge"); break;
            }

            builder.InnerHtml = text;

            return MvcHtmlString.Create(builder.ToString());
        }

        #endregion Badge

        #region Buttons

        public MvcHtmlString ActionButton(string text, BootstrapNamedColor color, string actionName, string controllerName)
        {
            return ActionButton(text, color, actionName, controllerName, null);
        }

        public MvcHtmlString ActionButton(string text, BootstrapNamedColor color, string actionName, string controllerName, object routeValues)
        {
            return ActionButton(text, color, actionName, controllerName, routeValues, null);
        }

        public MvcHtmlString ActionButton(string text, BootstrapNamedColor color, string actionName, string controllerName, object routeValues, object htmlAttributes)
        {
            var builder = new TagBuilder("a");
            builder.SetInnerText(text);

            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            switch (color)
            {
                case BootstrapNamedColor.Important: builder.AddCssClass("btn btn-danger"); break;
                case BootstrapNamedColor.Default: builder.AddCssClass("btn"); break;
                case BootstrapNamedColor.Info: builder.AddCssClass("btn btn-info"); break;
                case BootstrapNamedColor.Inverse: builder.AddCssClass("btn btn-inverse"); break;
                case BootstrapNamedColor.Primary: builder.AddCssClass("btn btn-primary"); break;
                case BootstrapNamedColor.Success: builder.AddCssClass("btn btn-success"); break;
                case BootstrapNamedColor.Warning: builder.AddCssClass("btn btn-warning"); break;
                default: builder.AddCssClass("btn"); break;
            }

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            builder.MergeAttribute("href", urlHelper.Action(actionName, controllerName, routeValues));

            return MvcHtmlString.Create(builder.ToString());
        }

        //public MvcHtmlString ActionButton(string text, BootstrapNamedColor color, string actionName, string controllerName, object routeValues, object htmlAttributes)
        //{
        //    var builder = new TagBuilder("button");
        //    builder.MergeAttribute("type", "button");
        //    //builder.MergeAttribute("value", text);
        //    builder.SetInnerText(text);

        //    builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

        //    switch (color)
        //    {
        //        case BootstrapNamedColor.Important: builder.AddCssClass("btn btn-danger"); break;
        //        case BootstrapNamedColor.Default: builder.AddCssClass("btn"); break;
        //        case BootstrapNamedColor.Info: builder.AddCssClass("btn btn-info"); break;
        //        case BootstrapNamedColor.Inverse: builder.AddCssClass("btn btn-inverse"); break;
        //        case BootstrapNamedColor.Primary: builder.AddCssClass("btn btn-primary"); break;
        //        case BootstrapNamedColor.Success: builder.AddCssClass("btn btn-success"); break;
        //        case BootstrapNamedColor.Warning: builder.AddCssClass("btn btn-warning"); break;
        //        default: builder.AddCssClass("btn"); break;
        //    }

        //    var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
        //    builder.MergeAttribute("onclick", string.Format("window.location = '{0}'", urlHelper.Action(actionName, controllerName, routeValues)));

        //    return MvcHtmlString.Create(builder.ToString());
        //}

        public MvcHtmlString Button(string text, BootstrapNamedColor color)
        {
            return Button(text, color, null);
        }

        public MvcHtmlString Button(string text, BootstrapNamedColor color, string onClick)
        {
            return Button(text, color, onClick, null);
        }

        public MvcHtmlString Button(string text, BootstrapNamedColor color, string onClick, object htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.MergeAttribute("type", "button");
            //builder.MergeAttribute("value", text);
            builder.SetInnerText(text);

            if (!string.IsNullOrEmpty(onClick))
            {
                builder.MergeAttribute("onclick", onClick);
            }

            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            switch (color)
            {
                case BootstrapNamedColor.Important: builder.AddCssClass("btn btn-danger"); break;
                case BootstrapNamedColor.Default: builder.AddCssClass("btn"); break;
                case BootstrapNamedColor.Info: builder.AddCssClass("btn btn-info"); break;
                case BootstrapNamedColor.Inverse: builder.AddCssClass("btn btn-inverse"); break;
                case BootstrapNamedColor.Primary: builder.AddCssClass("btn btn-primary"); break;
                case BootstrapNamedColor.Success: builder.AddCssClass("btn btn-success"); break;
                case BootstrapNamedColor.Warning: builder.AddCssClass("btn btn-warning"); break;
                default: builder.AddCssClass("btn"); break;
            }

            return MvcHtmlString.Create(builder.ToString());
        }

        public MvcHtmlString SubmitButton(string text, BootstrapNamedColor color)
        {
            return SubmitButton(text, color, null);
        }

        public MvcHtmlString SubmitButton(string text, BootstrapNamedColor color, object htmlAttributes)
        {
            var builder = new TagBuilder("button");
            builder.MergeAttribute("type", "submit");
            //builder.MergeAttribute("value", text);
            builder.SetInnerText(text);

            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            switch (color)
            {
                case BootstrapNamedColor.Important: builder.AddCssClass("btn btn-danger"); break;
                case BootstrapNamedColor.Default: builder.AddCssClass("btn"); break;
                case BootstrapNamedColor.Info: builder.AddCssClass("btn btn-info"); break;
                case BootstrapNamedColor.Inverse: builder.AddCssClass("btn btn-inverse"); break;
                case BootstrapNamedColor.Primary: builder.AddCssClass("btn btn-primary"); break;
                case BootstrapNamedColor.Success: builder.AddCssClass("btn btn-success"); break;
                case BootstrapNamedColor.Warning: builder.AddCssClass("btn btn-warning"); break;
                default: builder.AddCssClass("btn"); break;
            }

            return MvcHtmlString.Create(builder.ToString());
        }

        #endregion Buttons

        #region Carousel

        public CarouselBuilder<TModel> Begin(Carousel carousel)
        {
            if (carousel == null)
            {
                throw new ArgumentNullException("carousel");
            }

            return new CarouselBuilder<TModel>(this.helper, carousel);
        }

        #endregion Carousel

        #region CodeBlock

        public MvcHtmlString CodeBlock(string text, bool prettyify = true, bool showLineNumbers = true, object htmlAttributes = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            var builder = new TagBuilder("pre");
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            if (showLineNumbers)
            {
                builder.AddCssClass("linenums");
            }
            if (prettyify)
            {
                builder.AddCssClass("prettyprint");
            }
            builder.InnerHtml = text;

            return MvcHtmlString.Create(builder.ToString());
        }

        #endregion CodeBlock

        #region Forms

        #region DynamicForm

        private static BootstrapDynamicFormBuilder<TModel> defaultDynamicFormBuilder;

        private static BootstrapDynamicFormBuilder<TModel> DefaultDynamicFormBuilder(HtmlHelper<TModel> helper)
        {
            if (defaultDynamicFormBuilder == null)
            {
                defaultDynamicFormBuilder = new BootstrapDynamicFormBuilder<TModel>(helper);
            }
            return defaultDynamicFormBuilder;
        }

        public MvcHtmlString DynamicForm()
        {
            return DynamicForm(DefaultDynamicFormBuilder(helper));
        }

        public MvcHtmlString DynamicForm(IDynamicFormBuilder<TModel> builder)
        {
            return builder.Build(helper.ViewData.Model);
        }

        #endregion DynamicForm

        public BootstrapFormBuilder<TModel> BeginForm()
        {
            return BeginForm(BootstrapFormType.Horizontal);
        }

        public BootstrapFormBuilder<TModel> BeginForm(object htmlAttributes)
        {
            string rawUrl = this.helper.ViewContext.HttpContext.Request.RawUrl;
            return new BootstrapFormBuilder<TModel>(
                this.helper, new BootstrapForm(BootstrapFormType.Horizontal, rawUrl, FormMethod.Post, new RouteValueDictionary(htmlAttributes)));
        }

        public BootstrapFormBuilder<TModel> BeginForm(IDictionary<string, object> htmlAttributes)
        {
            string rawUrl = this.helper.ViewContext.HttpContext.Request.RawUrl;
            return new BootstrapFormBuilder<TModel>(
                this.helper, new BootstrapForm(BootstrapFormType.Horizontal, rawUrl, FormMethod.Post, htmlAttributes));
        }

        public BootstrapFormBuilder<TModel> BeginForm(BootstrapFormType formType)
        {
            string rawUrl = this.helper.ViewContext.HttpContext.Request.RawUrl;
            return new BootstrapFormBuilder<TModel>(
                this.helper, new BootstrapForm(formType, rawUrl, FormMethod.Post, new RouteValueDictionary()));
        }

        public BootstrapFormBuilder<TModel> BeginForm(BootstrapFormType formType, object htmlAttributes)
        {
            string rawUrl = this.helper.ViewContext.HttpContext.Request.RawUrl;
            return new BootstrapFormBuilder<TModel>(
                this.helper, new BootstrapForm(formType, rawUrl, FormMethod.Post, new RouteValueDictionary(htmlAttributes)));
        }

        public BootstrapFormBuilder<TModel> BeginForm(BootstrapFormType formType, IDictionary<string, object> htmlAttributes)
        {
            string rawUrl = this.helper.ViewContext.HttpContext.Request.RawUrl;
            return new BootstrapFormBuilder<TModel>(
                this.helper, new BootstrapForm(formType, rawUrl, FormMethod.Post, htmlAttributes));
        }

        public BootstrapFormBuilder<TModel> BeginForm(object routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(null, null, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(RouteValueDictionary routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(null, null, routeValues, FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, object routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, FormMethod method, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, new RouteValueDictionary(), method, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, RouteValueDictionary routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, routeValues, FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, object routeValues, FormMethod method, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, FormMethod method, IDictionary<string, object> htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, new RouteValueDictionary(), method, htmlAttributes, formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, FormMethod method, object htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, new RouteValueDictionary(), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, routeValues, method, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, object routeValues, FormMethod method, object htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginForm(actionName, controllerName, new RouteValueDictionary(routeValues), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), formType);
        }

        public BootstrapFormBuilder<TModel> BeginForm(string actionName, string controllerName, RouteValueDictionary routeValues, FormMethod method, IDictionary<string, object> htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            string formAction = UrlHelper.GenerateUrl(null, actionName, controllerName, routeValues, this.helper.RouteCollection, this.helper.ViewContext.RequestContext, true);
            return new BootstrapFormBuilder<TModel>(
                this.helper, new BootstrapForm(formType, formAction, method, htmlAttributes));
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(object routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(null, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, new RouteValueDictionary(), FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(RouteValueDictionary routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(null, routeValues, FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, object routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, new RouteValueDictionary(routeValues), FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, FormMethod method, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, new RouteValueDictionary(), method, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, RouteValueDictionary routeValues, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, routeValues, FormMethod.Post, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, object routeValues, FormMethod method, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, new RouteValueDictionary(routeValues), method, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, FormMethod method, IDictionary<string, object> htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, new RouteValueDictionary(), method, htmlAttributes, formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, FormMethod method, object htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, new RouteValueDictionary(), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, RouteValueDictionary routeValues, FormMethod method, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, routeValues, method, new RouteValueDictionary(), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, object routeValues, FormMethod method, object htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            return BeginRouteForm(routeName, new RouteValueDictionary(routeValues), method, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes), formType);
        }

        public BootstrapFormBuilder<TModel> BeginRouteForm(string routeName, RouteValueDictionary routeValues, FormMethod method, IDictionary<string, object> htmlAttributes, BootstrapFormType formType = BootstrapFormType.Horizontal)
        {
            string formAction = UrlHelper.GenerateUrl(routeName, null, null, routeValues, this.helper.RouteCollection, this.helper.ViewContext.RequestContext, false);
            return new BootstrapFormBuilder<TModel>(
                this.helper, new BootstrapForm(formType, formAction, method, htmlAttributes));
        }

        #endregion Forms

        #region Hero Unit

        public HeroUnitBuilder<TModel> Begin(HeroUnit heroUnit)
        {
            if (heroUnit == null)
            {
                throw new ArgumentNullException("heroUnit");
            }

            return new HeroUnitBuilder<TModel>(this.helper, heroUnit);
        }

        #endregion Hero Unit

        #region Inline Label

        public MvcHtmlString InlineLabel(string text, BootstrapNamedColor color, object htmlAttributes = null)
        {
            var builder = new TagBuilder("span");

            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            switch (color)
            {
                case BootstrapNamedColor.Important: builder.AddCssClass("label label-important"); break;
                case BootstrapNamedColor.Default: builder.AddCssClass("label"); break;
                case BootstrapNamedColor.Info: builder.AddCssClass("label label-info"); break;
                case BootstrapNamedColor.Inverse: builder.AddCssClass("label label-inverse"); break;
                case BootstrapNamedColor.Primary: builder.AddCssClass("label label-primary"); break;
                case BootstrapNamedColor.Success: builder.AddCssClass("label label-success"); break;
                case BootstrapNamedColor.Warning: builder.AddCssClass("label label-warning"); break;
                default: builder.AddCssClass("label"); break;
            }

            builder.InnerHtml = text;

            return MvcHtmlString.Create(builder.ToString());
        }

        #endregion Inline Label

        #region Modal (Dialog)

        public ModalBuilder<TModel> Begin(Modal modal)
        {
            if (modal == null)
            {
                throw new ArgumentNullException("modal");
            }

            return new ModalBuilder<TModel>(this.helper, modal);
        }

        #endregion Modal (Dialog)

        #region MoneyBox

        public MvcHtmlString MoneyBox(string name, string currencySymbol, uint dollars, object htmlAttributes = null)
        {
            return MoneyBox(name, currencySymbol, dollars, 0, true, htmlAttributes);
        }

        public MvcHtmlString MoneyBox(string name, string currencySymbol, uint dollars, uint cents = 0, bool showCents = true, object htmlAttributes = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name");
            }

            var builder = new TagBuilder("div");
            builder.AddCssClass("input-prepend");

            if (showCents)
            {
                builder.AddCssClass("input-append");
            }

            var sb = new StringBuilder();
            sb.Append(@"<span class=""add-on"">");
            sb.Append(string.IsNullOrEmpty(currencySymbol) ? "$" : currencySymbol);
            sb.Append("</span>");
            sb.Append(helper.TextBox(name, dollars, htmlAttributes));

            if (showCents)
            {
                sb.Append(@"<span class=""add-on"">.");
                sb.Append(cents < 10 ? "0" + cents : cents.ToString());
                sb.Append("</span>");
            }

            builder.InnerHtml = sb.ToString();

            return MvcHtmlString.Create(builder.ToString());
        }

        #endregion MoneyBox

        #region Quotes

        public MvcHtmlString Quote(string text, string author, object htmlAttributes = null)
        {
            return Quote(text, author, null, htmlAttributes);
        }

        public MvcHtmlString Quote(string text, string author, string titleOfWork, object htmlAttributes = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            var builder = new TagBuilder("blockquote");
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(text);
            sb.Append("</p>");

            if (!string.IsNullOrEmpty(author))
            {
                sb.Append("<small>");
                sb.Append(author);

                if (!string.IsNullOrEmpty(titleOfWork))
                {
                    sb.Append(", ");
                    sb.Append("<cite>");
                    sb.Append(titleOfWork);
                    sb.Append("</cite>");
                }

                sb.Append("</small>");
            }

            builder.InnerHtml = sb.ToString();

            return MvcHtmlString.Create(builder.ToString());
        }

        #endregion Quotes

        #region SubNavBar

        //TODO: The styling for subnav on the bootstrap demo site is not included in Bootstrap CSS file..
        // It comes from docs.css. See this link:
        // http://stackoverflow.com/questions/11661559/bootstrap-subnav-does-not-have-the-same-style-as-on-demo-site
        // We can add it later if needed

        public SubNavBarBuilder<TModel> Begin(SubNavBar subNav)
        {
            if (subNav == null)
            {
                throw new ArgumentNullException("subNav");
            }

            return new SubNavBarBuilder<TModel>(this.helper, subNav);
        }

        #endregion SubNavBar

        #region Tabs

        public TabsBuilder<TModel> Begin(Tabs tabs)
        {
            if (tabs == null)
            {
                throw new ArgumentNullException("tabs");
            }

            return new TabsBuilder<TModel>(this.helper, tabs);
        }

        #endregion Tabs

        #region Thumbnails

        public MvcHtmlString Thumbnail(string src, string alt, object aHtmlAttributes = null, object imgHtmlAttributes = null)
        {
            return Thumbnail(src, alt, null, aHtmlAttributes, imgHtmlAttributes);
        }

        public MvcHtmlString Thumbnail(string src, string alt, string href, object aHtmlAttributes = null, object imgHtmlAttributes = null)
        {
            var aBuilder = new TagBuilder("a");
            aBuilder.MergeAttribute("href", href);
            aBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(aHtmlAttributes));
            aBuilder.MergeAttribute("class", "thumbnail");

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var imgBuilder = new TagBuilder("img");
            imgBuilder.MergeAttribute("src", urlHelper.Content(src));
            imgBuilder.MergeAttribute("alt", alt);
            imgBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(imgHtmlAttributes));

            aBuilder.InnerHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

            return MvcHtmlString.Create(aBuilder.ToString());
        }

        public ThumbnailBuilder<TModel> Begin(Thumbnail thumbnail)
        {
            if (thumbnail == null)
            {
                throw new ArgumentNullException("thumbnail");
            }

            return new ThumbnailBuilder<TModel>(this.helper, thumbnail);
        }

        #endregion Thumbnails

        #region Toolbar

        public ToolbarBuilder<TModel> Begin(Toolbar toolbar)
        {
            if (toolbar == null)
            {
                throw new ArgumentNullException("tabs");
            }

            return new ToolbarBuilder<TModel>(this.helper, toolbar);
        }

        #endregion Toolbar
    }
}