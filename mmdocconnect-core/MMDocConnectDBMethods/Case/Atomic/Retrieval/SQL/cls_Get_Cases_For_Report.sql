
    Select Straight_Join
      hec_cas_cases.CaseNumber,
      bil_billposition_transmitionstatuses.TransmitionCode As StatusNumber,
      bil_billposition_transmitionstatuses.TransmitionStatusKey As CodeForType,
      bil_billpositions.PositionValue_IncludingTax As NumberForPayment,
      bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID As StatusID,
      hec_cas_cases.Patient_FirstName,
      hec_cas_cases.Patient_LastName,
      hec_cas_cases.Patient_Gender,
      hec_cas_cases.Patient_Age,
      hec_cas_cases.Patient_BirthDate,
      hec_cas_cases.Modification_Timestamp as CaseCreationDate,
      hec_act_performedactions.HEC_ACT_PerformedActionID As TreatmentCaseSubmitActionID,
      hec_act_performedactions.IM_IfPerformed_ResponsibleBP_FullName As TreatmentSubmitBPName,
      hec_act_performedactions.IM_IfPerformed_MedicalPractice_Name As TreatmentPracticeName,
      hec_act_performedactions1.HEC_ACT_PerformedActionID As afterCaseSubmitActionID,
      hec_act_performedactions1.IM_IfPerformed_MedicalPractice_Name As AfterCaseSubmitMedicalPractice,
      hec_act_performedactions1.IM_IfPerformed_ResponsibleBP_FullName As AfterCaseSubmitResponsibleBPNAme,
      hec_doctors1.HEC_DoctorID As AfterCareDoctor,
      hec_doctors.HEC_DoctorID As SurgeryDoctor,
      hec_cas_cases.HEC_CAS_CaseID As CaseID,
      hec_act_performedaction_diagnosisupdates1.HEC_ACT_PerformedAction_RefID,
      hec_act_performedaction_diagnosisupdate_localizations1.IM_PotentialDiagnosisLocalization_Code As IM_PotentialDiagnosisLocalization_Code,
      hec_dia_diagnosis_localizations1.HEC_DIA_Diagnosis_LocalizationID As LocalizationID,
      hec_act_performedaction_diagnosisupdates1.IM_PotentialDiagnosisState_Name,
      hec_act_performedaction_diagnosisupdates1.IM_PotentialDiagnosisCatalog_Name,
      hec_act_performedaction_diagnosisupdates1.IM_PotentialDiagnosis_Code,
      hec_act_performedaction_diagnosisupdates1.IM_PotentialDiagnosis_Name,
      hec_act_performedaction_diagnosisupdates1.PotentialDiagnosis_RefID,
      hec_dia_diagnosis_localizations1.DiagnosisLocalization_Name_DictID,
      hec_dia_diagnosis_localizations1.LocalizationCode,
      hec_act_performedaction_diagnosisupdate_localizations1.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID As LocalizationImID,
      hec_act_performedaction_diagnosisupdates1.HEC_ACT_PerformedAction_DiagnosisUpdateID As DiganoseImID,
      hec_dia_diagnosis_localizations1.Diagnosis_RefID,
      hec_dia_potentialdiagnosis_catalogcodes.Code,
      hec_dia_potentialdiagnosis_catalogs.Catalog_Name_DictID,
      hec_dia_potentialdiagnoses.PotentialDiagnosis_Name_DictID,
      bil_billposition_transmitionstatuses.BillPosition_RefID,
      bil_billposition_transmitionstatuses.IsActive,
      hec_bil_potentialcodes.BillingCode,
      bil_billpositions.PositionNumber,
      hec_act_plannedactions1.IsPerformed As IsAftercareP,
      hec_act_plannedactions.IsPerformed As IsTreatmentP,
      hec_act_plannedactions.HEC_ACT_PlannedActionID As IsTreatmentID,
      hec_act_plannedactions1.HEC_ACT_PlannedActionID As IsAftercareID,
      hec_act_performedaction_diagnosisupdates.PotentialDiagnosis_RefID As TreatmentPerformedDiganoseID,
      hec_act_performedaction_diagnosisupdates2.PotentialDiagnosis_RefID As AftercasePerformedDiagnoseID,
      hec_act_performedaction_diagnosisupdates.IM_PotentialDiagnosis_Name As IM_PotentialDiagnosis_NameTreatment,
      hec_act_performedaction_diagnosisupdates.IM_PotentialDiagnosisCatalog_Name As IM_PotentialDiagnosisCatalog_NameTreatment,
      hec_act_performedaction_diagnosisupdates.IM_PotentialDiagnosis_Code As IM_PotentialDiagnosis_CodeTreatment,
      hec_act_performedaction_diagnosisupdates2.IM_PotentialDiagnosis_Name As IM_PotentialDiagnosis_NameAftercare,
      hec_act_performedaction_diagnosisupdates2.IM_PotentialDiagnosis_Code As IM_PotentialDiagnosis_CodeAftercare,
      hec_act_performedaction_diagnosisupdates2.IM_PotentialDiagnosisCatalog_Name As IM_PotentialDiagnosisCatalog_NameAftercare,
      hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_DiagnosisUpdateID As TreatmentDiagnoseUpdateIM,
      hec_act_performedaction_diagnosisupdates2.HEC_ACT_PerformedAction_DiagnosisUpdateID As AftercareDiagnoseUpdateIM,
      hec_act_performedaction_diagnosisupdate_localizations.HEC_DIA_Diagnosis_Localization_RefID As TreatmentLocalizationID,
      hec_act_performedaction_diagnosisupdate_localizations.IM_PotentialDiagnosisLocalization_Code As TreatmentLocalizationCode,
      hec_act_performedaction_diagnosisupdate_localizations2.IM_PotentialDiagnosisLocalization_Code As AftercareLocalizationCode,
      hec_act_performedaction_diagnosisupdate_localizations2.HEC_DIA_Diagnosis_Localization_RefID As AftercareLocalizationID,
      hec_act_performedaction_diagnosisupdate_localizations2.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID As AftercaseLocalizationIDIM,
      hec_act_performedaction_diagnosisupdate_localizations.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID As TreatmentLocalizationIDIM,
      hec_cas_case_universalpropertyvalue.Value_Boolean As SendInvoiceToPractice,
      hec_prc_procurementorder_positions.IsOrderForPatient_PatientFeeWaived As IsPatientFeeWaived,
      hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID As orderId,
      ord_prc_procurementorder_statuses.Status_Code As orderStatusCode,
      hec_prc_procurementorder_positions.IfProFormaOrderPosition_PrintLabelOnly As isLabelOnly,
      hec_act_plannedaction_potentialprocedure_requiredproduct.HealthcareProduct_RefID As DrugID,
      hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID,
      hec_bil_potentialcodes_de.Content As CodeName,
      cmn_bpt_ctm_organizationalunits.IfMedicalPractise_HEC_MedicalPractice_RefID As TreatmentPracticeID,
      cmn_bpt_ctm_organizationalunits1.IfMedicalPractise_HEC_MedicalPractice_RefID As AftercarePracticeID,
      hec_cas_cases.Patient_RefID,
      cmn_bpt_businessparticipants1.DisplayName As PatientHIP,
      hec_patient_healthinsurances.HealthInsurance_Number As InsuranceID,
      hec_bil_potentialcodes.HEC_BIL_PotentialCodeID As GposID,
      hec_bil_billpositions.HEC_BIL_BillPositionID As BillPositionID,  
      hec_act_performedactions1.IfPerfomed_DateOfAction As AfterCareDate,
      hec_act_plannedactions.PlannedFor_Date as TreatmentDate
    From
      hec_cas_cases
      Left Join hec_cas_case_relevantperformedactions On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantperformedactions.Case_RefID And
        hec_cas_case_relevantperformedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantperformedactions.IsDeleted = 0
      Left Join hec_act_plannedactions On hec_cas_case_relevantperformedactions.PerformedAction_RefID = hec_act_plannedactions.IfPlannedFollowup_PreviousAction_RefID And
        hec_act_plannedactions.Tenant_RefID = @TenantID And hec_act_plannedactions.IsCancelled = 0 And hec_act_plannedactions.IsDeleted = 0
      Left Join hec_act_plannedaction_potentialprocedures On hec_act_plannedaction_potentialprocedures.PlannedAction_RefID = hec_act_plannedactions.HEC_ACT_PlannedActionID And
        hec_act_plannedaction_potentialprocedures.Tenant_RefID = @TenantID And hec_act_plannedaction_potentialprocedures.IsDeleted = 0
      Left Join hec_act_plannedaction_potentialprocedure_requiredproduct On hec_act_plannedaction_potentialprocedure_requiredproduct.PlannedAction_PotentialProcedure_RefID =
        hec_act_plannedaction_potentialprocedures.HEC_ACT_PlannedAction_PotentialProcedureID And hec_act_plannedaction_potentialprocedure_requiredproduct.Tenant_RefID = @TenantID And
        hec_act_plannedaction_potentialprocedure_requiredproduct.IsDeleted = 0
      Left Join hec_prc_procurementorder_positions On hec_act_plannedaction_potentialprocedure_requiredproduct.BoundTo_HealthcareProcurementOrderPosition_RefID =
        hec_prc_procurementorder_positions.HEC_PRC_ProcurementOrder_PositionID And hec_prc_procurementorder_positions.Tenant_RefID = @TenantID And
        hec_prc_procurementorder_positions.IsDeleted = 0
      Left Join hec_cas_case_universalpropertyvalue On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_universalpropertyvalue.HEC_CAS_Case_RefID And
        hec_cas_case_universalpropertyvalue.Tenant_RefID = @TenantID And hec_cas_case_universalpropertyvalue.IsDeleted = 0
      Left Join hec_cas_case_universalproperties On hec_cas_case_universalpropertyvalue.HEC_CAS_Case_UniversalProperty_RefID =
        hec_cas_case_universalproperties.HEC_CAS_Case_UniversalPropertyID And hec_cas_case_universalproperties.IsValue_Boolean = 1 And hec_cas_case_universalproperties.IsDeleted = 0
        And hec_cas_case_universalproperties.Tenant_RefID = @TenantID And hec_cas_case_universalproperties.PropertyName = 'Send Invoice to Practice'
      Left Join ord_prc_procurementorder_positions On hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID =
        ord_prc_procurementorder_positions.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_positions.IsDeleted = 0
      Left Join hec_doctors On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID = hec_doctors.BusinessParticipant_RefID And hec_doctors.Tenant_RefID = @TenantID And
        hec_doctors.IsDeleted = 0
      Left Join hec_cas_case_relevantplannedactions On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_relevantplannedactions.Case_RefID And
        hec_cas_case_relevantplannedactions.Tenant_RefID = @TenantID And hec_cas_case_relevantplannedactions.IsDeleted = 0
      Left Join hec_act_plannedaction_2_actiontype On hec_cas_case_relevantplannedactions.PlannedAction_RefID = hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID
        And hec_act_plannedaction_2_actiontype.Tenant_RefID = @TenantID And hec_act_plannedaction_2_actiontype.IsDeleted = 0
      Left Join hec_act_actiontype hec_act_actiontype1 On hec_act_plannedaction_2_actiontype.HEC_ACT_ActionType_RefID = hec_act_actiontype1.HEC_ACT_ActionTypeID And
        hec_act_actiontype1.GlobalPropertyMatchingID = 'mm.docconect.doc.app.planned.action.aftercare' And hec_act_actiontype1.Tenant_RefID = @TenantID And
        hec_act_actiontype1.IsDeleted = 0
      Left Join hec_act_plannedactions hec_act_plannedactions1 On hec_act_plannedaction_2_actiontype.HEC_ACT_PlannedAction_RefID = hec_act_plannedactions1.HEC_ACT_PlannedActionID And
        hec_act_plannedactions1.Tenant_RefID = @TenantID And hec_act_plannedactions.IsCancelled = 0 And hec_act_plannedactions1.IsDeleted = 0
      Left Join hec_doctors hec_doctors1 On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID = hec_doctors1.BusinessParticipant_RefID And hec_doctors1.Tenant_RefID =
        @TenantID And hec_doctors1.IsDeleted = 0 
      Left Join cmn_bpt_businessparticipants On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
        And cmn_bpt_businessparticipants.Tenant_RefID = @TenantID And cmn_bpt_businessparticipants.IsDeleted = 0
      Left Join cmn_per_personinfo On cmn_bpt_businessparticipants.IfNaturalPerson_CMN_PER_PersonInfo_RefID = cmn_per_personinfo.CMN_PER_PersonInfoID And
        cmn_per_personinfo.Tenant_RefID = @TenantID And cmn_per_personinfo.IsDeleted = 0
      Left Join cmn_com_companyinfo On cmn_bpt_businessparticipants.IfCompany_CMN_COM_CompanyInfo_RefID = cmn_com_companyinfo.CMN_COM_CompanyInfoID And cmn_com_companyinfo.Tenant_RefID
        = @TenantID And cmn_com_companyinfo.IsDeleted = 0
      Left Join cmn_universalcontactdetails On cmn_com_companyinfo.Contact_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID And
        cmn_universalcontactdetails.Tenant_RefID = @TenantID And cmn_universalcontactdetails.IsDeleted = 0
      Left Join ord_prc_procurementorder_positions ord_prc_procurementorder_positions1 On hec_prc_procurementorder_positions.Ext_ORD_PRC_ProcurementOrder_Position_RefID =
        ord_prc_procurementorder_positions1.ORD_PRC_ProcurementOrder_PositionID And ord_prc_procurementorder_positions1.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_positions1.IsDeleted = 0
      Left Join ord_prc_procurementorder_headers On ord_prc_procurementorder_positions1.ProcurementOrder_Header_RefID =
        ord_prc_procurementorder_headers.ORD_PRC_ProcurementOrder_HeaderID And ord_prc_procurementorder_headers.Tenant_RefID = @TenantID And ord_prc_procurementorder_headers.IsDeleted
        = 0
      Left Join ord_prc_procurementorder_statuses On ord_prc_procurementorder_headers.Current_ProcurementOrderStatus_RefID =
        ord_prc_procurementorder_statuses.ORD_PRC_ProcurementOrder_StatusID And ord_prc_procurementorder_statuses.Tenant_RefID = @TenantID And
        ord_prc_procurementorder_statuses.IsDeleted = 0
      Left Join hec_medicalpractises On cmn_com_companyinfo.CMN_COM_CompanyInfoID = hec_medicalpractises.Ext_CompanyInfo_RefID And hec_medicalpractises.Tenant_RefID = @TenantID And
        hec_medicalpractises.IsDeleted = 0
      Left Join hec_cas_case_billcodes On hec_cas_cases.HEC_CAS_CaseID = hec_cas_case_billcodes.HEC_CAS_Case_RefID And hec_cas_case_billcodes.IsDeleted = 0 And
        hec_cas_case_billcodes.Tenant_RefID = @TenantID
      Left Join hec_bil_billposition_billcodes On hec_cas_case_billcodes.HEC_BIL_BillPosition_BillCode_RefID = hec_bil_billposition_billcodes.HEC_BIL_BillPosition_BillCodeID And
        hec_bil_billposition_billcodes.Tenant_RefID = @TenantID And hec_bil_billposition_billcodes.IsDeleted = 0
      Left Join hec_bil_billpositions On hec_bil_billposition_billcodes.BillPosition_RefID = hec_bil_billpositions.HEC_BIL_BillPositionID And hec_bil_billpositions.Tenant_RefID =
        @TenantID And hec_bil_billpositions.IsDeleted = 0
      Left Join bil_billpositions On hec_bil_billpositions.Ext_BIL_BillPosition_RefID = bil_billpositions.BIL_BillPositionID And bil_billpositions.Tenant_RefID = @TenantID And
        bil_billpositions.IsDeleted = 0
      Inner Join bil_billposition_transmitionstatuses On bil_billposition_transmitionstatuses.BillPosition_RefID = bil_billpositions.BIL_BillPositionID And
        bil_billposition_transmitionstatuses.TransmitionCode = @Status And bil_billposition_transmitionstatuses.IsDeleted = 0 And bil_billposition_transmitionstatuses.IsActive = 1 And
        bil_billposition_transmitionstatuses.Tenant_RefID = @TenantID
      Left Join hec_act_performedactions On hec_act_plannedactions.IfPerformed_PerformedAction_RefID = hec_act_performedactions.HEC_ACT_PerformedActionID And
        hec_act_performedactions.IsDeleted = 0 And hec_act_performedactions.Tenant_RefID = @TenantID
      Left Join hec_act_performedactions hec_act_performedactions1 On hec_act_plannedactions1.IfPerformed_PerformedAction_RefID = hec_act_performedactions1.HEC_ACT_PerformedActionID
        And hec_act_plannedactions1.IsDeleted = 0 And hec_act_plannedactions1.Tenant_RefID = @TenantID
      Left Join hec_act_performedaction_diagnosisupdates hec_act_performedaction_diagnosisupdates1 On hec_act_performedaction_diagnosisupdates1.HEC_ACT_PerformedAction_RefID =
        hec_cas_case_relevantperformedactions.PerformedAction_RefID And hec_act_performedaction_diagnosisupdates1.IsDeleted = 0 And
        hec_act_performedaction_diagnosisupdates1.Tenant_RefID = @TenantID
      Left Join hec_act_performedaction_diagnosisupdate_localizations hec_act_performedaction_diagnosisupdate_localizations1
        On hec_act_performedaction_diagnosisupdate_localizations1.HEX_EXC_Action_DiagnosisUpdate_RefID =
        hec_act_performedaction_diagnosisupdates1.HEC_ACT_PerformedAction_DiagnosisUpdateID And hec_act_performedaction_diagnosisupdate_localizations1.IsDeleted = 0 And
        hec_act_performedaction_diagnosisupdate_localizations1.Tenant_RefID = @TenantID
      Left Join hec_dia_diagnosis_localizations hec_dia_diagnosis_localizations1 On hec_dia_diagnosis_localizations1.HEC_DIA_Diagnosis_LocalizationID =
        hec_act_performedaction_diagnosisupdate_localizations1.HEC_DIA_Diagnosis_Localization_RefID And hec_act_performedaction_diagnosisupdate_localizations1.IsDeleted = 0 And
        hec_act_performedaction_diagnosisupdate_localizations1.Tenant_RefID = @TenantID
      Left Join hec_dia_potentialdiagnoses On hec_dia_diagnosis_localizations1.Diagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID And
        hec_dia_potentialdiagnoses.IsDeleted = 0 And hec_dia_potentialdiagnoses.Tenant_RefID = @TenantID
      Left Join hec_dia_potentialdiagnosis_catalogcodes On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_RefID = hec_dia_potentialdiagnoses.HEC_DIA_PotentialDiagnosisID
        And hec_dia_potentialdiagnosis_catalogcodes.IsDeleted = 0 And hec_dia_potentialdiagnosis_catalogcodes.Tenant_RefID = @TenantID
      Left Join hec_dia_potentialdiagnosis_catalogs On hec_dia_potentialdiagnosis_catalogcodes.PotentialDiagnosis_Catalog_RefID =
        hec_dia_potentialdiagnosis_catalogs.HEC_DIA_PotentialDiagnosis_CatalogID And hec_dia_potentialdiagnosis_catalogs.IsDeleted = 0 And
        hec_dia_potentialdiagnosis_catalogs.Tenant_RefID = @TenantID
      Left Join hec_bil_potentialcodes On hec_bil_billposition_billcodes.PotentialCode_RefID = hec_bil_potentialcodes.HEC_BIL_PotentialCodeID And hec_bil_potentialcodes.IsDeleted = 0
        And hec_bil_potentialcodes.Tenant_RefID = @TenantID
      Left Join hec_act_performedaction_diagnosisupdates On hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID =
        hec_act_plannedactions.IfPerformed_PerformedAction_RefID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And hec_act_performedaction_diagnosisupdates.Tenant_RefID =
        @TenantID
      Left Join hec_act_performedaction_diagnosisupdates hec_act_performedaction_diagnosisupdates2 On hec_act_performedaction_diagnosisupdates2.HEC_ACT_PerformedAction_RefID =
        hec_act_plannedactions1.IfPerformed_PerformedAction_RefID And hec_act_performedaction_diagnosisupdates.IsDeleted = 0 And hec_act_performedaction_diagnosisupdates.Tenant_RefID =
        @TenantID
      Left Join hec_act_performedaction_diagnosisupdate_localizations On hec_act_performedaction_diagnosisupdate_localizations.HEX_EXC_Action_DiagnosisUpdate_RefID =
        hec_act_performedaction_diagnosisupdates.HEC_ACT_PerformedAction_RefID And hec_act_performedaction_diagnosisupdate_localizations.IsDeleted = 0 And
        hec_act_performedaction_diagnosisupdate_localizations.Tenant_RefID = @TenantID
      Left Join hec_act_performedaction_diagnosisupdate_localizations hec_act_performedaction_diagnosisupdate_localizations2
        On hec_act_performedaction_diagnosisupdate_localizations2.HEX_EXC_Action_DiagnosisUpdate_RefID =
        hec_act_performedaction_diagnosisupdates2.HEC_ACT_PerformedAction_DiagnosisUpdateID And hec_act_performedaction_diagnosisupdate_localizations2.IsDeleted = 0 And
        hec_act_performedaction_diagnosisupdate_localizations2.Tenant_RefID = @TenantID
      Left Join hec_bil_potentialcodes_de On hec_bil_potentialcodes_de.DictID = hec_bil_potentialcodes.CodeName_DictID And hec_bil_potentialcodes_de.IsDeleted = 0
      Inner Join cmn_bpt_ctm_organizationalunit_staff On hec_act_plannedactions.ToBePerformedBy_BusinessParticipant_RefID =
        cmn_bpt_ctm_organizationalunit_staff.BusinessParticipant_RefID And cmn_bpt_ctm_organizationalunit_staff.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_organizationalunit_staff.IsDeleted = 0
      Inner Join cmn_bpt_ctm_organizationalunits On cmn_bpt_ctm_organizationalunit_staff.OrganizationalUnit_RefID = cmn_bpt_ctm_organizationalunits.CMN_BPT_CTM_OrganizationalUnitID And
        cmn_bpt_ctm_organizationalunits.Tenant_RefID = @TenantID And cmn_bpt_ctm_organizationalunits.IsDeleted = 0
      Left Join cmn_bpt_ctm_organizationalunit_staff cmn_bpt_ctm_organizationalunit_staff1 On hec_act_plannedactions1.ToBePerformedBy_BusinessParticipant_RefID =
        cmn_bpt_ctm_organizationalunit_staff1.BusinessParticipant_RefID And cmn_bpt_ctm_organizationalunit_staff1.Tenant_RefID = @TenantID And
        cmn_bpt_ctm_organizationalunit_staff1.IsDeleted = 0
      Left Join cmn_bpt_ctm_organizationalunits cmn_bpt_ctm_organizationalunits1 On cmn_bpt_ctm_organizationalunit_staff1.OrganizationalUnit_RefID =
        cmn_bpt_ctm_organizationalunits1.CMN_BPT_CTM_OrganizationalUnitID And cmn_bpt_ctm_organizationalunits1.Tenant_RefID = @TenantID And cmn_bpt_ctm_organizationalunits1.IsDeleted =
        0
      Inner Join hec_patient_healthinsurances On hec_patient_healthinsurances.Patient_RefID = hec_cas_cases.Patient_RefID
      Inner Join hec_his_healthinsurance_companies On hec_patient_healthinsurances.HIS_HealthInsurance_Company_RefID = hec_his_healthinsurance_companies.HEC_HealthInsurance_CompanyID
        And hec_his_healthinsurance_companies.IsDeleted = 0 And hec_his_healthinsurance_companies.Tenant_RefID = @TenantID
      Inner Join cmn_bpt_businessparticipants cmn_bpt_businessparticipants1 On hec_his_healthinsurance_companies.CMN_BPT_BusinessParticipant_RefID =
        cmn_bpt_businessparticipants1.CMN_BPT_BusinessParticipantID And cmn_bpt_businessparticipants1.IsDeleted = 0 And cmn_bpt_businessparticipants1.Tenant_RefID = @TenantID
    Where
      hec_cas_cases.Tenant_RefID = @TenantID And
      hec_cas_cases.IsDeleted = 0
    Group By
      bil_billposition_transmitionstatuses.BIL_BillPosition_TransmitionStatusID
    Order By
      hec_cas_cases.CaseNumber,
      bil_billpositions.PositionNumber
	