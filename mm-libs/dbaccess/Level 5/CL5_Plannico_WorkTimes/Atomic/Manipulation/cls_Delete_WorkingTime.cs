/* 
 * Generated on 12/19/2013 11:50:05 AM
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
using CL5_Plannico_TypesOfWork.Complex.Retrieval;
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
    /// var result = cls_Delete_WorkingTime.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_WorkingTime
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,L5WT_DWT_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();

            ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query employmentRelationshipTemplateQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query();
            employmentRelationshipTemplateQuery.IsDeleted = false;
            employmentRelationshipTemplateQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_BPT_EMP_EmploymentRelationship_Template> employmentRelationshipTemplates = ORM_CMN_BPT_EMP_EmploymentRelationship_Template.Query.Search(Connection, Transaction, employmentRelationshipTemplateQuery);

                
            foreach (var employmentRelationshipTemplate in employmentRelationshipTemplates)
            {

                employmentRelationshipTemplate.Remove(Connection, Transaction);

                ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query officeTemplateQuery = new ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query();
                officeTemplateQuery.IsDeleted = false;
                officeTemplateQuery.Tenant_RefID = securityTicket.TenantID;
                List<ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template> officeTemplates = ORM_CMN_STR_Office_Default_WorkRelationDefinition_Template.Query.Search(Connection, Transaction, officeTemplateQuery);
                if (officeTemplates.Count != 0)
                {
                    officeTemplates[0].Remove(Connection, Transaction);
                }

                ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query templateToContractQuery = new ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query();
                templateToContractQuery.IsDeleted = false;
                templateToContractQuery.Tenant_RefID = securityTicket.TenantID;
                templateToContractQuery.CMN_BPT_EMP_EmploymentRelationship_Template_RefID = employmentRelationshipTemplate.CMN_BPT_EMP_EmploymentRelationship_TemplateID;
                List<ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract> templateToContracts = ORM_CMN_BPT_EMP_EmploymentRelationship_Templates_2_WorkingContract.Query.Search(Connection, Transaction, templateToContractQuery);
                if (templateToContracts.Count != 0)
                {
                    templateToContracts[0].Remove(Connection,Transaction);

                    ORM_CMN_BPT_EMP_WorkingContract workingContract = new ORM_CMN_BPT_EMP_WorkingContract();
                    workingContract.Load(Connection, Transaction, templateToContracts[0].CMN_BPT_EMP_WorkingContract_RefID);

                    workingContract.Remove(Connection, Transaction);

                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query extraWorkToContractQuery = new ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query();
                    extraWorkToContractQuery.IsDeleted = false;
                    extraWorkToContractQuery.Tenant_RefID = securityTicket.TenantID;
                    extraWorkToContractQuery.CMN_BPT_EMP_WorkingContract_RefID = workingContract.CMN_BPT_EMP_WorkingContractID;
                    ORM_CMN_BPT_EMP_WorkingContract_2_ExtraWorkSurcharge.Query.SoftDelete(Connection, Transaction, extraWorkToContractQuery);


                }


            }

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,L5WT_DWT_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,L5WT_DWT_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,L5WT_DWT_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,L5WT_DWT_1149 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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
				throw new Exception("Exception occured in method cls_Delete_WorkingTime",ex);
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
FR_Base cls_Delete_WorkingTime(,L5WT_DWT_1149 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_WorkingTime.Invoke(connectionString,L5WT_DWT_1149 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_TypesOfWork.Atomic.Manipulation.L5WT_DWT_1149();
parameter.CMN_BPT_EMP_EmploymentRelationship_TemplateID = ...;

*/