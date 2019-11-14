/*
 * Author: Milovan Regodic 
 * Email: milovan.regodic@danulabs.com
 * Date: November 2013
 */
using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;

namespace DLWebFormsTemplates.Controls
{
    public class DLTagCloud : CompositeDataBoundControl, IPostBackEventHandler
    {
        #region Private Members
        private Collection<DLTagCloudItem> _items = new Collection<DLTagCloudItem>();
        #endregion

        #region Properties
        /// <summary>
        /// Collection of DLTagCloudItems. <see cref="DLTagCloudItem"/> 
        /// </summary>
        [Themeable(false), PersistenceMode(PersistenceMode.InnerProperty), MergableProperty(false)]
        public Collection<DLTagCloudItem> Items
        {
            get
            {
                return _items;
            }
        }
        #endregion

        #region Design Properties

        /// <summary>
        ///     Gets or sets enabled add new item.
        /// </summary>
        /// <value> Is enabled adding new item. </value>
        [Category("Behavior")]
        public bool EnabledAddItem { get; set; }

        /// <summary>
        ///     Gets or sets enabled click on item.
        /// </summary>
        /// <value> Is enabled click on item. </value>
        [Category("Behavior")]
        public bool EnabledItemClick { get; set; }

        /// <summary>
        ///     Gets or sets enabled delete on item.
        /// </summary>
        /// <value> Is enabled delete on item. </value>
        [Category("Behavior")]
        public bool EnabledItemDelete { get; set; }

