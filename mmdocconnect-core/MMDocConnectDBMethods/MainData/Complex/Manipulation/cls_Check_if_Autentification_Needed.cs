/* 
 * Generated on 2/8/2017 1:31:11 PM
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
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using System.Configuration;

namespace MMDocConnectDBMethods.MainData.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Check_if_Autentification_Needed.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Check_if_Autentification_Needed
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Bool Execute(DbConnection Connection, DbTransaction Transaction, P_MD_CiAN_1313 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Bool();
            //Put your code here

            var isQuickOrderActive = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = Parameter.PracticeID,
                PropertyName = "Quick order"
            }, securityTicket).Result;

            if (isQuickOrderActive != null && isQuickOrderActive.BooleanValue)
            {
                #region Get last saved grace period time
                var gracePeriodDuration = Convert.ToInt32(ConfigurationManager.AppSettings["gracePeriodDuration"]);

                var lastSavedGracePeriodTime = DateTime.MinValue;
                if (!Parameter.isPractice)
                {
                    var doctororGracePeriod = cls_Get_Doctor_Grace_Period_Start_Time.Invoke(Connection, Transaction, new P_DO_GDGPST_1706
                    {
                        DoctorID = Parameter.DoctorID
                    }, securityTicket).Result;
                    lastSavedGracePeriodTime = doctororGracePeriod != null ? DateTime.Parse(doctororGracePeriod.PeriodStartAt) : DateTime.MinValue;
                }
                else
                {
                    var practiceGracePeriod = cls_Get_Practice_Grace_Period_Start_Time.Invoke(Connection, Transaction, new P_DO_GPGPST_0959
                    {
                        PracticeID = Parameter.PracticeID
                    }, securityTicket).Result;
                    lastSavedGracePeriodTime = practiceGracePeriod != null ? DateTime.Parse(practiceGracePeriod.PeriodStartAt) : DateTime.MinValue;
                }
                #endregion

                if (lastSavedGracePeriodTime == DateTime.MinValue || lastSavedGracePeriodTime.AddMinutes(gracePeriodDuration) < DateTime.Now)
                {
                    returnValue.Result = true;
                }
                else
                {
                    returnValue.Result = false;
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
        public static FR_Bool Invoke(string ConnectionString, P_MD_CiAN_1313 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, P_MD_CiAN_1313 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, P_MD_CiAN_1313 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_MD_CiAN_1313 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Check_if_Autentification_Needed", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_MD_CiAN_1313 for attribute P_MD_CiAN_1313
    [DataContract]
    public class P_MD_CiAN_1313
    {
        //Standard type parameters
        [DataMember]
        public Guid PracticeID { get; set; }
        [DataMember]
        public Guid DoctorID { get; set; }
        [DataMember]
        public Boolean isPractice { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Check_if_Autentification_Needed(,P_MD_CiAN_1313 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Check_if_Autentification_Needed.Invoke(connectionString,P_MD_CiAN_1313 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Complex.Manipulation.P_MD_CiAN_1313();
parameter.PracticeID = ...;
parameter.DoctorID = ...;
parameter.isPractice = ...;

*/
