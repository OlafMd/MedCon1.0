
    Select
      bil_billpositions.BIL_BillPositionID as BillPositionID
    From
      bil_billpositions
      Inner Join bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID = bil_billposition_transmitionstatuses.BillPosition_RefID  And
      bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And
      bil_billposition_transmitionstatuses.IsDeleted = 0
    Where
      bil_billpositions.PositionNumber is null And
      bil_billpositions.Tenant_RefID = @TenantID ANd
      bil_billpositions.IsDeleted = 0
	