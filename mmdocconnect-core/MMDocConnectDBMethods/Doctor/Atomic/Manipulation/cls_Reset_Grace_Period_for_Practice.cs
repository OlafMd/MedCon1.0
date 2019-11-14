/* 
 * Generated on 2/10/2017 3:45:00 PM
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
using CL1_HEC;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Model;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Doctor.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Reset_Grace_Period_for_Practice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Reset_Grace_Period_for_Practice
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Bool Execute(DbConnection Connection, DbTransaction Transaction, P_DO_RGPfP_1544 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Bool();
            //Put your code here

            var allDoctorsFromPractice = cls_Get_DoctorIDs_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GDIDsfPID_1635
            {
                PracticeID = Parameter.PracticeID
            }, securityTicket).Result;

            foreach (var doctor in allDoctorsFromPractice)
            {
                cls_Save_Doctor_Grace_Period.Invoke(Connection, Transaction, new P_DO_SDGP_1639 { DoctorID = doctor.DoctorID, ResetGracePeriod = true }, securityTicket);
            }

            cls_Save_Practice_Grace_Period.Invoke(Connection, Transaction, new P_DO_SPGP_0942 { PracticeID = Parameter.PracticeID, ResetGracePeriod = true }, securityTicket);

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Bool Invoke(string ConnectionString, P_DO_RGPfP_1544 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, P_DO_RGPfP_1544 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, P_DO_RGPfP_1544 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_DO_RGPfP_1544 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Bool functionReturn = new FR_Bool();
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

                throw new Exception("Exception occured in method cls_Reset_Grace_Period_for_Practice", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_DO_RGPfP_1544 for attribute P_DO_RGPfP_1544
    [DataContract]
    public class P_DO_RGPfP_1544
    {
        //Standard type parameters
        [DataMember]
        public Guid PracticeID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Reset_Grace_Period_for_Practice(,P_DO_RGPfP_1544 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Reset_Grace_Period_for_Practice.Invoke(connectionString,P_DO_RGPfP_1544 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Manipulation.P_DO_RGPfP_1544();
parameter.PracticeID = ...;

*/
