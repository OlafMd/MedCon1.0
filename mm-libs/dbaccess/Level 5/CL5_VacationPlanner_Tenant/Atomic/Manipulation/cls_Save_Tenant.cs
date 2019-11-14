/* 
 * Generated on 2/21/2014 10:15:46 AM
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
using CL1_CMN;
using CL1_CMN_BPT_STA;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TN_ST_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
			var returnValue = new FR_Guid();
			//Put your code here


			
			ORM_CMN_BPT_STA_SettingProfile profile = new ORM_CMN_BPT_STA_SettingProfile();
			if (Parameter.CMN_BPT_STA_SettingProfileID != Guid.Empty)
			{
				var result = profile.Load(Connection, Transaction, Parameter.CMN_BPT_STA_SettingProfileID);
				if (result.Status != FR_Status.Success || profile.CMN_BPT_STA_SettingProfileID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
					return error;
				}
			}
			profile.IsLeaveTimeCalculated_InDays = Parameter.IsLeaveTimeCalculated_InDays;
			profile.IsLeaveTimeCalculated_InHours = Parameter.IsLeaveTimeCalculated_InHours;
			profile.StafMember_Caption = Parameter.StafMember_Caption;
            profile.Default_SurchargeCalculation_UseAccumulated = Parameter.Default_SurchargeCalculation_UseAccumulated;
            profile.Default_SurchargeCalculation_UseMaximum = Parameter.Default_SurchargeCalculation_UseMaximum;
			profile.Save(Connection, Transaction);

			ORM_CMN_Tenant item = new ORM_CMN_Tenant();

			var result2 = item.Load(Connection, Transaction, securityTicket.TenantID);
			if (result2.Status != FR_Status.Success || item.CMN_TenantID == Guid.Empty)
			{
				item.CMN_TenantID = securityTicket.TenantID;
			}
			item.IsUsing_WorkAreas = Parameter.IsUsing_Offices;
			item.IsUsing_WorkAreas = Parameter.IsUsing_WorkAreas;
			item.IsUsing_Workplaces = Parameter.IsUsing_Workplaces;


			item.Save(Connection, Transaction);

			returnValue.Result = item.CMN_TenantID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TN_ST_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TN_ST_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TN_ST_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TN_ST_1139 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
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
FR_Guid cls_Save_Tenant(P_L5TN_ST_1139 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Tenant.Invoke(connectionString,P_L5TN_ST_1139 Parameter,securityTicket);
	 return result;
}
*/