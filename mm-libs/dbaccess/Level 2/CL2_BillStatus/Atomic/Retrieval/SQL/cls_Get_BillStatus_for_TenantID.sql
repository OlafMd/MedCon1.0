
	Select
	  bil_billstatuses.BIL_BillStatusID,
	  bil_billstatuses.BillStatus_Name_DictID,
	  bil_billstatuses.GlobalPropertyMatchingID,
	  bil_billstatuses.Creation_Timestamp
	From
	  bil_billstatuses
	Where
	  bil_billstatuses.IsDeleted = 0 And
	  bil_billstatuses.Tenant_RefID = @TenantID
  