
    Select
      tms_pro_businesstasks.TMS_PRO_BusinessTaskID,
      tms_pro_businesstasks.IdentificationNumber,
      tms_pro_businesstasks.DOC_Structure_Header_RefID,
      tms_pro_businesstasks.BusinessTasksPackage_RefID,
      tms_pro_businesstasks.Project_RefID,
      tms_pro_businesstasks.Estimated_StartDate,
      tms_pro_businesstasks.Estimated_EndDate,
      tms_pro_businesstasks.Task_Name_DictID,
      tms_pro_businesstasks.Task_Description_DictID,
      tms_pro_businesstasks.Task_Type_RefID,
      tms_pro_businesstasks.Task_Status_RefID,
      tms_pro_businesstasks.Task_Deadline,
      tms_pro_businesstasks.Creation_Timestamp,
      tms_pro_businesstasks.IsArchived
    From
      tms_pro_businesstasks
    Where
      tms_pro_businesstasks.Project_RefID = @ProjectIDList And
      (tms_pro_businesstasks.IsArchived = 0 Or
        tms_pro_businesstasks.IsArchived = @Is_ArchivedTasks_Included) And
      tms_pro_businesstasks.IsDeleted = 0 And
      tms_pro_businesstasks.Tenant_RefID = @TenantID
    Order By
      tms_pro_businesstasks.IdentificationNumber
  