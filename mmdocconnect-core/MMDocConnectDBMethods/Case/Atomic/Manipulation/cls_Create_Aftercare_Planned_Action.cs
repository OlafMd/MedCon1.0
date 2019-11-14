/* 
 * Generated on 06/11/15 12:40:37
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
using CL1_HEC_CAS;
using CL1_USR;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using CL1_CMN;
using CL1_HEC;
using CL1_CMN_BPT_CTM;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_Aftercare_Planned_Action.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_Aftercare_Planned_Action
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CAPA_1237 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            ORM_HEC_ACT_PlannedAction aftercare_planned_action = new ORM_HEC_ACT_PlannedAction();
            aftercare_planned_action.Creation_Timestamp = DateTime.Now;
            aftercare_planned_action.HEC_ACT_PlannedActionID = Guid.NewGuid();
            aftercare_planned_action.IsPerformed = false;
            aftercare_planned_action.Modification_Timestamp = DateTime.Now;
            aftercare_planned_action.Patient_RefID = Parameter.patient_id;
            aftercare_planned_action.PlannedFor_Date = Parameter.treatment_date;
            aftercare_planned_action.Tenant_RefID = securityTicket.TenantID;

            Guid id = Guid.Empty;

            var aftercare_doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
            {
                HEC_DoctorID = Parameter.aftercare_doctor_practice_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (aftercare_doctor != null)
            {
                id = aftercare_doctor.BusinessParticipant_RefID;
            }
            else
            {
                var aftercare_practice = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query()
                {
                    IfMedicalPractise_HEC_MedicalPractice_RefID = Parameter.aftercare_doctor_practice_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (aftercare_practice != null)
                {
                    var aftercare_customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
                    {
                        CMN_BPT_CTM_CustomerID = aftercare_practice.Customer_RefID,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).SingleOrDefault();

                    if (aftercare_customer != null)
                    {
                        id = aftercare_customer.Ext_BusinessParticipant_RefID;
                    }
                }
            }
            
            aftercare_planned_action.ToBePerformedBy_BusinessParticipant_RefID = id;            
            aftercare_planned_action.Save(Connection, Transaction);

            ORM_HEC_CAS_Case_RelevantPlannedAction aftercare_planned_action_to_case = new ORM_HEC_CAS_Case_RelevantPlannedAction();
            aftercare_planned_action_to_case.Case_RefID = Parameter.case_id;
            aftercare_planned_action_to_case.Creation_Timestamp = DateTime.Now;
            aftercare_planned_action_to_case.HEC_CAS_Case_RelevantPlannedActionID = Guid.NewGuid();
            aftercare_planned_action_to_case.Modification_Timestamp = DateTime.Now;
            aftercare_planned_action_to_case.PlannedAction_RefID = aftercare_planned_action.HEC_ACT_PlannedActionID;
            aftercare_planned_action_to_case.Tenant_RefID = securityTicket.TenantID;

            aftercare_planned_action_to_case.Save(Connection, Transaction);

            ORM_HEC_ACT_ActionType.Query aftercare_planned_action_typeQ = new ORM_HEC_ACT_ActionType.Query();
            aftercare_planned_action_typeQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.planned.action.aftercare";
            aftercare_planned_action_typeQ.Tenant_RefID = securityTicket.TenantID;
            aftercare_planned_action_typeQ.IsDeleted = false;

            var aftercare_planned_action_type_id = Guid.Empty;

            var aftercare_planned_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, aftercare_planned_action_typeQ).SingleOrDefault();

            if (aftercare_planned_action_type == null)
            {
                aftercare_planned_action_type = new ORM_HEC_ACT_ActionType();

                Dict action_type_name_dict = new Dict(ORM_HEC_ACT_ActionType.TableName);

                foreach (var lang in Parameter.all_languagesL)
                {
                    var content = lang.ISO_639_1.Equals("DE") ? "nachsorge" : "aftercare";
                    action_type_name_dict.AddEntry(lang.CMN_LanguageID, content);
                }

                aftercare_planned_action_type.ActionType_Name = action_type_name_dict;
                aftercare_planned_action_type.Creation_Timestamp = DateTime.Now;
                aftercare_planned_action_type.GlobalPropertyMatchingID = "mm.docconect.doc.app.planned.action.aftercare";
                aftercare_planned_action_type.Modification_Timestamp = DateTime.Now;
                aftercare_planned_action_type.HEC_ACT_ActionTypeID = Guid.NewGuid();
                aftercare_planned_action_type.Tenant_RefID = securityTicket.TenantID;
                aftercare_planned_action_type.Save(Connection, Transaction);

                aftercare_planned_action_type_id = aftercare_planned_action_type.HEC_ACT_ActionTypeID;
            }
            else
            {
                aftercare_planned_action_type_id = aftercare_planned_action_type.HEC_ACT_ActionTypeID;
            }

            ORM_HEC_ACT_PlannedAction_2_ActionType aftercare_planned_action_2_type = new ORM_HEC_ACT_PlannedAction_2_ActionType();
            aftercare_planned_action_2_type.Tenant_RefID = securityTicket.TenantID;
            aftercare_planned_action_2_type.Creation_Timestamp = DateTime.Now;
            aftercare_planned_action_2_type.IsDeleted = false;
            aftercare_planned_action_2_type.HEC_ACT_ActionType_RefID = aftercare_planned_action_type_id;
            aftercare_planned_action_2_type.HEC_ACT_PlannedAction_RefID = aftercare_planned_action.HEC_ACT_PlannedActionID;
            aftercare_planned_action_2_type.Modification_Timestamp = DateTime.Now;
            aftercare_planned_action_2_type.HEC_ACT_PlannedAction_2_ActionTypeID = Guid.NewGuid();

            aftercare_planned_action_2_type.Save(Connection, Transaction);

            returnValue.Result = aftercare_planned_action.HEC_ACT_PlannedActionID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_CAPA_1237 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_CAPA_1237 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CAPA_1237 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CAPA_1237 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
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

                throw new Exception("Exception occured in method cls_Create_Aftercare_Planned_Action", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_CAPA_1237 for attribute P_CAS_CAPA_1237
    [DataContract]
    public class P_CAS_CAPA_1237
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public ORM_CMN_Language[] all_languagesL { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public Guid aftercare_doctor_practice_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Aftercare_Planned_Action(,P_CAS_CAPA_1237 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Aftercare_Planned_Action.Invoke(connectionString,P_CAS_CAPA_1237 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CAPA_1237();
parameter.case_id = ...;
parameter.all_languagesL = ...;
parameter.practice_id = ...;
parameter.patient_id = ...;
parameter.treatment_date = ...;
parameter.aftercare_doctor_practice_id = ...;

*/
