UPDATE 
	cmn_qst_questionitem_enumerationanswers
SET 
	EnumerationAnswerType_RefID=@EnumerationAnswerType_RefID,
	EnumerationAnswer_Text_DictID=@EnumerationAnswer_Text,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_QST_QuestionItem_EnumerationAnswerID = @CMN_QST_QuestionItem_EnumerationAnswerID