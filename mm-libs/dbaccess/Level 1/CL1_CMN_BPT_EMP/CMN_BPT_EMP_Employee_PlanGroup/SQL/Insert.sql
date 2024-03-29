INSERT INTO 
	cmn_bpt_emp_employee_plangroups
	(
		CMN_BPT_EMP_Employee_PlanGroupID,
		GlobalPropertyMatchingID,
		PlanGroup_Name_DictID,
		PlanGroup_Description_DictID,
		BoundTo_Office_RefID,
		BoundTo_WorkArea_RefID,
		BoundTo_WorkPlace_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_BPT_EMP_Employee_PlanGroupID,
		@GlobalPropertyMatchingID,
		@PlanGroup_Name,
		@PlanGroup_Description,
		@BoundTo_Office_RefID,
		@BoundTo_WorkArea_RefID,
		@BoundTo_WorkPlace_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)