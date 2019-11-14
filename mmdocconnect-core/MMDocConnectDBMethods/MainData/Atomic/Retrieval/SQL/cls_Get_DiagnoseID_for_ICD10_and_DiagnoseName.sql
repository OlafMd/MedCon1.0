
    Select
      hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID as DiagnoseID
    From
      hec_dia_potentialdiagnoses
    Inner Join 
      hec_dia_potentialdiagnosis_catalogcodes 
    On 
      hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID = hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID And
      hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID And
      hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 And 
      hec_dia_potentialdiagnosis_catalogcodes.Code = @DiagnoseICD10      
    Inner Join
      hec_dia_potentialdiagnoses_de 
    On 
      hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID = hec_dia_potentialdiagnoses_de.DictID And
      hec_dia_potentialdiagnoses_de.IsDeleted = 0 And
      Replace(hec_dia_potentialdiagnoses_de.Content, ' ', '') = @DiagnoseNameWithoutSpaces
    Where
      hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID And
      hec_dia_potentialdiagnoses.IsDeleted = 0 
  