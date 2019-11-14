
	Select
	  tms_pro_acc_rightspackages.TMS_PRO_ACC_RightsPackageID AS RightsPackage_ID,
	  tms_pro_acc_rightspackages.Name_DictID,
	  tms_pro_acc_rightspackages.GlobalPropertyMatchingID AS RightsPackage_GlobalPropertyMatchingID
	From
	  tms_pro_acc_rightspackages
	Where
	  tms_pro_acc_rightspackages.IsDeleted = 0 And
	  tms_pro_acc_rightspackages.Tenant_RefID = @TenantID
  