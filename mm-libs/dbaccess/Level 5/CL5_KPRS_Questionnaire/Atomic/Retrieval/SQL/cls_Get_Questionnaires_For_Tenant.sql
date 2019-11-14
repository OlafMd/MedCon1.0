
Select
  res_qst_questionnaire.RES_QST_QuestionnaireID,
  res_qst_questionnaire.Questionnaire_Name_DictID,
  res_qst_questionnaire.Questionnaire_Description_DictID,
  res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID,
  res_qst_questionnaire_version.QuestionnaireVersion_VersionNumber
From
  res_qst_questionnaire Inner Join
  res_qst_questionnaire_version
    On res_qst_questionnaire.Current_QuestionnaireVersion_RefID =
    res_qst_questionnaire_version.RES_QST_Questionnaire_VersionID
Where
  res_qst_questionnaire.IsDeleted = 0 And
  res_qst_questionnaire.Tenant_RefID = @TenantID
  