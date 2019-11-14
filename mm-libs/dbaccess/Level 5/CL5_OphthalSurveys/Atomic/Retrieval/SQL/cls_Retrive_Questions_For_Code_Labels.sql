

		Select
		  cmn_pro_product_questionnaire_assignment.IsActive,
		  cmn_qst_questionnaire_questionitems.QuestionItem_Label_DictID,
		  cmn_qst_questionnaire_questionitems.QuestionItem_SequenceNumber,
		  cmn_qst_questionnaire_template_versions.CMN_QST_Questionnaire_Template_VersionID,
		  cmn_qst_questionnaire_questionitems.CMN_QST_Questionnaire_ItemID,
		  cmn_qst_questionitem_enumerationanswertypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID,
		  hec_shippingposition_barcodelabels.HEC_ShippingPosition_BarcodeLabelID,
		  log_shp_shipment_positions.LOG_SHP_Shipment_PositionID,
		  log_shp_shipment_positions.CMN_PRO_Product_RefID,
		  log_shp_shipment_positions.CMN_PRO_ProductVariant_RefID,
		  hec_shippingposition_barcodelabels.LOG_SHP_Shipment_Position_RefID,
		  hec_shippingposition_barcodelabels.Bound_QuestionnaireTemplateVersion_RefID,
		  cmn_pro_products.CMN_PRO_ProductID,
		  cmn_pro_products.Product_Name_DictID,
		  cmn_pro_product_questionnaire_assignment.CMN_PRO_Product_Questionnaire_AssignmentID,
		  cmn_pro_product_questionnaire_assignment.CMN_PRO_Product_RefID As
		  CMN_PRO_Product_RefID1,
		  cmn_pro_product_questionnaire_assignment.CMN_QST_Questionnaire_Template_Version_RefID,
		  cmn_qst_questionnaire_template_versions.QuestionnaireTemplate_RefID,
		  cmn_qst_questionnaire_template_versions.CopiedFrom_TemplateVersion_RefID,
		  cmn_qst_questionitem_enumerationanswers.CMN_QST_QuestionItem_EnumerationAnswerID,
		  cmn_qst_questionitem_enumerationanswers.EnumerationAnswer_Text_DictID,
		  hec_shippingposition_barcodelabels.ShippingPosition_BarcodeLabel
		From
		  cmn_pro_products Inner Join
		  log_shp_shipment_positions On log_shp_shipment_positions.CMN_PRO_Product_RefID
		    = cmn_pro_products.CMN_PRO_ProductID Inner Join
		  cmn_pro_product_questionnaire_assignment On cmn_pro_products.CMN_PRO_ProductID
		    = cmn_pro_product_questionnaire_assignment.CMN_PRO_Product_RefID Inner Join
		  cmn_qst_questionnaire_template_versions
		    On
		    cmn_pro_product_questionnaire_assignment.CMN_QST_Questionnaire_Template_Version_RefID = cmn_qst_questionnaire_template_versions.CMN_QST_Questionnaire_Template_VersionID Inner Join
		  cmn_qst_questionnaire_questionitems
		    On cmn_qst_questionnaire_questionitems.Questionnaire_Template_RefID =
		    cmn_qst_questionnaire_template_versions.CMN_QST_Questionnaire_Template_VersionID Inner Join
		  cmn_qst_questionitem_enumerationanswertypes
		    On cmn_qst_questionnaire_questionitems.IfAnswer_EnumType_RefID =
		    cmn_qst_questionitem_enumerationanswertypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID Inner Join
		  hec_shippingposition_barcodelabels
		    On log_shp_shipment_positions.LOG_SHP_Shipment_PositionID =
		    hec_shippingposition_barcodelabels.LOG_SHP_Shipment_Position_RefID
		  Inner Join
		  cmn_qst_questionitem_enumerationanswers
		    On
		    cmn_qst_questionitem_enumerationanswertypes.CMN_QST_QuestionItem_EnumerationAnswerTypeID = cmn_qst_questionitem_enumerationanswers.CMN_QST_QuestionItem_EnumerationAnswerID
		Where
		  cmn_pro_product_questionnaire_assignment.IsActive = 1 And
		  hec_shippingposition_barcodelabels.ShippingPosition_BarcodeLabel =
		  @barcodeLabel And
		  cmn_qst_questionnaire_questionitems.IsDeleted = 0 And
		  cmn_qst_questionnaire_template_versions.IsDeleted = 0 And
		  cmn_pro_products.IsDeleted = 0 And
		  cmn_pro_product_questionnaire_assignment.IsDeleted = 0 And
		  log_shp_shipment_positions.IsDeleted = 0 And
		  hec_shippingposition_barcodelabels.IsDeleted = 0 And
		  cmn_qst_questionitem_enumerationanswertypes.IsDeleted = 0
	  

  