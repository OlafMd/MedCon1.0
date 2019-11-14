/* 
 * Generated on 06/01/15 09:51:20
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DrugOrderIDs_for_PlannedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DrugOrderIDs_for_PlannedActionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GDOIDsfPAID_1243 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GDOIDsfPAID_1243 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GDOIDsfPAID_1243();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_DrugOrderIDs_for_PlannedActionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PlannedActionID", Parameter.PlannedActionID);



			List<CAS_GDOIDsfPAID_1243> results = new List<CAS_GDOIDsfPAID_1243>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Ext_ORD_PRC_ProcurementOrder_Position_RefID","HEC_PRC_ProcurementOrder_PositionID","HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID","ORD_PRC_ProcurementOrder_HeaderID","Current_ProcurementOrderStatus_RefID","HEC_ACT_PlannedAction_PotentialProcedureID" });
				while(reader.Read())
				{
					CAS_GDOIDsfPAID_1243 resultItem = new CAS_GDOIDsfPAID_1243();
					//0:Parameter Ext_ORD_PRC_ProcurementOrder_Position_RefID of type Guid
					resultItem.Ext_ORD_PRC_ProcurementOrder_Position_RefID = reader.GetGuid(0);
					//1:Parameter HEC_PRC_ProcurementOrder_PositionID of type Guid
					resultItem.HEC_PRC_ProcurementOrder_PositionID = reader.GetGuid(1);
					//2:Parameter HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID of type Guid
					resultItem.HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID = reader.GetGuid(2);
					//3:Parameter ORD_PRC_ProcurementOrder_HeaderID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_HeaderID = reader.GetGuid(3);
					//4:Parameter Current_ProcurementOrderStatus_RefID of type Guid
					resultItem.Current_ProcurementOrderStatus_RefID = reader.GetGuid(4);
					//5:Parameter HEC_ACT_PlannedAction_PotentialProcedureID of type Guid
					resultItem.HEC_ACT_PlannedAction_PotentialProcedureID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DrugOrderIDs_for_PlannedActionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GDOIDsfPAID_1243 Invoke(string ConnectionString,P_CAS_GDOIDsfPAID_1243 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GDOIDsfPAID_1243 Invoke(DbConnection Connection,P_CAS_GDOIDsfPAID_1243 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GDOIDsfPAID_1243 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GDOIDsfPAID_1243 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GDOIDsfPAID_1243 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GDOIDsfPAID_1243 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GDOIDsfPAID_1243 functionReturn = new FR_CAS_GDOIDsfPAID_1243();
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

				throw new Exception("Exception occured in method cls_Get_DrugOrderIDs_for_PlannedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GDOIDsfPAID_1243 : FR_Base
	{
		public CAS_GDOIDsfPAID_1243 Result	{ get; set; }

		public FR_CAS_GDOIDsfPAID_1243() : base() {}

		public FR_CAS_GDOIDsfPAID_1243(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GDOIDsfPAID_1243 for attribute P_CAS_GDOIDsfPAID_1243
		[DataContract]
		public class P_CAS_GDOIDsfPAID_1243 
		{
			//Standard type parameters
			[DataMember]
			public Guid PlannedActionID { get; set; } 

		}
		#endregion
		#region SClass CAS_GDOIDsfPAID_1243 for attribute CAS_GDOIDsfPAID_1243
		[DataContract]
		public class CAS_GDOIDsfPAID_1243 
		{
			//Standard type parameters
			[DataMember]
			public Guid Ext_ORD_PRC_ProcurementOrder_Position_RefID { get; set; } 
			[DataMember]
			public Guid HEC_PRC_ProcurementOrder_PositionID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_HeaderID { get; set; } 
			[DataMember]
			public Guid Current_ProcurementOrderStatus_RefID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PlannedAction_PotentialProcedureID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GDOIDsfPAID_1243 cls_Get_DrugOrderIDs_for_PlannedActionID(,P_CAS_GDOIDsfPAID_1243 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GDOIDsfPAID_1243 invocationResult = cls_Get_DrugOrderIDs_for_PlannedActionID.Invoke(connectionString,P_CAS_GDOIDsfPAID_1243 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GDOIDsfPAID_1243();
parameter.PlannedActionID = ...;

*/
