UPDATE 
	hec_cas_cases
SET 
	Patient_RefID=@Patient_RefID,
	CreatedBy_BusinessParticipant_RefID=@CreatedBy_BusinessParticipant_RefID,
	CaseNumber=@CaseNumber,
	CaseTitle_DictID=@CaseTitle,
	CaseDescription_DictID=@CaseDescription,
	IsClosed=@IsClosed,
	IsSolved=@IsSolved,
	Patient_FirstName=@Patient_FirstName,
	Patient_LastName=@Patient_LastName,
	Patient_Gender=@Patient_Gender,
	Patient_Age=@Patient_Age,
	Patient_BirthDate=@Patient_BirthDate,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_CaseID = @HEC_CAS_CaseID