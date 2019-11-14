/* 
 * Generated on 12/5/2014 08:37:53
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
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL3_InstallmentPlans.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_InstallmentPlan.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_InstallmentPlan
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3IP_SIP_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            returnValue.Result = Guid.Empty;

            bool isNew = Parameter.InstallmentPlanID == Guid.Empty;

            Guid currencyID = CL2_Currency.Atomic.Retrieval.cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.CMN_CurrencyID;

            var installmentPlan = new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan();
            var statusHistory = new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_StatusHistory();

            var firstDate = DateTime.Now;

            if (isNew)
            {
                #region Create new Installment Plan

                installmentPlan.ACC_IPL_InstallmentPlanID = Guid.NewGuid();

                installmentPlan.InstallmentPeriodType = 0;
                installmentPlan.InstallmentStart = firstDate;
                installmentPlan.Currency_RefID = currencyID;
                installmentPlan.Creation_Timestamp = DateTime.Now;
                installmentPlan.Tenant_RefID = securityTicket.TenantID;

                Guid statusID = CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_Status.Query.Search(Connection, Transaction,
                    new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_Status.Query
                    {
                        GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EInstallmentPlanStatus.Created),
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single().ACC_IPL_InstallmentPlan_StatusID;

                var BusinessParticipantID = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction,
                    new CL1_USR.ORM_USR_Account.Query
                    {
                        USR_AccountID = securityTicket.AccountID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single().BusinessParticipant_RefID;

                statusHistory = new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_StatusHistory
                {
                    ACC_IPL_InstallmentPlan_StatusHistoryID = Guid.NewGuid(),
                    ACC_IPL_InstallmentPlan_RefID = installmentPlan.ACC_IPL_InstallmentPlanID,
                    ACC_IPL_InstallmentPlan_Status_RefID = statusID,
                    PerformedBy_BusinessParticipant_RefID = BusinessParticipantID,
                    StatusHistoryComment = Parameter.Comment,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                statusHistory.Save(Connection, Transaction);

                installmentPlan.Current_InstallmentPlanStatus_RefID = statusID;

                #endregion
            }
            else
            {
                #region Load existing InstallmentPlan

                var fetched = installmentPlan.Load(Connection, Transaction, Parameter.InstallmentPlanID);
                if (fetched.Status != FR_Status.Success || installmentPlan.ACC_IPL_InstallmentPlanID != Parameter.InstallmentPlanID)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    return returnValue;
                }

                #endregion
            }

            installmentPlan.NominalValue = Parameter.NominalValue;

            installmentPlan.Save(Connection, Transaction);

            #region Save Installments

            CL1_ACC_IPL.ORM_ACC_IPL_Installment installment = null;
            foreach (var item in Parameter.Installments)
            {
                if (item.InstallmentID == Guid.Empty)
                {
                    installment = new CL1_ACC_IPL.ORM_ACC_IPL_Installment
                    {
                        ACC_IPL_InstallmentID = Guid.NewGuid(),
                        InstallmentPlan_RefID = installmentPlan.ACC_IPL_InstallmentPlanID,
                        IsFullyPaid = false,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID
                    };
                }
                else
                {
                    installment = new CL1_ACC_IPL.ORM_ACC_IPL_Installment();
                    var fetched = installment.Load(Connection, Transaction, item.InstallmentID);
                    if (fetched.Status != FR_Status.Success || installment.ACC_IPL_InstallmentID != item.InstallmentID)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        return returnValue;
                    }
                }

                installment.PaymentDeadline = item.PaymentDeadline;
                installment.Amount = item.Amount;

                installment.Save(Connection, Transaction);
            }

            #endregion

            returnValue.Result = installmentPlan.ACC_IPL_InstallmentPlanID;
            return returnValue;

            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3IP_SIP_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3IP_SIP_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3IP_SIP_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3IP_SIP_1718 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_InstallmentPlan",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3IP_SIP_1718 for attribute P_L3IP_SIP_1718
		[DataContract]
		public class P_L3IP_SIP_1718 
		{
			[DataMember]
			public P_L3IP_SIP_1718a[] Installments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid InstallmentPlanID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Decimal NominalValue { get; set; } 
			[DataMember]
			public String Comment { get; set; } 

		}
		#endregion
		#region SClass P_L3IP_SIP_1718a for attribute Installments
		[DataContract]
		public class P_L3IP_SIP_1718a 
		{
			//Standard type parameters
			[DataMember]
			public Guid InstallmentID { get; set; } 
			[DataMember]
			public Decimal Amount { get; set; } 
			[DataMember]
			public DateTime PaymentDeadline { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_InstallmentPlan(,P_L3IP_SIP_1718 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_InstallmentPlan.Invoke(connectionString,P_L3IP_SIP_1718 Parameter,securityTicket);
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
var parameter = new CL3_InstallmentPlans.Complex.Manipulation.P_L3IP_SIP_1718();
parameter.Installments = ...;

parameter.InstallmentPlanID = ...;
parameter.IsDeleted = ...;
parameter.NominalValue = ...;
parameter.Comment = ...;

*/
