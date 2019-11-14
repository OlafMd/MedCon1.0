UPDATE 
	cmn_qst_questionnaire_questionitems
SET 
	Questionnaire_Template_RefID=@Questionnaire_Template_RefID,
	QuestionItem_Label_DictID=@QuestionItem_Label,
	QuestionItem_Description_DictID=@QuestionItem_Description,
	QuestionItem_SequenceNumber=@QuestionItem_SequenceNumber,
	IsAnswer_Standard=@IsAnswer_Standard,
	IfAnswer_StandardType_RefID=@IfAnswer_StandardType_RefID,
	IsAnswer_Enum=@IsAnswer_Enum,
	IfAnswer_EnumType_RefID=@IfAnswer_EnumType_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_QST_Questionnaire_ItemID = @CMN_QST_Questionnaire_ItemID