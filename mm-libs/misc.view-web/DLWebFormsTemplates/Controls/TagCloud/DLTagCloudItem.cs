/*
 * Author: Milovan Regodic 
 * Email: milovan.regodic@danulabs.com
 * Date: November 2013
 */
using System;

namespace DLWebFormsTemplates.Controls
{
    [Serializable]
    public class DLTagCloudItem
    {
        public DLTagCloudItem()
        {
        }

        public DLTagCloudItem(string text, string value)
        {
            this._text = text;
            this._value = value;
        }

        public DLTagCloudItem(string text, string value, string title)
            : this(text, title)
        {
            this._title = title;
        }

        private string _text;

        /// <summary>
        /// Gets or sets the display text of item.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        private string _value;

        /// <summary>
        /// Get or sets the value of item.
        /// </summary>
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        private string _title;

        /// <summary>
        /// Gets or sets the title (tooltip) of the HTML anchor.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set { _title = value; }
        }

        #region Serailization Support
        private bool ShouldSerializeValue()
        {
            return !String.IsNullOrEmpty(_value);
        }

        private bool ShouldSerializeTitle()
        {
            return !String.IsNullOrEmpty(_title);
        }

        private bool ShouldSerializeText()
        {
            return !String.IsNullOrEmpty(_text);
        }
        #endregion
    }
}
