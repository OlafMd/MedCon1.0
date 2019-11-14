
Select
  tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID,
  tms_pro_businesstask_2_feature.Feature_RefID,
  tms_pro_feature.TMS_PRO_FeatureID,
  tms_pro_feature.IsDeleted,
  tms_pro_feature.IsArchived,
  tms_pro_feature.Name_DictID,
  tms_pro_feature.Parent_RefID,
  tms_pro_businesstask_2_feature.IsDeleted As IsDeleted1,
  tms_pro_feature.Project_RefID,
  tms_pro_businesstasks.TMS_PRO_BusinessTaskID,
  tms_pro_businesstask_2_feature.BusinessTask_RefID,
  tms_pro_businesstasks.BusinessTasksPackage_RefID,
  tms_pro_businesstasks.IsDeleted As IsDeleted2,
  tms_pro_businesstaskpackages.IsDeleted As IsDeleted3,
  tms_pro_businesstasks.IsArchived As IsArchived1
From
  tms_pro_businesstaskpackages Inner Join
  tms_pro_businesstasks On tms_pro_businesstasks.BusinessTasksPackage_RefID =
    tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID Inner Join
  tms_pro_businesstask_2_feature On tms_pro_businesstasks.TMS_PRO_BusinessTaskID
    = tms_pro_businesstask_2_feature.BusinessTask_RefID Inner Join
  tms_pro_feature On tms_pro_businesstask_2_feature.Feature_RefID =
    tms_pro_feature.TMS_PRO_FeatureID
 Where
   tms_pro_feature.IsDeleted =0 and
  tms_pro_feature.IsArchived= 0 and 
   tms_pro_businesstaskpackages.Tenant_RefID = @TenantID 
  
 
  