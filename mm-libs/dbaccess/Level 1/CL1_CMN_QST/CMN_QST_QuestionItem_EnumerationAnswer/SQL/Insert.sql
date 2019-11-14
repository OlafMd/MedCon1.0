INSERT INTO 
	cmn_qst_questionitem_enumerationanswers
	(
		CMN_QST_QuestionItem_EnumerationAnswerID,
		EnumerationAnswerType_RefID,
		EnumerationAnswer_Text_DictID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_QST_QuestionItem_EnumerationAnswerID,
		@EnumerationAnswerType_RefID,
		@EnumerationAnswer_Text,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)