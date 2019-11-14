using System;
using System.Collections.Generic;

namespace DLWebFormsTemplates.Controls.Tree.Support
{
    public class SelectionChangeEventArgs : EventArgs
    {
        private List<Guid> _selectedIDs { get; set; }

        public List<Guid> SelectedIDs 
        {
            get { return _selectedIDs; }
            set { _selectedIDs = value; }
        }
        public Guid SelectedID 
        { 
            get 
            {
                if (_selectedIDs == null || _selectedIDs.Count <= 0)
                {
                    return Guid.Empty;
                }
                else
                {
                    return _selectedIDs[0];
                }
            }
            set
            {
                if (_selectedIDs == null)
                {
                    _selectedIDs = new List<Guid>();
                }
                _selectedIDs.Clear();
                _selectedIDs.Add(value);
            }
        }
    }
}
