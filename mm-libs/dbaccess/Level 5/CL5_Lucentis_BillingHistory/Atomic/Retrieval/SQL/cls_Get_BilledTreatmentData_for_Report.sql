
	
Select
  bil_billposition_transmitionstatuses.TransmitionCode As TCode,
  Cast(bil_billpositions.External_PositionReferenceField As SIGNED) As
  VorgangsNumber,
  hec_patient_treatment.IfTreatmentPerformed_Date As TreatmentDate,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  bil_billpositions.External_PositionCode As GPOS,
  bil_billpositions.Creation_Timestamp,
  bil_billpositions.PositionValue_IncludingTax,
  bil_billpositions.BIL_BillPositionID,
  cmn_per_personinfo.BirthDate,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  bil_billpositions.External_PositionType,
  hec_patient_treatment.TreatmentPractice_RefID,
  Products.CMN_PRO_ProductID,
  Products.Product_Name_DictID
From
  hec_patient_treatment Left Join
  hec_patient_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID And
    hec_patient_2_patienttreatment.IsDeleted = 0 And
    hec_patient_2_patienttreatment.Tenant_RefID = @TenantID Inner Join
  hec_patients On hec_patient_2_patienttreatment.HEC_Patient_RefID =
    hec_patients.HEC_PatientID And hec_patients.IsDeleted = 0 And
    hec_patients.Tenant_RefID = @TenantID Inner Join
  hec_patient_healthinsurances On hec_patients.HEC_PatientID =
    hec_patient_healthinsurances.Patient_RefID And
    hec_patient_healthinsurances.Tenant_RefID = @TenantID Inner Join
  cmn_bpt_businessparticipants On hec_patients.CMN_BPT_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID Inner Join
  cmn_per_personinfo
    On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID =
    cmn_per_personinfo.CMN_PER_PersonInfoID And cmn_per_personinfo.IsDeleted = 0
    And cmn_per_personinfo.Tenant_RefID = @TenantID Inner Join
  hec_patient_medicalpractices On hec_patients.HEC_PatientID =
    hec_patient_medicalpractices.HEC_Patient_RefID And
    hec_patient_medicalpractices.IsDeleted = 0 And
    hec_patient_medicalpractices.Tenant_RefID = @TenantID Inner Join
  hec_medicalpractises
    On hec_patient_medicalpractices.HEC_MedicalPractices_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID And
    hec_medicalpractises.IsDeleted = 0 And hec_medicalpractises.Tenant_RefID =
    @TenantID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Left Join
  bil_billposition_2_patienttreatment
    On bil_billposition_2_patienttreatment.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID And
    bil_billposition_2_patienttreatment.IsDeleted = 0 And
    bil_billposition_2_patienttreatment.Tenant_RefID = @TenantID Left Join
  bil_billpositions On bil_billpositions.BIL_BillPositionID =
    bil_billposition_2_patienttreatment.BIL_BillPosition_RefID And
    bil_billpositions.IsDeleted = 0 And bil_billpositions.Tenant_RefID =
    @TenantID Inner Join
  bil_billposition_transmitionstatuses On bil_billpositions.BIL_BillPositionID =
    bil_billposition_transmitionstatuses.BillPosition_RefID And
    bil_billposition_transmitionstatuses.IsDeleted = 0 And
    bil_billposition_transmitionstatuses.IsActive = 1 And
    bil_billposition_transmitionstatuses.Tenant_RefID =@TenantID Left Join
  (Select
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_products.CMN_PRO_ProductID
  From
    hec_patient_treatment_requiredproducts Inner Join
    hec_products On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
      hec_products.HEC_ProductID Inner Join
    cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID) Products
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    Products.HEC_Patient_Treatment_RefID
Where
  hec_patient_treatment.HEC_Patient_TreatmentID = @TreatmentID And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment.Tenant_RefID = @TenantID And
  hec_patient_treatment.IsTreatmentBilled = 1 

  