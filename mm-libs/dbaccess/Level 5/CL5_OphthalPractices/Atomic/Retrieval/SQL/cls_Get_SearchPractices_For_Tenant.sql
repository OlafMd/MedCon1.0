
Select
  hec_medicalpractises.HEC_MedicalPractiseID,
  hec_medicalpractises.Contact_EmergencyPhoneNumber,
  cmn_bpt_businessparticipants.DisplayName As PracticeName,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As Practice_CMN_BPT_BusinessParticipantID,
  cmn_com_companyinfo.CMN_COM_CompanyInfoID,
  cmn_com_companyinfo.Contact_UCD_RefID,
  cmn_universalcontactdetails.CMN_UniversalContactDetailID As Contact_CMN_UniversalContactDetailID,
  cmn_universalcontactdetails.Contact_Email,
  cmn_universalcontactdetails.Contact_Website_URL,
  cmn_universalcontactdetails1.CMN_UniversalContactDetailID As Shipping_CMN_UniversalContactDetailID,
  cmn_com_companyinfo_addresses.CMN_COM_CompanyInfo_AddressID,
  hec_medicalpractises.ContactPerson_RefID,
  cmn_bpt_businessparticipants1.DisplayName As ContactPersonName,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails1.Street_Name As Street_Name1,
  cmn_universalcontactdetails1.Street_Number As Street_Number1,
  cmn_universalcontactdetails1.ZIP As ZIP1,
  cmn_universalcontactdetails1.Town As Town1,
  cmn_universalcontactdetails.Region_Name,
  cmn_universalcontactdetails1.Region_Name As Region_Name1
From
  cmn_bpt_businessparticipants Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID Inner Join
  cmn_com_companyinfo_addresses
    On cmn_com_companyinfo_addresses.CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_universalcontactdetails cmn_universalcontactdetails1
    On cmn_com_companyinfo_addresses.Address_UCD_RefID =
    cmn_universalcontactdetails1.CMN_UniversalContactDetailID Inner Join
  hec_medicalpractises On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    hec_medicalpractises.Ext_CompanyInfo_RefID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID =
    hec_medicalpractises.ContactPerson_RefID
Where
  cmn_bpt_businessparticipants.IsCompany = 1 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_universalcontactdetails.IsDeleted = 0 And
  cmn_universalcontactdetails1.IsDeleted = 0 And
  cmn_com_companyinfo_addresses.IsShipping = 1 And
  cmn_com_companyinfo_addresses.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_bpt_businessparticipants1.IsDeleted = 0
	