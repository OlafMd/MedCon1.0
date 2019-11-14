
    Select
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID As pharmacy_bpt_id,
      cmn_universalcontactdetails.First_Name As pharmacy_name,
      hec_pharmacies.HEC_PharmacyID As pharmacy_id
    From
      cmn_bpt_businessparticipants Inner Join
      cmn_com_companyinfo
        On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.Tenant_RefID =
        @TenantID And cmn_com_companyinfo.IsDeleted = 0 Inner Join
      hec_pharmacies
        On cmn_com_companyinfo.CMN_COM_CompanyInfoID = hec_pharmacies.Ext_CompanyInfo_RefID And hec_pharmacies.Tenant_RefID = @TenantID And
        hec_pharmacies.IsDeleted = 0 Inner Join
      cmn_universalcontactdetails
        On cmn_com_companyinfo.Contact_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID And cmn_universalcontactdetails.Tenant_RefID = @TenantID
        And cmn_universalcontactdetails.IsDeleted = 0
    Where
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID = @PharmacyBptIDs And
      cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
      cmn_bpt_businessparticipants.IsDeleted = 0
    Group By
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
    Order By
      Null
	