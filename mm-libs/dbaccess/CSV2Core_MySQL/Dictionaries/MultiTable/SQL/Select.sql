SELECT 
	EntryID,
	DictID,
	Language_RefID,
	Content,
	Creation_Timestamp,
	IsDeleted
FROM 
	$$TABLE$$
WHERE 
	DictID IN $$DICTID$$ AND IsDeleted = 0