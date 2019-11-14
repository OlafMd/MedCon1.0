UPDATE 
	hec_dia_sta_diagnosis_referralusagestatistics
SET 
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	ReferredTo_MedicalPractice_RefID=@ReferredTo_MedicalPractice_RefID,
	NumberOfOccurences=@NumberOfOccurences,
	IsStatistics_ForDoctor=@IsStatistics_ForDoctor,
	IfStatistics_ForDoctor_Doctor_RefID=@IfStatistics_ForDoctor_Doctor_RefID,
	IsStatistics_ForHCG=@IsStatistics_ForHCG,
	IfStatistics_ForHCG_HealthcareCommunityGroup_RefID=@IfStatistics_ForHCG_HealthcareCommunityGroup_RefID,
	StatisticsPeriod_From=@StatisticsPeriod_From,
	StatisticsPeriod_Through=@StatisticsPeriod_Through,
	IsLatestStatisticsData=@IsLatestStatisticsData,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_STA_Diagnosis_ReferralUsageStatisticsID = @HEC_DIA_STA_Diagnosis_ReferralUsageStatisticsID