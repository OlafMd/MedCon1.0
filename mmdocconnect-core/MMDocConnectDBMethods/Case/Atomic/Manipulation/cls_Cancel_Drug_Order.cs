/* 
 * Generated on 06/16/15 14:43:03
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
using CL1_ORD_PRC;
using CL1_CMN;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using CL1_HEC_CAS;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Cancel_Drug_Order.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Cancel_Drug_Order
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_CDO_1250 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_CDO_1250 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_CDO_1250();
            returnValue.Result = new CAS_CDO_1250();
            //Put your code here

            var treatment_planned_action_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = Parameter.case_id }, securityTicket).Result;

            var drug_order_status_latestQ = new ORM_ORD_PRC_ProcurementOrder_Status.Query();
            drug_order_status_latestQ.ORD_PRC_ProcurementOrder_StatusID = Parameter.ord_drug_order_header.Current_ProcurementOrderStatus_RefID;
            drug_order_status_latestQ.Tenant_RefID = securityTicket.TenantID;
            drug_order_status_latestQ.IsDeleted = false;

            var drug_order_status_latest = ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, drug_order_status_latestQ).SingleOrDefault();

            if (drug_order_status_latest.Status_Code == 6)
            {
                var previous_status = cls_Get_Previous_Order_Status_for_HeaderID.Invoke(Connection, Transaction, new P_OR_GPOSfHID_1347() { HeaderID = Parameter.ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID }, securityTicket).Result;
                returnValue.Result.previous_status = previous_status != null ? "MO" + previous_status.OrderStatus : "";
            }
            else
            {
                returnValue.Result.previous_status = "MO" + drug_order_status_latest.Status_Code;
            }

            var cancellation_code = drug_order_status_latest.Status_Code == 0 ? 9 : 6;
            var cancellation_status = String.Format("MO{0}", cancellation_code);

            var new_status = new ORM_ORD_PRC_ProcurementOrder_Status();
            new_status.Status_Code = cancellation_code;
            new_status.GlobalPropertyMatchingID = String.Format("mm.doc.connect.drug.order.status.{0}", cancellation_status.ToLower());
            new_status.Tenant_RefID = securityTicket.TenantID;
            new_status.Modification_Timestamp = DateTime.Now;

            Parameter.ord_drug_order_header.Current_ProcurementOrderStatus_RefID = new_status.ORD_PRC_ProcurementOrder_StatusID;
            Parameter.ord_drug_order_header.Save(Connection, Transaction);

            new_status.Status_Name = new Dict(ORM_ORD_PRC_ProcurementOrder_Status.TableName);

            foreach (var lang in Parameter.all_languagesL)
            {
                new_status.Status_Name.AddEntry(lang.CMN_LanguageID, cancellation_status);
            }

            new_status.Save(Connection, Transaction);

            var new_status_history_entry = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
            new_status_history_entry.IsStatus_Canceled = true;
            new_status_history_entry.Tenant_RefID = securityTicket.TenantID;
            new_status_history_entry.Modification_Timestamp = DateTime.Now;
            new_status_history_entry.ProcurementOrder_Header_RefID = Parameter.ord_drug_order_header.ORD_PRC_ProcurementOrder_HeaderID;
            new_status_history_entry.ProcurementOrder_Status_RefID = new_status.ORD_PRC_ProcurementOrder_StatusID;
            new_status_history_entry.TriggeredAt_Date = DateTime.Now;
            new_status_history_entry.TriggeredBy_BusinessParticipant_RefID = Parameter.created_by_bpt;

            new_status_history_entry.Save(Connection, Transaction);

            var ord_drug_order_position_history_entry = new ORM_ORD_PRC_ProcurementOrder_Position_History();
            ord_drug_order_position_history_entry.Tenant_RefID = securityTicket.TenantID;
            ord_drug_order_position_history_entry.ProcurementOrder_Position_RefID = Parameter.procurement_order_position_id;
            ord_drug_order_position_history_entry.IsRemoved = true;
            ord_drug_order_position_history_entry.Modification_Timestamp = DateTime.Now;

            ord_drug_order_position_history_entry.Save(Connection, Transaction);

            var practice_invoice_universal_property = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
            {
                GlobalPropertyMatchingID = "mm.doc.connect.case.practice.invoice",
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            var practice_invoice_universal_property_value = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
            {
                HEC_CAS_Case_UniversalProperty_RefID = practice_invoice_universal_property.HEC_CAS_Case_UniversalPropertyID,
                HEC_CAS_Case_RefID = Parameter.case_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (practice_invoice_universal_property_value != null)
            {
                practice_invoice_universal_property_value.IsDeleted = true;
                practice_invoice_universal_property_value.Modification_Timestamp = DateTime.Now;

                practice_invoice_universal_property_value.Save(Connection, Transaction);
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_CDO_1250 Invoke(string ConnectionString, P_CAS_CDO_1250 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_CDO_1250 Invoke(DbConnection Connection, P_CAS_CDO_1250 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_CDO_1250 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_CDO_1250 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_CDO_1250 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_CDO_1250 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_CDO_1250 functionReturn = new FR_CAS_CDO_1250();
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

                throw new Exception("Exception occured in method cls_Cancel_Drug_Order", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_CDO_1250 : FR_Base
    {
        public CAS_CDO_1250 Result { get; set; }

        public FR_CAS_CDO_1250() : base() { }

        public FR_CAS_CDO_1250(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_CDO_1250 for attribute P_CAS_CDO_1250
    [DataContract]
    public class P_CAS_CDO_1250
    {
        //Standard type parameters
        [DataMember]
        public ORM_ORD_PRC_ProcurementOrder_Header ord_drug_order_header { get; set; }
        [DataMember]
        public ORM_CMN_Language[] all_languagesL { get; set; }
        [DataMember]
        public Guid created_by_bpt { get; set; }
        [DataMember]
        public Guid procurement_order_position_id { get; set; }
        [DataMember]
        public Guid case_id { get; set; }

    }
    #endregion
    #region SClass CAS_CDO_1250 for attribute CAS_CDO_1250
    [DataContract]
    public class CAS_CDO_1250
    {
        //Standard type parameters
        [DataMember]
        public Guid drug_order_id { get; set; }
        [DataMember]
        public String previous_status { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_CDO_1250 cls_Cancel_Drug_Order(,P_CAS_CDO_1250 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_CDO_1250 invocationResult = cls_Cancel_Drug_Order.Invoke(connectionString,P_CAS_CDO_1250 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_CDO_1250();
parameter.ord_drug_order_header = ...;
parameter.all_languagesL = ...;
parameter.created_by_bpt = ...;
parameter.procurement_order_position_id = ...;
parameter.case_id = ...;

*/
