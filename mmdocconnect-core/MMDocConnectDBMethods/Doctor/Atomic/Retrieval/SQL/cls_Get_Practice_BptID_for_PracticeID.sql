
      Select
        cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID as practice_bpt_id
      From
        cmn_bpt_ctm_organizationalunits Inner Join
        cmn_bpt_ctm_customers
          On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
          cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
          cmn_bpt_ctm_customers.IsDeleted = 0
      Where
        cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID = @PracticeID And
        cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_organizationalunits.IsDeleted = 0
  