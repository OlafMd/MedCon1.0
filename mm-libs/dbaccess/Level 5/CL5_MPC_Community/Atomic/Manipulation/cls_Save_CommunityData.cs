/* 
 * Generated on 2/9/2015 11:24:56 PM
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

namespace CL5_MPC_Community.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CommunityData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CommunityData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_SCD_2316 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            var communitiy = new ORM_HEC_CMT_Community()
            {
                HEC_CMT_CommunityID = Guid.NewGuid(),
                Tenant_RefID = securityTicket.TenantID,
                IsCommunityOperatedByThisTenant = true,
                CommunityServicesBaseURL = Parameter.CommunityBaseURL,
                HealthcareCommunityITL = Parameter.CommunityITL
            };
            communitiy.Save(Connection, Transaction);

            if (Parameter.MembershipTypes != null)
            {
                foreach (var type in Parameter.MembershipTypes)
                {
                    var membershipType = new ORM_HEC_CMT_Community_OfferedMembershipType()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsAvailableFor_Tenants = type.IsAvailableFor_Tenants,
                        IsAvailableFor_Doctors = type.IsAvailableFor_Doctors,
                        HEC_CMT_Community_OfferedMembershipTypeID = Guid.NewGuid(),
                        HealthcareCommunityOfferedMembershipTypesITL = type.HealthcareCommunityOfferedMembershipTypesITL,
                        OfferedMembershipType_DisplayName = type.TypeDisplayName,
                        Community_RefID = communitiy.HEC_CMT_CommunityID
                    };
                    membershipType.Save(Connection, Transaction);
                }
            }

            if (Parameter.OfferedRoles != null)
            {
                foreach (var role in Parameter.OfferedRoles)
                {
                    var offeredRole = new ORM_HEC_CMT_OfferedRole()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        Community_RefID = communitiy.HEC_CMT_CommunityID,
                        GlobalPropertyMatchingID = role.GlobalPropertyMatchingID,
                        HEC_CMT_OfferedRoleID = Guid.NewGuid(),
                        IsUniqueOverAllGroupsPerSubscriber = role.IsUniqueOverAllGroupsPerSubscriber,
                        CommunityRoleITL = role.CommunityRoleITL,
                    };
                    offeredRole.Save(Connection, Transaction);
                }
            }
            if (Parameter.Group != null)
            {
                var group = new ORM_HEC_CMT_CommunityGroup()
                {
                    HEC_CMT_CommunityGroupID = Guid.NewGuid(),
                    HealthcareCommunityGroupITL = Parameter.Group.GroupITL,
                    Tenant_RefID = securityTicket.TenantID,
                    Community_RefID = communitiy.HEC_CMT_CommunityID,
                    CommunityGroupCode = Parameter.Group.GroupCode
                };

                group.Save(Connection, Transaction);
            }


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AC_SCD_2316 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AC_SCD_2316 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_SCD_2316 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_SCD_2316 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CommunityData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AC_SCD_2316 for attribute P_L5AC_SCD_2316
		[DataContract]
		public class P_L5AC_SCD_2316 
		{
			[DataMember]
			public P_L5AC_SCD_2316_MembershipType[] MembershipTypes { get; set; }
			[DataMember]
			public P_L5AC_SCD_2316_OfferedRole[] OfferedRoles { get; set; }
			[DataMember]
			public P_L5AC_SCD_2316_Group Group { get; set; }

			//Standard type parameters
			[DataMember]
			public string CommunityITL { get; set; } 
			[DataMember]
			public string CommunityBaseURL { get; set; } 

		}
		#endregion
		#region SClass P_L5AC_SCD_2316_MembershipType for attribute MembershipTypes
		[DataContract]
		public class P_L5AC_SCD_2316_MembershipType 
		{
			//Standard type parameters
			[DataMember]
			public string HealthcareCommunityOfferedMembershipTypesITL { get; set; } 
			[DataMember]
			public string TypeDisplayName { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Tenants { get; set; } 
			[DataMember]
			public bool IsAvailableFor_Doctors { get; set; } 

		}
		#endregion
		#region SClass P_L5AC_SCD_2316_OfferedRole for attribute OfferedRoles
		[DataContract]
		public class P_L5AC_SCD_2316_OfferedRole 
		{
			//Standard type parameters
			[DataMember]
			public string CommunityRoleITL { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public bool IsUniqueOverAllGroupsPerSubscriber { get; set; } 

		}
		#endregion
		#region SClass P_L5AC_SCD_2316_Group for attribute Group
		[DataContract]
		public class P_L5AC_SCD_2316_Group 
		{
			//Standard type parameters
			[DataMember]
			public string GroupITL { get; set; } 
			[DataMember]
			public string GroupCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CommunityData(,P_L5AC_SCD_2316 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CommunityData.Invoke(connectionString,P_L5AC_SCD_2316 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5AC_SCD_2316();
parameter.MembershipTypes = ...;
parameter.OfferedRoles = ...;
parameter.Group = ...;

parameter.CommunityITL = ...;
parameter.CommunityBaseURL = ...;

*/
