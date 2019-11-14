/* 
 * Generated on 7/15/2014 10:07:42 AM
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

namespace CL5_APOLogistic_StockReceipt.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProcurementOrderPosition_ForwardingInstructions_for_PositionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementOrderPosition_ForwardingInstructions_for_PositionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GPOPFIfPId_1033_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GPOPFIfPId_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SR_GPOPFIfPId_1033_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_ProcurementOrderPosition_ForwardingInstructions_for_PositionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PRCPositionID", Parameter.PRCPositionID);



			List<L5SR_GPOPFIfPId_1033> results = new List<L5SR_GPOPFIfPId_1033>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID","QuantityToForward","CMN_BPT_BusinessParticipantID","CompanyName_Line1","ProcurementOrder_Position_RefID" });
				while(reader.Read())
				{
					L5SR_GPOPFIfPId_1033 resultItem = new L5SR_GPOPFIfPId_1033();
					//0:Parameter ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID = reader.GetGuid(0);
					//1:Parameter QuantityToForward of type Double
					resultItem.QuantityToForward = reader.GetDouble(1);
					//2:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(2);
					//3:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(3);
					//4:Parameter ProcurementOrder_Position_RefID of type Guid
					resultItem.ProcurementOrder_Position_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProcurementOrderPosition_ForwardingInstructions_for_PositionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SR_GPOPFIfPId_1033_Array Invoke(string ConnectionString,P_L5SR_GPOPFIfPId_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GPOPFIfPId_1033_Array Invoke(DbConnection Connection,P_L5SR_GPOPFIfPId_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GPOPFIfPId_1033_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GPOPFIfPId_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GPOPFIfPId_1033_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GPOPFIfPId_1033 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GPOPFIfPId_1033_Array functionReturn = new FR_L5SR_GPOPFIfPId_1033_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementOrderPosition_ForwardingInstructions_for_PositionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GPOPFIfPId_1033_Array : FR_Base
	{
		public L5SR_GPOPFIfPId_1033[] Result	{ get; set; } 
		public FR_L5SR_GPOPFIfPId_1033_Array() : base() {}

		public FR_L5SR_GPOPFIfPId_1033_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GPOPFIfPId_1033 for attribute P_L5SR_GPOPFIfPId_1033
		[DataContract]
		public class P_L5SR_GPOPFIfPId_1033 
		{
			//Standard type parameters
			[DataMember]
			public Guid PRCPositionID { get; set; } 

		}
		#endregion
		#region SClass L5SR_GPOPFIfPId_1033 for attribute L5SR_GPOPFIfPId_1033
		[DataContract]
		public class L5SR_GPOPFIfPId_1033 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_Position_ForwardingInstructionID { get; set; } 
			[DataMember]
			public Double QuantityToForward { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public Guid ProcurementOrder_Position_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GPOPFIfPId_1033_Array cls_Get_ProcurementOrderPosition_ForwardingInstructions_for_PositionID(,P_L5SR_GPOPFIfPId_1033 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GPOPFIfPId_1033_Array invocationResult = cls_Get_ProcurementOrderPosition_ForwardingInstructions_for_PositionID.Invoke(connectionString,P_L5SR_GPOPFIfPId_1033 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5SR_GPOPFIfPId_1033();
parameter.PRCPositionID = ...;

*/
