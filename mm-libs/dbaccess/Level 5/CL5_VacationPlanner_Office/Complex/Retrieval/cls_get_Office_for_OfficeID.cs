/* 
 * Generated on 1/9/2014 2:11:17 PM
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
using CL5_VacationPlanner_Office.Atomic.Retrieval;
using CL1_CMN_STR;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using CL1_CMN_PER;
using CL1_CMN;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Office.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_Office_for_OfficeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Office_for_OfficeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OF_GOFID_1340 Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_GOFID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5OF_GOFID_1340();
            L5OF_GOFT_1157 result=new L5OF_GOFT_1157(); 
            var item = new ORM_CMN_STR_Office();
			if (Parameter.OfficeID != Guid.Empty)
			{
                var resultOffice = item.Load(Connection, Transaction, Parameter.OfficeID);
                if (resultOffice.Status != FR_Status.Success || item.CMN_STR_OfficeID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
                    return null;
				
				}
			}
            result.CMN_CAL_CalendarInstance_RefID=item.CMN_CAL_CalendarInstance_RefID;
            result.CMN_STR_OfficeID=item.CMN_STR_OfficeID;
            result.Country_RefID=item.Country_RefID;
            result.Default_FaxNumber=item.Default_FaxNumber;
            result.Default_PhoneNumber=item.Default_PhoneNumber;
            result.Office_ShortName=item.Office_ShortName;
            result.OfficeDescription=item.Office_Description;
            result.OfficeName=item.Office_Name;
            result.Region_RefID=item.Region_RefID;
            result.BillingAddress_CMN_AddressID=item.Default_BillingAddress_RefID;
           


			var address = new ORM_CMN_Address();
				var resultItem = address.Load(Connection, Transaction, item.Default_BillingAddress_RefID);
                if (resultItem.Status != FR_Status.Success || address.CMN_AddressID == Guid.Empty)
				{
					var error = new FR_Guid();
					error.ErrorMessage = "No Such ID";
					error.Status = FR_Status.Error_Internal;
                    return null;
				}
			
			result.BillingAddress_City_Name = address.City_Name;
			result.BillingAddress_City_AdministrativeDistrict = address.City_AdministrativeDistrict;
			result.BillingAddress_City_PostalCode = address.City_PostalCode;
			result.BillingAddress_City_Region = address.City_Region;
			result.BillingAddress_Country_Name = address.Country_Name;
			result.BillingAddress_Province_Name = address.Province_Name;
			result.BillingAddress_Street_Name = address.Street_Name;
			result.BillingAddress_Street_Number = address.Street_Number;
            result.BillingAddress_Country_ISOCode=address.Country_ISOCode;




            ORM_CMN_STR_Office_2_CostCenter.Query officeToCostcenterQuery =new  ORM_CMN_STR_Office_2_CostCenter.Query();
            officeToCostcenterQuery.Office_RefID = Parameter.OfficeID;
            officeToCostcenterQuery.Tenant_RefID=securityTicket.TenantID;
            officeToCostcenterQuery.IsDeleted=false;
            List<ORM_CMN_STR_Office_2_CostCenter> officeToCostcenterList=ORM_CMN_STR_Office_2_CostCenter.Query.Search(Connection,Transaction,officeToCostcenterQuery);
            if(officeToCostcenterList.Count!=0){
                L5OF_GOFT_1157_Costcenter costCenter=new L5OF_GOFT_1157_Costcenter();
                ORM_CMN_STR_CostCenter costCenterItem=new ORM_CMN_STR_CostCenter();
                costCenterItem.Load(Connection, Transaction, officeToCostcenterList[0].CostCenter_RefID);
                if(!costCenterItem.IsDeleted){
                    costCenter.AssignmentID=officeToCostcenterList[0].AssignmentID;
                    costCenter.CMN_STR_CostCenterID=officeToCostcenterList[0].CostCenter_RefID;
                    costCenter.CostcenterName=costCenterItem.Name;
                    costCenter.InternalID=costCenterItem.InternalID;
                    result.Costcenter=costCenter;
                }
            }
            var responsiblePersonsQuery = new ORM_CMN_STR_Office_ResponsiblePerson.Query();
            responsiblePersonsQuery.Tenant_RefID = securityTicket.TenantID;
            responsiblePersonsQuery.Office_RefID = item.CMN_STR_OfficeID;
            responsiblePersonsQuery.IsDeleted=false;
            var responsiblePersonsList = ORM_CMN_STR_Office_ResponsiblePerson.Query.Search(Connection, Transaction, responsiblePersonsQuery);
            List<L5OF_GOFT_1157_ResponsiblePersons> responsiblePresonsResultList=new List<L5OF_GOFT_1157_ResponsiblePersons>();
                foreach(var responsiblePerson in responsiblePersonsList)
                {
                    L5OF_GOFT_1157_ResponsiblePersons responsiblePersonResult=new L5OF_GOFT_1157_ResponsiblePersons();
                    responsiblePersonResult.CMN_BPT_EMP_EmployeeID=responsiblePerson.CMN_BPT_EMP_Employee_RefID;
                    responsiblePersonResult.CMN_STR_Office_ResponsiblePersonID=responsiblePerson.CMN_STR_Office_ResponsiblePersonID;

                    ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
                    employee.Load(Connection, Transaction, responsiblePerson.CMN_BPT_EMP_Employee_RefID);

                    ORM_CMN_BPT_BusinessParticipant bParticipant=new ORM_CMN_BPT_BusinessParticipant();
                    bParticipant.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                    ORM_CMN_PER_PersonInfo person=new ORM_CMN_PER_PersonInfo();
                    person.Load(Connection, Transaction, bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID);

                    responsiblePersonResult.CMN_BPT_BusinessParticipantID=bParticipant.CMN_BPT_BusinessParticipantID;
                    responsiblePersonResult.FirstName=person.FirstName;
                    responsiblePersonResult.LastName=person.LastName;
                    responsiblePresonsResultList.Add(responsiblePersonResult);
                }         
            result.Managers=responsiblePresonsResultList.ToArray();
            returnValue.Result=new L5OF_GOFID_1340();
            returnValue.Result.office=result;
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OF_GOFID_1340 Invoke(string ConnectionString,P_L5OF_GOFID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFID_1340 Invoke(DbConnection Connection,P_L5OF_GOFID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OF_GOFID_1340 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_GOFID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OF_GOFID_1340 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_GOFID_1340 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OF_GOFID_1340 functionReturn = new FR_L5OF_GOFID_1340();
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

				throw new Exception("Exception occured in method cls_get_Office_for_OfficeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OF_GOFID_1340 : FR_Base
	{
		public L5OF_GOFID_1340 Result	{ get; set; }

		public FR_L5OF_GOFID_1340() : base() {}

		public FR_L5OF_GOFID_1340(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OF_GOFID_1340 cls_get_Office_for_OfficeID(,P_L5OF_GOFID_1340 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OF_GOFID_1340 invocationResult = cls_get_Office_for_OfficeID.Invoke(connectionString,P_L5OF_GOFID_1340 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Office.Complex.Retrieval.P_L5OF_GOFID_1340();
parameter.OfficeID = ...;

*/