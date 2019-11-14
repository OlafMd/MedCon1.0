/* 
 * Generated on 9/16/2014 9:27:46 AM
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
using CL1_PPS_TSK;
using CL1_CMN_BPT_EMP;
using CL1_PPS_DEV;
using CL1_HEC_HIS;
using CL1_HEC;
using CL1_CMN_CAL_EVT;

namespace CL6_MyHealthClub_Dashboard.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllPagesMissingData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPagesMissingData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DA_GAPMDfTID_1353 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6DA_GAPMDfTID_1353();
			//Put your code here
            returnValue.Result = new L6DA_GAPMDfTID_1353();

            if (ORM_CMN_STR_Office.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.OrgUnitsHaveElements = true;
            }
            else
            {
                returnValue.Result.OrgUnitsHaveElements = false;
            }

            if (ORM_PPS_TSK_Task_Template.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.AppointmentTypesHaveElements = true;
            }
            else
            {
                returnValue.Result.AppointmentTypesHaveElements = false;
            }

            if (ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, new ORM_CMN_BPT_EMP_Employee.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.StaffMemberHaveElements = true;
            }
            else
            {
                returnValue.Result.StaffMemberHaveElements = false;
            }

            if (ORM_PPS_DEV_Device.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.DevicesHaveElements = true;
            }
            else
            {
                returnValue.Result.DevicesHaveElements = false;
            }

            if (ORM_PPS_DEV_Device_Instance.Query.Search(Connection, Transaction, new ORM_PPS_DEV_Device_Instance.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.DeviceInstanceHaveElements = true;
            }
            else
            {
                returnValue.Result.DeviceInstanceHaveElements = false;
            }

            if (ORM_CMN_STR_Profession.Query.Search(Connection, Transaction, new ORM_CMN_STR_Profession.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.StaffTypesHaveElements = true;
            }
            else
            {
                returnValue.Result.StaffTypesHaveElements = false;
            }

            if (ORM_CMN_STR_Skill.Query.Search(Connection, Transaction, new ORM_CMN_STR_Skill.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.StaffSkillHaveElements = true;
            }
            else
            {
                returnValue.Result.StaffSkillHaveElements = false;
            }

            if (ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, new ORM_HEC_HIS_HealthInsurance_Company.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.HICompanyHaveElements = true;
            }
            else
            {
                returnValue.Result.HICompanyHaveElements = false;
            }

            if (ORM_HEC_Patient_HealthInsurance_State.Query.Search(Connection, Transaction, new ORM_HEC_Patient_HealthInsurance_State.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.HIStateHaveElements = true;
            }
            else
            {
                returnValue.Result.HIStateHaveElements = false;
            }

            if (ORM_CMN_CAL_EVT_Presentation.Query.Search(Connection, Transaction, new ORM_CMN_CAL_EVT_Presentation.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.EventsHaveElements = true;
            }
            else
            {
                returnValue.Result.EventsHaveElements = false;
            }

            if (ORM_HEC_MedicalPractice_Type.Query.Search(Connection, Transaction, new ORM_HEC_MedicalPractice_Type.Query
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).Count > 0)
            {
                returnValue.Result.MedicalPracticeHaveElements = true;
            }
            else
            {
                returnValue.Result.MedicalPracticeHaveElements = false;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DA_GAPMDfTID_1353 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DA_GAPMDfTID_1353 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DA_GAPMDfTID_1353 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DA_GAPMDfTID_1353 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DA_GAPMDfTID_1353 functionReturn = new FR_L6DA_GAPMDfTID_1353();
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

				throw new Exception("Exception occured in method cls_Get_AllPagesMissingData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DA_GAPMDfTID_1353 : FR_Base
	{
		public L6DA_GAPMDfTID_1353 Result	{ get; set; }

		public FR_L6DA_GAPMDfTID_1353() : base() {}

		public FR_L6DA_GAPMDfTID_1353(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6DA_GAPMDfTID_1353 for attribute L6DA_GAPMDfTID_1353
		[DataContract]
		public class L6DA_GAPMDfTID_1353 
		{
			//Standard type parameters
			[DataMember]
			public bool OrgUnitsHaveElements { get; set; } 
			[DataMember]
			public bool AppointmentTypesHaveElements { get; set; } 
			[DataMember]
			public bool StaffMemberHaveElements { get; set; } 
			[DataMember]
			public bool DeviceInstanceHaveElements { get; set; } 
			[DataMember]
			public bool MedicalPracticeHaveElements { get; set; } 
			[DataMember]
			public bool StaffTypesHaveElements { get; set; } 
			[DataMember]
			public bool StaffSkillHaveElements { get; set; } 
			[DataMember]
			public bool DevicesHaveElements { get; set; } 
			[DataMember]
			public bool HICompanyHaveElements { get; set; } 
			[DataMember]
			public bool HIStateHaveElements { get; set; } 
			[DataMember]
			public bool EventsHaveElements { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DA_GAPMDfTID_1353 cls_Get_AllPagesMissingData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DA_GAPMDfTID_1353 invocationResult = cls_Get_AllPagesMissingData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

