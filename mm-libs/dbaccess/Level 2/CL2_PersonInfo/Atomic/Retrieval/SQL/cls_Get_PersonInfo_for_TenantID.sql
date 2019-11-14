
	SELECT CMN_PER_PersonInfoID,
	       FirstName,
	       LastName,
	       PrimaryEmail,
	       Title,
	       ProfileImage_Document_RefID,
	       BirthDate,
	       Address_RefID,
	       Salutation_General,
	       Salutation_Letter,
	       Gender
	  FROM cmn_per_personinfo
	where IsDeleted = 0 and Tenant_RefID = @TenantID
  