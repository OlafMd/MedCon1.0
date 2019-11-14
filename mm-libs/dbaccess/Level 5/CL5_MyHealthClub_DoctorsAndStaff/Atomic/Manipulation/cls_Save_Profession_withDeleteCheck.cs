/* 
 * Generated on 8/12/2014 9:12:32 AM
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
using CL3_Profession.Atomic.Manipulation;
using CL1_CMN_BPT_EMP;
using CL1_PPS_TSK;
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval;

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Profession_withDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Profession_withDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_SPwDC_1515 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_SPwDC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5DO_SPwDC_1515();
			//Put your code here

            returnValue.Result = new L5DO_SPwDC_1515();

            Guid ProfessionId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                ProfessionId = cls_Save_Profession.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
            }
            else
            {
                List<ORM_CMN_BPT_EMP_Employee_2_Profession> existingEmployee = ORM_CMN_BPT_EMP_Employee_2_Profession.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Profession.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Profession_RefID = Parameter.BaseData.StaffTypeID
                }).ToList();

                if (existingEmployee.Count > 0) //cannot delete
                {
                    List<L5DO_SPwDC_1515_UsedInEmployee> usedEmployeeList = new List<L5DO_SPwDC_1515_UsedInEmployee>();

                    foreach (var employee in existingEmployee)
                    {
                        L5DO_GSNfEID_1107 employeeName = cls_Get_Staff_Name_for_EmployeeID.Invoke(Connection, Transaction, new P_L5DO_GSNfEID_1107 { EmployeeID = employee.Employee_RefID }, securityTicket).Result;
                        string fullName = employeeName.FirstName + " " + employeeName.LastName;
                        usedEmployeeList.Add(new L5DO_SPwDC_1515_UsedInEmployee { EmployeeName = fullName });
                    }
                    returnValue.Result.UsedInEmployee = usedEmployeeList.ToArray();
                }

                List<ORM_PPS_TSK_Task_RequiredStaff_Profession> existingAppointmentType = ORM_PPS_TSK_Task_RequiredStaff_Profession.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Profession.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_STR_Profession_RefID = Parameter.BaseData.StaffTypeID
                }).ToList();

                if (existingAppointmentType.Count > 0) //cannot delete
                {
                    List<L5DO_SPwDC_1515_UsedInAppointmentType> usedAppointmentTypeList = new List<L5DO_SPwDC_1515_UsedInAppointmentType>();

                    foreach (var appointmentType in existingAppointmentType)
                    {
                        ORM_PPS_TSK_Task_RequiredStaff reqStaff = ORM_PPS_TSK_Task_RequiredStaff.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_Task_RequiredStaffID = appointmentType.RequiredStaff_RefID 
                        }).Single();
                        ORM_PPS_TSK_Task_Template appointmentTypeName = ORM_PPS_TSK_Task_Template.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            PPS_TSK_Task_TemplateID = reqStaff.TaskTemplate_RefID
                        }).Single();
                        usedAppointmentTypeList.Add(new L5DO_SPwDC_1515_UsedInAppointmentType { AppointmentTypeName = appointmentTypeName.TaskTemplateName });
                    }

                    returnValue.Result.UsedInAppointmentType = usedAppointmentTypeList.ToArray();
                }

                if (existingEmployee.Count == 0 && existingAppointmentType.Count == 0)
                {
                    ProfessionId = cls_Save_Profession.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                }
            }
            returnValue.Result.ID = ProfessionId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DO_SPwDC_1515 Invoke(string ConnectionString,P_L5DO_SPwDC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_SPwDC_1515 Invoke(DbConnection Connection,P_L5DO_SPwDC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_SPwDC_1515 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_SPwDC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_SPwDC_1515 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_SPwDC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_SPwDC_1515 functionReturn = new FR_L5DO_SPwDC_1515();
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

				throw new Exception("Exception occured in method cls_Save_Profession_withDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_SPwDC_1515 : FR_Base
	{
		public L5DO_SPwDC_1515 Result	{ get; set; }

		public FR_L5DO_SPwDC_1515() : base() {}

		public FR_L5DO_SPwDC_1515(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_SPwDC_1515 for attribute P_L5DO_SPwDC_1515
		[DataContract]
		public class P_L5DO_SPwDC_1515 
		{
			//Standard type parameters
			[DataMember]
			public P_L3P_SP_1653 BaseData { get; set; } 

		}
		#endregion
		#region SClass L5DO_SPwDC_1515 for attribute L5DO_SPwDC_1515
		[DataContract]
		public class L5DO_SPwDC_1515 
		{
			[DataMember]
			public L5DO_SPwDC_1515_UsedInAppointmentType[] UsedInAppointmentType { get; set; }
			[DataMember]
			public L5DO_SPwDC_1515_UsedInEmployee[] UsedInEmployee { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5DO_SPwDC_1515_UsedInAppointmentType for attribute UsedInAppointmentType
		[DataContract]
		public class L5DO_SPwDC_1515_UsedInAppointmentType 
		{
			//Standard type parameters
			[DataMember]
			public Dict AppointmentTypeName { get; set; } 

		}
		#endregion
		#region SClass L5DO_SPwDC_1515_UsedInEmployee for attribute UsedInEmployee
		[DataContract]
		public class L5DO_SPwDC_1515_UsedInEmployee 
		{
			//Standard type parameters
			[DataMember]
			public String EmployeeName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_SPwDC_1515 cls_Save_Profession_withDeleteCheck(,P_L5DO_SPwDC_1515 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_SPwDC_1515 invocationResult = cls_Save_Profession_withDeleteCheck.Invoke(connectionString,P_L5DO_SPwDC_1515 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Manipulation.P_L5DO_SPwDC_1515();
parameter.BaseData = ...;

*/
