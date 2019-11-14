/* 
 * Generated on 03-Dec-14 3:42:07 PM
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
using CL3_User.Atomic.Retrieval;
using CL1_TMS_PRO;
using CL1_USR;
using CL3_DeveloperTask.Atomic.Manipulation;
using CL3_DeveloperTask.Atomic.Retrieval;

namespace CL3_Features.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TMS_PRO_Peers_Feature.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TMS_PRO_Peers_Feature
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3FE_SPF_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            ORM_TMS_PRO_Feature Feature = new ORM_TMS_PRO_Feature();
            ORM_TMS_PRO_Project Project = new ORM_TMS_PRO_Project();
            ORM_TMS_PRO_ProjectMember ProjectMember = new ORM_TMS_PRO_ProjectMember();


            foreach(P_L3FE_SPF_1527a asgn in Parameter.Assignments)
            {
                var item = new ORM_TMS_PRO_Peers_Feature();
                Guid projectMemberID = Guid.Empty;

                if(asgn.AssignmentID != Guid.Empty)
                {
                    var result = item.Load(Connection, Transaction, asgn.AssignmentID);
                    if (result.Status != FR_Status.Success || item.AssignmentID == Guid.Empty)
                    {
                        var error = new FR_Bool(false);
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }

                    projectMemberID = item.ProjectMember_RefID;
                }

                if (asgn.IsDeleted == true)
                {
                    item.IsDeleted = true;
                }

                //Creation specific parameters (Tenant, Account ... )
                if (asgn.AssignmentID == Guid.Empty)
                {
                    item.Tenant_RefID = securityTicket.TenantID;
                    item.ProjectMember_RefID = Parameter.AssignedBy_ProjectMemberID;
                }

                item.Feature_RefID = Parameter.Feature_RefID;

                item.ProjectMember_RefID = asgn.ProjectMember_RefID;

                item.Save(Connection, Transaction);


                #region SubItems

                var task2featureQuery = new ORM_TMS_PRO_Feature_2_DeveloperTask.Query();
                task2featureQuery.Feature_RefID = item.Feature_RefID;

                var task2feature = ORM_TMS_PRO_Feature_2_DeveloperTask.Query.Search(Connection, Transaction, task2featureQuery);
                List<Guid> taskIds = task2feature.Select(t => t.DeveloperTask_RefID).Distinct().ToList();

                foreach (Guid currentTask in taskIds)
                {
                    P_L3DT_SPDT_1644 subscribeParam = new P_L3DT_SPDT_1644();
                    subscribeParam.DeveloperTask_RefID = currentTask;

                    P_L3DT_SPDT_1644a assignment = new P_L3DT_SPDT_1644a();

                    if (asgn.IsDeleted)
                    {
                        P_L3DT_GDTIaSfDT_1654 dtaskParam = new P_L3DT_GDTIaSfDT_1654();
                        dtaskParam.DTaskID = currentTask;
                        dtaskParam.IsBeingPrepared_Only = false;
                        FR_L3DT_GDTIaSfDT_1654 dtasKResult = cls_Get_DeveloperTaskInfo_and_Subscriptions_for_DTaskID.Invoke(Connection, Transaction, dtaskParam, securityTicket);
                        if (dtasKResult != null && dtasKResult.Result != null)
                        {
                            assignment.AssignmentID = dtasKResult.Result.PeersDevelopmentAssignmentID;
                            assignment.IsDeleted = true;
                        }
                    }

                    else
                    {
                        subscribeParam.AssignedBy_ProjectMemberID = Parameter.AssignedBy_ProjectMemberID;
                        assignment.ProjectMember_RefID = asgn.ProjectMember_RefID;
                    }
                    subscribeParam.Assignments = new P_L3DT_SPDT_1644a[] { assignment };
                    cls_Save_TMS_PRO_Peers_Development.Invoke(Connection, Transaction, subscribeParam, securityTicket);

                }



                #endregion

            }









			return returnValue;
			#endregion UserCode
		}


        #region SUPPORT METHODS

        //private static L3US_GUBIfUA_1057 GetUserInfoForProjectMemberID(Guid projectMemberID, DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        //{
        //    ORM_TMS_PRO_ProjectMember projectMember = new ORM_TMS_PRO_ProjectMember();
        //    projectMember.Load(Connection, Transaction, projectMemberID);
          
        //    P_L3US_GUBIfUA_1057 userParam = new P_L3US_GUBIfUA_1057();
        //    userParam.UserAccountID = projectMember.USR_Account_RefID;
        //    L3US_GUBIfUA_1057 userInfo = cls_Get_UserBasicInfo_for_UserAccountID.Invoke(Connection, Transaction, userParam, securityTicket).Result;
        //    return userInfo;
        //}

        #endregion


		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3FE_SPF_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3FE_SPF_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3FE_SPF_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3FE_SPF_1527 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_PRO_Peers_Feature",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3FE_SPF_1527 for attribute P_L3FE_SPF_1527
		[DataContract]
		public class P_L3FE_SPF_1527 
		{
			[DataMember]
			public P_L3FE_SPF_1527a[] Assignments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid Feature_RefID { get; set; } 
			[DataMember]
			public Guid AssignedBy_ProjectMemberID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 

		}
		#endregion
		#region SClass P_L3FE_SPF_1527a for attribute Assignments
		[DataContract]
		public class P_L3FE_SPF_1527a 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid ProjectMember_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_TMS_PRO_Peers_Feature(,P_L3FE_SPF_1527 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_TMS_PRO_Peers_Feature.Invoke(connectionString,P_L3FE_SPF_1527 Parameter,securityTicket);
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
var parameter = new CL3_Features.Atomic.Manipulation.P_L3FE_SPF_1527();
parameter.Assignments = ...;

parameter.Feature_RefID = ...;
parameter.AssignedBy_ProjectMemberID = ...;
parameter.Comment = ...;

*/
