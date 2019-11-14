/* 
 * Generated on 05.03.2015 15:37:20
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
    /// var result = cls_Add_GroupRole.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Add_GroupRole
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_AGR_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            var query = new ORM_HEC_CMT_OfferedRole.Query();
            query.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
            query.IsDeleted = false;
            query.Tenant_RefID = securityTicket.TenantID;
            var role = ORM_HEC_CMT_OfferedRole.Query.Search(Connection, Transaction, query).Single();


            var m2g = ORM_HEC_CMT_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_GroupSubscription.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                Membership_RefID = Parameter.HEC_CMT_MembershipID,
                CommunityGroup_RefID = Parameter.HEC_CMT_CommunityGroupID,
                IsDeleted = false
            }).Single();

            var r2gs = ORM_HEC_CMT_OfferedRoles_2_GroupSubscription.Query.Search(Connection, Transaction, new ORM_HEC_CMT_OfferedRoles_2_GroupSubscription.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                HEC_CMT_GroupSubscription_RefID = m2g.HEC_CMT_GroupSubscriptionID,
                HEC_CMT_OfferedRole_RefID = role.HEC_CMT_OfferedRoleID,
                IsDeleted = false
            }).SingleOrDefault();
            if (r2gs == null)
            {
                r2gs = new ORM_HEC_CMT_OfferedRoles_2_GroupSubscription()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    AssignmentID = Guid.NewGuid(),
                    HEC_CMT_GroupSubscription_RefID = m2g.HEC_CMT_GroupSubscriptionID,
                    HEC_CMT_OfferedRole_RefID = role.HEC_CMT_OfferedRoleID
                };
                r2gs.Save(Connection, Transaction);
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5MC_AGR_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5MC_AGR_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_AGR_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_AGR_1140 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Add_GroupRole",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5MC_AGR_1140 for attribute P_L5MC_AGR_1140
		[DataContract]
		public class P_L5MC_AGR_1140 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_CommunityGroupID { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Add_GroupRole(,P_L5MC_AGR_1140 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Add_GroupRole.Invoke(connectionString,P_L5MC_AGR_1140 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5MC_AGR_1140();
parameter.HEC_CMT_CommunityGroupID = ...;
parameter.HEC_CMT_MembershipID = ...;
parameter.GlobalPropertyMatchingID = ...;

*/
