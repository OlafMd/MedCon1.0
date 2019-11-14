/* 
 * Generated on 05-Nov-13 11:01:54
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
using CL1_CMN_BPT_STA;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_SettingProfile.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_SettingProfile
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TN_SSP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

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

            profile.Default_AdulthoodAge = Parameter.Default_AdulthoodAge;
            profile.Default_MaximumPostWork_Period_in_mins = Parameter.Default_MaximumPostWork_Period_in_mins;
            profile.Default_MaximumPreWork_Period_in_mins = Parameter.Default_MaximumPreWork_Period_in_mins;
            profile.Default_RestMinimumThresholdl_Adults_in_mins = Parameter.Default_RestMinimumThresholdl_Adults_in_mins;
            profile.Default_RestMinimumThresholdl_NonAdults_in_mins = Parameter.Default_RestMinimumThresholdl_NonAdults_in_mins;
            profile.Default_RestWarningThreshold_Adults_in_mins = Parameter.Default_RestWarningThreshold_Adults_in_mins;
            profile.Default_RestWarningThreshold_NonAdults_in_mins = Parameter.Default_RestWarningThreshold_NonAdults_in_mins;
            profile.Default_RoosterGridMinimumPlanningUnit_in_mins = Parameter.Default_RoosterGridMinimumPlanningUnit_in_mins;
            profile.Default_SurchargeCalculation_UseAccumulated = Parameter.Default_SurchargeCalculation_UseAccumulated;
            profile.Default_SurchargeCalculation_UseMaximum = Parameter.Default_SurchargeCalculation_UseMaximum;
            profile.Default_WorkdayStart_in_mins = Parameter.Default_WorkdayStart_in_mins;
            profile.Default_WorkEndTimeMaximum_NonAdults_in_mins = Parameter.Default_WorkEndTimeMaximum_NonAdults_in_mins;
            profile.Default_WorkEndTimeWarning_NonAdults_in_mins = Parameter.Default_WorkEndTimeWarning_NonAdults_in_mins;
            profile.Default_WorkStartTimeMinimum_NonAdults_in_mins = Parameter.Default_WorkStartTimeMinimum_NonAdults_in_mins;
            profile.Default_WorkStartTimeWarning_NonAdults_in_mins = Parameter.Default_WorkStartTimeWarning_NonAdults_in_mins;
            profile.Default_WorktimeBalancePeriod_in_months = Parameter.Default_WorktimeBalancePeriod_in_months;
            profile.Default_WorkTimeMaximumTreshold_Adults_in_mins = Parameter.Default_WorkTimeMaximumTreshold_Adults_in_mins;
            profile.Default_WorkTimeMaximumTreshold_NonAdults_in_mins = Parameter.Default_WorkTimeMaximumTreshold_NonAdults_in_mins;
            profile.Default_WorkTimeWarningTreshold_Adults_in_mins = Parameter.Default_WorkTimeWarningTreshold_Adults_in_mins;
            profile.Default_WorkTimeWarningTreshold_NonAdults_in_mins = Parameter.Default_WorkTimeWarningTreshold_NonAdults_in_mins;
            profile.IsLeaveTimeCalculated_InDays = Parameter.IsLeaveTimeCalculated_InDays;
            profile.IsLeaveTimeCalculated_InHours = Parameter.IsLeaveTimeCalculated_InHours;
            profile.IsUsingWorkflow_ForLeaveRequests = Parameter.IsUsingWorkflow_ForLeaveRequests;
            profile.Tenant_RefID = securityTicket.TenantID;

            profile.Save(Connection, Transaction);

            returnValue.Result = profile.CMN_BPT_STA_SettingProfileID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TN_SSP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TN_SSP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TN_SSP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TN_SSP_1723 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
