/* 
 * Generated on 23-Oct-13 13:04:22
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
    /// var result = cls_Get_EmploymentRelationships_For_Employee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EmploymentRelationships_For_Employee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CT_GERFE_1239_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5CT_GERFE_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5CT_GERFE_1239_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Contract.Atomic.Retrieval.SQL.cls_Get_EmploymentRelationships_For_Employee.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"EmployeeID", Parameter.EmployeeID);


			List<L5CT_GERFE_1239> results = new List<L5CT_GERFE_1239>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmploymentRelationshipID","HasWorkRelationEnded","Work_StartDate","Work_EndDate" });
				while(reader.Read())
				{
					L5CT_GERFE_1239 resultItem = new L5CT_GERFE_1239();
					//0:Parameter CMN_BPT_EMP_EmploymentRelationshipID of type Guid
					resultItem.CMN_BPT_EMP_EmploymentRelationshipID = reader.GetGuid(0);
					//1:Parameter HasWorkRelationEnded of type bool
					resultItem.HasWorkRelationEnded = reader.GetBoolean(1);
					//2:Parameter Work_StartDate of type DateTime
					resultItem.Work_StartDate = reader.GetDate(2);
					//3:Parameter Work_EndDate of type DateTime
					resultItem.Work_EndDate = reader.GetDate(3);

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
		public static FR_L5CT_GERFE_1239_Array Invoke(string ConnectionString,P_L5CT_GERFE_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CT_GERFE_1239_Array Invoke(DbConnection Connection,P_L5CT_GERFE_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CT_GERFE_1239_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CT_GERFE_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CT_GERFE_1239_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CT_GERFE_1239 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CT_GERFE_1239_Array functionReturn = new FR_L5CT_GERFE_1239_Array();
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
	public class FR_L5CT_GERFE_1239_Array : FR_Base
	{
		public L5CT_GERFE_1239[] Result	{ get; set; } 
		public FR_L5CT_GERFE_1239_Array() : base() {}

		public FR_L5CT_GERFE_1239_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}
