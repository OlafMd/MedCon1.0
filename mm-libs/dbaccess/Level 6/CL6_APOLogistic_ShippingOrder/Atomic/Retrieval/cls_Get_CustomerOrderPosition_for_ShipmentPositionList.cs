/* 
 * Generated on 11/13/2014 2:04:36 PM
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

namespace CL6_APOLogistic_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderPosition_for_ShipmentPositionList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderPosition_for_ShipmentPositionList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SO_GCOPfSPL_1152_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6SO_GCOPfSPL_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6SO_GCOPfSPL_1152_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_CustomerOrderPosition_for_ShipmentPositionList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShipmentPositionID"," IN $$ShipmentPositionID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShipmentPositionID$",Parameter.ShipmentPositionID);


			List<L6SO_GCOPfSPL_1152> results = new List<L6SO_GCOPfSPL_1152>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_PositionID","LOG_SHP_Shipment_PositionID" });
				while(reader.Read())
				{
					L6SO_GCOPfSPL_1152 resultItem = new L6SO_GCOPfSPL_1152();
					//0:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(0);
					//1:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderPosition_for_ShipmentPositionList",ex);
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
		public static FR_L6SO_GCOPfSPL_1152_Array Invoke(string ConnectionString,P_L6SO_GCOPfSPL_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SO_GCOPfSPL_1152_Array Invoke(DbConnection Connection,P_L6SO_GCOPfSPL_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SO_GCOPfSPL_1152_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SO_GCOPfSPL_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SO_GCOPfSPL_1152_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SO_GCOPfSPL_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SO_GCOPfSPL_1152_Array functionReturn = new FR_L6SO_GCOPfSPL_1152_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderPosition_for_ShipmentPositionList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SO_GCOPfSPL_1152_Array : FR_Base
	{
		public L6SO_GCOPfSPL_1152[] Result	{ get; set; } 
		public FR_L6SO_GCOPfSPL_1152_Array() : base() {}

		public FR_L6SO_GCOPfSPL_1152_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SO_GCOPfSPL_1152 for attribute P_L6SO_GCOPfSPL_1152
		[DataContract]
		public class P_L6SO_GCOPfSPL_1152 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ShipmentPositionID { get; set; } 

		}
		#endregion
		#region SClass L6SO_GCOPfSPL_1152 for attribute L6SO_GCOPfSPL_1152
		[DataContract]
		public class L6SO_GCOPfSPL_1152 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SO_GCOPfSPL_1152_Array cls_Get_CustomerOrderPosition_for_ShipmentPositionList(,P_L6SO_GCOPfSPL_1152 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SO_GCOPfSPL_1152_Array invocationResult = cls_Get_CustomerOrderPosition_for_ShipmentPositionList.Invoke(connectionString,P_L6SO_GCOPfSPL_1152 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L6SO_GCOPfSPL_1152();
parameter.ShipmentPositionID = ...;

*/
