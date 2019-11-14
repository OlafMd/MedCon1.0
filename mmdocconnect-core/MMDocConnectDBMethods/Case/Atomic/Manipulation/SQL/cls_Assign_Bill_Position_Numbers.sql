
update bil_billpositions as t1,
(Select
  cast(bil_billpositions.PositionNumber as unsigned) as LatestBillPositionNumber
From
  bil_billpositions
Where
  bil_billpositions.Tenant_RefID = @TenantID
Order By 
  LatestBillPositionNumber desc
Limit 1
For Update) as t2
set t1.PositionNumber = t2.LatestBillPositionNumber + 1
where
  t1.Tenant_RefID = @TenantID And
  t1.BIL_BillPositionID = @bill_position_id
  
	