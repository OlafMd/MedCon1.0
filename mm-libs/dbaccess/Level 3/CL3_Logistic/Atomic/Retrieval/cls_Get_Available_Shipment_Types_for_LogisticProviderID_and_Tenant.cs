/* 
 * Generated on 12/23/2014 11:37:23 AM
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

namespace CL3_Logistic.Atomic.Retrieval
{
	/// <summary>
    /// Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3L_GASTfLPaT_1629_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3L_GASTfLPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3L_GASTfLPaT_1629_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Logistic.Atomic.Retrieval.SQL.cls_Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LogisticProviderID", Parameter.LogisticProviderID);



			List<L3L_GASTfLPaT_1629> results = new List<L3L_GASTfLPaT_1629>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_AvailableShipmentTypeID","IsPrimaryShipmentType","ShipmentType_Name_DictID","ShipmentType_Description_DictID" });
				while(reader.Read())
				{
					L3L_GASTfLPaT_1629 resultItem = new L3L_GASTfLPaT_1629();
					//0:Parameter CMN_BPT_AvailableShipmentTypeID of type Guid
					resultItem.CMN_BPT_AvailableShipmentTypeID = reader.GetGuid(0);
					//1:Parameter IsPrimaryShipmentType of type bool
					resultItem.IsPrimaryShipmentType = reader.GetBoolean(1);
					//2:Parameter ShipmentType_Name of type Dict
					resultItem.ShipmentType_Name = reader.GetDictionary(2);
					resultItem.ShipmentType_Name.SourceTable = "log_shp_shipment_types";
					loader.Append(resultItem.ShipmentType_Name);
					//3:Parameter ShipmentType_Description of type Dict
					resultItem.ShipmentType_Description = reader.GetDictionary(3);
					resultItem.ShipmentType_Description.SourceTable = "log_shp_shipment_types";
					loader.Append(resultItem.ShipmentType_Description);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant",ex);
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
		public static FR_L3L_GASTfLPaT_1629_Array Invoke(string ConnectionString,P_L3L_GASTfLPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3L_GASTfLPaT_1629_Array Invoke(DbConnection Connection,P_L3L_GASTfLPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3L_GASTfLPaT_1629_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3L_GASTfLPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3L_GASTfLPaT_1629_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3L_GASTfLPaT_1629 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3L_GASTfLPaT_1629_Array functionReturn = new FR_L3L_GASTfLPaT_1629_Array();
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

				throw new Exception("Exception occured in method cls_Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3L_GASTfLPaT_1629_Array : FR_Base
	{
		public L3L_GASTfLPaT_1629[] Result	{ get; set; } 
		public FR_L3L_GASTfLPaT_1629_Array() : base() {}

		public FR_L3L_GASTfLPaT_1629_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3L_GASTfLPaT_1629 for attribute P_L3L_GASTfLPaT_1629
		[DataContract]
		public class P_L3L_GASTfLPaT_1629 
		{
			//Standard type parameters
			[DataMember]
			public Guid LogisticProviderID { get; set; } 

		}
		#endregion
		#region SClass L3L_GASTfLPaT_1629 for attribute L3L_GASTfLPaT_1629
		[DataContract]
		public class L3L_GASTfLPaT_1629 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_AvailableShipmentTypeID { get; set; } 
			[DataMember]
			public bool IsPrimaryShipmentType { get; set; } 
			[DataMember]
			public Dict ShipmentType_Name { get; set; } 
			[DataMember]
			public Dict ShipmentType_Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3L_GASTfLPaT_1629_Array cls_Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant(,P_L3L_GASTfLPaT_1629 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3L_GASTfLPaT_1629_Array invocationResult = cls_Get_Available_Shipment_Types_for_LogisticProviderID_and_Tenant.Invoke(connectionString,P_L3L_GASTfLPaT_1629 Parameter,securityTicket);
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
var parameter = new CL3_Logistic.Atomic.Retrieval.P_L3L_GASTfLPaT_1629();
parameter.LogisticProviderID = ...;

*/
