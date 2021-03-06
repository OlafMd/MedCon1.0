/* 
 * Generated on 10/29/2013 10:25:54 AM
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
    /// var result = cls_Get_ProjectGroup_For_ProjectGroupID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectGroup_For_ProjectGroupID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PR_GPGFPGID_1319 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PR_GPGFPGID_1319();
            returnValue.Result = new L5PR_GPGFPGID_1319();
			//Put your code here
            L5PR_GPGFT_1315 resultProjectGroup = new L5PR_GPGFT_1315();

            ORM_TMS_PRO_Project_Group.Query projectGroupQuery = new ORM_TMS_PRO_Project_Group.Query();
            projectGroupQuery.TMS_PRO_Project_GroupID = Parameter.TMS_PRO_Project_GroupID;
            projectGroupQuery.IsDeleted = false;
            projectGroupQuery.Tenant_RefID = securityTicket.TenantID;

            List<ORM_TMS_PRO_Project_Group> projectGroups = ORM_TMS_PRO_Project_Group.Query.Search(Connection, Transaction, projectGroupQuery);

            if (projectGroups.Count == 0)
                return null;
            ORM_TMS_PRO_Project_Group projectGroup = projectGroups.FirstOrDefault();
            resultProjectGroup.TMS_PRO_Project_GroupID = projectGroup.TMS_PRO_Project_GroupID;
            resultProjectGroup.ProjectGroup_Name = projectGroup.ProjectGroup_Name;
            resultProjectGroup.ProjectGroup_Description = projectGroup.ProjectGroup_Description;
            returnValue.Result.ProjectGroup = resultProjectGroup;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PR_GPGFPGID_1319 Invoke(string ConnectionString,P_L5PR_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PR_GPGFPGID_1319 Invoke(DbConnection Connection,P_L5PR_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PR_GPGFPGID_1319 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PR_GPGFPGID_1319 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_GPGFPGID_1319 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PR_GPGFPGID_1319 functionReturn = new FR_L5PR_GPGFPGID_1319();
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

				throw new Exception("Exception occured in method cls_Get_ProjectGroup_For_ProjectGroupID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PR_GPGFPGID_1319 : FR_Base
	{
		public L5PR_GPGFPGID_1319 Result	{ get; set; }

		public FR_L5PR_GPGFPGID_1319() : base() {}

		public FR_L5PR_GPGFPGID_1319(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PR_GPGFPGID_1319 cls_Get_ProjectGroup_For_ProjectGroupID(,P_L5PR_GPGFPGID_1319 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PR_GPGFPGID_1319 invocationResult = cls_Get_ProjectGroup_For_ProjectGroupID.Invoke(connectionString,P_L5PR_GPGFPGID_1319 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_Projects.Complex.Retrieval.P_L5PR_GPGFPGID_1319();
parameter.TMS_PRO_Project_GroupID = ...;

*/