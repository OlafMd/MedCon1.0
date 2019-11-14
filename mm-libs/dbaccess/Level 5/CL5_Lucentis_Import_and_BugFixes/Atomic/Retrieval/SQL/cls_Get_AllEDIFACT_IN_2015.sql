
		Select
  bil_billheaderextension_edifact.BIL_BillHeaderExtension_EDIFACTID
From
  bil_billheaderextension_edifact
Where
  bil_billheaderextension_edifact.IsDeleted = 0 And
  bil_billheaderextension_edifact.Tenant_RefID = @TenantID And
  Year(bil_billheaderextension_edifact.Creation_Timestamp) = 2015
  