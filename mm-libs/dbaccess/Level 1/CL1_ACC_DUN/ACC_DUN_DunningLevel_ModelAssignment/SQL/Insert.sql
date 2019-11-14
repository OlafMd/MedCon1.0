INSERT INTO 
	acc_dun_dunninglevel_modelassignments
	(
		ACC_DUN_DunningLevel_ModelAssignmentID,
		Dunning_Model_RefID,
		Dunning_Level_RefID,
		WaitPeriodToNextDunningLevel_In_Days,
		OrderSequence,
		Configuration,
		DunningFee,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@ACC_DUN_DunningLevel_ModelAssignmentID,
		@Dunning_Model_RefID,
		@Dunning_Level_RefID,
		@WaitPeriodToNextDunningLevel_In_Days,
		@OrderSequence,
		@Configuration,
		@DunningFee,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)