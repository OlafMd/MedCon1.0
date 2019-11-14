

  Select
  tms_pro_tags.TMS_PRO_TagID,
  tms_pro_tags.TagValue
From
  tms_pro_tags Inner Join
  tms_pro_project_2_tag On tms_pro_project_2_tag.Tag_RefID =
    tms_pro_tags.TMS_PRO_TagID Inner Join
  tms_pro_projects On tms_pro_project_2_tag.Project_RefID =
    tms_pro_projects.TMS_PRO_ProjectID
 Where 
 tms_pro_projects.TMS_PRO_ProjectID =@Project_RefID And
tms_pro_projects.IsDeleted = 0 And
tms_pro_projects.IsArchived = 0 And
tms_pro_tags.IsDeleted=0 And
tms_pro_project_2_tag.IsDeleted = 0 And
tms_pro_projects.Tenant_RefID = @TenantID


  
 