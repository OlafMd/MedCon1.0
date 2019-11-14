/* 
 * Generated on 11/18/2014 10:37:48 AM
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
using CL1_TMS_PRO;

namespace CL2_Project.Complex.Manipulation
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProjectMembers_for_ProjectID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProjectMembers_for_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_SPMfPID_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            foreach (var userID in Parameter.User_IDsToRemoveFromProject)
            {
                //ORM_TMS_PRO_ProjectMember projectMember = new ORM_TMS_PRO_ProjectMember();
                var projectMembers=ORM_TMS_PRO_ProjectMember.Query.Search(Connection, Transaction, new ORM_TMS_PRO_ProjectMember.Query()
                {
                    USR_Account_RefID=userID,
                    Project_RefID = Parameter.ProjectID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
                foreach (var projectMember in projectMembers)
                {
                    projectMember.IsDeleted = true;
                    projectMember.Save(Connection, Transaction);
                }
                
            }

            foreach (var userID in Parameter.User_IDsToAddToProject)
            {
                ORM_TMS_PRO_ProjectMember projectMember = new ORM_TMS_PRO_ProjectMember();
                projectMember = new CL1_TMS_PRO.ORM_TMS_PRO_ProjectMember();
                projectMember.TMS_PRO_ProjectMemberID = Guid.NewGuid();
                projectMember.USR_Account_RefID = userID;
                projectMember.Project_RefID = Parameter.ProjectID;
                projectMember.IsDeleted = false;
                projectMember.Tenant_RefID = securityTicket.TenantID;
                projectMember.Save(Connection, Transaction);
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PR_SPMfPID_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PR_SPMfPID_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_SPMfPID_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_SPMfPID_1341 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_ProjectMembers_for_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PR_SPMfPID_1341 for attribute P_L2PR_SPMfPID_1341
		[DataContract]
		public class P_L2PR_SPMfPID_1341 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] User_IDsToRemoveFromProject { get; set; } 
			[DataMember]
			public Guid[] User_IDsToAddToProject { get; set; } 
			[DataMember]
			public Guid ProjectID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ProjectMembers_for_ProjectID(,P_L2PR_SPMfPID_1341 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ProjectMembers_for_ProjectID.Invoke(connectionString,P_L2PR_SPMfPID_1341 Parameter,securityTicket);
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
var parameter = new CL2_Project.Complex.Manipulation.P_L2PR_SPMfPID_1341();
parameter.User_IDsToRemoveFromProject = ...;
parameter.User_IDsToAddToProject = ...;
parameter.ProjectID = ...;

*/
