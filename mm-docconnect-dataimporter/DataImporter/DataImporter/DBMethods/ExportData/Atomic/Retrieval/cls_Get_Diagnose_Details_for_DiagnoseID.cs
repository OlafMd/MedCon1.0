/* 
 * Generated on 1/20/2017 2:34:28 PM
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

namespace DataImporter.DBMethods.ExportData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Diagnose_Details_for_DiagnoseID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GDDfDID_1357 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GDDfDID_1357 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GDDfDID_1357();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_Diagnose_Details_for_DiagnoseID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnoseID", Parameter.DiagnoseID);



			List<CAS_GDDfDID_1357> results = new List<CAS_GDDfDID_1357>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "diagnose_id","diagnose_name","diagnose_icd_10","catalog_display_name" });
				while(reader.Read())
				{
					CAS_GDDfDID_1357 resultItem = new CAS_GDDfDID_1357();
					//0:Parameter diagnose_id of type Guid
					resultItem.diagnose_id = reader.GetGuid(0);
					//1:Parameter diagnose_name of type String
					resultItem.diagnose_name = reader.GetString(1);
					//2:Parameter diagnose_icd_10 of type String
					resultItem.diagnose_icd_10 = reader.GetString(2);
					//3:Parameter catalog_display_name of type String
					resultItem.catalog_display_name = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Diagnose_Details_for_DiagnoseID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CAS_GDDfDID_1357 Invoke(string ConnectionString,P_CAS_GDDfDID_1357 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GDDfDID_1357 Invoke(DbConnection Connection,P_CAS_GDDfDID_1357 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GDDfDID_1357 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GDDfDID_1357 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GDDfDID_1357 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GDDfDID_1357 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GDDfDID_1357 functionReturn = new FR_CAS_GDDfDID_1357();
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

				throw new Exception("Exception occured in method cls_Get_Diagnose_Details_for_DiagnoseID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GDDfDID_1357 : FR_Base
	{
		public CAS_GDDfDID_1357 Result	{ get; set; }

		public FR_CAS_GDDfDID_1357() : base() {}

		public FR_CAS_GDDfDID_1357(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GDDfDID_1357 for attribute P_CAS_GDDfDID_1357
		[DataContract]
		public class P_CAS_GDDfDID_1357 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnoseID { get; set; } 

		}
		#endregion
		#region SClass CAS_GDDfDID_1357 for attribute CAS_GDDfDID_1357
		[DataContract]
		public class CAS_GDDfDID_1357 
		{
			//Standard type parameters
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public String diagnose_name { get; set; } 
			[DataMember]
			public String diagnose_icd_10 { get; set; } 
			[DataMember]
			public String catalog_display_name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GDDfDID_1357 cls_Get_Diagnose_Details_for_DiagnoseID(,P_CAS_GDDfDID_1357 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GDDfDID_1357 invocationResult = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(connectionString,P_CAS_GDDfDID_1357 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.ExportData.Atomic.Retrieval.P_CAS_GDDfDID_1357();
parameter.DiagnoseID = ...;

*/
