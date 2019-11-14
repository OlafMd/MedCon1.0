/* 
 * Generated on 10/21/2013 6:01:14 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_ACC_PAY;

namespace CL2_AccountingPayment.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Payment_Deadline.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Payment_Deadline
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2AP_SPD_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            var item = new CL1_ACC_PAY.ORM_ACC_PAY_Condition();
            if (Parameter.ACC_PAY_ConditionID != Guid.Empty) 
            { 
                var result = item.Load(Connection, Transaction, Parameter.ACC_PAY_ConditionID);
                if (result.Status != FR_Status.Success || item.ACC_PAY_ConditionID == Guid.Empty) 
                {
                    var error = new FR_Guid(); 
                    error.ErrorMessage = "No Such ID"; 
                    error.Status = FR_Status.Error_Internal; 
                    return error; 
                }
            } 
            if (Parameter.IsDelete == true) 
            {
                if (Parameter.ACC_PAY_ConditionID != Guid.Empty)
                {
                    var detailsQuery = new ORM_ACC_PAY_Condition_Detail.Query();
                    detailsQuery.IsDeleted = false;
                    detailsQuery.Conditions_RefID = Parameter.ACC_PAY_ConditionID;
                    ORM_ACC_PAY_Condition_Detail.Query.SoftDelete(Connection, Transaction, detailsQuery);
                }
                item.IsDeleted = true; 
                return new FR_Guid(item.Save(Connection, Transaction), item.ACC_PAY_ConditionID); 
            }
            if (Parameter.ACC_PAY_ConditionID == Guid.Empty) 
            { 
                item.ACC_PAY_ConditionID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID; 
            } 
            item.PaymentCondition_Name = Parameter.PaymentCondition_Name; 
            item.MaximumPaymentTreshold_InDays = Parameter.MaximumPaymentTreshold_InDays;
            return new FR_Guid(item.Save(Connection, Transaction),item.ACC_PAY_ConditionID);

            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2AP_SPD_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2AP_SPD_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AP_SPD_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AP_SPD_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Payment_Deadline",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2AP_SPD_1628 for attribute P_L2AP_SPD_1628
		[DataContract]
		public class P_L2AP_SPD_1628 
		{
			//Standard type parameters
			[DataMember]
			public Dict PaymentCondition_Name { get; set; } 
			[DataMember]
			public Guid ACC_PAY_ConditionID { get; set; } 
			[DataMember]
			public int MaximumPaymentTreshold_InDays { get; set; } 
			[DataMember]
			public bool IsDelete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Payment_Deadline(,P_L2AP_SPD_1628 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Payment_Deadline.Invoke(connectionString,P_L2AP_SPD_1628 Parameter,securityTicket);
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
var parameter = new CL2_AccountingPayment.Atomic.Manipulation.P_L2AP_SPD_1628();
parameter.PaymentCondition_Name = ...;
parameter.ACC_PAY_ConditionID = ...;
parameter.MaximumPaymentTreshold_InDays = ...;
parameter.IsDelete = ...;

*/
