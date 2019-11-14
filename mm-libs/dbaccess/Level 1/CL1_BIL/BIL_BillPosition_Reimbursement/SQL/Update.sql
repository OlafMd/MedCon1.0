UPDATE 
	bil_billposition_reimbursements
SET 
	BIL_BillPosition_RefID=@BIL_BillPosition_RefID,
	ACC_CRN_GrantedCreditNote_RefID=@ACC_CRN_GrantedCreditNote_RefID,
	ReimbursedValue=@ReimbursedValue,
	ReimbursedQuantity=@ReimbursedQuantity,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	BIL_BillPosition_ReimbursementID = @BIL_BillPosition_ReimbursementID