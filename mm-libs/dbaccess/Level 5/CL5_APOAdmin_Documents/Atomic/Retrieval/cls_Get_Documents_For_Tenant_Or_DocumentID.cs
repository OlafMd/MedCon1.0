/* 
 * Generated on 2/5/2014 6:25:59 PM
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

namespace CL5_APOAdmin_Documents.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Documents_For_Tenant_Or_DocumentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Documents_For_Tenant_Or_DocumentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GDfToDID_1731_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GDfToDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GDfToDID_1731_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_Documents.Atomic.Retrieval.SQL.cls_Get_Documents_For_Tenant_Or_DocumentID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DOC_DocumentID", Parameter.DOC_DocumentID);



			List<L5DO_GDfToDID_1731> results = new List<L5DO_GDfToDID_1731>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DOC_DocumentID","DOC_DocumentRevisionID","File_Name","File_SourceLocation","Creation_Timestamp","File_ServerLocation","Username","IsPublicallyVisible","ECM_DOC_GeneralDocumentID" });
				while(reader.Read())
				{
					L5DO_GDfToDID_1731 resultItem = new L5DO_GDfToDID_1731();
					//0:Parameter DOC_DocumentID of type Guid
					resultItem.DOC_DocumentID = reader.GetGuid(0);
					//1:Parameter DOC_DocumentRevisionID of type Guid
					resultItem.DOC_DocumentRevisionID = reader.GetGuid(1);
					//2:Parameter File_Name of type String
					resultItem.File_Name = reader.GetString(2);
					//3:Parameter File_SourceLocation of type String
					resultItem.File_SourceLocation = reader.GetString(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(5);
					//6:Parameter Username of type String
					resultItem.Username = reader.GetString(6);
					//7:Parameter IsPublicallyVisible of type bool
					resultItem.IsPublicallyVisible = reader.GetBoolean(7);
					//8:Parameter ECM_DOC_GeneralDocumentID of type Guid
					resultItem.ECM_DOC_GeneralDocumentID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Documents_For_Tenant_Or_DocumentID",ex);
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
		public static FR_L5DO_GDfToDID_1731_Array Invoke(string ConnectionString,P_L5DO_GDfToDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GDfToDID_1731_Array Invoke(DbConnection Connection,P_L5DO_GDfToDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GDfToDID_1731_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GDfToDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GDfToDID_1731_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GDfToDID_1731 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GDfToDID_1731_Array functionReturn = new FR_L5DO_GDfToDID_1731_Array();
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

				throw new Exception("Exception occured in method cls_Get_Documents_For_Tenant_Or_DocumentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GDfToDID_1731_Array : FR_Base
	{
		public L5DO_GDfToDID_1731[] Result	{ get; set; } 
		public FR_L5DO_GDfToDID_1731_Array() : base() {}

		public FR_L5DO_GDfToDID_1731_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GDfToDID_1731 for attribute P_L5DO_GDfToDID_1731
		[DataContract]
		public class P_L5DO_GDfToDID_1731 
		{
			//Standard type parameters
			[DataMember]
			public Guid? DOC_DocumentID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDfToDID_1731 for attribute L5DO_GDfToDID_1731
		[DataContract]
		public class L5DO_GDfToDID_1731 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 
			[DataMember]
			public Guid DOC_DocumentRevisionID { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_SourceLocation { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public bool IsPublicallyVisible { get; set; } 
			[DataMember]
			public Guid ECM_DOC_GeneralDocumentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GDfToDID_1731_Array cls_Get_Documents_For_Tenant_Or_DocumentID(,P_L5DO_GDfToDID_1731 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GDfToDID_1731_Array invocationResult = cls_Get_Documents_For_Tenant_Or_DocumentID.Invoke(connectionString,P_L5DO_GDfToDID_1731 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Documents.Atomic.Retrieval.P_L5DO_GDfToDID_1731();
parameter.DOC_DocumentID = ...;

*/
