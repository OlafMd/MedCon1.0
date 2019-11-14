/* 
 * Generated on 13-Nov-13 17:29:31
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
using CL1_CMN_BPT_STR;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Office.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Office_SettingsProfile.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Office_SettingsProfile
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_SOSP_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_BPT_STR_Office_SettingsProfile officeSettingsProfile = new ORM_CMN_BPT_STR_Office_SettingsProfile();
            if (Parameter.CMN_BPT_STR_Office_SettingsProfileID != Guid.Empty)
            {
                var result = officeSettingsProfile.Load(Connection, Transaction, Parameter.CMN_BPT_STR_Office_SettingsProfileID);
                if (result.Status != FR_Status.Success || officeSettingsProfile.CMN_BPT_STR_Office_SettingsProfileID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            officeSettingsProfile.AdulthoodAge = Parameter.AdulthoodAge;
            officeSettingsProfile.Office_RefID = Parameter.Office_RefID;
            officeSettingsProfile.RestMinimumThresholdl_Adults_in_mins = Parameter.RestMinimumThresholdl_Adults_in_mins;
            officeSettingsProfile.RestMinimumThresholdl_NonAdults_in_mins = Parameter.RestMinimumThresholdl_NonAdults_in_mins;
            officeSettingsProfile.RestWarningThreshold_Adults_in_mins = Parameter.RestWarningThreshold_Adults_in_mins;
            officeSettingsProfile.RestWarningThreshold_NonAdults_in_mins = Parameter.RestWarningThreshold_NonAdults_in_mins;
            officeSettingsProfile.WorkEndTimeMaximum_NonAdults_in_mins = Parameter.WorkEndTimeMaximum_NonAdults_in_mins;
            officeSettingsProfile.WorkEndTimeWarning_NonAdults_in_mins = Parameter.WorkEndTimeWarning_NonAdults_in_mins;
            officeSettingsProfile.WorkStartTimeMinimum_NonAdults_in_mins = Parameter.WorkStartTimeMinimum_NonAdults_in_mins;
            officeSettingsProfile.WorkStartTimeWarning_NonAdults_in_mins = Parameter.WorkStartTimeWarning_NonAdults_in_mins;
            officeSettingsProfile.WorktimeBalancePeriod_in_months = Parameter.WorktimeBalancePeriod_in_months;
            officeSettingsProfile.WorkTimeMaximumTreshold_Adults_in_mins = Parameter.WorkTimeMaximumTreshold_Adults_in_mins;
            officeSettingsProfile.WorkTimeMaximumTreshold_NonAdults_in_mins = Parameter.WorkTimeMaximumTreshold_NonAdults_in_mins;
            officeSettingsProfile.WorkTimeWarningTreshold_Adults_in_mins = Parameter.WorkTimeWarningTreshold_Adults_in_mins;
            officeSettingsProfile.WorkTimeWarningTreshold_NonAdults_in_mins = Parameter.WorkTimeWarningTreshold_NonAdults_in_mins;
            officeSettingsProfile.WorkdayStart_in_mins = Parameter.WorkdayStart_in_mins;
            officeSettingsProfile.MaximumPostWork_Period_in_mins = Parameter.MaximumPostWork_Period_in_mins;
            officeSettingsProfile.MaximumPreWork_Period_in_mins = Parameter.MaximumPreWork_Period_in_mins;
            officeSettingsProfile.RoosterGridMinimumPlanningUnit_in_mins = Parameter.RoosterGridMinimumPlanningUnit_in_mins;
            officeSettingsProfile.Tenant_RefID = securityTicket.TenantID;

            officeSettingsProfile.Save(Connection, Transaction);

            returnValue.Result = officeSettingsProfile.CMN_BPT_STR_Office_SettingsProfileID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OF_SOSP_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OF_SOSP_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_SOSP_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_SOSP_1102 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
