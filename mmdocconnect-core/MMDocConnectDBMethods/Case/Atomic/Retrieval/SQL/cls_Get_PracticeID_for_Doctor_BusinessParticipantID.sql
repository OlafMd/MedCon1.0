
    Select
      cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As practice_id,
      cmn_bpt_businessparticipants.DisplayName As practice_name
    From
      cmn_bpt_ctm_organizationalunit_staff Inner Join
      cmn_bpt_ctm_organizationalunits
        On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
        cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
      cmn_bpt_ctm_customers
        On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And
        cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_customers.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0
    Where
      cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID = @BusinessParticipantID And
      cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
      cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0
	