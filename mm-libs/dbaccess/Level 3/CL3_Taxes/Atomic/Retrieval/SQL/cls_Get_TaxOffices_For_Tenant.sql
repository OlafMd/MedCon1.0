Select
  acc_tax_taxoffices.ACC_TAX_TaxOfficeID,
  cmn_bpt_businessparticipants.DisplayName,
  cmn_com_companyinfo.VATIdentificationNumber,
  cmn_universalcontactdetails.Country_639_1_ISOCode
From
  acc_tax_taxoffices Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    acc_tax_taxoffices.CMN_BPT_BusinessParticipant_RefID Inner Join
  cmn_com_companyinfo On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID Inner Join
  cmn_universalcontactdetails
    On cmn_universalcontactdetails.CMN_UniversalContactDetailID =
    cmn_com_companyinfo.Contact_UCD_RefID
Where
  acc_tax_taxoffices.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  acc_tax_taxoffices.Tenant_RefID = @TenantID And
  cmn_universalcontactdetails.IsDeleted = 0