
	Select
	 COUNT(bil_billheaders.BIL_BillHeaderID) as numberOfBillings
	From
	  bil_billheaders Inner Join
	  bil_billposition_2_patienttreatment
	    On bil_billposition_2_patienttreatment.IsDeleted = 0 And
	    bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID Left Join
	  hec_patient_treatment On hec_patient_treatment.HEC_Patient_TreatmentID =
	    bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID And
	    hec_patient_treatment.IsDeleted = 0 And
	    hec_patient_treatment.IsTreatmentBilled = 1 And
	    hec_patient_treatment.Tenant_RefID = @TenantID
	Where
	  Month(hec_patient_treatment.IfTreatmentPerformed_Date) = @SelectedMounth
  