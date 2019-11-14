/* 
 * Generated on 09/16/15 14:39:07
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_HEC_BIL;
using CL1_HEC;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using CL1_CMN_PRO;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using CL1_BIL;
using CL1_HEC_CAS;
using CL1_CMN;

namespace DataImporter.DBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Add_GPOS_to_Case.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_GPOS_to_Case
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_AGPOStC_0906 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Base();
            //Put your code here

            #region CONSTANTS
            const decimal OZURDEX_TREATMENT_FEE = 230;
            const decimal OZURDEX_AFTERCARE_FEE = 150;
            const decimal TREATMENT_FEE = 230;
            const decimal BEVACIZUMAB_TREATMENT_FEE = 75;
            const decimal MANAGEMENT_TREATMENT_FEE = 25;
            const decimal AFTERCARE_FEE = 60;
            const string BEVACIZUMAB_GPOS = "06010050";
            const string MANAGEMENT_FEE_GPOS = "36620057";
            #endregion

            ORM_HEC_BIL_PotentialCode.Query gpos_codeQ = new ORM_HEC_BIL_PotentialCode.Query();
            gpos_codeQ.Tenant_RefID = securityTicket.TenantID;
            gpos_codeQ.IsDeleted = false;

            ORM_HEC_Product.Query hec_drug_detailsQ = new ORM_HEC_Product.Query();
            hec_drug_detailsQ.HEC_ProductID = Parameter.drug_id;
            hec_drug_detailsQ.Tenant_RefID = securityTicket.TenantID;
            hec_drug_detailsQ.IsDeleted = false;

            var hec_drug_details = ORM_HEC_Product.Query.Search(Connection, Transaction, hec_drug_detailsQ).SingleOrDefault();
            if (hec_drug_details != null)
            {
                ORM_CMN_PRO_Product.Query cmn_drug_detailsQ = new ORM_CMN_PRO_Product.Query();
                cmn_drug_detailsQ.Tenant_RefID = securityTicket.TenantID;
                cmn_drug_detailsQ.CMN_PRO_ProductID = hec_drug_details.Ext_PRO_Product_RefID;
                cmn_drug_detailsQ.IsDeleted = false;

                var cmn_drug_details = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, cmn_drug_detailsQ).SingleOrDefault();
                if (cmn_drug_details != null)
                {
                    var drug_name = cmn_drug_details.Product_Name.GetContent(Parameter.all_languagesL.FirstOrDefault().CMN_LanguageID);

                    var gpos_diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = Parameter.diagnose_id }, securityTicket).Result;
                    if (gpos_diagnose_details != null)
                    {
                        #region TREATMENT GPOS

                        if (Parameter.treatment_gpos != "")
                        {
                            gpos_codeQ.BillingCode = Parameter.treatment_gpos;

                            var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();

                            ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                            gpos_position.BIL_BilHeader_RefID = Guid.Empty;
                            gpos_position.BIL_BillPositionID = Guid.NewGuid();
                            gpos_position.Creation_Timestamp = DateTime.Now;
                            gpos_position.Modification_Timestamp = DateTime.Now;
                            gpos_position.Tenant_RefID = securityTicket.TenantID;
                            gpos_position.PositionValue_IncludingTax = Parameter.treatment_gpos == "36620055" || Parameter.treatment_gpos == "36620056" ? OZURDEX_TREATMENT_FEE : TREATMENT_FEE;

                            gpos_position.Save(Connection, Transaction);

                            ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                            hec_gpos_position.Creation_Timestamp = DateTime.Now;
                            hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                            hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                            hec_gpos_position.Modification_Timestamp = DateTime.Now;
                            hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                            hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                            hec_gpos_position.Save(Connection, Transaction);

                            ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                            hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                            hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                            hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                            hec_gpos_position_code.IM_BillingCode = gpos_code != null ? gpos_code.BillingCode : "";
                            hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                            hec_gpos_position_code.PotentialCode_RefID = gpos_code != null ? gpos_code.HEC_BIL_PotentialCodeID : Guid.Empty;
                            hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                            hec_gpos_position_code.Save(Connection, Transaction);

                            ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                            hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                            hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                            hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                            hec_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                            hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                            hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                            hec_gpos_case_code.Save(Connection, Transaction);
                        }
                        else
                        {
                            var treatment_count = cls_Get_Treatment_Count_for_PatientID_And_DiagnoseID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GTCfPIDaDIDaLC_1008() { DiagnoseID = Parameter.diagnose_id, PatientID = Parameter.patient_id, LocalizationCode = Parameter.localization, PerformedDate = DateTime.Now }, securityTicket).Result;
                            if (treatment_count != null)
                            {
                                #region ICD H34.8
                                if (gpos_diagnose_details.diagnose_icd_10.Equals("H34.8"))
                                {
                                    #region Ozurdex position
                                    if (drug_name.Equals("Ozurdex"))
                                    {
                                        gpos_codeQ.BillingCode = treatment_count.treatment_count < 1 ? "36620055" : "36620056";

                                        var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                        if (gpos_code != null)
                                        {
                                            ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                            gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                                            gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                            gpos_position.Creation_Timestamp = DateTime.Now;
                                            gpos_position.Modification_Timestamp = DateTime.Now;
                                            gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            gpos_position.PositionValue_IncludingTax = OZURDEX_TREATMENT_FEE;

                                            gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                            hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                            hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                            hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                                            hec_gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                            hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                            hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                            hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                            hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;
                                            hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_position_code.Save(Connection, Transaction);

                                            ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                            hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                            hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                            hec_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                                            hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_case_code.Save(Connection, Transaction);
                                        }

                                    }
                                    #endregion

                                    #region Other drugs
                                    else
                                    {
                                        gpos_codeQ.BillingCode = treatment_count.treatment_count < 3 ? "36620053" : "36620054";

                                        var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                        if (gpos_code != null)
                                        {
                                            ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                            gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                                            gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                            gpos_position.Creation_Timestamp = DateTime.Now;
                                            gpos_position.Modification_Timestamp = DateTime.Now;
                                            gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            gpos_position.PositionValue_IncludingTax = TREATMENT_FEE;


                                            gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                            hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                            hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                            hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                                            hec_gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                            hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                            hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                            hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                            hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;
                                            hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_position_code.Save(Connection, Transaction);

                                            ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                            hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                            hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                            hec_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                                            hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_case_code.Save(Connection, Transaction);
                                        }

                                    }
                                    #endregion
                                }
                                #endregion ICD H34.8

                                #region ICD H35.3 or H36.0
                                else if (gpos_diagnose_details.diagnose_icd_10.Equals("H35.3") || gpos_diagnose_details.diagnose_icd_10.Equals("H36.0")) // H35.3 or H36.0
                                {
                                    gpos_codeQ.BillingCode = treatment_count.treatment_count < 3 ? "36620050" : treatment_count.treatment_count < 6 ? "36620051" : "36620052";

                                    var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                    if (gpos_code != null)
                                    {
                                        ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                        gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                                        gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                        gpos_position.Creation_Timestamp = DateTime.Now;
                                        gpos_position.Modification_Timestamp = DateTime.Now;
                                        gpos_position.Tenant_RefID = securityTicket.TenantID;
                                        gpos_position.PositionValue_IncludingTax = TREATMENT_FEE;


                                        gpos_position.Save(Connection, Transaction);

                                        ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                        hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                        hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                        hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                        hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                        hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                        hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                                        hec_gpos_position.Save(Connection, Transaction);

                                        ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                        hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                        hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                        hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                        hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                        hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                        hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;
                                        hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                        hec_gpos_position_code.Save(Connection, Transaction);

                                        ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                        hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                        hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                        hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                        hec_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                                        hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                        hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                        hec_gpos_case_code.Save(Connection, Transaction);
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion TREATMENT GPOS

                        // TODO: don't set beva and management on aftercare submit
                        #region BEVACIZUMAB GPOS
                        if (drug_name.Contains("Bevacizumab"))
                        {
                            gpos_codeQ.BillingCode = Parameter.bevacizumab_gpos != "" ? Parameter.bevacizumab_gpos : BEVACIZUMAB_GPOS;

                            var beva_gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();

                            ORM_BIL_BillPosition beva_gpos_position = new ORM_BIL_BillPosition();
                            beva_gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                            beva_gpos_position.BIL_BillPositionID = Guid.NewGuid();
                            beva_gpos_position.Creation_Timestamp = DateTime.Now;
                            beva_gpos_position.Modification_Timestamp = DateTime.Now;
                            beva_gpos_position.Tenant_RefID = securityTicket.TenantID;
                            beva_gpos_position.PositionValue_IncludingTax = BEVACIZUMAB_TREATMENT_FEE;

                            beva_gpos_position.Save(Connection, Transaction);

                            ORM_HEC_BIL_BillPosition hec_beva_gpos_position = new ORM_HEC_BIL_BillPosition();
                            hec_beva_gpos_position.Creation_Timestamp = DateTime.Now;
                            hec_beva_gpos_position.Ext_BIL_BillPosition_RefID = beva_gpos_position.BIL_BillPositionID;
                            hec_beva_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                            hec_beva_gpos_position.Modification_Timestamp = DateTime.Now;
                            hec_beva_gpos_position.Tenant_RefID = securityTicket.TenantID;
                            hec_beva_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                            hec_beva_gpos_position.Save(Connection, Transaction);

                            ORM_HEC_BIL_BillPosition_BillCode hec_beva_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                            hec_beva_gpos_position_code.BillPosition_RefID = hec_beva_gpos_position.HEC_BIL_BillPositionID;
                            hec_beva_gpos_position_code.Creation_Timestamp = DateTime.Now;
                            hec_beva_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                            hec_beva_gpos_position_code.IM_BillingCode = beva_gpos_code.BillingCode;
                            hec_beva_gpos_position_code.Modification_Timestamp = DateTime.Now;
                            hec_beva_gpos_position_code.PotentialCode_RefID = beva_gpos_code.HEC_BIL_PotentialCodeID;
                            hec_beva_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                            hec_beva_gpos_position_code.Save(Connection, Transaction);

                            ORM_HEC_CAS_Case_BillCode hec_beva_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                            hec_beva_gpos_case_code.Creation_Timestamp = DateTime.Now;
                            hec_beva_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_beva_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                            hec_beva_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                            hec_beva_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                            hec_beva_gpos_case_code.Modification_Timestamp = DateTime.Now;
                            hec_beva_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                            hec_beva_gpos_case_code.Save(Connection, Transaction);
                        }
                        #endregion BEVACIZUMAB GPOS

                        #region MANAGEMENT FEE GPOS
                        gpos_codeQ.BillingCode = Parameter.management_fee_gpos != "" ? Parameter.management_fee_gpos : MANAGEMENT_FEE_GPOS;

                        var man_gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();

                        ORM_BIL_BillPosition management_fee_gpos_position = new ORM_BIL_BillPosition();
                        management_fee_gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                        management_fee_gpos_position.BIL_BillPositionID = Guid.NewGuid();
                        management_fee_gpos_position.Creation_Timestamp = DateTime.Now;
                        management_fee_gpos_position.Modification_Timestamp = DateTime.Now;
                        management_fee_gpos_position.Tenant_RefID = securityTicket.TenantID;
                        management_fee_gpos_position.PositionValue_IncludingTax = MANAGEMENT_TREATMENT_FEE;

                        management_fee_gpos_position.Save(Connection, Transaction);

                        ORM_HEC_BIL_BillPosition hec_management_fee_gpos_position = new ORM_HEC_BIL_BillPosition();
                        hec_management_fee_gpos_position.Creation_Timestamp = DateTime.Now;
                        hec_management_fee_gpos_position.Ext_BIL_BillPosition_RefID = management_fee_gpos_position.BIL_BillPositionID;
                        hec_management_fee_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                        hec_management_fee_gpos_position.Modification_Timestamp = DateTime.Now;
                        hec_management_fee_gpos_position.Tenant_RefID = securityTicket.TenantID;
                        hec_management_fee_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                        hec_management_fee_gpos_position.Save(Connection, Transaction);

                        ORM_HEC_BIL_BillPosition_BillCode hec_hec_management_fee_gpos_code = new ORM_HEC_BIL_BillPosition_BillCode();
                        hec_hec_management_fee_gpos_code.BillPosition_RefID = hec_management_fee_gpos_position.HEC_BIL_BillPositionID;
                        hec_hec_management_fee_gpos_code.Creation_Timestamp = DateTime.Now;
                        hec_hec_management_fee_gpos_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                        hec_hec_management_fee_gpos_code.IM_BillingCode = man_gpos_code.BillingCode;
                        hec_hec_management_fee_gpos_code.Modification_Timestamp = DateTime.Now;
                        hec_hec_management_fee_gpos_code.PotentialCode_RefID = man_gpos_code.HEC_BIL_PotentialCodeID;
                        hec_hec_management_fee_gpos_code.Tenant_RefID = securityTicket.TenantID;

                        hec_hec_management_fee_gpos_code.Save(Connection, Transaction);

                        ORM_HEC_CAS_Case_BillCode hec_management_fee_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                        hec_management_fee_gpos_case_code.Creation_Timestamp = DateTime.Now;
                        hec_management_fee_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_hec_management_fee_gpos_code.HEC_BIL_BillPosition_BillCodeID;
                        hec_management_fee_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                        hec_management_fee_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                        hec_management_fee_gpos_case_code.Modification_Timestamp = DateTime.Now;
                        hec_management_fee_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                        hec_management_fee_gpos_case_code.Save(Connection, Transaction);
                        #endregion MANAGEMENT FEE GPOS

                        #region AFTERCARE GPOS
                        if (Parameter.aftercare_gpos != "")
                        {
                            gpos_codeQ.BillingCode = Parameter.aftercare_gpos;

                            var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();

                            ORM_BIL_BillPosition aftercare_gpos_position = new ORM_BIL_BillPosition();
                            aftercare_gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                            aftercare_gpos_position.BIL_BillPositionID = Guid.NewGuid();
                            aftercare_gpos_position.Creation_Timestamp = DateTime.Now;
                            aftercare_gpos_position.Modification_Timestamp = DateTime.Now;
                            aftercare_gpos_position.Tenant_RefID = securityTicket.TenantID;
                            aftercare_gpos_position.PositionValue_IncludingTax = Parameter.aftercare_gpos == "36620063" || Parameter.aftercare_gpos == "36620064" ? OZURDEX_AFTERCARE_FEE : AFTERCARE_FEE; ;

                            aftercare_gpos_position.Save(Connection, Transaction);

                            ORM_HEC_BIL_BillPosition hec_aftercare_gpos_position = new ORM_HEC_BIL_BillPosition();
                            hec_aftercare_gpos_position.Creation_Timestamp = DateTime.Now;
                            hec_aftercare_gpos_position.Ext_BIL_BillPosition_RefID = aftercare_gpos_position.BIL_BillPositionID;
                            hec_aftercare_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                            hec_aftercare_gpos_position.Modification_Timestamp = DateTime.Now;
                            hec_aftercare_gpos_position.Tenant_RefID = securityTicket.TenantID;
                            hec_aftercare_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                            hec_aftercare_gpos_position.Save(Connection, Transaction);

                            ORM_HEC_BIL_BillPosition_BillCode hec_aftercare_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                            hec_aftercare_gpos_position_code.BillPosition_RefID = hec_aftercare_gpos_position.HEC_BIL_BillPositionID;
                            hec_aftercare_gpos_position_code.Creation_Timestamp = DateTime.Now;
                            hec_aftercare_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                            hec_aftercare_gpos_position_code.IM_BillingCode = gpos_code != null ? gpos_code.BillingCode : "";
                            hec_aftercare_gpos_position_code.Modification_Timestamp = DateTime.Now;
                            hec_aftercare_gpos_position_code.PotentialCode_RefID = gpos_code != null ? gpos_code.HEC_BIL_PotentialCodeID : Guid.Empty;
                            hec_aftercare_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                            hec_aftercare_gpos_position_code.Save(Connection, Transaction);

                            ORM_HEC_CAS_Case_BillCode hec_aftercare_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                            hec_aftercare_gpos_case_code.Creation_Timestamp = DateTime.Now;
                            hec_aftercare_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_aftercare_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                            hec_aftercare_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                            hec_aftercare_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                            hec_aftercare_gpos_case_code.Modification_Timestamp = DateTime.Now;
                            hec_aftercare_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                            hec_aftercare_gpos_case_code.Save(Connection, Transaction);
                        }
                        else
                        {
                            var treatment_count = cls_Get_Treatment_Count_for_PatientID_And_DiagnoseID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GTCfPIDaDIDaLC_1008() { DiagnoseID = Parameter.diagnose_id, PatientID = Parameter.patient_id, LocalizationCode = Parameter.localization, PerformedDate = DateTime.Now }, securityTicket).Result;
                            if (treatment_count != null)
                            {
                                #region ICD H34.8
                                if (gpos_diagnose_details.diagnose_icd_10.Equals("H34.8"))
                                {
                                    #region Ozurdex position
                                    if (drug_name.Equals("Ozurdex"))
                                    {
                                        gpos_codeQ.BillingCode = treatment_count.treatment_count < 1 ? "36620063" : "36620064";

                                        var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                        if (gpos_code != null)
                                        {
                                            ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                            gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                                            gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                            gpos_position.Creation_Timestamp = DateTime.Now;
                                            gpos_position.Modification_Timestamp = DateTime.Now;
                                            gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            gpos_position.PositionValue_IncludingTax = OZURDEX_AFTERCARE_FEE;

                                            gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                            hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                            hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                            hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                                            hec_gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                            hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                            hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                            hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                            hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;
                                            hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_position_code.Save(Connection, Transaction);

                                            ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                            hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                            hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                            hec_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                                            hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_case_code.Save(Connection, Transaction);
                                        }

                                    }
                                    #endregion

                                    #region Other drugs
                                    else
                                    {

                                        gpos_codeQ.BillingCode = treatment_count.treatment_count < 3 ? "36620061" : "36620062";

                                        var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                        if (gpos_code != null)
                                        {
                                            ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                            gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                                            gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                            gpos_position.Creation_Timestamp = DateTime.Now;
                                            gpos_position.Modification_Timestamp = DateTime.Now;
                                            gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            gpos_position.PositionValue_IncludingTax = AFTERCARE_FEE;


                                            gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                            hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                            hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                            hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                            hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                                            hec_gpos_position.Save(Connection, Transaction);

                                            ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                            hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                            hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                            hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                            hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;
                                            hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_position_code.Save(Connection, Transaction);

                                            ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                            hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                            hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                            hec_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                                            hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                            hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                            hec_gpos_case_code.Save(Connection, Transaction);
                                        }

                                    }
                                    #endregion
                                }
                                #endregion ICD H34.8

                                #region ICD H35.3 or H36.0
                                else if (gpos_diagnose_details.diagnose_icd_10.Equals("H35.3") || gpos_diagnose_details.diagnose_icd_10.Equals("H36.0")) // H35.3 or H36.0
                                {
                                    gpos_codeQ.BillingCode = treatment_count.treatment_count < 3 ? "36620058" : treatment_count.treatment_count < 6 ? "36620059" : "36620060";

                                    var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                    if (gpos_code != null)
                                    {
                                        ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                        gpos_position.BIL_BilHeader_RefID = Parameter.header_id;
                                        gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                        gpos_position.Creation_Timestamp = DateTime.Now;
                                        gpos_position.Modification_Timestamp = DateTime.Now;
                                        gpos_position.Tenant_RefID = securityTicket.TenantID;
                                        gpos_position.PositionValue_IncludingTax = AFTERCARE_FEE;


                                        gpos_position.Save(Connection, Transaction);

                                        ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                                        hec_gpos_position.Creation_Timestamp = DateTime.Now;
                                        hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                                        hec_gpos_position.HEC_BIL_BillPositionID = Guid.NewGuid();
                                        hec_gpos_position.Modification_Timestamp = DateTime.Now;
                                        hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                                        hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                                        hec_gpos_position.Save(Connection, Transaction);

                                        ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                                        hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                                        hec_gpos_position_code.Creation_Timestamp = DateTime.Now;
                                        hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID = Guid.NewGuid();
                                        hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                        hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                        hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;
                                        hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                                        hec_gpos_position_code.Save(Connection, Transaction);

                                        ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                                        hec_gpos_case_code.Creation_Timestamp = DateTime.Now;
                                        hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                                        hec_gpos_case_code.HEC_CAS_Case_BillCodeID = Guid.NewGuid();
                                        hec_gpos_case_code.HEC_CAS_Case_RefID = Parameter.case_id;
                                        hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                                        hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                                        hec_gpos_case_code.Save(Connection, Transaction);
                                    }

                                }
                                #endregion
                            }
                        }
                        #endregion AFTERCARE GPOS
                    }
                }
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_CAS_AGPOStC_0906 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_CAS_AGPOStC_0906 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_AGPOStC_0906 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_AGPOStC_0906 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
			try
			{

				if (cleanupConnection == true) 
				{
					Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
					Connection.Open();
				}
				if (cleanupTransaction == true)
				{
					Transaction = Connection.BeginTransaction();
				}

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

				#region Cleanup Connection/Transaction
				//Commit the transaction 
				if (cleanupTransaction == true)
				{
					Transaction.Commit();
				}
				//Close the connection
				if (cleanupConnection == true)
				{
					Connection.Close();
				}
				#endregion
			}
			catch (Exception ex)
			{
				try
				{
					if (cleanupTransaction == true && Transaction!=null)
					{
						Transaction.Rollback();
					}
				}
				catch { }

				try
				{
					if (cleanupConnection == true && Connection != null)
					{
						Connection.Close();
					}
				}
				catch { }

				throw new Exception("Exception occured in method cls_Add_GPOS_to_Case",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_CAS_AGPOStC_0906 for attribute P_CAS_AGPOStC_0906
		[DataContract]
		public class P_CAS_AGPOStC_0906 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public Guid header_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid treatment_doctor_id { get; set; } 
			[DataMember]
			public Guid ac_doctor_id { get; set; } 
			[DataMember]
			public ORM_CMN_Language[] all_languagesL { get; set; } 
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public String treatment_gpos { get; set; } 
			[DataMember]
			public String aftercare_gpos { get; set; } 
			[DataMember]
			public String bevacizumab_gpos { get; set; } 
			[DataMember]
			public String management_fee_gpos { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Add_GPOS_to_Case(,P_CAS_AGPOStC_0906 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Add_GPOS_to_Case.Invoke(connectionString,P_CAS_AGPOStC_0906 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new DataImporter.DBMethods.Case.Atomic.Manipulation.P_CAS_AGPOStC_0906();
parameter.case_id = ...;
parameter.drug_id = ...;
parameter.diagnose_id = ...;
parameter.header_id = ...;
parameter.patient_id = ...;
parameter.treatment_doctor_id = ...;
parameter.ac_doctor_id = ...;
parameter.all_languagesL = ...;
parameter.localization = ...;
parameter.treatment_gpos = ...;
parameter.aftercare_gpos = ...;
parameter.bevacizumab_gpos = ...;
parameter.management_fee_gpos = ...;
parameter.treatment_date = ...;

*/
