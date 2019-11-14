/* 
 * Generated on 09/13/16 14:00:51
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
using CL1_HEC_CAS;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Case_Property.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Case_Property
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SCP_1308 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            var caseProperty = ORM_HEC_CAS_Case_UniversalProperty.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalProperty.Query()
            {
                GlobalPropertyMatchingID = Parameter.property_gpm_id,
                PropertyName = Parameter.property_name,
                Tenant_RefID = securityTicket.TenantID,
                IsValue_Boolean = Parameter.property_boolean_value.HasValue,
                IsValue_Number = Parameter.property_numeric_value.HasValue,
                IsValue_String = !String.IsNullOrEmpty(Parameter.property_string_value),
                IsDeleted = false
            }).SingleOrDefault();

            if (caseProperty == null)
            {
                caseProperty = new ORM_HEC_CAS_Case_UniversalProperty()
                {
                    IsValue_Boolean = Parameter.property_boolean_value.HasValue,
                    IsValue_Number = Parameter.property_numeric_value.HasValue,
                    IsValue_String = !String.IsNullOrEmpty(Parameter.property_string_value),
                    GlobalPropertyMatchingID = Parameter.property_gpm_id,
                    Modification_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                    PropertyName = Parameter.property_name
                };

                caseProperty.Save(Connection, Transaction);
            }

            var casePropertyValue = ORM_HEC_CAS_Case_UniversalPropertyValue.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_UniversalPropertyValue.Query()
            {
                HEC_CAS_Case_RefID = Parameter.case_id,
                HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (casePropertyValue == null)
            {
                casePropertyValue = new ORM_HEC_CAS_Case_UniversalPropertyValue();
                casePropertyValue.HEC_CAS_Case_RefID = Parameter.case_id;
                casePropertyValue.HEC_CAS_Case_UniversalProperty_RefID = caseProperty.HEC_CAS_Case_UniversalPropertyID;
                casePropertyValue.Tenant_RefID = securityTicket.TenantID;
            }

            casePropertyValue.Modification_Timestamp = DateTime.Now;
            casePropertyValue.Value_Boolean = Parameter.property_boolean_value.HasValue ? Parameter.property_boolean_value.Value : false;
            casePropertyValue.Value_Number = Parameter.property_numeric_value.HasValue ? Parameter.property_numeric_value.Value : 0;
            casePropertyValue.Value_String = !String.IsNullOrEmpty(Parameter.property_string_value) ? Parameter.property_string_value : null;

            casePropertyValue.Save(Connection, Transaction);
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_SCP_1308 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_SCP_1308 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SCP_1308 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SCP_1308 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Case_Property", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SCP_1308 for attribute P_CAS_SCP_1308
    [DataContract]
    public class P_CAS_SCP_1308
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public String property_name { get; set; }
        [DataMember]
        public String property_gpm_id { get; set; }
        [DataMember]
        public Double? property_numeric_value { get; set; }
        [DataMember]
        public String property_string_value { get; set; }
        [DataMember]
        public Boolean? property_boolean_value { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Case_Property(,P_CAS_SCP_1308 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Case_Property.Invoke(connectionString,P_CAS_SCP_1308 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SCP_1308();
parameter.case_id = ...;
parameter.property_name = ...;
parameter.property_gpm_id = ...;
parameter.property_numeric_value = ...;
parameter.property_string_value = ...;
parameter.property_boolean_value = ...;

*/
