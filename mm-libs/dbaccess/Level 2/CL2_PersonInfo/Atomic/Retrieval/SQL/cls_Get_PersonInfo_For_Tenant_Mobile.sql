
	Select
  cmn_per_personinfo.NumberOfChildren,
  cmn_per_personinfo.Gender,
  cmn_per_personinfo.Salutation_Letter,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Tenant_RefID,
  cmn_per_personinfo.IsDeleted,
  cmn_per_personinfo.Creation_Timestamp,
  cmn_per_personinfo.Address_RefID,
  cmn_per_personinfo.BirthDate,
  cmn_per_personinfo.ProfileImage_Document_RefID,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.CMN_PER_PersonInfoID
From
  cmn_per_personinfo
Where
  cmn_per_personinfo.Tenant_RefID = @TenantID And
  cmn_per_personinfo.IsDeleted = 0
  