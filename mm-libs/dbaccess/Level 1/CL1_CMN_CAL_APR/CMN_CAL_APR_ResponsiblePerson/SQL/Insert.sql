INSERT INTO 
	cmn_cal_apr_responsiblepersons
	(
		CMN_CAL_APR_ResponsiblePersonID,
		NumberOfResponsiblePersonsRequiredToApprove,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_CAL_APR_ResponsiblePersonID,
		@NumberOfResponsiblePersonsRequiredToApprove,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)