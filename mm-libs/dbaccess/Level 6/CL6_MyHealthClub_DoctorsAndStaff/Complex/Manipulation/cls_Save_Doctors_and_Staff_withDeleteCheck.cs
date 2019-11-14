/* 
 * Generated on 14.11.2014 11:06:32
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
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation;
using CL1_CMN_BPT_EMP;
using CL1_PPS_TSK;
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;

namespace CL6_MyHealthClub_DoctorsAndStaff.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Doctors_and_Staff_withDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Doctors_and_Staff_withDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DO_SDaSwDC_1224 Execute(DbConnection Connection,DbTransaction Transaction,P_L6DO_SDaSwDC_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6DO_SDaSwDC_1224();
			//Put your code here

            returnValue.Result = new L6DO_SDaSwDC_1224();

            Guid EmployeeId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                EmployeeId = cls_Save_Doctors_and_Staff.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;

                if(Parameter.UpdateSlots)
                    foreach (var unit in Parameter.BaseData.OrgUnits)
                        cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = unit.CMN_STR_Office_RefID }, securityTicket);
            }
            else
            {
                ORM_CMN_BPT_EMP_Employee employee = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    BusinessParticipant_RefID = Parameter.BaseData.CMN_BPT_BusinessParticipantID
                }).Single();

                List<ORM_PPS_TSK_Task_RequiredStaff> existingAppointmentType = ORM_PPS_TSK_Task_RequiredStaff.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Required_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID
                }).ToList();

                if (existingAppointmentType.Count > 0) //cannot delete
                {
                    List<L6DO_SDaSwDC_1224_UsedInAppointmentType> usedAppointmentTypeList = new List<L6DO_SDaSwDC_1224_UsedInAppointmentType>();

                    foreach (var appointmentType in existingAppointmentType)
                    {
                        ORM_PPS_TSK_Task_Template appointmentTypeName = ORM_PPS_TSK_Task_Template.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template.Query{
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_Task_TemplateID = appointmentType.TaskTemplate_RefID
                        }).Single();

                        usedAppointmentTypeList.Add(new L6DO_SDaSwDC_1224_UsedInAppointmentType { AppointmentTypeName = appointmentTypeName.TaskTemplateName });
                    }
                    returnValue.Result.UsedInAppointmentType = usedAppointmentTypeList.ToArray();
                }

                List<ORM_PPS_TSK_Task_StaffBooking> existingAppointment = ORM_PPS_TSK_Task_StaffBooking.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_StaffBooking.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_BPT_EMP_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID
                }).ToList();

                if (existingAppointment.Count > 0) //cannot delete
                {
                    List<L6DO_SDaSwDC_1224_UsedInAppointment> usedAppointmentList = new List<L6DO_SDaSwDC_1224_UsedInAppointment>();

                    foreach (var appointment in existingAppointment)
                    {
                        ORM_PPS_TSK_Task appointmentName = ORM_PPS_TSK_Task.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_TaskID = appointment.PPS_TSK_Task_RefID
                        }).Single();

                        usedAppointmentList.Add(new L6DO_SDaSwDC_1224_UsedInAppointment { AppointmentName = appointmentName.DisplayName });
                    }
                    returnValue.Result.UsedInAppointment = usedAppointmentList.ToArray();
                }

                if (existingAppointment.Count == 0 && existingAppointmentType.Count == 0)
                {
                    EmployeeId = cls_Save_Doctors_and_Staff.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                    var emp = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query { BusinessParticipant_RefID = Parameter.BaseData.CMN_BPT_BusinessParticipantID, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                    var orgUnits = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Office.Query { CMN_BPT_EMP_Employee_RefID = emp.CMN_BPT_EMP_EmployeeID, Tenant_RefID = securityTicket.TenantID });
                    if(Parameter.UpdateSlots)
                        foreach (var unit in orgUnits)
                            cls_CreateUpdate_Slots_for_Practice.Invoke(Connection, Transaction, new P_L5S_SUSfP_1708() { PracticeID = unit.CMN_STR_Office_RefID }, securityTicket);
                }
            }
            returnValue.Result.ID = EmployeeId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DO_SDaSwDC_1224 Invoke(string ConnectionString,P_L6DO_SDaSwDC_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DO_SDaSwDC_1224 Invoke(DbConnection Connection,P_L6DO_SDaSwDC_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DO_SDaSwDC_1224 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DO_SDaSwDC_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DO_SDaSwDC_1224 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DO_SDaSwDC_1224 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DO_SDaSwDC_1224 functionReturn = new FR_L6DO_SDaSwDC_1224();
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

				throw new Exception("Exception occured in method cls_Save_Doctors_and_Staff_withDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DO_SDaSwDC_1224 : FR_Base
	{
		public L6DO_SDaSwDC_1224 Result	{ get; set; }

		public FR_L6DO_SDaSwDC_1224() : base() {}

		public FR_L6DO_SDaSwDC_1224(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DO_SDaSwDC_1224 for attribute P_L6DO_SDaSwDC_1224
		[DataContract]
		public class P_L6DO_SDaSwDC_1224 
		{
			//Standard type parameters
			[DataMember]
			public P_L5DO_SDaS_1604 BaseData { get; set; } 
			[DataMember]
			public bool UpdateSlots { get; set; } 

		}
		#endregion
		#region SClass L6DO_SDaSwDC_1224 for attribute L6DO_SDaSwDC_1224
		[DataContract]
		public class L6DO_SDaSwDC_1224 
		{
			[DataMember]
			public L6DO_SDaSwDC_1224_UsedInAppointment[] UsedInAppointment { get; set; }
			[DataMember]
			public L6DO_SDaSwDC_1224_UsedInAppointmentType[] UsedInAppointmentType { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6DO_SDaSwDC_1224_UsedInAppointment for attribute UsedInAppointment
		[DataContract]
		public class L6DO_SDaSwDC_1224_UsedInAppointment 
		{
			//Standard type parameters
			[DataMember]
			public String AppointmentName { get; set; } 

		}
		#endregion
		#region SClass L6DO_SDaSwDC_1224_UsedInAppointmentType for attribute UsedInAppointmentType
		[DataContract]
		public class L6DO_SDaSwDC_1224_UsedInAppointmentType 
		{
			//Standard type parameters
			[DataMember]
			public Dict AppointmentTypeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DO_SDaSwDC_1224 cls_Save_Doctors_and_Staff_withDeleteCheck(,P_L6DO_SDaSwDC_1224 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DO_SDaSwDC_1224 invocationResult = cls_Save_Doctors_and_Staff_withDeleteCheck.Invoke(connectionString,P_L6DO_SDaSwDC_1224 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_DoctorsAndStaff.Complex.Manipulation.P_L6DO_SDaSwDC_1224();
parameter.BaseData = ...;
parameter.UpdateSlots = ...;

*/
