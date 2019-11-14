
    Select
      cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID as doctor_bpt_id
    From
	    cmn_bpt_ctm_organizationalunits Inner Join
  	    cmn_bpt_ctm_organizationalunit_staff
        On cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID = cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID And
        cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
        cmn_bpt_businessparticipants.IsDeleted = 0
    Where
      cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID = @PracticeID And
      cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
      cmn_bpt_ctm_organizationalunits.IsDeleted = 0
	