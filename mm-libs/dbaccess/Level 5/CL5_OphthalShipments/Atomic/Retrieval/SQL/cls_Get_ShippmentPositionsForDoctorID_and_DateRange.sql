
Select
  hec_shippingposition_barcodelabels.HEC_ShippingPosition_BarcodeLabelID,
  hec_shippingposition_barcodelabels.ShippingPosition_BarcodeLabel,
  hec_shippingposition_barcodelabels.R_IsSubmission_Complete,
  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
  log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID,
  log_shp_shipment_headers.Creation_Timestamp As Header_Creation_Timestamp,
  log_shp_shipment_headers.IsShipped As Header_IsShipped,
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Description_DictID,
  cmn_pro_products.Product_Number,
  Submision.CMN_QST_Questionnaire_SubmissionID,
  Submision.CMN_QST_Questionnaire_SubmissionItemID,
  Submision.CMN_QST_QuestionItem_EnumerationAnswerID,
  Submision.CMN_QST_Questionnaire_ItemID,
  Submision.HEC_ShippingPosition_QuestionnaireSubmissionID,
  Submision.EnumerationAnswer_Text_DictID,
  Submision.QuestionItem_Label_DictID,
  Submision.QuestionItem_SequenceNumber
From
  hec_shippingposition_barcodelabels Inner Join
  log_shp_shipment_positions
    On hec_shippingposition_barcodelabels.LOG_SHP_Shipment_Position_RefID =
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID Inner Join
  log_shp_shipment_headers
    On log_shp_shipment_positions.LOG_SHP_Shipment_Header_RefID =
    log_shp_shipment_headers.LOG_SHP_Shipment_HeaderID Inner Join
  cmn_pro_products On log_shp_shipment_positions.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Left Join
  (Select
    cmn_qst_questionnaire_submissions.CMN_QST_Questionnaire_SubmissionID,
    cmn_qst_questionnaire_submissionitems.CMN_QST_Questionnaire_SubmissionItemID,
    hec_shippingposition_questionnairesubmissions.HEC_ShippingPosition_QuestionnaireSubmissionID,
    hec_shippingposition_questionnairesubmissions.LOG_SHP_Shipment_Position_RefID,
    hec_shippingposition_questionnairesubmissions.Doctor_RefID,
    cmn_qst_questionnaire_questionitems.CMN_QST_Questionnaire_ItemID,
    cmn_qst_questionitem_enumerationanswers.CMN_QST_QuestionItem_EnumerationAnswerID,
    cmn_qst_questionitem_enumerationanswers.EnumerationAnswer_Text_DictID,
    cmn_qst_questionnaire_questionitems.QuestionItem_Label_DictID,
    cmn_qst_questionnaire_questionitems.QuestionItem_SequenceNumber
  From
    hec_shippingposition_questionnairesubmissions Inner Join
    cmn_qst_questionnaire_submissions
      On
      hec_shippingposition_questionnairesubmissions.CMN_QST_Questionnaire_Submission_RefID = cmn_qst_questionnaire_submissions.CMN_QST_Questionnaire_SubmissionID Inner Join
    cmn_qst_questionnaire_submissionitems
      On cmn_qst_questionnaire_submissions.CMN_QST_Questionnaire_SubmissionID =
      cmn_qst_questionnaire_submissionitems.Questionnaire_Submission_RefID
    Inner Join
    cmn_qst_questionnaire_questionitems
      On cmn_qst_questionnaire_submissionitems.Questionnaire_QuestionItem_RefID
      = cmn_qst_questionnaire_questionitems.CMN_QST_Questionnaire_ItemID
    Inner Join
    cmn_qst_questionitem_enumerationanswers
      On
      cmn_qst_questionitem_enumerationanswers.CMN_QST_QuestionItem_EnumerationAnswerID = cmn_qst_questionnaire_submissionitems.IsAnswerEnum_EnumerationValue_RefID
  Where
    cmn_qst_questionnaire_submissionitems.IsAswer_Specified = 1 And
    hec_shippingposition_questionnairesubmissions.IsDeleted = 0 And
    cmn_qst_questionnaire_submissions.IsDeleted = 0 And
    cmn_qst_questionnaire_submissionitems.IsDeleted = 0 And
    cmn_qst_questionnaire_questionitems.IsDeleted = 0 And
    cmn_qst_questionitem_enumerationanswers.IsDeleted = 0) Submision
    On Submision.LOG_SHP_Shipment_Position_RefID =
    log_shp_shipment_positions.LOG_SHP_Shipment_PositionID
Where
  hec_shippingposition_barcodelabels.IsDeleted = 0 And
  log_shp_shipment_positions.IsDeleted = 0 And
  log_shp_shipment_headers.IsDeleted = 0 And
  cmn_pro_products.IsDeleted = 0 And
  hec_shippingposition_barcodelabels.Tenant_RefID = @TenantID And
  hec_shippingposition_barcodelabels.Doctor_RefID = @HEC_DoctorID And
  hec_shippingposition_barcodelabels.Creation_Timestamp >= @FormDate And
  hec_shippingposition_barcodelabels.Creation_Timestamp <= @ToDate
  