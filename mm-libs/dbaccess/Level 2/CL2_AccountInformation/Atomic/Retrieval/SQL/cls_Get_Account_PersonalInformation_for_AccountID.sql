
	Select
  usr_accounts.USR_AccountID,
  usr_accounts.Username,
  usr_accounts.AccountSignInEmailAddress,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_languages.CMN_LanguageID,
  cmn_languages.ISO_639_2,
  ProfileImage.File_SourceLocation,
  ProfileImage.File_ServerLocation,
  usr_accounts.AccountType,
  cmn_per_personinfo.PrimaryEmail,
  cmn_per_personinfo.Title,
  cmn_per_personinfo.BirthDate,
  cmn_per_personinfo.Salutation_General,
  cmn_per_personinfo.Salutation_Letter,
  cmn_per_personinfo.Gender
From
  usr_accounts Inner Join
  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
    = usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo On cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID Left Join
  cmn_languages On usr_accounts.DefaultLanguage_RefID =
    cmn_languages.CMN_LanguageID Left Join
  (Select
    doc_documents.DOC_DocumentID,
    doc_documentrevisions.File_SourceLocation,
    doc_documentrevisions.File_ServerLocation
  From
    doc_documents Inner Join
    doc_documentrevisions On doc_documents.DOC_DocumentID =
      doc_documentrevisions.Document_RefID
  Where
    doc_documents.IsDeleted = 0 And
    doc_documents.Tenant_RefID = @TenantID And
    doc_documentrevisions.IsDeleted = 0 And
    doc_documentrevisions.IsLastRevision = 1) ProfileImage
    On cmn_per_personinfo.ProfileImage_Document_RefID =
    ProfileImage.DOC_DocumentID
Where
  usr_accounts.USR_AccountID = @AccountRefID And
  usr_accounts.IsDeleted = 0 And
  cmn_per_personinfo_2_account.IsDeleted = 0 And
  cmn_per_personinfo.IsDeleted = 0

  