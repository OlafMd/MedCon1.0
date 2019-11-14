
Select
  acc_bnk_banks.ACC_BNK_BankID,
  acc_bnk_banks.BankName,
  acc_bnk_banks.BICCode,
  acc_bnk_banks.RoutingNumber,
  acc_bnk_banks.BankNumber,
  acc_bnk_banks.BankLocationComment,
  cmn_countries.Country_ISOCode_Alpha2
From
  acc_bnk_banks Inner Join
  cmn_countries On cmn_countries.CMN_CountryID = acc_bnk_banks.Country_RefID
Where
  acc_bnk_banks.IsDeleted = 0 And
  acc_bnk_banks.Tenant_RefID = @TenantID
  