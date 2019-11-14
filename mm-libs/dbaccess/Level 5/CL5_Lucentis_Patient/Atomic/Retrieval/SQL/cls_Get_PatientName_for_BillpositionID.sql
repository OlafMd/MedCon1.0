
	Select
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName
	From
	  bil_billpositions Inner Join
	  bil_billposition_2_patienttreatment On bil_billpositions.BIL_BillPositionID =
	    bil_billposition_2_patienttreatment.BIL_BillPosition_RefID And
	  bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID And
	    bil_billposition_2_patienttreatment.IsDeleted = 0 Inner Join
	  hec_patient_treatment
	    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
	    hec_patient_treatment.HEC_Patient_TreatmentID And
	    hec_patient_treatment.IsDeleted = 0 And
	    hec_patient_treatment.IsTreatmentBilled = 1 And
	    hec_patient_treatment.IsTreatmentFollowup = 0 And
	    hec_patient_treatment.Tenant_RefID = @TenantID Inner Join
	  hec_patient_2_patienttreatment
	    On hec_patient_treatment.HEC_Patient_TreatmentID =
	    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID And
	    hec_patient_2_patienttreatment.IsDeleted = 0 And
	    hec_patient_2_patienttreatment.Tenant_RefID = @TenantID  Inner Join
	  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
	    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And 
	    hec_patients.Tenant_RefID = @TenantID Inner Join
	  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
	    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0   
	    And cmn_per_personinfo.Tenant_RefID = @TenantID
	Where
	  bil_billpositions.IsDeleted = 0 And
	  bil_billpositions.Tenant_RefID = @TenantID And
      bil_billpositions.BIL_BillPositionID = @BillPositionID
  