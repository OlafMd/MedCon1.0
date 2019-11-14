
Select
  usr_accounts.AccountSignInEmailAddress as LoginEmail
From
  usr_account_applicationsettings Inner Join
  usr_accounts
    On usr_accounts.USR_AccountID =
    usr_account_applicationsettings.Account_RefID And
    usr_account_applicationsettings.IsDeleted = 0 And
    usr_account_applicationsettings.Tenant_RefID =
    @TenantID Inner Join
  usr_account_applicationsetting_definitions
    On usr_account_applicationsettings.ApplicationSetting_Definition_RefID =
    usr_account_applicationsetting_definitions.USR_Account_ApplicationSetting_DefinitionID And usr_account_applicationsetting_definitions.IsDeleted = 0 And usr_account_applicationsetting_definitions.Tenant_RefID = @TenantID
Where
  usr_account_applicationsettings.IsDeleted = 0 And
  usr_account_applicationsettings.Tenant_RefID =
  @TenantID And
  usr_account_applicationsettings.ItemValue = 'True' And
  usr_account_applicationsetting_definitions.ItemKey = 'ReceiveNotification'
  