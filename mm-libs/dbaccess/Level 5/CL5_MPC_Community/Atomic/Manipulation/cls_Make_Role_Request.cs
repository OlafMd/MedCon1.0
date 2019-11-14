/* 
 * Generated on 24.03.2015 15:58:21
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
using CL1_HEC_CMT;
using CL5_MPC_Community.Atomic.Retrieval;

namespace CL5_MPC_Community.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Make_Role_Request.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Make_Role_Request
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MC_MRR_1440 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_MRR_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5MC_MRR_1440();
            returnValue.Result = new L5MC_MRR_1440();

            var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCommunityOperatedByThisTenant = true
            }).Single();

            var role = ORM_HEC_CMT_OfferedRole.Query.Search(Connection, Transaction, new ORM_HEC_CMT_OfferedRole.Query()
            {
                GlobalPropertyMatchingID = Parameter.Role_GlobalPropertyMatchingID,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Single();


            var memberRequests = cls_Get_Requests_for_GroupID_and_MemberID.Invoke(Connection, Transaction, new P_L5AC_GRfGaMs_1449() { GroupID = Parameter.HEC_CMT_CommunityGroupID, MemberID = Parameter.HEC_CMT_MembershipID }, securityTicket).Result;
            var memberRoles = cls_Get_MemberRoles_for_GroupID.Invoke(Connection, Transaction, new P_L5MC_GMRfGMID_1505() { GroupID = Parameter.HEC_CMT_CommunityGroupID, MemberID = Parameter.HEC_CMT_MembershipID }, securityTicket).Result.Roles;

            var subscription = ORM_HEC_CMT_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_GroupSubscription.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Membership_RefID = Parameter.HEC_CMT_MembershipID,
                CommunityGroup_RefID = Parameter.HEC_CMT_CommunityGroupID
            }).SingleOrDefault();

            var prevRequestStillActive = memberRequests.Where(w => w.Role_GlobalPropertyMatchingID == Parameter.Role_GlobalPropertyMatchingID).Count() > 0;
            var isThereCutomerRole = memberRoles.Where(w => w.GlobalPropertyMatchingID == Parameter.Role_GlobalPropertyMatchingID).Count() > 0;
            if (subscription == null || prevRequestStillActive && isThereCutomerRole)
            {
                returnValue.Result.IsSuccess = false;
                returnValue.Result.FailReason = new L5MC_MRR_1440_FailReason()
                {
                    IsntGroupMember = true,
                    IsAlreadyHaveThisRole = isThereCutomerRole,
                    IsAlreadyRequested = prevRequestStillActive,
                    IfAlreadyRequested_RequestID = isThereCutomerRole ? memberRequests.First(w => w.Role_GlobalPropertyMatchingID == Parameter.Role_GlobalPropertyMatchingID).HEC_CMT_GroupSubscription_RequestID : Guid.Empty
                };
            }
            else
            {
                var request = new ORM_HEC_CMT_GroupSubscription_Request()
                {
                    HEC_CMT_GroupSubscription_RequestID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID,
                    Membership_RefID = Parameter.HEC_CMT_MembershipID,
                    CommunityGroup_RefID = Parameter.HEC_CMT_CommunityGroupID,
                    IsRequested = true
                };
                request.Save(Connection, Transaction);

                var roleRequest = new ORM_HEC_CMT_OfferedRoles_2_GroupSubscriptionRequest()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    AssignmentID = Guid.NewGuid(),
                    HEC_CMT_OfferedRole_RefID = role.HEC_CMT_OfferedRoleID,
                    HEC_CMT_GroupSubscription_Request_RefID = request.HEC_CMT_GroupSubscription_RequestID
                };
                roleRequest.Save(Connection, Transaction);

                returnValue.Result.IsSuccess = true;
                returnValue.Result.HEC_CMT_GroupSubscription_RequestID = request.HEC_CMT_GroupSubscription_RequestID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MC_MRR_1440 Invoke(string ConnectionString,P_L5MC_MRR_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MC_MRR_1440 Invoke(DbConnection Connection,P_L5MC_MRR_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MC_MRR_1440 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_MRR_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MC_MRR_1440 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_MRR_1440 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MC_MRR_1440 functionReturn = new FR_L5MC_MRR_1440();
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

				throw new Exception("Exception occured in method cls_Make_Role_Request",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MC_MRR_1440 : FR_Base
	{
		public L5MC_MRR_1440 Result	{ get; set; }

		public FR_L5MC_MRR_1440() : base() {}

		public FR_L5MC_MRR_1440(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MC_MRR_1440 for attribute P_L5MC_MRR_1440
		[DataContract]
		public class P_L5MC_MRR_1440 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public string Role_GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5MC_MRR_1440 for attribute L5MC_MRR_1440
		[DataContract]
		public class L5MC_MRR_1440 
		{
			[DataMember]
			public L5MC_MRR_1440_FailReason FailReason { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 
			[DataMember]
			public bool IsSuccess { get; set; } 

		}
		#endregion
		#region SClass L5MC_MRR_1440_FailReason for attribute FailReason
		[DataContract]
		public class L5MC_MRR_1440_FailReason 
		{
			//Standard type parameters
			[DataMember]
			public bool IsntGroupMember { get; set; } 
			[DataMember]
			public bool IsAlreadyHaveThisRole { get; set; } 
			[DataMember]
			public bool IsAlreadyRequested { get; set; } 
			[DataMember]
			public Guid IfAlreadyRequested_RequestID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MC_MRR_1440 cls_Make_Role_Request(,P_L5MC_MRR_1440 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MC_MRR_1440 invocationResult = cls_Make_Role_Request.Invoke(connectionString,P_L5MC_MRR_1440 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5MC_MRR_1440();
parameter.HEC_CMT_CommunityGroupID = ...;
parameter.HEC_CMT_MembershipID = ...;
parameter.Role_GlobalPropertyMatchingID = ...;

*/
