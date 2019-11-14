
	Select
	  cmn_bpt_businessparticipants.DisplayName As PracticeName,
	  cmn_universalcontactdetails.Street_Name,
	  cmn_universalcontactdetails.Street_Number,
	  cmn_universalcontactdetails.ZIP,
	  cmn_universalcontactdetails.Town,
	  cmn_universalcontactdetails.Contact_Email As PracticeEmail,
	  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
	  cmn_universalcontactdetails.Region_Name,
	  cmn_universalcontactdetails.Contact_Website_URL,
	  hec_medicalpractises.Contact_EmergencyPhoneNumber,
	  cmn_per_personinfo.FirstName As ContactPersonFirstName,
	  cmn_per_personinfo.LastName As ContactPersonLastName,
	  cmn_per_personinfo.PrimaryEmail As ContactPersonEmail,
	  cmn_per_communicationcontacts.Content As ContactPersonPhone
	From
	  hec_medicalpractises Inner Join
	  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
	  cmn_bpt_businessparticipants
	    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
	  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
	    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
	    cmn_universalcontactdetails.IsDeleted = 0 Left Join
	  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
	    On hec_medicalpractises.ContactPerson_RefID =
	    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants1.IsDeleted = 0 And
	    cmn_bpt_businessparticipants1.Tenant_RefID =
	    @TenantID And
	    cmn_bpt_businessparticipants1.IsNaturalPerson = 1 And
	    cmn_bpt_businessparticipants1.IsCompany = 0 Left Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
	    = @TenantID And cmn_per_personinfo.IsDeleted = 0
	  Left Join
	  cmn_per_communicationcontacts
	    On cmn_per_communicationcontacts.PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And
	    cmn_per_communicationcontacts.Tenant_RefID =
	    @TenantID And
	    cmn_per_communicationcontacts.IsDeleted = 0
	Where
	  hec_medicalpractises.IsDeleted = 0 And
	  cmn_com_companyinfo.IsDeleted = 0 And
	  cmn_bpt_businessparticipants.IsDeleted = 0 And
	  hec_medicalpractises.Tenant_RefID = @TenantID And
	  cmn_bpt_businessparticipants.IsCompany = 1 And
	  cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
	  cmn_bpt_businessparticipants.IsTenant = 0
	  Order BY 
	    cmn_bpt_businessparticipants.DisplayName ASC
  