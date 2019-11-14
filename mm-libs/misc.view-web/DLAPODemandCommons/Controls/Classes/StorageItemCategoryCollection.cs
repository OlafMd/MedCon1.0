using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DLAPODemandCommons.Controls.Classes
{
    public enum StorageTypeEnum { ROOT, WAREHOUSE_GROUP, WAREHOUSE, AREA, RACK, SHELF }

    public class StorageItemCategoryCollection : IEnumerable, IList, ICollection, ICloneable
    {
        private List<StorageItemCategory> innerList = new List<StorageItemCategory>();

        public StorageItemCategory GetCategoryByType(StorageTypeEnum categoryType)
        {
            foreach (var category in innerList)
            {
                if (category.CategoryType == categoryType)
                {
                    return category;
                }
            }
            return null;
        }

        #region INTERFACES IMPLEMENTATIONS
        #region IEnumerable IMPLEMENTATIONS
        public void Add(StorageItemCategory storageCategory)
        {
            innerList.Add(storageCategory);
        }

        public void Remove(StorageItemCategory storageCategory)
        {
            innerList.Remove(storageCategory);
        }

        public int Count
        {
            get { return innerList.Count(); }
        }

        public StorageItemCategory this[int index]
        {
            get { return (StorageItemCategory)innerList[index]; }
            set { innerList[index] = value; }
        }

        public IEnumerator GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
        #endregion

        #region IList IMPLEMENTATIONS
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region ICollection IMPLEMENTATIONS
        public int Add(object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public bool IsFixedSize
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        object IList.this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region ICloneable IMPLEMENTATIONS
        public object Clone()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class StorageItemCategory
    {
        #region PUBLIC PROPERTIES
        [NotifyParentProperty(true),
        Description("Current storage category type.")]
        public StorageTypeEnum CategoryType
        {
            get { return _storageType; }
            set { _storageType = value; }
        }
        [NotifyParentProperty(true),
        DefaultValue(true),
        Description("Items of current storage category are visible but not selectable.")]
        public bool? IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }
        [NotifyParentProperty(true),
        DefaultValue(null),
        Description("Hides all items of current storage category.")]
        public bool? IsHidden
        {
            get { return _isHidden; }
            set { _isHidden = value; }
        }
        [NotifyParentProperty(true),
        DefaultValue(false),
        Description("Enables valid selection of item in current storage category.")]
        public bool IsSelectable
        {
            get { return _isSelectable; }
            set { _isSelectable = value; }
        }
        [NotifyParentProperty(true),
        DefaultValue(false),
        Description("Enables multiple selection of items in current storage category.")]
        public bool IsMultipleSelectionEnabled
        {
            get { return _isMultipleSelectionEnabled; }
            set { _isMultipleSelectionEnabled = value; }
        }
        [NotifyParentProperty(true)]
        public string RootElementName
        {
            get { return _rootElementName; }
            set { _rootElementName = value; }
        }
        #endregion

        #region PRIVATE PROPERTIES
        private StorageTypeEnum _storageType;
        private bool? _isEnabled;
        private bool? _isHidden;
        private bool _isSelectable;
        private bool _isMultipleSelectionEnabled;
        private string _rootElementName;
        #endregion

        #region CONSTRUCTORS
        public StorageItemCategory() : this(StorageTypeEnum.SHELF, null, null, true, false, "") { }

        public StorageItemCategory(StorageTypeEnum storageType, bool? isEnabled, bool? isHidden, bool isSelectable, bool isMultipleSelectionEnabled, string rootName)
        {
            _storageType = storageType;
            _isEnabled = isEnabled;
            _isHidden = isHidden;
            _isSelectable = isSelectable;
            _isMultipleSelectionEnabled = isMultipleSelectionEnabled;
            _rootElementName = rootName;
        }
        #endregion
    }
}