/* 
 * Generated on 12/8/2014 3:14:46 PM
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

namespace CL6_DanuTask_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Recommend_DeveloperTasks.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Recommend_DeveloperTasks
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_RDT_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            //Put your code here
            #region Get RecommendedBy ProjecMemberID
            ORM_TMS_PRO_ProjectMember RecommendedBy = null;
            if (Parameter.DeveloperTask_List != null && Parameter.DeveloperTask_List.Count() != 0)
            {
                ORM_TMS_PRO_DeveloperTask firstTask = new ORM_TMS_PRO_DeveloperTask();
                firstTask.Load(Connection, Transaction, Parameter.DeveloperTask_List.First());

                ORM_TMS_PRO_ProjectMember.Query mem_query = new ORM_TMS_PRO_ProjectMember.Query();
                mem_query.Project_RefID = firstTask.Project_RefID;
                mem_query.USR_Account_RefID = securityTicket.AccountID;

                RecommendedBy = ORM_TMS_PRO_ProjectMember.Query.Search(Connection, Transaction, mem_query).FirstOrDefault();
            }

            foreach (var currentTask in Parameter.DeveloperTask_List)
            {
                #region Remove Previous Recommendations

                ORM_TMS_PRO_DeveloperTask_Recommendation.Query rec_query = new ORM_TMS_PRO_DeveloperTask_Recommendation.Query();
                rec_query.DeveloperTask_RefID = currentTask;
                ORM_TMS_PRO_DeveloperTask_Recommendation.Query.SoftDelete(Connection, Transaction, rec_query);

                foreach (var currentMember in Parameter.ProjectMember_List)
                {
                    ORM_TMS_PRO_DeveloperTask_Recommendation rec_item = new ORM_TMS_PRO_DeveloperTask_Recommendation();
                    rec_item.DeveloperTask_RefID = currentTask;
                    rec_item.RecommendedBy_ProjectMember_RefID = RecommendedBy.TMS_PRO_ProjectMemberID;
                    rec_item.RecommendedTo_ProjectMember_RefID = currentMember;
                    rec_item.Description = "";
                    rec_item.Tenant_RefID = securityTicket.TenantID;
                    rec_item.Save(Connection, Transaction);
                }
                #endregion
            }
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_RDT_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_RDT_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_RDT_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_RDT_1057 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Recommend_DeveloperTasks",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_RDT_1057 for attribute P_L6DT_RDT_1057
		[DataContract]
		public class P_L6DT_RDT_1057 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] DeveloperTask_List { get; set; } 
			[DataMember]
			public Guid[] ProjectMember_List { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Recommend_DeveloperTasks(,P_L6DT_RDT_1057 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Recommend_DeveloperTasks.Invoke(connectionString,P_L6DT_RDT_1057 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Complex.Manipulation.P_L6DT_RDT_1057();
parameter.DeveloperTask_List = ...;
parameter.ProjectMember_List = ...;

*/
