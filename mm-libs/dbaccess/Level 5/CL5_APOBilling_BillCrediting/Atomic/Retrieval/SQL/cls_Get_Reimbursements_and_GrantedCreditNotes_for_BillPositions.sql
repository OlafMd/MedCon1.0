
	SELECT
	  bil_billposition_reimbursements.BIL_BillPosition_RefID,
	  bil_billposition_reimbursements.BIL_BillPosition_ReimbursementID,
	  acc_crn_grantedcreditnotes.ACC_CRN_GrantedCreditNoteID
	FROM bil_billposition_reimbursements
	INNER JOIN acc_crn_grantedcreditnotes
	  ON acc_crn_grantedcreditnotes.ACC_CRN_GrantedCreditNoteID = bil_billposition_reimbursements.ACC_CRN_GrantedCreditNote_RefID
	  AND acc_crn_grantedcreditnotes.Tenant_RefID = bil_billposition_reimbursements.Tenant_RefID
	  AND acc_crn_grantedcreditnotes.IsDeleted = bil_billposition_reimbursements.IsDeleted
	WHERE
	  bil_billposition_reimbursements.BIL_BillPosition_RefID = @BillPositionIDs
	  AND bil_billposition_reimbursements.Tenant_RefID = @TenantID
	  AND bil_billposition_reimbursements.IsDeleted = 0;
  