        /// <summary>
        /// Gets or sets the name of the data field that is bound to the Text property of an item.
        /// </summary>
        [Category("Data")]
        [TypeConverter(typeof(DataFieldConverter))]
        public string DataTextField
        {
            get
            {
                string val = ViewState[this.ID + "DataTextField"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTextField"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the format string for the Text property.
        /// </summary>
        [Category("Data")]
        public string DataTextFormatString
        {
            get
            {
                string val = ViewState[this.ID + "DataTextFormatString"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTextFormatString"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }


        /// <summary>
        /// Gets or sets the data field which is bound to the Value property of an item.
        /// </summary>
        [Category("Data")]
        [TypeConverter(typeof(DataFieldConverter))]
        public string DataValueField
        {
            get
            {
                string val = ViewState[this.ID + "DataValueField"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataValueField"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data field which is bound to the Title property of an item.
        /// </summary>
        [Category("Data")]
        [TypeConverter(typeof(DataFieldConverter))]
        public string DataTitleField
        {
            get
            {
                string val = ViewState[this.ID + "DataTitleField"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTitleField"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// The format string for the title(tooltip) of an item. {0} in this string is replaced with the
        /// value of the field specified as the DataTitleField.
        /// </summary>
        [Category("Data")]
        public string DataTitleFormatString
        {
            get
            {
                string val = ViewState[this.ID + "DataTitleFormatString"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "DataTitleFormatString"] = value;

                if (this.Initialized)
                {
                    this.RequiresDataBinding = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets the prefix for CSS class names for individual items.
        /// </summary>
        [Category("Appearance")]
        public string ItemCssClassPrefix
        {
            get
            {
                string val = ViewState[this.ID + "ItemCssClassPrefix"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "ItemCssClassPrefix"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix for CSS class names for add new item button.
        /// </summary>
        [Category("Appearance")]
        public string ButtonAddCssClass
        {
            get
            {
                string val = ViewState[this.ID + "ButtonAddCssClass"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "ButtonAddCssClass"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the prefix for CSS class names for delete item button.
        /// </summary>
        [Category("Appearance")]
        public string ButtonDeleteCssClass
        {
            get
            {
                string val = ViewState[this.ID + "ButtonDeleteCssClass"] as string;

                if (val != null)
                {
                    return val;
                }

                return String.Empty;
            }
            set
            {
                ViewState[this.ID + "ButtonDeleteCssClass"] = value;
            }
        }

        /// <summary>
        ///     Gets or sets the empty data text.
        /// </summary>
        /// <value> The empty data text. </value>
        [Category("Appearance")]
        public string EmptyDataText { get; set; }
        #endregion

        #region Serialization Support
        private bool ShouldSerializeItemCssClassPrefix()
        {
            return !String.IsNullOrEmpty(this.ItemCssClassPrefix);
        }

        private bool ShouldSerializeDataTitleFormatString()
        {
            return !String.IsNullOrEmpty(this.DataTitleFormatString);
        }

        private bool ShouldSerializeDataTextFormatString()
        {
            return !String.IsNullOrEmpty(this.DataTextFormatString);
        }

        private bool ShouldSerializeDataValueField()
        {
            return !String.IsNullOrEmpty(this.DataValueField);
        }

        private bool ShouldSerializeDataTitleField()
        {
            return !String.IsNullOrEmpty(this.DataTitleField);
        }
        #endregion

        #region Override Methods
        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            if (dataBinding && !this.DesignMode)
                CreateItemsFromData(dataSource);

            int index = 0;

            // Put button Add new item
            HtmlAnchor aAdd = new HtmlAnchor();
            if (!String.IsNullOrEmpty(this.ButtonAddCssClass))
            {
                aAdd.Attributes["class"] = this.ButtonAddCssClass;
            }
            aAdd.HRef = this.Page.ClientScript.GetPostBackClientHyperlink(this, "AddItem$-1");
            this.Controls.Add(aAdd);

            // Put items
            foreach (DLTagCloudItem item in Items)
            {
                Label span = new Label();
                span.ToolTip = item.Title;

                if (EnabledItemClick)
                {
                    HtmlAnchor a = new HtmlAnchor();
                    a.HRef = this.Page.ClientScript.GetPostBackClientHyperlink(this, string.Format("ItemClick${0}", index));
                    a.InnerText = item.Text;
                    a.Title = item.Title;
                    span.Controls.Add(a);
                }
                else
                {
                    Literal lit = new Literal { Text = item.Text };
                    span.Controls.Add(lit);
                }

                if (EnabledItemDelete)
                {
                    HtmlAnchor a = new HtmlAnchor();
                    if (!String.IsNullOrEmpty(this.ButtonDeleteCssClass))
                    {
                        a.Attributes["class"] = this.ButtonDeleteCssClass;
                    }
                    a.HRef = this.Page.ClientScript.GetPostBackClientHyperlink(this, string.Format("ItemDelete${0}", index));
                    span.Controls.Add(a);
                }

                if (!String.IsNullOrEmpty(ItemCssClassPrefix))
                {
                    span.Attributes["class"] = this.ItemCssClassPrefix;
                }

                this.Controls.Add(span);
                this.Controls.Add(new LiteralControl("&nbsp;"));
                index++;
            }

            if (this.DesignMode && Items.Count == 0)
            {
                this.Controls.Add(new Literal { Text = EmptyDataText });
            }

            return Items.Count;
        }
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }
        #endregion

        #region Private Methods
        private void CreateItemsFromData(System.Collections.IEnumerable dataSource)
        {
            _items = new Collection<DLTagCloudItem>();
            foreach (object data in dataSource)
            {
                DLTagCloudItem item = new DLTagCloudItem();

                if (!String.IsNullOrEmpty(this.DataValueField))
                {
                    item.Value = DataBinder.GetPropertyValue(data, this.DataValueField).ToString();
                }

                if (!String.IsNullOrEmpty(this.DataTextField))
                {
                    item.Text = DataBinder.Eval(data, this.DataTextField, this.DataTextFormatString);
                }

                if (!String.IsNullOrEmpty(this.DataTitleField))
                {
                    item.Title = DataBinder.Eval(data, this.DataTitleField, this.DataTitleFormatString);
                }

                this.Items.Add(item);
            }
        }
        #endregion

        #region Events
        public event EventHandler<DLCloudItemEventArgs> ItemClick;
        protected void OnItemClick(DLCloudItemEventArgs e)
        {
            if (ItemClick != null)
                ItemClick(this, e);
        }

        public event EventHandler<DLCloudItemEventArgs> ItemDelete;
        protected void OnItemDelete(DLCloudItemEventArgs e)
        {
            if (ItemDelete != null)
                ItemDelete(this, e);
        }

        public event EventHandler<EventArgs> AddItem;
        protected void OnAddItem(EventArgs e)
        {
             if (AddItem != null)
                AddItem(this, e);
        }
        #endregion

        #region IPostBackEventHandler Members

        public void RaisePostBackEvent(string eventArgument)
        {
            var args = eventArgument.Split('$');

            if (args.Length == 2)
            {
                var command = args[0];
                var argument = args[1];

                int selectedIndex = 0;
                if (Int32.TryParse(argument, out selectedIndex))
                {
                    this.RequiresDataBinding = true;
                    this.EnsureDataBound();

                    if (command == "AddItem")
                    {
                        OnAddItem(EventArgs.Empty);
                    }
                    else if (command == "ItemDelete")
                    {
                        if (selectedIndex >= 0 && selectedIndex < this.Items.Count)
                        {
                            OnItemDelete(new DLCloudItemEventArgs(this.Items[selectedIndex]));
                        }
                    }
                    else if (command == "ItemClick")
                    {
                        if (selectedIndex >= 0 && selectedIndex < this.Items.Count)
                        {
                            OnItemClick(new DLCloudItemEventArgs(this.Items[selectedIndex]));
                        }
                    }
                }
            }
        }

        #endregion
    }
}
