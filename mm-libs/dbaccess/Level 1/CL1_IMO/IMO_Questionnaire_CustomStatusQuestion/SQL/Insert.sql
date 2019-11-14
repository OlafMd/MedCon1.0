INSERT INTO 
	imo_questionnaire_customstatusquestions
	(
		IMO_Questionnaire_CustomStatusQuestionID,
		CustomStatusQuestionGroup_RefID,
		QuestionText_DictID,
		SequenceNumber,
		IsAnswerBoolean,
		IsAnswerNumber,
		IsAnswerText,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_Questionnaire_CustomStatusQuestionID,
		@CustomStatusQuestionGroup_RefID,
		@QuestionText,
		@SequenceNumber,
		@IsAnswerBoolean,
		@IsAnswerNumber,
		@IsAnswerText,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)