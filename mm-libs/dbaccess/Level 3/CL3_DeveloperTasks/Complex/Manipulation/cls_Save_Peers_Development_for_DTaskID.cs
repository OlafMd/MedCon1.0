/* 
 * Generated on 12/8/2014 2:36:02 PM
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

namespace CL3_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 

    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Peers_Development_for_DTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Peers_Development_for_DTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_SPDfDTID_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_TMS_PRO_DeveloperTask devTask = ORM_TMS_PRO_DeveloperTask.Query.Search(Connection, Transaction, new ORM_TMS_PRO_DeveloperTask.Query()
            {
                TMS_PRO_DeveloperTaskID = Parameter.DeveloperTaskID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            ORM_TMS_PRO_ProjectMember projMember = ORM_TMS_PRO_ProjectMember.Query.Search(Connection, Transaction, new ORM_TMS_PRO_ProjectMember.Query() {
            
                USR_Account_RefID = securityTicket.AccountID,
                Project_RefID = devTask.Project_RefID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            ORM_TMS_PRO_Project project = ORM_TMS_PRO_Project.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Project.Query() { 
                TMS_PRO_ProjectID = devTask.Project_RefID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            
            }).Single();

            if (Parameter.Delete)
            {
                ORM_TMS_PRO_Peers_Development subscription2Delete = ORM_TMS_PRO_Peers_Development.Query.Search(Connection, Transaction, new ORM_TMS_PRO_Peers_Development.Query() { 
                    DeveloperTask_RefID = Parameter.DeveloperTaskID,
                    ProjectMember_RefID = projMember.TMS_PRO_ProjectMemberID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();
                subscription2Delete.IsDeleted = true;
                subscription2Delete.Save(Connection,Transaction);

            }
            else
            {
                ORM_TMS_PRO_Peers_Development newSubscription = new ORM_TMS_PRO_Peers_Development();
                newSubscription.Tenant_RefID = securityTicket.TenantID;
                newSubscription.ProjectMember_RefID = projMember.TMS_PRO_ProjectMemberID;
                newSubscription.DeveloperTask_RefID = Parameter.DeveloperTaskID;
                newSubscription.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3DT_SPDfDTID_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3DT_SPDfDTID_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_SPDfDTID_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_SPDfDTID_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Peers_Development_for_DTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3DT_SPDfDTID_1425 for attribute P_L3DT_SPDfDTID_1425
		[DataContract]
		public class P_L3DT_SPDfDTID_1425 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTaskID { get; set; } 
			[DataMember]
			public Boolean Delete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Peers_Development_for_DTaskID(,P_L3DT_SPDfDTID_1425 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Peers_Development_for_DTaskID.Invoke(connectionString,P_L3DT_SPDfDTID_1425 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Complex.Manipulation.P_L3DT_SPDfDTID_1425();
parameter.DeveloperTaskID = ...;
parameter.Delete = ...;

*/
