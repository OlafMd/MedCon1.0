/* 
 * Generated on 1/27/2015 02:42:40
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

namespace CL5_Zugseil_Product.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SupplyChainData_for_Product.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SupplyChainData_for_Product
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GSCDfP_1437_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GSCDfP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PR_GSCDfP_1437_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Product.Atomic.Retrieval.SQL.cls_Get_SupplyChainData_for_Product.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5PR_GSCDfP_1437> results = new List<L5PR_GSCDfP_1437>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "EconomicRegion_Name_DictID","ParentEconomicRegion_RefID","CMN_EconomicRegionID","LOG_WRH_WarehouseID","Warehouse_Name","CMN_BPT_SupplierID","ExternalSupplierProvidedIdentifier","DisplayName","CMN_PRO_Product_SupplierID" });
				while(reader.Read())
				{
					L5PR_GSCDfP_1437 resultItem = new L5PR_GSCDfP_1437();
					//0:Parameter EconomicRegion_Name of type Dict
					resultItem.EconomicRegion_Name = reader.GetDictionary(0);
					resultItem.EconomicRegion_Name.SourceTable = "cmn_economicregion";
					loader.Append(resultItem.EconomicRegion_Name);
					//1:Parameter ParentEconomicRegion_RefID of type Guid
					resultItem.ParentEconomicRegion_RefID = reader.GetGuid(1);
					//2:Parameter CMN_EconomicRegionID of type Guid
					resultItem.CMN_EconomicRegionID = reader.GetGuid(2);
					//3:Parameter LOG_WRH_WarehouseID of type Guid
					resultItem.LOG_WRH_WarehouseID = reader.GetGuid(3);
					//4:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(4);
					//5:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(5);
					//6:Parameter ExternalSupplierProvidedIdentifier of type String
					resultItem.ExternalSupplierProvidedIdentifier = reader.GetString(6);
					//7:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(7);
					//8:Parameter CMN_PRO_Product_SupplierID of type Guid
					resultItem.CMN_PRO_Product_SupplierID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_SupplyChainData_for_Product",ex);
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
		public static FR_L5PR_GSCDfP_1437_Array Invoke(string ConnectionString,P_L5PR_GSCDfP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GSCDfP_1437_Array Invoke(DbConnection Connection,P_L5PR_GSCDfP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GSCDfP_1437_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GSCDfP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GSCDfP_1437_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GSCDfP_1437 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GSCDfP_1437_Array functionReturn = new FR_L5PR_GSCDfP_1437_Array();
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

				throw new Exception("Exception occured in method cls_Get_SupplyChainData_for_Product",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GSCDfP_1437_Array : FR_Base
	{
		public L5PR_GSCDfP_1437[] Result	{ get; set; } 
		public FR_L5PR_GSCDfP_1437_Array() : base() {}

		public FR_L5PR_GSCDfP_1437_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PR_GSCDfP_1437 for attribute P_L5PR_GSCDfP_1437
		[DataContract]
		public class P_L5PR_GSCDfP_1437 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5PR_GSCDfP_1437 for attribute L5PR_GSCDfP_1437
		[DataContract]
		public class L5PR_GSCDfP_1437 
		{
			//Standard type parameters
			[DataMember]
			public Dict EconomicRegion_Name { get; set; } 
			[DataMember]
			public Guid ParentEconomicRegion_RefID { get; set; } 
			[DataMember]
			public Guid CMN_EconomicRegionID { get; set; } 
			[DataMember]
			public Guid LOG_WRH_WarehouseID { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 
			[DataMember]
			public String ExternalSupplierProvidedIdentifier { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid CMN_PRO_Product_SupplierID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GSCDfP_1437_Array cls_Get_SupplyChainData_for_Product(,P_L5PR_GSCDfP_1437 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GSCDfP_1437_Array invocationResult = cls_Get_SupplyChainData_for_Product.Invoke(connectionString,P_L5PR_GSCDfP_1437 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Product.Atomic.Retrieval.P_L5PR_GSCDfP_1437();
parameter.ProductID = ...;

*/
