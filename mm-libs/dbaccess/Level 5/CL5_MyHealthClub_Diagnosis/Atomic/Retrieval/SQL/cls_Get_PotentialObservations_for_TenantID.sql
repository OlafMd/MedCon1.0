
	Select
	  hec_potentialobservations.Observation_Text_DictID,
	  hec_potentialobservations.HEC_PotentialObservationID
	From
	  hec_potentialobservations
	Where
	  hec_potentialobservations.Tenant_RefID = @TenantID And
	  hec_potentialobservations.IsDeleted = 0
  