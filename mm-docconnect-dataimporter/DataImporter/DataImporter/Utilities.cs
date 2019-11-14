using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    class TableInfo
    {
        public string Tablename { get; set; }
        public string Columnname { get; set; }
    }

    class Utilities
    {
        public static List<TableInfo> SearchKey(string connectionString, Guid guid)
        {
            List<TableInfo> tableInfo = GetFkTables();
            List<TableInfo> resultInfo = new List<TableInfo>();

            int counterTables = 0;
            foreach (var element in tableInfo)
            {
                using (var dbConnection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(connectionString))
                {
                    dbConnection.Open();

                    DbCommand command = dbConnection.CreateCommand();
                    Console.WriteLine("Looking in : {0}", element.Tablename);
                    command.Connection = dbConnection;
                    command.CommandText = "SELECT * from " + element.Tablename + " WHERE " + element.Columnname + "=  GuidToBinary('" + guid + "')";
                    var retVal = command.ExecuteReader();

                    Guid idGuid = new Guid("00000000000000000000000000000000");
                    int counter = 0;
                    while (retVal.Read())
                    {
                        try
                        {
                            idGuid = retVal.GetGuid(0);
                        }
                        catch (Exception)
                        {
                            idGuid = new Guid("00000000000000000000000000000001");
                        }
                        string idString = idGuid.ToString();
                        counter++;
                        resultInfo.Add(new TableInfo
                        {
                            Tablename = element.Tablename,
                            Columnname = idString
                        });
                    }
                    if (counter > 0)
                    {
                        // break;
                    }
                    counterTables++;
                }
            }

            return resultInfo;
        }
        public static List<TableInfo> GetTestTable()
        {
            List<TableInfo> tableInfos = new List<TableInfo>();
            tableInfos.Add(new TableInfo { Tablename = "hec_patients", Columnname = "HEC_PatientID" });
            return tableInfos;
        }


        public static List<TableInfo> GetFkTables()
        {
            List<TableInfo> tableInfos = new List<TableInfo>();
            tableInfos.Add(new TableInfo { Tablename = "acc_bnk_bankaccounts", Columnname = "Bank_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "bil_billheader_history", Columnname = "BillHeader_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "bil_billheader_history", Columnname = "TriggeredBy_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "bil_billheader_propertyvalues", Columnname = "BIL_BillHeader_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "bil_billheaders", Columnname = "CreatedBy_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "bil_billposition_propertyvalue", Columnname = "BIL_BillPosition_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "bil_billposition_transmitionstatuses", Columnname = "BillPosition_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "bil_billpositions", Columnname = "BIL_BilHeader_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_businessparticipant_2_bankaccount", Columnname = "CMN_BPT_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_businessparticipant_2_bankaccount", Columnname = "ACC_BNK_BankAccount_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_businessparticipants", Columnname = "IfNaturalPerson_CMN_PER_PersonInfo_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_businessparticipants", Columnname = "IfCompany_CMN_COM_CompanyInfo_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_businessparticipants", Columnname = "DefaultLanguage_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_businessparticipants", Columnname = "DefaultCurrency_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_ctm_customers", Columnname = "Ext_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_ctm_organizationalunit_staff", Columnname = "OrganizationalUnit_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_ctm_organizationalunit_staff", Columnname = "BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_ctm_organizationalunits", Columnname = "Customer_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_bpt_ctm_organizationalunits", Columnname = "IfMedicalPractise_HEC_MedicalPractice_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_com_companyinfo", Columnname = "Contact_UCD_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_com_companyinfo_addresses", Columnname = "CompanyInfo_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_com_companyinfo_addresses", Columnname = "Address_UCD_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_countries_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_ctr_contract_parameters", Columnname = "Contract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_ctr_contract_parties", Columnname = "Contract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_ctr_contract_parties", Columnname = "Undersigning_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_ctr_contract_parties", Columnname = "Party_ContractRole_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_currencies_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_languages_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_per_communicationcontacts", Columnname = "PersonInfo_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_per_communicationcontacts", Columnname = "Contact_Type" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_per_personinfo", Columnname = "Address_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_per_personinfo_2_account", Columnname = "CMN_PER_PersonInfo_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_per_personinfo_2_account", Columnname = "USR_Account_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_price_values", Columnname = "Price_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_price_values", Columnname = "PriceValue_Currency_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_pro_products_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "cmn_tenants", Columnname = "UniversalContactDetail_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "doc_document_2_structure", Columnname = "Document_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "doc_document_2_structure", Columnname = "Structure_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "doc_documentrevisions", Columnname = "Document_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "doc_documentrevisions", Columnname = "UploadedByAccount" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_actiontype_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_2_actiontype", Columnname = "HEC_ACT_PerformedAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_2_actiontype", Columnname = "HEC_ACT_ActionType_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_diagnosisupdate_localizations", Columnname = "HEX_EXC_Action_DiagnosisUpdate_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_diagnosisupdate_localizations", Columnname = "HEC_DIA_Diagnosis_Localization_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_diagnosisupdates", Columnname = "HEC_ACT_PerformedAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_diagnosisupdates", Columnname = "HEC_Patient_Diagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_diagnosisupdates", Columnname = "PotentialDiagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedactions", Columnname = "Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedactions", Columnname = "IfPerformedInternaly_ResponsibleBusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedactions", Columnname = "IsPerformed_MedicalPractice_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_2_actiontype", Columnname = "HEC_ACT_PlannedAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_2_actiontype", Columnname = "HEC_ACT_ActionType_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_potentialprocedure_requiredproduct", Columnname = "PlannedAction_PotentialProcedure_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_potentialprocedure_requiredproduct", Columnname = "HealthcareProduct_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_potentialprocedure_requiredproduct", Columnname = "BoundTo_HealthcareProcurementOrderPosition_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_potentialprocedures", Columnname = "PlannedAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_potentialprocedures", Columnname = "PotentialProcedure_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedactions", Columnname = "Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedactions", Columnname = "IfPerformed_PerformedAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedactions", Columnname = "ToBePerformedBy_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedactions", Columnname = "IfPlannedFollowup_PreviousAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedactions", Columnname = "MedicalPractice_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billheaders", Columnname = "Ext_BIL_BillHeader_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billheaders", Columnname = "Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billposition_billcodes", Columnname = "PotentialCode_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billposition_billcodes", Columnname = "BillPosition_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billpositions", Columnname = "Ext_BIL_BillPosition_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billpositions", Columnname = "PositionFor_Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcode_2_healthcareproduct", Columnname = "HEC_BIL_PotentialCode_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcode_2_healthcareproduct", Columnname = "HEC_Product_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcode_2_potentialdiagnosis", Columnname = "HEC_BIL_PotentialCode_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcode_2_potentialdiagnosis", Columnname = "HEC_DIA_PotentialDiagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcodes", Columnname = "PotentialCode_Catalog_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcodes", Columnname = "Price_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcodes_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_billcodes", Columnname = "HEC_CAS_Case_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_billcodes", Columnname = "HEC_BIL_BillPosition_BillCode_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_relevantperformedactions", Columnname = "Case_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_relevantperformedactions", Columnname = "PerformedAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_relevantplannedactions", Columnname = "Case_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_relevantplannedactions", Columnname = "PlannedAction_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_universalpropertyvalue", Columnname = "HEC_CAS_Case_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_universalpropertyvalue", Columnname = "HEC_CAS_Case_UniversalProperty_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_cases", Columnname = "Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_cases", Columnname = "CreatedBy_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_crt_insurancetobrokercontract_participatingdoctors", Columnname = "InsuranceToBrokerContract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_crt_insurancetobrokercontract_participatingdoctors", Columnname = "Doctor_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_crt_insurancetobrokercontract_participatingpatients", Columnname = "InsuranceToBrokerContract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_crt_insurancetobrokercontract_participatingpatients", Columnname = "Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_crt_insurancetobrokercontracts", Columnname = "Ext_CMN_CTR_Contract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty", Columnname = "CoveredPotentialBillCode_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty", Columnname = "CoveredPotentialBillCode_UniversalProperty_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts", Columnname = "InsuranceToBrokerContract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_insurancetobrokercontracts_coveredhealthcareproducts", Columnname = "HealthcareProduct_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes", Columnname = "InsuranceToBrokerContract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes", Columnname = "PotentialBillCode_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses", Columnname = "InsuranceToBrokerContract_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_insurancetobrokercontracts_coveredpotentialdiagnoses", Columnname = "PotentialDiagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_diagnosis_localizations", Columnname = "Diagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_potentialdiagnoses_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_potentialdiagnosis_catalogcodes", Columnname = "PotentialDiagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_potentialdiagnosis_catalogcodes", Columnname = "PotentialDiagnosis_Catalog_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_potentialdiagnosis_catalogs_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_doctor_universalpropertyvalues", Columnname = "HEC_Doctor_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_doctor_universalpropertyvalues", Columnname = "UniversalProperty_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_doctors", Columnname = "BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_doctors", Columnname = "Account_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_his_healthinsurance_companies", Columnname = "CMN_BPT_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_medicalpractice_2_universalproperty", Columnname = "HEC_MedicalPractice_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_medicalpractice_2_universalproperty", Columnname = "HEC_MedicalPractice_UniversalProperty_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_diagnoses", Columnname = "Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_diagnoses", Columnname = "R_PotentialDiagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_diagnosis_localizations", Columnname = "Patient_Diagnosis_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_diagnosis_localizations", Columnname = "DIA_Diagnosis_Localization_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_healthinsurances", Columnname = "Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_healthinsurances", Columnname = "HIS_HealthInsurance_Company_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_medicalpractices", Columnname = "HEC_Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_medicalpractices", Columnname = "HEC_MedicalPractices_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patients", Columnname = "CMN_BPT_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_prc_procurementorder_positions", Columnname = "Ext_ORD_PRC_ProcurementOrder_Position_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_prc_procurementorder_positions", Columnname = "OrderedFor_Patient_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_prc_procurementorder_positions", Columnname = "OrderedFor_Doctor_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_products", Columnname = "Ext_PRO_Product_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_tre_potentialprocedure_2_procedurepackage", Columnname = "HEC_TRE_PotentialProcedure_Package_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_tre_potentialprocedure_2_procedurepackage", Columnname = "HEC_TRE_PotentialProcedure_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_headers", Columnname = "Current_ProcurementOrderStatus_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_headers", Columnname = "CreatedBy_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_position_history", Columnname = "ProcurementOrder_Position_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_position_history", Columnname = "TriggeredBy_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_positions", Columnname = "ProcurementOrder_Header_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_positions", Columnname = "CMN_PRO_Product_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_positions", Columnname = "BillTo_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_statuses_de", Columnname = "Language_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_statushistory", Columnname = "ProcurementOrder_Header_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_statushistory", Columnname = "ProcurementOrder_Status_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_statushistory", Columnname = "TriggeredBy_BusinessParticipant_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_2_functionlevelright", Columnname = "FunctionLevelRight_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_2_functionlevelright", Columnname = "Account_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_applicationsettings", Columnname = "Account_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_applicationsettings", Columnname = "ApplicationSetting_Definition_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_functionlevelrights", Columnname = "FunctionLevelRights_Group_RefID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_accounts", Columnname = "BusinessParticipant_RefID" });
            return tableInfos;
        }
        public static List<TableInfo> GetPkTables()
        {
            List<TableInfo> tableInfos = new List<TableInfo>();
            tableInfos.Add(new TableInfo { Tablename = "doc_documents", Columnname = "DOC_DocumentID" });
            tableInfos.Add(new TableInfo { Tablename = "doc_structures", Columnname = "DOC_StructureID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_actiontype", Columnname = "HEC_ACT_ActionTypeID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedaction_diagnosisupdates", Columnname = "HEC_ACT_PerformedAction_DiagnosisUpdateID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_performedactions", Columnname = "HEC_ACT_PerformedActionID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedaction_potentialprocedures", Columnname = "HEC_ACT_PlannedAction_PotentialProcedureID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_act_plannedactions", Columnname = "HEC_ACT_PlannedActionID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billposition_billcodes", Columnname = "HEC_BIL_BillPosition_BillCodeID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_billpositions", Columnname = "HEC_BIL_BillPositionID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcode_catalogs", Columnname = "HEC_BIL_PotentialCode_CatalogID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_bil_potentialcodes", Columnname = "HEC_BIL_PotentialCodeID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_case_universalproperties", Columnname = "HEC_CAS_Case_UniversalPropertyID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_cas_cases", Columnname = "HEC_CAS_CaseID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_crt_insurancetobrokercontracts", Columnname = "HEC_CRT_InsuranceToBrokerContractID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties", Columnname = "HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_ctr_insurancetobrokercontracts_coveredpotentialbillcodes", Columnname = "HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCodeID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_diagnosis_localizations", Columnname = "HEC_DIA_Diagnosis_LocalizationID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_potentialdiagnoses", Columnname = "HEC_DIA_PotentialDiagnosisID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_dia_potentialdiagnosis_catalogs", Columnname = "HEC_DIA_PotentialDiagnosis_CatalogID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_doctor_universalproperties", Columnname = "HEC_Doctor_UniversalPropertyID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_doctors", Columnname = "HEC_DoctorID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_his_healthinsurance_companies", Columnname = "HEC_HealthInsurance_CompanyID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_medicalpractice_universalproperties", Columnname = "HEC_MedicalPractice_UniversalPropertyID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_medicalpractises", Columnname = "HEC_MedicalPractiseID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patient_diagnoses", Columnname = "HEC_Patient_DiagnosisID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_patients", Columnname = "HEC_PatientID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_prc_procurementorder_positions", Columnname = "HEC_PRC_ProcurementOrder_PositionID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_products", Columnname = "HEC_ProductID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_tre_potentialprocedure_packages", Columnname = "HEC_TRE_PotentialProcedure_PackageID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_tre_potentialprocedures", Columnname = "HEC_TRE_PotentialProcedureID" });
            tableInfos.Add(new TableInfo { Tablename = "hec_tre_potentialprocedures", Columnname = "HEC_TRE_PotentialProcedureID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_headers", Columnname = "ORD_PRC_ProcurementOrder_HeaderID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_positions", Columnname = "ORD_PRC_ProcurementOrder_PositionID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_statuses", Columnname = "ORD_PRC_ProcurementOrder_StatusID" });
            tableInfos.Add(new TableInfo { Tablename = "ord_prc_procurementorder_statuses", Columnname = "ORD_PRC_ProcurementOrder_StatusID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_applicationsetting_definitions", Columnname = "USR_Account_ApplicationSetting_DefinitionID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_functionlevelrights", Columnname = "USR_Account_FunctionLevelRightID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_account_functionlevelrights_groups", Columnname = "USR_Account_FunctionLevelRights_GroupID" });
            tableInfos.Add(new TableInfo { Tablename = "usr_accounts", Columnname = "USR_AccountID" });

            return tableInfos;
        }
    }
}
