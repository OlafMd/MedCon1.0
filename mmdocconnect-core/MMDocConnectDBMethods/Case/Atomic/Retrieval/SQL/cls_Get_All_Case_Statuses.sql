
Select
  bil_billposition_transmitionstatuses.TransmitionCode as StatusNumber,
  bil_billposition_transmitionstatuses.TransmittedOnDate as TreatmentDate,
  bil_billposition_transmitionstatuses.TransmitionStatusKey as CodeForType,
  bil_billpositions.PositionValue_IncludingTax as NumberForPayment,
    bil_billpositions.BIL_BilHeader_RefID as HeaderID
From
  bil_billpositions Inner Join
  bil_billposition_transmitionstatuses
    On bil_billposition_transmitionstatuses.BillPosition_RefID =
    bil_billpositions.BIL_BillPositionID  
    And
  bil_billposition_transmitionstatuses.IsActive = 1
  and
  bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID and 
  bil_billposition_transmitionstatuses.IsDeleted = 0
Where
  bil_billpositions.Tenant_RefID = @TenantID   and
  bil_billpositions.IsDeleted=0 
	