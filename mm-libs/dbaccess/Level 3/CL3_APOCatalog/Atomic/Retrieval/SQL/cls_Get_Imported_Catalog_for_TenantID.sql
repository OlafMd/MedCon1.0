
Select
  cmn_pro_subscribedcatalogs.SubscribedCatalog_ValidFrom As ValidFrom,
  cmn_pro_subscribedcatalogs.SubscribedCatalog_ValidThrough As ValidTo,
  cmn_pro_subscribedcatalogs.CMN_PRO_SubscribedCatalogID As CatalogID,
  cmn_pro_subscribedcatalogs.SubscribedCatalog_Name As CatalogName,
  (Case
    When Now() >= cmn_pro_subscribedcatalogs.SubscribedCatalog_ValidFrom And
    Now() <= cmn_pro_subscribedcatalogs.SubscribedCatalog_ValidThrough Then true
    Else false End) As IsActive,
  cmn_bpt_businessparticipants.DisplayName As SupplierName,
  cmn_pro_subscribedcatalogs.CatalogCodeITL As CatalogITL,
  cmn_pro_subscribedcatalogs.IsCatalogPublic
From
  cmn_pro_subscribedcatalogs Left Join
  cmn_bpt_suppliers On cmn_pro_subscribedcatalogs.PublishingSupplier_RefID =
    cmn_bpt_suppliers.CMN_BPT_SupplierID And cmn_bpt_suppliers.IsDeleted = 0
  Left Join
  cmn_bpt_businessparticipants
    On cmn_bpt_suppliers.Ext_BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0
Where
  cmn_bpt_businessparticipants.IsCompany = 1 And
  cmn_bpt_businessparticipants.IsNaturalPerson = 0 And
  cmn_pro_subscribedcatalogs.IsDeleted = 0 And
  cmn_pro_subscribedcatalogs.Tenant_RefID = @TenantID And
  cmn_pro_subscribedcatalogs.SubscribedBy_BusinessParticipant_RefID =
  @BussinessParticipantID
  