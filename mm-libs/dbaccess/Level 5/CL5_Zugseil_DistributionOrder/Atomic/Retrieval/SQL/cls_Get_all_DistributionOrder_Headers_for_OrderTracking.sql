
Select 
  ord_dis_distributionorder_headers.ORD_DIS_DistributionOrder_HeaderID, 
  ord_dis_distributionorder_headers.DistributionOrderDate, 
  ord_dis_distributionorder_headers.DistributionOrderNumber, 
  ord_dis_distributionorder_headers.IsCanceled, 
  ord_dis_distributionorder_headers.IsPartiallyFullfilled, 
  ord_dis_distributionorder_headers.IsFullyFullfilled, 
  cmn_str_costcenters.Name_DictID As CostCenterName_DictID, 
  cmn_str_offices.Office_Name_DictID As OfficeName_DictID, 
  log_wrh_warehouses.Warehouse_Name As WarehouseName, 
  drv_employee.Employee as EmployeeName
From 
  ord_dis_distributionorder_headers 
  Left Join cmn_str_costcenters On ord_dis_distributionorder_headers.Charged_CostCenter_RefID = cmn_str_costcenters.CMN_STR_CostCenterID 
  And cmn_str_costcenters.IsDeleted = 0 
  And cmn_str_costcenters.Tenant_RefID = @TenantID 
  Left Join cmn_str_offices On ord_dis_distributionorder_headers.Recipient_Office_RefID = cmn_str_offices.CMN_STR_OfficeID 
  And cmn_str_offices.IsDeleted = 0 
  And cmn_str_offices.Tenant_RefID = @TenantID 
  Left Join log_wrh_warehouses On ord_dis_distributionorder_headers.Recipient_Warehouse_RefID = log_wrh_warehouses.LOG_WRH_WarehouseID 
  And log_wrh_warehouses.IsDeleted = 0 
  And log_wrh_warehouses.Tenant_RefID = @TenantID 
  Left Join cmn_str_costcenters_de On cmn_str_costcenters.Name_DictID = cmn_str_costcenters_de.DictID 
  And cmn_str_costcenters_de.IsDeleted = 0 
  And cmn_str_costcenters_de.Language_RefID = @LanguageID 
  Left Join cmn_str_offices_de On cmn_str_offices.Office_Name_DictID = cmn_str_offices_de.DictID 
  And cmn_str_offices_de.IsDeleted = 0 
  And cmn_str_offices_de.Language_RefID = @LanguageID 
  Left Join (
    Select 
      cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID, 
      cmn_per_personinfo.FirstName, 
      cmn_per_personinfo.LastName, 
      Trim(
        cmn_per_personinfo.FirstName + '' + cmn_per_personinfo.LastName
      ) As Employee 
    From 
      cmn_bpt_emp_employees 
      Inner Join cmn_bpt_businessparticipants On cmn_bpt_emp_employees.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID 
      And cmn_bpt_businessparticipants.IsDeleted = 0 
      And cmn_bpt_businessparticipants.Tenant_RefID = @TenantID 
      Inner Join cmn_per_personinfo On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID 
      And cmn_per_personinfo.IsDeleted = 0 
      And cmn_per_personinfo.Tenant_RefID = @TenantID
  ) drv_employee On ord_dis_distributionorder_headers.Recipient_Employee_RefID = drv_employee.CMN_BPT_EMP_EmployeeID 
Where 
  ord_dis_distributionorder_headers.DistributionOrderDate Between Coalesce(
    @StartDate, ord_dis_distributionorder_headers.DistributionOrderDate
  ) 
  And Coalesce(
    @EndDate, ord_dis_distributionorder_headers.DistributionOrderDate
  ) 
  And (
    (
      ord_dis_distributionorder_headers.IsCanceled = @IsCanceled 
      And ord_dis_distributionorder_headers.IsPartiallyFullfilled = @IsPartiallyFullfilled 
      And ord_dis_distributionorder_headers.IsFullyFullfilled = @IsFullyFullfilled
    ) 
    Or @IsNew = 1
  ) 
  And (
    (
      log_wrh_warehouses.Warehouse_Name Is Null 
      And @Warehouse = '%%'
    ) 
    Or (
      log_wrh_warehouses.Warehouse_Name Is Not Null 
      And log_wrh_warehouses.Warehouse_Name Like Lower(@Warehouse)
    )
  ) 
  And ord_dis_distributionorder_headers.IsDeleted = 0 
  And ord_dis_distributionorder_headers.Tenant_RefID = @TenantID 
  And Lower(
    ord_dis_distributionorder_headers.DistributionOrderNumber
  ) Like Lower(@OrderNumber) 
  And (
    (
      cmn_str_costcenters_de.Content Is Null 
      And @CostCenter = '%%'
    ) 
    Or (
      cmn_str_costcenters_de.Content Is Not Null 
      And Lower(cmn_str_costcenters_de.Content) Like Lower(@CostCenter)
    )
  ) 
  And (
    (
      cmn_str_offices_de.Content Is Null 
      And @Office = '%%'
    ) 
    Or (
      cmn_str_offices_de.Content Is Not Null 
      And Lower(cmn_str_offices_de.Content) Like Lower(@Office)
    )
  ) 
  And (
    (
      drv_employee.Employee Is Null 
      And @Employee = '%%'
    ) 
    Or (
      drv_employee.Employee Is Not Null 
      And Lower(drv_employee.Employee) Like Lower(@Employee)
    )
  ) 
Order By 
  ord_dis_distributionorder_headers.DistributionOrderNumber LIMIT @PageSize OFFSET @ActivePage
    