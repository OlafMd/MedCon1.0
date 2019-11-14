
Select
  ord_cuo_customerorder_statuses.Status_Code,
  ord_cuo_customerorder_statuses.Status_Name_DictID,
  ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID,
  ord_cuo_customerorder_headers.CustomerOrder_Number,
  ord_cuo_customerorder_headers.CustomerOrder_Date,
  ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID,
  ord_cuo_customerorder_positions.Position_OrdinalNumber,
  ord_cuo_customerorder_positions.Position_Quantity,
  ord_cuo_customerorder_positions.Position_ValuePerUnit,
  ord_cuo_customerorder_positions.Position_ValueTotal,
  ord_cuo_customerorder_positions.Position_Comment,
  hec_patient_treatment.HEC_Patient_TreatmentID,
  hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RequiredProductID,
  cmn_com_companyinfo.CMN_COM_CompanyInfoID,
  cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID,
  cmn_bpt_businessparticipants.DisplayName,
  hec_medicalpractises.HEC_MedicalPractiseID,
  cmn_pro_products.CMN_PRO_ProductID,
  cmn_pro_products.Product_Name_DictID,
  cmn_pro_products.Product_Number,
  ord_cuo_customerorder_positions.Position_RequestedDateOfDelivery,
  ord_cuo_customerorder_statuses.GlobalPropertyMatchingID,
  ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID,
  hec_patient_treatment_requiredproducts.ExpectedDateOfDelivery,
  DoctorPerformed.DoctorFirstName,
  DoctorPerformed.DoctorLastname,
  DoctorPerformed.DoctorTitle,
  Doctor.DoctorFirstNameScheduled,
  Doctor.DoctorLastnameScheduled,
  Doctor.DoctorTitleScheduled
From
  ord_cuo_customerorder_positions Inner Join
  ord_cuo_customerorder_headers
    On ord_cuo_customerorder_positions.CustomerOrder_Header_RefID =
    ord_cuo_customerorder_headers.ORD_CUO_CustomerOrder_HeaderID Inner Join
  ord_cuo_customerorder_statuses
    On ord_cuo_customerorder_headers.Current_CustomerOrderStatus_RefID =
    ord_cuo_customerorder_statuses.ORD_CUO_CustomerOrder_StatusID Inner Join
  hec_patient_treatment_requiredproducts
    On
    hec_patient_treatment_requiredproducts.BoundTo_CustomerOrderPosition_RefID =
    ord_cuo_customerorder_positions.ORD_CUO_CustomerOrder_PositionID Inner Join
  hec_patient_treatment
    On hec_patient_treatment_requiredproducts.HEC_Patient_Treatment_RefID =
    hec_patient_treatment.HEC_Patient_TreatmentID Inner Join
  hec_medicalpractises On hec_patient_treatment.TreatmentPractice_RefID =
    hec_medicalpractises.HEC_MedicalPractiseID Inner Join
  cmn_com_companyinfo On hec_medicalpractises.Ext_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_bpt_businessparticipants
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID Inner Join
  cmn_pro_products On cmn_pro_products.CMN_PRO_ProductID =
    ord_cuo_customerorder_positions.CMN_PRO_Product_RefID Left Join
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
Where
  ord_cuo_customerorder_headers.IsDeleted = 0 And
  ord_cuo_customerorder_statuses.IsDeleted = 0 And
  ord_cuo_customerorder_positions.IsDeleted = 0 And
  hec_medicalpractises.IsDeleted = 0 And
  cmn_com_companyinfo.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsCompany = 1 And
  hec_patient_treatment.IsDeleted = 0 And
  hec_patient_treatment_requiredproducts.IsDeleted = 0 And
  ord_cuo_customerorder_headers.Tenant_RefID = @TenantID And
  hec_patient_treatment_requiredproducts.ProductProvidingPharmacy_RefID =
  @PharmacyID
  