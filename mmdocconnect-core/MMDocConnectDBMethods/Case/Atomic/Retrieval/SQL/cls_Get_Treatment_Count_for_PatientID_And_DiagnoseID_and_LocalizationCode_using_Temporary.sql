
    Select count(*) as treatment_count
    From tmp_treatment_count
    Where
	    DateOfAction <= @PerformedDate And
      Patient_RefID = @PatientID And
      PotentialDiagnosis_RefID = @DiagnoseID And
      ActionType = @ActionTypeID And
      LocalizationCode = @LocalizationCode
	