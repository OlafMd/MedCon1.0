UPDATE 
	cmn_bpt_emp_employee_plangroups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	PlanGroup_Name_DictID=@PlanGroup_Name,
	PlanGroup_Description_DictID=@PlanGroup_Description,
	BoundTo_Office_RefID=@BoundTo_Office_RefID,
	BoundTo_WorkArea_RefID=@BoundTo_WorkArea_RefID,
	BoundTo_WorkPlace_RefID=@BoundTo_WorkPlace_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_Employee_PlanGroupID = @CMN_BPT_EMP_Employee_PlanGroupID