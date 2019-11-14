/* 
 * Generated on 8/26/2013 10:30:28 AM
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
using CL1_CMN;

namespace CL2_ApplicationSubscription.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_GetUserSubscriptionForApplicationAndUserID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_GetUserSubscriptionForApplicationAndUserID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2AS_GUSfACU_2051 Execute(DbConnection Connection,DbTransaction Transaction,P_L2AS_GUSfACU_2051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 

            var returnValue = new FR_L2AS_GUSfACU_2051();
            returnValue.Result = new L2AS_GUSfACU_2051();

            var hasSubscription = false;
            var isTenantSubscribed = false;

            #region ORM_CMN_Tenant_ApplicationSubscription

            var query1 = new ORM_CMN_Tenant_ApplicationSubscription.Query();
            query1.Application_RefID = Parameter.ApplicationID;
            query1.Tenant_RefID = securityTicket.TenantID;
            query1.IsDeleted = false;
            query1.IsDisabled = false;

            var subscription = ORM_CMN_Tenant_ApplicationSubscription.Query.Search(Connection, Transaction, query1);

            if (subscription.Count() == 0)
            {
                returnValue.Result.HasSubscription = false;
                returnValue.Result.IsTenantSubscribed = false;
                return returnValue;
            }
            isTenantSubscribed = true;
            #endregion

            #region ORM_CMN_Account_ApplicationSubscription

            var query2 = new ORM_CMN_Account_ApplicationSubscription.Query();
            query2.Application_RefID = subscription.First().Application_RefID;
            query2.Tenant_RefID = securityTicket.TenantID;
            query2.Account_RefID = Parameter.CurrentUserID;
            query2.IsDeleted = false;
            query2.IsDisabled = false;

            hasSubscription = ORM_CMN_Account_ApplicationSubscription.Query.Exists(Connection, Transaction, query2);
            returnValue.Result.HasSubscription = hasSubscription;
            returnValue.Result.IsTenantSubscribed = isTenantSubscribed;
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2AS_GUSfACU_2051 Invoke(string ConnectionString,P_L2AS_GUSfACU_2051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2AS_GUSfACU_2051 Invoke(DbConnection Connection,P_L2AS_GUSfACU_2051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2AS_GUSfACU_2051 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AS_GUSfACU_2051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2AS_GUSfACU_2051 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AS_GUSfACU_2051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2AS_GUSfACU_2051 functionReturn = new FR_L2AS_GUSfACU_2051();
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

				throw new Exception("Exception occured in method cls_GetUserSubscriptionForApplicationAndUserID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2AS_GUSfACU_2051 : FR_Base
	{
		public L2AS_GUSfACU_2051 Result	{ get; set; }

		public FR_L2AS_GUSfACU_2051() : base() {}

		public FR_L2AS_GUSfACU_2051(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2AS_GUSfACU_2051 for attribute P_L2AS_GUSfACU_2051
		[DataContract]
		public class P_L2AS_GUSfACU_2051 
		{
			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 
			[DataMember]
			public Guid CurrentUserID { get; set; } 

		}
		#endregion
		#region SClass L2AS_GUSfACU_2051 for attribute L2AS_GUSfACU_2051
		[DataContract]
		public class L2AS_GUSfACU_2051 
		{
			//Standard type parameters
			[DataMember]
			public bool HasSubscription { get; set; } 
			[DataMember]
			public bool IsTenantSubscribed { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2AS_GUSfACU_2051 cls_GetUserSubscriptionForApplicationAndUserID(,P_L2AS_GUSfACU_2051 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L2AS_GUSfACU_2051 invocationResult = cls_GetUserSubscriptionForApplicationAndUserID.Invoke(connectionString,P_L2AS_GUSfACU_2051 Parameter,securityTicket);
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
var parameter = new CL2_ApplicationSubscription.Complex.Retrieval.P_L2AS_GUSfACU_2051();
parameter.ApplicationID = ...;
parameter.CurrentUserID = ...;

*/