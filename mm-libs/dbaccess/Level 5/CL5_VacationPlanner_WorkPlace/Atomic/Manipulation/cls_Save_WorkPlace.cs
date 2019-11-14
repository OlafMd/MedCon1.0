/* 
 * Generated on 2/19/2014 11:21:17 AM
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
using CL1_CMN_STR_PPS;
using CL1_CMN_CAL;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_WorkPlace.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_WorkPlace.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_WorkPlace
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WP_SWP_1551 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var item = new ORM_CMN_STR_PPS_Workplace();
            if (Parameter.CMN_STR_PPS_WorkplaceID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_STR_PPS_WorkplaceID);
                if (result.Status != FR_Status.Success || item.CMN_STR_PPS_WorkplaceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            if (Parameter.WorkPlaceDescription != null)
            {
                item.Description = Parameter.WorkPlaceDescription;
            }
            else
            {
                item.Description = new Dict();
                item.Description.DictionaryID = Guid.NewGuid();
            }
            item.Name = Parameter.WorkPlaceName;
            item.ShortName = Parameter.ShortName;
            item.DisplayColor = Parameter.DisplayColor;
            item.WorkArea_RefID = Parameter.WorkArea_RefID;
            item.Tenant_RefID = securityTicket.TenantID;
            item.CMN_CAL_CalendarInstance_RefID = Parameter.CMN_CAL_CalendarInstance_RefID;


            ORM_CMN_CAL_CalendarInstance calendar = new ORM_CMN_CAL_CalendarInstance();
            if (Parameter.CMN_CAL_CalendarInstance_RefID != Guid.Empty)
            {
                var result = calendar.Load(Connection, Transaction, Parameter.CMN_CAL_CalendarInstance_RefID);
                if (result.Status != FR_Status.Success || calendar.CMN_CAL_CalendarInstanceID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            calendar.WeekStartsOnDay = 1;
            calendar.Save(Connection, Transaction);
            item.CMN_CAL_CalendarInstance_RefID = calendar.CMN_CAL_CalendarInstanceID;
            item.Save(Connection, Transaction);

            CSV2Core.DlTrace.Trace("1 workPlace");
            ORM_CMN_STR_PPS_Workplace_ResponsiblePerson whereInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_PPS_Workplace_ResponsiblePerson>();
            CSV2Core.DlTrace.Trace("2 workPlace");
            whereInstance.Workplace_RefID = item.CMN_STR_PPS_WorkplaceID;
            CSV2Core.DlTrace.Trace("3 workPlace");
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstance);
            CSV2Core.DlTrace.Trace("4 workPlace");
            if (Parameter.ResponsiblePersons != null && Parameter.ResponsiblePersons.Length > 0)
            {
                CSV2Core.DlTrace.Trace("5 workPlace");
                foreach (P_L5WP_SWP_1551_ResponsiblePerson obj in Parameter.ResponsiblePersons)
                {
                    CSV2Core.DlTrace.Trace("6 workPlace");
                    ORM_CMN_STR_PPS_Workplace_ResponsiblePerson person = new ORM_CMN_STR_PPS_Workplace_ResponsiblePerson();
                    if (obj.CMN_STR_PPS_Workplace_ResponsiblePersonID != Guid.Empty)
                    {
                        CSV2Core.DlTrace.Trace("7 workPlace");
                        var result = calendar.Load(Connection, Transaction, obj.CMN_STR_PPS_Workplace_ResponsiblePersonID);
                        if (result.Status != FR_Status.Success || person.CMN_STR_PPS_Workplace_ResponsiblePersonID == Guid.Empty)
                        {
                            CSV2Core.DlTrace.Trace("8 workPlace");
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    if (obj.CMN_STR_PPS_Workplace_ResponsiblePersonID != Guid.Empty)
                    {
                        CSV2Core.DlTrace.Trace("9 workPlace");
                        person.IsDeleted = true;
                    }
                    else
                    {
                        CSV2Core.DlTrace.Trace("10 workPlace");
                        person.CMN_BPT_EMP_Employee_RefID = obj.CMN_BPT_EMP_EmployeeID;
                        person.Workplace_RefID = item.CMN_STR_PPS_WorkplaceID;
                        person.Tenant_RefID = securityTicket.TenantID;
                    }
                    CSV2Core.DlTrace.Trace("11 workPlace");
                    person.Save(Connection, Transaction);
                }
            }
            CSV2Core.DlTrace.Trace("12 workPlace");
			//Put your code here
            return new FR_Guid(item.CMN_STR_PPS_WorkplaceID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WP_SWP_1551 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WP_SWP_1551 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WP_SWP_1551 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WP_SWP_1551 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Guid cls_Save_WorkPlace(P_L5WP_SWP_1551 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_WorkPlace.Invoke(connectionString,P_L5WP_SWP_1551 Parameter,securityTicket);
	 return result;
}
*/