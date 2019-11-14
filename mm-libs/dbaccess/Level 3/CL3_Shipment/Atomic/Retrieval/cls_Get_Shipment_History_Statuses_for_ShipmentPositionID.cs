/* 
 * Generated on 3/5/2015 2:18:10 PM
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

namespace CL3_Shipment.Atomic.Retrieval
{
	/// <summary>
    /// Get_Shipment_History_Statuses_for_ShipmentPositionID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Shipment_History_Statuses_for_ShipmentPositionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Shipment_History_Statuses_for_ShipmentPositionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3S_GSHSfSP_1536_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3S_GSHSfSP_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3S_GSHSfSP_1536_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Shipment.Atomic.Retrieval.SQL.cls_Get_Shipment_History_Statuses_for_ShipmentPositionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderID", Parameter.ShipmentHeaderID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);



			List<L3S_GSHSfSP_1536> results = new List<L3S_GSHSfSP_1536>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_StatusHistoryID","StatusCreationTime","Comment","LOG_SHP_Shipment_StatusID","Status" });
				while(reader.Read())
				{
					L3S_GSHSfSP_1536 resultItem = new L3S_GSHSfSP_1536();
					//0:Parameter LOG_SHP_Shipment_StatusHistoryID of type Guid
					resultItem.LOG_SHP_Shipment_StatusHistoryID = reader.GetGuid(0);
					//1:Parameter StatusCreationTime of type DateTime
					resultItem.StatusCreationTime = reader.GetDate(1);
					//2:Parameter Comment of type string
					resultItem.Comment = reader.GetString(2);
					//3:Parameter LOG_SHP_Shipment_StatusID of type Guid
					resultItem.LOG_SHP_Shipment_StatusID = reader.GetGuid(3);
					//4:Parameter Status of type string
					resultItem.Status = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Shipment_History_Statuses_for_ShipmentPositionID",ex);
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
		public static FR_L3S_GSHSfSP_1536_Array Invoke(string ConnectionString,P_L3S_GSHSfSP_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3S_GSHSfSP_1536_Array Invoke(DbConnection Connection,P_L3S_GSHSfSP_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3S_GSHSfSP_1536_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3S_GSHSfSP_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3S_GSHSfSP_1536_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3S_GSHSfSP_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3S_GSHSfSP_1536_Array functionReturn = new FR_L3S_GSHSfSP_1536_Array();
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

				throw new Exception("Exception occured in method cls_Get_Shipment_History_Statuses_for_ShipmentPositionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3S_GSHSfSP_1536_Array : FR_Base
	{
		public L3S_GSHSfSP_1536[] Result	{ get; set; } 
		public FR_L3S_GSHSfSP_1536_Array() : base() {}

		public FR_L3S_GSHSfSP_1536_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3S_GSHSfSP_1536 for attribute P_L3S_GSHSfSP_1536
		[DataContract]
		public class P_L3S_GSHSfSP_1536 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L3S_GSHSfSP_1536 for attribute L3S_GSHSfSP_1536
		[DataContract]
		public class L3S_GSHSfSP_1536 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_StatusHistoryID { get; set; } 
			[DataMember]
			public DateTime StatusCreationTime { get; set; } 
			[DataMember]
			public string Comment { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_StatusID { get; set; } 
			[DataMember]
			public string Status { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3S_GSHSfSP_1536_Array cls_Get_Shipment_History_Statuses_for_ShipmentPositionID(,P_L3S_GSHSfSP_1536 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3S_GSHSfSP_1536_Array invocationResult = cls_Get_Shipment_History_Statuses_for_ShipmentPositionID.Invoke(connectionString,P_L3S_GSHSfSP_1536 Parameter,securityTicket);
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
var parameter = new CL3_Shipment.Atomic.Retrieval.P_L3S_GSHSfSP_1536();
parameter.ShipmentHeaderID = ...;
parameter.LanguageID = ...;

*/
