/* 
 * Generated on 7/1/2015 3:14:10 PM
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

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Negative_Cases_Which_Should_Not_be_Imported.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Negative_Cases_Which_Should_Not_be_Imported
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCWSNbI_1511_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCWSNbI_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_CAS_GCWSNbI_1511_Array();
            List<CAS_GCWSNbI_1511> nonEligibleStatuses = new List<CAS_GCWSNbI_1511>(); 
           

            foreach(var item in Parameter.BillNumberArray)
            {
                CAS_GCWSNbI_1511 caseModel = new CAS_GCWSNbI_1511();
                var result = cls_Check_Case_Status_For_BillNumber.Invoke(Connection, Transaction, new P_CAS_GCSFBN_1539 { PositionNumber = item.bullNumber }, securityTicket).Result;

                if (result == null)
                {
                    caseModel.bullNumber = item.bullNumber;
                    nonEligibleStatuses.Add(caseModel);
                }
                else if (result.TransmitionCode != 2 && result.TransmitionCode != 11)
                {
                    caseModel.bullNumber = item.bullNumber;
                    nonEligibleStatuses.Add(caseModel);
                }
                    
            }
            returnValue.Result = nonEligibleStatuses.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GCWSNbI_1511_Array Invoke(string ConnectionString,P_CAS_GCWSNbI_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCWSNbI_1511_Array Invoke(DbConnection Connection,P_CAS_GCWSNbI_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCWSNbI_1511_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCWSNbI_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCWSNbI_1511_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCWSNbI_1511 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCWSNbI_1511_Array functionReturn = new FR_CAS_GCWSNbI_1511_Array();
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

				throw new Exception("Exception occured in method cls_Get_Negative_Cases_Which_Should_Not_be_Imported",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCWSNbI_1511_Array : FR_Base
	{
		public CAS_GCWSNbI_1511[] Result	{ get; set; } 
		public FR_CAS_GCWSNbI_1511_Array() : base() {}

		public FR_CAS_GCWSNbI_1511_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCWSNbI_1511 for attribute P_CAS_GCWSNbI_1511
		[DataContract]
		public class P_CAS_GCWSNbI_1511 
		{
			[DataMember]
			public P_CAS_GCWSNbI_1511_BillNumberArray[] BillNumberArray { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_CAS_GCWSNbI_1511_BillNumberArray for attribute BillNumberArray
		[DataContract]
		public class P_CAS_GCWSNbI_1511_BillNumberArray 
		{
			//Standard type parameters
			[DataMember]
			public string bullNumber { get; set; } 

		}
		#endregion
		#region SClass CAS_GCWSNbI_1511 for attribute CAS_GCWSNbI_1511
		[DataContract]
		public class CAS_GCWSNbI_1511 
		{
			//Standard type parameters
			[DataMember]
			public string bullNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCWSNbI_1511_Array cls_Get_Negative_Cases_Which_Should_Not_be_Imported(,P_CAS_GCWSNbI_1511 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCWSNbI_1511_Array invocationResult = cls_Get_Negative_Cases_Which_Should_Not_be_Imported.Invoke(connectionString,P_CAS_GCWSNbI_1511 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_GCWSNbI_1511();
parameter.BillNumberArray = ...;


*/
