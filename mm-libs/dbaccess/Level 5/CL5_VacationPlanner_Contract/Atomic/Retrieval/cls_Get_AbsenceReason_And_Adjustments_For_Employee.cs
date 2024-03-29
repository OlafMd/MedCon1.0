/* 
 * Generated on 5/13/2014 5:20:32 PM
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

namespace CL5_VacationPlanner_Contract.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AbsenceReason_And_Adjustments_For_Employee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AbsenceReason_And_Adjustments_For_Employee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GARaAFE_1612_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GARaAFE_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EM_GARaAFE_1612_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Contract.Atomic.Retrieval.SQL.cls_Get_AbsenceReason_And_Adjustments_For_Employee.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AbsenceReason_ID", Parameter.AbsenceReason_ID);



			List<L5EM_GARaAFE_1612> results = new List<L5EM_GARaAFE_1612>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ContractAllowedAbsence_per_Month","IsAllowedAbsence","AbsenceTime_InMinutes","CMN_BPT_STA_AbsenceReasonID","IsWorkTimeCalculated_InHours","IsWorkTimeCalculated_InDays" });
				while(reader.Read())
				{
					L5EM_GARaAFE_1612 resultItem = new L5EM_GARaAFE_1612();
					//0:Parameter ContractAllowedAbsence_per_Month of type String
					resultItem.ContractAllowedAbsence_per_Month = reader.GetString(0);
					//1:Parameter IsAllowedAbsence of type bool
					resultItem.IsAllowedAbsence = reader.GetBoolean(1);
					//2:Parameter AbsenceTime_InMinutes of type double
					resultItem.AbsenceTime_InMinutes = reader.GetDouble(2);
					//3:Parameter CMN_BPT_STA_AbsenceReasonID of type Guid
					resultItem.CMN_BPT_STA_AbsenceReasonID = reader.GetGuid(3);
					//4:Parameter IsWorkTimeCalculated_InHours of type bool
					resultItem.IsWorkTimeCalculated_InHours = reader.GetBoolean(4);
					//5:Parameter IsWorkTimeCalculated_InDays of type bool
					resultItem.IsWorkTimeCalculated_InDays = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AbsenceReason_And_Adjustments_For_Employee",ex);
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
		public static FR_L5EM_GARaAFE_1612_Array Invoke(string ConnectionString,P_L5EM_GARaAFE_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GARaAFE_1612_Array Invoke(DbConnection Connection,P_L5EM_GARaAFE_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GARaAFE_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GARaAFE_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GARaAFE_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GARaAFE_1612 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GARaAFE_1612_Array functionReturn = new FR_L5EM_GARaAFE_1612_Array();
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

				throw new Exception("Exception occured in method cls_Get_AbsenceReason_And_Adjustments_For_Employee",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GARaAFE_1612_Array : FR_Base
	{
		public L5EM_GARaAFE_1612[] Result	{ get; set; } 
		public FR_L5EM_GARaAFE_1612_Array() : base() {}

		public FR_L5EM_GARaAFE_1612_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EM_GARaAFE_1612 for attribute P_L5EM_GARaAFE_1612
		[DataContract]
		public class P_L5EM_GARaAFE_1612 
		{
			//Standard type parameters
			[DataMember]
			public Guid AbsenceReason_ID { get; set; } 

		}
		#endregion
		#region SClass L5EM_GARaAFE_1612 for attribute L5EM_GARaAFE_1612
		[DataContract]
		public class L5EM_GARaAFE_1612 
		{
			//Standard type parameters
			[DataMember]
			public String ContractAllowedAbsence_per_Month { get; set; } 
			[DataMember]
			public bool IsAllowedAbsence { get; set; } 
			[DataMember]
			public double AbsenceTime_InMinutes { get; set; } 
			[DataMember]
			public Guid CMN_BPT_STA_AbsenceReasonID { get; set; } 
			[DataMember]
			public bool IsWorkTimeCalculated_InHours { get; set; } 
			[DataMember]
			public bool IsWorkTimeCalculated_InDays { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GARaAFE_1612_Array cls_Get_AbsenceReason_And_Adjustments_For_Employee(,P_L5EM_GARaAFE_1612 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GARaAFE_1612_Array invocationResult = cls_Get_AbsenceReason_And_Adjustments_For_Employee.Invoke(connectionString,P_L5EM_GARaAFE_1612 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Contract.Atomic.Retrieval.P_L5EM_GARaAFE_1612();
parameter.AbsenceReason_ID = ...;

*/
