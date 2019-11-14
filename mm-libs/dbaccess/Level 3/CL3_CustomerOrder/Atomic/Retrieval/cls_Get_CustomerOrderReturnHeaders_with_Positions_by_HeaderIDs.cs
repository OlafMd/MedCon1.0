/* 
 * Generated on 7/30/2014 9:16:39 AM
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

namespace CL3_CustomerOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CO_GCORHwPbH_1610_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_GCORHwPbH_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CO_GCORHwPbH_1610_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@CustomerOrderReturnHeaderIDs"," IN $$CustomerOrderReturnHeaderIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$CustomerOrderReturnHeaderIDs$",Parameter.CustomerOrderReturnHeaderIDs);


			List<L3CO_GCORHwPbH_1610_raw> results = new List<L3CO_GCORHwPbH_1610_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrderReturn_HeaderID","CustomerOrderReturnNumber","DateOfCustomerReturn","CustomerOrderReturnHeaderTotalValue","ReturnOrderCreatedBy","CustomerName","ORD_CUO_CustomerOrderReturn_PositionID","CMN_PRO_Product_RefID","Product_Name_DictID","Product_Number","Position_ValueTotal","Position_ValuePerUnit","Position_Quantity","ApplicableSalesTax_RefID","TaxRate","TaxName_DictID","EconomicRegion_RefID","IsStorage_BatchNumberMandatory","IsStorage_ExpiryDateMandatory","BatchNumber","ExpiryDate","Target_WRH_Shelf_RefID","QuantityInStock" });
				while(reader.Read())
				{
					L3CO_GCORHwPbH_1610_raw resultItem = new L3CO_GCORHwPbH_1610_raw();
					//0:Parameter ORD_CUO_CustomerOrderReturn_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrderReturn_HeaderID = reader.GetGuid(0);
					//1:Parameter CustomerOrderReturnNumber of type String
					resultItem.CustomerOrderReturnNumber = reader.GetString(1);
					//2:Parameter DateOfCustomerReturn of type DateTime
					resultItem.DateOfCustomerReturn = reader.GetDate(2);
					//3:Parameter CustomerOrderReturnHeaderTotalValue of type decimal
					resultItem.CustomerOrderReturnHeaderTotalValue = reader.GetDecimal(3);
					//4:Parameter ReturnOrderCreatedBy of type String
					resultItem.ReturnOrderCreatedBy = reader.GetString(4);
					//5:Parameter CustomerName of type String
					resultItem.CustomerName = reader.GetString(5);
					//6:Parameter ORD_CUO_CustomerOrderReturn_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrderReturn_PositionID = reader.GetGuid(6);
					//7:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(7);
					//8:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(8);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//9:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(9);
					//10:Parameter Position_ValueTotal of type decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(10);
					//11:Parameter Position_ValuePerUnit of type decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(11);
					//12:Parameter Position_Quantity of type double
					resultItem.Position_Quantity = reader.GetDouble(12);
					//13:Parameter ApplicableSalesTax_RefID of type Guid
					resultItem.ApplicableSalesTax_RefID = reader.GetGuid(13);
					//14:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(14);
					//15:Parameter TaxName of type Dict
					resultItem.TaxName = reader.GetDictionary(15);
					resultItem.TaxName.SourceTable = "acc_tax_taxes";
					loader.Append(resultItem.TaxName);
					//16:Parameter EconomicRegion_RefID of type Guid
					resultItem.EconomicRegion_RefID = reader.GetGuid(16);
					//17:Parameter IsStorage_BatchNumberMandatory of type bool
					resultItem.IsStorage_BatchNumberMandatory = reader.GetBoolean(17);
					//18:Parameter IsStorage_ExpiryDateMandatory of type bool
					resultItem.IsStorage_ExpiryDateMandatory = reader.GetBoolean(18);
					//19:Parameter BatchNumber of type string
					resultItem.BatchNumber = reader.GetString(19);
					//20:Parameter ExpiryDate of type DateTime
					resultItem.ExpiryDate = reader.GetDate(20);
					//21:Parameter Target_WRH_Shelf_RefID of type Guid
					resultItem.Target_WRH_Shelf_RefID = reader.GetGuid(21);
					//22:Parameter QuantityInStock of type decimal
					resultItem.QuantityInStock = reader.GetDecimal(22);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3CO_GCORHwPbH_1610_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CO_GCORHwPbH_1610_Array Invoke(string ConnectionString,P_L3CO_GCORHwPbH_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CO_GCORHwPbH_1610_Array Invoke(DbConnection Connection,P_L3CO_GCORHwPbH_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CO_GCORHwPbH_1610_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_GCORHwPbH_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CO_GCORHwPbH_1610_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_GCORHwPbH_1610 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CO_GCORHwPbH_1610_Array functionReturn = new FR_L3CO_GCORHwPbH_1610_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3CO_GCORHwPbH_1610_raw 
	{
		public Guid ORD_CUO_CustomerOrderReturn_HeaderID; 
		public String CustomerOrderReturnNumber; 
		public DateTime DateOfCustomerReturn; 
		public decimal CustomerOrderReturnHeaderTotalValue; 
		public String ReturnOrderCreatedBy; 
		public String CustomerName; 
		public Guid ORD_CUO_CustomerOrderReturn_PositionID; 
		public Guid CMN_PRO_Product_RefID; 
		public Dict Product_Name; 
		public String Product_Number; 
		public decimal Position_ValueTotal; 
		public decimal Position_ValuePerUnit; 
		public double Position_Quantity; 
		public Guid ApplicableSalesTax_RefID; 
		public double TaxRate; 
		public Dict TaxName; 
		public Guid EconomicRegion_RefID; 
		public bool IsStorage_BatchNumberMandatory; 
		public bool IsStorage_ExpiryDateMandatory; 
		public string BatchNumber; 
		public DateTime ExpiryDate; 
		public Guid Target_WRH_Shelf_RefID; 
		public decimal QuantityInStock; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3CO_GCORHwPbH_1610[] Convert(List<L3CO_GCORHwPbH_1610_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3CO_GCORHwPbH_1610 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrderReturn_HeaderID)).ToArray()
	group el_L3CO_GCORHwPbH_1610 by new 
	{ 
		el_L3CO_GCORHwPbH_1610.ORD_CUO_CustomerOrderReturn_HeaderID,

	}
	into gfunct_L3CO_GCORHwPbH_1610
	select new L3CO_GCORHwPbH_1610
	{     
		ORD_CUO_CustomerOrderReturn_HeaderID = gfunct_L3CO_GCORHwPbH_1610.Key.ORD_CUO_CustomerOrderReturn_HeaderID ,
		CustomerOrderReturnNumber = gfunct_L3CO_GCORHwPbH_1610.FirstOrDefault().CustomerOrderReturnNumber ,
		DateOfCustomerReturn = gfunct_L3CO_GCORHwPbH_1610.FirstOrDefault().DateOfCustomerReturn ,
		CustomerOrderReturnHeaderTotalValue = gfunct_L3CO_GCORHwPbH_1610.FirstOrDefault().CustomerOrderReturnHeaderTotalValue ,
		ReturnOrderCreatedBy = gfunct_L3CO_GCORHwPbH_1610.FirstOrDefault().ReturnOrderCreatedBy ,
		CustomerName = gfunct_L3CO_GCORHwPbH_1610.FirstOrDefault().CustomerName ,

		Positions = 
		(
			from el_Positions in gfunct_L3CO_GCORHwPbH_1610.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrderReturn_PositionID)).ToArray()
			group el_Positions by new 
			{ 
				el_Positions.ORD_CUO_CustomerOrderReturn_PositionID,

			}
			into gfunct_Positions
			select new L3CO_GCORHwPbH_1610a
			{     
				ORD_CUO_CustomerOrderReturn_PositionID = gfunct_Positions.Key.ORD_CUO_CustomerOrderReturn_PositionID ,
				CMN_PRO_Product_RefID = gfunct_Positions.FirstOrDefault().CMN_PRO_Product_RefID ,
				Product_Name = gfunct_Positions.FirstOrDefault().Product_Name ,
				Product_Number = gfunct_Positions.FirstOrDefault().Product_Number ,
				Position_ValueTotal = gfunct_Positions.FirstOrDefault().Position_ValueTotal ,
				Position_ValuePerUnit = gfunct_Positions.FirstOrDefault().Position_ValuePerUnit ,
				Position_Quantity = gfunct_Positions.FirstOrDefault().Position_Quantity ,
				ApplicableSalesTax_RefID = gfunct_Positions.FirstOrDefault().ApplicableSalesTax_RefID ,
				TaxRate = gfunct_Positions.FirstOrDefault().TaxRate ,
				TaxName = gfunct_Positions.FirstOrDefault().TaxName ,
				EconomicRegion_RefID = gfunct_Positions.FirstOrDefault().EconomicRegion_RefID ,
				IsStorage_BatchNumberMandatory = gfunct_Positions.FirstOrDefault().IsStorage_BatchNumberMandatory ,
				IsStorage_ExpiryDateMandatory = gfunct_Positions.FirstOrDefault().IsStorage_ExpiryDateMandatory ,
				BatchNumber = gfunct_Positions.FirstOrDefault().BatchNumber ,
				ExpiryDate = gfunct_Positions.FirstOrDefault().ExpiryDate ,
				Target_WRH_Shelf_RefID = gfunct_Positions.FirstOrDefault().Target_WRH_Shelf_RefID ,
				QuantityInStock = gfunct_Positions.FirstOrDefault().QuantityInStock ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3CO_GCORHwPbH_1610_Array : FR_Base
	{
		public L3CO_GCORHwPbH_1610[] Result	{ get; set; } 
		public FR_L3CO_GCORHwPbH_1610_Array() : base() {}

		public FR_L3CO_GCORHwPbH_1610_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CO_GCORHwPbH_1610 for attribute P_L3CO_GCORHwPbH_1610
		[DataContract]
		public class P_L3CO_GCORHwPbH_1610 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CustomerOrderReturnHeaderIDs { get; set; } 

		}
		#endregion
		#region SClass L3CO_GCORHwPbH_1610 for attribute L3CO_GCORHwPbH_1610
		[DataContract]
		public class L3CO_GCORHwPbH_1610 
		{
			[DataMember]
			public L3CO_GCORHwPbH_1610a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrderReturn_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrderReturnNumber { get; set; } 
			[DataMember]
			public DateTime DateOfCustomerReturn { get; set; } 
			[DataMember]
			public decimal CustomerOrderReturnHeaderTotalValue { get; set; } 
			[DataMember]
			public String ReturnOrderCreatedBy { get; set; } 
			[DataMember]
			public String CustomerName { get; set; } 

		}
		#endregion
		#region SClass L3CO_GCORHwPbH_1610a for attribute Positions
		[DataContract]
		public class L3CO_GCORHwPbH_1610a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrderReturn_PositionID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public double Position_Quantity { get; set; } 
			[DataMember]
			public Guid ApplicableSalesTax_RefID { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 
			[DataMember]
			public Dict TaxName { get; set; } 
			[DataMember]
			public Guid EconomicRegion_RefID { get; set; } 
			[DataMember]
			public bool IsStorage_BatchNumberMandatory { get; set; } 
			[DataMember]
			public bool IsStorage_ExpiryDateMandatory { get; set; } 
			[DataMember]
			public string BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 
			[DataMember]
			public Guid Target_WRH_Shelf_RefID { get; set; } 
			[DataMember]
			public decimal QuantityInStock { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CO_GCORHwPbH_1610_Array cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs(,P_L3CO_GCORHwPbH_1610 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CO_GCORHwPbH_1610_Array invocationResult = cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs.Invoke(connectionString,P_L3CO_GCORHwPbH_1610 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Atomic.Retrieval.P_L3CO_GCORHwPbH_1610();
parameter.CustomerOrderReturnHeaderIDs = ...;

*/
