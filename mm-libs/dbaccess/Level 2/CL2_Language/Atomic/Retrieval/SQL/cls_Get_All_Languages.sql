
Select
  cmn_languages.CMN_LanguageID,
  cmn_languages.ISO_639_1,
  cmn_languages.Name_DictID
From
  cmn_languages
Where
  cmn_languages.Tenant_RefID = @TenantID And
  cmn_languages.IsDeleted = 0
  