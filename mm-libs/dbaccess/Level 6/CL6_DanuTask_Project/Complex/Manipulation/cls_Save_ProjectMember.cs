/* 
 * Generated on 10/28/2014 1:11:25 PM
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

namespace CL6_DanuTask_Project.Complex.Manipulation
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProjectMember.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProjectMember
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_SPM_1040 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_SPM_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PR_SPM_1040();
			//Put your code here
            var item = new CL1_TMS_PRO.ORM_TMS_PRO_ProjectMember();
            L6PR_SPM_1040 addedRemovedProjectMemberInfo = new L6PR_SPM_1040();
            List<ORM_TMS_PRO_ProjectMember> removedProjectMembers= new List<ORM_TMS_PRO_ProjectMember>();
            List<ORM_TMS_PRO_ProjectMember> newProjectMembers = new List<ORM_TMS_PRO_ProjectMember>();
            if (Parameter.Project_IDs_to_Remove_Project_Members.ToList().Count()!=0)
            {
                foreach (var project in Parameter.Project_IDs_to_Remove_Project_Members.ToList())
                {
                    if (project != Guid.Empty)
                    {
                        item = ORM_TMS_PRO_ProjectMember.Query.Search(Connection, Transaction, new ORM_TMS_PRO_ProjectMember.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Project_RefID = project,
                            USR_Account_RefID = Parameter.User_ID
                        }).Single();
                        item.IsDeleted = true;
                        item.Save(Connection, Transaction);
                        removedProjectMembers.Add(item);
                    }
                }
            }
            if (Parameter.Project_IDs_to_Add_Project_Members.ToList().Count() != 0)
            {
                foreach (var project in Parameter.Project_IDs_to_Add_Project_Members.ToList())
                {
                    if (project != Guid.Empty)
                    {
                        item = new CL1_TMS_PRO.ORM_TMS_PRO_ProjectMember();
                        item = ORM_TMS_PRO_ProjectMember.Query.Search(Connection, Transaction, new ORM_TMS_PRO_ProjectMember.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Project_RefID = project,
                            USR_Account_RefID = Parameter.User_ID
                        }).SingleOrDefault();
                        if (item == null) 
                        {
                            item = new CL1_TMS_PRO.ORM_TMS_PRO_ProjectMember();
                            item.TMS_PRO_ProjectMemberID = Guid.NewGuid();
                            item.USR_Account_RefID = Parameter.User_ID;
                            item.Project_RefID = project;
                            item.IsDeleted = false;
                            item.Tenant_RefID = securityTicket.TenantID;
                            item.Save(Connection, Transaction);
                            newProjectMembers.Add(item);
                        }
                    }
                }
            }
            addedRemovedProjectMemberInfo.RemovedProjectMembers = removedProjectMembers.ToArray();
            addedRemovedProjectMemberInfo.AddedProjectMembers = newProjectMembers.ToArray();
            returnValue.Result = addedRemovedProjectMemberInfo;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///</summary>
		public static FR_L6PR_SPM_1040 Invoke(string ConnectionString,P_L6PR_SPM_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///</summary>
		public static FR_L6PR_SPM_1040 Invoke(DbConnection Connection,P_L6PR_SPM_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///</summary>
		public static FR_L6PR_SPM_1040 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_SPM_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
        ///</summary>
		protected static FR_L6PR_SPM_1040 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_SPM_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_SPM_1040 functionReturn = new FR_L6PR_SPM_1040();
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

				throw new Exception("Exception occured in method cls_Save_ProjectMember",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_SPM_1040 : FR_Base
	{
		public L6PR_SPM_1040 Result	{ get; set; }

		public FR_L6PR_SPM_1040() : base() {}

		public FR_L6PR_SPM_1040(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_SPM_1040 for attribute P_L6PR_SPM_1040
		[DataContract]
		public class P_L6PR_SPM_1040 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] Project_IDs_to_Add_Project_Members { get; set; } 
			[DataMember]
			public Guid[] Project_IDs_to_Remove_Project_Members { get; set; } 
			[DataMember]
			public Guid User_ID { get; set; } 

		}
		#endregion
		#region SClass L6PR_SPM_1040 for attribute L6PR_SPM_1040
		[DataContract]
		public class L6PR_SPM_1040 
		{
			[DataMember]
			public ORM_TMS_PRO_ProjectMember[] RemovedProjectMembers { get; set; }
			[DataMember]
			public ORM_TMS_PRO_ProjectMember[] AddedProjectMembers { get; set; }

			//Standard type parameters
		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_SPM_1040 cls_Save_ProjectMember(,P_L6PR_SPM_1040 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_SPM_1040 invocationResult = cls_Save_ProjectMember.Invoke(connectionString,P_L6PR_SPM_1040 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Complex.Manipulation.P_L6PR_SPM_1040();
parameter.Project_IDs_to_Add_Project_Members = ...;
parameter.Project_IDs_to_Remove_Project_Members = ...;
parameter.User_ID = ...;

*/
