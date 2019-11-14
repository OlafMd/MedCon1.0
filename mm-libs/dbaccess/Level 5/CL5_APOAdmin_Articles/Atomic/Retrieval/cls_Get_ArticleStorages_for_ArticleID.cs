/* 
 * Generated on 10/8/2014 12:13:57 PM
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

namespace CL5_APOAdmin_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ArticleStorages_for_ArticleID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ArticleStorages_for_ArticleID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_GASfA_1520_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_GASfA_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AR_GASfA_1520_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Articles.Atomic.Retrieval.SQL.cls_Get_ArticleStorages_for_ArticleID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ArticleID", Parameter.ArticleID);



			List<L5AR_GASfA_1520> results = new List<L5AR_GASfA_1520>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_WRH_QuantityLevelID","Quantity_Minimum","Quantity_RecommendedMinimumCalculation","Quantity_Maximum","ArticleID","AreaID","RackID","QLAreaID","QLRackID","QLShelfID","AreaCode","RackCode","ShelfCode","IsPointOfSalesArea","IsLongTermStorageArea","LocationPriority","PredefinedProductLocationID" });
				while(reader.Read())
				{
					L5AR_GASfA_1520 resultItem = new L5AR_GASfA_1520();
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
					//5:Parameter AreaID of type Guid
					resultItem.AreaID = reader.GetGuid(5);
					//6:Parameter RackID of type Guid
					resultItem.RackID = reader.GetGuid(6);
					//7:Parameter QLAreaID of type Guid
					resultItem.QLAreaID = reader.GetGuid(7);
					//8:Parameter QLRackID of type Guid
					resultItem.QLRackID = reader.GetGuid(8);
					//9:Parameter QLShelfID of type Guid
					resultItem.QLShelfID = reader.GetGuid(9);
					//10:Parameter AreaCode of type string
					resultItem.AreaCode = reader.GetString(10);
					//11:Parameter RackCode of type string
					resultItem.RackCode = reader.GetString(11);
					//12:Parameter ShelfCode of type string
					resultItem.ShelfCode = reader.GetString(12);
					//13:Parameter IsPointOfSalesArea of type Boolean
					resultItem.IsPointOfSalesArea = reader.GetBoolean(13);
					//14:Parameter IsLongTermStorageArea of type Boolean
					resultItem.IsLongTermStorageArea = reader.GetBoolean(14);
					//15:Parameter LocationPriority of type int
					resultItem.LocationPriority = reader.GetInteger(15);
					//16:Parameter PredefinedProductLocationID of type Guid
					resultItem.PredefinedProductLocationID = reader.GetGuid(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ArticleStorages_for_ArticleID",ex);
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
		public static FR_L5AR_GASfA_1520_Array Invoke(string ConnectionString,P_L5AR_GASfA_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_GASfA_1520_Array Invoke(DbConnection Connection,P_L5AR_GASfA_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_GASfA_1520_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_GASfA_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_GASfA_1520_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_GASfA_1520 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_GASfA_1520_Array functionReturn = new FR_L5AR_GASfA_1520_Array();
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

				throw new Exception("Exception occured in method cls_Get_ArticleStorages_for_ArticleID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_GASfA_1520_Array : FR_Base
	{
		public L5AR_GASfA_1520[] Result	{ get; set; } 
		public FR_L5AR_GASfA_1520_Array() : base() {}

		public FR_L5AR_GASfA_1520_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_GASfA_1520 for attribute P_L5AR_GASfA_1520
		[DataContract]
		public class P_L5AR_GASfA_1520 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 

		}
		#endregion
		#region SClass L5AR_GASfA_1520 for attribute L5AR_GASfA_1520
		[DataContract]
		public class L5AR_GASfA_1520 
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
			public Guid AreaID { get; set; } 
			[DataMember]
			public Guid RackID { get; set; } 
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
			public Boolean IsPointOfSalesArea { get; set; } 
			[DataMember]
			public Boolean IsLongTermStorageArea { get; set; } 
			[DataMember]
			public int LocationPriority { get; set; } 
			[DataMember]
			public Guid PredefinedProductLocationID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_GASfA_1520_Array cls_Get_ArticleStorages_for_ArticleID(,P_L5AR_GASfA_1520 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_GASfA_1520_Array invocationResult = cls_Get_ArticleStorages_for_ArticleID.Invoke(connectionString,P_L5AR_GASfA_1520 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Atomic.Retrieval.P_L5AR_GASfA_1520();
parameter.ArticleID = ...;

*/
