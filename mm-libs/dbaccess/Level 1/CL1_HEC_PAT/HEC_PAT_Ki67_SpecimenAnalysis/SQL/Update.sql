UPDATE 
	hec_pat_ki67_specimenanalysis
SET 
	Analysis_Name=@Analysis_Name,
	AnalysisPersistedBy_Account_RefID=@AnalysisPersistedBy_Account_RefID,
	Specimen_RefID=@Specimen_RefID,
	AnalysisResults=@AnalysisResults,
	CellMap_Document_RefID=@CellMap_Document_RefID,
	MarkupNoFill_Document_RefID=@MarkupNoFill_Document_RefID,
	MarkupFill_Document_RefID=@MarkupFill_Document_RefID,
	IsReportCreated=@IsReportCreated,
	IfReportCreated_Report_Document_RefID=@IfReportCreated_Report_Document_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_PAT_Ki67_SpecimenAnalysisID = @HEC_PAT_Ki67_SpecimenAnalysisID