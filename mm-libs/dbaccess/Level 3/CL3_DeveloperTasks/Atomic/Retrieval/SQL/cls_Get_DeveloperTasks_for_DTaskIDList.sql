
Select
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
  tms_pro_developertasks.Name,
  tms_pro_developertasks.IdentificationNumber,
  tms_pro_developertasks.DeveloperTime_CurrentInvestment_min,
  tms_pro_developertasks.DeveloperTime_RequiredEstimation_min,
  tms_pro_developertasks.PercentageComplete,
  tms_pro_developertasks.Description,
  tms_pro_developertasks.Completion_Deadline,
  tms_pro_developertask_priorities.Label_DictID As Priority_Label_DictID,
  tms_pro_developertask_priorities.IconLocationURL As Priority_IconLocationURL,
  tms_pro_developertask_types.Label_DictID As Type_Label_DictID,
  tms_pro_developertask_types.IconLocationURL As Type_IconLocationURL,
  tms_pro_developertasks.IsIncompleteInformation,
  tms_pro_developertasks.Creation_Timestamp,
  tms_pro_developertask_priorities.PriorityLevel As Priority_Level,
  tms_pro_developertasks.IsComplete,
  tms_pro_developertasks.IsBeingPrepared,
  usr_accounts.Username As CreatedBy_Username,
  tms_pro_developertask_types.TMS_PRO_DeveloperTask_TypeID,
  tms_pro_developertask_priorities.TMS_PRO_DeveloperTask_PriorityID,
  RecommendedTo.USR_AccountID,
  RecommendedTo.Username,
  tms_pro_developertasks.Completion_Timestamp,
  tms_pro_developertasks.DOC_Structure_Header_RefID,
  tms_pro_developertasks.IsArchived,
  Assignment.ProjectMember_RefID,
  Assignment.DeveloperTask_RefID,
  Assignment.OrderSequence,
  Assignment.R_InvestedWorkingTime_min,
  Assignment.Developer_CompletionTimeEstimation_min,
  Assignment.IsActive,
  Assignment.TMS_PRO_DeveloperTask_InvolvementID,
  Assignment.Assignment_Timestamp,
  Assignment.Assignment_Username,
  Revision.CMN_PRO_Product_ReleaseID,
  Revision.Product_Name_DictID,
  Revision.Product_ReleaseName,
  tms_pro_projects.Name_DictID,
  tms_pro_feature_type.Label_DictID As FeaturType_Dict,
  tms_pro_developertask_priorities.Priority_Colour,
  Documents.DocCount
