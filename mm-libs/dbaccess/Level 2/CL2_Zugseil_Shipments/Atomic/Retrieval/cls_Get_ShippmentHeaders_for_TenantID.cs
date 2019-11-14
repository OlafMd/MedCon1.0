/* 
 * Generated on 3/11/2015 4:55:52 PM
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

namespace CL2_Zugseil_Shipments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippmentHeaders_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippmentHeaders_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2SH_GSHfT_1527_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2SH_GSHfT_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2SH_GSHfT_1527_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Zugseil_Shipments.Atomic.Retrieval.SQL.cls_Get_ShippmentHeaders_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsShipped", Parameter.IsShipped);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentNumber", Parameter.ShipmentNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsPartiallyReadyForPicking", Parameter.IsPartiallyReadyForPicking);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsReadyForPicking", Parameter.IsReadyForPicking);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HasPickingStarted", Parameter.HasPickingStarted);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HasPickingFinished", Parameter.HasPickingFinished);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsBilled", Parameter.IsBilled);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsManuallyCleared_ForPicking", Parameter.IsManuallyCleared_ForPicking);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentCreationDateFrom", Parameter.ShipmentCreationDateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentCreationDateTo", Parameter.ShipmentCreationDateTo);



			List<L2SH_GSHfT_1527> results = new List<L2SH_GSHfT_1527>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","IsShipped","ShipmentHeader_Number","IsPartiallyReadyForPicking","IsReadyForPicking","HasPickingStarted","HasPickingFinished","IsBilled","DemandDate","IsPartialShippingAllowed","IsManuallyCleared_ForPicking","Shippipng_AddressUCD_RefID","Creation_Timestamp" });
				while(reader.Read())
				{
					L2SH_GSHfT_1527 resultItem = new L2SH_GSHfT_1527();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter IsShipped of type bool
					resultItem.IsShipped = reader.GetBoolean(1);
					//2:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(2);
					//3:Parameter IsPartiallyReadyForPicking of type bool
					resultItem.IsPartiallyReadyForPicking = reader.GetBoolean(3);
					//4:Parameter IsReadyForPicking of type bool
					resultItem.IsReadyForPicking = reader.GetBoolean(4);
					//5:Parameter HasPickingStarted of type bool
					resultItem.HasPickingStarted = reader.GetBoolean(5);
					//6:Parameter HasPickingFinished of type bool
					resultItem.HasPickingFinished = reader.GetBoolean(6);
					//7:Parameter IsBilled of type bool
					resultItem.IsBilled = reader.GetBoolean(7);
					//8:Parameter DemandDate of type DateTime
					resultItem.DemandDate = reader.GetDate(8);
					//9:Parameter IsPartialShippingAllowed of type bool
					resultItem.IsPartialShippingAllowed = reader.GetBoolean(9);
					//10:Parameter IsManuallyCleared_ForPicking of type bool
					resultItem.IsManuallyCleared_ForPicking = reader.GetBoolean(10);
					//11:Parameter Shippipng_AddressUCD_RefID of type Guid
					resultItem.Shippipng_AddressUCD_RefID = reader.GetGuid(11);
					//12:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShippmentHeaders_for_TenantID",ex);
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
		public static FR_L2SH_GSHfT_1527_Array Invoke(string ConnectionString,P_L2SH_GSHfT_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2SH_GSHfT_1527_Array Invoke(DbConnection Connection,P_L2SH_GSHfT_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2SH_GSHfT_1527_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2SH_GSHfT_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2SH_GSHfT_1527_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2SH_GSHfT_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2SH_GSHfT_1527_Array functionReturn = new FR_L2SH_GSHfT_1527_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShippmentHeaders_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2SH_GSHfT_1527_Array : FR_Base
	{
		public L2SH_GSHfT_1527[] Result	{ get; set; } 
		public FR_L2SH_GSHfT_1527_Array() : base() {}

		public FR_L2SH_GSHfT_1527_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2SH_GSHfT_1527 for attribute P_L2SH_GSHfT_1527
		[DataContract]
		public class P_L2SH_GSHfT_1527 
		{
			//Standard type parameters
			[DataMember]
			public Boolean? IsShipped { get; set; } 
			[DataMember]
			public String ShipmentNumber { get; set; } 
			[DataMember]
			public Boolean? IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? IsReadyForPicking { get; set; } 
			[DataMember]
			public Boolean? HasPickingStarted { get; set; } 
			[DataMember]
			public Boolean? HasPickingFinished { get; set; } 
			[DataMember]
			public Boolean? IsBilled { get; set; } 
			[DataMember]
			public Boolean? IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public DateTime? ShipmentCreationDateFrom { get; set; } 
			[DataMember]
			public DateTime? ShipmentCreationDateTo { get; set; } 

		}
		#endregion
		#region SClass L2SH_GSHfT_1527 for attribute L2SH_GSHfT_1527
		[DataContract]
		public class L2SH_GSHfT_1527 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public bool IsShipped { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public bool IsPartiallyReadyForPicking { get; set; } 
			[DataMember]
			public bool IsReadyForPicking { get; set; } 
			[DataMember]
			public bool HasPickingStarted { get; set; } 
			[DataMember]
			public bool HasPickingFinished { get; set; } 
			[DataMember]
			public bool IsBilled { get; set; } 
			[DataMember]
			public DateTime DemandDate { get; set; } 
			[DataMember]
			public bool IsPartialShippingAllowed { get; set; } 
			[DataMember]
			public bool IsManuallyCleared_ForPicking { get; set; } 
			[DataMember]
			public Guid Shippipng_AddressUCD_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2SH_GSHfT_1527_Array cls_Get_ShippmentHeaders_for_TenantID(,P_L2SH_GSHfT_1527 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2SH_GSHfT_1527_Array invocationResult = cls_Get_ShippmentHeaders_for_TenantID.Invoke(connectionString,P_L2SH_GSHfT_1527 Parameter,securityTicket);
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
var parameter = new CL2_Zugseil_Shipments.Atomic.Retrieval.P_L2SH_GSHfT_1527();
parameter.IsShipped = ...;
parameter.ShipmentNumber = ...;
parameter.IsPartiallyReadyForPicking = ...;
parameter.IsReadyForPicking = ...;
parameter.HasPickingStarted = ...;
parameter.HasPickingFinished = ...;
parameter.IsBilled = ...;
parameter.IsManuallyCleared_ForPicking = ...;
parameter.ShipmentCreationDateFrom = ...;
parameter.ShipmentCreationDateTo = ...;

*/
