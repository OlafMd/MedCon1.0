INSERT INTO 
	cmn_bpt_emp_employmentrelationship_templates_2_workingcontract
	(
		AssignmentID,
		CMN_BPT_EMP_EmploymentRelationship_Template_RefID,
		CMN_BPT_EMP_WorkingContract_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@CMN_BPT_EMP_EmploymentRelationship_Template_RefID,
		@CMN_BPT_EMP_WorkingContract_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)