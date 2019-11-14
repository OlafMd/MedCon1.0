   
Select
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
  RelevantDiagnosis.HEC_Patient_Treatment_RelevantDiagnosisID,
  RelevantDiagnosis.HEC_DIA_Diagnosis_StateID,
  RelevantDiagnosis.HEC_DIA_PotentialDiagnosisID,
  RelevantDiagnosis.Doctor_RefID,
  RelevantDiagnosis.ICD10_Code,
  RelevantDiagnosis.DiagnosisState_Name_DictID,
  RelevantDiagnosis.DiagnosisState_Abbreviation,
  RelevantDiagnosis.Creation_Date,
  RelevantDiagnosis.PotentialDiagnosis_Name_DictID,
  hec_patient_treatment_ocularextension.IsTreatmentOfLeftEye,
  hec_patient_treatment_ocularextension.IsTreatmentOfRightEye,
  RelevantDiagnosis.DiagnosedOnDate,
  Articles.Product_Name_DictID,
  Articles.Product_Number,
  Articles.Quantity,
  Articles.CMN_PRO_ProductID,
  hec_patient_2_patienttreatment.HEC_Patient_RefID,
  hec_patient_treatment.IfSheduled_ForDoctor_RefID,
  hec_patient_treatment.IsDeleted As IsTreatmentDeleted,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  bil_billposition_2_patienttreatment.AssignmentID
From
  hec_patient_treatment Left Join
  (Select
    hec_patient_treatment_relevantdiagnoses.HEC_Patient_Treatment_RelevantDiagnosisID,
    hec_patient_treatment_relevantdiagnoses.Patient_Treatment_RefID,
    hec_patient_treatment_relevantdiagnoses.Doctor_RefID,
    hec_dia_potentialdiagnoses.ICD10_Code,
    hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID,
    hec_dia_diagnosis_states.DiagnosisState_Abbreviation,
    hec_dia_diagnosis_states.DiagnosisState_Name_DictID,
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
    hec_patient_treatment_relevantdiagnoses.Creation_Timestamp As Creation_Date,
    hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
    hec_patient_treatment_relevantdiagnoses.DiagnosedOnDate
  From
    hec_patient_treatment_relevantdiagnoses Inner Join
    hec_dia_potentialdiagnoses
      On hec_patient_treatment_relevantdiagnoses.DIA_PotentialDiagnosis_RefID =
      hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID Inner Join
    hec_dia_diagnosis_states
      On hec_patient_treatment_relevantdiagnoses.DIA_State_RefID =
      hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID
  Where
    hec_patient_treatment_relevantdiagnoses.IsDeleted = 0 And
    hec_dia_diagnosis_states.IsDeleted = 0 And
    hec_dia_potentialdiagnoses.IsDeleted = 0 And
    hec_patient_treatment_relevantdiagnoses.Tenant_RefID = @TenantID)
  RelevantDiagnosis On hec_patient_treatment.HEC_Patient_TreatmentID =
    RelevantDiagnosis.Patient_Treatment_RefID Left Join
  hec_patient_treatment_ocularextension
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_treatment_ocularextension.HEC_Patient_Treatment_RefID And
    hec_patient_treatment_ocularextension.IsDeleted = 0 Left Join
  (Select
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_products.Product_Number,
    hec_patient_treatment_requiredproducts.Quantity,
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
    cmn_pro_products.CMN_PRO_ProductID
  From
    hec_patient_treatment_requiredproducts Inner Join
    hec_products On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
      hec_products.HEC_ProductID Inner Join
    cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID
  Where
    cmn_pro_products.IsDeleted = 0 And
    hec_products.IsDeleted = 0 And
    hec_patient_treatment_requiredproducts.IsDeleted = 0) Articles
    On Articles.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID Left Join
  hec_patient_2_patienttreatment
    On hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    (hec_patient_2_patienttreatment.IsDeleted = 0 Or
      hec_patient_2_patienttreatment.IsDeleted Is Null)  Left Join
  bil_billposition_2_patienttreatment
    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    bil_billposition_2_patienttreatment.IsDeleted = 0
Where
  hec_patient_treatment.IsTreatmentPerformed = 1 And
  hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentIDList 

  