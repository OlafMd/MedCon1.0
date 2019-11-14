UPDATE 
	cmn_bpt_emp_employee_taxinformation
SET 
	Employee_RefID=@Employee_RefID,
	TaxNumber=@TaxNumber,
	TaxClass=@TaxClass,
	TaxExemptionAmount=@TaxExemptionAmount,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_Employee_TaxInformationID = @CMN_BPT_EMP_Employee_TaxInformationID