UPDATE $$TABLE$$
SET
	DictID = @DictID,
	Language_RefID = @LanguageID,
	Content = @Content,
	IsDeleted = @IsDeleted
WHERE
	EntryID = @EntityID