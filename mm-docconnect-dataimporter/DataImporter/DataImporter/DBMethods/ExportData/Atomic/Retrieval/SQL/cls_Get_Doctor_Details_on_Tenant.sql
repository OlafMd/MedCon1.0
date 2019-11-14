
Select
  hec_doctors.HEC_DoctorID As DoctorID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  hec_doctors.DoctorIDNumber As DoctorLANR,
  cmn_bpt_businessparticipants1.DisplayName As PracticeName,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.Salutation_General,
  cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID As PracticeBPTID,
  hec_doctors.BusinessParticipant_RefID As DoctorBptId,
  cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID as PracticeId
From
  hec_doctors Left Join
  cmn_bpt_businessparticipants
    On hec_doctors.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipants.Tenant_RefID =
    @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID =
    @TenantID And cmn_per_personinfo.IsDeleted = 0 Left Join
  cmn_bpt_ctm_organizationalunit_staff
    On hec_doctors.BusinessParticipant_RefID = cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID And
    cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0 Left Join
  cmn_bpt_ctm_organizationalunits
    On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
    cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And cmn_bpt_ctm_organizationalunits.IsDeleted = 0 Left Join
  hec_medicalpractises
    On cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID = hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.Tenant_RefID = @TenantID And hec_medicalpractises.IsDeleted = 0 Left Join
  cmn_bpt_ctm_customers
    On cmn_bpt_ctm_organizationalunits.Customer_RefID = cmn_bpt_ctm_customers.CMN_BPT_CTM_CustomerID And cmn_bpt_ctm_customers.Tenant_RefID = @TenantID And
    cmn_bpt_ctm_customers.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
    On cmn_bpt_ctm_customers.Ext_BusinessParticipant_RefID = cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants1.IsDeleted = 0
Where
  hec_doctors.Tenant_RefID = @TenantID And
  hec_doctors.IsDeleted = 0
	