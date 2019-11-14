
Select
  
  bil_billposition_transmitionstatuses.TransmitionCode As StatusCode,
  bil_billposition_transmitionstatuses.IsActive,
  bil_billposition_transmitionstatuses.Creation_Timestamp,
  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID as StatusID
From
  bil_billposition_transmitionstatuses Left Join
  bil_billpositions On bil_billpositions.BIL_BillPositionID =
  bil_billposition_transmitionstatuses.BillPosition_RefID And
  bil_billpositions.Tenant_RefID = @TenantID And     
  bil_billpositions.IsDeleted = 0 
Where
bil_billpositions.BIL_BillPositionID = @BillPosition And
  bil_billposition_transmitionstatuses.Tenant_RefID =
  @TenantID  and
  bil_billposition_transmitionstatuses.IsDeleted = 0
  Order by 
    bil_billposition_transmitionstatuses.Creation_Timestamp desc
	