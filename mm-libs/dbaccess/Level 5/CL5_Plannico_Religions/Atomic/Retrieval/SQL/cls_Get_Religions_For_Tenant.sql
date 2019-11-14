
Select
  cmn_per_religions.CMN_PER_ReligionID,
  cmn_per_religions.GlobalPropertyMatchingID,
  cmn_per_religions.Religion_Name_DictID,
  cmn_per_religion_2_economicregion.Religion_Code
From
  cmn_per_religions Inner Join
  cmn_per_religion_2_economicregion On cmn_per_religions.CMN_PER_ReligionID =
    cmn_per_religion_2_economicregion.CMN_PER_Religion_RefID
Where
  cmn_per_religions.IsDeleted = 0 And
  cmn_per_religions.Tenant_RefID = @TenantID And
  cmn_per_religion_2_economicregion.IsDeleted = 0
  