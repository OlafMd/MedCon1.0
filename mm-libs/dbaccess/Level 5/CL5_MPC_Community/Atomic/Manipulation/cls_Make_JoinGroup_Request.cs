/* 
 * Generated on 24.03.2015 14:31:03
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
using DLCore_DBCommons.Utils;
using CL2_HECCommunityRole.DomainManagement;

namespace CL5_MPC_Community.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Make_JoinGroup_Request.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Make_JoinGroup_Request
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MC_MJGR_1414 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_MJGR_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5MC_MJGR_1414();
            returnValue.Result = new L5MC_MJGR_1414();

            var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCommunityOperatedByThisTenant = true
            }).Single();

            var role = ORM_HEC_CMT_OfferedRole.Query.Search(Connection, Transaction, new ORM_HEC_CMT_OfferedRole.Query()
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(ECommunityRole.Contributor),
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Single();

            var prevRequest = ORM_HEC_CMT_GroupSubscription_Request.Query.Search(Connection, Transaction, new ORM_HEC_CMT_GroupSubscription_Request.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsApproved = false,
                IsRequested = false,
                Membership_RefID = Parameter.HEC_CMT_MembershipID,
                CommunityGroup_RefID = Parameter.HEC_CMT_CommunityGroupID
            }).SingleOrDefault();

            var subscription = ORM_HEC_CMT_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_GroupSubscription.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Membership_RefID = Parameter.HEC_CMT_MembershipID,
                CommunityGroup_RefID = Parameter.HEC_CMT_CommunityGroupID
            }).SingleOrDefault();

            if (subscription == null && prevRequest == null)
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
            else
            {
                returnValue.Result.FailReason = new L5MC_MJGR_1414_FailReason()
                {
                    IfAlreadyGorupMember_GroupID = subscription == null ? Guid.Empty : subscription.HEC_CMT_GroupSubscriptionID,
                    IsAlreadyGorupMember = subscription != null,
                    IsAlreadyRequested = prevRequest != null,
                    IfAlreadyRequested_RequestID = prevRequest == null ? Guid.Empty : prevRequest.HEC_CMT_GroupSubscription_RequestID
                };
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MC_MJGR_1414 Invoke(string ConnectionString,P_L5MC_MJGR_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MC_MJGR_1414 Invoke(DbConnection Connection,P_L5MC_MJGR_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MC_MJGR_1414 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_MJGR_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MC_MJGR_1414 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_MJGR_1414 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MC_MJGR_1414 functionReturn = new FR_L5MC_MJGR_1414();
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

				throw new Exception("Exception occured in method cls_Make_JoinGroup_Request",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MC_MJGR_1414 : FR_Base
	{
		public L5MC_MJGR_1414 Result	{ get; set; }

		public FR_L5MC_MJGR_1414() : base() {}

		public FR_L5MC_MJGR_1414(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MC_MJGR_1414 for attribute P_L5MC_MJGR_1414
		[DataContract]
		public class P_L5MC_MJGR_1414 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 

		}
		#endregion
		#region SClass L5MC_MJGR_1414 for attribute L5MC_MJGR_1414
		[DataContract]
		public class L5MC_MJGR_1414 
		{
			[DataMember]
			public L5MC_MJGR_1414_FailReason FailReason { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 
			[DataMember]
			public bool IsSuccess { get; set; } 

		}
		#endregion
		#region SClass L5MC_MJGR_1414_FailReason for attribute FailReason
		[DataContract]
		public class L5MC_MJGR_1414_FailReason 
		{
			//Standard type parameters
			[DataMember]
			public bool IsAlreadyGorupMember { get; set; } 
			[DataMember]
			public Guid IfAlreadyGorupMember_GroupID { get; set; } 
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
FR_L5MC_MJGR_1414 cls_Make_JoinGroup_Request(,P_L5MC_MJGR_1414 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MC_MJGR_1414 invocationResult = cls_Make_JoinGroup_Request.Invoke(connectionString,P_L5MC_MJGR_1414 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5MC_MJGR_1414();
parameter.HEC_CMT_CommunityGroupID = ...;
parameter.HEC_CMT_MembershipID = ...;

*/
