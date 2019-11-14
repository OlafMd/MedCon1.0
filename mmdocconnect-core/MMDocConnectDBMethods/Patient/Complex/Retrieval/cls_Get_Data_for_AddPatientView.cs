/* 
 * Generated on 5/26/2015 3:48:50 PM
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
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;

namespace MMDocConnectDBMethods.Patient.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Data_for_AddPatientView.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Data_for_AddPatientView
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_PA_GDAPV_1629 Execute(DbConnection Connection, DbTransaction Transaction, P_PA_GDAPV_1629 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_PA_GDAPV_1629();
            returnValue.Result = new PA_GDAPV_1629();
            List<PA_GDAPV_1629_Contracts> ContractList = new List<PA_GDAPV_1629_Contracts>();


            if (Parameter.isPracticeLoggedIn)
            {
                var data = cls_Get_AllContracts_for_Practice_Doctors.Invoke(Connection, Transaction, new P_DO_GACfPD_1252 { PracticeID = Parameter.ID }, securityTicket).Result;
                if (data.Length != 0)
                {
                    data = data.Where(d => d.ValidThrough == DateTime.MinValue || d.ValidThrough > DateTime.Now.Date).ToArray();
                }

                foreach (var item in data)
                {
                    PA_GDAPV_1629_Contracts contract = new PA_GDAPV_1629_Contracts();
                    contract.ID = item.CMN_CTR_ContractID;
                    contract.Name = item.ContractName;
                    contract.ValidFrom = item.ValidFrom;
                    contract.ValidThrough = item.ValidThrough;
                    contract.participation_consent_valid_days = item.participation_consent_valid_days;
                    if (ContractList.Where(i => i.ID == contract.ID).FirstOrDefault() == null)
                        ContractList.Add(contract);
                }
            }
            else
            {
                var data = cls_Get_AllContracts_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GACDID_1320 { DoctorID = Parameter.ID }, securityTicket).Result;
                if (data.Length != 0)
                {
                    data = data.Where(d => d.ValidThrough == DateTime.MinValue || d.ValidThrough > DateTime.Now.Date).ToArray();
                }

                foreach (var item in data)
                {
                    PA_GDAPV_1629_Contracts contract = new PA_GDAPV_1629_Contracts();
                    contract.ID = item.CMN_CTR_ContractID;
                    contract.Name = item.ContractName;
                    contract.ValidFrom = item.ValidFrom;
                    contract.ValidThrough = item.ValidThrough;
                    contract.participation_consent_valid_days = item.participation_consent_valid_days;
                    if (ContractList.Where(i => i.ID == contract.ID).FirstOrDefault() == null)
                        ContractList.Add(contract);
                }
            }

            if (ContractList.Count != 0)
            {
                returnValue.Result.HealthInsuranceProviders = cls_Get_AllHealthInsuranceProviders.Invoke(Connection, Transaction, new P_PA_GAHIP_1223()
                {
                    ContractIDs = ContractList.Select(ctr => ctr.ID).ToArray()
                }, securityTicket).Result;
            }
            else
            {
                returnValue.Result.HealthInsuranceProviders = new PA_GAHIP_1223[] { };
            }

            returnValue.Result.Contracts = ContractList.ToArray();
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_PA_GDAPV_1629 Invoke(string ConnectionString, P_PA_GDAPV_1629 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_PA_GDAPV_1629 Invoke(DbConnection Connection, P_PA_GDAPV_1629 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_PA_GDAPV_1629 Invoke(DbConnection Connection, DbTransaction Transaction, P_PA_GDAPV_1629 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_PA_GDAPV_1629 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_PA_GDAPV_1629 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_PA_GDAPV_1629 functionReturn = new FR_PA_GDAPV_1629();
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

                throw new Exception("Exception occured in method cls_Get_Data_for_AddPatientView", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_PA_GDAPV_1629 : FR_Base
    {
        public PA_GDAPV_1629 Result { get; set; }

        public FR_PA_GDAPV_1629() : base() { }

        public FR_PA_GDAPV_1629(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_PA_GDAPV_1629 for attribute P_PA_GDAPV_1629
    [DataContract]
    public class P_PA_GDAPV_1629
    {
        //Standard type parameters
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public bool isPracticeLoggedIn { get; set; }

    }
    #endregion
    #region SClass PA_GDAPV_1629 for attribute PA_GDAPV_1629
    [DataContract]
    public class PA_GDAPV_1629
    {
        [DataMember]
        public PA_GDAPV_1629_Contracts[] Contracts { get; set; }

        //Standard type parameters
        [DataMember]
        public PA_GAHIP_1223[] HealthInsuranceProviders { get; set; }

    }
    #endregion
    #region SClass PA_GDAPV_1629_Contracts for attribute Contracts
    [DataContract]
    public class PA_GDAPV_1629_Contracts
    {
        //Standard type parameters
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public DateTime ValidFrom { get; set; }
        [DataMember]
        public DateTime ValidThrough { get; set; }
        [DataMember]
        public double participation_consent_valid_days { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GDAPV_1629 cls_Get_Data_for_AddPatientView(,P_PA_GDAPV_1629 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GDAPV_1629 invocationResult = cls_Get_Data_for_AddPatientView.Invoke(connectionString,P_PA_GDAPV_1629 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Complex.Retrieval.P_PA_GDAPV_1629();
parameter.ID = ...;
parameter.isPracticeLoggedIn = ...;

*/
