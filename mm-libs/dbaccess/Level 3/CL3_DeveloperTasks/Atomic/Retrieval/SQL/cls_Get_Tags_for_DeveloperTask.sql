
Select
  tms_pro_tags.TMS_PRO_TagID,
  tms_pro_tags.TagValue,
  tms_pro_developertask_2_tag.AssignmentID,
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_developertask_2_tag.DeveloperTask_RefID
From
  tms_pro_developertasks Inner Join
  tms_pro_developertask_2_tag On tms_pro_developertask_2_tag.DeveloperTask_RefID
  = tms_pro_developertasks.TMS_PRO_DeveloperTaskID Inner Join
  tms_pro_tags On tms_pro_developertask_2_tag.Tag_RefID =
  tms_pro_tags.TMS_PRO_TagID
Where
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_developertask_2_tag.IsDeleted = 0 And
  tms_pro_tags.IsDeleted = 0 And
  tms_pro_developertasks.Tenant_RefID = @TenantID And
  tms_pro_developertask_2_tag.DeveloperTask_RefID = @DTaskID
  