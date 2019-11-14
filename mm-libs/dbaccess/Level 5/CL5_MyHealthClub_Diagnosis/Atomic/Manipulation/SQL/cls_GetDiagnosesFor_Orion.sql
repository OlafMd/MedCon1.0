
	Select
	  hec_dia_potentialdiagnoses.ICD10_Code,
	  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
	  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID
	From
	  hec_dia_potentialdiagnoses
	Where
	  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
	  hec_dia_potentialdiagnoses.IsDeleted = 0
  