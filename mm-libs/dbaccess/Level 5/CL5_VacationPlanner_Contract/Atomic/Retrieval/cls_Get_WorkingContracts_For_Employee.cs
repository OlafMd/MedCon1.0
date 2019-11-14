/* 
 * Generated on 12-Nov-13 11:26:34
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Contract.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WorkingContracts_For_Employee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WorkingContracts_For_Employee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CT_GWCFE_1701_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CT_GWCFE_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CT_GWCFE_1701_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Contract.Atomic.Retrieval.SQL.cls_Get_WorkingContracts_For_Employee.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ForEmployeeID", Parameter.ForEmployeeID);


			List<L5CT_GWCFE_1701> results = new List<L5CT_GWCFE_1701>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "STA_AbsenceReason_RefID","IsAbsenceCalculated_InHours","IsAbsenceCalculated_InDays","ContractAllowedAbsence_per_Month","CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID" });
				while(reader.Read())
				{
					L5CT_GWCFE_1701 resultItem = new L5CT_GWCFE_1701();
					//0:Parameter STA_AbsenceReason_RefID of type Guid
					resultItem.STA_AbsenceReason_RefID = reader.GetGuid(0);
					//1:Parameter IsAbsenceCalculated_InHours of type bool
					resultItem.IsAbsenceCalculated_InHours = reader.GetBoolean(1);
					//2:Parameter IsAbsenceCalculated_InDays of type bool
					resultItem.IsAbsenceCalculated_InDays = reader.GetBoolean(2);
					//3:Parameter ContractAllowedAbsence_per_Month of type Double
					resultItem.ContractAllowedAbsence_per_Month = reader.GetDouble(3);
					//4:Parameter CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID of type Guid
					resultItem.CMN_BPT_EMP_WorkingContract_AllowedAbsenceReasonID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L5CT_GWCFE_1701_Array Invoke(string ConnectionString,P_L5CT_GWCFE_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CT_GWCFE_1701_Array Invoke(DbConnection Connection,P_L5CT_GWCFE_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CT_GWCFE_1701_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CT_GWCFE_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CT_GWCFE_1701_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CT_GWCFE_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CT_GWCFE_1701_Array functionReturn = new FR_L5CT_GWCFE_1701_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CT_GWCFE_1701_Array : FR_Base
	{
		public L5CT_GWCFE_1701[] Result	{ get; set; } 
		public FR_L5CT_GWCFE_1701_Array() : base() {}

		public FR_L5CT_GWCFE_1701_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}
