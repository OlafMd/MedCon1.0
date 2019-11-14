/* 
 * Generated on 14.11.2014 11:00:23
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
using CL5_MyHealthClub_OrgUnits.Atomic.Manipulation;
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval;
using CL1_CMN_BPT_EMP;
using CL1_CMN_STR;
using CL1_PPS_TSK;
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;

namespace CL6_MyHealthClub_OrgUnits.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_OrgsUnitsGeneralData_wihtDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_OrgsUnitsGeneralData_wihtDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6OU_SOUGDwDC_1541 Execute(DbConnection Connection,DbTransaction Transaction,P_L6OU_SOUGDwDC_1541 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6OU_SOUGDwDC_1541();
			//Put your code here

            returnValue.Result = new L6OU_SOUGDwDC_1541();

            Guid OrgUnitId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                OrgUnitId = cls_Save_OrgsUnitsGeneralData.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;

                if(Parameter.UpdateSlots)
                    cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = OrgUnitId }, securityTicket);
            }
            else
            {
                List<ORM_PPS_TSK_Task_OfficeBooking> existingAppointment = ORM_PPS_TSK_Task_OfficeBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_OfficeBooking.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_STR_Office_RefID = Parameter.BaseData.OrgUnitID
                }).ToList();

                if (existingAppointment.Count > 0) //cannot delete
                {
                    List<L6OU_SOUGDwDC_1541_UsedInAppointment> usedAppointmentList = new List<L6OU_SOUGDwDC_1541_UsedInAppointment>();

                    foreach (var appointment in existingAppointment)
                    {
                        ORM_PPS_TSK_Task appointmentName = ORM_PPS_TSK_Task.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_TaskID = appointment.PPS_TSK_Task_RefID
                        }).Single();
                        usedAppointmentList.Add(new L6OU_SOUGDwDC_1541_UsedInAppointment { AppointmentName = appointmentName.DisplayName });
                    }
                    returnValue.Result.UsedInAppointment = usedAppointmentList.ToArray();
                }

                List<ORM_CMN_STR_Office> existingParentOrgUnit = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Parent_RefID = Parameter.BaseData.OrgUnitID
                }).ToList();

                if (existingParentOrgUnit.Count > 0) //cannot delete
                {
                    List<L6OU_SOUGDwDC_1541_UsedInOrgUnit> usedOrgUnitList = new List<L6OU_SOUGDwDC_1541_UsedInOrgUnit>();

                    foreach (var orgUnit in existingParentOrgUnit)
                    {
                        usedOrgUnitList.Add(new L6OU_SOUGDwDC_1541_UsedInOrgUnit { OrgUnitName = orgUnit.Office_Name });
                    }

                    returnValue.Result.UsedInOrgUnit = usedOrgUnitList.ToArray();
                }

                List<ORM_CMN_BPT_EMP_Employee_2_Office> existingEmployee = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Office.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_STR_Office_RefID = Parameter.BaseData.OrgUnitID
                }).ToList();

                if (existingEmployee.Count > 0) //cannot delete
                {
                    List<L6OU_SOUGDwDC_1541_UsedInEmployee> usedEmployeeList = new List<L6OU_SOUGDwDC_1541_UsedInEmployee>();

                    foreach (var employee in existingEmployee)
                    {
                        L5DO_GSNfEID_1107 employeeName = cls_Get_Staff_Name_for_EmployeeID.Invoke(Connection, Transaction, new P_L5DO_GSNfEID_1107 { EmployeeID = employee.CMN_BPT_EMP_Employee_RefID }, securityTicket).Result;
                        string fullName = employeeName.FirstName + " " + employeeName.LastName;
                        usedEmployeeList.Add(new L6OU_SOUGDwDC_1541_UsedInEmployee { EmployeeName = fullName });
                    }
                    returnValue.Result.UsedInEmployee = usedEmployeeList.ToArray();
                }

                if (existingAppointment.Count == 0 && existingParentOrgUnit.Count == 0 && existingEmployee.Count == 0)
                {
                    OrgUnitId = cls_Save_OrgsUnitsGeneralData.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;

                    if(Parameter.UpdateSlots)
                        cls_Delete_Slots_for_PracticeID.Invoke(Connection, Transaction, new P_L5BTS_DSfPID_1103() { OfficeID = Parameter.BaseData.OrgUnitID }, securityTicket);
                    
                }
            }
            returnValue.Result.ID = OrgUnitId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6OU_SOUGDwDC_1541 Invoke(string ConnectionString,P_L6OU_SOUGDwDC_1541 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6OU_SOUGDwDC_1541 Invoke(DbConnection Connection,P_L6OU_SOUGDwDC_1541 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6OU_SOUGDwDC_1541 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6OU_SOUGDwDC_1541 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6OU_SOUGDwDC_1541 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6OU_SOUGDwDC_1541 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6OU_SOUGDwDC_1541 functionReturn = new FR_L6OU_SOUGDwDC_1541();
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

				throw new Exception("Exception occured in method cls_Save_OrgsUnitsGeneralData_wihtDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6OU_SOUGDwDC_1541 : FR_Base
	{
		public L6OU_SOUGDwDC_1541 Result	{ get; set; }

		public FR_L6OU_SOUGDwDC_1541() : base() {}

		public FR_L6OU_SOUGDwDC_1541(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6OU_SOUGDwDC_1541 for attribute P_L6OU_SOUGDwDC_1541
		[DataContract]
		public class P_L6OU_SOUGDwDC_1541 
		{
			//Standard type parameters
			[DataMember]
			public P_L5OU_SOUGD_1221 BaseData { get; set; } 
			[DataMember]
			public bool UpdateSlots { get; set; } 

		}
		#endregion
		#region SClass L6OU_SOUGDwDC_1541 for attribute L6OU_SOUGDwDC_1541
		[DataContract]
		public class L6OU_SOUGDwDC_1541 
		{
			[DataMember]
			public L6OU_SOUGDwDC_1541_UsedInAppointment[] UsedInAppointment { get; set; }
			[DataMember]
			public L6OU_SOUGDwDC_1541_UsedInEmployee[] UsedInEmployee { get; set; }
			[DataMember]
			public L6OU_SOUGDwDC_1541_UsedInOrgUnit[] UsedInOrgUnit { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6OU_SOUGDwDC_1541_UsedInAppointment for attribute UsedInAppointment
		[DataContract]
		public class L6OU_SOUGDwDC_1541_UsedInAppointment 
		{
			//Standard type parameters
			[DataMember]
			public String AppointmentName { get; set; } 

		}
		#endregion
		#region SClass L6OU_SOUGDwDC_1541_UsedInEmployee for attribute UsedInEmployee
		[DataContract]
		public class L6OU_SOUGDwDC_1541_UsedInEmployee 
		{
			//Standard type parameters
			[DataMember]
			public String EmployeeName { get; set; } 

		}
		#endregion
		#region SClass L6OU_SOUGDwDC_1541_UsedInOrgUnit for attribute UsedInOrgUnit
		[DataContract]
		public class L6OU_SOUGDwDC_1541_UsedInOrgUnit 
		{
			//Standard type parameters
			[DataMember]
			public Dict OrgUnitName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6OU_SOUGDwDC_1541 cls_Save_OrgsUnitsGeneralData_wihtDeleteCheck(,P_L6OU_SOUGDwDC_1541 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6OU_SOUGDwDC_1541 invocationResult = cls_Save_OrgsUnitsGeneralData_wihtDeleteCheck.Invoke(connectionString,P_L6OU_SOUGDwDC_1541 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_OrgUnits.Complex.Manipulation.P_L6OU_SOUGDwDC_1541();
parameter.BaseData = ...;
parameter.UpdateSlots = ...;

*/
