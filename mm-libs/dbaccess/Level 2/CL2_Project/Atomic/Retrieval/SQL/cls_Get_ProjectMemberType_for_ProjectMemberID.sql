
	Select
  tmp_pro_projectmember_types.TMP_PRO_ProjectMember_TypeID
From
  tms_pro_projectmembers Inner Join
  tmp_pro_projectmember_types On tms_pro_projectmembers.ProjectMember_Type_RefID
    = tmp_pro_projectmember_types.TMP_PRO_ProjectMember_TypeID
Where
  tms_pro_projectmembers.TMS_PRO_ProjectMemberID =@ProjectMemberID And
  tms_pro_projectmembers.IsDeleted = 0 And
  tmp_pro_projectmember_types.IsDeleted = 0 And
  tms_pro_projectmembers.Tenant_RefID = @TenantID
  