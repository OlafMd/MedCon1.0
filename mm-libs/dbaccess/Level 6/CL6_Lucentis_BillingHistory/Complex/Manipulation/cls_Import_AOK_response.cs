/* 
 * Generated on 5/19/2014 11:29:50 AM
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

namespace CL6_Lucentis_BillingHistory.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Import_AOK_response.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Import_AOK_response
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L6BH_IAOKR_1652 Execute(DbConnection Connection,DbTransaction Transaction,P_L6BH_IAOKR_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6BH_IAOKR_1652();
            returnValue.Result = new L6BH_IAOKR_1652();
            List<L6BH_IAOKR_1652_ImportedErrors> importedErrorsList= new List<L6BH_IAOKR_1652_ImportedErrors>();
            returnValue.Result.ImportedErrors = importedErrorsList.ToArray();
            List<int> ProcessNumberDoNotExist = new List<int>();
            returnValue.Result.ProcessNumberDoesNotExist = ProcessNumberDoNotExist.ToArray();
            List<int> ProcessNumberCouldNotBeChangedBack = new List<int>();
            returnValue.Result.ProcessNumberCouldNotBeChangedBack = ProcessNumberCouldNotBeChangedBack.ToArray();

            foreach (var edifactFileLocation in Parameter.EdifactFileList.ToList())
            {
                System.IO.StreamReader srInputFile = new System.IO.StreamReader(edifactFileLocation);
                EdifactInterface.Parser edifactFile = new EdifactInterface.Parser(srInputFile);
                var edifactFileList =edifactFile.getParsedPositions();

                foreach(var treatment in edifactFileList)
                {
                    var billPositionQuery = new ORM_BIL_BillPosition.Query();
                    billPositionQuery.Tenant_RefID = securityTicket.TenantID;
                    billPositionQuery.IsDeleted = false;
                    billPositionQuery.External_PositionReferenceField = (Int64.Parse(treatment.strProcessNumber) % 10000000000).ToString();

                    var billPosition = ORM_BIL_BillPosition.Query.Search(Connection, Transaction, billPositionQuery).FirstOrDefault();

                    if (billPosition != null)
                    {
                        //find if there is a higher status then one to be updated
                        var activeStatusesQuery = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                        activeStatusesQuery.Tenant_RefID = securityTicket.TenantID;
                        activeStatusesQuery.BillPosition_RefID = billPosition.BIL_BillPositionID;
                        activeStatusesQuery.IsDeleted = false;
                        activeStatusesQuery.IsActive = true;

                        var activeStatuss = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, activeStatusesQuery).FirstOrDefault();

                        if (activeStatuss.TransmitionCode >= 4)
                        {
                            ProcessNumberCouldNotBeChangedBack.Add(Int32.Parse(treatment.strProcessNumber));
                        }
                        else
                        {
                            activeStatuss.IsActive = false;
                            activeStatuss.IsDeleted = true;
                            activeStatuss.Save(Connection, Transaction);

                            //create status 4
                            var transmitionStatus = new ORM_BIL_BillPosition_TransmitionStatus();
                            transmitionStatus.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                            transmitionStatus.BillPosition_RefID = billPosition.BIL_BillPositionID;
                            transmitionStatus.TransmitionCode = 4;
                            transmitionStatus.TransmittedOnDate = DateTime.Now;
                            transmitionStatus.PrimaryComment = "AOK Fehlermeldung";
                            transmitionStatus.SecondaryComment = treatment.strErrorComment;
                            transmitionStatus.Tenant_RefID = securityTicket.TenantID;
                            transmitionStatus.Creation_Timestamp = DateTime.Now;
                            transmitionStatus.IsActive = true;
                            transmitionStatus.Save(Connection, Transaction);//save

                            L6BH_IAOKR_1652_ImportedErrors errorMessage = new L6BH_IAOKR_1652_ImportedErrors();
                            errorMessage.Comment = treatment.strErrorComment;
                            errorMessage.Patient = treatment.strPatientFirstName + " " + treatment.strPatientLastName;
                            errorMessage.ProcessNumber = Int32.Parse(treatment.strProcessNumber);

                            importedErrorsList.Add(errorMessage);
                        }
                    }
                    else
                    {
                        ProcessNumberDoNotExist.Add(Int32.Parse(treatment.strProcessNumber));
                    }
               }               
            }
            returnValue.Result.ProcessNumberCouldNotBeChangedBack = ProcessNumberCouldNotBeChangedBack.ToArray();
            returnValue.Result.ImportedErrors = importedErrorsList.ToArray();
            returnValue.Result.ProcessNumberDoesNotExist = ProcessNumberDoNotExist.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6BH_IAOKR_1652 Invoke(string ConnectionString,P_L6BH_IAOKR_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6BH_IAOKR_1652 Invoke(DbConnection Connection,P_L6BH_IAOKR_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6BH_IAOKR_1652 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6BH_IAOKR_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6BH_IAOKR_1652 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6BH_IAOKR_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6BH_IAOKR_1652 functionReturn = new FR_L6BH_IAOKR_1652();
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

				throw new Exception("Exception occured in method cls_Import_AOK_response",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6BH_IAOKR_1652 : FR_Base
	{
		public L6BH_IAOKR_1652 Result	{ get; set; }

		public FR_L6BH_IAOKR_1652() : base() {}

		public FR_L6BH_IAOKR_1652(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6BH_IAOKR_1652 for attribute P_L6BH_IAOKR_1652
		[DataContract]
		public class P_L6BH_IAOKR_1652 
		{
			//Standard type parameters
			[DataMember]
			public string[] EdifactFileList { get; set; } 

		}
		#endregion
		#region SClass L6BH_IAOKR_1652 for attribute L6BH_IAOKR_1652
		[DataContract]
		public class L6BH_IAOKR_1652 
		{
			[DataMember]
			public L6BH_IAOKR_1652_ImportedErrors[] ImportedErrors { get; set; }

			//Standard type parameters
			[DataMember]
			public int[] ProcessNumberDoesNotExist { get; set; } 
			[DataMember]
			public int[] ProcessNumberCouldNotBeChangedBack { get; set; } 

		}
		#endregion
		#region SClass L6BH_IAOKR_1652_ImportedErrors for attribute ImportedErrors
		[DataContract]
		public class L6BH_IAOKR_1652_ImportedErrors 
		{
			//Standard type parameters
			[DataMember]
			public int ProcessNumber { get; set; } 
			[DataMember]
			public string Patient { get; set; } 
			[DataMember]
			public string Comment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6BH_IAOKR_1652 cls_Import_AOK_response(,P_L6BH_IAOKR_1652 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6BH_IAOKR_1652 invocationResult = cls_Import_AOK_response.Invoke(connectionString,P_L6BH_IAOKR_1652 Parameter,securityTicket);
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
var parameter = new CL6_Lucentis_BillingHistory.Complex.Manipulation.P_L6BH_IAOKR_1652();
parameter.EdifactFileList = ...;

*/
