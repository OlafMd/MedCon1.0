    
    Select
      cmn_per_personinfo.Title As title,
      cmn_per_personinfo.FirstName As first_name,
      cmn_per_personinfo.LastName As last_name,
      hec_doctors.HEC_DoctorID as id
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.IsPerformed = 0 And
        hec_act_plannedactions.IsCancelled = 0 And hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @PlannedActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID
        And hec_act_plannedaction_2_actiontype.IsDeleted = 0 Inner Join 
        hec_doctors On
        hec_doctors.BusinessParticipant_RefID = hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID And
        hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On hec_doctors.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
      cmn_per_personinfo
        On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID =
        @TenantID And cmn_per_personinfo.IsDeleted = 0  
    Where
      hec_cas_case_relevantplannedactions.Case_RefID = @CaseID And
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
    Order By
      hec_cas_case_relevantplannedactions.Creation_Timestamp Desc
    Limit 1
	