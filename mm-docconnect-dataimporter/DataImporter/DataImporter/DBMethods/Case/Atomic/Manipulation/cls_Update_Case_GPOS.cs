/* 
 * Generated on 08/11/15 03:06:54
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
using CL1_CMN_PRO;
using CL1_CMN;
using CL1_BIL;
using CL1_HEC_CAS;
using CL1_HEC_ACT;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;

namespace DataImporter.DBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_Case_GPOS.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_Case_GPOS
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_UCGPOS_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode            
            var returnValue = new FR_Base();
            //Put your code here

            String[] treatment_gpos = cls_Get_All_GPOS_Billing_Codes_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, new P_CAS_GAGPOSBCfGPMID_1516() { GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.operation" }, securityTicket).Result.Select(gpos => gpos.BillingCode).ToArray();
            String[] aftercare_gpos = cls_Get_All_GPOS_Billing_Codes_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, new P_CAS_GAGPOSBCfGPMID_1516() { GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.nachsorge" }, securityTicket).Result.Select(gpos => gpos.BillingCode).ToArray();

            #region CONSTANTS
            const decimal OZURDEX_TREATMENT_FEE = 230;
            const decimal OZURDEX_AFTERCARE_FEE = 150;
            const decimal TREATMENT_FEE = 230;
            const decimal AFTERCARE_FEE = 60;
            #endregion

            Guid treatment_performed_action_type_id = Guid.Empty;

            var treatment_performed_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, new ORM_HEC_ACT_ActionType.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment"
            }).SingleOrDefault();

            if (treatment_performed_action_type == null)
            {
                treatment_performed_action_type = new ORM_HEC_ACT_ActionType();
                treatment_performed_action_type.GlobalPropertyMatchingID = "mm.docconect.doc.app.performed.action.treatment";
                treatment_performed_action_type.Creation_Timestamp = DateTime.Now;
                treatment_performed_action_type.Modification_Timestamp = DateTime.Now;
                treatment_performed_action_type.Tenant_RefID = securityTicket.TenantID;

                treatment_performed_action_type.Save(Connection, Transaction);

                treatment_performed_action_type_id = treatment_performed_action_type.HEC_ACT_ActionTypeID;
            }
            else
            {
                treatment_performed_action_type_id = treatment_performed_action_type.HEC_ACT_ActionTypeID;
            }

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
                        var treatment_count = cls_Get_Treatment_Count_for_PatientID_And_DiagnoseID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GTCfPIDaDIDaLC_1008() { ActionTypeID = treatment_performed_action_type_id, DiagnoseID = Parameter.diagnose_id, PatientID = Parameter.patient_id, LocalizationCode = Parameter.localization, PerformedDate = DateTime.Now }, securityTicket).Result;
                        if (treatment_count != null)
                        {
                            var bill_position_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = Parameter.case_id }, securityTicket).Result;

                            foreach (var id in bill_position_ids)
                            {

                                var billing_code = cls_Get_BillingCode_for_CaseBillCodeID.Invoke(Connection, Transaction, new P_CAS_GBCfCBCID_1334() { CaseBillCodeID = id.hec_case_bill_code_id }, securityTicket).Result;
                                if (billing_code != null)
                                {
                                    #region ICD H34.8
                                    if (gpos_diagnose_details.diagnose_icd_10.Equals("H34.8"))
                                    {
                                        #region Ozurdex position
                                        if (drug_name.Equals("Ozurdex"))
                                        {
                                            if (treatment_gpos.Contains(billing_code.BillingCode))
                                            {
                                                gpos_codeQ.BillingCode = treatment_count.treatment_count - 1 < 1 ? "36620055" : "36620056";

                                                var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                                if (gpos_code != null)
                                                {
                                                    ORM_BIL_BillPosition.Query old_gpos_positionQ = new ORM_BIL_BillPosition.Query();
                                                    old_gpos_positionQ.BIL_BillPositionID = id.bill_position_id;
                                                    old_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                    old_gpos_positionQ.IsDeleted = false;

                                                    var old_gpos_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, old_gpos_positionQ).SingleOrDefault();
                                                    if (old_gpos_position != null)
                                                    {
                                                        old_gpos_position.Modification_Timestamp = DateTime.Now;
                                                        old_gpos_position.PositionValue_IncludingTax = OZURDEX_TREATMENT_FEE;

                                                        old_gpos_position.Save(Connection, Transaction);

                                                        ORM_HEC_BIL_BillPosition.Query old_hec_gpos_positionQ = new ORM_HEC_BIL_BillPosition.Query();
                                                        old_hec_gpos_positionQ.Ext_BIL_BillPosition_RefID = old_gpos_position.BIL_BillPositionID;
                                                        old_hec_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                        old_hec_gpos_positionQ.PositionFor_Patient_RefID = Parameter.patient_id;
                                                        old_hec_gpos_positionQ.IsDeleted = false;

                                                        var old_hec_gpos_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, old_hec_gpos_positionQ).SingleOrDefault();
                                                        if (old_hec_gpos_position != null)
                                                        {
                                                            ORM_HEC_BIL_BillPosition_BillCode.Query old_hec_gpos_position_codeQ = new ORM_HEC_BIL_BillPosition_BillCode.Query();
                                                            old_hec_gpos_position_codeQ.Tenant_RefID = securityTicket.TenantID;
                                                            old_hec_gpos_position_codeQ.BillPosition_RefID = old_hec_gpos_position.HEC_BIL_BillPositionID;
                                                            old_hec_gpos_position_codeQ.IsDeleted = false;

                                                            var old_hec_gpos_position_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, old_hec_gpos_position_codeQ).SingleOrDefault();
                                                            if (old_hec_gpos_position_code != null)
                                                            {
                                                                old_hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                                                old_hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                                                old_hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;

                                                                old_hec_gpos_position_code.Save(Connection, Transaction);
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            if (aftercare_gpos.Contains(billing_code.BillingCode))
                                            {
                                                gpos_codeQ.BillingCode = treatment_count.treatment_count - 1 < 1 ? "36620063" : "36620064";

                                                var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                                if (gpos_code != null)
                                                {
                                                    ORM_BIL_BillPosition.Query old_gpos_positionQ = new ORM_BIL_BillPosition.Query();
                                                    old_gpos_positionQ.BIL_BillPositionID = id.bill_position_id;
                                                    old_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                    old_gpos_positionQ.IsDeleted = false;

                                                    var old_gpos_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, old_gpos_positionQ).SingleOrDefault();
                                                    if (old_gpos_position != null)
                                                    {
                                                        old_gpos_position.Modification_Timestamp = DateTime.Now;
                                                        old_gpos_position.PositionValue_IncludingTax = OZURDEX_AFTERCARE_FEE;

                                                        old_gpos_position.Save(Connection, Transaction);

                                                        ORM_HEC_BIL_BillPosition.Query old_hec_gpos_positionQ = new ORM_HEC_BIL_BillPosition.Query();
                                                        old_hec_gpos_positionQ.Ext_BIL_BillPosition_RefID = old_gpos_position.BIL_BillPositionID;
                                                        old_hec_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                        old_hec_gpos_positionQ.PositionFor_Patient_RefID = Parameter.patient_id;
                                                        old_hec_gpos_positionQ.IsDeleted = false;

                                                        var old_hec_gpos_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, old_hec_gpos_positionQ).SingleOrDefault();
                                                        if (old_hec_gpos_position != null)
                                                        {
                                                            ORM_HEC_BIL_BillPosition_BillCode.Query old_hec_gpos_position_codeQ = new ORM_HEC_BIL_BillPosition_BillCode.Query();
                                                            old_hec_gpos_position_codeQ.Tenant_RefID = securityTicket.TenantID;
                                                            old_hec_gpos_position_codeQ.BillPosition_RefID = old_hec_gpos_position.HEC_BIL_BillPositionID;
                                                            old_hec_gpos_position_codeQ.IsDeleted = false;

                                                            var old_hec_gpos_position_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, old_hec_gpos_position_codeQ).SingleOrDefault();
                                                            if (old_hec_gpos_position_code != null)
                                                            {
                                                                old_hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                                                old_hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                                                old_hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;

                                                                old_hec_gpos_position_code.Save(Connection, Transaction);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion

                                        #region Other drugs
                                        else
                                        {
                                            if (treatment_gpos.Contains(billing_code.BillingCode))
                                            {
                                                gpos_codeQ.BillingCode = treatment_count.treatment_count - 1 < 3 ? "36620053" : "36620054";

                                                var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                                if (gpos_code != null)
                                                {
                                                    ORM_BIL_BillPosition.Query old_gpos_positionQ = new ORM_BIL_BillPosition.Query();
                                                    old_gpos_positionQ.BIL_BillPositionID = id.bill_position_id;
                                                    old_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                    old_gpos_positionQ.IsDeleted = false;

                                                    var old_gpos_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, old_gpos_positionQ).SingleOrDefault();
                                                    if (old_gpos_position != null)
                                                    {
                                                        old_gpos_position.Modification_Timestamp = DateTime.Now;
                                                        old_gpos_position.PositionValue_IncludingTax = TREATMENT_FEE;

                                                        old_gpos_position.Save(Connection, Transaction);

                                                        ORM_HEC_BIL_BillPosition.Query old_hec_gpos_positionQ = new ORM_HEC_BIL_BillPosition.Query();
                                                        old_hec_gpos_positionQ.Ext_BIL_BillPosition_RefID = old_gpos_position.BIL_BillPositionID;
                                                        old_hec_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                        old_hec_gpos_positionQ.PositionFor_Patient_RefID = Parameter.patient_id;
                                                        old_hec_gpos_positionQ.IsDeleted = false;

                                                        var old_hec_gpos_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, old_hec_gpos_positionQ).SingleOrDefault();
                                                        if (old_hec_gpos_position != null)
                                                        {
                                                            ORM_HEC_BIL_BillPosition_BillCode.Query old_hec_gpos_position_codeQ = new ORM_HEC_BIL_BillPosition_BillCode.Query();
                                                            old_hec_gpos_position_codeQ.Tenant_RefID = securityTicket.TenantID;
                                                            old_hec_gpos_position_codeQ.BillPosition_RefID = old_hec_gpos_position.HEC_BIL_BillPositionID;
                                                            old_hec_gpos_position_codeQ.IsDeleted = false;

                                                            var old_hec_gpos_position_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, old_hec_gpos_position_codeQ).SingleOrDefault();
                                                            if (old_hec_gpos_position_code != null)
                                                            {
                                                                old_hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                                                old_hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                                                old_hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;

                                                                old_hec_gpos_position_code.Save(Connection, Transaction);
                                                            }
                                                        }
                                                    }
                                                }
                                            }


                                            if (aftercare_gpos.Contains(billing_code.BillingCode))
                                            {
                                                gpos_codeQ.BillingCode = treatment_count.treatment_count - 1 < 3 ? "36620061" : "36620062";

                                                var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                                if (gpos_code != null)
                                                {
                                                    ORM_BIL_BillPosition.Query old_gpos_positionQ = new ORM_BIL_BillPosition.Query();
                                                    old_gpos_positionQ.BIL_BillPositionID = id.bill_position_id;
                                                    old_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                    old_gpos_positionQ.IsDeleted = false;

                                                    var old_gpos_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, old_gpos_positionQ).SingleOrDefault();
                                                    if (old_gpos_position != null)
                                                    {
                                                        old_gpos_position.Modification_Timestamp = DateTime.Now;
                                                        old_gpos_position.PositionValue_IncludingTax = AFTERCARE_FEE;

                                                        old_gpos_position.Save(Connection, Transaction);

                                                        ORM_HEC_BIL_BillPosition.Query old_hec_gpos_positionQ = new ORM_HEC_BIL_BillPosition.Query();
                                                        old_hec_gpos_positionQ.Ext_BIL_BillPosition_RefID = old_gpos_position.BIL_BillPositionID;
                                                        old_hec_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                        old_hec_gpos_positionQ.PositionFor_Patient_RefID = Parameter.patient_id;
                                                        old_hec_gpos_positionQ.IsDeleted = false;

                                                        var old_hec_gpos_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, old_hec_gpos_positionQ).SingleOrDefault();
                                                        if (old_hec_gpos_position != null)
                                                        {
                                                            ORM_HEC_BIL_BillPosition_BillCode.Query old_hec_gpos_position_codeQ = new ORM_HEC_BIL_BillPosition_BillCode.Query();
                                                            old_hec_gpos_position_codeQ.Tenant_RefID = securityTicket.TenantID;
                                                            old_hec_gpos_position_codeQ.BillPosition_RefID = old_hec_gpos_position.HEC_BIL_BillPositionID;
                                                            old_hec_gpos_position_codeQ.IsDeleted = false;

                                                            var old_hec_gpos_position_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, old_hec_gpos_position_codeQ).SingleOrDefault();
                                                            if (old_hec_gpos_position_code != null)
                                                            {
                                                                old_hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                                                old_hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                                                old_hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;

                                                                old_hec_gpos_position_code.Save(Connection, Transaction);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    #endregion ICD H34.8

                                    #region ICD H35.3 or H36.0
                                    else if (gpos_diagnose_details.diagnose_icd_10.Equals("H35.3") || gpos_diagnose_details.diagnose_icd_10.Equals("H36.0")) // H35.3 or H36.0
                                    {
                                        if (treatment_gpos.Contains(billing_code.BillingCode))
                                        {
                                            gpos_codeQ.BillingCode = treatment_count.treatment_count - 1 < 3 ? "36620050" : treatment_count.treatment_count - 1 < 6 ? "36620051" : "36620052";

                                            var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                            if (gpos_code != null)
                                            {
                                                ORM_BIL_BillPosition.Query old_gpos_positionQ = new ORM_BIL_BillPosition.Query();
                                                old_gpos_positionQ.BIL_BillPositionID = id.bill_position_id;
                                                old_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                old_gpos_positionQ.IsDeleted = false;

                                                var old_gpos_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, old_gpos_positionQ).SingleOrDefault();
                                                if (old_gpos_position != null)
                                                {
                                                    old_gpos_position.Modification_Timestamp = DateTime.Now;
                                                    old_gpos_position.PositionValue_IncludingTax = TREATMENT_FEE;

                                                    old_gpos_position.Save(Connection, Transaction);

                                                    ORM_HEC_BIL_BillPosition.Query old_hec_gpos_positionQ = new ORM_HEC_BIL_BillPosition.Query();
                                                    old_hec_gpos_positionQ.Ext_BIL_BillPosition_RefID = old_gpos_position.BIL_BillPositionID;
                                                    old_hec_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                    old_hec_gpos_positionQ.PositionFor_Patient_RefID = Parameter.patient_id;
                                                    old_hec_gpos_positionQ.IsDeleted = false;

                                                    var old_hec_gpos_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, old_hec_gpos_positionQ).SingleOrDefault();
                                                    if (old_hec_gpos_position != null)
                                                    {
                                                        ORM_HEC_BIL_BillPosition_BillCode.Query old_hec_gpos_position_codeQ = new ORM_HEC_BIL_BillPosition_BillCode.Query();
                                                        old_hec_gpos_position_codeQ.Tenant_RefID = securityTicket.TenantID;
                                                        old_hec_gpos_position_codeQ.BillPosition_RefID = old_hec_gpos_position.HEC_BIL_BillPositionID;
                                                        old_hec_gpos_position_codeQ.IsDeleted = false;

                                                        var old_hec_gpos_position_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, old_hec_gpos_position_codeQ).SingleOrDefault();
                                                        if (old_hec_gpos_position_code != null)
                                                        {
                                                            old_hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                                            old_hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                                            old_hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;

                                                            old_hec_gpos_position_code.Save(Connection, Transaction);
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        if (aftercare_gpos.Contains(billing_code.BillingCode))
                                        {
                                            gpos_codeQ.BillingCode = treatment_count.treatment_count - 1 < 3 ? "36620058" : treatment_count.treatment_count - 1 < 6 ? "36620059" : "36620060";

                                            var gpos_code = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, gpos_codeQ).SingleOrDefault();
                                            if (gpos_code != null)
                                            {
                                                ORM_BIL_BillPosition.Query old_gpos_positionQ = new ORM_BIL_BillPosition.Query();
                                                old_gpos_positionQ.BIL_BillPositionID = id.bill_position_id;
                                                old_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                old_gpos_positionQ.IsDeleted = false;

                                                var old_gpos_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, old_gpos_positionQ).SingleOrDefault();
                                                if (old_gpos_position != null)
                                                {
                                                    old_gpos_position.Modification_Timestamp = DateTime.Now;
                                                    old_gpos_position.PositionValue_IncludingTax = AFTERCARE_FEE;

                                                    old_gpos_position.Save(Connection, Transaction);

                                                    ORM_HEC_BIL_BillPosition.Query old_hec_gpos_positionQ = new ORM_HEC_BIL_BillPosition.Query();
                                                    old_hec_gpos_positionQ.Ext_BIL_BillPosition_RefID = old_gpos_position.BIL_BillPositionID;
                                                    old_hec_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                                    old_hec_gpos_positionQ.PositionFor_Patient_RefID = Parameter.patient_id;
                                                    old_hec_gpos_positionQ.IsDeleted = false;

                                                    var old_hec_gpos_position = ORM_HEC_BIL_BillPosition.Query.Search(Connection, Transaction, old_hec_gpos_positionQ).SingleOrDefault();
                                                    if (old_hec_gpos_position != null)
                                                    {
                                                        ORM_HEC_BIL_BillPosition_BillCode.Query old_hec_gpos_position_codeQ = new ORM_HEC_BIL_BillPosition_BillCode.Query();
                                                        old_hec_gpos_position_codeQ.Tenant_RefID = securityTicket.TenantID;
                                                        old_hec_gpos_position_codeQ.BillPosition_RefID = old_hec_gpos_position.HEC_BIL_BillPositionID;
                                                        old_hec_gpos_position_codeQ.IsDeleted = false;

                                                        var old_hec_gpos_position_code = ORM_HEC_BIL_BillPosition_BillCode.Query.Search(Connection, Transaction, old_hec_gpos_position_codeQ).SingleOrDefault();
                                                        if (old_hec_gpos_position_code != null)
                                                        {
                                                            old_hec_gpos_position_code.IM_BillingCode = gpos_code.BillingCode;
                                                            old_hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                                            old_hec_gpos_position_code.PotentialCode_RefID = gpos_code.HEC_BIL_PotentialCodeID;

                                                            old_hec_gpos_position_code.Save(Connection, Transaction);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
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
		public static FR_Base Invoke(string ConnectionString,P_CAS_UCGPOS_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_CAS_UCGPOS_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_UCGPOS_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_UCGPOS_1516 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Update_Case_GPOS",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_CAS_UCGPOS_1516 for attribute P_CAS_UCGPOS_1516
		[DataContract]
		public class P_CAS_UCGPOS_1516 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public ORM_CMN_Language[] all_languagesL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Update_Case_GPOS(,P_CAS_UCGPOS_1516 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Update_Case_GPOS.Invoke(connectionString,P_CAS_UCGPOS_1516 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Manipulation.P_CAS_UCGPOS_1516();
parameter.case_id = ...;
parameter.drug_id = ...;
parameter.diagnose_id = ...;
parameter.patient_id = ...;
parameter.localization = ...;
parameter.all_languagesL = ...;

*/
