
	Select
	  hec_dia_potentialdiagnoses.ICD10_Code,
	  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
	  hec_act_performedaction_diagnosisupdates.IsDiagnosisNegated,
	  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
	From
	  hec_dia_potentialdiagnoses Inner Join
	  hec_act_performedaction_diagnosisupdates
	    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
	    hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID And
	    hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And
	    hec_act_performedaction_diagnosisupdates.Tenant_RefID = @TenantID
	Where
	  hec_dia_potentialdiagnoses.IsDeleted = 0 And
	  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID
  