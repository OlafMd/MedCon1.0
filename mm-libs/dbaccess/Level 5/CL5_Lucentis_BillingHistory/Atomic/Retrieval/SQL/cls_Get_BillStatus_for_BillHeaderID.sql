
	Select
	  bil_billheader_2_billstatus.BIL_BillHeader_RefID,
	  bil_billheader_2_billstatus.BIL_BillStatus_RefID
	From
	  bil_billheader_2_billstatus
	Where
	  bil_billheader_2_billstatus.BIL_BillHeader_RefID = @BillHeaderID And
	  bil_billheader_2_billstatus.Tenant_RefID = @TenantID And
	  bil_billheader_2_billstatus.IsDeleted = 0
  