From
  tms_pro_developertasks Left Join
  (Select
    tms_pro_developertask_recommendations.DeveloperTask_RefID,
    usr_accounts_RecommendedTo.USR_AccountID,
    usr_accounts_RecommendedTo.Username
  From
    tms_pro_developertask_recommendations Inner Join
    tms_pro_projectmembers tms_pro_projectmembers_RecommendedTo
      On tms_pro_developertask_recommendations.RecommendedTo_ProjectMember_RefID
      = tms_pro_projectmembers_RecommendedTo.TMS_PRO_ProjectMemberID Inner Join
    usr_accounts usr_accounts_RecommendedTo
      On tms_pro_projectmembers_RecommendedTo.USR_Account_RefID =
      usr_accounts_RecommendedTo.USR_AccountID
  Where
    tms_pro_developertask_recommendations.IsDeleted = 0 And
    tms_pro_projectmembers_RecommendedTo.IsDeleted = 0 And
    usr_accounts_RecommendedTo.IsDeleted = 0 And
    tms_pro_developertask_recommendations.Tenant_RefID = @TenantID)
  RecommendedTo On RecommendedTo.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Left Join
  tms_pro_developertask_priorities On tms_pro_developertasks.Priority_RefID =
    tms_pro_developertask_priorities.TMS_PRO_DeveloperTask_PriorityID Left Join
  tms_pro_developertask_types On tms_pro_developertasks.DeveloperTask_Type_RefID
    = tms_pro_developertask_types.TMS_PRO_DeveloperTask_TypeID Left Join
  (Select
    usr_accounts.Username As Assignment_Username,
    tms_pro_projectmembers.TMS_PRO_ProjectMemberID,
    tms_pro_developertask_involvements.TMS_PRO_DeveloperTask_InvolvementID,
    tms_pro_developertask_involvements.OrderSequence,
    tms_pro_developertask_involvements.R_InvestedWorkingTime_min,
    tms_pro_developertask_involvements.Creation_Timestamp As
    Assignment_Timestamp,
    tms_pro_developertask_involvements.Developer_CompletionTimeEstimation_min,
    tms_pro_developertask_involvements.IsActive,
    tms_pro_developertask_involvements.ProjectMember_RefID,
    tms_pro_developertask_involvements.DeveloperTask_RefID
  From
    tms_pro_projectmembers Inner Join
    usr_accounts On usr_accounts.USR_AccountID =
      tms_pro_projectmembers.USR_Account_RefID Inner Join
    tms_pro_developertask_involvements
      On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
      tms_pro_developertask_involvements.ProjectMember_RefID
  Where
    tms_pro_projectmembers.Tenant_RefID = @TenantID And
    usr_accounts.IsDeleted = 0 And
    tms_pro_projectmembers.IsDeleted = 0 And
    tms_pro_developertask_involvements.IsDeleted = 0 And
    (tms_pro_developertask_involvements.IsArchived = 0 Or
      tms_pro_developertask_involvements.IsArchived = @IncludeCompleted))
  Assignment On Assignment.ProjectMember_RefID =
    tms_pro_developertasks.GrabbedByMember_RefID And
    Assignment.DeveloperTask_RefID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID Inner Join
  tms_pro_projectmembers On tms_pro_projectmembers.TMS_PRO_ProjectMemberID =
    tms_pro_developertasks.CreatedBy_ProjectMember_RefID Inner Join
  usr_accounts On tms_pro_projectmembers.USR_Account_RefID =
    usr_accounts.USR_AccountID Left Join
  (Select
    cmn_pro_product_release_2_developertask.TMS_PRO_DeveloperTask_RefID,
    cmn_pro_product_releases.CMN_PRO_Product_ReleaseID,
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_product_releases.Product_ReleaseName
  From
    cmn_pro_product_releases Inner Join
    cmn_pro_product_release_2_developertask
      On cmn_pro_product_release_2_developertask.CMN_PRO_Product_Release_RefID =
      cmn_pro_product_releases.CMN_PRO_Product_ReleaseID Inner Join
    cmn_pro_products On cmn_pro_product_releases.Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID
  Where
    (cmn_pro_product_release_2_developertask.IsDeleted = 0 Or
      cmn_pro_product_release_2_developertask.IsDeleted Is Null) And
    (cmn_pro_product_releases.IsDeleted = 0 Or
      cmn_pro_product_releases.IsDeleted Is Null) And
    (cmn_pro_products.IsDeleted = 0 Or
      cmn_pro_products.IsDeleted Is Null) And
    cmn_pro_product_release_2_developertask.Tenant_RefID = @TenantID) Revision
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    Revision.TMS_PRO_DeveloperTask_RefID Inner Join
  tms_pro_projects On tms_pro_developertasks.Project_RefID =
    tms_pro_projects.TMS_PRO_ProjectID Inner Join
  tms_pro_feature_2_developertask
    On tms_pro_developertasks.TMS_PRO_DeveloperTaskID =
    tms_pro_feature_2_developertask.DeveloperTask_RefID Inner Join
  tms_pro_feature On tms_pro_feature_2_developertask.Feature_RefID =
    tms_pro_feature.TMS_PRO_FeatureID Inner Join
  tms_pro_feature_type On tms_pro_feature.Type_RefID =
    tms_pro_feature_type.TMS_PRO_Feature_TypeID Left Join
  (Select
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID,
    Count(Distinct doc_documents.DOC_DocumentID) As DocCount
  From
    doc_document_2_structure Inner Join
    doc_documents On doc_document_2_structure.Document_RefID =
      doc_documents.DOC_DocumentID Inner Join
    tms_pro_developertasks On tms_pro_developertasks.DOC_Structure_Header_RefID
      = doc_document_2_structure.StructureHeader_RefID
  Where
    doc_documents.IsDeleted = 0 And
    doc_document_2_structure.IsDeleted = 0 And
    doc_document_2_structure.Tenant_RefID = @TenantID And
    tms_pro_developertasks.IsDeleted = 0
  Group By
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID) Documents
    On Documents.TMS_PRO_DeveloperTaskID =
    tms_pro_developertasks.TMS_PRO_DeveloperTaskID
Where
  tms_pro_developertasks.TMS_PRO_DeveloperTaskID = @DTaskIDList And
  (tms_pro_developertasks.IsArchived = 0 Or
    tms_pro_developertasks.IsArchived = @IncludeCompleted) And
  tms_pro_developertasks.IsDeleted = 0 And
  tms_pro_projects.IsDeleted = 0 And
  tms_pro_feature_type.IsDeleted = 0 And
  tms_pro_feature.IsDeleted = 0
  