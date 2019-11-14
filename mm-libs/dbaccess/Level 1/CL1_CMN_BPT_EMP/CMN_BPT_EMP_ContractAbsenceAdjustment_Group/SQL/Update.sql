UPDATE 
	cmn_bpt_emp_contractabsenceadjustment_groups
SET 
	AbsenceAdjustment_Comment=@AbsenceAdjustment_Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_ContractAbsenceAdjustment_GroupID = @CMN_BPT_EMP_ContractAbsenceAdjustment_GroupID