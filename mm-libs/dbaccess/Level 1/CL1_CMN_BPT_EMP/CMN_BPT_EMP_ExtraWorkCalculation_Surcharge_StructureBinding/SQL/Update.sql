UPDATE 
	cmn_bpt_emp_extraworkcalculation_surcharge_structurebindings
SET 
	BoundTo_Office_RefID=@BoundTo_Office_RefID,
	BoundTo_WorkArea_RefID=@BoundTo_WorkArea_RefID,
	BoundTo_Workplace_RefID=@BoundTo_Workplace_RefID,
	ExtraWorkCalculation_Surcharge_RefID=@ExtraWorkCalculation_Surcharge_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBindingID = @CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_StructureBindingID