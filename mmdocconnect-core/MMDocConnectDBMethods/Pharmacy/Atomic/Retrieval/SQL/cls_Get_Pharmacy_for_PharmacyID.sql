
Select
  hec_pharmacies.HEC_PharmacyID As PharmacyID,
  cmn_universalcontactdetails.First_Name As PharmacyName,
  cmn_universalcontactdetails.Contact_Email,
  cmn_universalcontactdetails.Contact_Telephone,
  cmn_universalcontactdetails.Contact_Fax,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_bpt_businessparticipant_groups.GlobalPropertyMatchingID As PharmacyType,
  LTrim(RTrim(Concat(cmn_per_personinfo.FirstName, ' ',
  cmn_per_personinfo.LastName))) As ContactPersonName,
  cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID As CompanyBPID
From
  hec_pharmacies Inner Join
  cmn_bpt_businessparticipants
    On hec_pharmacies.ContactPerson_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  cmn_com_companyinfo
    On hec_pharmacies.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
  cmn_universalcontactdetails
    On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_universalcontactdetails.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    cmn_bpt_businessparticipants1.IfCompany_CMN_COM_CompanyInfo_RefID And
    cmn_bpt_businessparticipants1.IsDeleted = 0 And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipant_2_businessparticipantgroup
    On cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID =
    cmn_bpt_businessparticipant_2_businessparticipantgroup.CMN_BPT_BusinessParticipant_RefID And cmn_bpt_businessparticipant_2_businessparticipantgroup.IsDeleted = 0 And cmn_bpt_businessparticipant_2_businessparticipantgroup.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipant_groups
    On
    cmn_bpt_businessparticipant_2_businessparticipantgroup.CMN_BPT_BusinessParticipant_Group_RefID = cmn_bpt_businessparticipant_groups.CMN_BPT_BusinessParticipant_GroupID And cmn_bpt_businessparticipant_groups.IsDeleted = 0 And cmn_bpt_businessparticipant_groups.Tenant_RefID = @TenantID
Where
  hec_pharmacies.IsDeleted = 0 And
  hec_pharmacies.Tenant_RefID = @TenantID And
  hec_pharmacies.HEC_PharmacyID = @PharmacyID
  
  