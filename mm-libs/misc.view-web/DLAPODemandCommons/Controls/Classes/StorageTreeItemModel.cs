using System;
using System.Collections.Generic;
using DLWebFormsTemplates.Controls.Tree.Support;

namespace DLAPODemandCommons.Controls.Classes
{
    [Serializable]
    public class StorageTreeItemModel : AbstractTreeItemModel
    {
        #region PROPERTIES
        public StorageTypeEnum StorageItemType { get; set; }
        public bool IsHidden { get; set; }
        public bool IsCheckBoxEnabled { get; set; }
        public bool IsAutoPostbackEnabled { get; set; }
        public bool IsSelectable { get; set; }

        public StorageDatabaseModel StorageItemDatabaseModel { get; set; }
        #endregion

        #region CONSTRUCTORS
        public StorageTreeItemModel() 
        { 
            this.Children = new List<AbstractTreeItemModel>(); 
        }

        public StorageTreeItemModel(StorageTreeItemModel model)
        {
            this.ID = model.ID;
            this.Name = model.Name;
            this.StorageItemType = model.StorageItemType;
            this.ParentID = model.ParentID;
            this.IsHidden = model.IsHidden;
            this.IsCheckBoxEnabled = model.IsCheckBoxEnabled;
            this.IsAutoPostbackEnabled = model.IsAutoPostbackEnabled;
            this.IsSelectable = model.IsSelectable;
            this.Children = model.Children == null ? new List<AbstractTreeItemModel>() : model.Children;
            if (model.StorageItemDatabaseModel != null)
            {
                this.StorageItemDatabaseModel = new StorageDatabaseModel()
                {
                    WarehouseGroupId = model.StorageItemDatabaseModel.WarehouseGroupId,
                    WarehouseGroupName = model.StorageItemDatabaseModel.WarehouseGroupName,
                    WarehouseId = model.StorageItemDatabaseModel.WarehouseId,
                    WarehouseName = model.StorageItemDatabaseModel.WarehouseName,
                    AreaId = model.StorageItemDatabaseModel.AreaId,
                    AreaName = model.StorageItemDatabaseModel.AreaName,
                    RackId = model.StorageItemDatabaseModel.RackId,
                    RackName = model.StorageItemDatabaseModel.RackName,
                    ShelfId = model.StorageItemDatabaseModel.ShelfId,
                    ShelfName = model.StorageItemDatabaseModel.ShelfName
                };
            }
        }
        #endregion

        #region GETTERS & SETTERS
        public Guid GetStorageItemIdByStorageType(StorageTypeEnum type)
        {
            Guid resultValue;
            switch (type)
            {
                case StorageTypeEnum.WAREHOUSE_GROUP:
                    resultValue = StorageItemDatabaseModel.WarehouseGroupId;
                    break;
                case StorageTypeEnum.WAREHOUSE:
                    resultValue = StorageItemDatabaseModel.WarehouseId;
                    break;
                case StorageTypeEnum.AREA:
                    resultValue = StorageItemDatabaseModel.AreaId;
                    break;
                case StorageTypeEnum.RACK:
                    resultValue = StorageItemDatabaseModel.RackId;
                    break;
                case StorageTypeEnum.SHELF:
                    resultValue = StorageItemDatabaseModel.ShelfId;
                    break;
                default:
                    resultValue = Guid.Empty;
                    break;
            }
            return resultValue;
        }

        public string GetStorageItemNameByType(StorageTypeEnum type)
        {
            string resultValue;
            switch (type)
            {
                case StorageTypeEnum.WAREHOUSE_GROUP:
                    resultValue = StorageItemDatabaseModel.WarehouseGroupName;
                    break;
                case StorageTypeEnum.WAREHOUSE:
                    resultValue = StorageItemDatabaseModel.WarehouseName;
                    break;
                case StorageTypeEnum.AREA:
                    resultValue = StorageItemDatabaseModel.AreaName;
                    break;
                case StorageTypeEnum.RACK:
                    resultValue = StorageItemDatabaseModel.RackName;
                    break;
                case StorageTypeEnum.SHELF:
                    resultValue = StorageItemDatabaseModel.ShelfName;
                    break;
                default:
                    resultValue = string.Empty;
                    break;
            } 
            return resultValue;
        }

        public bool GetStorageItemIsHiddenByType(StorageTypeEnum type)
        {
            bool resultValue;
            switch (type)
            {
                case StorageTypeEnum.WAREHOUSE_GROUP:
                    resultValue = true;
                    break;
                case StorageTypeEnum.WAREHOUSE:
                    resultValue = StorageItemDatabaseModel.IsWarehouseHidden;
                    break;
                case StorageTypeEnum.AREA:
                    resultValue = StorageItemDatabaseModel.IsAreaHidden;
                    break;
                case StorageTypeEnum.RACK:
                    resultValue = StorageItemDatabaseModel.IsRackHidden;
                    break;
                case StorageTypeEnum.SHELF:
                    resultValue = false;
                    break;
                default:
                    resultValue = true;
                    break;
            }
            return resultValue;
        }

        public bool HasHiddenParent(Guid parentId)
        {
            if (StorageItemDatabaseModel != null)
            {
                switch (StorageItemType)
                {
                    case StorageTypeEnum.SHELF:
                        return StorageItemDatabaseModel.RackId == parentId
                            || StorageItemDatabaseModel.AreaId == parentId
                            || StorageItemDatabaseModel.WarehouseId == parentId
                            || StorageItemDatabaseModel.WarehouseGroupId == parentId;
                    case StorageTypeEnum.RACK:
                        return StorageItemDatabaseModel.AreaId == parentId
                            || StorageItemDatabaseModel.WarehouseId == parentId
                            || StorageItemDatabaseModel.WarehouseGroupId == parentId;
                    case StorageTypeEnum.AREA: 
                        return StorageItemDatabaseModel.WarehouseId == parentId
                            || StorageItemDatabaseModel.WarehouseGroupId == parentId;
                    case StorageTypeEnum.WAREHOUSE: 
                        return StorageItemDatabaseModel.WarehouseGroupId == parentId;
                    default:
                        return false;
                }
            }
            return false;
        }

        public void SetStorageDatabaseModel(StorageDatabaseModel sdb)
        {
            StorageItemDatabaseModel = sdb;
        }
        #endregion
    }

    [Serializable]
    public class StorageDatabaseModel
    {
        public Guid WarehouseGroupId { get; set; }
        public string WarehouseGroupName { get; set; }
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public bool IsWarehouseHidden { get; set; }
        public Guid AreaId { get; set; }
        public string AreaName { get; set; }
        public bool IsAreaHidden { get; set; }
        public Guid RackId { get; set; }
        public string RackName { get; set; }
        public bool IsRackHidden { get; set; }
        public Guid ShelfId { get; set; }
        public string ShelfName { get; set; }
    }
}
