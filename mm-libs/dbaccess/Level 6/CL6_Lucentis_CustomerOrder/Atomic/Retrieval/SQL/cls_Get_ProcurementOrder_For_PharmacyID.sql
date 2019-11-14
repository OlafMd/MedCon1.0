
Select
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RequiredProductID,
  cmn_com_companyinfo.CMN_COM_CompanyInfoID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  hec_patient_treatment_requiredproducts.ExpectedDateOfDelivery,
  DoctorPerformed.DoctorFirstName,
  DoctorPerformed.DoctorLastname,
  DoctorPerformed.DoctorTitle,
  Doctor.DoctorFirstNameScheduled,
  Doctor.DoctorLastnameScheduled,
  Doctor.DoctorTitleScheduled,
  ord_prc_procurementorder_statuses.GlobalPropertyMatchingID As
  GlobalPropertyMatchingID1,
  ord_prc_procurementorder_statuses.Status_Code As Status_Code1,
  ord_prc_procurementorder_statuses.Status_Name_DictID As Status_Name_DictID1,
  ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID,
  ord_prc_procurementorder_positions.Position_OrdinalNumber As
  Position_OrdinalNumber1,
  ord_prc_procurementorder_positions.Position_Quantity As Position_Quantity1,
  ord_prc_procurementorder_positions.Position_ValuePerUnit As
  Position_ValuePerUnit1,
  ord_prc_procurementorder_positions.Position_ValueTotal As
  Position_ValueTotal1,
  ord_prc_procurementorder_positions.Position_Comment As Position_Comment1,
  ord_prc_procurementorder_positions.Position_RequestedDateOfDelivery As
  Position_RequestedDateOfDelivery1,
  ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID,
  ord_prc_procurementorder_headers.ProcurementOrder_Number,
  ord_prc_procurementorder_headers.ProcurementOrder_Date,
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
From
  hec_patient_treatment_requiredproducts Inner Join
  hec_patient_treatment
    On hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Left Join
  (Select
    cmn_per_personinfo.FirstName As DoctorFirstName,
    cmn_per_personinfo.LastName As DoctorLastname,
    cmn_per_personinfo.Title As DoctorTitle,
    hec_doctors.HEC_DoctorID
  From
    cmn_per_personinfo Inner Join
    cmn_bpt_businessparticipants On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    Inner Join
    hec_doctors On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    hec_doctors.IsDeleted = 0) DoctorPerformed
    On hec_patient_treatment.IfTreatmentPerformed_ByDoctor_RefID =
    DoctorPerformed.HEC_DoctorID Left Join
  (Select
    cmn_per_personinfo.FirstName As DoctorFirstNameScheduled,
    cmn_per_personinfo.LastName As DoctorLastnameScheduled,
    cmn_per_personinfo.Title As DoctorTitleScheduled,
    hec_doctors.HEC_DoctorID
  From
    cmn_per_personinfo Inner Join
    cmn_bpt_businessparticipants On cmn_per_personinfo.CMN_PER_PersonInfoID =
      cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID
    Inner Join
    hec_doctors On hec_doctors.BusinessParticipant_RefID =
      cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
  Where
    cmn_per_personinfo.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsDeleted = 0 And
    cmn_bpt_businessparticipants.IsTenant = 0 And
    cmn_bpt_businessparticipants.IsNaturalPerson = 1 And
    cmn_bpt_businessparticipants.IsCompany = 0 And
    hec_doctors.IsDeleted = 0) Doctor
    On hec_patient_treatment.IfSheduled_ForDoctor_RefID = Doctor.HEC_DoctorID
  Inner Join
  ord_prc_procurementorder_positions
    On ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID =
    hec_patient_treatment_requiredproducts.BoundTo_ProcurementOrderPosition_RefID Inner Join
  cmn_pro_products On ord_prc_procurementorder_positions.CMN_PRO_Product_RefID =
    cmn_pro_products.CMN_PRO_ProductID Inner Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID =
    ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID
Where
  hec_medicalpractises.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsCompany = 1 And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment_requiredproducts.IsDeleted = 0 And
  hec_patient_treatment_requiredproducts.ProductProvidingPharmacy_RefID =
  @PharmacyID
  