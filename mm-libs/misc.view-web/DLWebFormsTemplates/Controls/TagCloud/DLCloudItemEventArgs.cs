/*
 * Author: Milovan Regodic 
 * Email: milovan.regodic@danulabs.com
 * Date: November 2013
 */
using System;

namespace DLWebFormsTemplates.Controls
{
    public class DLCloudItemEventArgs : EventArgs
    {
        internal DLCloudItemEventArgs(DLTagCloudItem item)
		{
			this._item = item;
		}

        private DLTagCloudItem _item;

		/// <summary>
		/// Gets the item which is clicked.
		/// </summary>
        public DLTagCloudItem Item
		{
			get { return _item; }
		}
    }
}
