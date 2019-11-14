/* 
 * Generated on 5/29/2014 4:59:24 PM
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
using CL1_ACC_DUN;
using CL5_APOBilling_Dunning.Complex.Retrieval;

namespace CL5_APOBilling_Dunning.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DunningProcessLevelChange.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DunningProcessLevelChange
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_SDPLC_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
                       
            var details = Parameter.BillHeaderWithDetails.DunningDetails;
            var bill = Parameter.BillHeaderWithDetails.Bill;

            //model
            var model = new ORM_ACC_DUN_Dunning_Model();
            model.Load(Connection, Transaction, details.ACC_DUN_Dunning_ModelID);

            var modelToLevelsAssignmentQuery = new ORM_ACC_DUN_DunningLevel_ModelAssignment.Query();
            modelToLevelsAssignmentQuery.Dunning_Model_RefID = model.ACC_DUN_Dunning_ModelID;
            modelToLevelsAssignmentQuery.Dunning_Level_RefID = Parameter.NextLevelID;
            modelToLevelsAssignmentQuery.Tenant_RefID = securityTicket.TenantID;
            var foundModelToLevelsAssignment = ORM_ACC_DUN_DunningLevel_ModelAssignment.Query.Search(Connection, Transaction, modelToLevelsAssignmentQuery).Single();

            //dunning process loading
            var dunningProcess = new ORM_ACC_DUN_DunningProcess();
            dunningProcess.Load(Connection, Transaction, details.ACC_DUN_DunningProcessID);
            dunningProcess.Current_DunningLevel_RefID = Parameter.NextLevelID;
            dunningProcess.ReachesNextDunningLevelAtDate = DateTime.Now.AddDays(foundModelToLevelsAssignment.WaitPeriodToNextDunningLevel_In_Days);
            dunningProcess.Save(Connection, Transaction);

            //get all previous history statuses
            var historyQuery = new ORM_ACC_DUN_DunningProcess_History.Query();
            historyQuery.ACC_DUN_DunningProcess_RefID = dunningProcess.ACC_DUN_DunningProcessID;
            historyQuery.Tenant_RefID = securityTicket.TenantID;
            var foundHistories = ORM_ACC_DUN_DunningProcess_History.Query.Search(Connection, Transaction, historyQuery).ToList();
            
            decimal summOfFees = 0;

            //and set their IsCurrentStep property
            foreach (var history in foundHistories)
            {
                history.IsCurrentStep = false;
                history.Save(Connection, Transaction);

                //while iterating, create summ of all fees in histories for dunning process
                if (history.IsSentToCustomer)
                {                    
                    summOfFees += history.DunningProcessFee_IncludingThisDunningLevel;
                }
            }

            var newHistoryEntity = new ORM_ACC_DUN_DunningProcess_History();
            newHistoryEntity.ACC_DUN_Dunning_Level_RefID = Parameter.NextLevelID;
            newHistoryEntity.ACC_DUN_DunningProcess_RefID = dunningProcess.ACC_DUN_DunningProcessID;
            newHistoryEntity.DunningProcessFee_IncludingThisDunningLevel = Parameter.FeeForLevel;
            newHistoryEntity.IsCurrentStep = true;
            newHistoryEntity.Tenant_RefID = securityTicket.TenantID;

            var savedNewHistoryID = new FR_Guid(newHistoryEntity.Save(Connection, Transaction), newHistoryEntity.ACC_DUN_DunningProcess_HistoryID).Result;

            var memberBills = new ORM_ACC_DUN_DunningProcess_MemberBill();
            memberBills.Load(Connection, Transaction, details.ACC_DUN_DunningProcess_MemberBillID);
            memberBills.ApplicableProcessDunningFees = summOfFees + newHistoryEntity.DunningProcessFee_IncludingThisDunningLevel; //added fee from new history also

            #region Save booking line for dunning fee

            var bookingParam = new CL3_Payments.Complex.Manipulation.P_L3PY_CATfDF_0849
            {
                DunningFee = Parameter.FeeForLevel,
                BillHeaderID = Parameter.BillHeaderWithDetails.Bill.BIL_BillHeaderID
            };
            CL3_Payments.Complex.Manipulation.cls_Create_AccountingTransaction_for_Dunning_Fee.Invoke(Connection, Transaction, bookingParam, securityTicket);

            #endregion

            returnValue.Result = savedNewHistoryID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BD_SDPLC_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BD_SDPLC_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_SDPLC_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_SDPLC_1642 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DunningProcessLevelChange",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BD_SDPLC_1642 for attribute P_L5BD_SDPLC_1642
		[DataContract]
		public class P_L5BD_SDPLC_1642 
		{
			//Standard type parameters
			[DataMember]
			public L5BD_GBwDDfTID_1017 BillHeaderWithDetails { get; set; } 
			[DataMember]
			public Guid NextLevelID { get; set; } 
			[DataMember]
			public decimal FeeForLevel { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DunningProcessLevelChange(,P_L5BD_SDPLC_1642 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DunningProcessLevelChange.Invoke(connectionString,P_L5BD_SDPLC_1642 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Dunning.Complex.Manipulation.P_L5BD_SDPLC_1642();
parameter.BillHeaderWithDetails = ...;
parameter.NextLevelID = ...;
parameter.FeeForLevel = ...;

*/
