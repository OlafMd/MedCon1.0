
Select
  hec_patient_treatment.IsTreatmentPerformed,
  hec_patient_treatment.IfTreatmentPerformed_Date,
  hec_patient_treatment.IsTreatmentFollowup,
  hec_patient_treatment.IsScheduled,
  hec_patient_treatment.IfSheduled_Date,
  hec_patient_treatment.IsTreatmentBilled,
  hec_patient_treatment.IfTreatmentBilled_Date,
  Article.CMN_PRO_ProductID,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  Article.HEC_Patient_Treatment_RefID,
  Article.Product_Name_DictID,
  RequiredProducts.BoundTo_CustomerOrderPosition_RefID,
  RequiredProducts.HEC_Patient_Treatment_RequiredProductID,
  hec_patient_treatment_ocularextension.IsTreatmentOfLeftEye,
  hec_patient_treatment_ocularextension.IsTreatmentOfRightEye,
  Article.Quantity,
  Article.Product_Number,
  FollowUp.FollowUp_ID,
  FollowUp.IfFollowUpSheduled_Date,
  FollowUp.IsFollowUPPerformed,
  FollowUp.IfFollowUpPerformed_Date,
  FollowUp.Followup_PracticeID,
  FollowUp.Followup_Performed_by_DoctorID,
  hec_patient_treatment.TreatmentPractice_RefID As Treatment_PracticeID,
  hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID As
  Treatment_Performed_by_DoctorID,
  Article.ExpectedDateOfDelivery,
  Article.PharmacyID,
  Article.Status_Name_DictID,
  Article.ArticleDate,
  FollowUp.Followup_Scheduled_for_DoctorID
From
  hec_patient_treatment Inner Join
  hec_patient_2_patienttreatment
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_2_patienttreatment.HEC_Patient_Treatment_RefID Inner Join
  hec_patients
    On hec_patients.HEC_PatientID =
    hec_patient_2_patienttreatment.HEC_Patient_RefID Left Join
  (Select
    cmn_pro_products.Product_Name_DictID,
    cmn_pro_products.CMN_PRO_ProductID,
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
    hec_patient_treatment_requiredproducts.Quantity,
    cmn_pro_products.Product_Number,
    hec_patient_treatment_requiredproducts.ExpectedDateOfDelivery,
    hec_patient_treatment_requiredproducts.ProductProvidingPharmacy_RefID As
    PharmacyID,
    ord_cuo_customerorder_statuses.Status_Name_DictID,
    ord_cuo_customerorder_positions.Position_RequestedDateOfDelivery As
    ArticleDate
  From
    hec_patient_treatment_requiredproducts Inner Join
    hec_products On hec_patient_treatment_requiredproducts.HEC_Product_RefID =
      hec_products.HEC_ProductID Inner Join
    cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
      cmn_pro_products.CMN_PRO_ProductID Left Join
    ord_cuo_customerorder_positions
      On
      hec_patient_treatment_requiredproducts.BoundTo_CustomerOrderPosition_RefID
      = ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID And
      ord_cuo_customerorder_positions.IsDeleted = 0 Left Join
    ord_cuo_customerorder_headers
      On ord_cuo_customerorder_positions.CustomerOrder_Header_RefID =
      ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID And
      ord_cuo_customerorder_headers.IsDeleted = 0 Left Join
    ord_cuo_customerorder_statushistory
      On ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID =
      ord_cuo_customerorder_statushistory.CustomerOrder_Header_RefID And
      ord_cuo_customerorder_statushistory.IsDeleted = 0 Left Join
    ord_cuo_customerorder_statuses
      On ord_cuo_customerorder_statushistory.CustomerOrder_Status_RefID =
      ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID And
      ord_cuo_customerorder_statuses.IsDeleted = 0
  Where
    hec_patient_treatment_requiredproducts.IsDeleted = 0 And
    hec_products.IsDeleted = 0 And
    cmn_pro_products.IsDeleted = 0) Article
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    Article.HEC_Patient_Treatment_RefID Left Join
  (Select
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID,
    hec_patient_treatment_requiredproducts.BoundTo_CustomerOrderPosition_RefID,
    hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RequiredProductID
  From
    hec_patient_treatment_requiredproducts
  Where
    hec_patient_treatment_requiredproducts.IsDeleted = 0) RequiredProducts
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    RequiredProducts.HEC_Patient_Treatment_RefID Left Join
  hec_patient_treatment_ocularextension
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    hec_patient_treatment_ocularextension.HEC_Patient_Treatment_RefID And
    hec_patient_treatment_ocularextension.IsDeleted = 0 Left Join
  (Select
    hec_patient_treatment.HEC_Patient_TreatmentID As FollowUp_ID,
    hec_patient_treatment.IfSheduled_Date As IfFollowUpSheduled_Date,
    hec_patient_treatment.IsTreatmentPerformed As IsFollowUPPerformed,
    hec_patient_treatment.IfTreatmentFollowup_FromTreatment_RefID,
    hec_patient_treatment.IfTreatmentPerformed_Date As IfFollowUpPerformed_Date,
    hec_patient_treatment.TreatmentPractice_RefID As Followup_PracticeID,
    hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID As
    Followup_Performed_by_DoctorID,
    hec_patient_treatment.IfSheduled_ForDoctor_RefID As
    Followup_Scheduled_for_DoctorID
  From
    hec_patient_treatment
  Where
    hec_patient_treatment.IsDeleted = 0 And
    hec_patient_treatment.IsTreatmentFollowup = 1 And
    hec_patient_treatment.Tenant_RefID = @TenantID) FollowUp
    On hec_patient_treatment.HEC_Patient_TreatmentID =
    FollowUp.IfTreatmentFollowup_FromTreatment_RefID
Where
  hec_patients.HEC_PatientID = @PatientID And
  hec_patients.IsDeleted = 0 And
  hec_patients.Tenant_RefID = @TenantID And
  hec_patient_2_patienttreatment.IsDeleted = 0 And
  hec_patient_treatment.IsDeleted = 0
  