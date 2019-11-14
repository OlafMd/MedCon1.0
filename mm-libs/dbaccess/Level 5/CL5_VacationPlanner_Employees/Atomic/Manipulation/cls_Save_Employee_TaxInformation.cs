/* 
 * Generated on 2/4/2014 12:09:28 PM
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
using CL1_CMN_PER;
using CL1_CMN_BPT_EMP;
using CL1_CMN_BPT;
using CL1_ACC_TAX;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee_TaxInformation.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee_TaxInformation
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_SETI_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_CMN_BPT_EMP_Employee_TaxInformation taxInfo = new ORM_CMN_BPT_EMP_Employee_TaxInformation();
            if (Parameter.CMN_BPT_EMP_Employee_TaxInformationID != Guid.Empty)
            {
                var result = taxInfo.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_Employee_TaxInformationID);
                if (result.Status != FR_Status.Success || taxInfo.CMN_BPT_EMP_Employee_TaxInformationID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            taxInfo.Employee_RefID = Parameter.EmployeeID;
            taxInfo.TaxNumber = Parameter.TaxNumber;
            taxInfo.TaxClass = Parameter.TaxClass;
            taxInfo.TaxExemptionAmount = Parameter.TaxExemptionAmount;
            taxInfo.Tenant_RefID = securityTicket.TenantID;
            taxInfo.Save(Connection, Transaction);

            returnValue = new FR_Guid(taxInfo.CMN_BPT_EMP_Employee_TaxInformationID);

            ORM_CMN_PER_Person_2_Religion.Query person2ReligionQuery = new ORM_CMN_PER_Person_2_Religion.Query();
            person2ReligionQuery.CMN_PER_PersonInfo_RefID = Parameter.CMN_PER_PersonInfoID;
            person2ReligionQuery.CMN_PER_Religion_RefID = Parameter.EmployeeID;
            person2ReligionQuery.IsDeleted = false;
            person2ReligionQuery.Tenant_RefID = securityTicket.TenantID;

            List<ORM_CMN_PER_Person_2_Religion> person2ReligionList = ORM_CMN_PER_Person_2_Religion.Query.Search(Connection, Transaction, person2ReligionQuery);

            if (person2ReligionList.Count == 0)
            {
                ORM_CMN_PER_Person_2_Religion newPersonToReligion = new ORM_CMN_PER_Person_2_Religion();
                newPersonToReligion.CMN_PER_PersonInfo_RefID = Parameter.CMN_PER_PersonInfoID;
                newPersonToReligion.CMN_PER_Religion_RefID = Parameter.ReligionID;
                newPersonToReligion.Tenant_RefID = securityTicket.TenantID;

                newPersonToReligion.Save(Connection, Transaction);
            }
            else
            {
                ORM_CMN_PER_Person_2_Religion personToReligion = person2ReligionList.FirstOrDefault();
                personToReligion.CMN_PER_PersonInfo_RefID = Parameter.CMN_PER_PersonInfoID;
                personToReligion.CMN_PER_Religion_RefID = Parameter.ReligionID;
                personToReligion.Save(Connection, Transaction);
            }

            ORM_ACC_TAX_TaxOffice taxOffice=new ORM_ACC_TAX_TaxOffice();
            taxOffice.Load(Connection,Transaction,Parameter.ACC_TAX_TaxOfficeID);
            if(taxOffice.ACC_TAX_TaxOfficeID==Guid.Empty)
                return returnValue;

            ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant bpartAssociated = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query
            {
                BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();
            if (bpartAssociated == null || bpartAssociated.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID == Guid.Empty)
            {
                bpartAssociated = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
            }
            bpartAssociated.AssociatedBusinessParticipant_RefID = taxOffice.CMN_BPT_BusinessParticipant_RefID;
            bpartAssociated.BusinessParticipant_RefID = Parameter.CMN_BPT_BusinessParticipantID;
            bpartAssociated.Tenant_RefID = securityTicket.TenantID;
            bpartAssociated.Save(Connection, Transaction);
            

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5EM_SETI_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5EM_SETI_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_SETI_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_SETI_1657 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Employee_TaxInformation",ex);
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
FR_Guid cls_Save_Employee_TaxInformation(,P_L5EM_SETI_1657 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Employee_TaxInformation.Invoke(connectionString,P_L5EM_SETI_1657 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Atomic.Manipulation.P_L5EM_SETI_1657();
parameter.CMN_BPT_EMP_Employee_TaxInformationID = ...;
parameter.CMN_PER_PersonInfoID = ...;
parameter.EmployeeID = ...;
parameter.ReligionID = ...;
parameter.TaxNumber = ...;
parameter.TaxClass = ...;
parameter.NumberOfChildren = ...;
parameter.TaxExemptionAmount = ...;
parameter.ACC_TAX_TaxOfficeID = ...;
parameter.CMN_BPT_BusinessParticipantID = ...;

*/