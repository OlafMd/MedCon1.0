UPDATE 
	cmn_qst_questionitem_standardanswertypes
SET 
	IsBoolean=@IsBoolean,
	IsNumber=@IsNumber,
	IfNumber_IsInteger=@IfNumber_IsInteger,
	IfNumber_Min_Inclusive=@IfNumber_Min_Inclusive,
	IfNumber_Max_Exclusive=@IfNumber_Max_Exclusive,
	IsShortText=@IsShortText,
	IfShortText_MaxLength=@IfShortText_MaxLength,
	IsLongText=@IsLongText,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_QST_QuestionItem_StandardAnswerTypeID = @CMN_QST_QuestionItem_StandardAnswerTypeID