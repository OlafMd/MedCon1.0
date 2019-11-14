INSERT INTO 
	cmn_bpt_emp_contractabsenceadjustment_groups
	(
		CMN_BPT_EMP_ContractAbsenceAdjustment_GroupID,
		AbsenceAdjustment_Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_EMP_ContractAbsenceAdjustment_GroupID,
		@AbsenceAdjustment_Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)