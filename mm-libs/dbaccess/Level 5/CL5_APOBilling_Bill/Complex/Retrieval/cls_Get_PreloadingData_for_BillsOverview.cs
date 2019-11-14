/* 
 * Generated on 23.09.2014 17:48:01
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
using CL2_BillDunning.Atomic.Retrieval;
using CL2_AccountingPayment.Atomic.Retrieval;
using CL2_BillStatus.Atomic.Retrieval;

namespace CL5_APOBilling_Bill.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadingData_for_BillsOverview.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadingData_for_BillsOverview
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GPDfBO_1321 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5BL_GPDfBO_1321();
            returnValue.Result = new L5BL_GPDfBO_1321();
            //Put your code here
            returnValue.Result.PaymentTypes = cls_Get_AllPaymentTypes_For_TenandID.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.BillStatuses = cls_Get_BillStatus_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;
            returnValue.Result.NumberOfDefindDunningLevels = cls_Get_DuningLevel_with_ChildData_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Count();

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BL_GPDfBO_1321 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GPDfBO_1321 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GPDfBO_1321 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GPDfBO_1321 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GPDfBO_1321 functionReturn = new FR_L5BL_GPDfBO_1321();
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

				throw new Exception("Exception occured in method cls_Get_PreloadingData_for_BillsOverview",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GPDfBO_1321 : FR_Base
	{
		public L5BL_GPDfBO_1321 Result	{ get; set; }

		public FR_L5BL_GPDfBO_1321() : base() {}

		public FR_L5BL_GPDfBO_1321(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5BL_GPDfBO_1321 for attribute L5BL_GPDfBO_1321
		[DataContract]
		public class L5BL_GPDfBO_1321 
		{
			//Standard type parameters
			[DataMember]
			public L2_BS_GBSfT_1615[] BillStatuses { get; set; } 
			[DataMember]
			public L2_AP_GAPTfT_1156[] PaymentTypes { get; set; } 
			[DataMember]
			public int NumberOfDefindDunningLevels { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GPDfBO_1321 cls_Get_PreloadingData_for_BillsOverview(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GPDfBO_1321 invocationResult = cls_Get_PreloadingData_for_BillsOverview.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

