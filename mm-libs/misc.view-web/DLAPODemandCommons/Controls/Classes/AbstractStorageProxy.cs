using System;
using System.Collections.Generic;
using BOp.Infrastructure.Authentication;
using Danulabs.Utils;

namespace DLAPODemandCommons.Controls.Classes
{
    public abstract class AbstractStorageProxy
    {
        public Guid WarehouseId;
        public Guid InvertoryJobId;

        public String SessionTicket
        {
            get
            {
                SessionTokenInformation sessionTokenInfo = SessionGlobal.Instance.SessionTokenInfo;
                return sessionTokenInfo.Session.SessionToken;
            }
        }

        public abstract List<StorageTreeItemModel> GetStorageStructureItems();
    }
}
