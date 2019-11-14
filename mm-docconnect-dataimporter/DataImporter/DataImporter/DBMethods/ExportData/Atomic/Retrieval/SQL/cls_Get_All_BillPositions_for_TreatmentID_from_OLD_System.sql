
Select
  bil_billpositions.PositionValue_IncludingTax,
  bil_billpositions.External_PositionReferenceField As VorgangsNummer,
  bil_billpositions.External_PositionType,
  bil_billposition_transmitionstatuses.TransmitionCode,
  bil_billposition_transmitionstatuses.PrimaryComment,
  bil_billposition_transmitionstatuses.SecondaryComment,
  bil_billposition_transmitionstatuses.TransmittedOnDate,
  bil_billpositions.BIL_BillPositionID,
  bil_billpositions.External_PositionCode As GPOS
From
  bil_billposition_2_patienttreatment Inner Join
  bil_billpositions
    On bil_billposition_2_patienttreatment.BIL_BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID And bil_billpositions.IsDeleted = 0 And
    bil_billpositions.Tenant_RefID = @TenantID Inner Join
  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.IsActive = 1
Where
  bil_billposition_2_patienttreatment.IsDeleted = 0 And
  bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID And
  bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID = @TreatmentID
  