using System.Collections.Generic;
using System.Web.Mvc;

namespace VortexSoft.Bootstrap
{
    internal static class HtmlAttributesUtility
    {
        // Methods
        public static IDictionary<string, object> ObjectToHtmlAttributesDictionary(object htmlAttributes)
        {
            IDictionary<string, object> dictionary = null;
            if (htmlAttributes == null)
            {
                return new Dictionary<string, object>();
            }
            dictionary = htmlAttributes as IDictionary<string, object>;
            if (dictionary == null)
            {
                dictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            }
            return dictionary;
        }
    }
}