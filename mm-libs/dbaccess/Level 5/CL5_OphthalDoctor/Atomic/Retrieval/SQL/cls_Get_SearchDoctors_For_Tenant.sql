
Select
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  hec_doctors.HEC_DoctorID,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedParticipant_FunctionName,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID As Practice_AssociatedBusinessParticipant_RefID,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID,
  cmn_per_communicationcontacts.Content As ContactContent,
  hec_medicalpractises.HEC_MedicalPractiseID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Inner Join
  hec_doctors On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_communicationcontacts
    On cmn_per_communicationcontacts.PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID Inner Join
  hec_medicalpractises On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID Inner Join
  usr_accounts On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    usr_accounts.BusinessParticipant_RefID Inner Join
  usr_device_accountcodes On usr_device_accountcodes.Account_RefID =
    usr_accounts.USR_AccountID Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  hec_publichealthcare_physitianassociations
    On hec_medicalpractises.AssociatedWith_PhysitianAssociation_RefID =
    hec_publichealthcare_physitianassociations.HEC_PublicHealthcare_PhysitianAssociationID
Where
  hec_doctors.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsCompany = 1 And
  cmn_per_communicationcontacts.IsDeleted = 0 And
  usr_accounts.IsDeleted = 0 And
  usr_device_accountcodes.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  hec_publichealthcare_physitianassociations.IsDeleted = 0
  