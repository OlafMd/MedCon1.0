/* 
 * Generated on 2/4/2014 12:59:06 PM
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

namespace CL5_APOWebShop_ShoppingCart.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TenantsTimes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TenantsTimes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AWSSC_GTT_1430_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSSC_GTT_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5AWSSC_GTT_1430_Array();

            List<L5AWSSC_GTT_1430> list = new List<L5AWSSC_GTT_1430>();

            var tenantQuery = new CL1_CMN.ORM_CMN_Tenant_ApplicationSubscription.Query();
            tenantQuery.IsDeleted = false;
            tenantQuery.Application_RefID = Parameter.ApplicationID;

            var tenants = CL1_CMN.ORM_CMN_Tenant_ApplicationSubscription.Query.Search(Connection, Transaction, tenantQuery).Select(i => i.Tenant_RefID).ToList();

            list.AddRange(tenants.Select(x => new L5AWSSC_GTT_1430() { TenantID = x, JobTime = Parameter.DefaultCronTime }));

            returnValue.Result = list.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AWSSC_GTT_1430_Array Invoke(string ConnectionString,P_L5AWSSC_GTT_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GTT_1430_Array Invoke(DbConnection Connection,P_L5AWSSC_GTT_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AWSSC_GTT_1430_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSSC_GTT_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AWSSC_GTT_1430_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSSC_GTT_1430 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AWSSC_GTT_1430_Array functionReturn = new FR_L5AWSSC_GTT_1430_Array();
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

				throw new Exception("Exception occured in method cls_Get_TenantsTimes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AWSSC_GTT_1430_Array : FR_Base
	{
		public L5AWSSC_GTT_1430[] Result	{ get; set; } 
		public FR_L5AWSSC_GTT_1430_Array() : base() {}

		public FR_L5AWSSC_GTT_1430_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AWSSC_GTT_1430 for attribute P_L5AWSSC_GTT_1430
		[DataContract]
		public class P_L5AWSSC_GTT_1430 
		{
			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 
			[DataMember]
			public String DefaultCronTime { get; set; } 

		}
		#endregion
		#region SClass L5AWSSC_GTT_1430 for attribute L5AWSSC_GTT_1430
		[DataContract]
		public class L5AWSSC_GTT_1430 
		{
			//Standard type parameters
			[DataMember]
			public String JobTime { get; set; } 
			[DataMember]
			public Guid TenantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AWSSC_GTT_1430_Array cls_Get_TenantsTimes(,P_L5AWSSC_GTT_1430 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AWSSC_GTT_1430_Array invocationResult = cls_Get_TenantsTimes.Invoke(connectionString,P_L5AWSSC_GTT_1430 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Retrieval.P_L5AWSSC_GTT_1430();
parameter.ApplicationID = ...;
parameter.DefaultCronTime = ...;

*/
