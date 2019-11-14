
     SELECT MAX(CONVERT(bil_billpositions.PositionNumber, SIGNED)) AS  latest_bill_position_number
        From
          bil_billpositions
        Where
          bil_billpositions.Tenant_RefID = @TenantID
	