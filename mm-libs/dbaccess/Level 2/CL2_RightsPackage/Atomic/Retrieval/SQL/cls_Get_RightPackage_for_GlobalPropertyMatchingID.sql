
	Select
	  tms_pro_acc_rightspackages.TMS_PRO_ACC_RightsPackageID,
	  tms_pro_acc_rightspackages.Name_DictID,
	  tms_pro_acc_rightspackages.Description_DictID,
	  tms_pro_acc_rightspackages.HierarchyLevel,
	  tms_pro_acc_rightspackages.Creation_Timestamp
	From
	  tms_pro_acc_rightspackages
	Where
	  tms_pro_acc_rightspackages.IsDeleted = 0 And
	  tms_pro_acc_rightspackages.Tenant_RefID = @TenantID And
	  tms_pro_acc_rightspackages.GlobalPropertyMatchingID =
	  @GlobalPropertyMatchingID
  