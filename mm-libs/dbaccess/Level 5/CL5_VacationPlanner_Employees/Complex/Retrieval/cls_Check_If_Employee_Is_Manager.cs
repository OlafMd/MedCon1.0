/* 
 * Generated on 8/26/2013 1:22:52 PM
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
using CL1_CMN_STR_PPS;
using CL1_CMN_STR;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_If_Employee_Is_Manager.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_If_Employee_Is_Manager
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_CIEIM_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();


            ORM_CMN_STR_Office_ResponsiblePerson.Query officeQuery = new ORM_CMN_STR_Office_ResponsiblePerson.Query();
            officeQuery.CMN_BPT_EMP_Employee_RefID = Parameter.EmployeeID;
            officeQuery.IsDeleted = false;
            if (ORM_CMN_STR_Office_ResponsiblePerson.Query.Exists(Connection, Transaction, officeQuery))
                returnValue.Result = true;

            ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson.Query workAreaQuery = new ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson.Query();
            workAreaQuery.CMN_BPT_EMP_Employee_RefID = Parameter.EmployeeID;
            workAreaQuery.IsDeleted = false;
            if (ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson.Query.Exists(Connection, Transaction, workAreaQuery))
                returnValue.Result = true;

            ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query workPlaceQuery=new ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query();
            workPlaceQuery.CMN_BPT_EMP_Employee_RefID = Parameter.EmployeeID;
            workPlaceQuery.IsDeleted = false;
            if (ORM_CMN_STR_PPS_Workplace_ResponsiblePerson.Query.Exists(Connection, Transaction, workPlaceQuery))
                returnValue.Result = true;
            //Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5EM_CIEIM_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5EM_CIEIM_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_CIEIM_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_CIEIM_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Check_If_Employee_Is_Manager(P_L5EM_CIEIM_1235 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Bool result = cls_Check_If_Employee_Is_Manager.Invoke(connectionString,P_L5EM_CIEIM_1235 Parameter,securityTicket);
	 return result;
}
*/