/* 
 * Generated on 2/7/2017 4:56:29 PM
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
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using System.Configuration;
using MMDocConnectDBMethods.Doctor.Atomic.Manipulation;

namespace MMDocConnectDBMethods.Doctor.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Grace_Period.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Grace_Period
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_DO_SGP_1655 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();

            #region save grace period
            Func<DbConnection, DbTransaction, CSV2Core.SessionSecurity.SessionSecurityTicket, Boolean, Guid, Guid, Boolean> SaveGracePeriod = (connection, transaction, secTicket, isDoctor, doctorID, practiceID) =>
            {
                if (isDoctor)
                {
                    return cls_Save_Doctor_Grace_Period.Invoke(connection, transaction, new P_DO_SDGP_1639
                    {
                        DoctorID = doctorID
                    }, secTicket).Result;
                }
                else
                {
                    return cls_Save_Practice_Grace_Period.Invoke(connection, transaction, new P_DO_SPGP_0942
                    {
                        PracticeID = practiceID
                    }, secTicket).Result;
                }
            };
            #endregion

            var accountInfo = cls_Get_Account_Information_with_PracticeID.Invoke(Connection, Transaction, securityTicket).Result;

            var useGracePeriod = false;
            var gracePeriodProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = accountInfo.PracticeID,
                PropertyName = "Grace period"
            }, securityTicket).Result;
            if (gracePeriodProperty != null)
            {
                useGracePeriod = gracePeriodProperty.BooleanValue;
            }

            var isQuickOrderActice = false;
            var quickOrderProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = accountInfo.PracticeID,
                PropertyName = "Quick order"
            }, securityTicket).Result;
            if (gracePeriodProperty != null)
            {
                isQuickOrderActice = quickOrderProperty.BooleanValue;
            }

            var gracePeriodDuration = Convert.ToInt32(ConfigurationManager.AppSettings["gracePeriodDuration"]);
            var autoRenewalWithQuickOrder = Boolean.Parse(ConfigurationManager.AppSettings["autoRenewalWithQuickOrder"]);

            if (useGracePeriod && isQuickOrderActice)
            {

                #region Get last saved grace period time
                var lastSavedGracePeriodTime = DateTime.MinValue;
                if (Parameter.IsDoctor)
                {
                    var doctororGracePeriod = cls_Get_Doctor_Grace_Period_Start_Time.Invoke(Connection, Transaction, new P_DO_GDGPST_1706
                    {
                        DoctorID = accountInfo.DoctorID
                    }, securityTicket).Result;
                    lastSavedGracePeriodTime = doctororGracePeriod != null ? DateTime.Parse(doctororGracePeriod.PeriodStartAt) : DateTime.MinValue;
                }
                else
                {
                    var practiceGracePeriod = cls_Get_Practice_Grace_Period_Start_Time.Invoke(Connection, Transaction, new P_DO_GPGPST_0959
                    {
                        PracticeID = accountInfo.PracticeID
                    }, securityTicket).Result;
                    lastSavedGracePeriodTime = practiceGracePeriod != null ? DateTime.Parse(practiceGracePeriod.PeriodStartAt) : DateTime.MinValue;
                }
                #endregion

                if (lastSavedGracePeriodTime != DateTime.MinValue && lastSavedGracePeriodTime.AddMinutes(gracePeriodDuration) >= DateTime.Now)
                {
                    if (autoRenewalWithQuickOrder)
                    {
                        SaveGracePeriod(Connection, Transaction, securityTicket, Parameter.IsDoctor, accountInfo.DoctorID, accountInfo.PracticeID);
                    }
                }
                else
                {
                    SaveGracePeriod(Connection, Transaction, securityTicket, Parameter.IsDoctor, accountInfo.DoctorID, accountInfo.PracticeID);
                }
            }

            //Put your code here
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_DO_SGP_1655 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_DO_SGP_1655 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_DO_SGP_1655 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_DO_SGP_1655 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Grace_Period", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_DO_SGP_1655 for attribute P_DO_SGP_1655
    [DataContract]
    public class P_DO_SGP_1655
    {
        //Standard type parameters
        [DataMember]
        public Boolean IsDoctor { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Grace_Period(,P_DO_SGP_1655 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Grace_Period.Invoke(connectionString,P_DO_SGP_1655 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Complex.Manipulation.P_DO_SGP_1655();
parameter.IsDoctor = ...;

*/
