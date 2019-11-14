/* 
 * Generated on 3/7/2014 1:04:35 PM
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
using CL2_AccountingPayment.Atomic.Retrieval;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;

namespace CL5_APOBilling_Bill.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadingData_for_BillCreation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadingData_for_BillCreation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GPDfB_1119 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BL_GPDfB_1119();
            returnValue.Result = new L5BL_GPDfB_1119();
			//Put your code here
            returnValue.Result.PaymentTypes = CL2_AccountingPayment.Atomic.Retrieval.cls_Get_AllPaymentTypes_For_TenandID.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.PaymentDeadlines = CL2_AccountingPayment.Atomic.Retrieval.cls_Get_AllPaymentDeadlines_For_TenandID.Invoke(Connection, Transaction, securityTicket).Result;
		    
            var account = new CL1_USR.ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            var incrNumberParam = new P_L2NR_GINfUA_1113()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.BillNumber)
            };
            var billNumber = cls_Get_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

            returnValue.Result.BillNumber = billNumber;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BL_GPDfB_1119 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GPDfB_1119 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GPDfB_1119 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GPDfB_1119 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GPDfB_1119 functionReturn = new FR_L5BL_GPDfB_1119();
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

				throw new Exception("Exception occured in method cls_Get_PreloadingData_for_BillCreation",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GPDfB_1119 : FR_Base
	{
		public L5BL_GPDfB_1119 Result	{ get; set; }

		public FR_L5BL_GPDfB_1119() : base() {}

		public FR_L5BL_GPDfB_1119(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5BL_GPDfB_1119 for attribute L5BL_GPDfB_1119
		[DataContract]
		public class L5BL_GPDfB_1119 
		{
			//Standard type parameters
			[DataMember]
			public L2_AP_GAPTfT_1156[] PaymentTypes { get; set; } 
			[DataMember]
			public L2_AP_GAPDfT_1605[] PaymentDeadlines { get; set; } 
			[DataMember]
			public String BillNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GPDfB_1119 cls_Get_PreloadingData_for_BillCreation(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GPDfB_1119 invocationResult = cls_Get_PreloadingData_for_BillCreation.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

