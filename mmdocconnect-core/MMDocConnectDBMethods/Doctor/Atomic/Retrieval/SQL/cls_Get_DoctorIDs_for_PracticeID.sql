
  Select
    hec_doctors.HEC_DoctorID as DoctorID
  From
    hec_medicalpractises Inner Join
    cmn_bpt_ctm_organizationalunits
      On
      cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID
      = hec_medicalpractises.HEC_MedicalPractiseID And
      cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And
      cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Inner Join
    cmn_bpt_ctm_organizationalunit_staff
      On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID =
      cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
      cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
      cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Inner Join
    hec_doctors On cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID
      = hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID =
      @TenantID And hec_doctors.IsDeleted = 0
  Where
    hec_medicalpractises.Tenant_RefID = @TenantID And
    hec_medicalpractises.IsDeleted = 0 And
    hec_medicalpractises.HEC_MedicalPractiseID = @PracticeID
	