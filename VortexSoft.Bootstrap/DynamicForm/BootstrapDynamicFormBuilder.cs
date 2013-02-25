using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using VortexSoft.Bootstrap.Collections.Generic;
using VortexSoft.Bootstrap.Extensions;

namespace VortexSoft.Bootstrap
{
    public class BootstrapDynamicFormBuilder<TModel> : IDynamicFormBuilder<TModel>
    {
        protected readonly HtmlHelper<TModel> helper;

        public BootstrapDynamicFormBuilder(HtmlHelper<TModel> helper)
        {
            this.helper = helper;
        }

        public virtual MvcHtmlString Build(TModel model)
        {
            var sb = new StringBuilder(2000);

            using (var stringWriter = new StringWriter(sb))
            using (var textWriter = new HtmlTextWriter(stringWriter))
            {
                var properties = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                #region Hidden Fields

                var hiddenFields = new List<PropertyInfo>();

                foreach (var property in properties)
                {
                    var keyAttribute = property.GetCustomAttributes(typeof(KeyAttribute), false).FirstOrDefault() as KeyAttribute;
                    if (keyAttribute != null)
                    {
                        hiddenFields.Add(property);
                    }
                }

                foreach (var property in hiddenFields)
                {
                    textWriter.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
                    textWriter.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
                    textWriter.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
                    textWriter.AddAttribute(HtmlTextWriterAttribute.Value, property.GetValue(model, null).ToString());
                    textWriter.RenderBeginTag(HtmlTextWriterTag.Input);
                    textWriter.RenderEndTag();
                }

                #endregion Hidden Fields

                var groupedProperties = new PairCollection<string, PropertyInfo>();
                foreach (var property in properties)
                {
                    var displayAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

                    if (displayAttribute != null)
                    {
                        groupedProperties.Add(displayAttribute.GroupName, property);
                    }
                }

                bool useLegend = (groupedProperties.Select(x => x.First).Distinct().Count() > 1);
                foreach (var groupedProperty in groupedProperties.OrderBy(x => x.First).GroupBy(x => x.First))
                {
                    textWriter.RenderBeginTag(HtmlTextWriterTag.Fieldset);

                    if (useLegend)
                    {
                        if (!string.IsNullOrEmpty(groupedProperty.Key))
                        {
                            textWriter.RenderBeginTag(HtmlTextWriterTag.Legend);
                            textWriter.Write(groupedProperty.Key);
                            textWriter.RenderEndTag(); // legend
                        }
                        else
                        {
                            textWriter.RenderBeginTag(HtmlTextWriterTag.Legend);
                            textWriter.Write("General");
                            textWriter.RenderEndTag(); // legend
                        }
                    }

                    var orderedProperties = new PairCollection<int, PropertyInfo>();
                    foreach (var property in groupedProperty)
                    {
                        if (hiddenFields.Contains(property.Second))
                        {
                            continue;
                        }

                        var displayAttribute = property.Second.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

                        if (displayAttribute == null)
                        {
                            orderedProperties.Add(0, property.Second);
                        }
                        else
                        {
                            orderedProperties.Add(displayAttribute.GetOrder() ?? 0, property.Second);
                        }
                    }

                    foreach (var property in orderedProperties.OrderBy(x => x.First).Select(x => x.Second))
                    {
                        if (hiddenFields.Contains(property))
                        {
                            continue;
                        }

                        #region DisplayAttribute

                        string displayName = property.Name;
                        var displayAttribute = property.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

                        if (displayAttribute != null)
                        {
                            if (!string.IsNullOrEmpty(displayAttribute.Name))
                            {
                                displayName = displayAttribute.Name;
                            }
                        }

                        #endregion DisplayAttribute

                        // Control-Group
                        textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "control-group");
                        textWriter.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Label
                        textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "control-label");
                        textWriter.AddAttribute(HtmlTextWriterAttribute.For, property.Name);
                        textWriter.RenderBeginTag(HtmlTextWriterTag.Label);
                        textWriter.Write(displayName);
                        textWriter.RenderEndTag(); // label

                        // Controls Div
                        textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "controls");
                        textWriter.RenderBeginTag(HtmlTextWriterTag.Div);

                        // Control
                        RenderDynamicControl(textWriter, model, property);

                        textWriter.RenderEndTag(); // div (Controls Div)
                        textWriter.RenderEndTag(); // div (Control-Group)
                    }

                    textWriter.RenderEndTag(); // fieldset
                }

