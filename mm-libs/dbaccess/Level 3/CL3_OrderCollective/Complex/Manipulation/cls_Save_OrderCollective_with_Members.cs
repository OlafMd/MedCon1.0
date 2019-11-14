/* 
 * Generated on 10/13/2014 9:57:35 AM
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
using CL2_OrderCollective.Atomic.Manipulation;
using CL1_CMN_BPT;

namespace CL3_OrderCollective.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OrderCollective_with_Members.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OrderCollective_with_Members
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3OC_SOCwM_0925 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
			#region UserCode 
			var returnValue = new FR_Guid();
            returnValue.Status = FR_Status.Error_Internal;
            returnValue.Result = Guid.Empty;

            var orderCollectiveId = cls_Save_OCL_OrderCollective.Invoke(Connection, Transaction, Parameter.OrderCollective, securityTicket).Result;

            if (orderCollectiveId != null && orderCollectiveId != Guid.Empty)
            {
                foreach (var member in Parameter.OrderCollectiveLeadMembers)
                {
                    if (member.IsOrderCollectiveLead)
                    {
                        var bussinesParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(
                            Connection,
                            Transaction,
                            new ORM_CMN_BPT_BusinessParticipant.Query()
                            {
                                IfTenant_Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false
                            }).FirstOrDefault();
                        member.BusinessParticipant_RefID = bussinesParticipant == null
                            ? Guid.Empty
                            : bussinesParticipant.CMN_BPT_BusinessParticipantID;
                    }

                    member.OrderCollective_RefID = orderCollectiveId;
                    cls_Save_OCL_OrderCollective_Member.Invoke(Connection, Transaction, member, securityTicket);
                }
                returnValue.Status = FR_Status.Success;
                returnValue.Result = orderCollectiveId;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3OC_SOCwM_0925 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3OC_SOCwM_0925 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3OC_SOCwM_0925 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3OC_SOCwM_0925 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_OrderCollective_with_Members",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3OC_SOCwM_0925 for attribute P_L3OC_SOCwM_0925
		[DataContract]
		public class P_L3OC_SOCwM_0925 
		{
			//Standard type parameters
			[DataMember]
			public CL2_OrderCollective.Atomic.Manipulation.P_L2OC_SOC_1528 OrderCollective { get; set; } 
			[DataMember]
			public CL2_OrderCollective.Atomic.Manipulation.P_L2OC_SOCM_0922[] OrderCollectiveLeadMembers { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_OrderCollective_with_Members(,P_L3OC_SOCwM_0925 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_OrderCollective_with_Members.Invoke(connectionString,P_L3OC_SOCwM_0925 Parameter,securityTicket);
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
var parameter = new CL3_OrderCollective.Complex.Manipulation.P_L3OC_SOCwM_0925();
parameter.OrderCollective = ...;
parameter.OrderCollectiveLeadMembers = ...;

*/
