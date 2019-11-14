
	Select
  cmn_universalcontactdetails.Street_Name As PharmacyStreetName,
  cmn_universalcontactdetails.Street_Number As PharmacyStreetNumber,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Contact_Email As PharmacyEmail,
  cmn_universalcontactdetails.Street_Name_Line2 As PharmacyStreet2,
  ContactPerson.ContactTypePhoneID,
  ContactPerson.ContactTypePhoneNumber,
  ContactPerson.ContactTypeFirstName,
  ContactPerson.ContactTypeLastName,
  ContactPerson.CMN_PER_PersonInfoID,
  ContactPerson.ContactTypeEmail,
  hec_pharmacies.HEC_PharmacyID,
  cmn_bpt_businessparticipants.DisplayName
From
  (Select
    cmn_per_communicationcontacts.Contact_Type As ContactTypePhoneID,
    cmn_per_communicationcontacts.Content As ContactTypePhoneNumber,
    cmn_per_personinfo.FirstName As ContactTypeFirstName,
    cmn_per_personinfo.LastName As ContactTypeLastName,
    cmn_per_personinfo.PrimaryEmail As ContactTypeEmail,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
    cmn_per_personinfo.CMN_PER_PersonInfoID,
    cmn_per_personinfo.Tenant_RefID
  From
    cmn_per_personinfo Inner Join
    cmn_per_communicationcontacts On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_per_communicationcontacts.PersonInfo_RefID Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
      cmn_per_personinfo.CMN_PER_PersonInfoID
  Where
    cmn_per_personinfo.Tenant_RefID = @TenantID And
    cmn_per_communicationcontacts.IsDeleted = 0 And
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0) ContactPerson Right Join
  hec_pharmacies On hec_pharmacies.ContactPerson_BusinessParticipant_RefID =
    ContactPerson.CMN_BPT_BusinessParticipantID Inner Join
  cmn_com_companyinfo On hec_pharmacies.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0
Where
  hec_pharmacies.HEC_PharmacyID = @PharmacyID And
  hec_pharmacies.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsCompany = 1 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
  cmn_bpt_businessparticipants.IsTenant = 0 And
  hec_pharmacies.Tenant_RefID = @TenantID
  