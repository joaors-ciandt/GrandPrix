using System;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Web.Mvc.Html;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomFramework.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        private const string Nbsp = "&nbsp;";

        public static MvcHtmlString NbspIfEmpty(this HtmlHelper helper, string value)
        {
            return new MvcHtmlString(string.IsNullOrEmpty(value) ? Nbsp : value);
        }

        #region CustomTextBox

        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression)
        {
            return CustomTextBoxFor(helper, Expression, null);
        }

        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, object htmlAttributes)
        {
            return CustomTextBoxFor(helper, Expression, htmlAttributes, false);
        }

        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, object htmlAttributes, bool ModelPlaceholder)
        {
            return CustomTextBoxFor(helper, Expression, htmlAttributes, ModelPlaceholder, false);
        }

        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, bool ModelPlaceholder)
        {
            return CustomTextBoxFor(helper, Expression, null, ModelPlaceholder, false);
        }

        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, bool ModelPlaceholder, bool readOnly)
        {
            return CustomTextBoxFor(helper, Expression, null, ModelPlaceholder, readOnly);
        }

        public static MvcHtmlString CustomTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, object htmlAttributes, bool ModelPlaceholder, bool readOnly)
        {

            var attributes = new Dictionary<string, object>();
            if (htmlAttributes != null)
            {
                var properties = htmlAttributes.GetType().GetProperties().ToList();
                foreach (var item in properties)
                {
                    attributes.Add(item.Name, item.GetValue(htmlAttributes, null));
                }
            }

            if (Expression != null)
            {
                var memberAccessExpression = (MemberExpression)Expression.Body;

                var stringLengthAttribs = memberAccessExpression.Member.GetCustomAttributes(
                    typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute), true);

                if (stringLengthAttribs != null && stringLengthAttribs.Length > 0)
                {
                    var length = ((StringLengthAttribute)stringLengthAttribs[0]).MaximumLength;

                    if (length > 0)
                    {
                        if (!attributes.ContainsKey("maxlength"))
                            attributes.Add("maxlength", length.ToString());
                    }
                }
            }

            if (ModelPlaceholder)
            {
                var display = ModelMetadata.FromLambdaExpression<TModel, TProperty>(Expression, helper.ViewData).DisplayName;
                if (!attributes.ContainsKey("placeholder"))
                    attributes.Add("placeholder", display);
            }

            if (readOnly)
            {
                if (!attributes.ContainsKey("readonly"))
                    attributes.Add("readonly", "true");
            }

            return InputExtensions.TextBoxFor(helper, Expression, attributes);
        }

        #endregion


        #region CustomPassword

        public static MvcHtmlString CustomPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression)
        {
            return CustomPasswordFor(helper, Expression, null, false);
        }

        public static MvcHtmlString CustomPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, bool ModelPlaceholder)
        {
            return CustomPasswordFor(helper, Expression, null, ModelPlaceholder);
        }

        public static MvcHtmlString CustomPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, object htmlAttributes)
        {
            return CustomPasswordFor(helper, Expression, htmlAttributes, false);
        }
        
        public static MvcHtmlString CustomPasswordFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> Expression, object htmlAttributes, bool ModelPlaceholder)
        {

            var attributes = new Dictionary<string, object>();
            if (htmlAttributes != null)
            {
                var properties = htmlAttributes.GetType().GetProperties().ToList();
                foreach (var item in properties)
                {
                    attributes.Add(item.Name, item.GetValue(htmlAttributes, null));
                }
            }

            if (Expression != null)
            {
                var memberAccessExpression = (MemberExpression)Expression.Body;

                var stringLengthAttribs = memberAccessExpression.Member.GetCustomAttributes(
                    typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute), true);

                if (stringLengthAttribs != null && stringLengthAttribs.Length > 0)
                {
                    var length = ((StringLengthAttribute)stringLengthAttribs[0]).MaximumLength;

                    if (length > 0)
                    {
                        if (!attributes.ContainsKey("maxlength"))
                            attributes.Add("maxlength", length.ToString());
                    }
                }
            }

            if (ModelPlaceholder)
            {
                var display = ModelMetadata.FromLambdaExpression<TModel, TProperty>(Expression, helper.ViewData).DisplayName;
                if (!attributes.ContainsKey("placeholder"))
                    attributes.Add("placeholder", display);
            }          

            return InputExtensions.PasswordFor(helper, Expression, attributes);
        }



        #endregion


    }
}
