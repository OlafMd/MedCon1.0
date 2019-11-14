using System;
using System.ComponentModel;

namespace DLCore_DBCommons.DanuTask
{
    public enum EDeveloperTaskPriority
    {
        [Description("dtask-priority.low")]
        Low,
        [Description("dtask-priority.normal")]
        Normal,
        [Description("dtask-priority.high")]
        High,
        [Description("dtask-priority.urgent")]
        Urgent
    }

    public enum EFeatureType
    {
        [Description("feature-type.feature")]
        Feature,
        [Description("feature-type.maintenance")]
        Maintenance,
        [Description("feature-type.bug")]
        Bug
    }

    public enum ERightsPackage
    {
        [Description("rights-package.project-member")]
        ProjectMember,
        [Description("rights-package.task-developer")]
        TaskDeveloper,
        [Description("rights-package.technical-manager")]
        TechnicalManager,
        [Description("rights-package.project-manager")]
        ProjectManager
    }

    public enum EBusinessTypeTask
    {
        [Description("business-task-type.feature-development")]
        FeatureDevelopment,
        [Description("business-task-type.project-maintenance")]
        ProjectMaintenance,
        [Description("business-task-type.project-fix")]
        ProjectFix
    }

    public enum ERight
    {
        [Description("right.right-to-see-project-strucuture")]
        RightToSeeProjectStrucuture
    }

    public enum EProjectStatus
    {
        [Description("project-status.in-preparation")]
        InPreparation,
        [Description("project-status.ready")]
        Ready,
        [Description("project-status.running")]
        Running,
        [Description("project-status.paused")]
        Paused,
        [Description("project-status.completed")]
        Completed,
        [Description("project-status.canceled")]
        Canceled
    }

    public enum EDeveloperTaskHistory
    {
        [Description("developer-task-status.assigned")]
        Assigned,
        [Description("developer-task-status.deassigned")]
        Deassigned,
        [Description("developer-task-status.developers-update")]
        DevelopersUpdate,
        [Description("developer-task-status.activated")]
        Activated,
        [Description("developer-task-status.deactivated")]
        Deactivated,
        [Description("developer-task-status.started")]
        Started,
        [Description("developer-task-status.stopped")]
        Stopped,
        [Description("developer-task-status.missing-info")]
        MissingInfo,
        [Description("developer-task-status.finished")]
        Finished,
        [Description("developer-task-status.returned-to-developer")]
        ReturnedToDeveloper,
        [Description("developer-task-status.assigned-by-manager")]
        AssignedByManager,
        [Description("developer-task-status.deassigned-by-manager")]
        DeAssignedByManager,
        [Description("developer-task-status.missing-info-resolved")]
        MissingInfoResolved,
        [Description("developer-task-status.taskinfo-changed")]
        TaskInfoChanged,
        [Description("developer-task-status.manager-time-invested")]
        ManagerTimeInvested,
        [Description("developer-task-status.document-updated")]
        DocumentUpdated,
        [Description("developer-task-status.commented")]
        Commented
    }

    public enum EFeatureStatus
    {
        [Description("feature-status.ready")]
        Ready,
        [Description("feature-status.started")]
        Started,
        [Description("feature-status.paused")]
        Paused,
        [Description("feature-status.completed")]
        Completed,
        [Description("feature-status.canceled")]
        Canceled,
        [Description("feature-status.in-preparation")]
        InPreparation
    }

    public enum EBusinessTaskStatus
    {
        [Description("business-task-status.ready")]
        Ready,
        [Description("business-task-status.started")]
        Started,
        [Description("business-task-status.paused")]
        Paused,
        [Description("business-task-status.completed")]
        Completed,
        [Description("business-task-status.canceled")]
        Canceled,
        [Description("business-task-status.in-preparation")]
        InPreparation
    }

    public enum EQuickTaskType
    {
        [Description("quick-task-type.phone-call")]
        PhoneCall,
        [Description("quick-task-type.discussion")]
        QTT_Discussion,
        [Description("quick-task-type.meeting")]
        Meeting,
        [Description("quick-task-type.email")]
        Email,
        [Description("quick-task-type.other")]
        Other
    }

    public enum EAcountFunctionLevel
    {
        [Description("acount-function-level-right.Admin")]
        Admin,
        [Description("acount-function-level-right.Biz")]
        Biz,
        [Description("acount-function-level-right.Tec")]
        Tec,
        [Description("acount-function-level-right.Dev")]
        Dev
    }

