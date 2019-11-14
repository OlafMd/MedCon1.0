/* 
 * Generated on 11/19/2014 1:10:19 PM
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

namespace CL3_Notes.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_ProjectNotes_Created_by_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_ProjectNotes_Created_by_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3N_GAPNCbAID_1415_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3N_GAPNCbAID_1415_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Notes.Atomic.Retrieval.SQL.cls_Get_All_ProjectNotes_Created_by_AccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3N_GAPNCbAID_1415> results = new List<L3N_GAPNCbAID_1415>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_Project_NoteID","Current_NoteRevision_RefID","CMN_NoteID","Project_RefID","Creation_Timestamp","Modification_Timestamp","CreatedBy_BusinessParticipant_RefID" });
				while(reader.Read())
				{
					L3N_GAPNCbAID_1415 resultItem = new L3N_GAPNCbAID_1415();
					//0:Parameter TMS_PRO_Project_NoteID of type Guid
					resultItem.TMS_PRO_Project_NoteID = reader.GetGuid(0);
					//1:Parameter Current_NoteRevision_RefID of type Guid
					resultItem.Current_NoteRevision_RefID = reader.GetGuid(1);
					//2:Parameter CMN_NoteID of type Guid
					resultItem.CMN_NoteID = reader.GetGuid(2);
					//3:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(3);
					//4:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(4);
					//5:Parameter Modification_Timestamp of type DateTime
					resultItem.Modification_Timestamp = reader.GetDate(5);
					//6:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_ProjectNotes_Created_by_AccountID",ex);
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
		public static FR_L3N_GAPNCbAID_1415_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3N_GAPNCbAID_1415_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3N_GAPNCbAID_1415_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3N_GAPNCbAID_1415_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3N_GAPNCbAID_1415_Array functionReturn = new FR_L3N_GAPNCbAID_1415_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_All_ProjectNotes_Created_by_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3N_GAPNCbAID_1415_Array : FR_Base
	{
		public L3N_GAPNCbAID_1415[] Result	{ get; set; } 
		public FR_L3N_GAPNCbAID_1415_Array() : base() {}

		public FR_L3N_GAPNCbAID_1415_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3N_GAPNCbAID_1415 for attribute L3N_GAPNCbAID_1415
		[DataContract]
		public class L3N_GAPNCbAID_1415 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_Project_NoteID { get; set; } 
			[DataMember]
			public Guid Current_NoteRevision_RefID { get; set; } 
			[DataMember]
			public Guid CMN_NoteID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3N_GAPNCbAID_1415_Array cls_Get_All_ProjectNotes_Created_by_AccountID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3N_GAPNCbAID_1415_Array invocationResult = cls_Get_All_ProjectNotes_Created_by_AccountID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

