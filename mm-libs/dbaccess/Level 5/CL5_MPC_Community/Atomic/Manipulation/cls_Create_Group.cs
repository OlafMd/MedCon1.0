/* 
 * Generated on 03.03.2015 12:14:16
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
using CL2_HECCommunityRole.DomainManagement;
using DLCore_DBCommons.Utils;

namespace CL5_MPC_Community.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Group.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Group
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_SG_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCommunityOperatedByThisTenant = true
            }).Single();

            if (Parameter.HEC_CMT_CommunityGroupID == Guid.Empty)
            {
                Random _rng = new Random((int)DateTime.Now.Ticks);
                string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
                int loopCountMax = 100;
                int loopCounter = 0;
                bool uniqueFlag = false;
                string codeValue;

                do
                {
                    loopCounter++;
                    if (loopCounter > loopCountMax)
                    {
                        return null;
                    }

                    char[] buffer = new char[6];
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer[i] = _chars[_rng.Next(_chars.Length)];
                    }
                    codeValue = new string(buffer);

                    var query1 = new ORM_HEC_CMT_CommunityGroup.Query();
                    query1.CommunityGroupCode = codeValue;
                    query1.Tenant_RefID = securityTicket.TenantID;
                    query1.IsDeleted = false;

                    var codes = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, query1);
                    if (codes.Count == 0)
                        uniqueFlag = true;
                } while (!uniqueFlag);

                var group = new ORM_HEC_CMT_CommunityGroup()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsPrivate = Parameter.IsPrivate,
                    IsDeleted = false,
                    CommunityGroupCode = codeValue,
                    CommunityGroup_Name = Parameter.GroupName,
                    CommunityGroup_Description = Parameter.GroupDescription,
                    HealthcareCommunityGroupITL = Guid.NewGuid().ToString(),
                    HEC_CMT_CommunityGroupID = Guid.NewGuid(),
                    Community_RefID = community.HEC_CMT_CommunityID
                };
                group.Save(Connection, Transaction);

                var member = ORM_HEC_CMT_Membership.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Membership.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Community_RefID = community.HEC_CMT_CommunityID,
                    BusinessParticipant_RefID = Parameter.UserBPID
                }).Single();

                var m2g = new ORM_HEC_CMT_GroupSubscription()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    Membership_RefID = member.HEC_CMT_MembershipID,
                    CommunityGroup_RefID = group.HEC_CMT_CommunityGroupID
                };
                m2g.Save(Connection, Transaction);

                var founderRoleID = DMCommunityRoles.Get_CommunityRole_for_GlobalPropertyMatchingID(Connection, Transaction,
                    EnumUtils.GetEnumDescription(ECommunityRole.Founder_Init), community.HEC_CMT_CommunityID, securityTicket);

                var contributorRoleID = DMCommunityRoles.Get_CommunityRole_for_GlobalPropertyMatchingID(Connection, Transaction,
                    EnumUtils.GetEnumDescription(ECommunityRole.Contributor), community.HEC_CMT_CommunityID, securityTicket);

                DMCommunityRoles.Get_CommunityRole_for_GlobalPropertyMatchingID(Connection, Transaction,
                EnumUtils.GetEnumDescription(ECommunityRole.Bureaucrat), community.HEC_CMT_CommunityID, securityTicket);
                DMCommunityRoles.Get_CommunityRole_for_GlobalPropertyMatchingID(Connection, Transaction,
                EnumUtils.GetEnumDescription(ECommunityRole.Founder), community.HEC_CMT_CommunityID, securityTicket);

                var r2gFounder = new ORM_HEC_CMT_OfferedRoles_2_GroupSubscription()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    AssignmentID = Guid.NewGuid(),
                    HEC_CMT_GroupSubscription_RefID = m2g.HEC_CMT_GroupSubscriptionID,
                    HEC_CMT_OfferedRole_RefID = founderRoleID
                };
                r2gFounder.Save(Connection, Transaction);

                var r2gContributor = new ORM_HEC_CMT_OfferedRoles_2_GroupSubscription()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    AssignmentID = Guid.NewGuid(),
                    HEC_CMT_GroupSubscription_RefID = m2g.HEC_CMT_GroupSubscriptionID,
                    HEC_CMT_OfferedRole_RefID = contributorRoleID
                };
                r2gContributor.Save(Connection, Transaction);

                returnValue.Result = group.HEC_CMT_CommunityGroupID;
            }
            else
            {
                var group = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, new ORM_HEC_CMT_CommunityGroup.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    HEC_CMT_CommunityGroupID = Parameter.HEC_CMT_CommunityGroupID
                }).Single();

                group.IsPrivate = Parameter.IsPrivate;
                group.CommunityGroup_Name = Parameter.GroupName;
                group.CommunityGroup_Description = Parameter.GroupDescription;
                group.Save(Connection, Transaction);

                returnValue.Result = Parameter.HEC_CMT_CommunityGroupID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5MC_SG_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5MC_SG_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_SG_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_SG_1701 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_Group",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5MC_SG_1701 for attribute P_L5MC_SG_1701
		[DataContract]
		public class P_L5MC_SG_1701 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public Dict GroupName { get; set; } 
			[DataMember]
			public Dict GroupDescription { get; set; } 
			[DataMember]
			public bool IsPrivate { get; set; } 
			[DataMember]
			public Guid UserBPID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Group(,P_L5MC_SG_1701 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Group.Invoke(connectionString,P_L5MC_SG_1701 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5MC_SG_1701();
parameter.HEC_CMT_CommunityGroupID = ...;
parameter.GroupName = ...;
parameter.GroupDescription = ...;
parameter.IsPrivate = ...;
parameter.UserBPID = ...;

*/
