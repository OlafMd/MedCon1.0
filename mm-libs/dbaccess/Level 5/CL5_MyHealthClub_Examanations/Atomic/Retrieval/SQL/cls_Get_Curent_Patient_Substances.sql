
	Select
  hec_patient_medications.R_DateOfAdding,
  hec_patient_medications.R_ActiveUntill,
  hec_patient_medications.R_IfSubstance_Strength,
  hec_patient_medications.R_DosageText,
  hec_patient_medications.HEC_Patient_MedicationID,
  hec_sub_substances.GlobalPropertyMatchingID
From
  hec_patient_medications Inner Join
  hec_sub_substances On hec_patient_medications.R_IfSubstance_Substance_RefiD =
    hec_sub_substances.HEC_SUB_SubstanceID And
  hec_sub_substances.IsDeleted = 0 And
  hec_sub_substances.Tenant_RefID = @TenantID
Where
  hec_patient_medications.R_ActiveUntill > CurDate() And
  hec_patient_medications.Patient_RefID = @PatientID And
  hec_patient_medications.IsDeleted = 0 And
  hec_patient_medications.Tenant_RefID = @TenantID And
  hec_patient_medications.R_IsActive = 1 And
  hec_patient_medications.R_IsSubstance = 1 
  