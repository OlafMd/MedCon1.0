/* 
 * Generated on 07.11.2014 16:15:42
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

namespace CL5_APOBilling_Bill.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OpenShipmentPositions_with_Data.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OpenShipmentPositions_with_Data
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GOSPwD_0954_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GOSPwD_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BL_GOSPwD_0954_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Bill.Atomic.Retrieval.SQL.cls_Get_OpenShipmentPositions_with_Data.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentStatusID", Parameter.ShipmentStatusID);



			List<L5BL_GOSPwD_0954> results = new List<L5BL_GOSPwD_0954>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_PositionID","RecipientBusinessParticipant_RefID","CMN_PRO_Product_RefID","ShipmentHeader_Number","CustomerName","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal","StatusDeliveryDate","CurrencySymbol","CurrencyISO" });
				while(reader.Read())
				{
					L5BL_GOSPwD_0954 resultItem = new L5BL_GOSPwD_0954();
					//0:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(0);
					//1:Parameter RecipientBusinessParticipant_RefID of type Guid
					resultItem.RecipientBusinessParticipant_RefID = reader.GetGuid(1);
					//2:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(2);
					//3:Parameter ShipmentHeader_Number of type string
					resultItem.ShipmentHeader_Number = reader.GetString(3);
					//4:Parameter CustomerName of type string
					resultItem.CustomerName = reader.GetString(4);
					//5:Parameter Position_Quantity of type decimal
					resultItem.Position_Quantity = reader.GetDecimal(5);
					//6:Parameter Position_ValuePerUnit of type decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(6);
					//7:Parameter Position_ValueTotal of type decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(7);
					//8:Parameter StatusDeliveryDate of type DateTime
					resultItem.StatusDeliveryDate = reader.GetDate(8);
					//9:Parameter CurrencySymbol of type string
					resultItem.CurrencySymbol = reader.GetString(9);
					//10:Parameter CurrencyISO of type string
					resultItem.CurrencyISO = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OpenShipmentPositions_with_Data",ex);
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
		public static FR_L5BL_GOSPwD_0954_Array Invoke(string ConnectionString,P_L5BL_GOSPwD_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GOSPwD_0954_Array Invoke(DbConnection Connection,P_L5BL_GOSPwD_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GOSPwD_0954_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GOSPwD_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GOSPwD_0954_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GOSPwD_0954 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GOSPwD_0954_Array functionReturn = new FR_L5BL_GOSPwD_0954_Array();
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

				throw new Exception("Exception occured in method cls_Get_OpenShipmentPositions_with_Data",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GOSPwD_0954_Array : FR_Base
	{
		public L5BL_GOSPwD_0954[] Result	{ get; set; } 
		public FR_L5BL_GOSPwD_0954_Array() : base() {}

		public FR_L5BL_GOSPwD_0954_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GOSPwD_0954 for attribute P_L5BL_GOSPwD_0954
		[DataContract]
		public class P_L5BL_GOSPwD_0954 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentStatusID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GOSPwD_0954 for attribute L5BL_GOSPwD_0954
		[DataContract]
		public class L5BL_GOSPwD_0954 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid RecipientBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public string ShipmentHeader_Number { get; set; } 
			[DataMember]
			public string CustomerName { get; set; } 
			[DataMember]
			public decimal Position_Quantity { get; set; } 
			[DataMember]
			public decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public DateTime StatusDeliveryDate { get; set; } 
			[DataMember]
			public string CurrencySymbol { get; set; } 
			[DataMember]
			public string CurrencyISO { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GOSPwD_0954_Array cls_Get_OpenShipmentPositions_with_Data(,P_L5BL_GOSPwD_0954 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GOSPwD_0954_Array invocationResult = cls_Get_OpenShipmentPositions_with_Data.Invoke(connectionString,P_L5BL_GOSPwD_0954 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Atomic.Retrieval.P_L5BL_GOSPwD_0954();
parameter.ShipmentStatusID = ...;

*/
