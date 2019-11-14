/* 
 * Generated on 11.02.2015 16:44:39
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

namespace CL5_MyHealthClub_MedProCommunity.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MembershipCredential.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MembershipCredential
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5MPC_SMC_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            returnValue.Result = new Guid();
            #region Save

            var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCommunityOperatedByThisTenant = true
            }).Single();

            var membershipType = ORM_HEC_CMT_Community_OfferedMembershipType.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community_OfferedMembershipType.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsAvailableFor_Tenants = Parameter.IsTenant,
                IsAvailableFor_Doctors = !Parameter.IsTenant
            }).Single();

            var members = ORM_HEC_CMT_Membership.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Membership.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                BusinessParticipant_RefID = Parameter.BusinessParticipantID
            }).SingleOrDefault();
            if (members == null)
            {
                members = new ORM_HEC_CMT_Membership()
                {
                    HEC_CMT_MembershipID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID,
                    CommunityMembershipITL = Guid.Empty.ToString(),
                    BusinessParticipant_RefID = Parameter.BusinessParticipantID,
                    Community_RefID = community.HEC_CMT_CommunityID
                };
                members.Save(Connection, Transaction);
            }

            var creds = ORM_HEC_CMT_Membership_Credential.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Membership_Credential.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Membership_RefID = members.HEC_CMT_MembershipID
            }).SingleOrDefault();
            if (creds == null)
            {
                creds = new ORM_HEC_CMT_Membership_Credential()
                {
                    HEC_CMT_Membership_CredentialID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID,
                    Membership_RefID = members.HEC_CMT_MembershipID,
                };
            }
            creds.Membership_Password = Parameter.Membership_Password;
            creds.Membership_Username = Parameter.Membership_Username;
            creds.Save(Connection, Transaction);

            if (!Parameter.IsTenant)
            {
                var group = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, new ORM_HEC_CMT_CommunityGroup.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsPrivate = false,
                    IsDeleted = false,
                    CommunityGroupCode = "FAVORITES"
                }).Single();

                var m2g = ORM_HEC_CMT_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_GroupSubscription.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    Membership_RefID = members.HEC_CMT_MembershipID,
                    CommunityGroup_RefID = group.HEC_CMT_CommunityGroupID
                }).SingleOrDefault();
                if (m2g == null)
                {
                    m2g = new ORM_HEC_CMT_GroupSubscription()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        Membership_RefID = members.HEC_CMT_MembershipID,
                        CommunityGroup_RefID = group.HEC_CMT_CommunityGroupID
                    };
                    m2g.Save(Connection, Transaction);
                }

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
		public static FR_Guid Invoke(string ConnectionString,P_L5MPC_SMC_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5MPC_SMC_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MPC_SMC_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MPC_SMC_1101 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_MembershipCredential",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5MPC_SMC_1101 for attribute P_L5MPC_SMC_1101
		[DataContract]
		public class P_L5MPC_SMC_1101 
		{
			//Standard type parameters
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public String Membership_Username { get; set; } 
			[DataMember]
			public String Membership_Password { get; set; } 
			[DataMember]
			public bool IsTenant { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_MembershipCredential(,P_L5MPC_SMC_1101 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_MembershipCredential.Invoke(connectionString,P_L5MPC_SMC_1101 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_MedProCommunity.Atomic.Manipulation.P_L5MPC_SMC_1101();
parameter.BusinessParticipantID = ...;
parameter.Membership_Username = ...;
parameter.Membership_Password = ...;
parameter.IsTenant = ...;

*/
