
    Select
      tms_pro_feature.TMS_PRO_FeatureID,
      tms_pro_feature.IdentificationNumber,
      tms_pro_feature.DOC_Structure_Header_RefID,
      tms_pro_feature.Project_RefID,
      tms_pro_feature.Component_RefID,
      tms_pro_feature.Type_RefID,
      tms_pro_feature.Status_RefID,
      tms_pro_feature.Name_DictID,
      tms_pro_feature.Description_DictID,
      tms_pro_feature.Feature_Deadline,
      tms_pro_feature.IsArchived,
      tms_pro_feature.Creation_Timestamp,
      tms_pro_businesstask_2_feature.BusinessTask_RefID
    From
      tms_pro_feature Inner Join
      tms_pro_businesstask_2_feature On tms_pro_feature.TMS_PRO_FeatureID =
        tms_pro_businesstask_2_feature.Feature_RefID
    Where
      tms_pro_feature.Project_RefID = @ProjectIDList And
      (tms_pro_feature.IsArchived = 0 Or
        tms_pro_feature.IsArchived = @Is_ArchivedFeatures_Included) And
      tms_pro_feature.Tenant_RefID = @TenantID And
      tms_pro_feature.IsDeleted = 0 And
      tms_pro_businesstask_2_feature.IsDeleted = 0
    Order By
      tms_pro_feature.IdentificationNumber
  