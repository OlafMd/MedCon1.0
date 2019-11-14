/* 
 * Generated on 2/13/2017 3:32:31 PM
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
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using CL1_HEC_CAS;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Case_Order_Number_for_OrderIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Case_Order_Number_for_OrderIDs
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_String Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SCONfOID_1442 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_String();
            //Put your code here
            var caseOrderNumber = 00001;
            var lastCaseOrderNumber = cls_Get_Last_Case_Order_Number_for_PracticeBSNR.Invoke(Connection, Transaction, new P_CAS_GLCONfPBSNR_1534
            {
                PracticeBSNR = String.Format("%{0}-%", Parameter.practice_bsnr)
            }, securityTicket).Result;
            if (lastCaseOrderNumber != null)
            {
                caseOrderNumber = lastCaseOrderNumber.CaseOrderNumber + 1;
            }

            var newCaseNumber = String.Format("{0}-{1}", Parameter.practice_bsnr, caseOrderNumber.ToString("D5"));

            var cases = cls_Get_CaseIDs_for_OrderIDs.Invoke(Connection, Transaction, new P_CAS_GCIDsfOIDs_1508
            {
                OrderIDs = Parameter.order_ids
            }, securityTicket).Result;

            foreach (var cas in cases)
            {
                var case_universal_property = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
                {
                    GlobalPropertyMatchingID = ECaseProperty.CaseOrderNumber.Value(),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (case_universal_property == null)
                {
                    case_universal_property = new ORM_HEC_CAS_Case_UniversalProperty();
                    case_universal_property.Tenant_RefID = securityTicket.TenantID;
                    case_universal_property.PropertyName = "Case order number";
                    case_universal_property.IsValue_Boolean = true;
                    case_universal_property.GlobalPropertyMatchingID = ECaseProperty.CaseOrderNumber.Value();
                    case_universal_property.Modification_Timestamp = DateTime.Now;

                    case_universal_property.Save(Connection, Transaction);
                }

                #region parameter value
                var case_universal_property_value = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
                {
                    HEC_CAS_Case_RefID = cas.CaseID,
                    HEC_CAS_Case_UniversalProperty_RefID = case_universal_property.HEC_CAS_Case_UniversalPropertyID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (case_universal_property_value == null)
                {
                    case_universal_property_value = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                    case_universal_property_value.Tenant_RefID = securityTicket.TenantID;
                    case_universal_property_value.HEC_CAS_Case_RefID = cas.CaseID;
                    case_universal_property_value.HEC_CAS_Case_UniversalProperty_RefID = case_universal_property.HEC_CAS_Case_UniversalPropertyID;
                }
                case_universal_property_value.Modification_Timestamp = DateTime.Now;
                case_universal_property_value.Value_String = newCaseNumber;

                case_universal_property_value.Save(Connection, Transaction);
            }
                #endregion

            returnValue.Result = newCaseNumber;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_String Invoke(string ConnectionString, P_CAS_SCONfOID_1442 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection, P_CAS_SCONfOID_1442 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SCONfOID_1442 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_String Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SCONfOID_1442 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_String functionReturn = new FR_String();
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

                throw new Exception("Exception occured in method cls_Save_Case_Order_Number_for_OrderIDs", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SCONfOID_1442 for attribute P_CAS_SCONfOID_1442
    [DataContract]
    public class P_CAS_SCONfOID_1442
    {
        //Standard type parameters
        [DataMember]
        public Guid[] order_ids { get; set; }
        [DataMember]
        public String practice_bsnr { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_String cls_Save_Case_Order_Number_for_OrderIDs(,P_CAS_SCONfOID_1442 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_String invocationResult = cls_Save_Case_Order_Number_for_OrderIDs.Invoke(connectionString,P_CAS_SCONfOID_1442 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SCONfOID_1442();
parameter.order_ids = ...;
parameter.practice_bsnr = ...;

*/
