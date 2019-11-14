/* 
 * Generated on 2/13/2014 11:32:30 AM
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
using CL1_CMN_PER;
using CL1_CMN_BPT_EMP;
using CL1_CMN_BPT;
using CL1_CMN;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_FirstEmployee.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_FirstEmployee
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SFE_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
      
            

            ORM_CMN_Address address = new ORM_CMN_Address();
            if (Parameter.CMN_AddressID != Guid.Empty)
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
            address.Street_Name = Parameter.Street_Name;
            address.Street_Number = Parameter.Street_Number;
            address.Country_Name = Parameter.Country_Name;
            address.Province_Name = Parameter.Province_Name;
            address.Tenant_RefID = Parameter.TenantID;
            address.Save(Connection, Transaction);

            ORM_CMN_PER_PersonInfo person = new ORM_CMN_PER_PersonInfo();
            if (Parameter.CMN_PER_PersonInfoID != Guid.Empty)
            {
                var result = person.Load(Connection, Transaction, Parameter.CMN_PER_PersonInfoID);
                if (result.Status != FR_Status.Success || person.CMN_PER_PersonInfoID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            //person.AccountImage_URL = Parameter.ProfileImage_Document_RefID;
            person.FirstName = Parameter.FirstName;
            person.LastName = Parameter.LastName;
            person.PrimaryEmail = Parameter.PrimaryEmail;
            person.Tenant_RefID = Parameter.TenantID;
            person.Title = Parameter.Title;
            person.Address_RefID = address.CMN_AddressID;
            person.BirthDate = Parameter.BirthDate;
            person.Save(Connection, Transaction);

            ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
            if (Parameter.CMN_BPT_BusinessParticipantID != Guid.Empty)
            {
                var result = bParticipant.Load(Connection, Transaction, Parameter.CMN_BPT_BusinessParticipantID);
                if (result.Status != FR_Status.Success || bParticipant.CMN_BPT_BusinessParticipantID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            bParticipant.DisplayName = Parameter.DisplayName;
            bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
            bParticipant.IsNaturalPerson = true;
            bParticipant.Tenant_RefID = Parameter.TenantID;
            bParticipant.Save(Connection, Transaction);
            ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();


            CSV2Core.DlTrace.Trace("Parameter.CMN_BPT_EMP_EmployeeID " + Parameter.CMN_BPT_EMP_EmployeeID);
            if (Parameter.CMN_BPT_EMP_EmployeeID != Guid.Empty)
            {
                var result = employee.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_EmployeeID);
                if (result.Status != FR_Status.Success || employee.CMN_BPT_EMP_EmployeeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            
            employee.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            employee.Staff_Number = Parameter.Staff_Number;
            employee.StandardFunction = Parameter.StandardFunction;
            employee.Tenant_RefID = Parameter.TenantID;
          
            employee.Save(Connection, Transaction);
            CSV2Core.DlTrace.Trace("after save Parameter.CMN_BPT_EMP_EmployeeID " + Parameter.CMN_BPT_EMP_EmployeeID);
            CSV2Core.DlTrace.Trace("employee.Status_IsAlreadySaved " + employee.Status_IsAlreadySaved);

            ORM_CMN_BPT_EMP_EmploymentRelationship employeeRelationship = new ORM_CMN_BPT_EMP_EmploymentRelationship();
            if (Parameter.CMN_BPT_EMP_Employee_WorkingContractID != Guid.Empty)
            {
                var result = employeeRelationship.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_Employee_WorkingContractID);
                if (result.Status != FR_Status.Success || employeeRelationship.CMN_BPT_EMP_EmploymentRelationshipID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            employeeRelationship.Work_StartDate = Parameter.Work_StartDate;
            employeeRelationship.Work_EndDate = Parameter.Work_EndDate;
            employeeRelationship.Tenant_RefID = Parameter.TenantID;
            employeeRelationship.Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
            employeeRelationship.Save(Connection, Transaction);

            

            if (Parameter.USR_AccountID != null && Parameter.USR_AccountID != Guid.Empty)
            {
                ORM_USR_Account account = new ORM_USR_Account();
                account.Load(Connection, Transaction, Parameter.USR_AccountID);
                account.USR_AccountID = Parameter.USR_AccountID;
                account.Username = Parameter.username;
                account.DefaultLanguage_RefID = Parameter.LanguageID;
                account.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                account.Tenant_RefID = Parameter.TenantID;
                account.Save(Connection, Transaction);

                var personToAccountQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
                personToAccountQuery.Tenant_RefID = securityTicket.TenantID;
                personToAccountQuery.USR_Account_RefID = account.USR_AccountID;
                personToAccountQuery.IsDeleted = false;
                var personToAccounts = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, personToAccountQuery);
                if (personToAccounts.Count != 0)
                {
                    ORM_CMN_PER_PersonInfo_2_Account personToAccount = personToAccounts[0];
                    personToAccount.CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
                    personToAccount.USR_Account_RefID = account.USR_AccountID;
                    personToAccount.Tenant_RefID = securityTicket.TenantID;
                    personToAccount.Save(Connection, Transaction);
                }
                else
                {
                    ORM_CMN_PER_PersonInfo_2_Account personToAccount = new ORM_CMN_PER_PersonInfo_2_Account();
                    personToAccount.CMN_PER_PersonInfo_RefID = person.CMN_PER_PersonInfoID;
                    personToAccount.USR_Account_RefID = account.USR_AccountID;
                    personToAccount.Tenant_RefID = securityTicket.TenantID;
                    personToAccount.Save(Connection, Transaction);
                }

                if (Parameter.Rights != null)
                {
                    foreach (var rightParam in Parameter.Rights)
                    {
                        var right = new ORM_USR_Account_FunctionLevelRight();
                        if (rightParam.RightID != Guid.Empty)
                        {
                            var result = right.Load(Connection, Transaction, rightParam.RightID);
                            if (result.Status != FR_Status.Success || right.USR_Account_FunctionLevelRightID == Guid.Empty)
                            {
                                right.USR_Account_FunctionLevelRightID = rightParam.RightID;
                                right.Tenant_RefID = Parameter.TenantID;
                                right.RightName = rightParam.RightName;
                                right.FunctionLevelRights_Group_RefID = Guid.Empty;
                                right.Save(Connection, Transaction);
                            }
                        }

                        var right2account = new ORM_USR_Account_2_FunctionLevelRight();
                        right2account.Account_RefID = account.USR_AccountID;
                        right2account.FunctionLevelRight_RefID = rightParam.RightID;
                        right2account.Tenant_RefID = Parameter.TenantID;
                        right2account.Save(Connection, Transaction);
                    }
                }
   
            }

            returnValue.Result = employee.CMN_BPT_EMP_EmployeeID;
            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SFE_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SFE_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SFE_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SFE_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_FirstEmployee",ex);
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
FR_Guid cls_Save_FirstEmployee(,P_L5EM_SFE_1524 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_FirstEmployee.Invoke(connectionString,P_L5EM_SFE_1524 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Atomic.Manipulation.P_L5EM_SFE_1524();
parameter.Rights = ...;

parameter.CMN_PER_PersonInfoID = ...;
parameter.TenantID = ...;
parameter.FirstName = ...;
parameter.LastName = ...;
parameter.PrimaryEmail = ...;
parameter.Title = ...;
parameter.BirthDate = ...;
parameter.ProfileImage_Document_RefID = ...;
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
parameter.CMN_BPT_BusinessParticipantID = ...;
parameter.DisplayName = ...;
parameter.CMN_BPT_EMP_EmployeeID = ...;
parameter.Staff_Number = ...;
parameter.StandardFunction = ...;
parameter.Employee_2_Contract_AssigmentID = ...;
parameter.CMN_BPT_EMP_Employee_WorkingContractID = ...;
parameter.IsActive = ...;
parameter.Work_StartDate = ...;
parameter.Work_EndDate = ...;
parameter.ContractDate = ...;
parameter.USR_AccountID = ...;
parameter.LanguageID = ...;
parameter.username = ...;
parameter.ApplicationID = ...;

*/