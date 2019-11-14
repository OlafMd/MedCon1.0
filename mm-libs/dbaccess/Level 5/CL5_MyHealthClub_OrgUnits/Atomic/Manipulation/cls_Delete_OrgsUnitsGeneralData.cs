/* 
 * Generated on 5/29/2014 11:26:43 AM
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
using CL1_CMN;
using CL1_CMN_BPT_EMP;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_PPS_TSK;
using CL1_HEC;

namespace CL5_MyHealthClub_OrgUnits.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_OrgsUnitsGeneralData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_OrgsUnitsGeneralData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_DOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            foreach (var OrgUnitID in Parameter.OrgUnitID)
            {
                //delete  office
                var officeQuery = new ORM_CMN_STR_Office.Query();
                officeQuery.Tenant_RefID = securityTicket.TenantID;
                officeQuery.IsDeleted = false;
                officeQuery.CMN_STR_OfficeID = OrgUnitID;

                var office = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery).Single();
                //delete Medical practice type
                ORM_HEC_MedicalPractice_2_PracticeType.Query.SoftDelete(Connection, Transaction, new ORM_HEC_MedicalPractice_2_PracticeType.Query
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_MedicalPractice_RefID = office.IfMedicalPractise_HEC_MedicalPractice_RefID
                });
                office.IsDeleted = true;
                office.Save(Connection, Transaction);

                //delete Addresses

                var addressQuery = new ORM_CMN_STR_Office_Address.Query();
                addressQuery.IsDeleted = false;
                addressQuery.Tenant_RefID = securityTicket.TenantID;
                addressQuery.Office_RefID = OrgUnitID;

                var addressList = ORM_CMN_STR_Office_Address.Query.Search(Connection, Transaction, addressQuery).ToList();

                foreach (var address in addressList)
                {
                    address.IsDeleted = true;
                    address.Save(Connection, Transaction);

                    var addressDataQuery = new ORM_CMN_Address.Query();
                    addressDataQuery.IsDeleted = false;
                    addressDataQuery.CMN_AddressID = address.CMN_Address_RefID;

                    var addressData = ORM_CMN_Address.Query.Search(Connection, Transaction, addressDataQuery).Single();
                    addressData.IsDeleted = true;
                    addressData.Save(Connection, Transaction);
                }

                //delete Unit Speciality

                //var office_2_officeTypeQuery = new ORM_CMN_STR_Office_2_OfficeType.Query();
                //office_2_officeTypeQuery.IsDeleted = false;
                //office_2_officeTypeQuery.Office_RefID = OrgUnitID;

                //var office_2_officeType = ORM_CMN_STR_Office_2_OfficeType.Query.Search(Connection, Transaction, office_2_officeTypeQuery).First();
                //office_2_officeType.IsDeleted = true;
                //office_2_officeType.Save(Connection, Transaction);

                //delete contact person data
                var responsiblePersonQuery = new ORM_CMN_STR_Office_ResponsiblePerson.Query();
                responsiblePersonQuery.Office_RefID = OrgUnitID;
                responsiblePersonQuery.IsDeleted = false;

                var responsiblePerson = ORM_CMN_STR_Office_ResponsiblePerson.Query.Search(Connection, Transaction, responsiblePersonQuery).First();
                responsiblePerson.IsDeleted = true;
                responsiblePerson.Save(Connection, Transaction);

                var employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
                employeeQuery.IsDeleted = false;
                employeeQuery.CMN_BPT_EMP_EmployeeID = responsiblePerson.CMN_BPT_EMP_Employee_RefID;

                var employee = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, employeeQuery).Single();
                employee.IsDeleted = true;
                employee.Save(Connection, Transaction);

                var businessParticpantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                businessParticpantQuery.CMN_BPT_BusinessParticipantID = employee.BusinessParticipant_RefID;
                businessParticpantQuery.IsDeleted = false;

                var businessParticpant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticpantQuery).Single();
                businessParticpant.IsDeleted = true;
                businessParticpant.Save(Connection, Transaction);

                var personInfoQuery = new ORM_CMN_PER_PersonInfo.Query();
                personInfoQuery.CMN_PER_PersonInfoID = businessParticpant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfoQuery.IsDeleted = false;

                var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personInfoQuery).Single();
                personInfo.IsDeleted = true;
                personInfo.Save(Connection, Transaction);

                //delete all children
                var officeQueryChildren = new ORM_CMN_STR_Office.Query();
                officeQueryChildren.Tenant_RefID = securityTicket.TenantID;
                officeQueryChildren.IsDeleted = false;
                officeQueryChildren.Parent_RefID = OrgUnitID;

                //delete connection to appointmetn types

                var orgUnitToAppointmentTypeQuery = new ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query();
                orgUnitToAppointmentTypeQuery.CMN_STR_Office_RefID = OrgUnitID;
                orgUnitToAppointmentTypeQuery.Tenant_RefID = securityTicket.TenantID;
                orgUnitToAppointmentTypeQuery.IsDeleted = false;

                var orgUnitToAppointmentTypeList = ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query.Search(Connection, Transaction, orgUnitToAppointmentTypeQuery).ToList();

                foreach (var item in orgUnitToAppointmentTypeList)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }

                var officeChildrenList = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQueryChildren).ToList();

                if (officeChildrenList.Count > 0)
                {
                    List<Guid> guidList = new List<Guid>();
                    foreach (var officeChildren in officeChildrenList)
                    {
                        guidList.Add(officeChildren.CMN_STR_OfficeID);
                    }
                    cls_Delete_OrgsUnitsGeneralData.Invoke(Connection, Transaction, new P_L5OU_DOUGD_1221 { OrgUnitID = guidList.ToArray() }, securityTicket);
                }
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OU_DOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OU_DOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_DOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_DOUGD_1221 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_OrgsUnitsGeneralData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OU_DOUGD_1221 for attribute P_L5OU_DOUGD_1221
		[DataContract]
		public class P_L5OU_DOUGD_1221 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] OrgUnitID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_OrgsUnitsGeneralData(,P_L5OU_DOUGD_1221 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_OrgsUnitsGeneralData.Invoke(connectionString,P_L5OU_DOUGD_1221 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Manipulation.P_L5OU_DOUGD_1221();
parameter.OrgUnitID = ...;

*/
