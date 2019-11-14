/* 
 * Generated on 10/14/2014 10:55:03 AM
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
using CL1_USR;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.DanuTask;

namespace CL6_DanuTask_User.Complex.Retrieval
{
	/// <summary>
    /// Get user account running times
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_UserRunningTimes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_UserRunningTimes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GURT_1054 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6US_GURT_1054();
			//Put your code here
            returnValue.Result = new L6US_GURT_1054();
            ORM_USR_Account_ApplicationSetting.Query ApplicationSettingsQuery = new ORM_USR_Account_ApplicationSetting.Query();
            ApplicationSettingsQuery.Account_RefID = securityTicket.AccountID;
            ApplicationSettingsQuery.Tenant_RefID = securityTicket.TenantID;
            ApplicationSettingsQuery.ItemValue = EnumUtils.GetEnumDescription(RunningTimes.Item_Key);
            if(ORM_USR_Account_ApplicationSetting.Query.Exists(Connection, Transaction, ApplicationSettingsQuery)){
                Guid DefinitionID = ORM_USR_Account_ApplicationSetting.Query.Search(Connection, Transaction, ApplicationSettingsQuery).FirstOrDefault().ApplicationSetting_Definition_RefID;
                ORM_USR_Account_ApplicationSetting_Definition ApplicationDefinition = new ORM_USR_Account_ApplicationSetting_Definition();
                ApplicationDefinition.Load(Connection, Transaction, DefinitionID);
                returnValue.Result.UserRunningTimesXML = ApplicationDefinition.DefaultValue;
            }           
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6US_GURT_1054 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GURT_1054 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GURT_1054 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GURT_1054 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GURT_1054 functionReturn = new FR_L6US_GURT_1054();
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

				throw new Exception("Exception occured in method cls_Get_UserRunningTimes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GURT_1054 : FR_Base
	{
		public L6US_GURT_1054 Result	{ get; set; }

		public FR_L6US_GURT_1054() : base() {}

		public FR_L6US_GURT_1054(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6US_GURT_1054 for attribute L6US_GURT_1054
		[DataContract]
		public class L6US_GURT_1054 
		{
			//Standard type parameters
			[DataMember]
			public String UserRunningTimesXML { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GURT_1054 cls_Get_UserRunningTimes(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GURT_1054 invocationResult = cls_Get_UserRunningTimes.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

