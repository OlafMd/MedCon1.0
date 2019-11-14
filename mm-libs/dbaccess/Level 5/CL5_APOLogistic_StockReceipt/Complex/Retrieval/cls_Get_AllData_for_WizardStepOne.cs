/* 
 * Generated on 2/20/2014 11:43:05 AM
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
using CL5_APOLogistic_StockReceipt.Atomic.Retrieval;

namespace CL5_APOLogistic_StockReceipt.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllData_for_WizardStepOne.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllData_for_WizardStepOne
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GADfWSO_1136 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GADfWSO_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5SR_GADfWSO_1136();
			//Put your code here

            returnValue.Result = new L5SR_GADfWSO_1136();

            returnValue.Result.Positions = cls_Get_LightStockReceiptsPositions_for_HeaderID.
                Invoke(Connection, Transaction, new P_L5ALSR_GLSRPfH_1138 { HeaderID = Parameter.ReceiptHeaderID }, securityTicket).Result;

            returnValue.Result.BasicInfo = cls_Get_BasicInfo_WizardStepOne_for_HeaderID.
                Invoke(Connection, Transaction, new P_L5SR_GBIWSOfH_1131 { HeaderID = Parameter.ReceiptHeaderID }, securityTicket).Result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SR_GADfWSO_1136 Invoke(string ConnectionString,P_L5SR_GADfWSO_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GADfWSO_1136 Invoke(DbConnection Connection,P_L5SR_GADfWSO_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GADfWSO_1136 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GADfWSO_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GADfWSO_1136 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GADfWSO_1136 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GADfWSO_1136 functionReturn = new FR_L5SR_GADfWSO_1136();
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

				throw new Exception("Exception occured in method cls_Get_AllData_for_WizardStepOne",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GADfWSO_1136 : FR_Base
	{
		public L5SR_GADfWSO_1136 Result	{ get; set; }

		public FR_L5SR_GADfWSO_1136() : base() {}

		public FR_L5SR_GADfWSO_1136(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GADfWSO_1136 for attribute P_L5SR_GADfWSO_1136
		[DataContract]
		public class P_L5SR_GADfWSO_1136 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GADfWSO_1136 for attribute L5SR_GADfWSO_1136
		[DataContract]
		public class L5SR_GADfWSO_1136 
		{
			//Standard type parameters
			[DataMember]
			public L5ALSR_GLSRPfH_1138[] Positions { get; set; } 
			[DataMember]
			public L5SR_GBIWSOfH_1131 BasicInfo { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GADfWSO_1136 cls_Get_AllData_for_WizardStepOne(,P_L5SR_GADfWSO_1136 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GADfWSO_1136 invocationResult = cls_Get_AllData_for_WizardStepOne.Invoke(connectionString,P_L5SR_GADfWSO_1136 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Retrieval.P_L5SR_GADfWSO_1136();
parameter.ReceiptHeaderID = ...;

*/
