
    
Select
  tms_pro_tags.TMS_PRO_TagID,
  tms_pro_tags.TagValue
From
  tms_pro_tags
Where
  tms_pro_tags.IsDeleted = 0 And
  tms_pro_tags.Tenant_RefID = @TenantID
    
  