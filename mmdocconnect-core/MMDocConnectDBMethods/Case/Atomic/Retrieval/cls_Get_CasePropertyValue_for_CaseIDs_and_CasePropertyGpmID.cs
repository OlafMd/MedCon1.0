/* 
 * Generated on 12/19/16 14:07:03
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCPVfCIDsaCGpmID_0832_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GCPVfCIDsaCGpmID_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCPVfCIDsaCGpmID_0832_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@CaseIDs"," IN $$CaseIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$CaseIDs$",Parameter.CaseIDs);
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PropertyGpmID", Parameter.PropertyGpmID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IncludeDeleted", Parameter.IncludeDeleted);



			List<CAS_GCPVfCIDsaCGpmID_0832> results = new List<CAS_GCPVfCIDsaCGpmID_0832>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Value_String","Value_Boolean","Value_Number","ID","CaseID" });
				while(reader.Read())
				{
					CAS_GCPVfCIDsaCGpmID_0832 resultItem = new CAS_GCPVfCIDsaCGpmID_0832();
					//0:Parameter Value_String of type String
					resultItem.Value_String = reader.GetString(0);
					//1:Parameter Value_Boolean of type Boolean
					resultItem.Value_Boolean = reader.GetBoolean(1);
					//2:Parameter Value_Number of type Double
					resultItem.Value_Number = reader.GetDouble(2);
					//3:Parameter ID of type Guid
					resultItem.ID = reader.GetGuid(3);
					//4:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID",ex);
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
		public static FR_CAS_GCPVfCIDsaCGpmID_0832_Array Invoke(string ConnectionString,P_CAS_GCPVfCIDsaCGpmID_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCPVfCIDsaCGpmID_0832_Array Invoke(DbConnection Connection,P_CAS_GCPVfCIDsaCGpmID_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCPVfCIDsaCGpmID_0832_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GCPVfCIDsaCGpmID_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCPVfCIDsaCGpmID_0832_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GCPVfCIDsaCGpmID_0832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCPVfCIDsaCGpmID_0832_Array functionReturn = new FR_CAS_GCPVfCIDsaCGpmID_0832_Array();
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

				throw new Exception("Exception occured in method cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCPVfCIDsaCGpmID_0832_Array : FR_Base
	{
		public CAS_GCPVfCIDsaCGpmID_0832[] Result	{ get; set; } 
		public FR_CAS_GCPVfCIDsaCGpmID_0832_Array() : base() {}

		public FR_CAS_GCPVfCIDsaCGpmID_0832_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GCPVfCIDsaCGpmID_0832 for attribute P_CAS_GCPVfCIDsaCGpmID_0832
		[DataContract]
		public class P_CAS_GCPVfCIDsaCGpmID_0832 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CaseIDs { get; set; } 
			[DataMember]
			public String PropertyGpmID { get; set; } 
			[DataMember]
			public Boolean IncludeDeleted { get; set; } 

		}
		#endregion
		#region SClass CAS_GCPVfCIDsaCGpmID_0832 for attribute CAS_GCPVfCIDsaCGpmID_0832
		[DataContract]
		public class CAS_GCPVfCIDsaCGpmID_0832 
		{
			//Standard type parameters
			[DataMember]
			public String Value_String { get; set; } 
			[DataMember]
			public Boolean Value_Boolean { get; set; } 
			[DataMember]
			public Double Value_Number { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCPVfCIDsaCGpmID_0832_Array cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID(,P_CAS_GCPVfCIDsaCGpmID_0832 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCPVfCIDsaCGpmID_0832_Array invocationResult = cls_Get_CasePropertyValue_for_CaseIDs_and_CasePropertyGpmID.Invoke(connectionString,P_CAS_GCPVfCIDsaCGpmID_0832 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GCPVfCIDsaCGpmID_0832();
parameter.CaseIDs = ...;
parameter.PropertyGpmID = ...;
parameter.IncludeDeleted = ...;

*/
