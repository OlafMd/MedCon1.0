
	Select
	  hec_medicalpractice_types.MedicalPracticeType_Name_DictID,
	  hec_medicalpractice_types.HEC_MedicalPractice_TypeID As id,
	  hec_medicalpractises.HEC_MedicalPractiseID
	From
	  hec_medicalpractice_types Inner Join
	  hec_medicalpractice_2_practicetype
	    On hec_medicalpractice_types.HEC_MedicalPractice_TypeID =
	    hec_medicalpractice_2_practicetype.HEC_MedicalPractice_Type_RefID And
	    hec_medicalpractice_2_practicetype.IsDeleted = 0 And
	    hec_medicalpractice_2_practicetype.Tenant_RefID = @TenantID Inner Join
	  hec_medicalpractises
	    On hec_medicalpractice_2_practicetype.HEC_MedicalPractice_RefID =
	    hec_medicalpractises.HEC_MedicalPractiseID And
	    hec_medicalpractises.IsHospital = 0 And hec_medicalpractises.IsDeleted = 0
	    And hec_medicalpractises.Tenant_RefID = @TenantID
	Where
	  hec_medicalpractice_types.Tenant_RefID = @TenantID And
	  hec_medicalpractice_types.IsDeleted = 0
  