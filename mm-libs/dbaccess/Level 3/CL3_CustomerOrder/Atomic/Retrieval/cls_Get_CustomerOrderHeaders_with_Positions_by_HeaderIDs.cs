/* 
 * Generated on 7/28/2014 5:07:57 PM
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
    /// var result = cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CO_GCOHwPbH_1604_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_GCOHwPbH_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CO_GCOHwPbH_1604_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_CustomerOrder.Atomic.Retrieval.SQL.cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@CustomerOrderHeaderIDs"," IN $$CustomerOrderHeaderIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$CustomerOrderHeaderIDs$",Parameter.CustomerOrderHeaderIDs);


			List<L3CO_GCOHwPbH_1604_raw> results = new List<L3CO_GCOHwPbH_1604_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","CustomerOrder_Number","CustomerOrder_Date","TotalValue_BeforeTax","IsCustomerOrderFinalized","OrderCreatedBy","OrderedByCompanyInfoId","OrderedByCompanyName","OrderedByEmail","Status_Code","Status_Name_DictID","GlobalPropertyMatchingID","ConfirmedBy_DisplayName","ORD_CUO_CustomerOrder_PositionID","CMN_PRO_Product_RefID","Product_Name_DictID","Product_Number","Position_ValueTotal","Position_ValuePerUnit","Position_Quantity","ApplicableSalesTax_RefID","TaxRate","TaxName_DictID","EconomicRegion_RefID" });
				while(reader.Read())
				{
					L3CO_GCOHwPbH_1604_raw resultItem = new L3CO_GCOHwPbH_1604_raw();
					//0:Parameter ORD_CUO_CustomerOrder_HeaderID of type Guid
					resultItem.ORD_CUO_CustomerOrder_HeaderID = reader.GetGuid(0);
					//1:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(1);
					//2:Parameter CustomerOrder_Date of type DateTime
					resultItem.CustomerOrder_Date = reader.GetDate(2);
					//3:Parameter TotalValue_BeforeTax of type decimal
					resultItem.TotalValue_BeforeTax = reader.GetDecimal(3);
					//4:Parameter IsCustomerOrderFinalized of type bool
					resultItem.IsCustomerOrderFinalized = reader.GetBoolean(4);
					//5:Parameter OrderCreatedBy of type String
					resultItem.OrderCreatedBy = reader.GetString(5);
					//6:Parameter OrderedByCompanyInfoId of type Guid
					resultItem.OrderedByCompanyInfoId = reader.GetGuid(6);
					//7:Parameter OrderedByCompanyName of type String
					resultItem.OrderedByCompanyName = reader.GetString(7);
					//8:Parameter OrderedByEmail of type String
					resultItem.OrderedByEmail = reader.GetString(8);
					//9:Parameter Status_Code of type String
					resultItem.Status_Code = reader.GetString(9);
					//10:Parameter Status_Name of type Dict
					resultItem.Status_Name = reader.GetDictionary(10);
					resultItem.Status_Name.SourceTable = "ord_cuo_customerorder_statuses";
					loader.Append(resultItem.Status_Name);
					//11:Parameter GlobalPropertyMatchingID of type string
					resultItem.GlobalPropertyMatchingID = reader.GetString(11);
					//12:Parameter ConfirmedBy_DisplayName of type String
					resultItem.ConfirmedBy_DisplayName = reader.GetString(12);
					//13:Parameter ORD_CUO_CustomerOrder_PositionID of type Guid
					resultItem.ORD_CUO_CustomerOrder_PositionID = reader.GetGuid(13);
					//14:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(14);
					//15:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(15);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//16:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(16);
					//17:Parameter Position_ValueTotal of type decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(17);
					//18:Parameter Position_ValuePerUnit of type decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(18);
					//19:Parameter Position_Quantity of type double
					resultItem.Position_Quantity = reader.GetDouble(19);
					//20:Parameter ApplicableSalesTax_RefID of type Guid
					resultItem.ApplicableSalesTax_RefID = reader.GetGuid(20);
					//21:Parameter TaxRate of type double
					resultItem.TaxRate = reader.GetDouble(21);
					//22:Parameter TaxName of type Dict
					resultItem.TaxName = reader.GetDictionary(22);
					resultItem.TaxName.SourceTable = "acc_tax_taxes";
					loader.Append(resultItem.TaxName);
					//23:Parameter EconomicRegion_RefID of type Guid
					resultItem.EconomicRegion_RefID = reader.GetGuid(23);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3CO_GCOHwPbH_1604_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CO_GCOHwPbH_1604_Array Invoke(string ConnectionString,P_L3CO_GCOHwPbH_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CO_GCOHwPbH_1604_Array Invoke(DbConnection Connection,P_L3CO_GCOHwPbH_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CO_GCOHwPbH_1604_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_GCOHwPbH_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CO_GCOHwPbH_1604_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_GCOHwPbH_1604 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CO_GCOHwPbH_1604_Array functionReturn = new FR_L3CO_GCOHwPbH_1604_Array();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3CO_GCOHwPbH_1604_raw 
	{
		public Guid ORD_CUO_CustomerOrder_HeaderID; 
		public String CustomerOrder_Number; 
		public DateTime CustomerOrder_Date; 
		public decimal TotalValue_BeforeTax; 
		public bool IsCustomerOrderFinalized; 
		public String OrderCreatedBy; 
		public Guid OrderedByCompanyInfoId; 
		public String OrderedByCompanyName; 
		public String OrderedByEmail; 
		public String Status_Code; 
		public Dict Status_Name; 
		public string GlobalPropertyMatchingID; 
		public String ConfirmedBy_DisplayName; 
		public Guid ORD_CUO_CustomerOrder_PositionID; 
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


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3CO_GCOHwPbH_1604[] Convert(List<L3CO_GCOHwPbH_1604_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3CO_GCOHwPbH_1604 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_HeaderID)).ToArray()
	group el_L3CO_GCOHwPbH_1604 by new 
	{ 
		el_L3CO_GCOHwPbH_1604.ORD_CUO_CustomerOrder_HeaderID,

	}
	into gfunct_L3CO_GCOHwPbH_1604
	select new L3CO_GCOHwPbH_1604
	{     
		ORD_CUO_CustomerOrder_HeaderID = gfunct_L3CO_GCOHwPbH_1604.Key.ORD_CUO_CustomerOrder_HeaderID ,
		CustomerOrder_Number = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().CustomerOrder_Number ,
		CustomerOrder_Date = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().CustomerOrder_Date ,
		TotalValue_BeforeTax = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().TotalValue_BeforeTax ,
		IsCustomerOrderFinalized = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().IsCustomerOrderFinalized ,
		OrderCreatedBy = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().OrderCreatedBy ,
		OrderedByCompanyInfoId = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().OrderedByCompanyInfoId ,
		OrderedByCompanyName = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().OrderedByCompanyName ,
		OrderedByEmail = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().OrderedByEmail ,
		Status_Code = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().Status_Code ,
		Status_Name = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().Status_Name ,
		GlobalPropertyMatchingID = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().GlobalPropertyMatchingID ,
		ConfirmedBy_DisplayName = gfunct_L3CO_GCOHwPbH_1604.FirstOrDefault().ConfirmedBy_DisplayName ,

		Positions = 
		(
			from el_Positions in gfunct_L3CO_GCOHwPbH_1604.Where(element => !EqualsDefaultValue(element.ORD_CUO_CustomerOrder_PositionID)).ToArray()
			group el_Positions by new 
			{ 
				el_Positions.ORD_CUO_CustomerOrder_PositionID,

			}
			into gfunct_Positions
			select new L3CO_GCOHwPbH_1604a
			{     
				ORD_CUO_CustomerOrder_PositionID = gfunct_Positions.Key.ORD_CUO_CustomerOrder_PositionID ,
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

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3CO_GCOHwPbH_1604_Array : FR_Base
	{
		public L3CO_GCOHwPbH_1604[] Result	{ get; set; } 
		public FR_L3CO_GCOHwPbH_1604_Array() : base() {}

		public FR_L3CO_GCOHwPbH_1604_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CO_GCOHwPbH_1604 for attribute P_L3CO_GCOHwPbH_1604
		[DataContract]
		public class P_L3CO_GCOHwPbH_1604 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CustomerOrderHeaderIDs { get; set; } 

		}
		#endregion
		#region SClass L3CO_GCOHwPbH_1604 for attribute L3CO_GCOHwPbH_1604
		[DataContract]
		public class L3CO_GCOHwPbH_1604 
		{
			[DataMember]
			public L3CO_GCOHwPbH_1604a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_HeaderID { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 
			[DataMember]
			public DateTime CustomerOrder_Date { get; set; } 
			[DataMember]
			public decimal TotalValue_BeforeTax { get; set; } 
			[DataMember]
			public bool IsCustomerOrderFinalized { get; set; } 
			[DataMember]
			public String OrderCreatedBy { get; set; } 
			[DataMember]
			public Guid OrderedByCompanyInfoId { get; set; } 
			[DataMember]
			public String OrderedByCompanyName { get; set; } 
			[DataMember]
			public String OrderedByEmail { get; set; } 
			[DataMember]
			public String Status_Code { get; set; } 
			[DataMember]
			public Dict Status_Name { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String ConfirmedBy_DisplayName { get; set; } 

		}
		#endregion
		#region SClass L3CO_GCOHwPbH_1604a for attribute Positions
		[DataContract]
		public class L3CO_GCOHwPbH_1604a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_PositionID { get; set; } 
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

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CO_GCOHwPbH_1604_Array cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs(,P_L3CO_GCOHwPbH_1604 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CO_GCOHwPbH_1604_Array invocationResult = cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs.Invoke(connectionString,P_L3CO_GCOHwPbH_1604 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Atomic.Retrieval.P_L3CO_GCOHwPbH_1604();
parameter.CustomerOrderHeaderIDs = ...;

*/
