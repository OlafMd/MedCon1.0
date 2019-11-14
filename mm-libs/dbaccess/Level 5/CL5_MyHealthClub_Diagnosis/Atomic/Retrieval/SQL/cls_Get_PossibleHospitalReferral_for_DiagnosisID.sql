
	Select
	  cmn_universalcontactdetails.CompanyName_Line1 As HospitalName,
	  cmn_per_personinfo.Title As ContactPersonTitle,
	  cmn_per_personinfo.FirstName As ContactPersonFirstName,
	  cmn_per_personinfo.LastName As ContactPersonLastName,
	  cmn_universalcontactdetails.Street_Name,
	  cmn_universalcontactdetails.Street_Number,
	  cmn_universalcontactdetails.Town,
	  cmn_universalcontactdetails.Contact_Telephone,
	  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
	  hec_dia_frequentpotentialdiagnoses.PotentialDiagnosis_RefID,
	  hec_dia_frequentpotentialdiagnoses.HEC_DIA_FrequentPotentialDiagnosisID,
	  hec_dia_frequentpotentialdiagnoses.MedicalPractice_RefID
	From
	  hec_medicalpractises Inner Join
	  hec_dia_frequentpotentialdiagnoses
	    On hec_dia_frequentpotentialdiagnoses.MedicalPractice_RefID =
	    hec_medicalpractises.HEC_MedicalPractiseID And
	    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID =
	    @TenantID Inner Join
	  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
	    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
	  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
	    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
	    cmn_universalcontactdetails.IsDeleted = 0 And
	    cmn_universalcontactdetails.IsCompany = 1 And
	    cmn_universalcontactdetails.Tenant_RefID = @TenantID Inner Join
	  cmn_bpt_businessparticipants On hec_medicalpractises.ContactPerson_RefID =
	    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
	    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
	  hec_medicalpractice_2_practicetype
	    On hec_medicalpractises.HEC_MedicalPractiseID =
	    hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID And
	    hec_medicalpractice_2_practicetype.IsDeleted = 0 And
	    hec_medicalpractice_2_practicetype.Tenant_RefID = @TenantID Inner Join
	  hec_medicalpractice_types
	    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID =
	    hec_medicalpractice_types.HEC_MedicalPractice_TypeID And
	    hec_medicalpractice_types.IsDeleted = 0 And
	    hec_medicalpractice_types.Tenant_RefID = @TenantID
	Where
	  hec_dia_frequentpotentialdiagnoses.IsDeleted = 0 And
	  hec_dia_frequentpotentialdiagnoses.Tenant_RefID = @TenantID And
	  hec_dia_frequentpotentialdiagnoses.PotentialDiagnosis_RefID = @DiagnosisID
  