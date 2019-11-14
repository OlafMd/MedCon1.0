/* 
 * Generated on 7/18/2014 3:11:25 PM
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
using System.Runtime.Serialization;
using CL1_ACC_DUN;
using CL1_BIL;
using CL1_CMN_BPT_CTM;
using CL2_BillDunning.Atomic.Manipulation;

namespace CL5_APOBilling_Dunning.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CreateDunningProcess.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CreateDunningProcess
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_SCDP_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            var savedProcesses = new List<Guid>();

            foreach (var billHeaderID in Parameter.BIL_BillHeaderIDs.ToList())
            {
                #region Prerequisites

                var billHeader = new ORM_BIL_BillHeader();
                billHeader.Load(Connection, Transaction, billHeaderID);

                //assigned payments
                var assignedPaymentsQuery = new ORM_BIL_BillHeader_AssignedPayment.Query();
                assignedPaymentsQuery.BIL_BillHeader_RefID = billHeader.BIL_BillHeaderID;
                assignedPaymentsQuery.Tenant_RefID = securityTicket.TenantID;
                var foundAssignmentPayments = ORM_BIL_BillHeader_AssignedPayment.Query.Search(Connection, Transaction, assignedPaymentsQuery);

                //calculated sum of payments to the present day
                var paymentsSummForCurrentDate = foundAssignmentPayments.Where(fap => fap.Creation_Timestamp <= DateTime.Now).Sum(x => x.AssignedValue);

                //customer
                var customerQuery = new ORM_CMN_BPT_CTM_Customer.Query();
                customerQuery.Tenant_RefID = securityTicket.TenantID;
                customerQuery.Ext_BusinessParticipant_RefID = billHeader.BillRecipient_BuisnessParticipant_RefID;
                var foundCustomer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQuery).Single();

                //Model
                ORM_ACC_DUN_Dunning_Model.Query defaultDunningModelQuery = new ORM_ACC_DUN_Dunning_Model.Query();
                defaultDunningModelQuery.Tenant_RefID = securityTicket.TenantID;
                defaultDunningModelQuery.IsDefaultCustomerModel = true;
                var foundDunningModel = ORM_ACC_DUN_Dunning_Model.Query.Search(Connection, Transaction, defaultDunningModelQuery).SingleOrDefault();

                //Assignment to levels
                var modelToLevelsAssignmentQuery = new ORM_ACC_DUN_DunningLevel_ModelAssignment.Query();
                modelToLevelsAssignmentQuery.Dunning_Model_RefID = foundDunningModel.ACC_DUN_Dunning_ModelID;
                modelToLevelsAssignmentQuery.Tenant_RefID = securityTicket.TenantID;
                var foundModelToLevelsAssignments = ORM_ACC_DUN_DunningLevel_ModelAssignment.Query.Search(Connection, Transaction, modelToLevelsAssignmentQuery);

                var minimalLevelInSequence = foundModelToLevelsAssignments.OrderBy(la => la.OrderSequence).First();
                


                //Levels
                var dunningLevels = new ORM_ACC_DUN_Dunning_Level();
                //dunningLevels.Load(Connection, Transaction, foundModelToLevelsAssignment.Dunning_Level_RefID);
                
                #endregion

                //model to customer assignment
                var modelToCustomerAssignment = new ORM_ACC_DUN_Dunning_Model_2_Customer();
                modelToCustomerAssignment.Tenant_RefID = securityTicket.TenantID;
                modelToCustomerAssignment.ACC_DUN_DunningModel_RefID = foundDunningModel.ACC_DUN_Dunning_ModelID;
                modelToCustomerAssignment.CMN_BPT_CTM_Customer_RefID = foundCustomer.CMN_BPT_CTM_CustomerID;
                var savedModelToCustomerAssignmentID = new FR_Guid(modelToCustomerAssignment.Save(Connection, Transaction), modelToCustomerAssignment.AssignmentID);

                //dunning process
                P_L2BD_SADDP_1412 saveDunningProcessParameter = new P_L2BD_SADDP_1412();
                saveDunningProcessParameter.DunnedCustomer_RefID = foundCustomer.CMN_BPT_CTM_CustomerID;
                saveDunningProcessParameter.DunningModel_RefID = foundDunningModel.ACC_DUN_Dunning_ModelID;
                saveDunningProcessParameter.Current_DunningLevel_RefID = minimalLevelInSequence.Dunning_Level_RefID;
                saveDunningProcessParameter.DunnedAmount_Total = billHeader.TotalValue_BeforeTax - paymentsSummForCurrentDate;
                saveDunningProcessParameter.Currency_RefID = billHeader.Currency_RefID;
                saveDunningProcessParameter.ReachesNextDunningLevelAtDate = DateTime.Now.AddDays(minimalLevelInSequence.WaitPeriodToNextDunningLevel_In_Days);

                var savedDunningProcessID = cls_Save_ACC_DUN_DunningProcess.Invoke(Connection, Transaction, saveDunningProcessParameter, securityTicket).Result;

                //dunning process member bills
                P_L2BD_SADDPMB_1359 saveMemberBillsParameter = new P_L2BD_SADDPMB_1359();
                saveMemberBillsParameter.BIL_BillHeader_RefID = billHeaderID;
                saveMemberBillsParameter.ACC_DUN_DunningProcess_RefID = savedDunningProcessID;
                saveMemberBillsParameter.ApplicableProcessDunningFees = 0;
                saveMemberBillsParameter.CurrentUnpaidBillFraction = 0;

                var savedMemberBillID = cls_Save_ACC_DUN_DunningProcess_MemberBill.Invoke(Connection, Transaction, saveMemberBillsParameter, securityTicket).Result;
                savedProcesses.Add(savedMemberBillID);

                //dunning process history
                var dunningProcessHistory = new ORM_ACC_DUN_DunningProcess_History();
                dunningProcessHistory.ACC_DUN_Dunning_Level_RefID = minimalLevelInSequence.Dunning_Level_RefID;
                dunningProcessHistory.ACC_DUN_DunningProcess_RefID = savedDunningProcessID;
                dunningProcessHistory.Creation_Timestamp = DateTime.Now;
                dunningProcessHistory.DunningProcessFee_IncludingThisDunningLevel = 0;
                dunningProcessHistory.IsCurrentStep = true;
                dunningProcessHistory.Tenant_RefID = securityTicket.TenantID;

                var savedDunningProcessHistoryID = new FR_Guid(dunningProcessHistory.Save(Connection, Transaction), dunningProcessHistory.ACC_DUN_DunningProcess_HistoryID);
            }

            returnValue.Result = savedProcesses.ToArray();           

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5BD_SCDP_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5BD_SCDP_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_SCDP_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_SCDP_1347 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Save_CreateDunningProcess",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BD_SCDP_1347 for attribute P_L5BD_SCDP_1347
		[DataContract]
		public class P_L5BD_SCDP_1347 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] BIL_BillHeaderIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_CreateDunningProcess(,P_L5BD_SCDP_1347 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_CreateDunningProcess.Invoke(connectionString,P_L5BD_SCDP_1347 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Dunning.Complex.Manipulation.P_L5BD_SCDP_1347();
parameter.BIL_BillHeaderIDs = ...;

*/
