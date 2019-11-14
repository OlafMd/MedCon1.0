UPDATE 
	imo_questionnaire_customstatusquestions
SET 
	CustomStatusQuestionGroup_RefID=@CustomStatusQuestionGroup_RefID,
	QuestionText_DictID=@QuestionText,
	SequenceNumber=@SequenceNumber,
	IsAnswerBoolean=@IsAnswerBoolean,
	IsAnswerNumber=@IsAnswerNumber,
	IsAnswerText=@IsAnswerText,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_CustomStatusQuestionID = @IMO_Questionnaire_CustomStatusQuestionID