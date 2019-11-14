
	SELECT
	  bil_billposition_reimbursements.BIL_BillPosition_ReimbursementID,
	  bil_billposition_reimbursements.ReimbursedValue,
	  bil_billposition_reimbursements.ReimbursedQuantity,
      bil_billposition_reimbursements.BIL_BillPosition_RefID,
	  acc_crn_grantedcreditnotes.ACC_CRN_GrantedCreditNoteID,
	  acc_crn_grantedcreditnotes.CreditNote_Value,
	  acc_crn_grantedcreditnotes.CreditNote_Number,
	  acc_crn_grantedcreditnotes.DateOnCreditNote,
	  acc_crn_grantedcreditnotes.CreditNote_Currency_RefID
	FROM bil_billposition_reimbursements
	INNER JOIN acc_crn_grantedcreditnotes
	  ON acc_crn_grantedcreditnotes.ACC_CRN_GrantedCreditNoteID = bil_billposition_reimbursements.ACC_CRN_GrantedCreditNote_RefID
	  AND acc_crn_grantedcreditnotes.Tenant_RefID = bil_billposition_reimbursements.Tenant_RefID
	  AND acc_crn_grantedcreditnotes.IsDeleted = bil_billposition_reimbursements.IsDeleted
	WHERE
	  bil_billposition_reimbursements.BIL_BillPosition_RefID = @BillPositionIDs
	  AND bil_billposition_reimbursements.Tenant_RefID = @TenantID
	  AND bil_billposition_reimbursements.IsDeleted = 0;
  