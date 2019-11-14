/* 
 * Generated on 10/29/2013 10:25:42 AM
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
using CL5_Plannico_Projects.Atomic.Retrieval;
using CL1_TMS_PRO;
using PlannicoModel.Models;

namespace CL5_Plannico_Projects.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Project_For_ProjectID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Project_For_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPFPID_1204 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GPFPID_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PR_GPFPID_1204();
            returnValue.Result = new L5PR_GPFPID_1204();
			//Put your code here
            L5PR_GPFT_1200 resultProject = new L5PR_GPFT_1200();

            ORM_TMS_PRO_Project.Query projectsQuery = new ORM_TMS_PRO_Project.Query();
            projectsQuery.TMS_PRO_ProjectID = Parameter.TMS_PRO_ProjectID;
            projectsQuery.IsDeleted = false;
            projectsQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_TMS_PRO_Project> projects = ORM_TMS_PRO_Project.Query.Search(Connection, Transaction, projectsQuery);

            if(projects.Count == 0)
                return null;

            ORM_TMS_PRO_Project project = projects.FirstOrDefault();
            
            ORM_TMS_PRO_Project_2_ProjectGroup.Query project2ProjectGroupQuery = new ORM_TMS_PRO_Project_2_ProjectGroup.Query();
            project2ProjectGroupQuery.TMS_PRO_Project_RefID = Parameter.TMS_PRO_ProjectID;
            project2ProjectGroupQuery.IsDeleted = false;
            project2ProjectGroupQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_TMS_PRO_Project_2_ProjectGroup> project2ProjectGroup = ORM_TMS_PRO_Project_2_ProjectGroup.Query.Search(Connection, Transaction, project2ProjectGroupQuery);

            ORM_TMS_PRO_Project_2_ProjectGroup resultProject2ProjectGroup = new ORM_TMS_PRO_Project_2_ProjectGroup();

            if (project2ProjectGroup.Count != 0)
                resultProject2ProjectGroup = project2ProjectGroup.FirstOrDefault();

            resultProject.TMS_PRO_ProjectID = project.TMS_PRO_ProjectID;
            resultProject.Name = project.Name;
            resultProject.Description = project.Description;
            resultProject.IsArchived = project.IsArchived;
            resultProject.Default_CostCenter_RefID = project.Default_CostCenter_RefID;
            resultProject.AssignmentID = resultProject2ProjectGroup.AssignmentID;
            resultProject.TMS_PRO_Project_Group_RefID = resultProject2ProjectGroup.TMS_PRO_Project_Group_RefID;

            returnValue.Result.Project = resultProject;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPFPID_1204 Invoke(string ConnectionString,P_L5PR_GPFPID_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPFPID_1204 Invoke(DbConnection Connection,P_L5PR_GPFPID_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPFPID_1204 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GPFPID_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPFPID_1204 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GPFPID_1204 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPFPID_1204 functionReturn = new FR_L5PR_GPFPID_1204();
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

				throw new Exception("Exception occured in method cls_Get_Project_For_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GPFPID_1204 : FR_Base
	{
		public L5PR_GPFPID_1204 Result	{ get; set; }

		public FR_L5PR_GPFPID_1204() : base() {}

		public FR_L5PR_GPFPID_1204(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPFPID_1204 cls_Get_Project_For_ProjectID(,P_L5PR_GPFPID_1204 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPFPID_1204 invocationResult = cls_Get_Project_For_ProjectID.Invoke(connectionString,P_L5PR_GPFPID_1204 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_Projects.Complex.Retrieval.P_L5PR_GPFPID_1204();
parameter.TMS_PRO_ProjectID = ...;

*/