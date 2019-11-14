
Select
  hec_act_performedactions.IfPerfomed_DateOfAction,
  cmn_str_offices.Office_Name_DictID,
  hec_act_performedaction_doctors.HEC_Doctor_RefID,
  hec_act_performedactions.HEC_ACT_PerformedActionID,
  cmn_per_personinfo.Title As DoctorTitle,
  cmn_per_personinfo.FirstName As DoctorFirstName,
  cmn_per_personinfo.LastName As DoctorLastName
From
  hec_act_performedaction_doctors Inner Join
  hec_act_performedactions On hec_act_performedactions.HEC_ACT_PerformedActionID
    = hec_act_performedaction_doctors.HEC_ACT_PerformedAction_RefID And
    hec_act_performedactions.Tenant_RefID = @TenantID And
    hec_act_performedactions.IsDeleted = 0 And
    hec_act_performedactions.IsPerformed_Externally = 0 Inner Join
  hec_medicalpractises
    On hec_act_performedactions.IsPerformed_MedicalPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID =
    @TenantID Inner Join
  cmn_str_offices On cmn_str_offices.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID And cmn_str_offices.IsDeleted =
    0 And cmn_str_offices.Tenant_RefID = @TenantID And
    cmn_str_offices.IsMedicalPractice = 1 Inner Join
  hec_doctors On hec_act_performedaction_doctors.HEC_Doctor_RefID =
    hec_doctors.HEC_DoctorID And
  hec_doctors.IsDeleted = 0 And
  hec_doctors.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_per_personinfo.Tenant_RefID = @TenantID
Where
  hec_act_performedaction_doctors.HEC_Doctor_RefID = @ListDoctorID And
  hec_act_performedaction_doctors.Tenant_RefID = @TenantID And
  hec_act_performedaction_doctors.IsDeleted = 0
  