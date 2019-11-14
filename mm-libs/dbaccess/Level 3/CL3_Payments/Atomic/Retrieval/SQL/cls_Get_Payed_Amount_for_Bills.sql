
	SELECT
		bil_billheaders.BIL_BillHeaderID AS BillHeaderID,
		SUM(bil_billheader_assignedpayments.AssignedValue) AS TotalPayedValue,
		bil_billheaders.TotalValue_IncludingTax
	FROM
		bil_billheaders
	LEFT OUTER JOIN bil_billheader_assignedpayments
		ON bil_billheader_assignedpayments.BIL_BillHeader_RefID = bil_billheaders.BIL_BillHeaderID
		AND bil_billheader_assignedpayments.IsDeleted = 0
		AND bil_billheader_assignedpayments.Tenant_RefID = @TenantID
	WHERE
		bil_billheaders.BIL_BillHeaderID = @BillHeaderID_List
		AND bil_billheaders.IsDeleted = 0
		AND bil_billheaders.Tenant_RefID = @TenantID
	GROUP BY 1
  