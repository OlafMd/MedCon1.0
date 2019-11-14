
	Select
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName
	From
	  hec_patients Inner Join
	  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
	    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
	    cmn_bpt_businessparticipants.IsCompany = 0 And
	    cmn_bpt_businessparticipants.IsNaturalPerson = 1 Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
	    And cmn_per_personinfo.Tenant_RefID = @TenantID
	Where
	  hec_patients.IsDeleted = 0 And
	  hec_patients.Tenant_RefID = @TenantID And
	  hec_patients.HEC_PatientID = @PatientID
  