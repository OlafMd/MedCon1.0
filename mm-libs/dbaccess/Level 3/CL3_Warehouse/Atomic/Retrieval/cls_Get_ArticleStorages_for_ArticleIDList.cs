/* 
 * Generated on 8/14/2014 10:30:33 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_Warehouse.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ArticleStorages_for_ArticleIDList.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ArticleStorages_for_ArticleIDList
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3WH_GASfA_1924_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3WH_GASfA_1924 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3WH_GASfA_1924_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Warehouse.Atomic.Retrieval.SQL.cls_Get_ArticleStorages_for_ArticleIDList.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ArticleID_List"," IN $$ArticleID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ArticleID_List$",Parameter.ArticleID_List);


			List<L3WH_GASfA_1924> results = new List<L3WH_GASfA_1924>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_QuantityLevelID","Quantity_Minimum","Quantity_RecommendedMinimumCalculation","Quantity_Maximum","ArticleID","WarehouseID","AreaID","RackID","ShelfID","QLAreaID","QLRackID","QLShelfID","AreaCode","RackCode","ShelfCode","WarehouseCode","IsPointOfSalesArea","IsLongTermStorageArea" });
				while(reader.Read())
				{
					L3WH_GASfA_1924 resultItem = new L3WH_GASfA_1924();
					//0:Parameter LOG_WRH_QuantityLevelID of type Guid
					resultItem.LOG_WRH_QuantityLevelID = reader.GetGuid(0);
					//1:Parameter Quantity_Minimum of type Double
					resultItem.Quantity_Minimum = reader.GetDouble(1);
					//2:Parameter Quantity_RecommendedMinimumCalculation of type Double
					resultItem.Quantity_RecommendedMinimumCalculation = reader.GetDouble(2);
					//3:Parameter Quantity_Maximum of type Double
					resultItem.Quantity_Maximum = reader.GetDouble(3);
					//4:Parameter ArticleID of type Guid
					resultItem.ArticleID = reader.GetGuid(4);
					//5:Parameter WarehouseID of type Guid
					resultItem.WarehouseID = reader.GetGuid(5);
					//6:Parameter AreaID of type Guid
					resultItem.AreaID = reader.GetGuid(6);
					//7:Parameter RackID of type Guid
					resultItem.RackID = reader.GetGuid(7);
					//8:Parameter ShelfID of type Guid
					resultItem.ShelfID = reader.GetGuid(8);
					//9:Parameter QLAreaID of type Guid
					resultItem.QLAreaID = reader.GetGuid(9);
					//10:Parameter QLRackID of type Guid
					resultItem.QLRackID = reader.GetGuid(10);
					//11:Parameter QLShelfID of type Guid
					resultItem.QLShelfID = reader.GetGuid(11);
					//12:Parameter AreaCode of type string
					resultItem.AreaCode = reader.GetString(12);
					//13:Parameter RackCode of type string
					resultItem.RackCode = reader.GetString(13);
					//14:Parameter ShelfCode of type string
					resultItem.ShelfCode = reader.GetString(14);
					//15:Parameter WarehouseCode of type string
					resultItem.WarehouseCode = reader.GetString(15);
					//16:Parameter IsPointOfSalesArea of type Boolean
					resultItem.IsPointOfSalesArea = reader.GetBoolean(16);
					//17:Parameter IsLongTermStorageArea of type Boolean
					resultItem.IsLongTermStorageArea = reader.GetBoolean(17);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ArticleStorages_for_ArticleIDList",ex);
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
		public static FR_L3WH_GASfA_1924_Array Invoke(string ConnectionString,P_L3WH_GASfA_1924 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3WH_GASfA_1924_Array Invoke(DbConnection Connection,P_L3WH_GASfA_1924 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3WH_GASfA_1924_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3WH_GASfA_1924 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3WH_GASfA_1924_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3WH_GASfA_1924 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3WH_GASfA_1924_Array functionReturn = new FR_L3WH_GASfA_1924_Array();
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

				throw new Exception("Exception occured in method cls_Get_ArticleStorages_for_ArticleIDList",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3WH_GASfA_1924_Array : FR_Base
	{
		public L3WH_GASfA_1924[] Result	{ get; set; } 
		public FR_L3WH_GASfA_1924_Array() : base() {}

		public FR_L3WH_GASfA_1924_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3WH_GASfA_1924 for attribute P_L3WH_GASfA_1924
		[DataContract]
		public class P_L3WH_GASfA_1924 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ArticleID_List { get; set; } 

		}
		#endregion
		#region SClass L3WH_GASfA_1924 for attribute L3WH_GASfA_1924
		[DataContract]
		public class L3WH_GASfA_1924 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_WRH_QuantityLevelID { get; set; } 
			[DataMember]
			public Double Quantity_Minimum { get; set; } 
			[DataMember]
			public Double Quantity_RecommendedMinimumCalculation { get; set; } 
			[DataMember]
			public Double Quantity_Maximum { get; set; } 
			[DataMember]
			public Guid ArticleID { get; set; } 
			[DataMember]
			public Guid WarehouseID { get; set; } 
			[DataMember]
			public Guid AreaID { get; set; } 
			[DataMember]
			public Guid RackID { get; set; } 
			[DataMember]
			public Guid ShelfID { get; set; } 
			[DataMember]
			public Guid QLAreaID { get; set; } 
			[DataMember]
			public Guid QLRackID { get; set; } 
			[DataMember]
			public Guid QLShelfID { get; set; } 
			[DataMember]
			public string AreaCode { get; set; } 
			[DataMember]
			public string RackCode { get; set; } 
			[DataMember]
			public string ShelfCode { get; set; } 
			[DataMember]
			public string WarehouseCode { get; set; } 
			[DataMember]
			public Boolean IsPointOfSalesArea { get; set; } 
			[DataMember]
			public Boolean IsLongTermStorageArea { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3WH_GASfA_1924_Array cls_Get_ArticleStorages_for_ArticleIDList(,P_L3WH_GASfA_1924 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3WH_GASfA_1924_Array invocationResult = cls_Get_ArticleStorages_for_ArticleIDList.Invoke(connectionString,P_L3WH_GASfA_1924 Parameter,securityTicket);
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
var parameter = new CL3_Warehouse.Atomic.Retrieval.P_L3WH_GASfA_1924();
parameter.ArticleID_List = ...;

*/
