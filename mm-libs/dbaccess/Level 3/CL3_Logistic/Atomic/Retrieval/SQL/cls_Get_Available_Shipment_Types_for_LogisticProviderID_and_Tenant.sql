
   
Select
  cmn_bpt_availableshipmenttypes.CMN_BPT_AvailableShipmentTypeID,
  cmn_bpt_availableshipmenttypes.IsPrimaryShipmentType,
  log_shp_shipment_types.ShipmentType_Name_DictID,
  log_shp_shipment_types.ShipmentType_Description_DictID
From
  log_logisticsproviders Right Join
  cmn_bpt_availableshipmenttypes
    On log_logisticsproviders.Ext_CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_availableshipmenttypes.CMN_BPT_BusinessParticipant_RefID Inner Join
  log_shp_shipment_types
    On cmn_bpt_availableshipmenttypes.LOG_SHP_Shipment_Type_RefID =
    log_shp_shipment_types.LOG_SHP_Shipment_TypeID
Where
  log_logisticsproviders.LOG_LogisticsProviderID = @LogisticProviderID And
  log_logisticsproviders.Tenant_RefID = @TenantID And
  log_logisticsproviders.IsDeleted = 0 And
  cmn_bpt_availableshipmenttypes.IsDeleted = 0 or Null
     
 