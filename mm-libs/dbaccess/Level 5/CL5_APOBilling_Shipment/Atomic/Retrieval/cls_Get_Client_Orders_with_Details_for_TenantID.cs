/* 
 * Generated on 6/10/2014 9:02:11 AM
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
using System.Runtime.Serialization;

namespace CL5_APOBilling_Shipment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Client_Orders_with_Details_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Client_Orders_with_Details_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SH_GCwDfT_1454_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SH_GCwDfT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SH_GCwDfT_1454_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Shipment.Atomic.Retrieval.SQL.cls_Get_Client_Orders_with_Details_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderNumber", Parameter.OrderNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Customer", Parameter.Customer);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PeriodFrom", Parameter.PeriodFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PeriodTo", Parameter.PeriodTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeliveryFrom", Parameter.DeliveryFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeliveryTo", Parameter.DeliveryTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentStatusID_Shipped", Parameter.ShipmentStatusID_Shipped);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ShipmentStatusID_Created", Parameter.ShipmentStatusID_Created);



			List<L5SH_GCwDfT_1454_raw> results = new List<L5SH_GCwDfT_1454_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","StatusShipmentDate","ShipmentHeader_Number","ShipmentHeader_Creation_Timestamp","CustomerName","OrderDate","InternalCustomerNumber","CMN_BPT_CTM_CustomerID","CreatedByName","CMN_PRO_Product_RefID","ShipmentPosition_ValueWithoutTax","CurrencySymbol","TaxRate" });
				while(reader.Read())
				{
					L5SH_GCwDfT_1454_raw resultItem = new L5SH_GCwDfT_1454_raw();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter StatusShipmentDate of type DateTime
					resultItem.StatusShipmentDate = reader.GetDate(1);
					//2:Parameter ShipmentHeader_Number of type string
					resultItem.ShipmentHeader_Number = reader.GetString(2);
					//3:Parameter ShipmentHeader_Creation_Timestamp of type DateTime
					resultItem.ShipmentHeader_Creation_Timestamp = reader.GetDate(3);
					//4:Parameter CustomerName of type string
					resultItem.CustomerName = reader.GetString(4);
					//5:Parameter OrderDate of type DateTime
					resultItem.OrderDate = reader.GetDate(5);
					//6:Parameter InternalCustomerNumber of type string
					resultItem.InternalCustomerNumber = reader.GetString(6);
					//7:Parameter CMN_BPT_CTM_CustomerID of type Guid
					resultItem.CMN_BPT_CTM_CustomerID = reader.GetGuid(7);
					//8:Parameter CreatedByName of type string
					resultItem.CreatedByName = reader.GetString(8);
					//9:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(9);
					//10:Parameter ShipmentPosition_ValueWithoutTax of type decimal
					resultItem.ShipmentPosition_ValueWithoutTax = reader.GetDecimal(10);
					//11:Parameter CurrencySymbol of type string
					resultItem.CurrencySymbol = reader.GetString(11);
					//12:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Client_Orders_with_Details_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5SH_GCwDfT_1454_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SH_GCwDfT_1454_Array Invoke(string ConnectionString,P_L5SH_GCwDfT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SH_GCwDfT_1454_Array Invoke(DbConnection Connection,P_L5SH_GCwDfT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SH_GCwDfT_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SH_GCwDfT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SH_GCwDfT_1454_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SH_GCwDfT_1454 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SH_GCwDfT_1454_Array functionReturn = new FR_L5SH_GCwDfT_1454_Array();
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

				throw new Exception("Exception occured in method cls_Get_Client_Orders_with_Details_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5SH_GCwDfT_1454_raw 
	{
		public Guid LOG_SHP_Shipment_HeaderID; 
		public DateTime StatusShipmentDate; 
		public string ShipmentHeader_Number; 
		public DateTime ShipmentHeader_Creation_Timestamp; 
		public string CustomerName; 
		public DateTime OrderDate; 
		public string InternalCustomerNumber; 
		public Guid CMN_BPT_CTM_CustomerID; 
		public string CreatedByName; 
		public Guid CMN_PRO_Product_RefID; 
		public decimal ShipmentPosition_ValueWithoutTax; 
		public string CurrencySymbol; 
		public double TaxRate; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5SH_GCwDfT_1454[] Convert(List<L5SH_GCwDfT_1454_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5SH_GCwDfT_1454 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.LOG_SHP_Shipment_HeaderID)).ToArray()
	group el_L5SH_GCwDfT_1454 by new 
	{ 
		el_L5SH_GCwDfT_1454.LOG_SHP_Shipment_HeaderID,

	}
	into gfunct_L5SH_GCwDfT_1454
	select new L5SH_GCwDfT_1454
	{     
		LOG_SHP_Shipment_HeaderID = gfunct_L5SH_GCwDfT_1454.Key.LOG_SHP_Shipment_HeaderID ,
		StatusShipmentDate = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().StatusShipmentDate ,
		ShipmentHeader_Number = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().ShipmentHeader_Number ,
		ShipmentHeader_Creation_Timestamp = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().ShipmentHeader_Creation_Timestamp ,
		CustomerName = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().CustomerName ,
		OrderDate = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().OrderDate ,
		InternalCustomerNumber = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().InternalCustomerNumber ,
		CMN_BPT_CTM_CustomerID = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().CMN_BPT_CTM_CustomerID ,
		CreatedByName = gfunct_L5SH_GCwDfT_1454.FirstOrDefault().CreatedByName ,

		InfoProducts = 
		(
			from el_InfoProducts in gfunct_L5SH_GCwDfT_1454.Where(element => !EqualsDefaultValue(element.CMN_PRO_Product_RefID)).ToArray()
			group el_InfoProducts by new 
			{ 
				el_InfoProducts.CMN_PRO_Product_RefID,

			}
			into gfunct_InfoProducts
			select new L5SH_GCwDfT_1454_InfoProduct
			{     
				CMN_PRO_Product_RefID = gfunct_InfoProducts.Key.CMN_PRO_Product_RefID ,
				ShipmentPosition_ValueWithoutTax = gfunct_InfoProducts.FirstOrDefault().ShipmentPosition_ValueWithoutTax ,
				CurrencySymbol = gfunct_InfoProducts.FirstOrDefault().CurrencySymbol ,
				TaxRate = gfunct_InfoProducts.FirstOrDefault().TaxRate ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5SH_GCwDfT_1454_Array : FR_Base
	{
		public L5SH_GCwDfT_1454[] Result	{ get; set; } 
		public FR_L5SH_GCwDfT_1454_Array() : base() {}

		public FR_L5SH_GCwDfT_1454_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SH_GCwDfT_1454 for attribute P_L5SH_GCwDfT_1454
		[DataContract]
		public class P_L5SH_GCwDfT_1454 
		{
			//Standard type parameters
			[DataMember]
			public string OrderNumber { get; set; } 
			[DataMember]
			public string Customer { get; set; } 
			[DataMember]
			public DateTime? PeriodFrom { get; set; } 
			[DataMember]
			public DateTime? PeriodTo { get; set; } 
			[DataMember]
			public DateTime? DeliveryFrom { get; set; } 
			[DataMember]
			public DateTime? DeliveryTo { get; set; } 
			[DataMember]
			public Guid ShipmentStatusID_Shipped { get; set; } 
			[DataMember]
			public Guid ShipmentStatusID_Created { get; set; } 

		}
		#endregion
		#region SClass L5SH_GCwDfT_1454 for attribute L5SH_GCwDfT_1454
		[DataContract]
		public class L5SH_GCwDfT_1454 
		{
			[DataMember]
			public L5SH_GCwDfT_1454_InfoProduct[] InfoProducts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public DateTime StatusShipmentDate { get; set; } 
			[DataMember]
			public string ShipmentHeader_Number { get; set; } 
			[DataMember]
			public DateTime ShipmentHeader_Creation_Timestamp { get; set; } 
			[DataMember]
			public string CustomerName { get; set; } 
			[DataMember]
			public DateTime OrderDate { get; set; } 
			[DataMember]
			public string InternalCustomerNumber { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public string CreatedByName { get; set; } 

		}
		#endregion
		#region SClass L5SH_GCwDfT_1454_InfoProduct for attribute InfoProducts
		[DataContract]
		public class L5SH_GCwDfT_1454_InfoProduct 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public decimal ShipmentPosition_ValueWithoutTax { get; set; } 
			[DataMember]
			public string CurrencySymbol { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SH_GCwDfT_1454_Array cls_Get_Client_Orders_with_Details_for_TenantID(,P_L5SH_GCwDfT_1454 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SH_GCwDfT_1454_Array invocationResult = cls_Get_Client_Orders_with_Details_for_TenantID.Invoke(connectionString,P_L5SH_GCwDfT_1454 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Shipment.Atomic.Retrieval.P_L5SH_GCwDfT_1454();
parameter.OrderNumber = ...;
parameter.Customer = ...;
parameter.PeriodFrom = ...;
parameter.PeriodTo = ...;
parameter.DeliveryFrom = ...;
parameter.DeliveryTo = ...;
parameter.ShipmentStatusID_Shipped = ...;
parameter.ShipmentStatusID_Created = ...;

*/
