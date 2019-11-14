/* 
 * Generated on 3/6/2015 13:31:54
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

namespace CL5_Zugseil_CustomerOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrder_with_CustomerOrderPosition_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrder_with_CustomerOrderPosition_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GCOwCOPfH_1232 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_GCOwCOPfH_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CO_GCOwCOPfH_1232();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_CustomerOrder.Complex.Retrieval.SQL.cls_Get_CustomerOrder_with_CustomerOrderPosition_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerOrderHeaderID", Parameter.CustomerOrderHeaderID);



			List<L5CO_GCOwCOPfH_1232> results = new List<L5CO_GCOwCOPfH_1232>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_CUO_CustomerOrder_HeaderID","CustomerOrder_Number","CustomerOrder_Date","TotalValue_BeforeTax","IsCustomerOrderFinalized","OrderCreatedBy","OrderedByCompanyInfoId","OrderedByCompanyName","OrderedByEmail","Status_Code","Status_Name_DictID","GlobalPropertyMatchingID","ConfirmedBy_DisplayName" });
				while(reader.Read())
				{
					L5CO_GCOwCOPfH_1232 resultItem = new L5CO_GCOwCOPfH_1232();
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

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CustomerOrder_with_CustomerOrderPosition_for_HeaderID",ex);
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
		public static FR_L5CO_GCOwCOPfH_1232 Invoke(string ConnectionString,P_L5CO_GCOwCOPfH_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOwCOPfH_1232 Invoke(DbConnection Connection,P_L5CO_GCOwCOPfH_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOwCOPfH_1232 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_GCOwCOPfH_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GCOwCOPfH_1232 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_GCOwCOPfH_1232 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GCOwCOPfH_1232 functionReturn = new FR_L5CO_GCOwCOPfH_1232();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrder_with_CustomerOrderPosition_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GCOwCOPfH_1232 : FR_Base
	{
		public L5CO_GCOwCOPfH_1232 Result	{ get; set; }

		public FR_L5CO_GCOwCOPfH_1232() : base() {}

		public FR_L5CO_GCOwCOPfH_1232(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_GCOwCOPfH_1232 for attribute P_L5CO_GCOwCOPfH_1232
		[DataContract]
		public class P_L5CO_GCOwCOPfH_1232 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5CO_GCOwCOPfH_1232 for attribute L5CO_GCOwCOPfH_1232
		[DataContract]
		public class L5CO_GCOwCOPfH_1232 
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
			public Dict Variant_Name { get; set; } 
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
FR_L5CO_GCOwCOPfH_1232 cls_Get_CustomerOrder_with_CustomerOrderPosition_for_HeaderID(,P_L5CO_GCOwCOPfH_1232 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GCOwCOPfH_1232 invocationResult = cls_Get_CustomerOrder_with_CustomerOrderPosition_for_HeaderID.Invoke(connectionString,P_L5CO_GCOwCOPfH_1232 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_CustomerOrder.Complex.Retrieval.P_L5CO_GCOwCOPfH_1232();
parameter.CustomerOrderHeaderID = ...;

*/
