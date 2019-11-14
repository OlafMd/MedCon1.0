
Select
  log_logisticsproviders.LOG_LogisticsProviderID,
  log_logisticsproviders.IsProviding_TransportServices,
  log_logisticsproviders.IsTrackingAvailable,
  cmn_bpt_businessparticipants.DisplayName
From
  log_logisticsproviders Inner Join
  cmn_bpt_businessparticipants
    On log_logisticsproviders.Ext_CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_availableshipmenttypes
    On cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID =
    cmn_bpt_availableshipmenttypes.CMN_BPT_BusinessParticipant_RefID And
    cmn_bpt_availableshipmenttypes.IsDeleted = 0 And
    cmn_bpt_availableshipmenttypes.Tenant_RefID = @TenantID
Where
  log_logisticsproviders.IsDeleted = 0 And
  log_logisticsproviders.Tenant_RefID = @TenantID And
  cmn_bpt_availableshipmenttypes.LOG_SHP_Shipment_Type_RefID = @ShipmentTypeID
  