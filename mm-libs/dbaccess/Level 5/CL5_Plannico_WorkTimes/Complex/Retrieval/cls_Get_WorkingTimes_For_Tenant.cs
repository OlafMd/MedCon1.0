/* 
 * Generated on 12/19/2013 11:32:59 AM
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

namespace CL5_Plannico_TypesOfWork.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WorkingTimes_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WorkingTimes_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5WT_GWTFT_1106_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L5WT_GWTFT_1106_Array();


            ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query employmentRelationshipTemplateQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query();
            employmentRelationshipTemplateQuery.IsDeleted = false;
            employmentRelationshipTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> employmentRelationshipTemplates = ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query.Search(Connection, Transaction, employmentRelationshipTemplateQuery);

            List<L5WT_GWTFT_1106> resultList = new List<L5WT_GWTFT_1106>();
            foreach (var employmentRelationshipTemplate in employmentRelationshipTemplates)
            {
                L5WT_GWTFT_1106 eRItem = new L5WT_GWTFT_1106();
                eRItem.CMN_BPT_EMP_EmploymentRelationship_TemplateID = employmentRelationshipTemplate.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
                eRItem.RequiredDailyHours = employmentRelationshipTemplate.RequiredDailyHours;
                eRItem.RequiredMonthlyHours = employmentRelationshipTemplate.RequiredMonthlyHours;
                eRItem.RequiredWeeklyHours = employmentRelationshipTemplate.RequiredWeeklyHours;
                eRItem.Template_EndDate = employmentRelationshipTemplate.Template_EndDate;
                eRItem.Template_Name = employmentRelationshipTemplate.Template_Name;
                eRItem.Template_StartDate = employmentRelationshipTemplate.Template_StartDate;
                eRItem.R_WeeklyWorkPattern = employmentRelationshipTemplate.R_WeeklyWorkPattern;
                ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query officeTemplateQuery = new ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query();
                officeTemplateQuery.IsDeleted = false;
                officeTemplateQuery.Tenant_RefID = securityTicket.TenantID;
                officeTemplateQuery.CMN_BPT_EMP_Employee_WorkRelationDefinition_Template_RefID = eRItem.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
                List<ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template> officeTemplates = ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query.Search(Connection, Transaction, officeTemplateQuery);
                if (officeTemplates.Count != 0)
                {
                    eRItem.CMN_STR_Office_RefID = officeTemplates[0].CMN_STR_Office_RefID;
                }

                ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query templateToContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query();
                templateToContractQuery.IsDeleted = false;
                templateToContractQuery.Tenant_RefID = securityTicket.TenantID;
                templateToContractQuery.CMN_BPT_EMP_EmploymentRelationship_Template_RefID = employmentRelationshipTemplate.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
                List<ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract> templateToContracts = ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query.Search(Connection, Transaction, templateToContractQuery);
                if (templateToContracts.Count != 0)
                {
                    ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract templateToContract = templateToContracts[0];

                    ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                    workingContract.Load(Connection, Transaction, templateToContract.CMN_BPT_EMP_WorkingContract_RefID);

                    eRItem.ExtraWorkCalculation_RefID = workingContract.ExtraWorkCalculation_RefID;

                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query extraWorkToContractQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query();
                    extraWorkToContractQuery.IsDeleted = false;
                    extraWorkToContractQuery.Tenant_RefID = securityTicket.TenantID;
                    extraWorkToContractQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                    List<ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge> extraWorkToContracts = ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query.Search(Connection, Transaction, extraWorkToContractQuery);
                    
                    List<L5WT_GWTFT_1106_ExtraWorkSurcharges> ewsItemList=new List<L5WT_GWTFT_1106_ExtraWorkSurcharges>();
                    foreach (var extraWorkToContract in extraWorkToContracts)
                    {
                        L5WT_GWTFT_1106_ExtraWorkSurcharges ewsItem = new L5WT_GWTFT_1106_ExtraWorkSurcharges();
                        ewsItem.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID = extraWorkToContract.CMN_BPT_EMP_ExtraWorkCalculation_Surcharge_RefID;
                        ewsItem.R_IsNightTimeSurcharge = extraWorkToContract.R_IsNightTimeSurcharge;
                        ewsItem.R_IsSpecialEventSurcharge = extraWorkToContract.R_IsSpecialEventSurcharge;
                        ewsItemList.Add(ewsItem);
                    }
                    eRItem.ExtraWorkSurcharges = ewsItemList.ToArray();
                    resultList.Add(eRItem);

                }


            }
            returnValue.Result = resultList.ToArray();


            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5WT_GWTFT_1106_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5WT_GWTFT_1106_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5WT_GWTFT_1106_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5WT_GWTFT_1106_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5WT_GWTFT_1106_Array functionReturn = new FR_L5WT_GWTFT_1106_Array();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Get_WorkingTimes_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5WT_GWTFT_1106_Array : FR_Base
	{
		public L5WT_GWTFT_1106[] Result	{ get; set; } 
		public FR_L5WT_GWTFT_1106_Array() : base() {}

		public FR_L5WT_GWTFT_1106_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5WT_GWTFT_1106_Array cls_Get_WorkingTimes_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5WT_GWTFT_1106_Array invocationResult = cls_Get_WorkingTimes_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
