using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DLDanuTaskCommons.Constants
{
    public enum DanuTaskModules
    {
        Administrator,
        Manager,
        Developer
    }

    public enum DeveloperModulePages
    {
        TaskDetails,
        Assigned,
        Recommended,
        Free,
        Mentions,
        Completed,
        ReportedToday,
        Notes
    }

    public enum AdminModulePages
    {
        ActiveUsers,
        Projects,
        WorkingTimeTypes,
        DeveloperTaskPriorities,
        ProjectMemberTypes,
        PriceGrades,
        RequestedProjects,
        Reports,
        ReportedToday,
        EstimationMethods,
        Notes
    }

    public enum ManagerModulePages
    {
        Projects,
        Features,
        DeveloperTasks,
        Boards,
        ReportedToday,
        Reports,
        Issues,
        Notes

    }
    
    public enum PopUpTypes
    {

        StopTask,
        FinishTask,
        ReportWorkTime,
        AsignTaskByDeveloper,
        RecommendDeveloperTask,
        AddPriceGrade,
        AddEditDeveloperTaskPriority,
        AddEditProject,
        FinishRunningTime,
        AddNewWorkingTaskType,
        AdminUsers,
        DeleteDeveloperTaskPriority,
        DeleteWorkingTaskType,
        AddUsertoProject,
        AddEditMemberType,
        AssignChargingLevelToMemberType,
        ReplaceMemberType,

        ReplacePriceGrades,
        ReplaceSinglePriceGrade,

        UsersSelectable,
        AssignUsersToProject,

        OpenNewIssue,
        AddEditDeveloperPoint,
        ManagerAddPackage,
        AddFeature,
        EditFeature,
        DeleteFeature,
        AddBudgetLimitforProject,
        DeleteProject,

        ResolveMissingInfo
     }

    public enum PopupRecommendationType
    {
        Note,
        DeveloperTask,
        Project,
        NoteDetails
    }
}
