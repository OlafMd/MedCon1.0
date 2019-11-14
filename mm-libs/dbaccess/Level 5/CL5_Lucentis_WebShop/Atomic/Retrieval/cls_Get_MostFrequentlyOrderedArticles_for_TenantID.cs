/* 
 * Generated on 12/20/2013 5:56:15 PM
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

namespace CL5_Lucentis_WebShop.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MostFrequentlyOrderedArticles_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MostFrequentlyOrderedArticles_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WS_GMFOA_1548_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5WS_GMFOA_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5WS_GMFOA_1548_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_WebShop.Atomic.Retrieval.SQL.cls_Get_MostFrequentlyOrderedArticles_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductGroupMatchingID", Parameter.ProductGroupMatchingID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfLastDays", Parameter.NumberOfLastDays);



			List<L5WS_GMFOA_1548> results = new List<L5WS_GMFOA_1548>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","Product_Name_DictID","Product_Description_DictID","Product_Number","HEC_Product_DosageFormID","DosageForm_Name_DictID","CMN_UnitID","Label_DictID","Quantity","Price","CurrencyISO" });
				while(reader.Read())
				{
					L5WS_GMFOA_1548 resultItem = new L5WS_GMFOA_1548();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(1);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//2:Parameter Product_Description of type Dict
					resultItem.Product_Description = reader.GetDictionary(2);
					resultItem.Product_Description.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Description);
					//3:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(3);
					//4:Parameter HEC_Product_DosageFormID of type Guid
					resultItem.HEC_Product_DosageFormID = reader.GetGuid(4);
					//5:Parameter DosageForm_Name of type Dict
					resultItem.DosageForm_Name = reader.GetDictionary(5);
					resultItem.DosageForm_Name.SourceTable = "hec_product_dosageforms";
					loader.Append(resultItem.DosageForm_Name);
					//6:Parameter CMN_UnitID of type Guid
					resultItem.CMN_UnitID = reader.GetGuid(6);
					//7:Parameter Label of type Dict
					resultItem.Label = reader.GetDictionary(7);
					resultItem.Label.SourceTable = "cmn_units";
					loader.Append(resultItem.Label);
					//8:Parameter Quantity of type String
					resultItem.Quantity = reader.GetString(8);
					//9:Parameter Price of type double
					resultItem.Price = reader.GetDouble(9);
					//10:Parameter CurrencyISO of type String
					resultItem.CurrencyISO = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_MostFrequentlyOrderedArticles_for_TenantID",ex);
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
		public static FR_L5WS_GMFOA_1548_Array Invoke(string ConnectionString,P_L5WS_GMFOA_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WS_GMFOA_1548_Array Invoke(DbConnection Connection,P_L5WS_GMFOA_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WS_GMFOA_1548_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WS_GMFOA_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WS_GMFOA_1548_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WS_GMFOA_1548 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WS_GMFOA_1548_Array functionReturn = new FR_L5WS_GMFOA_1548_Array();
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

				throw new Exception("Exception occured in method cls_Get_MostFrequentlyOrderedArticles_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5WS_GMFOA_1548_Array : FR_Base
	{
		public L5WS_GMFOA_1548[] Result	{ get; set; } 
		public FR_L5WS_GMFOA_1548_Array() : base() {}

		public FR_L5WS_GMFOA_1548_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5WS_GMFOA_1548 for attribute P_L5WS_GMFOA_1548
		[DataContract]
		public class P_L5WS_GMFOA_1548 
		{
			//Standard type parameters
			[DataMember]
			public String ProductGroupMatchingID { get; set; } 
			[DataMember]
			public String NumberOfLastDays { get; set; } 

		}
		#endregion
		#region SClass L5WS_GMFOA_1548 for attribute L5WS_GMFOA_1548
		[DataContract]
		public class L5WS_GMFOA_1548 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public Dict Product_Description { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid HEC_Product_DosageFormID { get; set; } 
			[DataMember]
			public Dict DosageForm_Name { get; set; } 
			[DataMember]
			public Guid CMN_UnitID { get; set; } 
			[DataMember]
			public Dict Label { get; set; } 
			[DataMember]
			public String Quantity { get; set; } 
			[DataMember]
			public double Price { get; set; } 
			[DataMember]
			public String CurrencyISO { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WS_GMFOA_1548_Array cls_Get_MostFrequentlyOrderedArticles_for_TenantID(,P_L5WS_GMFOA_1548 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WS_GMFOA_1548_Array invocationResult = cls_Get_MostFrequentlyOrderedArticles_for_TenantID.Invoke(connectionString,P_L5WS_GMFOA_1548 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_WebShop.Atomic.Retrieval.P_L5WS_GMFOA_1548();
parameter.ProductGroupMatchingID = ...;
parameter.NumberOfLastDays = ...;

*/
