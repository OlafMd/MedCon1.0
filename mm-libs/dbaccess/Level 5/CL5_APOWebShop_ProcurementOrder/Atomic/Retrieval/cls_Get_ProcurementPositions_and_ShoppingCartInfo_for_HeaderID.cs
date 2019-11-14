/* 
 * Generated on 4/17/2014 9:31:26 AM
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

namespace CL5_APOWebShop_ProcurementOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PO_GPPaSCIfH_1750_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_GPPaSCIfH_1750 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PO_GPPaSCIfH_1750_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOWebShop_ProcurementOrder.Atomic.Retrieval.SQL.cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProcurementOrderHeaderID", Parameter.ProcurementOrderHeaderID);



			List<L5PO_GPPaSCIfH_1750> results = new List<L5PO_GPPaSCIfH_1750>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ProcurementOrder_Header_RefID","ORD_PRC_ProcurementOrder_PositionID","ORD_PRC_ShoppingCart_ProductID","ORD_PRC_ShoppingCart_RefID","Position_Quantity","Position_ValuePerUnit","Position_ValueTotal","IsProductReplacementAllowed","CMN_PRO_Product_RefID","CMN_PRO_Product_Variant_RefID","CMN_PRO_Product_Release_RefID","CMN_STR_OfficeID","Office_InternalNumber" });
				while(reader.Read())
				{
					L5PO_GPPaSCIfH_1750 resultItem = new L5PO_GPPaSCIfH_1750();
					//0:Parameter ProcurementOrder_Header_RefID of type Guid
					resultItem.ProcurementOrder_Header_RefID = reader.GetGuid(0);
					//1:Parameter ORD_PRC_ProcurementOrder_PositionID of type Guid
					resultItem.ORD_PRC_ProcurementOrder_PositionID = reader.GetGuid(1);
					//2:Parameter ORD_PRC_ShoppingCart_ProductID of type Guid
					resultItem.ORD_PRC_ShoppingCart_ProductID = reader.GetGuid(2);
					//3:Parameter ORD_PRC_ShoppingCart_RefID of type Guid
					resultItem.ORD_PRC_ShoppingCart_RefID = reader.GetGuid(3);
					//4:Parameter Position_Quantity of type double
					resultItem.Position_Quantity = reader.GetDouble(4);
					//5:Parameter Position_ValuePerUnit of type Decimal
					resultItem.Position_ValuePerUnit = reader.GetDecimal(5);
					//6:Parameter Position_ValueTotal of type Decimal
					resultItem.Position_ValueTotal = reader.GetDecimal(6);
					//7:Parameter IsProductReplacementAllowed of type Boolean
					resultItem.IsProductReplacementAllowed = reader.GetBoolean(7);
					//8:Parameter CMN_PRO_Product_RefID of type Guid
					resultItem.CMN_PRO_Product_RefID = reader.GetGuid(8);
					//9:Parameter CMN_PRO_Product_Variant_RefID of type Guid
					resultItem.CMN_PRO_Product_Variant_RefID = reader.GetGuid(9);
					//10:Parameter CMN_PRO_Product_Release_RefID of type Guid
					resultItem.CMN_PRO_Product_Release_RefID = reader.GetGuid(10);
					//11:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(11);
					//12:Parameter Office_InternalNumber of type String
					resultItem.Office_InternalNumber = reader.GetString(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID",ex);
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
		public static FR_L5PO_GPPaSCIfH_1750_Array Invoke(string ConnectionString,P_L5PO_GPPaSCIfH_1750 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PO_GPPaSCIfH_1750_Array Invoke(DbConnection Connection,P_L5PO_GPPaSCIfH_1750 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PO_GPPaSCIfH_1750_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_GPPaSCIfH_1750 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PO_GPPaSCIfH_1750_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_GPPaSCIfH_1750 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PO_GPPaSCIfH_1750_Array functionReturn = new FR_L5PO_GPPaSCIfH_1750_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PO_GPPaSCIfH_1750_Array : FR_Base
	{
		public L5PO_GPPaSCIfH_1750[] Result	{ get; set; } 
		public FR_L5PO_GPPaSCIfH_1750_Array() : base() {}

		public FR_L5PO_GPPaSCIfH_1750_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PO_GPPaSCIfH_1750 for attribute P_L5PO_GPPaSCIfH_1750
		[DataContract]
		public class P_L5PO_GPPaSCIfH_1750 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5PO_GPPaSCIfH_1750 for attribute L5PO_GPPaSCIfH_1750
		[DataContract]
		public class L5PO_GPPaSCIfH_1750 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrder_Header_RefID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_PositionID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ShoppingCart_ProductID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ShoppingCart_RefID { get; set; } 
			[DataMember]
			public double Position_Quantity { get; set; } 
			[DataMember]
			public Decimal Position_ValuePerUnit { get; set; } 
			[DataMember]
			public Decimal Position_ValueTotal { get; set; } 
			[DataMember]
			public Boolean IsProductReplacementAllowed { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Variant_RefID { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_Release_RefID { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public String Office_InternalNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PO_GPPaSCIfH_1750_Array cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID(,P_L5PO_GPPaSCIfH_1750 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PO_GPPaSCIfH_1750_Array invocationResult = cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID.Invoke(connectionString,P_L5PO_GPPaSCIfH_1750 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ProcurementOrder.Atomic.Retrieval.P_L5PO_GPPaSCIfH_1750();
parameter.ProcurementOrderHeaderID = ...;

*/
