
	Select
	  bil_billposition_transmitionstatuses.TransmitionCode As TCode,
	  Cast(bil_billpositions.External_PositionReferenceField As SIGNED) As
	  PositionNumber,
	  Cast(bil_billheaders.BillNumber As SIGNED) As BillID,
	  hec_patient_treatment.IfTreatmentPerformed_Date As TreatmentDate,
	  hec_patient_healthinsurances.HealthInsurance_Number,
	  hec_patient_healthinsurances.InsuranceStateCode,
	  cmn_per_personinfo.FirstName As PatientFirstName,
	  cmn_per_personinfo.LastName As PatientLastName,
	  cmn_com_companyinfo.CompanyInfo_EstablishmentNumber As BSNR,
	  hec_doctors.DoctorIDNumber As LANR,
	  bil_billpositions.External_PositionCode As GPOS,
	  bil_billpositions.PositionValue_IncludingTax,
	  cmn_per_personinfo.BirthDate,
	  hec_patients.HEC_PatientID As PatientID,
	  hec_patient_treatment.IsTreatmentBilled,
	  doctor_personInfo.FirstName As DoctorFirstName,
	  doctor_personInfo.LastName As DoctorLastName,
	  doctor_personInfo.Title As DoctorsTitle,
	  hec_patient_treatment.HEC_Patient_TreatmentID,
	  bil_billposition_transmitionstatuses.TransmittedOnDate,
	  bil_billposition_transmitionstatuses.SecondaryComment As AOKComment,
	  bil_billpositions.External_PositionType,
	  bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID,
	  bil_billpositions.BIL_BillPositionID,
	  bil_billposition_transmitionstatuses.PrimaryComment,
	  bil_billposition_transmitionstatuses.IsActive,
	  bil_billposition_transmitionstatuses.IsDeleted
	From
	  hec_patient_treatment Left Join
	  hec_patient_2_patienttreatment
	    On hec_patient_treatment.HEC_Patient_TreatmentID =
	    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID And
	    hec_patient_2_patienttreatment.IsDeleted = 0 And
	    hec_patient_2_patienttreatment.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
	    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
	    hec_patients.Tenant_RefID = 0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  hec_patient_healthinsurances On hec_patients.HEC_PatientID =
	    hec_patient_healthinsurances.Patient_RefID And
	    hec_patient_healthinsurances.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
	    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants.IsDeleted = 0 And
	    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
	    cmn_bpt_businessparticipants.IsCompany = 0 And
	    cmn_bpt_businessparticipants.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  cmn_per_personinfo
	    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
	    And cmn_per_personinfo.Tenant_RefID = 0xc7b0fb86d661e24f8b8d4e1191614ec0
	  Inner Join
	  hec_patient_medicalpractices On hec_patients.HEC_PatientID =
	    hec_patient_medicalpractices.HEC_Patient_RefID And
	    hec_patient_medicalpractices.IsDeleted = 0 And
	    hec_patient_medicalpractices.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  hec_medicalpractises
	    On hec_patient_medicalpractices.HEC_MedicalPractices_RefID =
	    hec_medicalpractises.HEC_MedicalPractiseID And
	    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
	    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
	    = 0 And cmn_com_companyinfo.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Left Join
	  hec_doctors On hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
	    hec_doctors.HEC_DoctorID And hec_doctors.IsDeleted = 0 And
	    hec_doctors.Tenant_RefID = 0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  cmn_bpt_businessparticipants cmn_bpt_businessparticipants1
	    On hec_doctors.BusinessParticipant_RefID =
	    cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And
	    cmn_bpt_businessparticipants1.IsDeleted = 0 And
	    cmn_bpt_businessparticipants1.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Inner Join
	  cmn_per_personinfo doctor_personInfo
	    On cmn_bpt_businessparticipants1.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
	    doctor_personInfo.CMN_PER_PersonInfoID And doctor_personInfo.IsDeleted = 0
	    And doctor_personInfo.Tenant_RefID = 0xc7b0fb86d661e24f8b8d4e1191614ec0
	  Left Join
	  bil_billposition_2_patienttreatment
	    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
	    hec_patient_treatment.HEC_Patient_TreatmentID And
	    bil_billposition_2_patienttreatment.IsDeleted = 0 And
	    bil_billposition_2_patienttreatment.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Left Join
	  bil_billpositions On bil_billpositions.BIL_BillPositionID =
	    bil_billposition_2_patienttreatment.BIL_BillPosition_RefID And
	    bil_billpositions.IsDeleted = 0 And bil_billpositions.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0 Left Join
	  bil_billheaders On bil_billpositions.BIL_BilHeader_RefID =
	    bil_billheaders.BIL_BillHeaderID And bil_billheaders.IsDeleted = 0
	    And bil_billheaders.Tenant_RefID = 0xc7b0fb86d661e24f8b8d4e1191614ec0
	  Left Join
	  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
	    bil_billposition_transmitionstatuses.BillPosition_RefID And
	    bil_billposition_transmitionstatuses.IsDeleted = 0 And
	    bil_billposition_transmitionstatuses.IsActive = 1 And
	    bil_billposition_transmitionstatuses.Tenant_RefID =
	    0xc7b0fb86d661e24f8b8d4e1191614ec0
	Where
	  hec_patient_treatment.IsDeleted = 0 And
	  hec_patient_treatment.Tenant_RefID = @TenantID
  