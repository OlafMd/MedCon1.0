/* 
 * Generated on 21.02.2014 18:00:09
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
using CL1_CMN_TRL;

namespace CL2_TrustRelation.Atomic.Retrieval
{
	/// <summary>
    /// 
      
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TenantConnectionCodes_for_TenantCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TenantConnectionCodes_for_TenantCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2TR_GTCCfTC_1749 Execute(DbConnection Connection,DbTransaction Transaction,P_L2TR_GTCCfTC_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L2TR_GTCCfTC_1749();

            var ownRequests = ORM_CMN_TRL_IntroductionRequest.Query.Search(Connection, Transaction, new ORM_CMN_TRL_IntroductionRequest.Query()
            {
                IsApproved = true,
                IsRejected = false,
                IsPermanentlyRejected = false,
                RequestingTenantCode = Parameter.TenantCode
            }).ToList();
            var otherRequest = ORM_CMN_TRL_IntroductionRequest.Query.Search(Connection, Transaction, new ORM_CMN_TRL_IntroductionRequest.Query()
            {
                IsApproved = true,
                IsRejected = false,
                IsPermanentlyRejected = false,
                RequestedForTenantCode = Parameter.TenantCode
            }).ToList();

            ownRequests.AddRange(otherRequest);
            ownRequests = ownRequests.OrderByDescending(r => r.Creation_Timestamp).ToList();

            var codes = new List<string>();
            foreach (var request in ownRequests)
                codes.Add(request.RequestedForTenantCode);

            returnValue.Result = new L2TR_GTCCfTC_1749() { TenantCodes = codes.ToArray() };
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2TR_GTCCfTC_1749 Invoke(string ConnectionString,P_L2TR_GTCCfTC_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2TR_GTCCfTC_1749 Invoke(DbConnection Connection,P_L2TR_GTCCfTC_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2TR_GTCCfTC_1749 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2TR_GTCCfTC_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2TR_GTCCfTC_1749 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2TR_GTCCfTC_1749 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2TR_GTCCfTC_1749 functionReturn = new FR_L2TR_GTCCfTC_1749();
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

				throw new Exception("Exception occured in method cls_Get_TenantConnectionCodes_for_TenantCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2TR_GTCCfTC_1749 : FR_Base
	{
		public L2TR_GTCCfTC_1749 Result	{ get; set; }

		public FR_L2TR_GTCCfTC_1749() : base() {}

		public FR_L2TR_GTCCfTC_1749(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2TR_GTCCfTC_1749 for attribute P_L2TR_GTCCfTC_1749
		[DataContract]
		public class P_L2TR_GTCCfTC_1749 
		{
			//Standard type parameters
			[DataMember]
			public string TenantCode { get; set; } 

		}
		#endregion
		#region SClass L2TR_GTCCfTC_1749 for attribute L2TR_GTCCfTC_1749
		[DataContract]
		public class L2TR_GTCCfTC_1749 
		{
			//Standard type parameters
			[DataMember]
			public string[] TenantCodes { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2TR_GTCCfTC_1749 cls_Get_TenantConnectionCodes_for_TenantCode(,P_L2TR_GTCCfTC_1749 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2TR_GTCCfTC_1749 invocationResult = cls_Get_TenantConnectionCodes_for_TenantCode.Invoke(connectionString,P_L2TR_GTCCfTC_1749 Parameter,securityTicket);
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
var parameter = new CL2_TrustRelation.Atomic.Retrieval.P_L2TR_GTCCfTC_1749();
parameter.TenantCode = ...;

*/
