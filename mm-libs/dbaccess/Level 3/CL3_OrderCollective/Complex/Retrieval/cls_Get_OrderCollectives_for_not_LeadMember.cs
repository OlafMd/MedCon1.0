/* 
 * Generated on 10/29/2014 4:48:39 PM
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
using CL1_CMN_BPT;
using CL3_OrderCollective.Atomic.Retrieval;
using CL1_OCL;

namespace CL3_OrderCollective.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OrderCollectives_for_not_LeadMember.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrderCollectives_for_not_LeadMember
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3OC_GOCfnLM_1602_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3OC_GOCfnLM_1602_Array();
            var results = new List<L3OC_GOCfnLM_1602>();
			
            #region Get Order Collectives for which current Tenant ISN'T a Lead
            var orderCollectives = cls_Get_OrderCollective_for_Member.Invoke(
                Connection, 
                Transaction, 
                new P_L3OC_GOCfM_1544() { IsMemberLead = false }, 
                securityTicket);
            if (orderCollectives == null || orderCollectives.Result == null || orderCollectives.Result.Count() < 1) 
            {
                returnValue.Result = results.ToArray();
                returnValue.Status = FR_Status.Success;
                return returnValue;
            }
            #endregion

            #region Get Tenant Business Participant
            var tenantBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
            new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IfTenant_Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();
            if (tenantBusinessParticipant == null) 
            {
                returnValue.Result = results.ToArray();
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            #endregion

            foreach (var orderCollective in orderCollectives.Result) 
            {
                #region Get Tenant Order Collective Member
                var tenantMember = ORM_OCL_OrderCollective_Member.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_OCL_OrderCollective_Member.Query() 
                    {
                        BusinessParticipant_RefID = tenantBusinessParticipant.CMN_BPT_BusinessParticipantID,
                        OrderCollective_RefID = orderCollective.OCL_OrderCollectiveID,
                        Tenant_RefID = securityTicket.TenantID
                    }).FirstOrDefault();
                if (tenantMember == null) 
                {
                    returnValue.Result = results.ToArray();
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }
                #endregion

                results.Add(new L3OC_GOCfnLM_1602() 
                {
                    OrderCollective = orderCollective,
                    CurrentOrderCollectiveMemberID = tenantMember.OCL_OrderCollective_MemberID,
                    CurrentOrderCollectiveMemberJoinDate = tenantMember.MemberSince
                });
            }

            returnValue.Status = FR_Status.Success;
            returnValue.Result = results.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3OC_GOCfnLM_1602_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3OC_GOCfnLM_1602_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3OC_GOCfnLM_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3OC_GOCfnLM_1602_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3OC_GOCfnLM_1602_Array functionReturn = new FR_L3OC_GOCfnLM_1602_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrderCollectives_for_not_LeadMember",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3OC_GOCfnLM_1602_Array : FR_Base
	{
		public L3OC_GOCfnLM_1602[] Result	{ get; set; } 
		public FR_L3OC_GOCfnLM_1602_Array() : base() {}

		public FR_L3OC_GOCfnLM_1602_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3OC_GOCfnLM_1602 for attribute L3OC_GOCfnLM_1602
		[DataContract]
		public class L3OC_GOCfnLM_1602 
		{
			[DataMember]
			public CL3_OrderCollective.Atomic.Retrieval.L3OC_GOCfM_1544 OrderCollective { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CurrentOrderCollectiveMemberID { get; set; } 
			[DataMember]
			public DateTime CurrentOrderCollectiveMemberJoinDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3OC_GOCfnLM_1602_Array cls_Get_OrderCollectives_for_not_LeadMember(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3OC_GOCfnLM_1602_Array invocationResult = cls_Get_OrderCollectives_for_not_LeadMember.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

