
Select
  hec_dia_potentialdiagnosis_catalogs.Catalog_Name_DictID,
  hec_dia_potentialdiagnosis_catalog_access.IsContributor,
  hec_dia_potentialdiagnosis_catalogs.IsPrivateCatalog,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.Title,
  hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID,
  hec_dia_potentialdiagnosis_catalog_access.HEC_DIA_PotentialDiagnosis_Catalog_AccessID
From
  hec_dia_potentialdiagnosis_catalogs Left Join
  hec_dia_potentialdiagnosis_catalog_access
    On hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID
    = hec_dia_potentialdiagnosis_catalog_access.PotentialDiagnosis_Catalog_RefID
    And hec_dia_potentialdiagnosis_catalog_access.Tenant_RefID = @TenantID And
    hec_dia_potentialdiagnosis_catalog_access.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants
    On hec_dia_potentialdiagnosis_catalog_access.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 Left Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.Tenant_RefID
    = @TenantID And cmn_per_personinfo.IsDeleted = 0
Where
  hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID And
  hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0
  