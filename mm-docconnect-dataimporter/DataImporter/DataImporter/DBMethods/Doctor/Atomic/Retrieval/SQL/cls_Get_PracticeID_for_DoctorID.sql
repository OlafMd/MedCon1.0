
Select
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID as HEC_MedicalPractiseID
From
  hec_doctors Inner Join
  cmn_bpt_ctm_organizationalunit_staff On hec_doctors.BusinessParticipant_RefID
    = cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Inner Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID =
    cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_organizationalunits.IsDeleted = 0
Where
  hec_doctors.HEC_DoctorID = @DoctorID And
  hec_doctors.Tenant_RefID = @TenantID And
  hec_doctors.IsDeleted = 0
	