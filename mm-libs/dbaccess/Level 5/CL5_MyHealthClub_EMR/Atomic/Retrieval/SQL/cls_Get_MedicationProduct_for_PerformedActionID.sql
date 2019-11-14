
Select
  hec_act_performedaction_medicationupdates.HEC_ACT_PerformedAction_MedicationUpdateID,
  hec_patient_medications.HEC_Patient_MedicationID,
  hec_act_performedaction_medicationupdates.DosageText,
  hec_products.HEC_ProductID,
  hec_act_performedaction_medicationupdates.MedicationUpdateComment,
  hec_act_performedaction_medicationupdates.Relevant_PatientDiagnosis_RefID,
  hec_act_performedaction_medicationupdates.IntendedApplicationDuration_in_days,
  cmn_pro_products.Product_Name_DictID,
  hec_product_dosageforms.HEC_Product_DosageFormID,
  hec_product_dosageforms.DosageForm_Name_DictID,
  hec_act_performedaction_medicationupdates.IsMedicationDeactivated
From
  hec_act_performedaction_medicationupdates Inner Join
  hec_patient_medications
    On hec_act_performedaction_medicationupdates.HEC_Patient_Medication_RefID =
    hec_patient_medications.HEC_Patient_MedicationID Inner Join
  hec_products
    On hec_products.HEC_ProductID =
    hec_act_performedaction_medicationupdates.HEC_Product_RefID Inner Join
  cmn_pro_products On hec_products.Ext_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  hec_product_dosageforms On hec_product_dosageforms.HEC_Product_DosageFormID =
    hec_products.ProductDosageForm_RefID
Where
  hec_act_performedaction_medicationupdates.HEC_ACT_PerformedAction_RefID =
  @PerformedActionID And
  hec_act_performedaction_medicationupdates.Tenant_RefID = @TenantID And
  hec_act_performedaction_medicationupdates.IsDeleted = 0 And
  hec_act_performedaction_medicationupdates.IsHealthcareProduct = 1
Order By
  hec_act_performedaction_medicationupdates.Creation_Timestamp Desc
  