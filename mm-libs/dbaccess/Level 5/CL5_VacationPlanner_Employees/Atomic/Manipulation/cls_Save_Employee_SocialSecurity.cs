/* 
 * Generated on 2/4/2014 11:38:53 AM
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
using CL1_HEC;
using CL1_CMN_BPT_EMP;
using CL1_CMN_PER;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee_SocialSecurity.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee_SocialSecurity
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SESS_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

			//Put your code here
            ORM_HEC_Patient patient = ORM_HEC_Patient.Query.Search(Connection, Transaction, new ORM_HEC_Patient.Query() {
                IsDeleted = false,
                CMN_BPT_BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID,
                Tenant_RefID = securityTicket.TenantID
            }).FirstOrDefault();

            if (patient == null || patient.HEC_PatientID == Guid.Empty)
                patient = new ORM_HEC_Patient();

            patient.Tenant_RefID = securityTicket.TenantID;
            patient.CMN_BPT_BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID;
            patient.Save(Connection, Transaction);

            ORM_HEC_Patient_HealthInsurance patientHI = ORM_HEC_Patient_HealthInsurance.Query.Search(Connection, Transaction, new ORM_HEC_Patient_HealthInsurance.Query() {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Patient_RefID = patient.HEC_PatientID
            }).FirstOrDefault();

            if (patientHI == null || patientHI.HEC_Patient_HealthInsurancesID == Guid.Empty)
                patientHI = new ORM_HEC_Patient_HealthInsurance();

            patientHI.Tenant_RefID = securityTicket.TenantID;
            patientHI.Patient_RefID = patient.HEC_PatientID;
            patientHI.HealthInsurance_Number = Parameter.HealthInsurance_Number;
            patientHI.HIS_HealthInsurance_Company_RefID = Parameter.HEC_HealthInsurance_CompanyID;
            patientHI.Save(Connection, Transaction);


                ORM_CMN_BPT_EMP_Employee_2_Profession employeeToProffession = ORM_CMN_BPT_EMP_Employee_2_Profession.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Profession.Query()
                {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID,
                Employee_RefID = Parameter.CMN_BPT_EMP_EmployeeID
            }).FirstOrDefault();
                if (employeeToProffession == null || employeeToProffession.AssignmentID == Guid.Empty)
                    employeeToProffession = new ORM_CMN_BPT_EMP_Employee_2_Profession();
                employeeToProffession.Employee_RefID = Parameter.CMN_BPT_EMP_EmployeeID;
                employeeToProffession.Profession_RefID = Parameter.CMN_STR_ProfessionID;
                employeeToProffession.Tenant_RefID = securityTicket.TenantID;
                employeeToProffession.Save(Connection, Transaction);
            


                ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus personSecurityStatus = ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus.Query.Search(Connection, Transaction, new ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                     CMN_PER_PersonInfo_RefID= Parameter.CMN_PER_PersonInfoID
                }).FirstOrDefault();
                if (personSecurityStatus == null || personSecurityStatus.AssignmentID == Guid.Empty)
                    personSecurityStatus = new ORM_CMN_PER_Person_2_CompulsorySocialSecurityStatus();
                personSecurityStatus.CMN_PER_PersonInfo_RefID = Parameter.CMN_PER_PersonInfoID;
                personSecurityStatus.CMN_PER_CompulsorySocialSecurityStatus_RefID = Parameter.CMN_PER_CompulsorySocialSecurityStatusID;
                personSecurityStatus.Tenant_RefID = securityTicket.TenantID;
                personSecurityStatus.Save(Connection, Transaction);
            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SESS_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SESS_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SESS_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SESS_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Employee_SocialSecurity",ex);
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
FR_Guid cls_Save_Employee_SocialSecurity(,P_L5EM_SESS_1534 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Employee_SocialSecurity.Invoke(connectionString,P_L5EM_SESS_1534 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Atomic.Manipulation.P_L5EM_SESS_1534();
parameter.HealthInsurance_Number = ...;
parameter.CMN_BPT_BusinessParticipantID = ...;
parameter.HEC_HealthInsurance_CompanyID = ...;
parameter.CMN_STR_ProfessionID = ...;
parameter.ACC_TAX_TaxOfficeID = ...;
parameter.CMN_BPT_EMP_EmployeeID = ...;
parameter.CMN_PER_CompulsorySocialSecurityStatusID = ...;
parameter.CMN_PER_PersonInfoID = ...;

*/