/* 
 * Generated on 28-Oct-13 11:24:38
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
using PlannicoModel.Models;

namespace CL5_Plannico_Projects.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Project.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Project
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PR_SPR_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_TMS_PRO_Project item = new ORM_TMS_PRO_Project();
            if (Parameter.TMS_PRO_ProjectID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.TMS_PRO_ProjectID);
                if (result.Status != FR_Status.Success || item.TMS_PRO_ProjectID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }                
            }

            item.Description = Parameter.Description;
            item.Name = Parameter.Name;
            item.IsArchived = Parameter.IsArchived;
            item.Default_CostCenter_RefID = Parameter.Default_CostCenter_RefID;
            item.Tenant_RefID = securityTicket.TenantID;
            item.Save(Connection, Transaction);

            ORM_TMS_PRO_Project_2_ProjectGroup.Query project2ProjectGroupQuery = new ORM_TMS_PRO_Project_2_ProjectGroup.Query();
            project2ProjectGroupQuery.TMS_PRO_Project_RefID = item.TMS_PRO_ProjectID;
            project2ProjectGroupQuery.Tenant_RefID = securityTicket.TenantID;
            project2ProjectGroupQuery.IsDeleted = false;
            ORM_TMS_PRO_Project_2_ProjectGroup project2ProjectGroup = new ORM_TMS_PRO_Project_2_ProjectGroup();

            var queryRes = ORM_TMS_PRO_Project_2_ProjectGroup.Query.Search(Connection, Transaction, project2ProjectGroupQuery);

            bool doesAssignmentExist = false;

            if (queryRes != null && queryRes.Count != 0)
            {
                project2ProjectGroup = queryRes.FirstOrDefault();
                doesAssignmentExist = true;
            }


            if (Parameter.TMS_PRO_Project_Group_RefID != Guid.Empty)
            {
                project2ProjectGroup.TMS_PRO_Project_Group_RefID = Parameter.TMS_PRO_Project_Group_RefID;
                project2ProjectGroup.TMS_PRO_Project_RefID = item.TMS_PRO_ProjectID;
                project2ProjectGroup.Tenant_RefID = securityTicket.TenantID;
                project2ProjectGroup.Save(Connection, Transaction);
            }
            else if (doesAssignmentExist)
            {
                project2ProjectGroup.IsDeleted = true;
                project2ProjectGroup.Save(Connection, Transaction);
            }

            return new FR_Guid(item.TMS_PRO_ProjectID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PR_SPR_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PR_SPR_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PR_SPR_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PR_SPR_1333 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes


	#endregion
}
