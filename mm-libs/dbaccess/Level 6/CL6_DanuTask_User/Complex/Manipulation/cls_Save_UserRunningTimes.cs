/* 
 * Generated on 10/14/2014 10:14:23 AM
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
using DLCore_DBCommons.DanuTask;
using DLCore_DBCommons.Utils;

namespace CL6_DanuTask_User.Complex.Manipulation
{
	/// <summary>
    /// Save user account running times
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_UserRunningTimes.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_UserRunningTimes
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6US_SURT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            //Save usr_account_applicationsetting-definition

            ORM_USR_Account_ApplicationSetting_Definition SettingsDefinition = new ORM_USR_Account_ApplicationSetting_Definition();
            ORM_USR_Account_ApplicationSetting_Definition.Query ApplicationSettingsDefinitionQuery = new ORM_USR_Account_ApplicationSetting_Definition.Query();
            ApplicationSettingsDefinitionQuery.ApplicationID = STDL_ApplicationIdentification.ApplicationID;
            ApplicationSettingsDefinitionQuery.ItemKey = EnumUtils.GetEnumDescription(RunningTimes.Item_Key);
            ApplicationSettingsDefinitionQuery.Tenant_RefID = securityTicket.TenantID;
            ApplicationSettingsDefinitionQuery.IsDeleted = false;
            if (!ORM_USR_Account_ApplicationSetting_Definition.Query.Exists(Connection, Transaction, ApplicationSettingsDefinitionQuery))
            {
                SettingsDefinition.ApplicationID = STDL_ApplicationIdentification.ApplicationID;
                SettingsDefinition.DefaultValue = Parameter.RunningTimesXML;
                SettingsDefinition.ItemKey = EnumUtils.GetEnumDescription(RunningTimes.Item_Key);
                SettingsDefinition.Tenant_RefID = securityTicket.TenantID;
                SettingsDefinition.Save(Connection, Transaction);
            }
            else
            {
                SettingsDefinition = ORM_USR_Account_ApplicationSetting_Definition.Query.Search(Connection, Transaction, ApplicationSettingsDefinitionQuery).FirstOrDefault();
                SettingsDefinition.DefaultValue = Parameter.RunningTimesXML;
                SettingsDefinition.Save(Connection, Transaction);
            }


            ORM_USR_Account_ApplicationSetting ApplicationSettings = new ORM_USR_Account_ApplicationSetting();
            ORM_USR_Account_ApplicationSetting.Query ApplicationSettingsQuery = new ORM_USR_Account_ApplicationSetting.Query();
            ApplicationSettingsQuery.Account_RefID = securityTicket.AccountID;
            ApplicationSettingsQuery.ApplicationSetting_Definition_RefID = SettingsDefinition.USR_Account_ApplicationSetting_DefinitionID;
            if (!ORM_USR_Account_ApplicationSetting.Query.Exists(Connection, Transaction, ApplicationSettingsQuery))
            {
                ApplicationSettings.Account_RefID = securityTicket.AccountID;
                ApplicationSettings.ApplicationSetting_Definition_RefID = SettingsDefinition.USR_Account_ApplicationSetting_DefinitionID;
                ApplicationSettings.ItemValue = EnumUtils.GetEnumDescription(RunningTimes.Item_Key);
                ApplicationSettings.Tenant_RefID = securityTicket.TenantID;
                ApplicationSettings.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6US_SURT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6US_SURT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6US_SURT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6US_SURT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_UserRunningTimes",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6US_SURT_0947 for attribute P_L6US_SURT_0947
		[DataContract]
		public class P_L6US_SURT_0947 
		{
			//Standard type parameters
			[DataMember]
			public String RunningTimesXML { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_UserRunningTimes(,P_L6US_SURT_0947 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_UserRunningTimes.Invoke(connectionString,P_L6US_SURT_0947 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_User.Complex.Manipulation.P_L6US_SURT_0947();
parameter.RunningTimesXML = ...;

*/
