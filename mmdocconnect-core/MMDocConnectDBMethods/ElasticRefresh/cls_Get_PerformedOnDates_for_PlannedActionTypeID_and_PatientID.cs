/* 
 * Generated on 3/20/2017 4:45:31 PM
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
    /// var result = cls_Get_PerformedOnDates_for_PlannedActionTypeID_and_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PerformedOnDates_for_PlannedActionTypeID_and_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GPoDfPATIDaPID_1642_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GPoDfPATIDaPID_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GPoDfPATIDaPID_1642_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_PerformedOnDates_for_PlannedActionTypeID_and_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PlannedActionTypeID", Parameter.PlannedActionTypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<CAS_GPoDfPATIDaPID_1642> results = new List<CAS_GPoDfPATIDaPID_1642>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "localization","date","patient_id","id" });
				while(reader.Read())
				{
					CAS_GPoDfPATIDaPID_1642 resultItem = new CAS_GPoDfPATIDaPID_1642();
					//0:Parameter localization of type String
					resultItem.localization = reader.GetString(0);
					//1:Parameter date of type DateTime
					resultItem.date = reader.GetDate(1);
					//2:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(2);
					//3:Parameter id of type Guid
					resultItem.id = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PerformedOnDates_for_PlannedActionTypeID_and_PatientID",ex);
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
		public static FR_CAS_GPoDfPATIDaPID_1642_Array Invoke(string ConnectionString,P_CAS_GPoDfPATIDaPID_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GPoDfPATIDaPID_1642_Array Invoke(DbConnection Connection,P_CAS_GPoDfPATIDaPID_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GPoDfPATIDaPID_1642_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GPoDfPATIDaPID_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GPoDfPATIDaPID_1642_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GPoDfPATIDaPID_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GPoDfPATIDaPID_1642_Array functionReturn = new FR_CAS_GPoDfPATIDaPID_1642_Array();
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

				throw new Exception("Exception occured in method cls_Get_PerformedOnDates_for_PlannedActionTypeID_and_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GPoDfPATIDaPID_1642_Array : FR_Base
	{
		public CAS_GPoDfPATIDaPID_1642[] Result	{ get; set; } 
		public FR_CAS_GPoDfPATIDaPID_1642_Array() : base() {}

		public FR_CAS_GPoDfPATIDaPID_1642_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GPoDfPATIDaPID_1642 for attribute P_CAS_GPoDfPATIDaPID_1642
		[DataContract]
		public class P_CAS_GPoDfPATIDaPID_1642 
		{
			//Standard type parameters
			[DataMember]
			public Guid PlannedActionTypeID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass CAS_GPoDfPATIDaPID_1642 for attribute CAS_GPoDfPATIDaPID_1642
		[DataContract]
		public class CAS_GPoDfPATIDaPID_1642 
		{
			//Standard type parameters
			[DataMember]
			public String localization { get; set; } 
			[DataMember]
			public DateTime date { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public Guid id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GPoDfPATIDaPID_1642_Array cls_Get_PerformedOnDates_for_PlannedActionTypeID_and_PatientID(,P_CAS_GPoDfPATIDaPID_1642 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GPoDfPATIDaPID_1642_Array invocationResult = cls_Get_PerformedOnDates_for_PlannedActionTypeID_and_PatientID.Invoke(connectionString,P_CAS_GPoDfPATIDaPID_1642 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_CAS_GPoDfPATIDaPID_1642();
parameter.PlannedActionTypeID = ...;
parameter.PatientID = ...;

*/
