/* 
 * Generated on 27.03.2015 11:38:30
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
    /// var result = cls_Remove_AdminRoles.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Remove_AdminRoles
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MC_RAR_1138 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_RAR_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5MC_RAR_1138();


            var roles = ORM_HEC_CMT_OfferedRole.Query.Search(Connection, Transaction, new ORM_HEC_CMT_OfferedRole.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).ToArray();

            var roleToId = new Dictionary<ECommunityRole, ORM_HEC_CMT_OfferedRole>();
            foreach (var role in roles)
            {
                roleToId.Add(EnumUtils.GetEnumValueByDescription<ECommunityRole>(role.GlobalPropertyMatchingID), role);
            }

            var groupSubscription = ORM_HEC_CMT_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_GroupSubscription.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                Membership_RefID = Parameter.HEC_CMT_MembershipID,
                CommunityGroup_RefID = Parameter.HEC_CMT_CommunityGroupID,
                IsDeleted = false
            }).Single();

            var r2gs = ORM_HEC_CMT_OfferedRoles_2_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_OfferedRoles_2_GroupSubscription.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                HEC_CMT_GroupSubscription_RefID = groupSubscription.HEC_CMT_GroupSubscriptionID,
                IsDeleted = false
            }).ToArray();

            foreach (var r2g in r2gs)
            {
                var currentRole = roleToId.ToArray().Single(s => s.Value.HEC_CMT_OfferedRoleID == r2g.HEC_CMT_OfferedRole_RefID).Key;
                if (currentRole >= ECommunityRole.Administrator)
                {
                    r2g.IsDeleted = true;
                    r2g.Save(Connection, Transaction);
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5MC_RAR_1138 Invoke(string ConnectionString,P_L5MC_RAR_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MC_RAR_1138 Invoke(DbConnection Connection,P_L5MC_RAR_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MC_RAR_1138 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_RAR_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MC_RAR_1138 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_RAR_1138 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MC_RAR_1138 functionReturn = new FR_L5MC_RAR_1138();
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

				throw new Exception("Exception occured in method cls_Remove_AdminRoles",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MC_RAR_1138 : FR_Base
	{
		public L5MC_RAR_1138 Result	{ get; set; }

		public FR_L5MC_RAR_1138() : base() {}

		public FR_L5MC_RAR_1138(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MC_RAR_1138 for attribute P_L5MC_RAR_1138
		[DataContract]
		public class P_L5MC_RAR_1138 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 

		}
		#endregion
		#region SClass L5MC_RAR_1138 for attribute L5MC_RAR_1138
		[DataContract]
		public class L5MC_RAR_1138 
		{
			//Standard type parameters
		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5MC_RAR_1138 cls_Remove_AdminRoles(,P_L5MC_RAR_1138 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MC_RAR_1138 invocationResult = cls_Remove_AdminRoles.Invoke(connectionString,P_L5MC_RAR_1138 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5MC_RAR_1138();
parameter.HEC_CMT_CommunityGroupID = ...;
parameter.HEC_CMT_MembershipID = ...;

*/
