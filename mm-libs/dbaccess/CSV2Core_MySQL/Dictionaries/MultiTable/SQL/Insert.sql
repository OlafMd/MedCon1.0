INSERT INTO $$TABLE$$
( 
	EntryID,
	DictID,
	Language_RefID,
	Content,
	Creation_Timestamp,
	IsDeleted
)
VALUES
(
	@EntityID,
	@DictID,
	@LanguageID,
	@Content,
	@Creation_Timestamp,
	@IsDeleted
)