/* 
 * Generated on 10/24/2014 2:53:37 PM
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

namespace CL5_APOLogistic_StockReceipt.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StockReceipts_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StockReceipts_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5ALSR_GSRfT_1016_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5ALSR_GSRfT_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5ALSR_GSRfT_1016_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_StockReceipt.Atomic.Retrieval.SQL.cls_Get_StockReceipts_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SupplierName", Parameter.SupplierName);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReceiptNumber", Parameter.ReceiptNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProcurementOrderNumber", Parameter.ProcurementOrderNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateFrom", Parameter.DateFrom);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateTo", Parameter.DateTo);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsTakenIntoStock", Parameter.IsTakenIntoStock);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsQualityControlPerformed", Parameter.IsQualityControlPerformed);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsPriceConditionsManuallyCleared", Parameter.IsPriceConditionsManuallyCleared);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsReceiptForwardedToBookkeeping", Parameter.IsReceiptForwardedToBookkeeping);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SupplierTypeID", Parameter.SupplierTypeID);



			List<L5ALSR_GSRfT_1016_raw> results = new List<L5ALSR_GSRfT_1016_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_ExpectedDelivery_HeaderID","ExpectedDeliveryDate","ExpectedDeliveryNumber","ExpDeliveryHeader_DateOfCreation","LOG_RCP_Receipt_HeaderID","ReceiptNumber","IsTakenIntoStock","IsQualityControlPerformed","IsPriceConditionsManuallyCleared","IsReceiptForwardedToBookkeeping","ProcurementOrder_Number","CMN_BPT_SupplierID","CMN_BPT_BusinessParticipantID","DisplayName","CMN_BPT_Supplier_TypeID","SupplierType","CurrencySymbol","ORD_PRC_ExpectedDelivery_PositionID","TotalExpectedQuantity","Position_ValuePerUnit" });
				while(reader.Read())
				{
					L5ALSR_GSRfT_1016_raw resultItem = new L5ALSR_GSRfT_1016_raw();
					//0:Parameter ORD_PRC_ExpectedDelivery_HeaderID of type Guid
					resultItem.ORD_PRC_ExpectedDelivery_HeaderID = reader.GetGuid(0);
					//1:Parameter ExpectedDeliveryDate of type DateTime
					resultItem.ExpectedDeliveryDate = reader.GetDate(1);
					//2:Parameter ExpectedDeliveryNumber of type String
					resultItem.ExpectedDeliveryNumber = reader.GetString(2);
					//3:Parameter ExpDeliveryHeader_DateOfCreation of type DateTime
					resultItem.ExpDeliveryHeader_DateOfCreation = reader.GetDate(3);
					//4:Parameter LOG_RCP_Receipt_HeaderID of type Guid
					resultItem.LOG_RCP_Receipt_HeaderID = reader.GetGuid(4);
					//5:Parameter ReceiptNumber of type String
					resultItem.ReceiptNumber = reader.GetString(5);
					//6:Parameter IsTakenIntoStock of type bool
					resultItem.IsTakenIntoStock = reader.GetBoolean(6);
					//7:Parameter IsQualityControlPerformed of type bool
					resultItem.IsQualityControlPerformed = reader.GetBoolean(7);
					//8:Parameter IsPriceConditionsManuallyCleared of type bool
					resultItem.IsPriceConditionsManuallyCleared = reader.GetBoolean(8);
					//9:Parameter IsReceiptForwardedToBookkeeping of type bool
					resultItem.IsReceiptForwardedToBookkeeping = reader.GetBoolean(9);
					//10:Parameter ProcurementOrder_Number of type String
					resultItem.ProcurementOrder_Number = reader.GetString(10);
					//11:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(11);
					//12:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(12);
					//13:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(13);
					//14:Parameter CMN_BPT_Supplier_TypeID of type Guid
					resultItem.CMN_BPT_Supplier_TypeID = reader.GetGuid(14);
					//15:Parameter SupplierType of type string
					resultItem.SupplierType = reader.GetString(15);
					//16:Parameter CurrencySymbol of type string
					resultItem.CurrencySymbol = reader.GetString(16);
					//17:Parameter ORD_PRC_ExpectedDelivery_PositionID of type Guid
					resultItem.ORD_PRC_ExpectedDelivery_PositionID = reader.GetGuid(17);
					//18:Parameter TotalExpectedQuantity of type double
					resultItem.TotalExpectedQuantity = reader.GetDouble(18);
					//19:Parameter Position_ValuePerUnit of type decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(19);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StockReceipts_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5ALSR_GSRfT_1016_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5ALSR_GSRfT_1016_Array Invoke(string ConnectionString,P_L5ALSR_GSRfT_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5ALSR_GSRfT_1016_Array Invoke(DbConnection Connection,P_L5ALSR_GSRfT_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5ALSR_GSRfT_1016_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ALSR_GSRfT_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5ALSR_GSRfT_1016_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ALSR_GSRfT_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5ALSR_GSRfT_1016_Array functionReturn = new FR_L5ALSR_GSRfT_1016_Array();
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

				throw new Exception("Exception occured in method cls_Get_StockReceipts_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5ALSR_GSRfT_1016_raw 
	{
		public Guid ORD_PRC_ExpectedDelivery_HeaderID; 
		public DateTime ExpectedDeliveryDate; 
		public String ExpectedDeliveryNumber; 
		public DateTime ExpDeliveryHeader_DateOfCreation; 
		public Guid LOG_RCP_Receipt_HeaderID; 
		public String ReceiptNumber; 
		public bool IsTakenIntoStock; 
		public bool IsQualityControlPerformed; 
		public bool IsPriceConditionsManuallyCleared; 
		public bool IsReceiptForwardedToBookkeeping; 
		public String ProcurementOrder_Number; 
		public Guid CMN_BPT_SupplierID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String DisplayName; 
		public Guid CMN_BPT_Supplier_TypeID; 
		public string SupplierType; 
		public string CurrencySymbol; 
		public Guid ORD_PRC_ExpectedDelivery_PositionID; 
		public double TotalExpectedQuantity; 
		public decimal Position_ValuePerUnit; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5ALSR_GSRfT_1016[] Convert(List<L5ALSR_GSRfT_1016_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5ALSR_GSRfT_1016 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_PRC_ExpectedDelivery_HeaderID)).ToArray()
	group el_L5ALSR_GSRfT_1016 by new 
	{ 
		el_L5ALSR_GSRfT_1016.ORD_PRC_ExpectedDelivery_HeaderID,

	}
	into gfunct_L5ALSR_GSRfT_1016
	select new L5ALSR_GSRfT_1016
	{     
		ORD_PRC_ExpectedDelivery_HeaderID = gfunct_L5ALSR_GSRfT_1016.Key.ORD_PRC_ExpectedDelivery_HeaderID ,
		ExpectedDeliveryDate = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().ExpectedDeliveryDate ,
		ExpectedDeliveryNumber = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().ExpectedDeliveryNumber ,
		ExpDeliveryHeader_DateOfCreation = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().ExpDeliveryHeader_DateOfCreation ,
		LOG_RCP_Receipt_HeaderID = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().LOG_RCP_Receipt_HeaderID ,
		ReceiptNumber = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().ReceiptNumber ,
		IsTakenIntoStock = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().IsTakenIntoStock ,
		IsQualityControlPerformed = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().IsQualityControlPerformed ,
		IsPriceConditionsManuallyCleared = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().IsPriceConditionsManuallyCleared ,
		IsReceiptForwardedToBookkeeping = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().IsReceiptForwardedToBookkeeping ,
		ProcurementOrder_Number = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().ProcurementOrder_Number ,
		CMN_BPT_SupplierID = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().CMN_BPT_SupplierID ,
		CMN_BPT_BusinessParticipantID = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		DisplayName = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().DisplayName ,
		CMN_BPT_Supplier_TypeID = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().CMN_BPT_Supplier_TypeID ,
		SupplierType = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().SupplierType ,
		CurrencySymbol = gfunct_L5ALSR_GSRfT_1016.FirstOrDefault().CurrencySymbol ,

		Positions = 
		(
			from el_Positions in gfunct_L5ALSR_GSRfT_1016.Where(element => !EqualsDefaultValue(element.ORD_PRC_ExpectedDelivery_PositionID)).ToArray()
			group el_Positions by new 
			{ 
				el_Positions.ORD_PRC_ExpectedDelivery_PositionID,

			}
			into gfunct_Positions
			select new L5ALSR_GSRfT_1016_ord_prc_expecteddelivery_positions
			{     
				ORD_PRC_ExpectedDelivery_PositionID = gfunct_Positions.Key.ORD_PRC_ExpectedDelivery_PositionID ,
				TotalExpectedQuantity = gfunct_Positions.FirstOrDefault().TotalExpectedQuantity ,
				Position_ValuePerUnit = gfunct_Positions.FirstOrDefault().Position_ValuePerUnit ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5ALSR_GSRfT_1016_Array : FR_Base
	{
		public L5ALSR_GSRfT_1016[] Result	{ get; set; } 
		public FR_L5ALSR_GSRfT_1016_Array() : base() {}

		public FR_L5ALSR_GSRfT_1016_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5ALSR_GSRfT_1016 for attribute P_L5ALSR_GSRfT_1016
		[DataContract]
		public class P_L5ALSR_GSRfT_1016 
		{
			//Standard type parameters
			[DataMember]
			public string SupplierName { get; set; } 
			[DataMember]
			public string ReceiptNumber { get; set; } 
			[DataMember]
			public string ProcurementOrderNumber { get; set; } 
			[DataMember]
			public DateTime? DateFrom { get; set; } 
			[DataMember]
			public DateTime? DateTo { get; set; } 
			[DataMember]
			public bool? IsTakenIntoStock { get; set; } 
			[DataMember]
			public bool? IsQualityControlPerformed { get; set; } 
			[DataMember]
			public bool? IsPriceConditionsManuallyCleared { get; set; } 
			[DataMember]
			public bool? IsReceiptForwardedToBookkeeping { get; set; } 
			[DataMember]
			public Guid? SupplierTypeID { get; set; } 

		}
		#endregion
		#region SClass L5ALSR_GSRfT_1016 for attribute L5ALSR_GSRfT_1016
		[DataContract]
		public class L5ALSR_GSRfT_1016 
		{
			[DataMember]
			public L5ALSR_GSRfT_1016_ord_prc_expecteddelivery_positions[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ExpectedDelivery_HeaderID { get; set; } 
			[DataMember]
			public DateTime ExpectedDeliveryDate { get; set; } 
			[DataMember]
			public String ExpectedDeliveryNumber { get; set; } 
			[DataMember]
			public DateTime ExpDeliveryHeader_DateOfCreation { get; set; } 
			[DataMember]
			public Guid LOG_RCP_Receipt_HeaderID { get; set; } 
			[DataMember]
			public String ReceiptNumber { get; set; } 
			[DataMember]
			public bool IsTakenIntoStock { get; set; } 
			[DataMember]
			public bool IsQualityControlPerformed { get; set; } 
			[DataMember]
			public bool IsPriceConditionsManuallyCleared { get; set; } 
			[DataMember]
			public bool IsReceiptForwardedToBookkeeping { get; set; } 
			[DataMember]
			public String ProcurementOrder_Number { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid CMN_BPT_Supplier_TypeID { get; set; } 
			[DataMember]
			public string SupplierType { get; set; } 
			[DataMember]
			public string CurrencySymbol { get; set; } 

		}
		#endregion
		#region SClass L5ALSR_GSRfT_1016_ord_prc_expecteddelivery_positions for attribute Positions
		[DataContract]
		public class L5ALSR_GSRfT_1016_ord_prc_expecteddelivery_positions 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ExpectedDelivery_PositionID { get; set; } 
			[DataMember]
			public double TotalExpectedQuantity { get; set; } 
			[DataMember]
			public decimal Position_ValuePerUnit { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5ALSR_GSRfT_1016_Array cls_Get_StockReceipts_for_TenantID(,P_L5ALSR_GSRfT_1016 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5ALSR_GSRfT_1016_Array invocationResult = cls_Get_StockReceipts_for_TenantID.Invoke(connectionString,P_L5ALSR_GSRfT_1016 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Atomic.Retrieval.P_L5ALSR_GSRfT_1016();
parameter.SupplierName = ...;
parameter.ReceiptNumber = ...;
parameter.ProcurementOrderNumber = ...;
parameter.DateFrom = ...;
parameter.DateTo = ...;
parameter.IsTakenIntoStock = ...;
parameter.IsQualityControlPerformed = ...;
parameter.IsPriceConditionsManuallyCleared = ...;
parameter.IsReceiptForwardedToBookkeeping = ...;
parameter.SupplierTypeID = ...;

*/
