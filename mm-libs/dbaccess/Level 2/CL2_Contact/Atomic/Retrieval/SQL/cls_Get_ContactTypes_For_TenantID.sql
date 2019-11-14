
	Select
	  cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID,
	  cmn_per_communicationcontact_types.Type
	From
	  cmn_per_communicationcontact_types
	Where
	  cmn_per_communicationcontact_types.IsDeleted = 0 And
	  cmn_per_communicationcontact_types.Tenant_RefID = @TenantID
  