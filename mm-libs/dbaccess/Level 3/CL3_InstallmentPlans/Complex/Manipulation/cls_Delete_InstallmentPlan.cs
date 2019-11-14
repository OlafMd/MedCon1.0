/* 
 * Generated on 5/7/2014 11:45:25 AM
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

namespace CL3_InstallmentPlans.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_InstallmentPlan.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_InstallmentPlan
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3IP_DIP_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_StatusHistory.Query.SoftDelete(Connection, Transaction,
                new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan_StatusHistory.Query
                {
                    ACC_IPL_InstallmentPlan_RefID = Parameter.InstallmentPlanID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

            CL1_ACC_IPL.ORM_ACC_IPL_Installment.Query.SoftDelete(Connection, Transaction,
                new CL1_ACC_IPL.ORM_ACC_IPL_Installment.Query
                {
                    InstallmentPlan_RefID = Parameter.InstallmentPlanID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

            CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan.Query.SoftDelete(Connection, Transaction,
               new CL1_ACC_IPL.ORM_ACC_IPL_InstallmentPlan.Query
               {
                   ACC_IPL_InstallmentPlanID = Parameter.InstallmentPlanID,
                   IsDeleted = false,
                   Tenant_RefID = securityTicket.TenantID
               });

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3IP_DIP_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3IP_DIP_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3IP_DIP_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3IP_DIP_1144 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_InstallmentPlan",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3IP_DIP_1144 for attribute P_L3IP_DIP_1144
		[DataContract]
		public class P_L3IP_DIP_1144 
		{
			//Standard type parameters
			[DataMember]
			public Guid InstallmentPlanID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_InstallmentPlan(,P_L3IP_DIP_1144 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_InstallmentPlan.Invoke(connectionString,P_L3IP_DIP_1144 Parameter,securityTicket);
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
var parameter = new CL3_InstallmentPlans.Complex.Manipulation.P_L3IP_DIP_1144();
parameter.InstallmentPlanID = ...;

*/
