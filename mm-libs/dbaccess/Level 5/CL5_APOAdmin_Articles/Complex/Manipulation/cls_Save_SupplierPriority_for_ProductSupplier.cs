/* 
 * Generated on 7/4/2014 5:00:21 PM
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
using CL1_CMN_PRO;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_Articles.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_SupplierPriority_for_ProductSupplier.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_SupplierPriority_for_ProductSupplier
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_String Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_SSPfPS_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
            #region UserCode 
            var returnValue = new FR_String();

            for (int i = 0; i < Parameter.Priorities.Count(); i++)
            {
                var productSupplier = new ORM_CMN_PRO_Product_Supplier();

                if (Parameter.Priorities[i].Product_SupplierID != Guid.Empty)
                {
                    var fetched = productSupplier.Load(Connection, Transaction, Parameter.Priorities[i].Product_SupplierID);
                    if (fetched.Status == FR_Status.Success)
                    {
                        productSupplier.SupplierPriority = Parameter.Priorities[i].SupplierPriority;
                        productSupplier.Save(Connection, Transaction);
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
        public static FR_String Invoke(string ConnectionString,P_L5AR_SSPfPS_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString,Parameter,securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection,P_L5AR_SSPfPS_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_SSPfPS_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null,Parameter,securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_String Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_SSPfPS_1335 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_SupplierPriority_for_ProductSupplier",ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
        #region SClass P_L5AR_SSPfPS_1335 for attribute P_L5AR_SSPfPS_1335
        [DataContract]
        public class P_L5AR_SSPfPS_1335 
        {
            [DataMember]
            public P_L5AR_SSP_f_PS_1335a[] Priorities { get; set; }

            //Standard type parameters
        }
        #endregion
        #region SClass P_L5AR_SSP_f_PS_1335a for attribute Priorities
        [DataContract]
        public class P_L5AR_SSP_f_PS_1335a 
        {
            //Standard type parameters
            [DataMember]
            public Guid Product_SupplierID { get; set; } 
            [DataMember]
            public int SupplierPriority { get; set; } 

        }
        #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_String cls_Save_SupplierPriority_for_ProductSupplier(,P_L5AR_SSPfPS_1335 Parameter, string sessionToken = null)
{
    try
    {
        var securityTicket = Verify(sessionToken);
        FR_String invocationResult = cls_Save_SupplierPriority_for_ProductSupplier.Invoke(connectionString,P_L5AR_SSPfPS_1335 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Manipulation.P_L5AR_SSPfPS_1335();
parameter.Priorities = ...;


*/