                // Buttons Control-Group
                textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "control-group");
                textWriter.RenderBeginTag(HtmlTextWriterTag.Div);

                // Controls Div
                textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "controls");
                textWriter.RenderBeginTag(HtmlTextWriterTag.Div);

                // Submit Button
                textWriter.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
                textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "btn btn-primary");
                textWriter.AddAttribute(HtmlTextWriterAttribute.Value, "Submit");
                textWriter.RenderBeginTag(HtmlTextWriterTag.Input);
                textWriter.RenderEndTag(); //</input>

                textWriter.Write("&nbsp;&nbsp;");

                // Cancel Button
                textWriter.AddAttribute(HtmlTextWriterAttribute.Type, "button");
                textWriter.AddAttribute(HtmlTextWriterAttribute.Class, "btn");
                textWriter.AddAttribute(HtmlTextWriterAttribute.Value, "Cancel");
                textWriter.AddAttribute(HtmlTextWriterAttribute.Onclick, "window.location = '" + helper.ViewContext.HttpContext.Request.UrlReferrer + "'");
                textWriter.RenderBeginTag(HtmlTextWriterTag.Input);
                textWriter.RenderEndTag(); //</input>

                textWriter.RenderEndTag(); // div (Controls Div)

                textWriter.RenderEndTag(); // div (Buttons Control-Group)

                return new MvcHtmlString(sb.ToString());
            }
        }

        protected void RenderDynamicControl(HtmlTextWriter writer, TModel model, PropertyInfo property)
        {
            //TODO: Use standard data annotations first to determine control type.
            // Example: DataTypeAttribute
            //Also TODO: implement standard validation stuff (like Html.ValidationMessageFor())..
            // even though we don't use that, a lot of people do and this is going open-source soon
            // so need to implement it.

            bool isRequired = false;

            var requiredAttribute = property.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault() as RequiredAttribute;
            if (requiredAttribute != null)
            {
                isRequired = true;
            }

            var value = property.GetValue(model, null);

            #region Boolean

            if (property.PropertyType.In(typeof(bool), typeof(bool?)))
            {
                RenderBoolean(writer, property, value);
            }

            #endregion Boolean

            #region DateTime

            else if (property.PropertyType.In(typeof(DateTime), typeof(DateTime?)))
            {
                RenderDateTime(writer, property, value, isRequired);
            }

            #endregion DateTime

            #region Byte, SByte, Int16, Int32, Int64, UInt16, UInt32, UInt64

            else if (property.PropertyType.In(
                typeof(byte), typeof(short), typeof(int), typeof(long), typeof(sbyte), typeof(ushort), typeof(uint), typeof(ulong),
                typeof(byte?), typeof(short?), typeof(int?), typeof(long?), typeof(sbyte?), typeof(ushort?), typeof(uint?), typeof(ulong?)))
            {
                RenderWholeNumber(writer, property, value, isRequired);
            }

            #endregion Byte, SByte, Int16, Int32, Int64, UInt16, UInt32, UInt64

            #region Decimal, Double, Single

            else if (property.PropertyType.In(
                typeof(decimal), typeof(double), typeof(float),
                typeof(decimal?), typeof(double?), typeof(float?)))
            {
                RenderFloatingPointNumber(writer, property, value, isRequired);
            }

            #endregion Decimal, Double, Single

            #region Enum

            else if (property.PropertyType.IsEnum)
            {
                RenderEnum(writer, property, value, isRequired);
            }

            #endregion Enum

            #region Collection

            //else if (property.PropertyType.IsCollection())
            //{
            //}

            #endregion Collection

            #region Strings

            else if (property.PropertyType == typeof(string))
            {
                RenderString(writer, property, value, isRequired);
            }

            else
            {
                CheckForOtherTypes(writer, property);
            }

            #endregion Strings
        }

        protected virtual void RenderBoolean(HtmlTextWriter writer, PropertyInfo property, object value)
        {
            if (Convert.ToBoolean(value))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
            writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
            writer.AddAttribute(HtmlTextWriterAttribute.Value, "true");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag(); // input

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
            writer.AddAttribute(HtmlTextWriterAttribute.Value, "false");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag(); // input
        }

        protected virtual void RenderDateTime(HtmlTextWriter writer, PropertyInfo property, object value, bool isRequired)
        {
            if (value != null && value != DBNull.Value)
            {
                var dt = Convert.ToDateTime(value);
                writer.AddAttribute(HtmlTextWriterAttribute.Value, dt.ToString("yyyy-MM-dd"));
            }

            if (isRequired)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required,custom[date]]");
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[custom[date]]");
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Maxlength, "10");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
            writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag(); // input
        }

        protected virtual void RenderWholeNumber(HtmlTextWriter writer, PropertyInfo property, object value, bool isRequired)
        {
            if (isRequired)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required,custom[integer]]");
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[custom[integer]]");
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Value, Convert.ToString(value));
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
            writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag(); // input
        }

        protected virtual void RenderFloatingPointNumber(HtmlTextWriter writer, PropertyInfo property, object value, bool isRequired)
        {
            if (isRequired)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required,custom[number]]");
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[custom[number]]");
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Value, Convert.ToString(value));
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
            writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
            writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag(); // input
        }

        protected virtual void RenderEnum(HtmlTextWriter writer, PropertyInfo property, object value, bool isRequired)
        {
            var dropDownList = new DropDownList();
            dropDownList.ID = property.Name;

            foreach (var fieldInfo in property.PropertyType.GetFields(BindingFlags.Public | BindingFlags.Static).OrderBy(x => x.Name))
            {
                var item = new ListItem(fieldInfo.Name.SpacePascal(), fieldInfo.GetRawConstantValue().ToString());
                dropDownList.Items.Add(item);
            }

            if (isRequired)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required]");
            }

            writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
            dropDownList.RenderControl(writer);
        }

        protected virtual void RenderString(HtmlTextWriter writer, PropertyInfo property, object value, bool isRequired)
        {
            // first check if there is a DataType attribute. If not, then use StringLenght to detemine if TextBox or TextArea..

            var dataTypeAttribute = property.GetCustomAttributes(typeof(DataTypeAttribute), false).FirstOrDefault() as DataTypeAttribute;
            var stringLengthAttribute = property.GetCustomAttributes(typeof(StringLengthAttribute), false).FirstOrDefault() as StringLengthAttribute;

            if (dataTypeAttribute != null)
            {
                if (dataTypeAttribute.DataType == DataType.Password)
                {
                    if (isRequired)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required]");
                    }
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "password");
                    if (stringLengthAttribute != null)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Maxlength, stringLengthAttribute.MaximumLength.ToString(CultureInfo.InvariantCulture));
                    }
                    writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
                    writer.RenderBeginTag(HtmlTextWriterTag.Input);
                    writer.RenderEndTag(); // </input>
                }
                else if (dataTypeAttribute.DataType == DataType.Text)
                {
                    if (isRequired)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required]");
                    }
                    writer.AddAttribute(HtmlTextWriterAttribute.Value, Convert.ToString(value));
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
                    if (stringLengthAttribute != null)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Maxlength, stringLengthAttribute.MaximumLength.ToString(CultureInfo.InvariantCulture));
                    }
                    writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
                    writer.RenderBeginTag(HtmlTextWriterTag.Input);
                    writer.RenderEndTag(); // </input>
                }

                // TODO: Implement Email input type, etc?
                else // Treat as Multi Line
                {
                    if (isRequired)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required]");
                    }

                    writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
                    writer.AddAttribute(HtmlTextWriterAttribute.Cols, "60");
                    writer.AddAttribute(HtmlTextWriterAttribute.Rows, "6");
                    writer.RenderBeginTag(HtmlTextWriterTag.Textarea);
                    writer.Write(value);
                    writer.RenderEndTag(); // </textarea>
                }
            }
            else
            {
                // Have no extra info about data type, so need to guess..
                // First, check if StringLengthAttribute exists.. if yes, then that's a good indication that it is a normal textbox
                // If there is no StringLengthAttribute, we will default to using a text area.
                if (stringLengthAttribute != null)
                {
                    if (isRequired)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required]");
                    }
                    writer.AddAttribute(HtmlTextWriterAttribute.Value, Convert.ToString(value));
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "text");
                    writer.AddAttribute(HtmlTextWriterAttribute.Maxlength, stringLengthAttribute.MaximumLength.ToString(CultureInfo.InvariantCulture));
                    writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
                    writer.RenderBeginTag(HtmlTextWriterTag.Input);
                    writer.RenderEndTag(); // </input>
                }
                else
                {
                    if (isRequired)
                    {
                        writer.AddAttribute(HtmlTextWriterAttribute.Class, "validate[required]");
                    }

                    writer.AddAttribute(HtmlTextWriterAttribute.Name, property.Name);
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, property.Name);
                    writer.AddAttribute(HtmlTextWriterAttribute.Cols, "60");
                    writer.AddAttribute(HtmlTextWriterAttribute.Rows, "6");
                    writer.RenderBeginTag(HtmlTextWriterTag.Textarea);
                    writer.Write(value);
                    writer.RenderEndTag(); // </textarea>
                }
            }
        }

        /// <summary>
        /// Override in child class to check for custom types
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="model"></param>
        /// <param name="property"></param>
        protected virtual void CheckForOtherTypes(HtmlTextWriter writer, PropertyInfo property)
        {
            // Default: Do Nothing..
        }
    }
}