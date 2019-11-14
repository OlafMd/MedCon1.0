
Select Straight_Join
  hec_cas_cases.Patient_RefID,
  ord_prc_procurementorder_statuses.Status_Code As StatusCode,
  hec_cas_cases.HEC_CAS_CaseID As CaseID,
  ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID As
  StatusID,
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID As OrderID,
  hec_cas_cases.Creation_Timestamp As CaseCreationDate,
  ord_prc_procurementorder_headers.ProcurementOrder_Number As OrderNumber,
  cmn_pro_products.Product_Number As PZN,
  ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_To As
  DeliveryTimeTo,
  ord_prc_procurementorder_positions.RequestedDateOfDelivery_TimeFrame_From As
  DeliveryTimeFrom,
  ord_prc_procurementorder_positions.Position_RequestedDateOfDelivery As
  DeliveryDate,
  ord_prc_procurementorder_positions.IsProFormaOrderPosition As OnlyLabel,
  hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As
  ChargesFee,
  hec_cas_case_universalpropertyvalue.Value_Boolean As SendInvoiceToPractice,
  hec_act_plannedactions.PlannedFor_Date As TreatmentDate,
  hec_doctors.HEC_DoctorID As DoctorID,
  cmn_pro_products_de.Content As DrugName,
  ord_prc_procurementorder_positions.Creation_Timestamp As
  OrderCreationTimestamp,
  hec_cas_cases.CaseNumber,
  ord_prc_procurementorder_headers.CreatedBy_BusinessParticipant_RefID
  As BusinesParticipantWhoCreatedOrder,
  ord_prc_procurementorder_positions.Position_Comment As OrderComment,
  ord_prc_procurementorder_notes.Comment As HeaderComment,
  hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted,
  hec_pharmacies.HEC_PharmacyID As PharmacyID,
  cmn_universalcontactdetails.First_Name As PharmacyName
From
  hec_cas_cases Inner Join
  hec_cas_case_relevantperformedactions
    On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_relevantperformedactions.Case_RefID And
    hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And
    hec_cas_case_relevantperformedactions.IsDeleted = 0 Left Join
  hec_cas_case_universalpropertyvalue
    On hec_cas_cases.HEC_CAS_CaseID =
    hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And
    hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And
    hec_cas_case_universalpropertyvalue.IsDeleted = 0 Left Join
  hec_cas_case_universalproperties
    On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID
    = hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And
    hec_cas_case_universalproperties.IsDeleted = 0 And
    hec_cas_case_universalproperties.Tenant_RefID = @TenantID
  Inner Join
  hec_act_plannedactions
    On hec_cas_case_relevantperformedactions.PerformedAction_RefID =
    hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
    hec_act_plannedactions.Tenant_RefID = @TenantID And
    hec_act_plannedactions.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedures
    On hec_act_plannedactions.HEC_ACT_PlannedActionID =
    hec_act_plannedaction_potentialprocedures.PlannedAction_RefID And
    hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID
    And hec_act_plannedaction_potentialprocedures.IsDeleted = 0 Inner Join
  hec_act_plannedaction_potentialprocedure_requiredproduct
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID = hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID Inner Join
  hec_prc_procurementorder_positions
    On
    hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID = hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And hec_prc_procurementorder_positions.IsDeleted = 0 And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID Inner Join
  ord_prc_procurementorder_positions
    On
    hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.IsDeleted = 0 And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID Inner Join
  ord_prc_procurementorder_headers
    On ord_prc_procurementorder_positions.ProcurementOrder_Header_RefID =
    ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
    And ord_prc_procurementorder_headers.IsDeleted = 0 And
    ord_prc_procurementorder_headers.Tenant_RefID = @TenantID Inner Join
  ord_prc_procurementorder_statuses
    On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
    ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And
    ord_prc_procurementorder_statuses.Status_Code = @OrderStatuses And
    ord_prc_procurementorder_statuses.IsDeleted = 0 And
    ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID Left Join
  hec_products
    On hec_products.HEC_ProductID =
    hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID And hec_products.IsDeleted = 0 And hec_products.Tenant_RefID = @TenantID Inner Join
  cmn_pro_products
    On cmn_pro_products.CMN_PRO_ProductID = hec_products.Ext_PRO_Product_RefID
    And cmn_pro_products.IsDeleted = 0 And cmn_pro_products.Tenant_RefID =
    @TenantID Left Join
  hec_doctors
    On hec_doctors.BusinessParticipant_RefID =
    hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID And
    hec_doctors.IsDeleted = 0 And hec_doctors.Tenant_RefID = @TenantID
  Inner Join
  cmn_pro_products_de
    On cmn_pro_products_de.DictID = cmn_pro_products.Product_Name_DictID And
    cmn_pro_products_de.IsDeleted = 0 Left Join
  ord_prc_procurementorder_notes
    On ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID =
    ord_prc_procurementorder_notes.ORD_PRC_ProcurementOrder_Header_RefID And
    ord_prc_procurementorder_notes.Tenant_RefID = @TenantID And
    ord_prc_procurementorder_notes.IsDeleted = 0 Left Join
  cmn_bpt_businessparticipants
    On ord_prc_procurementorder_headers.ProcurementOrder_Supplier_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID And
    cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And
    cmn_bpt_businessparticipants.IsDeleted = 0 Left Join
  cmn_com_companyinfo
    On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID =
    cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.IsDeleted
    = 0 And cmn_com_companyinfo.Tenant_RefID = @TenantID Left Join
  cmn_universalcontactdetails
    On cmn_com_companyinfo.Contact_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_universalcontactdetails.Tenant_RefID = @TenantID Left Join
  hec_pharmacies
    On cmn_com_companyinfo.CMN_COM_CompanyInfoID =
    hec_pharmacies.Ext_CompanyInfo_RefID And hec_pharmacies.IsDeleted = 0 And
    hec_pharmacies.Tenant_RefID = @TenantID
Where
  hec_cas_cases.Tenant_RefID = @TenantID
Group By
  ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID
Order By
  hec_cas_cases.CaseNumber,
  OrderNumber
  