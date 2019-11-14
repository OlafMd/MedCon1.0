/* 
 * Generated on 8/26/2013 2:02:48 PM
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
using CL5_VacationPlanner_Office.Atomic.Retrieval;
using CL5_VacationPlanner_WorkArea.Atomic.Retrieval;
using CL5_VacationPlanner_WorkPlace.Atomic.Retrieval;
using CL5_VacationPlanner_Office.Complex.Retrieval;
using CL5_VacationPlanner_WorkArea.Complex.Retrieval;
using CL5_VacationPlanner_WorkPlace.Complex.Retrieval;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Company.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Company_Structure_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Company_Structure_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CM_GCSFT_1157 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5CM_GCSFT_1157();


            L5OF_GOFT_1157[] ofices = cls_get_Offices_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            L5WA_GWAFT_1201[] workAreas = cls_Get_WorkAreas_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            L5WP_GWFT_1203[] workPlaces = cls_Get_Workplaces_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            L5CM_GCSFT_1157 company = new L5CM_GCSFT_1157();
            company.Offices = ofices;
            company.WorkAreas = workAreas;
            company.WorkPlaces = workPlaces;

            returnValue.Result = company;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CM_GCSFT_1157 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CM_GCSFT_1157 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CM_GCSFT_1157 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CM_GCSFT_1157 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CM_GCSFT_1157 functionReturn = new FR_L5CM_GCSFT_1157();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CM_GCSFT_1157 : FR_Base
	{
		public L5CM_GCSFT_1157 Result	{ get; set; }

		public FR_L5CM_GCSFT_1157() : base() {}

		public FR_L5CM_GCSFT_1157(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CM_GCSFT_1157 cls_Get_Company_Structure_For_Tenant(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5CM_GCSFT_1157 result = cls_Get_Company_Structure_For_Tenant.Invoke(connectionString,securityTicket);
	 return result;
}
*/