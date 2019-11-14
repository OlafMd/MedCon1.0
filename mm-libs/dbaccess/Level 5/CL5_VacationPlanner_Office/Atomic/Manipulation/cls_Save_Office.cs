/* 
 * Generated on 10/25/2013 11:47:10 AM
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
using CL1_CMN_STR;
using CL1_CMN_CAL;
using CL1_CMN;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Office.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Office.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Office
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_SO_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();




			var item = new ORM_CMN_STR_Office();
			if (Parameter.CMN_STR_OfficeID != Guid.Empty)
			{
				var result = item.Load(Connection, Transaction, Parameter.CMN_STR_OfficeID);
				if (result.Status != FR_Status.Success || item.CMN_STR_OfficeID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
					return error;
				}
			}



			var address = new ORM_CMN_Address();
			if (Parameter.CMN_AddressID!= Guid.Empty)
			{
				var result = address.Load(Connection, Transaction, Parameter.CMN_AddressID);
				if (result.Status != FR_Status.Success || address.CMN_AddressID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
					return error;
				}
			}
			address.City_Name = Parameter.City_Name;
			address.City_AdministrativeDistrict = Parameter.City_AdministrativeDistrict;
			address.City_PostalCode = Parameter.City_PostalCode;
			address.City_Region = Parameter.City_Region;
			address.Country_Name = Parameter.Country_Name;
			address.Province_Name = Parameter.Province_Name;
			address.Street_Name = Parameter.Street_Name;
			address.Street_Number = Parameter.Street_Number;
			address.Tenant_RefID = securityTicket.TenantID;
			address.Save(Connection, Transaction);

            item.Default_BillingAddress_RefID = address.CMN_AddressID;
            item.Default_ShippingAddress_RefID = address.CMN_AddressID;
            item.Tenant_RefID = securityTicket.TenantID;
            item.Default_FaxNumber = Parameter.Default_FaxNumber;
            item.Default_PhoneNumber = Parameter.Default_PhoneNumber;
            item.Office_Name = Parameter.OfficeName;
            item.Office_Description = Parameter.OfficeDescription;
            item.Office_ShortName = Parameter.OfficeShortName;
            item.CMN_CAL_CalendarInstance_RefID = Parameter.CMN_CAL_CalendarInstance_RefID;
            item.Region_RefID = Parameter.Region_RefID;
            item.Country_RefID = Parameter.Country_RefID;
        
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



            ORM_CMN_STR_Office_2_CostCenter whereCC2OInstance = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_Office_2_CostCenter>();
            whereCC2OInstance.Office_RefID = Parameter.CMN_STR_OfficeID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereCC2OInstance);
            if (Parameter.Costcenter_RefID != Guid.Empty)
            {
                var cc2o = new ORM_CMN_STR_Office_2_CostCenter();
                cc2o.CostCenter_RefID = Parameter.Costcenter_RefID;
                cc2o.IsDefault = true;
                cc2o.IsDeleted = false;
                cc2o.Tenant_RefID = securityTicket.TenantID;
                cc2o.Office_RefID = item.CMN_STR_OfficeID;
                cc2o.Save(Connection, Transaction);
            }
            var query1 = new ORM_CMN_STR_Office_ResponsiblePerson.Query();
            query1.Tenant_RefID = securityTicket.TenantID;
            query1.Office_RefID = item.CMN_STR_OfficeID;
            var res = ORM_CMN_STR_Office_ResponsiblePerson.Query.SoftDelete(Connection, Transaction, query1);
            if (Parameter.ResponsiblePerson != null && Parameter.ResponsiblePerson.Length > 0)
            {
                foreach(P_L5OF_SO_1428_ResponsiblePerson obj in Parameter.ResponsiblePerson)
                {
                    ORM_CMN_STR_Office_ResponsiblePerson person = new ORM_CMN_STR_Office_ResponsiblePerson();
                    if (obj.AssignmentID != Guid.Empty)
                    {
                        var result = calendar.Load(Connection, Transaction, obj.AssignmentID);
                        if (result.Status != FR_Status.Success || person.CMN_STR_Office_ResponsiblePersonID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return error;
                        }
                    }
                    if (obj.AssignmentID != Guid.Empty)
                    {
                        person.IsDeleted = true;
                    }
                    else
                    {
                        person.CMN_BPT_EMP_Employee_RefID = obj.ResponsibleEmployeeID;
                        person.Office_RefID = item.CMN_STR_OfficeID;
                        person.Tenant_RefID = securityTicket.TenantID;
                    }
                   
                    person.Save(Connection, Transaction);
                }         
            }

            return new FR_Guid(item.CMN_STR_OfficeID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OF_SO_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OF_SO_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_SO_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_SO_1428 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Office",ex);
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
FR_Guid cls_Save_Office(,P_L5OF_SO_1428 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Office.Invoke(connectionString,P_L5OF_SO_1428 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Office.Atomic.Manipulation.P_L5OF_SO_1428();
parameter.ResponsiblePerson = ...;

parameter.CMN_STR_OfficeID = ...;
parameter.Region_RefID = ...;
parameter.Country_RefID = ...;
parameter.Costcenter_RefID = ...;
parameter.CMN_AddressID = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.City_AdministrativeDistrict = ...;
parameter.City_Region = ...;
parameter.City_Name = ...;
parameter.City_PostalCode = ...;
parameter.Province_Name = ...;
parameter.Country_Name = ...;
parameter.Country_ISOCode = ...;
parameter.Default_PhoneNumber = ...;
parameter.Default_FaxNumber = ...;
parameter.OfficeName = ...;
parameter.OfficeDescription = ...;
parameter.OfficeShortName = ...;
parameter.CMN_CAL_CalendarInstance_RefID = ...;

*/