/* 
 * Generated on 5/9/2014 6:35:54 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;

namespace CL3_InstallmentPlans.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Change_InstallmentPlan_StatusHistory.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Change_InstallmentPlan_StatusHistory
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3IP_CIPSH_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Bool();
            returnValue.Result = false;

            var installmentPlan = new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan();
            installmentPlan.Load(Connection, Transaction, Parameter.InstallmentPlanID);

            var statuses = CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_Status.Query.Search(Connection, Transaction,
                new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_Status.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

            bool isNotFullyPaidInstallmentPlan = CL1_ACC_IPL.ORM_ACC_IPL_Installment.Query.Exists(Connection, Transaction,
                new CL1_ACC_IPL.ORM_ACC_IPL_Installment.Query
                {
                    InstallmentPlan_RefID = installmentPlan.ACC_IPL_InstallmentPlanID,
                    IsFullyPaid = false,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

            var BusinessParticipantID = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction,
                new CL1_USR.ORM_USR_Account.Query
                {
                    USR_AccountID = securityTicket.AccountID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single().BusinessParticipant_RefID;

            // prepare new status history entry
            var newStatusHistoryEntry = new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_StatusHistory
            {
                ACC_IPL_InstallmentPlan_StatusHistoryID = Guid.NewGuid(),
                ACC_IPL_InstallmentPlan_RefID = installmentPlan.ACC_IPL_InstallmentPlanID,
                PerformedBy_BusinessParticipant_RefID = BusinessParticipantID,
                Creation_Timestamp = DateTime.Now,
                Tenant_RefID = securityTicket.TenantID
            };

            bool doUpdateStatus = false;
            EInstallmentPlanStatus newStatusEnum = EInstallmentPlanStatus.Created;

            if (Parameter.DoTerminate)
            {
                doUpdateStatus = true;
                newStatusEnum = EInstallmentPlanStatus.Terminated;
            }
            else if (isNotFullyPaidInstallmentPlan)
            {
                // Find out in which status Installment plan is
                var currentStatusMatchingID = statuses.Single(x => x.ACC_IPL_InstallmentPlan_StatusID == installmentPlan.Current_InstallmentPlanStatus_RefID).GlobalPropertyMatchingID;

                // If installment plan is not fully paid and if it is not in that status already, make it so
                if (currentStatusMatchingID != EnumUtils.GetEnumDescription(EInstallmentPlanStatus.PartiallyPayed))
                {
                    doUpdateStatus = true;
                    newStatusEnum = EInstallmentPlanStatus.PartiallyPayed;
                }
            }
            else
            {
                // If it is fully paid and not going to be terminated, installment plan has status 'PayedInTotal'
                doUpdateStatus = true;
                newStatusEnum = EInstallmentPlanStatus.PayedInTotal;
            }

            // finally, save status
            if (doUpdateStatus)
            {
                newStatusHistoryEntry.ACC_IPL_InstallmentPlan_Status_RefID = statuses.Single(
                    x => x.GlobalPropertyMatchingID == EnumUtils.GetEnumDescription(newStatusEnum)).ACC_IPL_InstallmentPlan_StatusID;
                newStatusHistoryEntry.Save(Connection, Transaction);

                installmentPlan.Current_InstallmentPlanStatus_RefID = newStatusHistoryEntry.ACC_IPL_InstallmentPlan_Status_RefID;
                installmentPlan.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3IP_CIPSH_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3IP_CIPSH_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3IP_CIPSH_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3IP_CIPSH_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Change_InstallmentPlan_StatusHistory",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3IP_CIPSH_1447 for attribute P_L3IP_CIPSH_1447
		[DataContract]
		public class P_L3IP_CIPSH_1447 
		{
			//Standard type parameters
			[DataMember]
			public Guid InstallmentPlanID { get; set; } 
			[DataMember]
			public Boolean DoTerminate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Change_InstallmentPlan_StatusHistory(,P_L3IP_CIPSH_1447 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Change_InstallmentPlan_StatusHistory.Invoke(connectionString,P_L3IP_CIPSH_1447 Parameter,securityTicket);
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
var parameter = new CL3_InstallmentPlans.Complex.Manipulation.P_L3IP_CIPSH_1447();
parameter.InstallmentPlanID = ...;
parameter.DoTerminate = ...;

*/
