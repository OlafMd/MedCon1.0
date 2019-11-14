
    Select
      hec_act_performedactions.IfPerfomed_DateOfAction As oct_date,
      cmn_per_personinfo.Title As oct_doctor_title,
      cmn_per_personinfo.FirstName As oct_doctor_first_name,
      cmn_per_personinfo.LastName As oct_doctor_last_name,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code as localization
    From
      hec_cas_case_relevantplannedactions Inner Join
      hec_act_plannedactions
        On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And hec_act_plannedactions.Patient_RefID =
        @PatientID And hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsDeleted = 0 Inner Join
      hec_act_performedactions
        On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.IfPerfomed_DateOfAction Between @ConsentStart And @ConsentEnd And hec_act_performedactions.Tenant_RefID = @TenantID And
        hec_act_performedactions.IsDeleted = 0 Inner Join
        hec_act_performedaction_diagnosisupdates on 
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And
        hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations on
  	    hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID And
 	     hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And
  	    hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 Inner Join
	    hec_cas_case_billcodes
        On hec_cas_case_relevantplannedactions.Case_RefID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.Tenant_RefID = @TenantID And
        hec_cas_case_billcodes.IsDeleted = 0 Inner Join
      hec_bil_billposition_billcodes
        On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
        hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0 Inner Join
      hec_bil_billpositions
        On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID = @TenantID And
        hec_bil_billpositions.IsDeleted = 0 Inner Join
      bil_billposition_transmitionstatuses
        On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billposition_transmitionstatuses.BillPosition_RefID And
        bil_billposition_transmitionstatuses.TransmitionCode Not In (8, 11, 17) And bil_billposition_transmitionstatuses.TransmitionStatusKey = 'oct' And
        bil_billposition_transmitionstatuses.IsActive = 1 And bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
        bil_billposition_transmitionstatuses.IsDeleted = 0 Inner Join
      cmn_bpt_businessparticipants
        On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
        cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0 Inner Join
      cmn_per_personinfo
        On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID =
        @TenantID And cmn_per_personinfo.IsDeleted = 0 Inner Join
      hec_act_plannedaction_2_actiontype
        On hec_act_plannedactions.HEC_ACT_PlannedActionID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID And
        hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = @PlannedOctActionTypeID And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And
        hec_act_plannedaction_2_actiontype.IsDeleted = 0
    Where
      hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And
      hec_cas_case_relevantplannedactions.IsDeleted = 0
    Group By
      bil_billposition_transmitionstatuses.BillPosition_RefID
    Order By
      Null
	