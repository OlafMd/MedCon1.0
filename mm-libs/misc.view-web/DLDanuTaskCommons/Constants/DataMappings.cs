using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLDanuTaskCommons.Constants
{
    public class DataMappings
    {
        public static String RightPackages(Guid TenantID){ return "RightPackages_"+TenantID;  }
        public static String Rights(Guid TenantID) { return "Rights_" + TenantID; }
        public static String ProjectStatus(Guid TenantID) { return "ProjectStatus_" + TenantID; }
        public static String BusinessTaskStatus(Guid TenantID) { return "BusinessTaskStatusMappings_" + TenantID; }
        public static String FeatureStatus(Guid TenantID) { return "FeatureStatus_" + TenantID; }
        public static String DeveloperTaskHistoryStatus(Guid TenantID) { return "DeveloperTaskHistoryStatus_" + TenantID; }
    }

    public enum EDataMappings
    {
        RightPackages,
        Rights,
        ProjectStatus,
        BusinessTaskStatus,
        FeatureStatus,
        DeveloperTaskHistoryStatus
    }

    public enum PopUp_SelectUser_ParentAction
    {
        Recommend_DeveloperTask,
        Share_Note,
        Add_ProjectMembers
    }
}
