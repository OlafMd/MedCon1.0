
    Select
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As localization,
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As diagnose_id,
      Convert(Concat(hec_dia_potentialdiagnoses_de.Content, ' (', hec_dia_potentialdiagnosis_catalogs.Catalog_DisplayName, ': ',
      hec_dia_potentialdiagnosis_catalogcodes.Code, ')') Using utf8) As diagnose_name,
      hec_act_plannedactions.HEC_ACT_PlannedActionID As action_id
    From
      hec_act_plannedactions Inner Join
      hec_act_performedaction_diagnosisupdates
        On hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID = hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And
        hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 Inner Join
      hec_act_performedaction_diagnosisupdate_localizations
        On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID =
        hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0
      Inner Join
      hec_dia_potentialdiagnoses
        On hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID Inner Join
      hec_dia_potentialdiagnoses_de
        On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID = hec_dia_potentialdiagnoses_de.DictID And hec_dia_potentialdiagnoses_de.IsDeleted = 0
      Inner Join
      hec_dia_potentialdiagnosis_catalogcodes
        On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
        hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 Inner Join
      hec_dia_potentialdiagnosis_catalogs
        On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID = hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID And
        hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0
    Where
      hec_act_plannedactions.Patient_RefID = @PatientID And
      hec_act_plannedactions.IsDeleted = 0 And
      hec_act_plannedactions.Tenant_RefID = @TenantID
    Group By
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID
    Order By
      Null
	