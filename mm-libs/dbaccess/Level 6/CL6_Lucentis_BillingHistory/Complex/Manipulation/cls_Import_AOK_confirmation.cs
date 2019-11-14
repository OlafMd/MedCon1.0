/* 
 * Generated on 5/19/2014 9:46:41 AM
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
using CL1_BIL;
using CL5_Lucentis_Patient.Atomic.Retrieval;

namespace CL6_Lucentis_BillingHistory.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Import_AOK_confirmation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Import_AOK_confirmation
    {
        public static readonly int QueryTimeout = 6000;

        #region Method Execution
        protected static FR_L6BH_IAOKC_1356 Execute(DbConnection Connection, DbTransaction Transaction, P_L6BH_IAOKC_1356 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L6BH_IAOKC_1356();
            returnValue.Result = new L6BH_IAOKC_1356();
            List<L6BH_IAOKC_1356_ImportedConfirmations> ImportedAOKConfirmList = new List<L6BH_IAOKC_1356_ImportedConfirmations>();
            returnValue.Result.ImportedConfirmations = ImportedAOKConfirmList.ToArray();
            List<int> ProcessNumberDoNotExist = new List<int>();
            returnValue.Result.ProcessNumberDoesNotExist = ProcessNumberDoNotExist.ToArray();
            List<int> ProcessNumberCouldNotBeImported = new List<int>();
            returnValue.Result.ProcessNumberCouldNotBeImported = ProcessNumberCouldNotBeImported.ToArray();
            List<String> ListOfProcessNumbersToSetStatusConfirm = new List<String>();
            List<int> ProcessNumberCouldNotBeChangedBack = new List<int>();
            returnValue.Result.ProcessNumberCouldNotBeChangedBack = ProcessNumberCouldNotBeChangedBack.ToArray();

            var patientList = cls_Get_PatientName_and_BillpositionID.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            foreach (var item in Parameter.ProcessNumberList)
            {
                if (item == String.Empty)
                    continue;
                ListOfProcessNumbersToSetStatusConfirm.Add((Int64.Parse(item) % 10000000000).ToString());
            }
            ListOfProcessNumbersToSetStatusConfirm.RemoveAll(r => String.IsNullOrEmpty(r.Trim()));

            var billPositionQuery = new ORM_BIL_BillPosition.Query();
            billPositionQuery.Tenant_RefID = securityTicket.TenantID;
            billPositionQuery.IsDeleted = false;

            var allbillPositions = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, billPositionQuery).ToArray();

            var activeStatusesQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
            activeStatusesQuery.Tenant_RefID = securityTicket.TenantID;
            activeStatusesQuery.IsDeleted = false;
            activeStatusesQuery.IsActive = true;

            var allActiveStatuss = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, activeStatusesQuery).ToArray();

            foreach (var processNumber in ListOfProcessNumbersToSetStatusConfirm)
            {
                var billPosition = allbillPositions.FirstOrDefault(p => p.External_PositionReferenceField == processNumber);

                if (billPosition != null)
                {
                    var activeStatuss = allActiveStatuss.First(a => a.BillPosition_RefID == billPosition.BIL_BillPositionID);

                    if (activeStatuss.TransmitionCode >= 3)
                    {
                        ProcessNumberCouldNotBeChangedBack.Add(Int32.Parse(processNumber));
                    }
                    else
                    {
                        activeStatuss.IsActive = false;
                        activeStatuss.IsDeleted = true;
                        activeStatuss.Save(Connection, Transaction);

                        //create status 3
                        var transmitionStatus = new ORM_BIL_BillPosition_TransmitionStatus();
                        transmitionStatus.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                        transmitionStatus.BillPosition_RefID = billPosition.BIL_BillPositionID;
                        transmitionStatus.TransmitionCode = 3;
                        transmitionStatus.TransmittedOnDate = DateTime.Now;
                        transmitionStatus.PrimaryComment = "AOK bestätigt";
                        transmitionStatus.SecondaryComment = "AOK bestätigt";
                        transmitionStatus.Tenant_RefID = securityTicket.TenantID;
                        transmitionStatus.Creation_Timestamp = DateTime.Now;
                        transmitionStatus.IsActive = true;
                        transmitionStatus.Save(Connection, Transaction);//save

                        // get Patient first and last name
                        var patient = patientList.Where(p => p.BIL_BillPositionID == billPosition.BIL_BillPositionID).FirstOrDefault(); ;

                        if (patient == null)
                        {
                            ProcessNumberCouldNotBeImported.Add(Int32.Parse(processNumber));
                        }
                        else
                        {
                            L6BH_IAOKC_1356_ImportedConfirmations ImportedConfirmation = new L6BH_IAOKC_1356_ImportedConfirmations();
                            ImportedConfirmation.ProcessNumber = Int32.Parse(processNumber);
                            ImportedConfirmation.Patient = patient.FirstName + " " + patient.LastName;
                            ImportedAOKConfirmList.Add(ImportedConfirmation);
                        }
                    }
                }
                else
                {
                    ProcessNumberDoNotExist.Add(Int32.Parse(processNumber));
                }

            }
            returnValue.Result.ProcessNumberCouldNotBeChangedBack = ProcessNumberCouldNotBeChangedBack.ToArray();
            returnValue.Result.ImportedConfirmations = ImportedAOKConfirmList.ToArray();
            returnValue.Result.ProcessNumberDoesNotExist = ProcessNumberDoNotExist.ToArray();
            returnValue.Result.ProcessNumberCouldNotBeImported = ProcessNumberCouldNotBeImported.ToArray();
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L6BH_IAOKC_1356 Invoke(string ConnectionString, P_L6BH_IAOKC_1356 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L6BH_IAOKC_1356 Invoke(DbConnection Connection, P_L6BH_IAOKC_1356 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L6BH_IAOKC_1356 Invoke(DbConnection Connection, DbTransaction Transaction, P_L6BH_IAOKC_1356 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L6BH_IAOKC_1356 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L6BH_IAOKC_1356 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L6BH_IAOKC_1356 functionReturn = new FR_L6BH_IAOKC_1356();
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

                throw new Exception("Exception occured in method cls_Import_AOK_confirmation", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L6BH_IAOKC_1356 : FR_Base
    {
        public L6BH_IAOKC_1356 Result { get; set; }

        public FR_L6BH_IAOKC_1356() : base() { }

        public FR_L6BH_IAOKC_1356(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L6BH_IAOKC_1356 for attribute P_L6BH_IAOKC_1356
    [DataContract]
    public class P_L6BH_IAOKC_1356
    {
        //Standard type parameters
        [DataMember]
        public string[] ProcessNumberList { get; set; }

    }
    #endregion
    #region SClass L6BH_IAOKC_1356 for attribute L6BH_IAOKC_1356
    [DataContract]
    public class L6BH_IAOKC_1356
    {
        [DataMember]
        public L6BH_IAOKC_1356_ImportedConfirmations[] ImportedConfirmations { get; set; }

        //Standard type parameters
        [DataMember]
        public int[] ProcessNumberDoesNotExist { get; set; }
        [DataMember]
        public int[] ProcessNumberCouldNotBeImported { get; set; }
        [DataMember]
        public int[] ProcessNumberCouldNotBeChangedBack { get; set; }

    }
    #endregion
    #region SClass L6BH_IAOKC_1356_ImportedConfirmations for attribute ImportedConfirmations
    [DataContract]
    public class L6BH_IAOKC_1356_ImportedConfirmations
    {
        //Standard type parameters
        [DataMember]
        public int ProcessNumber { get; set; }
        [DataMember]
        public string Patient { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6BH_IAOKC_1356 cls_Import_AOK_confirmation(,P_L6BH_IAOKC_1356 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6BH_IAOKC_1356 invocationResult = cls_Import_AOK_confirmation.Invoke(connectionString,P_L6BH_IAOKC_1356 Parameter,securityTicket);
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
var parameter = new CL6_Lucentis_BillingHistory.Complex.Manipulation.P_L6BH_IAOKC_1356();
parameter.ProcessNumberList = ...;

*/
