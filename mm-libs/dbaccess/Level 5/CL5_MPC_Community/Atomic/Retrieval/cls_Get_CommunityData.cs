/* 
 * Generated on 09.02.2015 20:45:23
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

namespace CL5_MPC_Community.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CommunityData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CommunityData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GCD_1251 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AC_GCD_1251();

            var community = ORM_HEC_CMT_Community.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCommunityOperatedByThisTenant = true
            }).Single();

            var membershipTypes = ORM_HEC_CMT_Community_OfferedMembershipType.Query.Search(Connection, Transaction, new ORM_HEC_CMT_Community_OfferedMembershipType.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Community_RefID = community.HEC_CMT_CommunityID
            }).ToArray();

            returnValue.Result = new L5AC_GCD_1251()
            {
                CommunityBaseURL = community.CommunityServicesBaseURL,
                CommunityITL = community.HealthcareCommunityITL,     
                
            };

            var rolesORM = ORM_HEC_CMT_OfferedRole.Query.Search(Connection, Transaction, new ORM_HEC_CMT_OfferedRole.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                Community_RefID = community.HEC_CMT_CommunityID
            }).ToArray();


            var types = new List<L5AC_GCD_1251_MembershipType>();

            foreach (var membershipType in membershipTypes)
            {
                types.Add(new L5AC_GCD_1251_MembershipType()
                {
                    HealthcareCommunityOfferedMembershipTypesITL = membershipType.HealthcareCommunityOfferedMembershipTypesITL,
                    IsAvailableFor_Doctors = membershipType.IsAvailableFor_Doctors,
                    IsAvailableFor_Tenants = membershipType.IsAvailableFor_Tenants,
                    TypeDisplayName = membershipType.OfferedMembershipType_DisplayName
                });
            }

            var roles = new List<L5AC_GCD_1251_OfferedRole>();

            foreach (var roleORM in rolesORM)
            {
                roles.Add(new L5AC_GCD_1251_OfferedRole()
                {
                    CommunityRoleITL = roleORM.CommunityRoleITL,
                    GlobalPropertyMatchingID = roleORM.GlobalPropertyMatchingID,
                    IsUniqueOverAllGroupsPerSubscriber = roleORM.IsUniqueOverAllGroupsPerSubscriber
                });
            }

            var group = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, new ORM_HEC_CMT_CommunityGroup.Query()
            {
                IsDeleted = false,
                IsPrivate = false,
                Tenant_RefID = securityTicket.TenantID,
                CommunityGroupCode = "FAVORITES"
            }).Single();

            returnValue.Result.Group = new L5AC_GCD_1251_Group()
            {
                GroupCode = group.CommunityGroupCode,
                GroupITL = group.HealthcareCommunityGroupITL
            };

            returnValue.Result.MembershipTypes = types.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AC_GCD_1251 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GCD_1251 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GCD_1251 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GCD_1251 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GCD_1251 functionReturn = new FR_L5AC_GCD_1251();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_CommunityData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GCD_1251 : FR_Base
	{
		public L5AC_GCD_1251 Result	{ get; set; }

		public FR_L5AC_GCD_1251() : base() {}

		public FR_L5AC_GCD_1251(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5AC_GCD_1251 for attribute L5AC_GCD_1251
		[DataContract]
		public class L5AC_GCD_1251 
		{
			[DataMember]
			public L5AC_GCD_1251_MembershipType[] MembershipTypes { get; set; }
			[DataMember]
			public L5AC_GCD_1251_OfferedRole[] OfferedRoles { get; set; }
			[DataMember]
			public L5AC_GCD_1251_Group Group { get; set; }

			//Standard type parameters
			[DataMember]
			public string CommunityITL { get; set; } 
			[DataMember]
			public string CommunityBaseURL { get; set; } 

		}
		#endregion
		#region SClass L5AC_GCD_1251_MembershipType for attribute MembershipTypes
		[DataContract]
		public class L5AC_GCD_1251_MembershipType 
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
		#region SClass L5AC_GCD_1251_OfferedRole for attribute OfferedRoles
		[DataContract]
		public class L5AC_GCD_1251_OfferedRole 
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
		#region SClass L5AC_GCD_1251_Group for attribute Group
		[DataContract]
		public class L5AC_GCD_1251_Group 
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
FR_L5AC_GCD_1251 cls_Get_CommunityData(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GCD_1251 invocationResult = cls_Get_CommunityData.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

