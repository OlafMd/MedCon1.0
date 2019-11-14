UPDATE 
	acc_dun_dunninglevel_modelassignments
SET 
	Dunning_Model_RefID=@Dunning_Model_RefID,
	Dunning_Level_RefID=@Dunning_Level_RefID,
	WaitPeriodToNextDunningLevel_In_Days=@WaitPeriodToNextDunningLevel_In_Days,
	OrderSequence=@OrderSequence,
	Configuration=@Configuration,
	DunningFee=@DunningFee,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	ACC_DUN_DunningLevel_ModelAssignmentID = @ACC_DUN_DunningLevel_ModelAssignmentID