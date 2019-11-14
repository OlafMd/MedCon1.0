
    Select Distinct
      Concat(hec_dia_potentialdiagnoses_de.Content, ' (',
      hec_dia_potentialdiagnosis_catalogcodes.Code, ')') As DiagnoseName,
      hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID As DiagnoseID,
  hec_dia_potentialdiagnosis_catalogcodes.Code As DiagnoseICD10
    From
      hec_dia_potentialdiagnoses
      Inner Join hec_dia_potentialdiagnosis_catalogcodes
        On hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID =
        hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID And
        hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID =
        @TenantID And
        hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0
      Inner Join hec_dia_potentialdiagnoses_de
        On hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID =
        hec_dia_potentialdiagnoses_de.DictID And
        hec_dia_potentialdiagnoses_de.IsDeleted = 0
    Where
      hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID
      And
      hec_dia_potentialdiagnoses.IsDeleted = 0 And
      (Lower(hec_dia_potentialdiagnoses_de.Content) Like @SearchCriteria Or
        Lower(hec_dia_potentialdiagnosis_catalogcodes.Code) Like @SearchCriteria)
  