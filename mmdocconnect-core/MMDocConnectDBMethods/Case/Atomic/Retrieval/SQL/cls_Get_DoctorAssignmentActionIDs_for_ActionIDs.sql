    
    Select
      hec_doctors.HEC_DoctorID As doctor_id,
      hec_act_plannedactions.HEC_ACT_PlannedActionID As action_id
    From
      hec_act_plannedactions Inner Join
      hec_doctors
        On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On hec_doctors.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
      cmn_per_personinfo
        On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID
    Where
      hec_act_plannedactions.HEC_ACT_PlannedActionID = @ActionIDs And
      hec_act_plannedactions.Tenant_RefID = @TenantID And
      hec_act_plannedactions.IsDeleted = 0
    Order by 
      Concat_ws(' ', cmn_per_personinfo.FirstName,
      cmn_per_personinfo.LastName) 
