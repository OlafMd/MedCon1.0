
	Select
	  cmn_languages.CMN_LanguageID,
	  cmn_languages.ISO_639_1,
	  cmn_languages.Tenant_RefID,
	  cmn_languages.IsDeleted,
	  cmn_languages.ISO_639_2,
	  cmn_languages.Label,
	  cmn_languages.Name_DictID,
	  cmn_languages.Icon_Document_RefID,
	  cmn_languages.Creation_Timestamp
	From
	  cmn_languages
	Where
	  cmn_languages.Tenant_RefID = @TenantID
    And cmn_languages.IsDeleted = 0
  