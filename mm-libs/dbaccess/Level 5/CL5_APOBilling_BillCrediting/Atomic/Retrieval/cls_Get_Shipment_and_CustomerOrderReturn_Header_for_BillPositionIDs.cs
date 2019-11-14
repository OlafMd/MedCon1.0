/* 
 * Generated on 8/5/2014 3:58:08 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOBilling_BillCrediting.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BC_GSaCORHfCP_1109_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BC_GSaCORHfCP_1109 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BC_GSaCORHfCP_1109_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_BillCrediting.Atomic.Retrieval.SQL.cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@BillPositionIDs"," IN $$BillPositionIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$BillPositionIDs$",Parameter.BillPositionIDs);


			List<L5BC_GSaCORHfCP_1109> results = new List<L5BC_GSaCORHfCP_1109>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BIL_BillPositionID","LOG_SHP_Shipment_HeaderID","ShipmentHeader_Number","ORD_CUO_CustomerOrderReturn_HeaderID","CustomerOrderReturnNumber" });
				while(reader.Read())
				{
					L5BC_GSaCORHfCP_1109 resultItem = new L5BC_GSaCORHfCP_1109();
					//0:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(1);
					//2:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(2);
					//3:Parameter ORD_CUO_CustomerOrderReturn_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrderReturn_HeaderID = reader.GetGuid(3);
					//4:Parameter CustomerOrderReturnNumber of type String
					resultItem.CustomerOrderReturnNumber = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs",ex);
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
		public static FR_L5BC_GSaCORHfCP_1109_Array Invoke(string ConnectionString,P_L5BC_GSaCORHfCP_1109 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BC_GSaCORHfCP_1109_Array Invoke(DbConnection Connection,P_L5BC_GSaCORHfCP_1109 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BC_GSaCORHfCP_1109_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BC_GSaCORHfCP_1109 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BC_GSaCORHfCP_1109_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BC_GSaCORHfCP_1109 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BC_GSaCORHfCP_1109_Array functionReturn = new FR_L5BC_GSaCORHfCP_1109_Array();
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

				throw new Exception("Exception occured in method cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BC_GSaCORHfCP_1109_Array : FR_Base
	{
		public L5BC_GSaCORHfCP_1109[] Result	{ get; set; } 
		public FR_L5BC_GSaCORHfCP_1109_Array() : base() {}

		public FR_L5BC_GSaCORHfCP_1109_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BC_GSaCORHfCP_1109 for attribute P_L5BC_GSaCORHfCP_1109
		[DataContract]
		public class P_L5BC_GSaCORHfCP_1109 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] BillPositionIDs { get; set; } 

		}
		#endregion
		#region SClass L5BC_GSaCORHfCP_1109 for attribute L5BC_GSaCORHfCP_1109
		[DataContract]
		public class L5BC_GSaCORHfCP_1109 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public Guid ORD_CUO_CustomerOrderReturn_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrderReturnNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BC_GSaCORHfCP_1109_Array cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs(,P_L5BC_GSaCORHfCP_1109 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BC_GSaCORHfCP_1109_Array invocationResult = cls_Get_Shipment_and_CustomerOrderReturn_Header_for_BillPositionIDs.Invoke(connectionString,P_L5BC_GSaCORHfCP_1109 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_BillCrediting.Atomic.Retrieval.P_L5BC_GSaCORHfCP_1109();
parameter.BillPositionIDs = ...;

*/
