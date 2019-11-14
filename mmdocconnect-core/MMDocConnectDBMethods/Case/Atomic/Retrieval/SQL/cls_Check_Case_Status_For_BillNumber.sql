
Select
  bil_billposition_transmitionstatuses.TransmitionCode
From
  bil_billposition_transmitionstatuses Inner Join
  bil_billpositions On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID
    And
  bil_billposition_transmitionstatuses.IsDeleted = 0 And
  bil_billposition_transmitionstatuses.IsActive = 1
Where
  bil_billpositions.IsDeleted = 0 And
  bil_billpositions.Tenant_RefID = @TenantID And
  cast(bil_billpositions.PositionNumber as unsigned) = cast(@PositionNumber as unsigned)
	