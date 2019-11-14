/* 
 * Generated on 19-Feb-14 14:35:51
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
using CL1_CMN_BPT_STA;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL6_Plannico_CalculationSettings.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StructureSettings_For_Structure.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StructureSettings_For_Structure
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6CS_GSSFS_1354 Execute(DbConnection Connection,DbTransaction Transaction,P_L6CS_GSSFS_1354 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6CS_GSSFS_1354();
			//Put your code here

            L6CS_GSSFS_1354 result = new L6CS_GSSFS_1354();

            bool foundOfficeLevelSettings = false;
            bool foundWorkAreaLevelSettings = false;

            if (Parameter.WorkAreaID != Guid.Empty)
            {
                ORM_CMN_BPT_STR_Workarea_SettingsProfile.Query workAreaSettingsProfileQuery = new ORM_CMN_BPT_STR_Workarea_SettingsProfile.Query();
                workAreaSettingsProfileQuery.Workarea_RefID = Parameter.WorkAreaID;
                workAreaSettingsProfileQuery.IsDeleted = false;
                workAreaSettingsProfileQuery.Tenant_RefID = securityTicket.TenantID;

                ORM_CMN_BPT_STR_Workarea_SettingsProfile workAreaSettingsProfile = ORM_CMN_BPT_STR_Workarea_SettingsProfile.Query.Search(Connection, Transaction, workAreaSettingsProfileQuery).FirstOrDefault();
                if (workAreaSettingsProfile != null)
                {
                    foundWorkAreaLevelSettings = true;
                    result.RoosterGridMinimumPlanningUnit_in_mins = workAreaSettingsProfile.RoosterGridMinimumPlanningUnit_in_mins;
                    result.MaximumPostWork_Period_in_mins = workAreaSettingsProfile.MaximumPostWork_Period_in_mins;
                    result.MaximumPreWork_Period_in_mins = workAreaSettingsProfile.MaximumPreWork_Period_in_mins;
                    result.WorkdayStart_in_mins = workAreaSettingsProfile.WorkdayStart_in_mins;
                }
            }

            if (Parameter.OfficeID != Guid.Empty)
            {
                ORM_CMN_BPT_STR_Office_SettingsProfile.Query officeSettingsProfileQuery = new ORM_CMN_BPT_STR_Office_SettingsProfile.Query();
                officeSettingsProfileQuery.Office_RefID = Parameter.OfficeID;
                officeSettingsProfileQuery.IsDeleted = false;
                officeSettingsProfileQuery.Tenant_RefID = securityTicket.TenantID;

                ORM_CMN_BPT_STR_Office_SettingsProfile officeSettingsProfile = ORM_CMN_BPT_STR_Office_SettingsProfile.Query.Search(Connection, Transaction, officeSettingsProfileQuery).FirstOrDefault();
                if (officeSettingsProfile != null)
                {
                    foundOfficeLevelSettings = true;

                    result.RestMinimumThresholdl_Adults_in_mins = officeSettingsProfile.RestMinimumThresholdl_Adults_in_mins;
                    result.RestMinimumThresholdl_NonAdults_in_mins = officeSettingsProfile.RestMinimumThresholdl_NonAdults_in_mins;
                    result.RestWarningThreshold_Adults_in_mins = officeSettingsProfile.RestWarningThreshold_Adults_in_mins;
                    result.RestWarningThreshold_NonAdults_in_mins = officeSettingsProfile.RestWarningThreshold_NonAdults_in_mins;
                    result.WorkEndTimeMaximum_NonAdults_in_mins = officeSettingsProfile.WorkEndTimeMaximum_NonAdults_in_mins;
                    result.WorkEndTimeWarning_NonAdults_in_mins = officeSettingsProfile.WorkEndTimeWarning_NonAdults_in_mins;
                    result.WorkStartTimeMinimum_NonAdults_in_mins = officeSettingsProfile.WorkStartTimeMinimum_NonAdults_in_mins;
                    result.WorkStartTimeWarning_NonAdults_in_mins = officeSettingsProfile.WorkStartTimeWarning_NonAdults_in_mins;
                    result.WorktimeBalancePeriod_in_months = officeSettingsProfile.WorktimeBalancePeriod_in_months;
                    result.WorkTimeMaximumTreshold_Adults_in_mins = officeSettingsProfile.WorkTimeMaximumTreshold_Adults_in_mins;
                    result.WorkTimeMaximumTreshold_NonAdults_in_mins = officeSettingsProfile.WorkTimeMaximumTreshold_NonAdults_in_mins;
                    result.WorkTimeWarningTreshold_Adults_in_mins = officeSettingsProfile.WorkTimeWarningTreshold_Adults_in_mins;
                    result.WorkTimeWarningTreshold_NonAdults_in_mins = officeSettingsProfile.WorkTimeWarningTreshold_NonAdults_in_mins;
                    result.AdulthoodAge = officeSettingsProfile.AdulthoodAge;

                    if (!foundWorkAreaLevelSettings)
                    {
                        foundWorkAreaLevelSettings = true;
                        result.RoosterGridMinimumPlanningUnit_in_mins = officeSettingsProfile.RoosterGridMinimumPlanningUnit_in_mins;
                        result.WorkdayStart_in_mins = officeSettingsProfile.WorkdayStart_in_mins;
                        result.MaximumPostWork_Period_in_mins = officeSettingsProfile.MaximumPostWork_Period_in_mins;
                        result.MaximumPreWork_Period_in_mins = officeSettingsProfile.MaximumPreWork_Period_in_mins;
                    }    

                }

            }

            if (!foundOfficeLevelSettings || !foundWorkAreaLevelSettings)
            {
                ORM_CMN_BPT_STA_SettingProfile.Query tenantSettingProfileQuery = new ORM_CMN_BPT_STA_SettingProfile.Query();
                tenantSettingProfileQuery.IsDeleted = false;
                tenantSettingProfileQuery.Tenant_RefID = securityTicket.TenantID;

                ORM_CMN_BPT_STA_SettingProfile tenantSettingProfile = ORM_CMN_BPT_STA_SettingProfile.Query.Search(Connection, Transaction, tenantSettingProfileQuery).FirstOrDefault();

                if (tenantSettingProfile != null)
                {
                    if (!foundOfficeLevelSettings)
                    {
                        foundOfficeLevelSettings = true;
                        result.RestMinimumThresholdl_Adults_in_mins = tenantSettingProfile.Default_RestMinimumThresholdl_Adults_in_mins;
                        result.RestMinimumThresholdl_NonAdults_in_mins = tenantSettingProfile.Default_RestMinimumThresholdl_NonAdults_in_mins;
                        result.RestWarningThreshold_Adults_in_mins = tenantSettingProfile.Default_RestWarningThreshold_Adults_in_mins;
                        result.RestWarningThreshold_NonAdults_in_mins = tenantSettingProfile.Default_RestWarningThreshold_NonAdults_in_mins;
                        result.WorkEndTimeMaximum_NonAdults_in_mins = tenantSettingProfile.Default_WorkEndTimeMaximum_NonAdults_in_mins;
                        result.WorkEndTimeWarning_NonAdults_in_mins = tenantSettingProfile.Default_WorkEndTimeWarning_NonAdults_in_mins;
                        result.WorkStartTimeMinimum_NonAdults_in_mins = tenantSettingProfile.Default_WorkStartTimeMinimum_NonAdults_in_mins;
                        result.WorkStartTimeWarning_NonAdults_in_mins = tenantSettingProfile.Default_WorkStartTimeWarning_NonAdults_in_mins;
                        result.WorktimeBalancePeriod_in_months = tenantSettingProfile.Default_WorktimeBalancePeriod_in_months;
                        result.WorkTimeMaximumTreshold_Adults_in_mins = tenantSettingProfile.Default_WorkTimeMaximumTreshold_Adults_in_mins;
                        result.WorkTimeMaximumTreshold_NonAdults_in_mins = tenantSettingProfile.Default_WorkTimeMaximumTreshold_NonAdults_in_mins;
                        result.WorkTimeWarningTreshold_Adults_in_mins = tenantSettingProfile.Default_WorkTimeWarningTreshold_Adults_in_mins;
                        result.WorkTimeWarningTreshold_NonAdults_in_mins = tenantSettingProfile.Default_WorkTimeWarningTreshold_NonAdults_in_mins;
                        result.AdulthoodAge = tenantSettingProfile.Default_AdulthoodAge;
                    }

                    if (!foundWorkAreaLevelSettings)
                    {
                        foundWorkAreaLevelSettings = true;
                        result.RoosterGridMinimumPlanningUnit_in_mins = tenantSettingProfile.Default_RoosterGridMinimumPlanningUnit_in_mins;
                        result.WorkdayStart_in_mins = tenantSettingProfile.Default_WorkdayStart_in_mins;
                        result.MaximumPostWork_Period_in_mins = tenantSettingProfile.Default_MaximumPostWork_Period_in_mins;
                        result.MaximumPreWork_Period_in_mins = tenantSettingProfile.Default_MaximumPreWork_Period_in_mins;
                    }
                }
            }

            if (!foundOfficeLevelSettings)
            {
                result.RestMinimumThresholdl_Adults_in_mins = -1;
                result.RestMinimumThresholdl_NonAdults_in_mins = -1;
                result.RestWarningThreshold_Adults_in_mins = -1;
                result.RestWarningThreshold_NonAdults_in_mins = -1;
                result.WorkEndTimeMaximum_NonAdults_in_mins = -1;
                result.WorkEndTimeWarning_NonAdults_in_mins = -1;
                result.WorkStartTimeMinimum_NonAdults_in_mins = -1;
                result.WorkStartTimeWarning_NonAdults_in_mins = -1;
                result.WorktimeBalancePeriod_in_months = -1;
                result.WorkTimeMaximumTreshold_Adults_in_mins = -1;
                result.WorkTimeMaximumTreshold_NonAdults_in_mins = -1;
                result.WorkTimeWarningTreshold_Adults_in_mins = -1;
                result.WorkTimeWarningTreshold_NonAdults_in_mins = -1;
            }

            if (!foundWorkAreaLevelSettings)
            {
                result.RoosterGridMinimumPlanningUnit_in_mins = -1;
                result.WorkdayStart_in_mins = -1;
                result.MaximumPostWork_Period_in_mins = -1;
                result.MaximumPreWork_Period_in_mins = -1;
            }

            returnValue.Result = result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6CS_GSSFS_1354 Invoke(string ConnectionString,P_L6CS_GSSFS_1354 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6CS_GSSFS_1354 Invoke(DbConnection Connection,P_L6CS_GSSFS_1354 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6CS_GSSFS_1354 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CS_GSSFS_1354 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6CS_GSSFS_1354 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CS_GSSFS_1354 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6CS_GSSFS_1354 functionReturn = new FR_L6CS_GSSFS_1354();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6CS_GSSFS_1354 : FR_Base
	{
		public L6CS_GSSFS_1354 Result	{ get; set; }

		public FR_L6CS_GSSFS_1354() : base() {}

		public FR_L6CS_GSSFS_1354(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}
