
Select   distinct
  cmn_str_offices.CMN_STR_OfficeID As OfficeID,
  cmn_str_offices.Office_Name_DictID
From
  hec_medicalpractice_types Inner Join
  hec_medicalpractice_2_practicetype
    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID =
    hec_medicalpractice_types.HEC_MedicalPractice_TypeID Inner Join
  hec_medicalpractises
    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_str_offices On cmn_str_offices.IfMedicalPractise_HEC_MedicalPractice_RefID
    = hec_medicalpractises.HEC_MedicalPractiseID
Where
  hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID = @MedicalPracticeTypeID And
  hec_medicalpractice_2_practicetype.IsDeleted = 0 And
  hec_medicalpractice_2_practicetype.Tenant_RefID = @TenantID
  