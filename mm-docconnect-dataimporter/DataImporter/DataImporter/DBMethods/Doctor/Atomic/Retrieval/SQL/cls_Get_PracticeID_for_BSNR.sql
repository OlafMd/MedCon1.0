
    Select
      cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID as practice_id
    From
      cmn_com_companyinfo Inner Join
      cmn_bpt_businessparticipants On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
        cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0 
         Inner Join
      cmn_bpt_ctm_customers
        On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
        cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID And
        cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And 
        cmn_bpt_ctm_customers.IsDeleted = 0
        Inner Join
      cmn_bpt_ctm_organizationalunits
        On cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID =
        cmn_bpt_ctm_organizationalunits.Customer_RefID And
        cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_organizationalunits.IsDeleted = 0 
    Where
      cmn_com_companyinfo.CompanyInfo_EstablishmentNumber = @BSNR And
      cmn_com_companyinfo.IsDeleted = 0 And
      cmn_com_companyinfo.Tenant_RefID = @TenantID   
  