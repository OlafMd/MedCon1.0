/* 
 * Generated on 8/26/2013 2:33:08 PM
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
using CL2_Language.Atomic.Retrieval;
using CL1_CMN;
using CL1_CMN_BPT_STA;
using CL1_CMN_CAL;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Tenant_Calendar.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Tenant_Calendar
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            ORM_CMN_CAL_CalendarInstance CalendarInstance = new ORM_CMN_CAL_CalendarInstance();
            CalendarInstance.WeekStartsOnDay=0;
            CalendarInstance.Tenant_RefID = securityTicket.TenantID;
            CalendarInstance.Save(Connection,Transaction);

            ORM_CMN_BPT_STA_SettingProfile profile = new ORM_CMN_BPT_STA_SettingProfile();
            profile.IsLeaveTimeCalculated_InDays = true;
            L2LN_GAL_1526[] AllLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result;
            profile.StafMember_Caption = new Dict();
            profile.StafMember_Caption.DictionaryID = Guid.NewGuid();
                           
            if (AllLanguages != null)
            {
                foreach (var lang in AllLanguages)
                {
                    if (lang.ISO_639_1.ToUpper() == "DE")
                        profile.StafMember_Caption.AddEntry(lang.CMN_LanguageID, "Mitarbeiter");
                    if (lang.ISO_639_1.ToUpper() == "EN")
                        profile.StafMember_Caption.AddEntry(lang.CMN_LanguageID, "Staff");
                }
            }
            profile.Tenant_RefID = securityTicket.TenantID;
            profile.Save(Connection, Transaction);

            ORM_CMN_Tenant tenant = new ORM_CMN_Tenant();
            if (securityTicket.TenantID != Guid.Empty)
            {
                var result = tenant.Load(Connection, Transaction, securityTicket.TenantID);
                if (result.Status != FR_Status.Success || tenant.CMN_TenantID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            tenant.CMN_BPT_STA_SettingProfile_RefID = profile.CMN_BPT_STA_SettingProfileID;
            tenant.CMN_CAL_CalendarInstance_RefID = CalendarInstance.CMN_CAL_CalendarInstanceID;
            tenant.Save(Connection, Transaction);
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Guid cls_Save_Tenant_Calendar(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Tenant_Calendar.Invoke(connectionString,securityTicket);
	 return result;
}
*/