/* 
 * Generated on 26.03.2015 12:36:07
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
using CL2_HECCommunityRole.DomainManagement;
using CL5_MPC_Account.Atomic.Retrieval;
using CL5_MPC_Community.Atomic.Retrieval;
using CL1_HEC_CMT;
using DLCore_DBCommons.Utils;

namespace CL5_MPC_Community.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Requests_for_Member.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Requests_for_Member
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GRfMID_1641_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GRfMID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5AC_GRfMID_1641_Array();
            

            var maxRolePerGroup = new Dictionary<Guid, ECommunityRole>();

            var user = cls_Get_AcctionGroups_with_Roles.Invoke(Connection, Transaction, new P_L5AC_GAGwR_1520() { CMN_BPT_USR_UserID = Parameter.CMN_BPT_USR_UserID }, securityTicket).Result;

            foreach (var group in user.Group)//set max role per group
            {
                foreach (var role in group.Group_Roles)
                {
                    ECommunityRole eRole = EnumUtils.GetEnumValueByDescription<ECommunityRole>(role.GlobalPropertyMatchingID);
                    if (!maxRolePerGroup.ContainsKey(group.HEC_CMT_CommunityGroupID))
                    {
                        maxRolePerGroup.Add(group.HEC_CMT_CommunityGroupID, eRole);
                    }
                    else
                    {
                        if (maxRolePerGroup[group.HEC_CMT_CommunityGroupID] < eRole)
                        {
                            maxRolePerGroup[group.HEC_CMT_CommunityGroupID] = eRole;
                        }
                    }
                }
            }
            var res = new List<L5AC_GRfMID_1641>();
            Guid[] groupIDsWhereCanAdministrate = maxRolePerGroup.ToArray().Where(w => w.Value >= ECommunityRole.Administrator).Select(s => s.Key).ToArray();
            if (groupIDsWhereCanAdministrate.Length > 0)
            {
                var requests = cls_Get_Requests_for_GroupIDs.Invoke(Connection, Transaction, new P_L5AC_GRfGIDs_1555() { GroupIDs = groupIDsWhereCanAdministrate }, securityTicket).Result;

                List<L5AC_GRfGIDs_1555> requestsThatICanSee = new List<L5AC_GRfGIDs_1555>();
                foreach (var request in requests)
                {
                    ECommunityRole eRole = EnumUtils.GetEnumValueByDescription<ECommunityRole>(request.Role_GlobalPropertyMatchingID);
                    if (maxRolePerGroup[request.CommunityGroup_RefID] >= eRole)
                        requestsThatICanSee.Add(request);
                }

                var groups = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, new ORM_HEC_CMT_CommunityGroup.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).ToArray();

                foreach (var request in requestsThatICanSee)
                {
                    var group = groups.SingleOrDefault(s => s.HEC_CMT_CommunityGroupID == request.CommunityGroup_RefID);
                    res.Add(new L5AC_GRfMID_1641()
                    {
                        HEC_CMT_GroupSubscription_RequestID = request.HEC_CMT_GroupSubscription_RequestID,
                        Role_GlobalPropertyMatchingID = request.Role_GlobalPropertyMatchingID,
                        CommunityGroup_RefID = request.CommunityGroup_RefID,
                        CommunityGroup_Name = group == null ? new Dict() : group.CommunityGroup_Name,
                        IsGroupJoinRequest = request.RoleRequestForGroup == null,
                        Request_By_MemberID = request.HEC_CMT_MembershipID,
                        Member_FirstName = request.Member_FirstName,
                        Member_LastName = request.Member_LastName,
                        CMN_BPT_USR_UserID = request.CMN_BPT_USR_UserID
                    });
                }
            }
            returnValue.Result = res.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GRfMID_1641_Array Invoke(string ConnectionString,P_L5AC_GRfMID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GRfMID_1641_Array Invoke(DbConnection Connection,P_L5AC_GRfMID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GRfMID_1641_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GRfMID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GRfMID_1641_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GRfMID_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GRfMID_1641_Array functionReturn = new FR_L5AC_GRfMID_1641_Array();
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

				throw new Exception("Exception occured in method cls_Get_Requests_for_Member",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GRfMID_1641_Array : FR_Base
	{
		public L5AC_GRfMID_1641[] Result	{ get; set; } 
		public FR_L5AC_GRfMID_1641_Array() : base() {}

		public FR_L5AC_GRfMID_1641_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GRfMID_1641 for attribute P_L5AC_GRfMID_1641
		[DataContract]
		public class P_L5AC_GRfMID_1641 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_USR_UserID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GRfMID_1641 for attribute L5AC_GRfMID_1641
		[DataContract]
		public class L5AC_GRfMID_1641 
		{
			//Standard type parameters
			[DataMember]
			public Guid Request_By_MemberID { get; set; } 
			[DataMember]
			public bool IsGroupJoinRequest { get; set; } 
			[DataMember]
			public Guid CMN_BPT_USR_UserID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 
			[DataMember]
			public string Role_GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Guid CommunityGroup_RefID { get; set; } 
			[DataMember]
			public Dict CommunityGroup_Name { get; set; } 
			[DataMember]
			public string Member_FirstName { get; set; } 
			[DataMember]
			public string Member_LastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GRfMID_1641_Array cls_Get_Requests_for_Member(,P_L5AC_GRfMID_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GRfMID_1641_Array invocationResult = cls_Get_Requests_for_Member.Invoke(connectionString,P_L5AC_GRfMID_1641 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Complex.Retrieval.P_L5AC_GRfMID_1641();
parameter.CMN_BPT_USR_UserID = ...;

*/
