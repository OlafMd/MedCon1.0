/* 
 * Generated on 12/17/2014 7:59:28 PM
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

namespace CL3_LogisticProvider.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LogisticProviders_For_ShipmentType.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LogisticProviders_For_ShipmentType
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3LP_GLPfST_1348_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3LP_GLPfST_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3LP_GLPfST_1348_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_LogisticProvider.Atomic.Retrieval.SQL.cls_Get_LogisticProviders_For_ShipmentType.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentTypeID", Parameter.ShipmentTypeID);



			List<L3LP_GLPfST_1348> results = new List<L3LP_GLPfST_1348>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_LogisticsProviderID","IsProviding_TransportServices","IsTrackingAvailable","DisplayName" });
				while(reader.Read())
				{
					L3LP_GLPfST_1348 resultItem = new L3LP_GLPfST_1348();
					//0:Parameter LOG_LogisticsProviderID of type Guid
					resultItem.LOG_LogisticsProviderID = reader.GetGuid(0);
					//1:Parameter IsProviding_TransportServices of type bool
					resultItem.IsProviding_TransportServices = reader.GetBoolean(1);
					//2:Parameter IsTrackingAvailable of type bool
					resultItem.IsTrackingAvailable = reader.GetBoolean(2);
					//3:Parameter DisplayName of type string
					resultItem.DisplayName = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_LogisticProviders_For_ShipmentType",ex);
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
		public static FR_L3LP_GLPfST_1348_Array Invoke(string ConnectionString,P_L3LP_GLPfST_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3LP_GLPfST_1348_Array Invoke(DbConnection Connection,P_L3LP_GLPfST_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3LP_GLPfST_1348_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3LP_GLPfST_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3LP_GLPfST_1348_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3LP_GLPfST_1348 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3LP_GLPfST_1348_Array functionReturn = new FR_L3LP_GLPfST_1348_Array();
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

				throw new Exception("Exception occured in method cls_Get_LogisticProviders_For_ShipmentType",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3LP_GLPfST_1348_Array : FR_Base
	{
		public L3LP_GLPfST_1348[] Result	{ get; set; } 
		public FR_L3LP_GLPfST_1348_Array() : base() {}

		public FR_L3LP_GLPfST_1348_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3LP_GLPfST_1348 for attribute P_L3LP_GLPfST_1348
		[DataContract]
		public class P_L3LP_GLPfST_1348 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentTypeID { get; set; } 

		}
		#endregion
		#region SClass L3LP_GLPfST_1348 for attribute L3LP_GLPfST_1348
		[DataContract]
		public class L3LP_GLPfST_1348 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_LogisticsProviderID { get; set; } 
			[DataMember]
			public bool IsProviding_TransportServices { get; set; } 
			[DataMember]
			public bool IsTrackingAvailable { get; set; } 
			[DataMember]
			public string DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3LP_GLPfST_1348_Array cls_Get_LogisticProviders_For_ShipmentType(,P_L3LP_GLPfST_1348 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3LP_GLPfST_1348_Array invocationResult = cls_Get_LogisticProviders_For_ShipmentType.Invoke(connectionString,P_L3LP_GLPfST_1348 Parameter,securityTicket);
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
var parameter = new CL3_LogisticProvider.Atomic.Retrieval.P_L3LP_GLPfST_1348();
parameter.ShipmentTypeID = ...;

*/
