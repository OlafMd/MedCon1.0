
	Select
  hec_act_performedactions.IfPerfomed_DateOfAction As treatment_date,
  hec_act_performedactions.HEC_ACT_PerformedActionID As id,
   cmn_per_personinfo.ProfileImage_Document_RefID As url,
  Concat_Ws(' ', cmn_per_personinfo.Title, cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName) As doctor
From
  hec_act_performedactions Inner Join
  hec_act_performedaction_doctors
    On hec_act_performedactions.HEC_ACT_PerformedActionID =
    hec_act_performedaction_doctors.HEC_ACT_PerformedAction_RefID And
    hec_act_performedaction_doctors.Tenant_RefID = @TenantID And
    hec_act_performedaction_doctors.IsDeleted = 0 Inner Join
  hec_doctors On hec_act_performedaction_doctors.HEC_Doctor_RefID =
    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
    hec_doctors.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And
  cmn_per_personinfo.IsDeleted = 0 And
  cmn_per_personinfo.Tenant_RefID = @TenantID
Where
  hec_act_performedactions.IsDeleted = 0 And
  hec_act_performedactions.Tenant_RefID = @TenantID And
  hec_act_performedactions.Patient_RefID = @PatientID And
  hec_act_performedactions.IsFollowupPerformedAction = 0 
  