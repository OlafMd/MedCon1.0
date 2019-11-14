
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
  ord_dis_distributionorder_positions.ORD_DIS_DistributionOrder_PositionID, 
  ord_dis_distributionorder_positions.Quantity, 
  ord_dis_distributionorder_positions.Position_OrdinalNumber, 
  cmn_pro_products.CMN_PRO_ProductID, 
  cmn_pro_products.Product_Name_DictID, 
  cmn_pro_products.Product_Number, 
  cmn_pro_product_variants.CMN_PRO_Product_VariantID, 
  cmn_pro_product_variants.IsStandardProductVariant, 
  cmn_pro_product_variants.VariantName_DictID, 
  dtb_distribution_order_created_by.DisplayName As CreatedBy_BusinessParticipantDisplayName, 
  dtb_distribution_order_created_by.CMN_BPT_BusinessParticipantID As CreatedBy_BusinessParticipantID, 
  drv_employee.EmployeeName 
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
  Left Join ord_dis_distributionorder_positions On ord_dis_distributionorder_headers.ORD_DIS_DistributionOrder_HeaderID = ord_dis_distributionorder_positions.DistributionOrder_Header_RefID 
  And ord_dis_distributionorder_positions.IsDeleted = 0 
  And ord_dis_distributionorder_positions.Tenant_RefID = @TenantID 
  Left Join cmn_pro_products On ord_dis_distributionorder_positions.Product_RefID = cmn_pro_products.CMN_PRO_ProductID 
  And cmn_pro_products.IsDeleted = 0 
  And cmn_pro_products.Tenant_RefID = @TenantID 
  Left Join cmn_pro_product_variants On ord_dis_distributionorder_positions.Product_Variant_RefID = cmn_pro_product_variants.CMN_PRO_Product_VariantID 
  And cmn_pro_product_variants.IsDeleted = 0 
  And cmn_pro_product_variants.Tenant_RefID = @TenantID 
  Left Join (
    Select 
      ord_dis_distributionorder_header_history.ORD_DIS_DistributionOrder_Header_HistoryID, 
      ord_dis_distributionorder_header_history.DistributionOrder_Header_RefID, 
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID, 
      cmn_bpt_businessparticipants.DisplayName 
    From 
      ord_dis_distributionorder_header_history 
      Left Join cmn_bpt_businessparticipants On ord_dis_distributionorder_header_history.TriggeredBy_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID 
      And cmn_bpt_businessparticipants.IsDeleted = 0 
      And cmn_bpt_businessparticipants.Tenant_RefID = @TenantID 
    Where 
      ord_dis_distributionorder_header_history.IsCreated = 1 
      And ord_dis_distributionorder_header_history.IsDeleted = 0 
      And ord_dis_distributionorder_header_history.Tenant_RefID = @TenantID
  ) dtb_distribution_order_created_by On ord_dis_distributionorder_headers.ORD_DIS_DistributionOrder_HeaderID = dtb_distribution_order_created_by.DistributionOrder_Header_RefID 
  Left Join (
    Select 
      cmn_bpt_emp_employees.CMN_BPT_EMP_EmployeeID, 
      cmn_per_personinfo.FirstName, 
      cmn_per_personinfo.LastName, 
      cmn_per_personinfo.FirstName + ' ' + cmn_per_personinfo.LastName As EmployeeName 
    From 
      cmn_bpt_emp_employees 
      Inner Join cmn_bpt_businessparticipants On cmn_bpt_emp_employees.BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID 
      And cmn_bpt_businessparticipants.IsDeleted = 0 
      And cmn_bpt_businessparticipants.Tenant_RefID = @TenantID 
      Inner Join cmn_per_personinfo On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID 
      And cmn_per_personinfo.IsDeleted = 0 
      And cmn_per_personinfo.Tenant_RefID = @TenantID 
    Where 
      cmn_bpt_emp_employees.IsDeleted = 0 
      And cmn_bpt_emp_employees.Tenant_RefID = @TenantID
  ) drv_employee On ord_dis_distributionorder_headers.Recipient_Employee_RefID = drv_employee.CMN_BPT_EMP_EmployeeID 
Where 
  ord_dis_distributionorder_headers.ORD_DIS_DistributionOrder_HeaderID = @DistributionOrderHeaderID 
  And ord_dis_distributionorder_headers.IsDeleted = 0 
  And ord_dis_distributionorder_headers.Tenant_RefID = @TenantID
    
    