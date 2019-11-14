/* 
 * Generated on 12/10/2014 1:55:25 PM
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

namespace CL3_User.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_UserBasicInfo_for_UserAccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_UserBasicInfo_for_UserAccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3US_GUBIfUA_1057 Execute(DbConnection Connection,DbTransaction Transaction,P_L3US_GUBIfUA_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3US_GUBIfUA_1057();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_User.Atomic.Retrieval.SQL.cls_Get_UserBasicInfo_for_UserAccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"UserAccountID", Parameter.UserAccountID);



			List<L3US_GUBIfUA_1057> results = new List<L3US_GUBIfUA_1057>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FirstName","LastName","PrimaryEmail","File_ServerLocation" });
				while(reader.Read())
				{
					L3US_GUBIfUA_1057 resultItem = new L3US_GUBIfUA_1057();
					//0:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(0);
					//1:Parameter LastName of type String
					resultItem.LastName = reader.GetString(1);
					//2:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(2);
					//3:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_UserBasicInfo_for_UserAccountID",ex);
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
		public static FR_L3US_GUBIfUA_1057 Invoke(string ConnectionString,P_L3US_GUBIfUA_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3US_GUBIfUA_1057 Invoke(DbConnection Connection,P_L3US_GUBIfUA_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3US_GUBIfUA_1057 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3US_GUBIfUA_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3US_GUBIfUA_1057 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3US_GUBIfUA_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3US_GUBIfUA_1057 functionReturn = new FR_L3US_GUBIfUA_1057();
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

				throw new Exception("Exception occured in method cls_Get_UserBasicInfo_for_UserAccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3US_GUBIfUA_1057 : FR_Base
	{
		public L3US_GUBIfUA_1057 Result	{ get; set; }

		public FR_L3US_GUBIfUA_1057() : base() {}

		public FR_L3US_GUBIfUA_1057(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3US_GUBIfUA_1057 for attribute P_L3US_GUBIfUA_1057
		[DataContract]
		public class P_L3US_GUBIfUA_1057 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserAccountID { get; set; } 

		}
		#endregion
		#region SClass L3US_GUBIfUA_1057 for attribute L3US_GUBIfUA_1057
		[DataContract]
		public class L3US_GUBIfUA_1057 
		{
			//Standard type parameters
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3US_GUBIfUA_1057 cls_Get_UserBasicInfo_for_UserAccountID(,P_L3US_GUBIfUA_1057 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3US_GUBIfUA_1057 invocationResult = cls_Get_UserBasicInfo_for_UserAccountID.Invoke(connectionString,P_L3US_GUBIfUA_1057 Parameter,securityTicket);
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
var parameter = new CL3_User.Atomic.Retrieval.P_L3US_GUBIfUA_1057();
parameter.UserAccountID = ...;

*/
