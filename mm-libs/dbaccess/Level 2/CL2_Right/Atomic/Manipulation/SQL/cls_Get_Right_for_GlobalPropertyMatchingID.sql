
	Select
	  tms_pro_acc_rights.TMS_PRO_ACC_RightID,
	  tms_pro_acc_rights.Right_Name_DictID
	From
	  tms_pro_acc_rights
	Where
	  tms_pro_acc_rights.IsDeleted = 0 And
	  tms_pro_acc_rights.Tenant_RefID = @TenantID And
	  tms_pro_acc_rights.GlobalPropertyMatchingID = @GlobalPropertyMatchingID
  