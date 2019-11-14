/* 
 * Generated on 26.03.2015 15:56:48
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
    /// var result = cls_Make_PrivateJoinGroup_Request.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Make_PrivateJoinGroup_Request
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5MC_MPJGR_1556 Execute(DbConnection Connection,DbTransaction Transaction,P_L5MC_MPJGR_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5MC_MPJGR_1556();

            var group = ORM_HEC_CMT_CommunityGroup.Query.Search(Connection, Transaction, new ORM_HEC_CMT_CommunityGroup.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                IsPrivate = true,
                CommunityGroupCode = Parameter.Code
            }).SingleOrDefault();

            if (group != null)
            {
                var res = cls_Make_JoinGroup_Request.Invoke(Connection, Transaction, new P_L5MC_MJGR_1414() { HEC_CMT_MembershipID = Parameter.HEC_CMT_MembershipID, HEC_CMT_CommunityGroupID = group.HEC_CMT_CommunityGroupID }, securityTicket).Result;
                returnValue.Result = new L5MC_MPJGR_1556()
                {
                    HEC_CMT_GroupSubscription_RequestID = res.HEC_CMT_GroupSubscription_RequestID,
                    IsSuccess = res.IsSuccess
                };
                if (res.FailReason != null)
                {
                    returnValue.Result.FailReason = new L5MC_MPJGR_1556_FailReason()
                    {
                        IfAlreadyGorupMember_GroupID = res.FailReason.IfAlreadyGorupMember_GroupID,
                        IfAlreadyRequested_RequestID = res.FailReason.IfAlreadyRequested_RequestID,
                        IsAlreadyGorupMember = res.FailReason.IsAlreadyGorupMember,
                        IsAlreadyRequested = res.FailReason.IsAlreadyRequested
                    };
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
		public static FR_L5MC_MPJGR_1556 Invoke(string ConnectionString,P_L5MC_MPJGR_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5MC_MPJGR_1556 Invoke(DbConnection Connection,P_L5MC_MPJGR_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5MC_MPJGR_1556 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5MC_MPJGR_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5MC_MPJGR_1556 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5MC_MPJGR_1556 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5MC_MPJGR_1556 functionReturn = new FR_L5MC_MPJGR_1556();
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

				throw new Exception("Exception occured in method cls_Make_PrivateJoinGroup_Request",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5MC_MPJGR_1556 : FR_Base
	{
		public L5MC_MPJGR_1556 Result	{ get; set; }

		public FR_L5MC_MPJGR_1556() : base() {}

		public FR_L5MC_MPJGR_1556(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5MC_MPJGR_1556 for attribute P_L5MC_MPJGR_1556
		[DataContract]
		public class P_L5MC_MPJGR_1556 
		{
			//Standard type parameters
			[DataMember]
			public string Code { get; set; } 
			[DataMember]
			public Guid HEC_CMT_MembershipID { get; set; } 

		}
		#endregion
		#region SClass L5MC_MPJGR_1556 for attribute L5MC_MPJGR_1556
		[DataContract]
		public class L5MC_MPJGR_1556 
		{
			[DataMember]
			public L5MC_MPJGR_1556_FailReason FailReason { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 
			[DataMember]
			public bool IsSuccess { get; set; } 

		}
		#endregion
		#region SClass L5MC_MPJGR_1556_FailReason for attribute FailReason
		[DataContract]
		public class L5MC_MPJGR_1556_FailReason 
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
FR_L5MC_MPJGR_1556 cls_Make_PrivateJoinGroup_Request(,P_L5MC_MPJGR_1556 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5MC_MPJGR_1556 invocationResult = cls_Make_PrivateJoinGroup_Request.Invoke(connectionString,P_L5MC_MPJGR_1556 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Manipulation.P_L5MC_MPJGR_1556();
parameter.Code = ...;
parameter.HEC_CMT_MembershipID = ...;

*/
