UPDATE 
	res_realestateproperty_2_propertytype
SET 
	RES_RealestateProperty_RefID=@RES_RealestateProperty_RefID,
	RES_RealestateProperty_Type_RefID=@RES_RealestateProperty_Type_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID