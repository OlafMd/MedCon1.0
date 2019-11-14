
Select
  tmp_pro_projectmember_types.TMP_PRO_ProjectMember_TypeID,
  tmp_pro_projectmember_types.ProjectMemberType_Name_DictID,
  tmp_pro_projectmember_types.Color
From
  tmp_pro_projectmember_types
Where
  tmp_pro_projectmember_types.Tenant_RefID = @TenantID And
  tmp_pro_projectmember_types.IsDeleted = 0
  