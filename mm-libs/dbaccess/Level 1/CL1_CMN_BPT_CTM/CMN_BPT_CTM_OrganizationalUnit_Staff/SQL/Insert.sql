INSERT INTO 
	cmn_bpt_ctm_organizationalunit_staff
	(
		CMN_BPT_CTM_OrganizationalUnit_StaffID,
		OrganizationalUnit_RefID,
		BusinessParticipant_RefID,
		IsPrimaryORGUnitForBusinessParticipant,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_BPT_CTM_OrganizationalUnit_StaffID,
		@OrganizationalUnit_RefID,
		@BusinessParticipant_RefID,
		@IsPrimaryORGUnitForBusinessParticipant,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)