/* 
 * Generated on 7/8/2013 3:26:19 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using CSV2Core.Core;
using CL1_CMN;

namespace CL2_ApplicationSubscription.Complex.Retrieval
{
	[Serializable]
	public class cls_GetUserSubscriptionForApplication
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2AS_GUSfA_1609 Execute(DbConnection Connection,DbTransaction Transaction,P_L2AS_GUSfA_1609 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L2AS_GUSfA_1609();
            returnValue.Result = new L2AS_GUSfA_1609();

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
            query2.Account_RefID = securityTicket.AccountID;
            query2.IsDeleted = false;
            query2.IsDisabled = false;

            hasSubscription = ORM_CMN_Account_ApplicationSubscription.Query.Exists(Connection, Transaction, query2);
            returnValue.Result.HasSubscription = hasSubscription;
            returnValue.Result.IsTenantSubscribed = isTenantSubscribed;
            returnValue.Result.Configuration = subscription.FirstOrDefault().Configuration;

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2AS_GUSfA_1609 Invoke(string ConnectionString,P_L2AS_GUSfA_1609 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2AS_GUSfA_1609 Invoke(DbConnection Connection,P_L2AS_GUSfA_1609 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2AS_GUSfA_1609 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2AS_GUSfA_1609 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2AS_GUSfA_1609 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2AS_GUSfA_1609 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2AS_GUSfA_1609 functionReturn = new FR_L2AS_GUSfA_1609();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2AS_GUSfA_1609 : FR_Base
	{
		public L2AS_GUSfA_1609 Result	{ get; set; }

		public FR_L2AS_GUSfA_1609() : base() {}

		public FR_L2AS_GUSfA_1609(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2AS_GUSfA_1609 for attribute P_L2AS_GUSfA_1609
		[Serializable]
		public class P_L2AS_GUSfA_1609 
		{
			//Standard type parameters
			public Guid ApplicationID; 

		}
		#endregion
		#region SClass L2AS_GUSfA_1609 for attribute L2AS_GUSfA_1609
		[Serializable]
		public class L2AS_GUSfA_1609 
		{
			//Standard type parameters
			public bool HasSubscription; 
			public bool IsTenantSubscribed; 
			public String Configuration; 

		}
		#endregion

	#endregion
}
