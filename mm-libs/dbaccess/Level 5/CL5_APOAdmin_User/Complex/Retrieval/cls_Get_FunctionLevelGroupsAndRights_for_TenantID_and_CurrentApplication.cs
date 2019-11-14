/* 
 * Generated on 12/9/2013 4:48:09 PM
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
using DLCore_DBCommons.Utils;
using CL5_APOAdmin_User.Atomic.Retrieval;
using DLCore_DBCommons.APODemand;

namespace CL5_APOAdmin_User.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FunctionLevelGroupsAndRights_for_TenantID_and_CurrentApplication.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FunctionLevelGroupsAndRights_for_TenantID_and_CurrentApplication
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GFLGaRfTaCA_1657 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5US_GFLGaRfTaCA_1657();
            returnValue.Result = new L5US_GFLGaRfTaCA_1657();

            var FunctionLevelRightGroups = EnumUtils.GetAllEnumDescriptions<EAccountFunctionLevelRightGroup>();

            var result = cls_Get_FunctionLevelGroupsAndRights_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            //filter results by EAccountFunctionLevelRightGroup
            result = result.Where(i => FunctionLevelRightGroups.Contains(i.Groups_GlobalPropertyMatchingID)).ToArray();

            returnValue.Result.GroupRights = result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5US_GFLGaRfTaCA_1657 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GFLGaRfTaCA_1657 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GFLGaRfTaCA_1657 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GFLGaRfTaCA_1657 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GFLGaRfTaCA_1657 functionReturn = new FR_L5US_GFLGaRfTaCA_1657();
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

				throw new Exception("Exception occured in method cls_Get_FunctionLevelGroupsAndRights_for_TenantID_and_CurrentApplication",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GFLGaRfTaCA_1657 : FR_Base
	{
		public L5US_GFLGaRfTaCA_1657 Result	{ get; set; }

		public FR_L5US_GFLGaRfTaCA_1657() : base() {}

		public FR_L5US_GFLGaRfTaCA_1657(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5US_GFLGaRfTaCA_1657 for attribute L5US_GFLGaRfTaCA_1657
		[DataContract]
		public class L5US_GFLGaRfTaCA_1657 
		{
			//Standard type parameters
			[DataMember]
			public L5US_GFLGaRfT_1432[] GroupRights { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GFLGaRfTaCA_1657 cls_Get_FunctionLevelGroupsAndRights_for_TenantID_and_CurrentApplication(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GFLGaRfTaCA_1657 invocationResult = cls_Get_FunctionLevelGroupsAndRights_for_TenantID_and_CurrentApplication.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

