
    Select
      tms_pro_developertasks.IdentificationNumber,
      tms_pro_developertasks.DOC_Structure_Header_RefID,
      tms_pro_developertasks.CreatedBy_ProjectMember_RefID,
      tms_pro_developertasks.Priority_RefID,
      tms_pro_developertasks.Project_RefID,
      tms_pro_developertasks.DeveloperTask_Type_RefID,
      tms_pro_developertasks.GrabbedByMember_RefID,
      tms_pro_developertasks.Completion_Deadline,
      tms_pro_developertasks.Completion_Timestamp,
      tms_pro_developertasks.Name,
      tms_pro_developertasks.Description,
      tms_pro_developertasks.Developer_Points,
      tms_pro_developertasks.IsComplete,
      tms_pro_developertasks.IsIncompleteInformation,
      tms_pro_developertasks.IsArchived,
      tms_pro_developertasks.IsBeingPrepared,
      tms_pro_developertasks.Creation_Timestamp,
      tms_pro_developertasks.IsDeleted,
      tms_pro_developertasks.Tenant_RefID,
      tms_pro_developertasks.DeveloperTime_RequiredEstimation_min,
      tms_pro_developertasks.DeveloperTime_CurrentInvestment_min,
      tms_pro_developertasks.PercentageComplete
    From
      tms_pro_developertasks
    Where
      tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @TaskID
  