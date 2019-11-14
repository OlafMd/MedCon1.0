/* 
 * Generated on 12/19/2013 12:38:12 PM
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
using CL1_CMN_BPT_EMP;
using CL1_CMN_STR;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_TypesOfWork.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_WorkingTime.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_WorkingTime
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WT_SWT_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query employmentRelationshipTemplateQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query();
            employmentRelationshipTemplateQuery.IsDeleted = false;
            employmentRelationshipTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> employmentRelationshipTemplates = ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query.Search(Connection, Transaction, employmentRelationshipTemplateQuery);

            var item = new ORM_CMN_BPT_EMP_EmploymentRelationship_Template();
            if (Parameter.CMN_BPT_EMP_EmploymentRelationship_TemplateID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_EmploymentRelationship_TemplateID);
                if (result.Status != FR_Status.Success || item.CMN_BPT_EMP_EmploymentRelationship_TemplateID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            item.RequiredDailyHours = Parameter.RequiredDailyHours;
            item.RequiredMonthlyHours = Parameter.RequiredMonthlyHours;
            item.RequiredWeeklyHours = Parameter.RequiredWeeklyHours;
            item.Template_EndDate = Parameter.Template_EndDate;
            item.Template_Name = Parameter.Template_Name;
            item.Template_StartDate = Parameter.Template_StartDate;
            item.R_WeeklyWorkPattern = Parameter.R_WeeklyWorkPattern;
            item.Tenant_RefID = securityTicket.TenantID;
            item.Save(Connection, Transaction);


            if (Parameter.CMN_BPT_EMP_EmploymentRelationship_TemplateID == Guid.Empty && Parameter.CMN_STR_Office_RefID != Guid.Empty)
            {
                ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template officeTemplate = new ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template();
                officeTemplate.CMN_BPT_EMP_Employee_WorkRelationDefinition_Template_RefID = item.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
                officeTemplate.CMN_STR_Office_RefID = Parameter.CMN_STR_Office_RefID;
                officeTemplate.Tenant_RefID = securityTicket.TenantID;
                officeTemplate.Save(Connection, Transaction);
            }

            if (Parameter.CMN_BPT_EMP_EmploymentRelationship_TemplateID == Guid.Empty)
            {


                ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract empRelToContract = new ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract();
                empRelToContract.CMN_BPT_EMP_EmploymentRelationship_Template_RefID = item.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
                


                ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                workingContract.ExtraWorkCalculation_RefID = Parameter.ExtraWorkCalculation_RefID;
                workingContract.Tenant_RefID = securityTicket.TenantID;
                workingContract.Save(Connection, Transaction);


                empRelToContract.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                empRelToContract.Tenant_RefID = securityTicket.TenantID;
                empRelToContract.Save(Connection, Transaction);



                foreach (var extraWorksurcharges in Parameter.ExtraWorkSurcharges)
                {
                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge ewsItem = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge();
                    ewsItem.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID = extraWorksurcharges.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID;
                    ewsItem.R_IsNightTimeSurcharge = extraWorksurcharges.R_IsNightTimeSurcharge;
                    ewsItem.R_IsSpecialEventSurcharge = extraWorksurcharges.R_IsSpecialEventSurcharge;
                    ewsItem.Tenant_RefID = securityTicket.TenantID;
                    ewsItem.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                    ewsItem.Save(Connection, Transaction);
                }
            }
            else
            {


                ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query templateToContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query();
                templateToContractQuery.IsDeleted = false;
                templateToContractQuery.Tenant_RefID = securityTicket.TenantID;
                templateToContractQuery.CMN_BPT_EMP_EmploymentRelationship_Template_RefID = item.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
                List<ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract> templateToContracts = ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query.Search(Connection, Transaction, templateToContractQuery);
                if (templateToContracts.Count != 0)
                {
                    ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract templateToContract = templateToContracts[0];
                    ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                    workingContract.Load(Connection, Transaction, templateToContract.CMN_BPT_EMP_WorkingContract_RefID);

                    workingContract.ExtraWorkCalculation_RefID = Parameter.ExtraWorkCalculation_RefID;
                    workingContract.Save(Connection, Transaction);

                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query extraWorkToContractQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query();
                    extraWorkToContractQuery.IsDeleted = false;
                    extraWorkToContractQuery.Tenant_RefID = securityTicket.TenantID;
                    extraWorkToContractQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query.SoftDelete(Connection, Transaction, extraWorkToContractQuery);


                    foreach (var extraWorksurcharges in Parameter.ExtraWorkSurcharges)
                    {
                        ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge ewsItem = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge();
                        ewsItem.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID = extraWorksurcharges.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID;
                        ewsItem.R_IsNightTimeSurcharge = extraWorksurcharges.R_IsNightTimeSurcharge;
                        ewsItem.R_IsSpecialEventSurcharge = extraWorksurcharges.R_IsSpecialEventSurcharge;
                        ewsItem.Tenant_RefID = securityTicket.TenantID;
                        ewsItem.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                        ewsItem.Save(Connection, Transaction);
                    }

                }




            }
            returnValue.Result = item.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WT_SWT_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WT_SWT_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WT_SWT_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WT_SWT_1135 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Save_WorkingTime",ex);
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
FR_Guid cls_Save_WorkingTime(,P_L5WT_SWT_1135 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_WorkingTime.Invoke(connectionString,P_L5WT_SWT_1135 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_TypesOfWork.Atomic.Manipulation.P_L5WT_SWT_1135();
parameter.ExtraWorkSurcharges = ...;

parameter.CMN_STR_Office_RefID = ...;
parameter.CMN_BPT_EMP_EmploymentRelationship_TemplateID = ...;
parameter.Template_StartDate = ...;
parameter.Template_EndDate = ...;
parameter.Template_Name = ...;
parameter.RequiredMonthlyHours = ...;
parameter.RequiredWeeklyHours = ...;
parameter.RequiredDailyHours = ...;
parameter.ExtraWorkCalculation_RefID = ...;
parameter.R_WeeklyWorkPattern = ...;

*/