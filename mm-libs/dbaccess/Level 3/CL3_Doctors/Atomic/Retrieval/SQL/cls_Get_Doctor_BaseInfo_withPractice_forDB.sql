

Select
  hec_doctors.HEC_DoctorID,
  hec_doctors.DoctorIDNumber As LANR,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_communicationcontacts.Content,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_per_personinfo.PrimaryEmail As LoginEmail,
  hec_doctors.Account_RefID,
  cmn_per_communicationcontacts.Contact_Type,
  cmn_bpt_businessparticipants1.DisplayName As PracticeName,
  cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID,
  hec_medicalpractises.HEC_MedicalPractiseID As PracticeID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As
  Doctor_CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedParticipant_FunctionName,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.Creation_Timestamp,
  hec_doctors.Tenant_RefID,
  cmn_per_personinfo.CMN_PER_PersonInfoID
From
  hec_doctors Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Inner Join
  cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_communicationcontacts.PersonInfo_RefID Left Join
  cmn_bpt_businessparticipant_associatedbusinessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_associatedbusinessparticipants.BusinessParticipant_RefID And cmn_bpt_businessparticipant_associatedbusinessparticipants.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On
    cmn_bpt_businessparticipant_associatedbusinessparticipants.AssociatedBusinessParticipant_RefID = cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipants1.IsDeleted = 0 Left Join
  hec_medicalpractises
    On cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID =
    hec_medicalpractises.Ext_CompanyInfo_RefID And
    hec_medicalpractises.IsDeleted = 0
Where
  hec_doctors.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsCompany = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0
Group By
  hec_doctors.HEC_DoctorID, cmn_per_personinfo.Title,
  cmn_per_personinfo.PrimaryEmail, hec_doctors.Account_RefID,
  cmn_per_communicationcontacts.Contact_Type,
  cmn_bpt_businessparticipants1.DisplayName,
  cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipant_associatedbusinessparticipants.Creation_Timestamp,
  hec_doctors.Tenant_RefID, cmn_bpt_businessparticipants1.Tenant_RefID,
  cmn_per_personinfo.CMN_PER_PersonInfoID
Order By
  cmn_bpt_businessparticipant_associatedbusinessparticipants.Creation_Timestamp
  