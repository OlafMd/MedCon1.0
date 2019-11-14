
Select
  usr_accounts.DefaultLanguage_RefID,
  usr_accounts.Username,
  usr_accounts.BusinessParticipant_RefID,
  usr_accounts.AccountType,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.ProfileImage_Document_RefID,
  cmn_per_personinfo.BirthDate,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  usr_accounts.Tenant_RefID,
  usr_accounts.USR_AccountID,
  cmn_addresses.CMN_AddressID,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_AdministrativeDistrict,
  cmn_addresses.City_Region,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Province_Name,
  cmn_addresses.Country_ISOCode,
  cmn_addresses.Country_Name
From
  usr_accounts Inner Join
  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
    = usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID Left Join
  cmn_addresses On cmn_addresses.CMN_AddressID =
    cmn_per_personinfo.Address_RefID
Where
  usr_accounts.IsDeleted = 0 And
  cmn_per_personinfo_2_account.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0 And
  (cmn_addresses.IsDeleted = 0 Or
    cmn_addresses.IsDeleted Is Null) And
  usr_accounts.Tenant_RefID = @TenantID And
  usr_accounts.USR_AccountID = @AccountID
  