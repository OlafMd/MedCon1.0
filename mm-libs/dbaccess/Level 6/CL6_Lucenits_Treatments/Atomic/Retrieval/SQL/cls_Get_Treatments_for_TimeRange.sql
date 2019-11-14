
      Select
      hec_patient_treatment.HEC_Patient_TreatmentID,
      hec_patient_treatment.TreatmentPractice_RefID,
      hec_patient_treatment.IsTreatmentPerformed,
      hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID,
      hec_patient_treatment.IfTreatmentPerformed_Date,
      hec_patient_treatment.IsTreatmentFollowup,
      hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
      hec_patient_treatment.IsScheduled,
      hec_patient_treatment.IfSheduled_Date,
      hec_patient_treatment.IsTreatmentBilled,
      hec_patient_treatment.IfTreatmentBilled_Date,
      hec_patient_treatment.Treatment_Comment,
      hec_patient_treatment.IfSheduled_ForDoctor_RefID
      from  hec_patient_treatment
      Where
      ((hec_patient_treatment.IsTreatmentPerformed = 1 And  hec_patient_treatment.IfTreatmentPerformed_Date <= @toDate And
      hec_patient_treatment.IfTreatmentPerformed_Date >= @fromDate) Or
      (hec_patient_treatment.IsTreatmentPerformed = 0 And
      hec_patient_treatment.IfSheduled_Date <= @toDate And
      hec_patient_treatment.IfSheduled_Date >= @fromDate)) And
      hec_patient_treatment.Tenant_RefID = @TenantID And
      hec_patient_treatment.IsDeleted = 0
 