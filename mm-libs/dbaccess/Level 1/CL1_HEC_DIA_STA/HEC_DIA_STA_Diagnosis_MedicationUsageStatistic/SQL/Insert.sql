INSERT INTO 
	hec_dia_sta_diagnosis_medicationusagestatistics
	(
		HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID,
		IsHealthcareProduct,
		IfHealthcareProduct_HealthcareProduct_RefID,
		IsSubstance,
		IfSubstance_Substance_RefID,
		IfSubstance_Strength,
		DosageText,
		PotentialDiagnosis_RefID,
		NumberOfOccurences,
		IsStatistics_ForDoctor,
		IfStatistics_ForDoctor_Doctor_RefID,
		IsStatistics_ForHCG,
		IfStatistics_ForHCG_HealthcareCommunityGroup_RefID,
		StatisticsPeriod_From,
		StatisticsPeriod_Through,
		IsLatestStatisticsData,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_DIA_STA_Diagnosis_ProductUsageStatisticsID,
		@IsHealthcareProduct,
		@IfHealthcareProduct_HealthcareProduct_RefID,
		@IsSubstance,
		@IfSubstance_Substance_RefID,
		@IfSubstance_Strength,
		@DosageText,
		@PotentialDiagnosis_RefID,
		@NumberOfOccurences,
		@IsStatistics_ForDoctor,
		@IfStatistics_ForDoctor_Doctor_RefID,
		@IsStatistics_ForHCG,
		@IfStatistics_ForHCG_HealthcareCommunityGroup_RefID,
		@StatisticsPeriod_From,
		@StatisticsPeriod_Through,
		@IsLatestStatisticsData,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)