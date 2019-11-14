
Select
  cmn_bpt_ctm_organizationalunits.OrganizationalUnit_Name_DictID,
  cmn_bpt_ctm_organizationalunits.Default_PhoneNumber,
  cmn_per_personinfo.FirstName As ContactFirstname,
  cmn_per_personinfo.LastName As ContactLastname,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.Town,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_bpt_businessparticipants.IsDeleted,
  cmn_bpt_ctm_organizationalunits.Modification_Timestamp,
  hec_medicalpractises.Modification_Timestamp As Modification_Timestamp1,
  cmn_bpt_businessparticipants.Modification_Timestamp As
  Modification_Timestamp2,
  cmn_per_personinfo.Modification_Timestamp As Modification_Timestamp3,
  cmn_com_companyinfo.Modification_Timestamp As Modification_Timestamp4,
  cmn_universalcontactdetails.Modification_Timestamp As Modification_Timestamp5,
  hec_medicalpractises.Tenant_RefID,
  hec_medicalpractises.Creation_Timestamp,
  hec_medicalpractises.IsHospital
From
  hec_medicalpractises Left Join
  cmn_bpt_ctm_organizationalunits
    On
    cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID Left Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    hec_medicalpractises.ContactPerson_RefID Left Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
  Left Join
  cmn_com_companyinfo On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    hec_medicalpractises.Ext_CompanyInfo_RefID Left Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID
Where
  hec_medicalpractises.Tenant_RefID = @Tenant
  