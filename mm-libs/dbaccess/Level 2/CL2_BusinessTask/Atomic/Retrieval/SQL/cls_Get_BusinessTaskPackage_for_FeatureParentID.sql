
	Select
	  tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID,
	  tms_pro_businesstaskpackages.Parent_RefID,
	  tms_pro_businesstaskpackages.Project_RefID,
	  tms_pro_businesstaskpackages.Label As BTP_Name
	From
	  tms_pro_businesstaskpackages
	Where
	  tms_pro_businesstaskpackages.IsDeleted = 0 And
	  tms_pro_businesstaskpackages.Tenant_RefID = @TenantID And
	  tms_pro_businesstaskpackages.TMS_PRO_BusinessTaskPackageID =
	  @Feature_Parent_RefID
  