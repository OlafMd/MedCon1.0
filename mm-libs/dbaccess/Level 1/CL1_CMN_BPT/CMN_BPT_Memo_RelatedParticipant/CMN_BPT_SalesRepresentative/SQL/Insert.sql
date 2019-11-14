INSERT INTO 
	cmn_bpt_salesrepresentatives
	(
		CMN_BPT_SalesRepresentativeID,
		IfEmployee_Employee_RefID,
		IsEmployee,
		Ext_BusinessParticipant_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_SalesRepresentativeID,
		@IfEmployee_Employee_RefID,
		@IsEmployee,
		@Ext_BusinessParticipant_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)