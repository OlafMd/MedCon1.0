/* 
 * Generated on 7/23/2014 11:10:10 AM
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

namespace CL5_APOLogistic_ReturnShipment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ReturnShipmentPositions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReturnShipmentPositions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_RSP_1552_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_RSP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5RS_RSP_1552_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.SQL.cls_Get_ReturnShipmentPositions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SupplierName", Parameter.SupplierName);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeliverySlipNumber", Parameter.DeliverySlipNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentHeaderNr", Parameter.ShipmentHeaderNr);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@Status"," IN $$Status$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$Status$",Parameter.Status);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RetShpCreationDateFrom", Parameter.RetShpCreationDateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"RetShpCreationDateTo", Parameter.RetShpCreationDateTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NoteCreationDateFrom", Parameter.NoteCreationDateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NoteCreationDateTo", Parameter.NoteCreationDateTo);



			List<L5RS_RSP_1552> results = new List<L5RS_RSP_1552>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ShipmentHeader_Number","DeliverySlip_Number","DateOfReturnShipmentCreation","DateOnCreditNote","CreditNote_Number","GlobalPropertyMatchingID","Supplier","LastUpdatedBy","QuantityToShip","ShipmentPosition_ValueWithoutTax","CMN_PRO_Product_RefID","LOG_SHP_Shipment_PositionID","LOG_SHP_Shipment_HeaderID","LOG_SHP_ReturnShipment_HeaderID" });
				while(reader.Read())
				{
					L5RS_RSP_1552 resultItem = new L5RS_RSP_1552();
					//0:Parameter ShipmentHeader_Number of type String
					resultItem.ShipmentHeader_Number = reader.GetString(0);
					//1:Parameter DeliverySlip_Number of type String
					resultItem.DeliverySlip_Number = reader.GetString(1);
					//2:Parameter DateOfReturnShipmentCreation of type DateTime
					resultItem.DateOfReturnShipmentCreation = reader.GetDate(2);
					//3:Parameter DateOnCreditNote of type DateTime
					resultItem.DateOnCreditNote = reader.GetDate(3);
					//4:Parameter CreditNote_Number of type String
					resultItem.CreditNote_Number = reader.GetString(4);
					//5:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(5);
					//6:Parameter Supplier of type String
					resultItem.Supplier = reader.GetString(6);
					//7:Parameter LastUpdatedBy of type String
					resultItem.LastUpdatedBy = reader.GetString(7);
					//8:Parameter QuantityToShip of type Double
					resultItem.QuantityToShip = reader.GetDouble(8);
					//9:Parameter ShipmentPosition_ValueWithoutTax of type Decimal
					resultItem.ShipmentPosition_ValueWithoutTax = reader.GetDecimal(9);
					//10:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(10);
					//11:Parameter LOG_SHP_Shipment_PositionID of type Guid
					resultItem.LOG_SHP_Shipment_PositionID = reader.GetGuid(11);
					//12:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(12);
					//13:Parameter LOG_SHP_ReturnShipment_HeaderID of type Guid
					resultItem.LOG_SHP_ReturnShipment_HeaderID = reader.GetGuid(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ReturnShipmentPositions",ex);
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
		public static FR_L5RS_RSP_1552_Array Invoke(string ConnectionString,P_L5RS_RSP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_RSP_1552_Array Invoke(DbConnection Connection,P_L5RS_RSP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_RSP_1552_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_RSP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_RSP_1552_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_RSP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_RSP_1552_Array functionReturn = new FR_L5RS_RSP_1552_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReturnShipmentPositions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_RSP_1552_Array : FR_Base
	{
		public L5RS_RSP_1552[] Result	{ get; set; } 
		public FR_L5RS_RSP_1552_Array() : base() {}

		public FR_L5RS_RSP_1552_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_RSP_1552 for attribute P_L5RS_RSP_1552
		[DataContract]
		public class P_L5RS_RSP_1552 
		{
			//Standard type parameters
			[DataMember]
			public string SupplierName { get; set; } 
			[DataMember]
			public string DeliverySlipNumber { get; set; } 
			[DataMember]
			public string ShipmentHeaderNr { get; set; } 
			[DataMember]
			public string[] Status { get; set; } 
			[DataMember]
			public DateTime? RetShpCreationDateFrom { get; set; } 
			[DataMember]
			public DateTime? RetShpCreationDateTo { get; set; } 
			[DataMember]
			public DateTime? NoteCreationDateFrom { get; set; } 
			[DataMember]
			public DateTime? NoteCreationDateTo { get; set; } 

		}
		#endregion
		#region SClass L5RS_RSP_1552 for attribute L5RS_RSP_1552
		[DataContract]
		public class L5RS_RSP_1552 
		{
			//Standard type parameters
			[DataMember]
			public String ShipmentHeader_Number { get; set; } 
			[DataMember]
			public String DeliverySlip_Number { get; set; } 
			[DataMember]
			public DateTime DateOfReturnShipmentCreation { get; set; } 
			[DataMember]
			public DateTime DateOnCreditNote { get; set; } 
			[DataMember]
			public String CreditNote_Number { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String Supplier { get; set; } 
			[DataMember]
			public String LastUpdatedBy { get; set; } 
			[DataMember]
			public Double QuantityToShip { get; set; } 
			[DataMember]
			public Decimal ShipmentPosition_ValueWithoutTax { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_PositionID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public Guid LOG_SHP_ReturnShipment_HeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_RSP_1552_Array cls_Get_ReturnShipmentPositions(,P_L5RS_RSP_1552 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_RSP_1552_Array invocationResult = cls_Get_ReturnShipmentPositions.Invoke(connectionString,P_L5RS_RSP_1552 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Atomic.Retrieval.P_L5RS_RSP_1552();
parameter.SupplierName = ...;
parameter.DeliverySlipNumber = ...;
parameter.ShipmentHeaderNr = ...;
parameter.Status = ...;
parameter.RetShpCreationDateFrom = ...;
parameter.RetShpCreationDateTo = ...;
parameter.NoteCreationDateFrom = ...;
parameter.NoteCreationDateTo = ...;

*/
