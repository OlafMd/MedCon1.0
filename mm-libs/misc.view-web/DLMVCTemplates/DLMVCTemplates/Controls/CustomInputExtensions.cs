using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace DLMVCTemplates.Controls
{
    public static class CustomInputExtensions
    {
        public static MvcHtmlString CustomCheckBox(this HtmlHelper htmlHelper, string name, string text)
        {
            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBox(name).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;
          
            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);
        }
        public static MvcHtmlString CustomCheckBox(this HtmlHelper htmlHelper, string name,string text, bool isChecked)
        {
            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBox(name, isChecked).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);
        }
        public static MvcHtmlString CustomCheckBox(this HtmlHelper htmlHelper, string name, string text, IDictionary<string, object> htmlAttributes)
        {
            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBox(name, htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);
        
        }
        public static MvcHtmlString CustomCheckBox(this HtmlHelper htmlHelper, string name, string text, object htmlAttributes)
        {
            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBox(name, htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);
        
        }
        public static MvcHtmlString CustomCheckBox(this HtmlHelper htmlHelper, string name,string text, bool isChecked, IDictionary<string, object> htmlAttributes)
        {
            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBox(name,isChecked, htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);
        
        
        }
        public static MvcHtmlString CustomCheckBox(this HtmlHelper htmlHelper, string name, string text, bool isChecked, object htmlAttributes)
        {
            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBox(name, isChecked, htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key=="class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);
        }
        public static MvcHtmlString CustomCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression)
        {


            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBoxFor<TModel>(expression).ToString();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
            tag.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);

        }
        public static MvcHtmlString CustomCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, IDictionary<string, object> htmlAttributes)
        {
            string spanOpen = "<span class='mask-checkbox'>";
            string customCheckBox = htmlHelper.CheckBoxFor<TModel>(expression, htmlAttributes).ToString();

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");

            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";

            string CheckBoxFor = spanOpen + customCheckBox + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);

        }
        public static MvcHtmlString CustomCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes)
        {

            string spanOpen = "<span class='mask-checkbox'>";

            string customCheckBoxString = htmlHelper.CheckBoxFor<TModel>(expression, htmlAttributes).ToString();

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string CheckBoxFor = spanOpen + customCheckBoxString + icon + spanClose + label;
            return new MvcHtmlString(CheckBoxFor);

        }



        public static MvcHtmlString CustomRadioButton(this HtmlHelper htmlHelper, string name, object value, string text)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButton(name,value).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        
        }

        public static MvcHtmlString CustomRadioButton(this HtmlHelper htmlHelper, string name, object value, string text, bool isChecked)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButton(name, value, isChecked).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        }
        public static MvcHtmlString CustomRadioButton(this HtmlHelper htmlHelper, string name, object value, string text, IDictionary<string, object> htmlAttributes)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButton(name, value,htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        }
        public static MvcHtmlString CustomRadioButton(this HtmlHelper htmlHelper, string name, object value, string text, object htmlAttributes)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButton(name, value, htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        }
        public static MvcHtmlString CustomRadioButton(this HtmlHelper htmlHelper, string name, object value, string text, bool isChecked, IDictionary<string, object> htmlAttributes)
        {

            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButton(name, value,isChecked,htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        }
        public static MvcHtmlString CustomRadioButton(this HtmlHelper htmlHelper, string name, object value, string text, bool isChecked, object htmlAttributes)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButton(name, value, isChecked,htmlAttributes).ToString();
            string labelText = string.IsNullOrEmpty(text) ? name : text;

            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        }
        public static MvcHtmlString CustomRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButtonFor<TModel,TProperty>(expression, value).ToString();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
        
            tag.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        
        }
        public static MvcHtmlString CustomRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, IDictionary<string, object> htmlAttributes)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButtonFor<TModel, TProperty>(expression, value, htmlAttributes).ToString();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+label+ spanClose;
            return new MvcHtmlString(RadioButtonControl);
        
        }
        public static MvcHtmlString CustomRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value, object htmlAttributes)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButtonFor<TModel, TProperty>(expression, value, htmlAttributes).ToString();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
            tag.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton +icon+ label + spanClose;
            return new MvcHtmlString(RadioButtonControl);
        
        }

        public static MvcHtmlString CustomRadioButtonFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object value,string text, object htmlAttributes)
        {
            string spanOpen = "<span class='mask-radio'>";
            string radioButton = htmlHelper.RadioButtonFor<TModel, TProperty>(expression, value, htmlAttributes).ToString();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = text;
            if (String.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
            var htmlAttributesDict = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            foreach (var attribute in htmlAttributesDict)
            {
                if (attribute.Key == "class")
                {
                    if (attribute.Value.ToString().Contains("hidden-text"))
                        tag.AddCssClass("hidden-text block-element");
                }
            }
         
            tag.Attributes.Add("for", htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            string label = tag.ToString(TagRenderMode.Normal);
            string spanClose = "</span>";
            string icon = "<i class='icon'></i>";
            string RadioButtonControl = spanOpen + radioButton + icon + label + spanClose;
            return new MvcHtmlString(RadioButtonControl);

        }
    }
}
