/* 
 * Generated on 8/30/2013 10:52:11 AM
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

namespace CL5_OphthalDocuments.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Documents_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Documents_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OD_GDfP_1552_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_GDfP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OD_GDfP_1552_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalDocuments.Atomic.Retrieval.SQL.cls_Get_Documents_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<L5OD_GDfP_1552> results = new List<L5OD_GDfP_1552>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DOC_DocumentID","File_ServerLocation","File_Name","DOC_DocumentRevisionID","File_Size_Bytes","File_MIMEType","File_Extension","HEC_Patient_DocumentID","IsDocument_Standard","IsDocument_PatientConsent","IsDocument_PatientParticipationPolicy" });
				while(reader.Read())
				{
					L5OD_GDfP_1552 resultItem = new L5OD_GDfP_1552();
					//0:Parameter DOC_DocumentID of type Guid
					resultItem.DOC_DocumentID = reader.GetGuid(0);
					//1:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(1);
					//2:Parameter File_Name of type String
					resultItem.File_Name = reader.GetString(2);
					//3:Parameter DOC_DocumentRevisionID of type Guid
					resultItem.DOC_DocumentRevisionID = reader.GetGuid(3);
					//4:Parameter File_Size_Bytes of type String
					resultItem.File_Size_Bytes = reader.GetString(4);
					//5:Parameter File_MIMEType of type String
					resultItem.File_MIMEType = reader.GetString(5);
					//6:Parameter File_Extension of type String
					resultItem.File_Extension = reader.GetString(6);
					//7:Parameter HEC_Patient_DocumentID of type Guid
					resultItem.HEC_Patient_DocumentID = reader.GetGuid(7);
					//8:Parameter IsDocument_Standard of type bool
					resultItem.IsDocument_Standard = reader.GetBoolean(8);
					//9:Parameter IsDocument_PatientConsent of type bool
					resultItem.IsDocument_PatientConsent = reader.GetBoolean(9);
					//10:Parameter IsDocument_PatientParticipationPolicy of type bool
					resultItem.IsDocument_PatientParticipationPolicy = reader.GetBoolean(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Documents_for_PatientID",ex);
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
		public static FR_L5OD_GDfP_1552_Array Invoke(string ConnectionString,P_L5OD_GDfP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OD_GDfP_1552_Array Invoke(DbConnection Connection,P_L5OD_GDfP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OD_GDfP_1552_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_GDfP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OD_GDfP_1552_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_GDfP_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OD_GDfP_1552_Array functionReturn = new FR_L5OD_GDfP_1552_Array();
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

				throw new Exception("Exception occured in method cls_Get_Documents_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OD_GDfP_1552_Array : FR_Base
	{
		public L5OD_GDfP_1552[] Result	{ get; set; } 
		public FR_L5OD_GDfP_1552_Array() : base() {}

		public FR_L5OD_GDfP_1552_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OD_GDfP_1552 for attribute P_L5OD_GDfP_1552
		[DataContract]
		public class P_L5OD_GDfP_1552 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5OD_GDfP_1552 for attribute L5OD_GDfP_1552
		[DataContract]
		public class L5OD_GDfP_1552 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentID { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public Guid DOC_DocumentRevisionID { get; set; } 
			[DataMember]
			public String File_Size_Bytes { get; set; } 
			[DataMember]
			public String File_MIMEType { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public Guid HEC_Patient_DocumentID { get; set; } 
			[DataMember]
			public bool IsDocument_Standard { get; set; } 
			[DataMember]
			public bool IsDocument_PatientConsent { get; set; } 
			[DataMember]
			public bool IsDocument_PatientParticipationPolicy { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OD_GDfP_1552_Array cls_Get_Documents_for_PatientID(,P_L5OD_GDfP_1552 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OD_GDfP_1552_Array invocationResult = cls_Get_Documents_for_PatientID.Invoke(connectionString,P_L5OD_GDfP_1552 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDocuments.Atomic.Retrieval.P_L5OD_GDfP_1552();
parameter.PatientID = ...;

*/
