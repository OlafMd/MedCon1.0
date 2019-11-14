/* 
 * Generated on 3/27/2014 11:42:26 AM
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

namespace CL5_APOLogistic_Storage.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_for_StockCorrection_by_Article.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_for_StockCorrection_by_Article
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SG_GDfSCbA_1641_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SG_GDfSCbA_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SG_GDfSCbA_1641_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_Storage.Atomic.Retrieval.SQL.cls_Get_Data_for_StockCorrection_by_Article.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BatchNumber", Parameter.BatchNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ExpirationDate", Parameter.ExpirationDate);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ProductID_List"," IN $$ProductID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ProductID_List$",Parameter.ProductID_List);


			List<L5SG_GDfSCbA_1641> results = new List<L5SG_GDfSCbA_1641>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Number","Product_Name_DictID","DosageFormGlobalPropertyName","DosageForm_Name_DictID","PackageContent_Amount","ISOCode","Quantity_Current","BatchNumber","ExpirationDate","Rack_Name","Shelf_Name","Area_Name","Warehouse_Name","CMN_PRO_ProductID","LOG_ProductTrackingInstanceID","CurrentQuantityOnTrackingInstance","LOG_WRH_Shelf_ContentID" });
				while(reader.Read())
				{
					L5SG_GDfSCbA_1641 resultItem = new L5SG_GDfSCbA_1641();
					//0:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter DosageFormGlobalPropertyName of type String
					resultItem.DosageFormGlobalPropertyName = reader.GetString(2);
					//3:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(3);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//4:Parameter PackageContent_Amount of type String
					resultItem.PackageContent_Amount = reader.GetString(4);
					//5:Parameter ISOCode of type String
					resultItem.ISOCode = reader.GetString(5);
					//6:Parameter Quantity_Current of type double
					resultItem.Quantity_Current = reader.GetDouble(6);
					//7:Parameter BatchNumber of type String
					resultItem.BatchNumber = reader.GetString(7);
					//8:Parameter ExpirationDate of type DateTime
					resultItem.ExpirationDate = reader.GetDate(8);
					//9:Parameter Rack_Name of type String
					resultItem.Rack_Name = reader.GetString(9);
					//10:Parameter Shelf_Name of type String
					resultItem.Shelf_Name = reader.GetString(10);
					//11:Parameter Area_Name of type String
					resultItem.Area_Name = reader.GetString(11);
					//12:Parameter Warehouse_Name of type String
					resultItem.Warehouse_Name = reader.GetString(12);
					//13:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(13);
					//14:Parameter LOG_ProductTrackingInstanceID of type Guid
					resultItem.LOG_ProductTrackingInstanceID = reader.GetGuid(14);
					//15:Parameter CurrentQuantityOnTrackingInstance of type double
					resultItem.CurrentQuantityOnTrackingInstance = reader.GetDouble(15);
					//16:Parameter LOG_WRH_Shelf_ContentID of type Guid
					resultItem.LOG_WRH_Shelf_ContentID = reader.GetGuid(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Data_for_StockCorrection_by_Article",ex);
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
		public static FR_L5SG_GDfSCbA_1641_Array Invoke(string ConnectionString,P_L5SG_GDfSCbA_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SG_GDfSCbA_1641_Array Invoke(DbConnection Connection,P_L5SG_GDfSCbA_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SG_GDfSCbA_1641_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SG_GDfSCbA_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SG_GDfSCbA_1641_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SG_GDfSCbA_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SG_GDfSCbA_1641_Array functionReturn = new FR_L5SG_GDfSCbA_1641_Array();
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

				throw new Exception("Exception occured in method cls_Get_Data_for_StockCorrection_by_Article",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SG_GDfSCbA_1641_Array : FR_Base
	{
		public L5SG_GDfSCbA_1641[] Result	{ get; set; } 
		public FR_L5SG_GDfSCbA_1641_Array() : base() {}

		public FR_L5SG_GDfSCbA_1641_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SG_GDfSCbA_1641 for attribute P_L5SG_GDfSCbA_1641
		[DataContract]
		public class P_L5SG_GDfSCbA_1641 
		{
			//Standard type parameters
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime? ExpirationDate { get; set; } 
			[DataMember]
			public Guid[] ProductID_List { get; set; } 

		}
		#endregion
		#region SClass L5SG_GDfSCbA_1641 for attribute L5SG_GDfSCbA_1641
		[DataContract]
		public class L5SG_GDfSCbA_1641 
		{
			//Standard type parameters
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String DosageFormGlobalPropertyName { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public String PackageContent_Amount { get; set; } 
			[DataMember]
			public String ISOCode { get; set; } 
			[DataMember]
			public double Quantity_Current { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime ExpirationDate { get; set; } 
			[DataMember]
			public String Rack_Name { get; set; } 
			[DataMember]
			public String Shelf_Name { get; set; } 
			[DataMember]
			public String Area_Name { get; set; } 
			[DataMember]
			public String Warehouse_Name { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Guid LOG_ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public double CurrentQuantityOnTrackingInstance { get; set; } 
			[DataMember]
			public Guid LOG_WRH_Shelf_ContentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SG_GDfSCbA_1641_Array cls_Get_Data_for_StockCorrection_by_Article(,P_L5SG_GDfSCbA_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SG_GDfSCbA_1641_Array invocationResult = cls_Get_Data_for_StockCorrection_by_Article.Invoke(connectionString,P_L5SG_GDfSCbA_1641 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_Storage.Atomic.Retrieval.P_L5SG_GDfSCbA_1641();
parameter.BatchNumber = ...;
parameter.ExpirationDate = ...;
parameter.ProductID_List = ...;

*/
