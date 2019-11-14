using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLDanuTaskCommons.Constants
{
    public class PopUpRelativePath
    {
        public static String PopUp_StopTask { get { return "~/Popups/PopUp_StopTask.ascx"; } }
        public static String PopUp_FinishTask { get { return "~/Popups/PopUp_FinishTask.ascx"; } }
        public static String PopUp_ReportWorkTime { get { return "~/Popups/PopUp_ReportWorkTime.ascx"; } }
        public static String PopUp_AsignTaskByDeveloper { get { return "~/Popups/PopUp_AssignTaskByDeveloper.ascx"; } }
        public static String PopUp_AddPriceGrade { get { return "~/Popups/PopUp_AddPriceGrade.ascx"; } }
        public static String PopUp_AddEditDeveloperTaskPriority { get { return "~/Popups/PopUp_AddEditDeveloperTaskPriority.ascx"; } }
        public static String PopUp_DeleteDeveloperTaskPriority { get { return "~/Popups/PopUp_DeleteDeveloperTaskPriority.ascx"; } }
        public static String PopUp_AddEditProject { get { return "~/Popups/PopUp_AdminProjects.ascx"; } }
        public static String PopUp_OpenNewIssue { get { return "~/Popups/PopUp_OpenNewIssue.ascx"; } }
        public static String PopUp_AddEditDeveloperPoint { get { return "~/Popups/PopUp_AddEditDeveloperPoint.ascx"; } }

        public static String PopUp_AddWorkTaskType { get { return "~/Popups/PopUp_AddWorkTaskType.ascx"; } }
        public static String PopUp_Note { get { return "~/Popups/PopUp_Note.ascx"; } }//popupNote je prebacen na stranicu treba ga obrisati
        public static String PopUp_UsersSelectable { get { return "~/Popups/PopUp_SelectUsers.ascx"; } }
        public static String PopUp_AdminUsers { get { return "~/Popups/PopUp_AdminUsers.ascx"; } }
        public static String Popup_Add_User_to_Project { get { return "~/Popups/PopUp_Add_User_to_Project.ascx"; } }
        public static String PoUp_AddEdit_MemberType { get { return "~/Popups/PoUp_AddEditMemberType.ascx"; } }
        public static String PoUp_AssignChargingLevel_to_MemberType { get { return "~/Popups/PopUp_AssignChargingLevel_to_MemberType.ascx"; } }
        public static String PoUp_Replace_MemberType { get { return "~/Popups/PopUp_ReplaceMemberType.ascx"; } }
        public static String Popup_Delete_WorkingTaskType { get { return "~/Popups/PopUp_DeleteWorkingTaskType.ascx"; } }
        public static String PopUp_ReplacePriceGrades { get { return "~/Popups/PopUp_ReplacePriceGrades.ascx"; } }
        public static String PopUp_ManagerAddPackage { get { return "~/Popups/PopUp_Manager_AddPackage.ascx"; } }
        public static String PopUp_ManagerAddFeature { get { return "~/Popups/PopUp_ManagerAddFeature.ascx"; } }
        public static String PopUp_PopUpAddBudgetLimitforProject { get { return "~/Popups/PopUp_AddBudgetLimit_for_Project.ascx"; } }

        public static String PopUp_ResolveMissingInfo { get { return ""; } }
            
    }

    public class PageNavigation
    {
        public static string Admin_ActiveUsers { get { return "~/Module_Administrator/Angular_Admin_Users.aspx"; } }
        public static string Admin_Projects { get { return "~/Module_Administrator/Admin_Projects.aspx"; } }
        public static string Admin_WorkingTimeTypes { get { return "~/Module_Administrator/Administrator_WorkingTaskTypes.aspx"; } }
        public static string Admin_DeveloperTaskPriorities { get { return "~/Module_Administrator/Administrator_DeveloperTaskPriorities.aspx"; } }
        public static string Admin_ProjectMemberTypes { get { return "~/Module_Administrator/Administrator_ProjectMemberTypes.aspx"; } }
        public static string Admin_PriceGrades { get { return "~/Module_Administrator/Administrator_PriceGrades.aspx"; } }
        public static string Admin_RequestedProjects { get { return ""; } }
        public static string Admin_Reports { get { return "~/Module_Administrator/Admin_Reports.aspx"; } }

        public static string Admin_EstimationMethods { get { return "~/Module_Administrator/Admin_Estimation_Methods.aspx"; } }
        public static string Administrator_Notes { get { return "~/Module_Administrator/Administrator_Notes.aspx"; } }
        public static string Manager_Notes { get { return "~/Module_Manager/Manager_Notes.aspx"; } }

        public static string Developer_TaskDetails(String additionalParameters)     
        {
            if(additionalParameters != null)
                return String.Format("{0}?{1}","~/Module_Developer/Developer_TaskDetails.aspx",additionalParameters);
            return "~/Module_Developer/Developer_TaskDetails.aspx";

        } 
        public static string Developer_NotCompleted    { get { return "~/Module_Developer/Developer_NotCompletedTasks.aspx"; } }
        public static string Developer_Completed       { get { return "~/Module_Developer/Developer_NotCompletedTasks.aspx"; } }
        public static string Developer_ReportedToday   { get { return "~/Module_Developer/Developer_UserWorkTime.aspx"; } }
        public static string Developer_Notes           { get { return "~/Module_Developer/Developer_Notes.aspx"; } }


        public static string Manager_Projects { get { return "~/Module_Manager/Manager_Projects.aspx"; } }
        public static string Manager_Boards { get { return "~/Module_Manager/Manager_Boards.aspx"; } }
        public static string Manager_Features { get { return "~/Module_Manager/Manager_Features.aspx"; } }
        public static string Manager_DeveloperTasks { get { return "~/Module_Manager/Manager_DeveloperTasks.aspx"; } }
        public static string Manager_ReportedToday { get { return "~/Module_Manager/Manager_ReportedToday.aspx"; } }
        public static string Manager_Reports { get { return "~/Module_Manager/Manager_Reports.aspx"; } }
        


    }

    public class DeveloperMenuItemsPath
    {
        public static string Dev_ActiveTask { get { return "~/Module_Developer/Developer_MenuItems/MI_ActiveTask.ascx"; } }
        public static string Dev_AssignedTasks { get { return "~/Module_Developer/Developer_MenuItems/MI_AssignedTasks.ascx"; } }
        public static string Dev_Blank { get { return "~/Module_Developer/Developer_MenuItems/MI_Blank.ascx"; } }
        public static string Dev_CompletedTasks { get { return "~/Module_Developer/Developer_MenuItems/MI_CompletedTasks.ascx"; } }
        public static string Dev_FreeTasks { get { return "~/Module_Developer/Developer_MenuItems/MI_FreeTasks.ascx"; } }
        public static string Dev_Mentions { get { return "~/Module_Developer/Developer_MenuItems/MI_Mentions.ascx"; } }
        public static string Dev_Notes { get { return "~/Module_Developer/Developer_MenuItems/MI_Notes.ascx"; } }
        public static string Dev_RecommendedTasks { get { return "~/Module_Developer/Developer_MenuItems/MI_RecommendedTasks.ascx"; } }
        public static string Dev_ReportedToday { get { return "~/Module_Developer/Developer_MenuItems/MI_ReportedToday.ascx"; } }
    }
     
}

