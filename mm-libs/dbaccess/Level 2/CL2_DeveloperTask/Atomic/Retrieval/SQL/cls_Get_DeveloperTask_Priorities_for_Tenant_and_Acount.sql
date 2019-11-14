
Select
  tms_pro_developertask_priorities.TMS_PRO_DeveloperTask_PriorityID,
  tms_pro_developertask_priorities.Label_DictID,
  tms_pro_developertask_priorities.Description_DictID,
  tms_pro_developertask_priorities.IconLocationURL,
  tms_pro_developertask_priorities.Groups,
  tms_pro_developertask_priorities.PriorityLevel,
  tms_pro_developertask_priorities.IsPersistent,
  tms_pro_developertask_priorities.Creation_Timestamp,
  tms_pro_developertask_priorities.Tenant_RefID,
  tms_pro_developertask_priorities.IsDeleted,
  tms_pro_developertask_priorities.Priority_Colour,
  tms_pro_developertask_priorities.GlobalPropertyMatchingID
From
  tms_pro_developertask_priorities
Where
  tms_pro_developertask_priorities.Tenant_RefID = @TenantID And
  tms_pro_developertask_priorities.IsDeleted = 0
  