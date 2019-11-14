/* 
 * Generated on 10/27/15 14:33:46
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

namespace MMDocConnectDBMethods.MainData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GDIDfDN_1408 Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GDIDfDN_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GDIDfDN_1408();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnoseNameWithoutSpaces", Parameter.DiagnoseNameWithoutSpaces);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnoseICD10", Parameter.DiagnoseICD10);



			List<MD_GDIDfDN_1408> results = new List<MD_GDIDfDN_1408>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DiagnoseID" });
				while(reader.Read())
				{
					MD_GDIDfDN_1408 resultItem = new MD_GDIDfDN_1408();
					//0:Parameter DiagnoseID of type Guid
					resultItem.DiagnoseID = reader.GetGuid(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName",ex);
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
		public static FR_MD_GDIDfDN_1408 Invoke(string ConnectionString,P_MD_GDIDfDN_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GDIDfDN_1408 Invoke(DbConnection Connection,P_MD_GDIDfDN_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GDIDfDN_1408 Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GDIDfDN_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GDIDfDN_1408 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GDIDfDN_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GDIDfDN_1408 functionReturn = new FR_MD_GDIDfDN_1408();
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

				throw new Exception("Exception occured in method cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GDIDfDN_1408 : FR_Base
	{
		public MD_GDIDfDN_1408 Result	{ get; set; }

		public FR_MD_GDIDfDN_1408() : base() {}

		public FR_MD_GDIDfDN_1408(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GDIDfDN_1408 for attribute P_MD_GDIDfDN_1408
		[DataContract]
		public class P_MD_GDIDfDN_1408 
		{
			//Standard type parameters
			[DataMember]
			public String DiagnoseNameWithoutSpaces { get; set; } 
			[DataMember]
			public String DiagnoseICD10 { get; set; } 

		}
		#endregion
		#region SClass MD_GDIDfDN_1408 for attribute MD_GDIDfDN_1408
		[DataContract]
		public class MD_GDIDfDN_1408 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnoseID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GDIDfDN_1408 cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName(,P_MD_GDIDfDN_1408 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GDIDfDN_1408 invocationResult = cls_Get_DiagnoseID_for_ICD10_and_DiagnoseName.Invoke(connectionString,P_MD_GDIDfDN_1408 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GDIDfDN_1408();
parameter.DiagnoseNameWithoutSpaces = ...;
parameter.DiagnoseICD10 = ...;

*/
