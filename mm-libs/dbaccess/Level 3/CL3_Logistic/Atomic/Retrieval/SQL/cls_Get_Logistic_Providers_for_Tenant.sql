
   
Select
  log_logisticsproviders.LOG_LogisticsProviderID,
  log_logisticsproviders.IsTrackingAvailable,
  log_logisticsproviders.IsProviding_TransportServices,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName
From
  log_logisticsproviders Inner Join
  cmn_bpt_businessparticipants
    On log_logisticsproviders.Ext_CMN_BPT_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  log_logisticsproviders.IsDeleted = 0 And
  log_logisticsproviders.Tenant_RefID = @TenantID
Order By
  cmn_bpt_businessparticipants.DisplayName
     
 