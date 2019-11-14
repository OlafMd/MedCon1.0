/* 
 * Generated on 2/25/2015 1:15:33 AM
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

namespace CL6_MRMS_MeasuringPoints.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_NotesWithEmployeeNames_by_AccountCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_NotesWithEmployeeNames_by_AccountCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6_NWEN_b_AC_1229_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6_NWEN_b_AC_1229 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6_NWEN_b_AC_1229_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MRMS_MeasuringPoints.Atomic.Retrieval.SQL.cls_NotesWithEmployeeNames_by_AccountCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L6_NWEN_b_AC_1229> results = new List<L6_NWEN_b_AC_1229>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MRS_MPT_NoteID","MeasuringPoint_RefID","IsDeleted","Tenant_RefID","Creation_Timestamp","SequenceNumber","CreatedBy_BusinessParticipant_RefID","Text","FirstName","LastName" });
				while(reader.Read())
				{
					L6_NWEN_b_AC_1229 resultItem = new L6_NWEN_b_AC_1229();
					//0:Parameter MRS_MPT_NoteID of type Guid
					resultItem.MRS_MPT_NoteID = reader.GetGuid(0);
					//1:Parameter MeasuringPoint_RefID of type Guid
					resultItem.MeasuringPoint_RefID = reader.GetGuid(1);
					//2:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(2);
					//3:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter SequenceNumber of type String
					resultItem.SequenceNumber = reader.GetString(5);
					//6:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(6);
					//7:Parameter Text of type String
					resultItem.Text = reader.GetString(7);
					//8:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(8);
					//9:Parameter LastName of type String
					resultItem.LastName = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_NotesWithEmployeeNames_by_AccountCode",ex);
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
		public static FR_L6_NWEN_b_AC_1229_Array Invoke(string ConnectionString,P_L6_NWEN_b_AC_1229 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6_NWEN_b_AC_1229_Array Invoke(DbConnection Connection,P_L6_NWEN_b_AC_1229 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6_NWEN_b_AC_1229_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6_NWEN_b_AC_1229 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6_NWEN_b_AC_1229_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6_NWEN_b_AC_1229 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6_NWEN_b_AC_1229_Array functionReturn = new FR_L6_NWEN_b_AC_1229_Array();
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

				throw new Exception("Exception occured in method cls_NotesWithEmployeeNames_by_AccountCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6_NWEN_b_AC_1229_Array : FR_Base
	{
		public L6_NWEN_b_AC_1229[] Result	{ get; set; } 
		public FR_L6_NWEN_b_AC_1229_Array() : base() {}

		public FR_L6_NWEN_b_AC_1229_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6_NWEN_b_AC_1229 for attribute P_L6_NWEN_b_AC_1229
		[DataContract]
		public class P_L6_NWEN_b_AC_1229 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L6_NWEN_b_AC_1229 for attribute L6_NWEN_b_AC_1229
		[DataContract]
		public class L6_NWEN_b_AC_1229 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_MPT_NoteID { get; set; } 
			[DataMember]
			public Guid MeasuringPoint_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String SequenceNumber { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String Text { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6_NWEN_b_AC_1229_Array cls_NotesWithEmployeeNames_by_AccountCode(,P_L6_NWEN_b_AC_1229 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6_NWEN_b_AC_1229_Array invocationResult = cls_NotesWithEmployeeNames_by_AccountCode.Invoke(connectionString,P_L6_NWEN_b_AC_1229 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_MeasuringPoints.Atomic.Retrieval.P_L6_NWEN_b_AC_1229();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
