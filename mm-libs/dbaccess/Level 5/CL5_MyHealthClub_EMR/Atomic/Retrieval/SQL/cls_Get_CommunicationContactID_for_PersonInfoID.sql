
	Select
	  cmn_per_communicationcontacts.CMN_PER_CommunicationContactID
	From
	  cmn_per_communicationcontacts Inner Join
	  cmn_per_communicationcontact_types
	    On cmn_per_communicationcontacts.Contact_Type =
	    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID
	Where
	  cmn_per_communicationcontacts.PersonInfo_RefID = @PersonInfoID And
	  cmn_per_communicationcontacts.Tenant_RefID = @Tenant And
	  cmn_per_communicationcontact_types.Type = 'comunication-contact-type.mobile'
  