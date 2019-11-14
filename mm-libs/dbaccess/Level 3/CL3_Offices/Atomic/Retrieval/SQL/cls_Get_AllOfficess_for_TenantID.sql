
Select
  cmn_str_offices.CMN_STR_OfficeID As OfficeID,
  cmn_str_offices.Parent_RefID As ParentID,
  cmn_str_offices.Office_Name_DictID,
  cmn_str_offices.Office_InternalNumber,
  cmn_str_offices.IsMedicalPractice
From
  cmn_str_offices
Where
  cmn_str_offices.Tenant_RefID = @TenantID And
  cmn_str_offices.IsDeleted = 0 
  