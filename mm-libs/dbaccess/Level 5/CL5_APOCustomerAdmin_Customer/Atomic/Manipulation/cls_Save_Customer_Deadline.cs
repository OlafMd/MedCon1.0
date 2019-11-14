/* 
 * Generated on 24.09.2014 11:05:02
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
using CL1_CMN_BPT;

namespace CL5_APOCustomerAdmin_Customer.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Customer_Deadline.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Customer_Deadline
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CACU_SCD_1439 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CACU_SCD_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5CACU_SCD_1439();
            returnValue.Result = new L5CACU_SCD_1439();
            //Put your code here
            var item = new ORM_CMN_BPT_Customer_PromisedDeliveryTime();
            if (Parameter.DeadlineID != Guid.Empty)
            {
                item.Load(Connection, Transaction, Parameter.DeadlineID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                item.Save(Connection, Transaction);

                returnValue.Result.OldCroneExpression = item.CRONExpression;
                returnValue.Result.IsDeleted = true;
                return returnValue;
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.DeadlineID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }
            var oldCroneExpression = item.CRONExpression;

            item.Customer_RefID = Parameter.CustomerID;
            item.CRONExpression = Parameter.CronFormatedDeadline;
            item.TimeToDelivery_in_min = Parameter.TimeToDeliveryInMin;
            item.Save(Connection, Transaction);

            if (oldCroneExpression == null)
                oldCroneExpression = String.Empty;
            returnValue.Result.OldCroneExpression = oldCroneExpression;
            returnValue.Result.NewCroneExpression = Parameter.CronFormatedDeadline;
            returnValue.Result.IsDeleted = false;

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CACU_SCD_1439 Invoke(string ConnectionString,P_L5CACU_SCD_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CACU_SCD_1439 Invoke(DbConnection Connection,P_L5CACU_SCD_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CACU_SCD_1439 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CACU_SCD_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CACU_SCD_1439 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CACU_SCD_1439 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CACU_SCD_1439 functionReturn = new FR_L5CACU_SCD_1439();
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

				throw new Exception("Exception occured in method cls_Save_Customer_Deadline",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CACU_SCD_1439 : FR_Base
	{
		public L5CACU_SCD_1439 Result	{ get; set; }

		public FR_L5CACU_SCD_1439() : base() {}

		public FR_L5CACU_SCD_1439(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CACU_SCD_1439 for attribute P_L5CACU_SCD_1439
		[DataContract]
		public class P_L5CACU_SCD_1439 
		{
			//Standard type parameters
			[DataMember]
			public String CronFormatedDeadline { get; set; } 
			[DataMember]
			public Guid CustomerID { get; set; } 
			[DataMember]
			public Guid DeadlineID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public float TimeToDeliveryInMin { get; set; } 

		}
		#endregion
		#region SClass L5CACU_SCD_1439 for attribute L5CACU_SCD_1439
		[DataContract]
		public class L5CACU_SCD_1439 
		{
			//Standard type parameters
			[DataMember]
			public String NewCroneExpression { get; set; } 
			[DataMember]
			public String OldCroneExpression { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CACU_SCD_1439 cls_Save_Customer_Deadline(,P_L5CACU_SCD_1439 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CACU_SCD_1439 invocationResult = cls_Save_Customer_Deadline.Invoke(connectionString,P_L5CACU_SCD_1439 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Customer.Atomic.Manipulation.P_L5CACU_SCD_1439();
parameter.CronFormatedDeadline = ...;
parameter.CustomerID = ...;
parameter.DeadlineID = ...;
parameter.LanguageID = ...;
parameter.IsDeleted = ...;
parameter.TimeToDeliveryInMin = ...;

*/
