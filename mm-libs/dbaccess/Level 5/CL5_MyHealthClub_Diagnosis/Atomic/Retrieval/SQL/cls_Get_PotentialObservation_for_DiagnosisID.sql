
		Select
		  hec_dia_typicalpotentialobservations.HEC_DIA_TypicalPotentialObservationID,
		  hec_dia_typicalpotentialobservations.PotentialObservation_RefID,
		  hec_dia_typicalpotentialobservations.PotentialDiagnosis_RefID,
		  hec_potentialobservations.Observation_Text_DictID
		From
		  hec_potentialobservations Inner Join
		  hec_dia_typicalpotentialobservations
		    On hec_potentialobservations.HEC_PotentialObservationID =
		    hec_dia_typicalpotentialobservations.PotentialObservation_RefID And
		  hec_dia_typicalpotentialobservations.IsDeleted = 0 And
		  hec_dia_typicalpotentialobservations.Tenant_RefID = @TenantID
		Where
		  hec_potentialobservations.Tenant_RefID = @TenantID And
		  hec_potentialobservations.IsDeleted = 0 And
		  hec_dia_typicalpotentialobservations.PotentialDiagnosis_RefID = @DiagnosisID 
  