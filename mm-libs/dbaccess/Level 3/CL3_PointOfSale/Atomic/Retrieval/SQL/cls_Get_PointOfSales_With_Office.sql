
Select
  cmn_sls_pointofsales.CMN_SLS_PointOfSaleID,
  cmn_sls_pointofsales.PointOfSale_DisplayName,
  cmn_sls_pointofsales.PointOfSaleITL,
  cmn_sls_pointofsales.IsPickUpStationForDistributionOrder,
  cmn_str_offices.CMN_STR_OfficeID,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Office_ShortName
From
  cmn_sls_pointofsales Left Join
  cmn_str_offices On cmn_sls_pointofsales.CMN_STR_Office_RefID =
    cmn_str_offices.CMN_STR_OfficeID And cmn_str_offices.IsDeleted = 0
    And cmn_str_offices.Tenant_RefID = @TenantID
Where
  cmn_sls_pointofsales.IsDeleted = 0 And
  cmn_sls_pointofsales.Tenant_RefID = @TenantID
  