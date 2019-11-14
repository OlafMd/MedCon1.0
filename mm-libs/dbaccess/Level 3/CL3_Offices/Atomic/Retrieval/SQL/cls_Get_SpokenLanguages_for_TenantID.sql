
	Select
  cmn_languages.CMN_LanguageID,
  cmn_languages.Name_DictID
  From
  cmn_languages
	Where
  cmn_languages.IsDeleted = 0 And 
  cmn_languages.Tenant_RefID = @TenantID	 
  