/* 
 * Generated on 3/3/2015 12:03:35 PM
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

namespace CL3_Doctors.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Document_Owners_by_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Document_Owners_by_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_DOT_1151_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_DOT_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_DOT_1151_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Doctors.Atomic.Retrieval.SQL.cls_Get_Document_Owners_by_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L3_DOT_1151> results = new List<L3_DOT_1151>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","DOC_DocumentTemplate_Instance_RefID","AssignmentID","IsDeleted","Modification_Timestamp","Modification_Timestamp1","Creation_Timestamp1","Creation_Timestamp" });
				while(reader.Read())
				{
					L3_DOT_1151 resultItem = new L3_DOT_1151();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter DOC_DocumentTemplate_Instance_RefID of type Guid
					resultItem.DOC_DocumentTemplate_Instance_RefID = reader.GetGuid(1);
					//2:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(2);
					//3:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(3);
					//4:Parameter Modification_Timestamp of type DateTime
					resultItem.Modification_Timestamp = reader.GetDate(4);
					//5:Parameter Modification_Timestamp1 of type DateTime
					resultItem.Modification_Timestamp1 = reader.GetDate(5);
					//6:Parameter Creation_Timestamp1 of type DateTime
					resultItem.Creation_Timestamp1 = reader.GetDate(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Document_Owners_by_Tenant",ex);
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
		public static FR_L3_DOT_1151_Array Invoke(string ConnectionString,P_L3_DOT_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_DOT_1151_Array Invoke(DbConnection Connection,P_L3_DOT_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_DOT_1151_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_DOT_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_DOT_1151_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_DOT_1151 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_DOT_1151_Array functionReturn = new FR_L3_DOT_1151_Array();
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

				throw new Exception("Exception occured in method cls_Get_Document_Owners_by_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_DOT_1151_Array : FR_Base
	{
		public L3_DOT_1151[] Result	{ get; set; } 
		public FR_L3_DOT_1151_Array() : base() {}

		public FR_L3_DOT_1151_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_DOT_1151 for attribute P_L3_DOT_1151
		[DataContract]
		public class P_L3_DOT_1151 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L3_DOT_1151 for attribute L3_DOT_1151
		[DataContract]
		public class L3_DOT_1151 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public Guid DOC_DocumentTemplate_Instance_RefID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp1 { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp1 { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_DOT_1151_Array cls_Get_Document_Owners_by_Tenant(,P_L3_DOT_1151 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_DOT_1151_Array invocationResult = cls_Get_Document_Owners_by_Tenant.Invoke(connectionString,P_L3_DOT_1151 Parameter,securityTicket);
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
var parameter = new CL3_Doctors.Atomic.Retrieval.P_L3_DOT_1151();
parameter.Tenant = ...;

*/
