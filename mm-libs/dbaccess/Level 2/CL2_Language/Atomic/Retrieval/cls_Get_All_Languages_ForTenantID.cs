/* 
 * Generated on 5/13/2014 10:10:34 AM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL2_Language.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Languages_ForTenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Languages_ForTenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2LN_GALFTID_1530_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2LN_GALFTID_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2LN_GALFTID_1530_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Language.Atomic.Retrieval.SQL.cls_Get_All_Languages_ForTenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant_RefID", Parameter.Tenant_RefID);



			List<L2LN_GALFTID_1530> results = new List<L2LN_GALFTID_1530>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_LanguageID","ISO_639_1","Name_DictID" });
				while(reader.Read())
				{
					L2LN_GALFTID_1530 resultItem = new L2LN_GALFTID_1530();
					//0:Parameter CMN_LanguageID of type Guid
					resultItem.CMN_LanguageID = reader.GetGuid(0);
					//1:Parameter ISO_639_1 of type String
					resultItem.ISO_639_1 = reader.GetString(1);
					//2:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(2);
					resultItem.Name.SourceTable = "cmn_languages";
					loader.Append(resultItem.Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Languages_ForTenantID",ex);
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
		public static FR_L2LN_GALFTID_1530_Array Invoke(string ConnectionString,P_L2LN_GALFTID_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2LN_GALFTID_1530_Array Invoke(DbConnection Connection,P_L2LN_GALFTID_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2LN_GALFTID_1530_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2LN_GALFTID_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2LN_GALFTID_1530_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2LN_GALFTID_1530 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2LN_GALFTID_1530_Array functionReturn = new FR_L2LN_GALFTID_1530_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Languages_ForTenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2LN_GALFTID_1530_Array : FR_Base
	{
		public L2LN_GALFTID_1530[] Result	{ get; set; } 
		public FR_L2LN_GALFTID_1530_Array() : base() {}

		public FR_L2LN_GALFTID_1530_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2LN_GALFTID_1530 for attribute P_L2LN_GALFTID_1530
		[DataContract]
		public class P_L2LN_GALFTID_1530 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion
		#region SClass L2LN_GALFTID_1530 for attribute L2LN_GALFTID_1530
		[DataContract]
		public class L2LN_GALFTID_1530 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_LanguageID { get; set; } 
			[DataMember]
			public String ISO_639_1 { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2LN_GALFTID_1530_Array cls_Get_All_Languages_ForTenantID(,P_L2LN_GALFTID_1530 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2LN_GALFTID_1530_Array invocationResult = cls_Get_All_Languages_ForTenantID.Invoke(connectionString,P_L2LN_GALFTID_1530 Parameter,securityTicket);
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
var parameter = new CL2_Language.Atomic.Retrieval.P_L2LN_GALFTID_1530();
parameter.Tenant_RefID = ...;

*/
