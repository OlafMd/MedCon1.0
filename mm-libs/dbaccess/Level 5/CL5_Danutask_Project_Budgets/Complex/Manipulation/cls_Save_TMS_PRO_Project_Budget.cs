/* 
 * Generated on 11/18/2013 3:57:19 PM
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

namespace CL5_Danutask_Project_Budgets.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TMS_PRO_Project_Budget.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TMS_PRO_Project_Budget
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PB_SPB_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_TMS_PRO.ORM_TMS_PRO_Project_Budget();
			if (Parameter.TMS_PRO_Project_BudgetID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.TMS_PRO_Project_BudgetID);
			    if (result.Status != FR_Status.Success || item.TMS_PRO_Project_BudgetID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.TMS_PRO_Project_BudgetID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.TMS_PRO_Project_BudgetID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Project_RefID = Parameter.Project_RefID;
			item.BudgetFor_Month = Parameter.BudgetFor_Month;
			item.BudgetFor_Year = Parameter.BudgetFor_Year;
			item.BudgetLimit_Amount = Parameter.BudgetLimit_Amount;
			item.UsedBudget_Amount = Parameter.UsedBudget_Amount;


			return new FR_Guid(item.Save(Connection, Transaction),item.TMS_PRO_Project_BudgetID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PB_SPB_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PB_SPB_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PB_SPB_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PB_SPB_1633 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TMS_PRO_Project_Budget",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PB_SPB_1633 for attribute P_L5PB_SPB_1633
		[DataContract]
		public class P_L5PB_SPB_1633 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_Project_BudgetID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public int BudgetFor_Month { get; set; } 
			[DataMember]
			public int BudgetFor_Year { get; set; } 
			[DataMember]
			public Decimal BudgetLimit_Amount { get; set; } 
			[DataMember]
			public Decimal UsedBudget_Amount { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TMS_PRO_Project_Budget(,P_L5PB_SPB_1633 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TMS_PRO_Project_Budget.Invoke(connectionString,P_L5PB_SPB_1633 Parameter,securityTicket);
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
var parameter = new CL5_Danutask_Project_Budgets.Complex.Manipulation.P_L5PB_SPB_1633();
parameter.TMS_PRO_Project_BudgetID = ...;
parameter.Project_RefID = ...;
parameter.BudgetFor_Month = ...;
parameter.BudgetFor_Year = ...;
parameter.BudgetLimit_Amount = ...;
parameter.UsedBudget_Amount = ...;
parameter.IsDeleted = ...;

*/
