
  Select
    cmn_bpt_suppliers.CMN_BPT_SupplierID,
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
    cmn_universalcontactdetails.CompanyName_Line1
  From
    cmn_bpt_suppliers Inner Join
    cmn_bpt_businessparticipants
      On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
    cmn_com_companyinfo
      On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
      cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
    cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID =
      cmn_universalcontactdetails.CMN_UniversalContactDetailID
  Where
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_bpt_suppliers.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_com_companyinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
  