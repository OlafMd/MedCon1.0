
    Select
      Count(*) as position_count
    From
      bil_billpositions Inner Join
      bil_billposition_transmitionstatuses
        On bil_billpositions.BIL_BillPositionID = bil_billposition_transmitionstatuses.BillPosition_RefID And bil_billposition_transmitionstatuses.IsActive = 1 And
        bil_billposition_transmitionstatuses.TransmitionCode In (2, 11) And
        bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID And bil_billpositions.IsDeleted = 0
    Where
      cast(bil_billpositions.PositionNumber as unsigned) = @BillNumbers And
	    bil_billpositions.Tenant_RefID = @TenantID And
      bil_billpositions.IsDeleted = 0
	