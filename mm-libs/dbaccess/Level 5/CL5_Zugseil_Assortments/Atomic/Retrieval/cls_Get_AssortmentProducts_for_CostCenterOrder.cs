/* 
 * Generated on 1/12/2015 06:07:36
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

namespace CL5_Zugseil_Assortments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AssortmentProducts_for_CostCenterOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AssortmentProducts_for_CostCenterOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AS_GAPfCCO_1931_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AS_GAPfCCO_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AS_GAPfCCO_1931_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Zugseil_Assortments.Atomic.Retrieval.SQL.cls_Get_AssortmentProducts_for_CostCenterOrder.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CurrencyID", Parameter.CurrencyID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AssortmentID", Parameter.AssortmentID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriteria", Parameter.SearchCriteria);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PageSize", Parameter.PageSize);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ActivePage", Parameter.ActivePage);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);



			List<L5AS_GAPfCCO_1931> results = new List<L5AS_GAPfCCO_1931>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Name_DictID","Product_Number","CMN_PRO_ProductID","PriceValue_Amount","Content" });
				while(reader.Read())
				{
					L5AS_GAPfCCO_1931 resultItem = new L5AS_GAPfCCO_1931();
					//0:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(0);
					resultItem.Product_Name.SourceTable = "cmn_pro_products";
					loader.Append(resultItem.Product_Name);
					//1:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(1);
					//2:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(2);
					//3:Parameter PriceValue_Amount of type double
					resultItem.PriceValue_Amount = reader.GetDouble(3);
					//4:Parameter Content of type String
					resultItem.Content = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AssortmentProducts_for_CostCenterOrder",ex);
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
		public static FR_L5AS_GAPfCCO_1931_Array Invoke(string ConnectionString,P_L5AS_GAPfCCO_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AS_GAPfCCO_1931_Array Invoke(DbConnection Connection,P_L5AS_GAPfCCO_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AS_GAPfCCO_1931_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AS_GAPfCCO_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AS_GAPfCCO_1931_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AS_GAPfCCO_1931 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AS_GAPfCCO_1931_Array functionReturn = new FR_L5AS_GAPfCCO_1931_Array();
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

				throw new Exception("Exception occured in method cls_Get_AssortmentProducts_for_CostCenterOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AS_GAPfCCO_1931_Array : FR_Base
	{
		public L5AS_GAPfCCO_1931[] Result	{ get; set; } 
		public FR_L5AS_GAPfCCO_1931_Array() : base() {}

		public FR_L5AS_GAPfCCO_1931_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AS_GAPfCCO_1931 for attribute P_L5AS_GAPfCCO_1931
		[DataContract]
		public class P_L5AS_GAPfCCO_1931 
		{
			//Standard type parameters
			[DataMember]
			public Guid CurrencyID { get; set; } 
			[DataMember]
			public Guid AssortmentID { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public int PageSize { get; set; } 
			[DataMember]
			public int ActivePage { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L5AS_GAPfCCO_1931 for attribute L5AS_GAPfCCO_1931
		[DataContract]
		public class L5AS_GAPfCCO_1931 
		{
			//Standard type parameters
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public double PriceValue_Amount { get; set; } 
			[DataMember]
			public String Content { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AS_GAPfCCO_1931_Array cls_Get_AssortmentProducts_for_CostCenterOrder(,P_L5AS_GAPfCCO_1931 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AS_GAPfCCO_1931_Array invocationResult = cls_Get_AssortmentProducts_for_CostCenterOrder.Invoke(connectionString,P_L5AS_GAPfCCO_1931 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Assortments.Atomic.Retrieval.P_L5AS_GAPfCCO_1931();
parameter.CurrencyID = ...;
parameter.AssortmentID = ...;
parameter.SearchCriteria = ...;
parameter.PageSize = ...;
parameter.ActivePage = ...;
parameter.LanguageID = ...;

*/
