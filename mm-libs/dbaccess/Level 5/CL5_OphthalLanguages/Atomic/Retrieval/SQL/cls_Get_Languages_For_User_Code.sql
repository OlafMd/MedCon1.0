
	Select
	  cmn_languages.CMN_LanguageID,
	  cmn_languages.ISO_639_1,
	  cmn_languages.Label,
	  cmn_languages.Name_DictID
	From
	  usr_device_accountcodes Inner Join
	  cmn_languages On usr_device_accountcodes.Tenant_RefID =
	    cmn_languages.Tenant_RefID
	Where
	  usr_device_accountcodes.AccountCode_Value = @DeviceCode And
	  usr_device_accountcodes.IsDeleted = 0 And
	  cmn_languages.IsDeleted = 0
  