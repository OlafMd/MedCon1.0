
Select
  hec_patient_diagnoses.HEC_Patient_DiagnosisID,
  hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID,
  hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID,
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
  hec_dia_diagnosis_localizations.DiagnosisLocalization_Name_DictID,
  hec_dia_diagnosis_states.DiagnosisState_Abbreviation,
  hec_dia_diagnosis_states.DiagnosisState_Name_DictID,
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_patient_diagnoses.Creation_Timestamp As CreationDate,
  cmn_per_personinfo.FirstName As DoctorFirstName,
  cmn_per_personinfo.LastName As DoctorLastName,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  hec_doctors.HEC_DoctorID,
  hec_patient_diagnoses.DiagnosedOnDate
From
  hec_patient_diagnoses Inner Join
  hec_dia_potentialdiagnoses
    On hec_patient_diagnoses.DIA_PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID Inner Join
  hec_dia_diagnosis_localizations
    On hec_dia_diagnosis_localizations.Diagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID Inner Join
  hec_dia_diagnosis_states On hec_patient_diagnoses.DIA_State_RefID =
    hec_dia_diagnosis_states.HEC_DIA_Diagnosis_StateID And
    hec_dia_diagnosis_states.Diagnose_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID Inner Join
  hec_patient_diagnosis_localizations
    On hec_patient_diagnoses.HEC_Patient_DiagnosisID =
    hec_patient_diagnosis_localizations.HEC_Patient_Diagnosis_RefID And
    hec_patient_diagnosis_localizations.HEC_DIA_Diagnosis_Localization_RefID =
    hec_dia_diagnosis_localizations.HEC_DIA_Diagnosis_LocalizationID Inner Join
  hec_doctors On hec_patient_diagnoses.Doctor_RefID = hec_doctors.HEC_DoctorID
  Inner Join
  cmn_bpt_businessparticipants On hec_doctors.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID
Where
  hec_dia_diagnosis_localizations.IsDeleted = 0 And
  hec_dia_diagnosis_states.IsDeleted = 0 And
  hec_dia_potentialdiagnoses.IsDeleted = 0 And
  hec_patient_diagnoses.Tenant_RefID = @TenantID And
  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
  hec_dia_diagnosis_localizations.Tenant_RefID = @TenantID And
  hec_dia_diagnosis_states.Tenant_RefID = @TenantID And
  hec_patient_diagnoses.Patient_RefID = @PatientID And
  hec_patient_diagnosis_localizations.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
  cmn_bpt_businessparticipants.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  hec_patient_diagnoses.IsDeleted = 0
  