    public enum ECurrencies
    {
        [Description("currency-names.Euro")]
        Euro,
        [Description("currency-names.Dinar")]
        Dinar,
        [Description("currency-names.Dollar")]
        Dollar
    }

    public enum EDeveloperTaskContext 
    { 
        NotAssigned, 
        Assigned, 
        Active, 
        IncompleteInformation, 
        Completed, 
        Archived, 
        Deleted 
    }

    public enum RunningTimes
    {
        [Description("danutask.runningTime-history")]
        Item_Key
    }

    public static class ResourceFilePath
    {
        public static String DeveloperTaskPriorities    = "DLCore_DBCommons.DanuTask.StaticListDataResource.developer-task-priorities.xml";
        public static String FeatureTypes               = "DLCore_DBCommons.DanuTask.StaticListDataResource.feature-types.xml";
        public static String RightsPackage              = "DLCore_DBCommons.DanuTask.StaticListDataResource.rights-packages.xml";
        public static String BusinessTypeTask           = "DLCore_DBCommons.DanuTask.StaticListDataResource.business-task-types.xml";
        public static String Right                      = "DLCore_DBCommons.DanuTask.StaticListDataResource.rights.xml";
        public static String ProjectStatus              = "DLCore_DBCommons.DanuTask.StaticListDataResource.project-statuses.xml";
        public static String DeveloperTaskHistory       = "DLCore_DBCommons.DanuTask.StaticListDataResource.developer-task-statuses.xml";
        public static String FeatureStatus              = "DLCore_DBCommons.DanuTask.StaticListDataResource.feature-statuses.xml";
        public static String QuickTaskType              = "DLCore_DBCommons.DanuTask.StaticListDataResource.quick-task-type.xml";
        public static String AcountFunctionLevel        = "DLCore_DBCommons.DanuTask.StaticListDataResource.acount-function-level-right.xml";
        public static String ComunicationContactType    = "DLCore_DBCommons.DanuTask.StaticListDataResource.comunication-contact-type.xml";
        public static String BusinessTaskStatus         = "DLCore_DBCommons.DanuTask.StaticListDataResource.business-task-statuses.xml";
        public static String CurrencyNames              = "DLCore_DBCommons.DanuTask.StaticListDataResource.currency-names.xml";
       
    }

    public class STLD_DeveloperTask_Context
    {
        public static readonly Guid Completed = Guid.Parse("4CC6BE2E-4CC0-4542-AE99-985440F56804");
        public static readonly Guid IncompleteInfo = Guid.Parse("38140FE4-6952-42C3-A47B-776809E8AFE1");
        public static readonly Guid Assigned = Guid.Parse("3DF28237-373E-49B7-8A3B-2B2D8A52A1D1");
        public static readonly Guid Unassigned = Guid.Parse("3EE767DC-82F3-409A-8778-53CCA2CED2F9");
        public static readonly Guid Prepared = Guid.Parse("5E6A7F4B-2605-475B-AA8B-96CE13BE11AE");
        public static readonly Guid InPreparation = Guid.Parse("37726E2F-652D-4771-995A-013F9BE1BD55");
        public static readonly Guid Archived = Guid.Parse("B9BC6C35-5E5C-46C1-B5D4-ECB94BDDBB86");
    }

    public class STLD_FunctionLevelRights
    {
        public static readonly Guid DanuTask_ApplicationRole_Administrator = Guid.Parse("fef57a6a-810a-4fcf-82fb-135d1af89e30");
        public static readonly Guid DanuTask_ModuleAccess_Business = Guid.Parse("ed8f72ac-837a-413b-b8cd-05751ff6c3aa");
        public static readonly Guid DanuTask_ModuleAccess_Technical = Guid.Parse("0cbc3d01-5b49-467f-9374-ef4720e90783");
        public static readonly Guid DanuTask_ModuleAccess_Developer = Guid.Parse("f392f5fc-1cf2-47be-8021-05bc6a30ea63");
    }

    public class STLD_CommunicationContact_Type
    {
        public static readonly Guid Telephone = Guid.Parse("01cd5c1b-a1bd-471c-bad5-64fedbfa5e3c");
        public static readonly Guid SkypeName = Guid.Parse("11ed2d2c-3edd-40b6-9d37-c34dc89437a6");
        public static readonly Guid Email = Guid.Parse("45eb89dc-cb98-43c1-8954-b51a38d31b23");
    }

    public class STDL_ApplicationIdentification
    {
        public static readonly Guid ApplicationID = Guid.Parse("f7b64a58-dfc9-4af8-a9e3-b8b430cd2e91");
    }

}
