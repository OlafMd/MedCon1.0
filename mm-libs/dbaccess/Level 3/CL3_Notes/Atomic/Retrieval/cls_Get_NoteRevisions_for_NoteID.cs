/* 
 * Generated on 11/19/2014 9:48:33 AM
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
    /// var result = cls_Get_NoteRevisions_for_NoteID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_NoteRevisions_for_NoteID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3N_GNRfNID_1559_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3N_GNRfNID_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3N_GNRfNID_1559_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Notes.Atomic.Retrieval.SQL.cls_Get_NoteRevisions_for_NoteID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"@NoteID", Parameter.@NoteID);



			List<L3N_GNRfNID_1559> results = new List<L3N_GNRfNID_1559>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_NoteRevisionID","Title","Content","CreatedBy_BusinessParticipant_RefID","Version","Creation_Timestamp","Modification_Timestamp" });
				while(reader.Read())
				{
					L3N_GNRfNID_1559 resultItem = new L3N_GNRfNID_1559();
					//0:Parameter CMN_NoteRevisionID of type Guid
					resultItem.CMN_NoteRevisionID = reader.GetGuid(0);
					//1:Parameter Title of type String
					resultItem.Title = reader.GetString(1);
					//2:Parameter Content of type String
					resultItem.Content = reader.GetString(2);
					//3:Parameter CreatedBy_BusinessParticipant_RefID of type Guid
					resultItem.CreatedBy_BusinessParticipant_RefID = reader.GetGuid(3);
					//4:Parameter Version of type int
					resultItem.Version = reader.GetInteger(4);
					//5:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(5);
					//6:Parameter Modification_Timestamp of type DateTime
					resultItem.Modification_Timestamp = reader.GetDate(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_NoteRevisions_for_NoteID",ex);
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
		public static FR_L3N_GNRfNID_1559_Array Invoke(string ConnectionString,P_L3N_GNRfNID_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3N_GNRfNID_1559_Array Invoke(DbConnection Connection,P_L3N_GNRfNID_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3N_GNRfNID_1559_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3N_GNRfNID_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3N_GNRfNID_1559_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3N_GNRfNID_1559 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3N_GNRfNID_1559_Array functionReturn = new FR_L3N_GNRfNID_1559_Array();
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

				throw new Exception("Exception occured in method cls_Get_NoteRevisions_for_NoteID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3N_GNRfNID_1559_Array : FR_Base
	{
		public L3N_GNRfNID_1559[] Result	{ get; set; } 
		public FR_L3N_GNRfNID_1559_Array() : base() {}

		public FR_L3N_GNRfNID_1559_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3N_GNRfNID_1559 for attribute P_L3N_GNRfNID_1559
		[DataContract]
		public class P_L3N_GNRfNID_1559 
		{
			//Standard type parameters
			[DataMember]
			public Guid @NoteID { get; set; } 

		}
		#endregion
		#region SClass L3N_GNRfNID_1559 for attribute L3N_GNRfNID_1559
		[DataContract]
		public class L3N_GNRfNID_1559 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_NoteRevisionID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public int Version { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3N_GNRfNID_1559_Array cls_Get_NoteRevisions_for_NoteID(,P_L3N_GNRfNID_1559 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3N_GNRfNID_1559_Array invocationResult = cls_Get_NoteRevisions_for_NoteID.Invoke(connectionString,P_L3N_GNRfNID_1559 Parameter,securityTicket);
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
var parameter = new CL3_Notes.Atomic.Retrieval.P_L3N_GNRfNID_1559();
parameter.@NoteID = ...;

*/
