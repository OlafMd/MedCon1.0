
	Select
	  hec_doctors.HEC_DoctorID
	From
	  hec_doctors Inner Join
	  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
	    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
	  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
	    cmn_per_communicationcontacts.PersonInfo_RefID And
	    cmn_per_communicationcontacts.IsDeleted = 0 And
	    cmn_per_communicationcontacts.Tenant_RefID = @TenantID Inner Join
	  cmn_per_communicationcontact_types
	    On cmn_per_communicationcontacts.Contact_Type =
	    cmn_per_communicationcontact_types.CMN_PER_CommunicationContact_TypeID And
	  cmn_per_communicationcontact_types.IsDeleted = 0 And
	  cmn_per_communicationcontact_types.Tenant_RefID = @TenantID
	Where
	  hec_doctors.IsDeleted = 0 And
	  cmn_per_communicationcontact_types.Type = 'comunication-contact-type.email'
	  And
	  hec_doctors.Tenant_RefID = @TenantID
  