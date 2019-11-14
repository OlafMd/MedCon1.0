
Select
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_treatment.IsTreatmentFollowup,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID
From
  hec_patient_treatment
Where
  hec_patient_treatment.IsTreatmentPerformed = 1 And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment.Tenant_RefID = @TenantID And
  Month(hec_patient_treatment.IfTreatmentPerformed_Date) = @SelectedMounth And
  Year(hec_patient_treatment.IfTreatmentPerformed_Date) = @SelectedYear And
  hec_patient_treatment.IsTreatmentBilled = 1
  