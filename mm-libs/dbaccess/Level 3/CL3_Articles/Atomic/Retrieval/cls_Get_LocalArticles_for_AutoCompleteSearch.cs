/* 
 * Generated on 8/22/2014 1:45:37 PM
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

namespace CL3_Articles.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LocalArticles_for_AutoCompleteSearch.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LocalArticles_for_AutoCompleteSearch
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3AR_GLAfACS_1339_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3AR_GLAfACS_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3AR_GLAfACS_1339_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Articles.Atomic.Retrieval.SQL.cls_Get_LocalArticles_for_AutoCompleteSearch.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCondition", Parameter.SearchCondition);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IsAvailableForOrdering", Parameter.IsAvailableForOrdering);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);



			List<L3AR_GLAfACS_1339> results = new List<L3AR_GLAfACS_1339>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PRO_ProductID","ProductITL","ProductName","Product_Number" });
				while(reader.Read())
				{
					L3AR_GLAfACS_1339 resultItem = new L3AR_GLAfACS_1339();
					//0:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(0);
					//1:Parameter ProductITL of type String
					resultItem.ProductITL = reader.GetString(1);
					//2:Parameter ProductName of type String
					resultItem.ProductName = reader.GetString(2);
					//3:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_LocalArticles_for_AutoCompleteSearch",ex);
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
		public static FR_L3AR_GLAfACS_1339_Array Invoke(string ConnectionString,P_L3AR_GLAfACS_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3AR_GLAfACS_1339_Array Invoke(DbConnection Connection,P_L3AR_GLAfACS_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3AR_GLAfACS_1339_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3AR_GLAfACS_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3AR_GLAfACS_1339_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AR_GLAfACS_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3AR_GLAfACS_1339_Array functionReturn = new FR_L3AR_GLAfACS_1339_Array();
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

				throw new Exception("Exception occured in method cls_Get_LocalArticles_for_AutoCompleteSearch",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3AR_GLAfACS_1339_Array : FR_Base
	{
		public L3AR_GLAfACS_1339[] Result	{ get; set; } 
		public FR_L3AR_GLAfACS_1339_Array() : base() {}

		public FR_L3AR_GLAfACS_1339_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3AR_GLAfACS_1339 for attribute P_L3AR_GLAfACS_1339
		[DataContract]
		public class P_L3AR_GLAfACS_1339 
		{
			//Standard type parameters
			[DataMember]
			public string SearchCondition { get; set; } 
			[DataMember]
			public bool? IsAvailableForOrdering { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L3AR_GLAfACS_1339 for attribute L3AR_GLAfACS_1339
		[DataContract]
		public class L3AR_GLAfACS_1339 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public String ProductName { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AR_GLAfACS_1339_Array cls_Get_LocalArticles_for_AutoCompleteSearch(,P_L3AR_GLAfACS_1339 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AR_GLAfACS_1339_Array invocationResult = cls_Get_LocalArticles_for_AutoCompleteSearch.Invoke(connectionString,P_L3AR_GLAfACS_1339 Parameter,securityTicket);
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
var parameter = new CL3_Articles.Atomic.Retrieval.P_L3AR_GLAfACS_1339();
parameter.SearchCondition = ...;
parameter.IsAvailableForOrdering = ...;
parameter.LanguageID = ...;

*/
