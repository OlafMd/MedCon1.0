/* 
 * Generated on 8/30/2013 11:31:24 AM
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
using CL2_ApplicationSettings.Atomic.Manipulation;
using PlannicoModel.Models;

namespace CL6_VacationPlanner_User.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Application_Settings_ForTenant_FirstTime.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Application_Settings_ForTenant_FirstTime
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L6USR_SASFTFT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Base();

            P_L2USR_SASD_1034 appSettingsParam = new P_L2USR_SASD_1034();
            appSettingsParam.ApplicationID = Parameter.ApplicationID;

            appSettingsParam.ItemKey = "plannico.tutorial.finished.company-data";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannico.tutorial.finished.cost-centers";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannico.tutorial.finished.company-structure";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannico.tutorial.finished.leave-types";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannico.tutorial.finished.calculations";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannico.tutorial.finished.staff";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannico.tutorial.finished.event-types";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannico.tutorial.finished.events-and-holidays";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannicoTime.planingDayList.ddlLocationFilter";
            appSettingsParam.DefaultValue = String.Empty;
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannicoTime.planingDayList.ddlOrderBy";
            appSettingsParam.DefaultValue = String.Empty;
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannicoTime.planingDayList.rememberState";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannicoTime.companyData.IsUsingSimpleProjectStructure";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            appSettingsParam.ItemKey = "plannicoTime.companyData.IsUsingComplexProjectStructure";
            appSettingsParam.DefaultValue = "false";
            cls_Save_USR_Account_ApplicationSetting_Definition.Invoke(Connection, Transaction, appSettingsParam, securityTicket);

            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L6USR_SASFTFT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L6USR_SASFTFT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L6USR_SASFTFT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6USR_SASFTFT_1637 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Save_Application_Settings_ForTenant_FirstTime",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
	

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_Application_Settings_ForTenant_FirstTime(,P_L6USR_SASFTFT_1637 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_Application_Settings_ForTenant_FirstTime.Invoke(connectionString,P_L6USR_SASFTFT_1637 Parameter,securityTicket);
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
var parameter = new CL6_VacationPlanner_User.Complex.Manipulation.P_L6USR_SASFTFT_1637();
parameter.ApplicationID = ...;

*/