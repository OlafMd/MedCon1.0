/* 
 * Generated on 10/21/2013 3:23:52 PM
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
using System.Runtime.Serialization;

namespace CL2_AccountingPayment.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ACC_PAY_Condition_Detail.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ACC_PAY_Condition_Detail
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2AP_SCD_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new CL1_ACC_PAY.ORM_ACC_PAY_Condition_Detail();
			if (Parameter.ACC_PAY_Condition_DetailID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.ACC_PAY_Condition_DetailID);
			    if (result.Status != FR_Status.Success || item.ACC_PAY_Condition_DetailID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.ACC_PAY_Condition_DetailID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.ACC_PAY_Condition_DetailID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Conditions_RefID = Parameter.Conditions_RefID;
			item.DateInterval_From = Parameter.DateInterval_From;
			item.DateInterval_To = Parameter.DateInterval_To;
			item.DiscountPercentage = Parameter.DiscountPercentage;
			item.SequenceNumber = Parameter.SequenceNumber;


			return new FR_Guid(item.Save(Connection, Transaction),item.ACC_PAY_Condition_DetailID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2AP_SCD_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2AP_SCD_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AP_SCD_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AP_SCD_1521 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ACC_PAY_Condition_Detail",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2AP_SCD_1521 for attribute P_L2AP_SCD_1521
		[DataContract]
		public class P_L2AP_SCD_1521 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_PAY_Condition_DetailID { get; set; } 
			[DataMember]
			public Guid Conditions_RefID { get; set; } 
			[DataMember]
			public int DateInterval_From { get; set; } 
			[DataMember]
			public int DateInterval_To { get; set; } 
			[DataMember]
			public double DiscountPercentage { get; set; } 
			[DataMember]
			public int SequenceNumber { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ACC_PAY_Condition_Detail(,P_L2AP_SCD_1521 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ACC_PAY_Condition_Detail.Invoke(connectionString,P_L2AP_SCD_1521 Parameter,securityTicket);
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
var parameter = new CL2_AccountingPayment.Atomic.Manipulation.P_L2AP_SCD_1521();
parameter.ACC_PAY_Condition_DetailID = ...;
parameter.Conditions_RefID = ...;
parameter.DateInterval_From = ...;
parameter.DateInterval_To = ...;
parameter.DiscountPercentage = ...;
parameter.SequenceNumber = ...;
parameter.IsDeleted = ...;

*/
