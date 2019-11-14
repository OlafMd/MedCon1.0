
	Select
		  tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID,
		  tms_pro_businesstaskpackages.Parent_RefID,
		  tms_pro_businesstaskpackages.Project_RefID,
		  tms_pro_businesstaskpackages.Label As BTP_Name
		From
		  tms_pro_businesstaskpackages Inner Join
		  tms_pro_businesstasks On tms_pro_businesstasks.BusinessTasksPackage_RefID =
		    tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID Inner Join
		  tms_pro_businesstask_2_feature
		    On tms_pro_businesstask_2_feature.BusinessTask_RefID =
		    tms_pro_businesstasks.TMS_PRO_BusinessTaskID Inner Join
		  tms_pro_feature On tms_pro_feature.TMS_PRO_FeatureID =
		    tms_pro_businesstask_2_feature.Feature_RefID
		Where
		  tms_pro_businesstaskpackages.IsDeleted = 0 And
		  tms_pro_feature.TMS_PRO_FeatureID = @FeatureID And
		  tms_pro_feature.IsDeleted = 0 And
		  tms_pro_feature.IsArchived = 0 And
		  tms_pro_feature.Tenant_RefID = @TenantID

  