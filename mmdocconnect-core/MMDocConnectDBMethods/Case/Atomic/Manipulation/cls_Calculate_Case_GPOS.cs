/* 
 * Generated on 09/01/16 10:53:06
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
using CL1_HEC_ACT;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using CL1_HEC_BIL;
using CL1_HEC_CAS;
using CL1_BIL;
using CL1_CMN;
using MMDocConnectUtils;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Calculate_Case_GPOS.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Calculate_Case_GPOS
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CCGPOS_1000 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guids();
            Guid treatment_performed_action_type_id = Guid.Empty;
            var resultList = new List<Guid>();

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

            var treatment_count = cls_Get_Treatment_Count_for_PatientID_And_DiagnoseID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GTCfPIDaDIDaLC_1008()
            {
                ActionTypeID = treatment_performed_action_type_id,
                DiagnoseID = Parameter.diagnose_id,
                PatientID = Parameter.patient_id,
                LocalizationCode = Parameter.localization,
                PerformedDate = Parameter.treatment_date == DateTime.MinValue ? DateTime.Now : Parameter.treatment_date
            }, securityTicket).Result;

            if (treatment_count != null)
            {
                treatment_count.treatment_count++;

                var contracts = cls_Get_InsuranceToBrokerContractID_for_DrugID_and_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GItBCIDfDIDaDID_1541()
                {
                    DiagnoseID = Parameter.diagnose_id,
                    DrugID = Parameter.drug_id,
                    PatientID = Parameter.patient_id,
                    TreatmentDate = DateTime.Now
                }, securityTicket).Result.OrderBy(ctr => ctr.patient_consent_valid_from);

                var contract = contracts.LastOrDefault(ctr => ctr.patient_consent_valid_from.Date <= Parameter.treatment_date);
                var contract_id = Guid.Empty;
                if (contract == null)
                {
                    if (contracts.Any())
                    {
                        contract = contracts.Last();
                    }
                    else
                    {
                        var hip = cls_Get_Patient_Insurance_Data_for_PatientIDs.Invoke(Connection, Transaction, new P_PA_GPIDfPIDs_1002() { PatientIDs = new Guid[] { Parameter.patient_id } }, securityTicket).Result.First();
                        contract_id = cls_Get_Contracts_Where_Hip_Participating_for_HipID.Invoke(Connection, Transaction, new P_PA_GCwHipPfHipID_0954() { HipIkNumber = hip.HipIkNumber }, securityTicket).Result.Last().ContractID;
                    }
                }
                else
                {
                    contract_id = contract.contract_id;
                }

                if (!Parameter.should_update)
                {
                    var gpos_details = cls_Get_All_GPOS_Details_for_ContractID.Invoke(Connection, Transaction, new P_CAS_GAGPOSDfCID_1754() { ContractID = contract_id }, securityTicket).Result;

                    if (gpos_details.Length != 0)
                    {
                        var gpos_types = new List<string>();

                        if (Parameter.oct_doctor_id != Guid.Empty)
                        {
                            gpos_types.Add(EGposType.Oct.Value());
                            if (Parameter.treatment_doctor_id == Guid.Empty && Parameter.ac_doctor_id != Guid.Empty)
                            {
                                gpos_types.Add(EGposType.Aftercare.Value());
                            }
                        }
                        else
                        {
                            if (Parameter.treatment_doctor_id == Guid.Empty && Parameter.ac_doctor_id != Guid.Empty)
                            {
                                gpos_types.Add(EGposType.Aftercare.Value());
                            }
                            else if (Parameter.diagnose_id != Guid.Empty)
                            {
                                gpos_types.Add(EGposType.Operation.Value());
                                gpos_types.Add(EGposType.Aftercare.Value());
                            }
                        }

                        foreach (var gpos_type in gpos_types)
                        {
                            foreach (var gpos_detail in gpos_details.Where(t => t.GposType == gpos_type))
                            {
                                var covered_drugs = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                                {
                                    HEC_BIL_PotentialCode_RefID = gpos_detail.GposID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                }).Select(covered_drug => covered_drug.HEC_Product_RefID);

                                var covered_diagnoses = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                                {
                                    HEC_BIL_PotentialCode_RefID = gpos_detail.GposID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    IsDeleted = false
                                }).Select(covered_diagnose => covered_diagnose.HEC_DIA_PotentialDiagnosis_RefID);

                                var drug_condition = covered_drugs.Any() ? covered_drugs.Any(t => t == Parameter.drug_id) : true;
                                var diagnose_condition = covered_diagnoses.Any() ? covered_diagnoses.Any(t => t == Parameter.diagnose_id) : true;

                                bool treatment_count_condition = gpos_detail.FromInjection > 1000000;

                                if (covered_drugs.Any() && covered_diagnoses.Any())
                                {
                                    var gpos_details_for_drug_diagnose_combo = cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID.Invoke(Connection, Transaction, new P_CAS_GGPOSDfDIDaDID_1033()
                                    {
                                        ContractID = contract_id,
                                        DiagnoseID = Parameter.diagnose_id,
                                        DrugID = Parameter.drug_id
                                    }, securityTicket).Result;

                                    treatment_count_condition = treatment_count.treatment_count >= gpos_detail.FromInjection &&
                                        !gpos_details_for_drug_diagnose_combo.Any(gpos => treatment_count.treatment_count >= gpos.injection_from && gpos.injection_from > gpos_detail.FromInjection && gpos.gpos_type == gpos_type);
                                }

                                var gpos_condition = drug_condition && diagnose_condition && treatment_count_condition;

                                if (gpos_condition)
                                {
                                    ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                                    gpos_position.BIL_BilHeader_RefID = Guid.Empty;
                                    gpos_position.BIL_BillPositionID = Guid.NewGuid();
                                    gpos_position.Creation_Timestamp = DateTime.Now;
                                    gpos_position.Modification_Timestamp = DateTime.Now;
                                    gpos_position.Tenant_RefID = securityTicket.TenantID;
                                    gpos_position.PositionValue_IncludingTax = Convert.ToDecimal(gpos_detail.GposPrice);

                                    gpos_position.Save(Connection, Transaction);

                                    resultList.Add(gpos_position.BIL_BillPositionID);

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
                                    hec_gpos_position_code.IM_BillingCode = gpos_detail.GposNumber;
                                    hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                    hec_gpos_position_code.PotentialCode_RefID = gpos_detail.GposID;
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
                        }
                    }
                }
                else
                {
                    // TODO: fix update - beva -> no beva and such
                    var bill_position_ids = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = Parameter.case_id }, securityTicket).Result;
                    var gpos_details = cls_Get_GPOS_Details_for_DiagnoseID_and_DrugID.Invoke(Connection, Transaction, new P_CAS_GGPOSDfDIDaDID_1033()
                    {
                        ContractID = contract_id,
                        DiagnoseID = Parameter.diagnose_id,
                        DrugID = Parameter.drug_id
                    }, securityTicket).Result;

                    if (gpos_details.Length != 0 && bill_position_ids.Length != 0)
                    {
                        bill_position_ids = bill_position_ids.Where(bp => ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                        {
                            HEC_BIL_PotentialCode_RefID = bp.gpos_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Count != 0 &&
                        ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                        {
                            HEC_BIL_PotentialCode_RefID = bp.gpos_id,
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false
                        }).Count != 0).ToArray();

                        foreach (var id in bill_position_ids)
                        {
                            foreach (var gpos_detail in gpos_details)
                            {
                                if (id.gpos_type == gpos_detail.gpos_type)
                                {
                                    if (treatment_count.treatment_count >= gpos_detail.injection_from
                                        && !gpos_details.Any(gpos => treatment_count.treatment_count >= gpos.injection_from && gpos.injection_from > gpos_detail.injection_from && gpos.gpos_type == id.gpos_type))
                                    {
                                        ORM_BIL_BillPosition.Query old_gpos_positionQ = new ORM_BIL_BillPosition.Query();
                                        old_gpos_positionQ.BIL_BillPositionID = id.bill_position_id;
                                        old_gpos_positionQ.Tenant_RefID = securityTicket.TenantID;
                                        old_gpos_positionQ.IsDeleted = false;

                                        var old_gpos_position = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, old_gpos_positionQ).SingleOrDefault();
                                        if (old_gpos_position != null)
                                        {
                                            old_gpos_position.Modification_Timestamp = DateTime.Now;
                                            old_gpos_position.PositionValue_IncludingTax = Convert.ToDecimal(gpos_detail.gpos_price);

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
                                                    old_hec_gpos_position_code.IM_BillingCode = gpos_detail.gpos_code;
                                                    old_hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                                                    old_hec_gpos_position_code.PotentialCode_RefID = gpos_detail.gpos_id;

                                                    old_hec_gpos_position_code.Save(Connection, Transaction);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            returnValue.Result = resultList.ToArray();
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_CAS_CCGPOS_1000 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_CAS_CCGPOS_1000 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CCGPOS_1000 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CCGPOS_1000 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Calculate_Case_GPOS", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CCGPOS_1000 for attribute P_CAS_CCGPOS_1000
    [DataContract]
    public class P_CAS_CCGPOS_1000
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
        public Guid treatment_doctor_id { get; set; }
        [DataMember]
        public Guid oct_doctor_id { get; set; }
        [DataMember]
        public Guid ac_doctor_id { get; set; }
        [DataMember]
        public String localization { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public ORM_CMN_Language[] all_languagesL { get; set; }
        [DataMember]
        public Boolean should_update { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Calculate_Case_GPOS(,P_CAS_CCGPOS_1000 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Calculate_Case_GPOS.Invoke(connectionString,P_CAS_CCGPOS_1000 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CCGPOS_1000();
parameter.case_id = ...;
parameter.drug_id = ...;
parameter.diagnose_id = ...;
parameter.patient_id = ...;
parameter.treatment_doctor_id = ...;
parameter.oct_doctor_id = ...;
parameter.ac_doctor_id = ...;
parameter.localization = ...;
parameter.treatment_date = ...;
parameter.all_languagesL = ...;
parameter.should_update = ...;

*/
