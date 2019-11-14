/* 
 * Generated on 3/23/2015 12:26:37
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

namespace CL3_ShelfContent.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Products_NotContainedInShelfList_for_SearchCriteria.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Products_NotContainedInShelfList_for_SearchCriteria
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3SC_GPNCISLfSC_1146_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3SC_GPNCISLfSC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3SC_GPNCISLfSC_1146_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_ShelfContent.Atomic.Retrieval.SQL.cls_Get_Products_NotContainedInShelfList_for_SearchCriteria.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LanguageID", Parameter.LanguageID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"SearchCriteria", Parameter.SearchCriteria);

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ShelfIDs"," IN $$ShelfIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ShelfIDs$",Parameter.ShelfIDs);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfShelves", Parameter.NumberOfShelves);



			List<L3SC_GPNCISLfSC_1146> results = new List<L3SC_GPNCISLfSC_1146>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Product_Number","CMN_PRO_ProductID","Product_Name_DictID" });
				while(reader.Read())
				{
					L3SC_GPNCISLfSC_1146 resultItem = new L3SC_GPNCISLfSC_1146();
					//0:Parameter Product_Number of type String
					resultItem.Product_Number = reader.GetString(0);
					//1:Parameter CMN_PRO_ProductID of type Guid
					resultItem.CMN_PRO_ProductID = reader.GetGuid(1);
					//2:Parameter Product_Name of type Dict
					resultItem.Product_Name = reader.GetDictionary(2);
					resultItem.Product_Name.SourceTable = "CMN_PRO_Products";
					loader.Append(resultItem.Product_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Products_NotContainedInShelfList_for_SearchCriteria",ex);
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
		public static FR_L3SC_GPNCISLfSC_1146_Array Invoke(string ConnectionString,P_L3SC_GPNCISLfSC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3SC_GPNCISLfSC_1146_Array Invoke(DbConnection Connection,P_L3SC_GPNCISLfSC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3SC_GPNCISLfSC_1146_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3SC_GPNCISLfSC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3SC_GPNCISLfSC_1146_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3SC_GPNCISLfSC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3SC_GPNCISLfSC_1146_Array functionReturn = new FR_L3SC_GPNCISLfSC_1146_Array();
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

				throw new Exception("Exception occured in method cls_Get_Products_NotContainedInShelfList_for_SearchCriteria",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3SC_GPNCISLfSC_1146_Array : FR_Base
	{
		public L3SC_GPNCISLfSC_1146[] Result	{ get; set; } 
		public FR_L3SC_GPNCISLfSC_1146_Array() : base() {}

		public FR_L3SC_GPNCISLfSC_1146_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3SC_GPNCISLfSC_1146 for attribute P_L3SC_GPNCISLfSC_1146
		[DataContract]
		public class P_L3SC_GPNCISLfSC_1146 
		{
			//Standard type parameters
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public String SearchCriteria { get; set; } 
			[DataMember]
			public Guid[] ShelfIDs { get; set; } 
			[DataMember]
			public int NumberOfShelves { get; set; } 

		}
		#endregion
		#region SClass L3SC_GPNCISLfSC_1146 for attribute L3SC_GPNCISLfSC_1146
		[DataContract]
		public class L3SC_GPNCISLfSC_1146 
		{
			//Standard type parameters
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public Guid CMN_PRO_ProductID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SC_GPNCISLfSC_1146_Array cls_Get_Products_NotContainedInShelfList_for_SearchCriteria(,P_L3SC_GPNCISLfSC_1146 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SC_GPNCISLfSC_1146_Array invocationResult = cls_Get_Products_NotContainedInShelfList_for_SearchCriteria.Invoke(connectionString,P_L3SC_GPNCISLfSC_1146 Parameter,securityTicket);
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
var parameter = new CL3_ShelfContent.Atomic.Retrieval.P_L3SC_GPNCISLfSC_1146();
parameter.LanguageID = ...;
parameter.SearchCriteria = ...;
parameter.ShelfIDs = ...;
parameter.NumberOfShelves = ...;

*/
