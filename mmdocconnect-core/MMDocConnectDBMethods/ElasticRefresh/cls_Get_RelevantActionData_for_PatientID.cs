/* 
 * Generated on 4/22/2017 9:37:40 PM
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RelevantActionData_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RelevantActionData_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GRADfPID_1734_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GRADfPID_1734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GRADfPID_1734_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_RelevantActionData_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<ER_GRADfPID_1734> results = new List<ER_GRADfPID_1734>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IsDeleted","IsPerformed","IsCancelled","CaseID","PlannedAction_RefID","ActionTypeGpmID","ToBePerformedBy_BusinessParticipant_RefID","IsOpPerformed","IsOpCancelled","PatientID","Localization" });
				while(reader.Read())
				{
					ER_GRADfPID_1734 resultItem = new ER_GRADfPID_1734();
					//0:Parameter IsDeleted of type Boolean
					resultItem.IsDeleted = reader.GetBoolean(0);
					//1:Parameter IsPerformed of type Boolean
					resultItem.IsPerformed = reader.GetBoolean(1);
					//2:Parameter IsCancelled of type Boolean
					resultItem.IsCancelled = reader.GetBoolean(2);
					//3:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(3);
					//4:Parameter PlannedAction_RefID of type Guid
					resultItem.PlannedAction_RefID = reader.GetGuid(4);
					//5:Parameter ActionTypeGpmID of type String
					resultItem.ActionTypeGpmID = reader.GetString(5);
					//6:Parameter ToBePerformedBy_BusinessParticipant_RefID of type Guid
					resultItem.ToBePerformedBy_BusinessParticipant_RefID = reader.GetGuid(6);
					//7:Parameter IsOpPerformed of type Boolean
					resultItem.IsOpPerformed = reader.GetBoolean(7);
					//8:Parameter IsOpCancelled of type Boolean
					resultItem.IsOpCancelled = reader.GetBoolean(8);
					//9:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(9);
					//10:Parameter Localization of type String
					resultItem.Localization = reader.GetString(10);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RelevantActionData_for_PatientID",ex);
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
		public static FR_ER_GRADfPID_1734_Array Invoke(string ConnectionString,P_ER_GRADfPID_1734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GRADfPID_1734_Array Invoke(DbConnection Connection,P_ER_GRADfPID_1734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GRADfPID_1734_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GRADfPID_1734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GRADfPID_1734_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GRADfPID_1734 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GRADfPID_1734_Array functionReturn = new FR_ER_GRADfPID_1734_Array();
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

				throw new Exception("Exception occured in method cls_Get_RelevantActionData_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GRADfPID_1734_Array : FR_Base
	{
		public ER_GRADfPID_1734[] Result	{ get; set; } 
		public FR_ER_GRADfPID_1734_Array() : base() {}

		public FR_ER_GRADfPID_1734_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GRADfPID_1734 for attribute P_ER_GRADfPID_1734
		[DataContract]
		public class P_ER_GRADfPID_1734 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass ER_GRADfPID_1734 for attribute ER_GRADfPID_1734
		[DataContract]
		public class ER_GRADfPID_1734 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsPerformed { get; set; } 
			[DataMember]
			public Boolean IsCancelled { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid PlannedAction_RefID { get; set; } 
			[DataMember]
			public String ActionTypeGpmID { get; set; } 
			[DataMember]
			public Guid ToBePerformedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public Boolean IsOpPerformed { get; set; } 
			[DataMember]
			public Boolean IsOpCancelled { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public String Localization { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GRADfPID_1734_Array cls_Get_RelevantActionData_for_PatientID(,P_ER_GRADfPID_1734 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GRADfPID_1734_Array invocationResult = cls_Get_RelevantActionData_for_PatientID.Invoke(connectionString,P_ER_GRADfPID_1734 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GRADfPID_1734();
parameter.PatientIDs = ...;

*/
