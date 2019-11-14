
Select
  cmn_universalcontactdetails.CompanyName_Line1 As name,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As id
From
  hec_pharmacies Inner Join
  cmn_com_companyinfo
    On hec_pharmacies.Ext_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.Tenant_RefID = @TenantID And
    cmn_com_companyinfo.IsDeleted = 0 Inner Join
  cmn_universalcontactdetails
    On cmn_com_companyinfo.Contact_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID And cmn_universalcontactdetails.Tenant_RefID = @TenantID
    And cmn_universalcontactdetails.IsDeleted = 0 Inner Join
  cmn_bpt_businessparticipants
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID = cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0
Where
  hec_pharmacies.Tenant_RefID = @TenantID And
  hec_pharmacies.IsDeleted = 0
  