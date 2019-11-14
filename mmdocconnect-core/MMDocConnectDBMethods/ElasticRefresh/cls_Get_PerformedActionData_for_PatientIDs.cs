/* 
 * Generated on 3/20/2017 5:56:13 PM
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
    /// var result = cls_Get_PerformedActionData_for_PatientIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PerformedActionData_for_PatientIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GPADfPIDs_1754_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GPADfPIDs_1754 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GPADfPIDs_1754_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_PerformedActionData_for_PatientIDs.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientIDs"," IN $$PatientIDs$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientIDs$",Parameter.PatientIDs);


			List<ER_GPADfPIDs_1754> results = new List<ER_GPADfPIDs_1754>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PerformedOnDate","DiagnoseID","LocalizationCode","ActionID","PracticeID","PatientID" });
				while(reader.Read())
				{
					ER_GPADfPIDs_1754 resultItem = new ER_GPADfPIDs_1754();
					//0:Parameter PerformedOnDate of type DateTime
					resultItem.PerformedOnDate = reader.GetDate(0);
					//1:Parameter DiagnoseID of type Guid
					resultItem.DiagnoseID = reader.GetGuid(1);
					//2:Parameter LocalizationCode of type String
					resultItem.LocalizationCode = reader.GetString(2);
					//3:Parameter ActionID of type Guid
					resultItem.ActionID = reader.GetGuid(3);
					//4:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(4);
					//5:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PerformedActionData_for_PatientIDs",ex);
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
		public static FR_ER_GPADfPIDs_1754_Array Invoke(string ConnectionString,P_ER_GPADfPIDs_1754 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GPADfPIDs_1754_Array Invoke(DbConnection Connection,P_ER_GPADfPIDs_1754 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GPADfPIDs_1754_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GPADfPIDs_1754 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GPADfPIDs_1754_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GPADfPIDs_1754 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GPADfPIDs_1754_Array functionReturn = new FR_ER_GPADfPIDs_1754_Array();
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

				throw new Exception("Exception occured in method cls_Get_PerformedActionData_for_PatientIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GPADfPIDs_1754_Array : FR_Base
	{
		public ER_GPADfPIDs_1754[] Result	{ get; set; } 
		public FR_ER_GPADfPIDs_1754_Array() : base() {}

		public FR_ER_GPADfPIDs_1754_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GPADfPIDs_1754 for attribute P_ER_GPADfPIDs_1754
		[DataContract]
		public class P_ER_GPADfPIDs_1754 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientIDs { get; set; } 

		}
		#endregion
		#region SClass ER_GPADfPIDs_1754 for attribute ER_GPADfPIDs_1754
		[DataContract]
		public class ER_GPADfPIDs_1754 
		{
			//Standard type parameters
			[DataMember]
			public DateTime PerformedOnDate { get; set; } 
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public String LocalizationCode { get; set; } 
			[DataMember]
			public Guid ActionID { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GPADfPIDs_1754_Array cls_Get_PerformedActionData_for_PatientIDs(,P_ER_GPADfPIDs_1754 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GPADfPIDs_1754_Array invocationResult = cls_Get_PerformedActionData_for_PatientIDs.Invoke(connectionString,P_ER_GPADfPIDs_1754 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GPADfPIDs_1754();
parameter.PatientIDs = ...;

*/
