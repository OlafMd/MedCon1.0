
Select
  cmn_universalcontactdetails.First_Name As PharmacyName,
  hec_pharmacies.HEC_PharmacyID As PharmacyID
From
  cmn_bpt_businessparticipants Inner Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Inner Join
  cmn_universalcontactdetails
    On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_universalcontactdetails.Tenant_RefID = @TenantID Inner Join
  hec_pharmacies
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    hec_pharmacies.Ext_CompanyInfo_RefID And hec_pharmacies.Tenant_RefID =
    @TenantID And hec_pharmacies.IsDeleted = 0
Where
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = @BPID And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
	