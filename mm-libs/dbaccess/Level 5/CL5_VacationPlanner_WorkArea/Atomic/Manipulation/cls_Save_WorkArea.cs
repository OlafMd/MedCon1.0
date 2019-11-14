/* 
 * Generated on 8/26/2013 2:06:10 PM
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

namespace CL5_VacationPlanner_WorkArea.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_WorkArea.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_WorkArea
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WA_SWA_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
			//Put your code here

            var item = new ORM_CMN_STR_PPS_WorkArea();
            if (Parameter.CMN_STR_PPS_WorkAreaID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_STR_PPS_WorkAreaID);
                if (result.Status != FR_Status.Success || item.CMN_STR_PPS_WorkAreaID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            item.Default_StartWorkingHour =0;
            if (Parameter.WorkAreaDescription != null)
            {
                item.Description = Parameter.WorkAreaDescription;
            }
            else
            {
                item.Description = new Dict();
                item.Description.DictionaryID = Guid.NewGuid();
            }
            item.Name = Parameter.WorkAreaName;
            item.ShortName = Parameter.ShortName;
            item.Parent_RefID = Parameter.Parent_RefID;            
            item.Tenant_RefID = securityTicket.TenantID;
            item.Office_RefID = Parameter.Office_RefID;
            item.CMN_CAL_CalendarInstance_RefID = Parameter.CMN_CAL_CalendarInstance_RefID;
       
            ORM_CMN_STR_PPS_WorkArea_2_CostCenter whereCC2WAInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_PPS_WorkArea_2_CostCenter>();
            whereCC2WAInstance.WorkArea_RefID = item.CMN_STR_PPS_WorkAreaID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereCC2WAInstance);
            if (Parameter.Costcenter_RefID != null)
            {
                


                var cc2wa = new ORM_CMN_STR_PPS_WorkArea_2_CostCenter();
                cc2wa.CostCenter_RefID = Parameter.Costcenter_RefID;
                cc2wa.IsDeleted = false;
                cc2wa.Tenant_RefID = securityTicket.TenantID;
                cc2wa.WorkArea_RefID = item.CMN_STR_PPS_WorkAreaID;
                cc2wa.Save(Connection, Transaction);
            }

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

            ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson whereInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson>();
            whereInstance.WorkArea_RefID = item.CMN_STR_PPS_WorkAreaID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstance);
            if (Parameter.ResponsiblePersons != null && Parameter.ResponsiblePersons.Length > 0)
            {
                foreach (P_L5WA_SWA_1545_ResponsiblePersons obj in Parameter.ResponsiblePersons)
                {
                    ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson person = new ORM_CMN_STR_PPS_WorkArea_ResponsiblePerson();
                    if (obj.CMN_STR_PPS_WorkArea_ResponsiblePersonID != Guid.Empty)
                    {
                        var result = calendar.Load(Connection, Transaction, obj.CMN_STR_PPS_WorkArea_ResponsiblePersonID);
                        if (result.Status != FR_Status.Success || person.CMN_STR_PPS_WorkArea_ResponsiblePersonID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    if (obj.CMN_STR_PPS_WorkArea_ResponsiblePersonID != Guid.Empty)
                    {
                        person.IsDeleted = true;
                    }
                    else
                    {
                        person.CMN_BPT_EMP_Employee_RefID = obj.CMN_BPT_EMP_EmployeeID;
                        person.WorkArea_RefID = item.CMN_STR_PPS_WorkAreaID;
                        person.Tenant_RefID = securityTicket.TenantID;
                    }

                    person.Save(Connection, Transaction);
                }
            }

            return   new FR_Guid(item.CMN_STR_PPS_WorkAreaID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WA_SWA_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WA_SWA_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WA_SWA_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WA_SWA_1545 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
FR_Guid cls_Save_WorkArea(P_L5WA_SWA_1545 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_WorkArea.Invoke(connectionString,P_L5WA_SWA_1545 Parameter,securityTicket);
	 return result;
}
*/