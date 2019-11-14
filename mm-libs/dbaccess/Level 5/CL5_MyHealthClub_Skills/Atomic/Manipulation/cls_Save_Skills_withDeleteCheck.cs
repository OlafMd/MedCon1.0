/* 
 * Generated on 8/12/2014 11:22:40 AM
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
using CL3_Skills.Atomic.Manipulation;
using CL1_CMN_STR;
using CL1_CMN_BPT_EMP;
using CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval;
using CL1_PPS_TSK;

namespace CL5_MyHealthClub_Skills.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Skills_withDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Skills_withDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SK_SSwDC_1618 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SK_SSwDC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5SK_SSwDC_1618();
			//Put your code here

            returnValue.Result = new L5SK_SSwDC_1618();

            Guid SkillId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                SkillId = cls_Save_Skill.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
            }
            else
            {
                List<ORM_CMN_STR_Skill_2_Profession> existingProfession = ORM_CMN_STR_Skill_2_Profession.Query.Search(Connection, Transaction, new ORM_CMN_STR_Skill_2_Profession.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Skill_RefID = Parameter.BaseData.SkillID
                }).ToList();

                if (existingProfession.Count > 0) //cannot delete
                {
                    List<L5SK_SSwDC_1618_UsedInProfession> usedProfessionList = new List<L5SK_SSwDC_1618_UsedInProfession>();

                    foreach (var profession in existingProfession)
                    {
                        ORM_CMN_STR_Profession professionName = ORM_CMN_STR_Profession.Query.Search(Connection,Transaction, new ORM_CMN_STR_Profession.Query{
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            CMN_STR_ProfessionID = profession.Profession_RefID
                        }).Single();
                        usedProfessionList.Add(new L5SK_SSwDC_1618_UsedInProfession { ProfessionName = professionName.ProfessionName });
                    }
                    returnValue.Result.UsedInProfession = usedProfessionList.ToArray();
                }

                List<ORM_CMN_BPT_EMP_Employee_2_Skill> existingEmployee = ORM_CMN_BPT_EMP_Employee_2_Skill.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee_2_Skill.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Skill_RefID = Parameter.BaseData.SkillID
                }).ToList();

                if (existingEmployee.Count > 0) //cannot delete
                {
                    List<L5SK_SSwDC_1618_UsedInEmployee> usedEmployeeList = new List<L5SK_SSwDC_1618_UsedInEmployee>();

                    foreach (var employee in existingEmployee)
                    {
                        L5DO_GSNfEID_1107 employeeName = cls_Get_Staff_Name_for_EmployeeID.Invoke(Connection, Transaction, new P_L5DO_GSNfEID_1107 { EmployeeID = employee.Employee_RefID }, securityTicket).Result;
                        string fullName = employeeName.FirstName + " " + employeeName.LastName;
                        usedEmployeeList.Add(new L5SK_SSwDC_1618_UsedInEmployee { EmployeeName = fullName });
                    }
                    returnValue.Result.UsedInEmployee = usedEmployeeList.ToArray();
                }

                List<Guid> skillInAppointmentType = ORM_PPS_TSK_Task_RequiredStaff_Skill.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff_Skill.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    CMN_STR_Skill_RefID = Parameter.BaseData.SkillID
                }).Select(x=>x.RequiredStaff_RefID).ToList();

                if (skillInAppointmentType.Count > 0)
                {
                    List<L5SK_SSwDC_1618_UsedInAppointmentType> usedAppointmentTypeList = new List<L5SK_SSwDC_1618_UsedInAppointmentType>();

                    List<Guid> skillInStaff = ORM_PPS_TSK_Task_RequiredStaff.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_RequiredStaff.Query
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                    }).Where(x => skillInAppointmentType.Contains(x.PPS_TSK_Task_RequiredStaffID)).Select(a => a.TaskTemplate_RefID).ToList();

                    List<ORM_PPS_TSK_Task_Template> appointmentTypeList = ORM_PPS_TSK_Task_Template.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template.Query
                    {
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID,
                    }).Where(x => skillInStaff.Contains(x.PPS_TSK_Task_TemplateID)).ToList();

                    foreach (var appointmentType in appointmentTypeList)
                    {
                        usedAppointmentTypeList.Add(new L5SK_SSwDC_1618_UsedInAppointmentType { AppointmentTypeName = appointmentType.TaskTemplateName });
                    }

                    returnValue.Result.UsedInAppointmentType = usedAppointmentTypeList.ToArray();
                }

                if (existingProfession.Count == 0 && existingEmployee.Count == 0 && skillInAppointmentType.Count == 0)
                {
                    SkillId = cls_Save_Skill.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                }
            }
            returnValue.Result.ID = SkillId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SK_SSwDC_1618 Invoke(string ConnectionString,P_L5SK_SSwDC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SK_SSwDC_1618 Invoke(DbConnection Connection,P_L5SK_SSwDC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SK_SSwDC_1618 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SK_SSwDC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SK_SSwDC_1618 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SK_SSwDC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SK_SSwDC_1618 functionReturn = new FR_L5SK_SSwDC_1618();
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

				throw new Exception("Exception occured in method cls_Save_Skills_withDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SK_SSwDC_1618 : FR_Base
	{
		public L5SK_SSwDC_1618 Result	{ get; set; }

		public FR_L5SK_SSwDC_1618() : base() {}

		public FR_L5SK_SSwDC_1618(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SK_SSwDC_1618 for attribute P_L5SK_SSwDC_1618
		[DataContract]
		public class P_L5SK_SSwDC_1618 
		{
			//Standard type parameters
			[DataMember]
			public P_L3S_SS_1408 BaseData { get; set; } 

		}
		#endregion
		#region SClass L5SK_SSwDC_1618 for attribute L5SK_SSwDC_1618
		[DataContract]
		public class L5SK_SSwDC_1618 
		{
			[DataMember]
			public L5SK_SSwDC_1618_UsedInProfession[] UsedInProfession { get; set; }
			[DataMember]
			public L5SK_SSwDC_1618_UsedInEmployee[] UsedInEmployee { get; set; }
			[DataMember]
			public L5SK_SSwDC_1618_UsedInAppointmentType[] UsedInAppointmentType { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5SK_SSwDC_1618_UsedInProfession for attribute UsedInProfession
		[DataContract]
		public class L5SK_SSwDC_1618_UsedInProfession 
		{
			//Standard type parameters
			[DataMember]
			public Dict ProfessionName { get; set; } 

		}
		#endregion
		#region SClass L5SK_SSwDC_1618_UsedInEmployee for attribute UsedInEmployee
		[DataContract]
		public class L5SK_SSwDC_1618_UsedInEmployee 
		{
			//Standard type parameters
			[DataMember]
			public String EmployeeName { get; set; } 

		}
		#endregion
		#region SClass L5SK_SSwDC_1618_UsedInAppointmentType for attribute UsedInAppointmentType
		[DataContract]
		public class L5SK_SSwDC_1618_UsedInAppointmentType 
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
FR_L5SK_SSwDC_1618 cls_Save_Skills_withDeleteCheck(,P_L5SK_SSwDC_1618 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SK_SSwDC_1618 invocationResult = cls_Save_Skills_withDeleteCheck.Invoke(connectionString,P_L5SK_SSwDC_1618 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Skills.Atomic.Manipulation.P_L5SK_SSwDC_1618();
parameter.BaseData = ...;

*/
