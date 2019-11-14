
    SELECT
		acc_ipl_installmentplans.ACC_IPL_InstallmentPlanID,
		acc_ipl_installments.ACC_IPL_InstallmentID,
		acc_ipl_installments.Amount,
		acc_ipl_installments.PaymentDeadline,
		acc_ipl_installments.IsFullyPaid
	FROM
		bil_billheader_2_installmentplans
	INNER JOIN acc_ipl_installmentplans 
		ON acc_ipl_installmentplans.ACC_IPL_InstallmentPlanID = bil_billheader_2_installmentplans.BIL_InstallmentPlan_RefID
		AND acc_ipl_installmentplans.IsDeleted = 0
		AND acc_ipl_installmentplans.Tenant_RefID = @TenantID
	INNER JOIN acc_ipl_installments
		ON acc_ipl_installments.InstallmentPlan_RefID = acc_ipl_installmentplans.ACC_IPL_InstallmentPlanID
		AND (@IsFullyPaid IS NULL OR acc_ipl_installments.IsFullyPaid = @IsFullyPaid)
		AND acc_ipl_installments.IsDeleted = 0
		AND acc_ipl_installments.Tenant_RefID = @TenantID
	WHERE
		bil_billheader_2_installmentplans.BIL_BillHeader_RefID = @BillHeaderID
		AND bil_billheader_2_installmentplans.IsDeleted = 0
		AND bil_billheader_2_installmentplans.Tenant_RefID = @TenantID
  