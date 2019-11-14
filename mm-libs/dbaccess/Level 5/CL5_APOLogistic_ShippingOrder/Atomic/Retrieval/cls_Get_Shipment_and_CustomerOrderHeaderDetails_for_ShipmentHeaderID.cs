/* 
 * Generated on 11/7/2014 10:43:42 AM
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

namespace CL5_APOLogistic_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GSaCOHDfSH_1446 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GSaCOHDfSH_1446 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SO_GSaCOHDfSH_1446();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShippingHeaderID", Parameter.ShippingHeaderID);



			List<L5SO_GSaCOHDfSH_1446> results = new List<L5SO_GSaCOHDfSH_1446>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","CustomerOrder_Number","CustomerOrder_Date","ShipmentHeader_Number","ShippingDate","LOG_SHP_Shipment_TypeID","ShipmentType_Name_DictID","NotesCount","OrderingCustomer_BusinessParticipant_RefID","CMN_BPT_CTM_OrganizationalUnit_RefID","CMN_BPT_CTM_CustomerID" });
				while(reader.Read())
				{
					L5SO_GSaCOHDfSH_1446 resultItem = new L5SO_GSaCOHDfSH_1446();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(1);
					//2:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(2);
					//3:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(3);
					//4:Parameter ShippingDate of type DateTime
					resultItem.ShippingDate = reader.GetDate(4);
					//5:Parameter LOG_SHP_Shipment_TypeID of type Guid
					resultItem.LOG_SHP_Shipment_TypeID = reader.GetGuid(5);
					//6:Parameter ShipmentType_Name of type Dict
					resultItem.ShipmentType_Name = reader.GetDictionary(6);
					resultItem.ShipmentType_Name.SourceTable = "log_shp_shipment_types";
					loader.Append(resultItem.ShipmentType_Name);
					//7:Parameter NotesCount of type int
					resultItem.NotesCount = reader.GetInteger(7);
					//8:Parameter OrderingCustomer_BusinessParticipant_RefID of type Guid
					resultItem.OrderingCustomer_BusinessParticipant_RefID = reader.GetGuid(8);
					//9:Parameter CMN_BPT_CTM_OrganizationalUnit_RefID of type Guid
					resultItem.CMN_BPT_CTM_OrganizationalUnit_RefID = reader.GetGuid(9);
					//10:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID",ex);
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
		public static FR_L5SO_GSaCOHDfSH_1446 Invoke(string ConnectionString,P_L5SO_GSaCOHDfSH_1446 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GSaCOHDfSH_1446 Invoke(DbConnection Connection,P_L5SO_GSaCOHDfSH_1446 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GSaCOHDfSH_1446 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GSaCOHDfSH_1446 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GSaCOHDfSH_1446 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GSaCOHDfSH_1446 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GSaCOHDfSH_1446 functionReturn = new FR_L5SO_GSaCOHDfSH_1446();
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

				throw new Exception("Exception occured in method cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GSaCOHDfSH_1446 : FR_Base
	{
		public L5SO_GSaCOHDfSH_1446 Result	{ get; set; }

		public FR_L5SO_GSaCOHDfSH_1446() : base() {}

		public FR_L5SO_GSaCOHDfSH_1446(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GSaCOHDfSH_1446 for attribute P_L5SO_GSaCOHDfSH_1446
		[DataContract]
		public class P_L5SO_GSaCOHDfSH_1446 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShippingHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_GSaCOHDfSH_1446 for attribute L5SO_GSaCOHDfSH_1446
		[DataContract]
		public class L5SO_GSaCOHDfSH_1446 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public DateTime ShippingDate { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_TypeID { get; set; } 
			[DataMember]
			public Dict ShipmentType_Name { get; set; } 
			[DataMember]
			public int NotesCount { get; set; } 
			[DataMember]
			public Guid OrderingCustomer_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnit_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GSaCOHDfSH_1446 cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID(,P_L5SO_GSaCOHDfSH_1446 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GSaCOHDfSH_1446 invocationResult = cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID.Invoke(connectionString,P_L5SO_GSaCOHDfSH_1446 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L5SO_GSaCOHDfSH_1446();
parameter.ShippingHeaderID = ...;

*/
