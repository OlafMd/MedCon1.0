

	SELECT
	  cast(bil_billpositions.PositionNumber as SIGNED) as PositionNumber,
	    cast(bil_billheaders.BillNumber as SIGNED) As BillID,
	  hec_patient_treatment.IfTreatmentPerformed_Date As TreatmentDate,
	  hec_patient_healthinsurances.HealthInsurance_Number,
	  hec_patient_healthinsurances.InsuranceStateCode,
	  cmn_per_personinfo.FirstName,
	  cmn_per_personinfo.LastName,
	  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
	  hec_doctors.DoctorIDNumber As LANR,
	  bil_billpositions.BillPosition_ProductNumber As GPOS,
	  bil_billpositions.Creation_Timestamp,
	  bil_billpositions.PositionValue_IncludingTax,
	  bil_billpositions.PositionValue_BeforeTax,
	  bil_billheaders.BIL_BillHeaderID,
	  bil_billpositions.BIL_BillPositionID,
	  hec_patient_treatment.HEC_Patient_TreatmentID As TreatmentID,  
	  cmn_per_personinfo.BirthDate,
	  hec_patients.HEC_PatientID As PatientID
	FROM
	  bil_billpositions
	  INNER JOIN bil_billheaders 
	    ON bil_billpositions.BIL_BilHeader_RefID = bil_billheaders.BIL_BillHeaderID  AND
	       bil_billheaders.IsDeleted = 0
	       and bil_billheaders.Tenant_RefID = @TenantID
	   INNER JOIN bil_billposition_2_patienttreatment
	    ON bil_billposition_2_patienttreatment.BIL_BillPosition_RefID = bil_billpositions.BIL_BillPositionID AND
	       bil_billposition_2_patienttreatment.IsDeleted = 0 AND 
	       bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID
	 LEFT JOIN hec_patient_treatment
	    ON hec_patient_treatment.HEC_Patient_TreatmentID = bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID AND
	       hec_patient_treatment.IsDeleted = 0 AND
	       hec_patient_treatment.IsTreatmentBilled = 1 AND 
	       hec_patient_treatment.Tenant_RefID = @TenantID
	  LEFT JOIN hec_patient_2_patienttreatment
	    ON hec_patient_treatment.HEC_Patient_TreatmentID  = hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID AND
	       hec_patient_2_patienttreatment.IsDeleted = 0 AND
	       hec_patient_2_patienttreatment.Tenant_RefID = @TenantID
	  INNER JOIN hec_patients
	    ON hec_patient_2_patienttreatment.HEC_Patient_RefID =
	         hec_patients.HEC_PatientID AND
	       hec_patients.IsDeleted = 0 AND
	       hec_patients.Tenant_RefID = @TenantID
	  INNER JOIN hec_patient_healthinsurances
	    ON hec_patients.HEC_PatientID = hec_patient_healthinsurances.Patient_RefID AND
	       hec_patient_healthinsurances.Tenant_RefID = @TenantID
	  INNER JOIN cmn_bpt_businessparticipants
	    ON hec_patients.CMN_BPT_BusinessParticipant_RefID =
	         cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID AND
	       cmn_bpt_businessparticipants.IsDeleted = 0 AND
	       cmn_bpt_businessparticipants.IsTenant = 0 AND
	       cmn_bpt_businessparticipants.IsNaturalPerson = 1 AND
	       cmn_bpt_businessparticipants.IsCompany = 0 AND
	       cmn_bpt_businessparticipants.Tenant_RefID = @TenantID
	   INNER JOIN cmn_per_personinfo
	    ON cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	         cmn_per_personinfo.CMN_PER_PersonInfoID AND
	       cmn_per_personinfo.IsDeleted = 0 AND
	       cmn_per_personinfo.Tenant_RefID = @TenantID
	  INNER JOIN hec_patient_medicalpractices
	    ON hec_patients.HEC_PatientID =
	         hec_patient_medicalpractices.HEC_Patient_RefID AND
	       hec_patient_medicalpractices.isdeleted = 0 AND
	       hec_patient_medicalpractices.Tenant_RefID = @TenantID
	 INNER JOIN hec_medicalpractises
	    ON hec_patient_medicalpractices.HEC_MedicalPractices_RefID =
	         hec_medicalpractises.HEC_MedicalPractiseID AND
	       hec_medicalpractises.isdeleted = 0 AND
	       hec_medicalpractises.Tenant_RefID = @TenantID
	  INNER JOIN cmn_com_companyinfo
	    ON hec_medicalpractises.Ext_CompanyInfo_RefID =
	         cmn_com_companyinfo.CMN_COM_CompanyInfoID AND
	       cmn_com_companyinfo.isdeleted = 0 AND
	       cmn_com_companyinfo.Tenant_RefID = @TenantID
	  LEFT JOIN hec_doctors
	    ON hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
	         hec_doctors.HEC_DoctorID AND
	       hec_doctors.IsDeleted = 0 AND
	       hec_doctors.Tenant_RefID = @TenantID
	        
	 WHERE        bil_billpositions.IsDeleted = 0 AND
	       bil_billpositions.Tenant_RefID = @TenantID
	       AND  Month(hec_patient_treatment.IfTreatmentPerformed_Date)=@SelectedMounth
	    

  