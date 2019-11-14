
	Select Distinct
  hec_dia_potentialdiagnoses.ICD10_Code,
  hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID,
  hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
  hec_dia_potentialdiagnosis_prioritysequence.PriorityNumber_Manual,
  hec_dia_potentialdiagnosis_prioritysequence.PriorityNumber_Automatic,
  hec_dia_potentialdiagnosis_prioritysequence.HEC_DIA_PotentialDiagnosis_PrioritySequenceID,
  hec_dia_potentialdiagnosis_catalogs.IsUsingSelfLearningPriorities,
  hec_dia_potentialdiagnosis_catalogs.SelfLearningPriorities_InitializationTreshold,
  hec_dia_potentialdiagnosis_catalogs.SelfLearningPriorities_NumberOfPastDaysTakenIntoAccount,
  hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
From
  hec_dia_potentialdiagnoses Inner Join
  hec_dia_potentialdiagnoses_de
    On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID =
    hec_dia_potentialdiagnoses_de.DictID Inner Join
  hec_dia_potentialdiagnosis_catalogcodes
    On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID =
    hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
    hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 And
    hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID Inner Join
  hec_dia_potentialdiagnosis_catalogs
    On hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
    = hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID
    And hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0 And
    hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID =
    @CatalogID Inner Join
  hec_dia_potentialdiagnosis_prioritysequence
    On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
    hec_dia_potentialdiagnosis_prioritysequence.PotentialDiagnosis_RefID And
    hec_dia_potentialdiagnosis_prioritysequence.PotentialDiagnosis_Catalog_RefID
    = hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
    And hec_dia_potentialdiagnosis_prioritysequence.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_prioritysequence.IsDeleted = 0 And
    hec_dia_potentialdiagnosis_prioritysequence.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_prioritysequence.IsDeleted = 0
Where
  hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
  hec_dia_potentialdiagnoses.IsDeleted = 0 And
  hec_dia_potentialdiagnoses_de.Language_RefID = @LanguageID And
  hec_dia_potentialdiagnoses_de.IsDeleted = 0
	   @SearchCriterium
  ORDER BY 
        Case When @OrderBy = 'ASC' Then @OrderValue End Asc,
        Case When @OrderBy = 'DESC' Then @OrderValue End Desc
  LIMIT @StartIndex , @NumberOfElements
  