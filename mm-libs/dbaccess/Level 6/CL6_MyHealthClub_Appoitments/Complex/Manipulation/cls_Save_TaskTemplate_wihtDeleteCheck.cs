/* 
 * Generated on 14.11.2014 11:09:04
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
using CL5_MyHealthClub_TaskTemplate.Atomic.Manipulation;
using CL1_PPS_TSK;
using CL1_CMN_STR;
using CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation;

namespace CL6_MyHealthClub_Appoitments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TaskTemplate_wihtDeleteCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TaskTemplate_wihtDeleteCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6TA_STTwDC_1146 Execute(DbConnection Connection,DbTransaction Transaction,P_L6TA_STTwDC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6TA_STTwDC_1146();
			//Put your code here

            returnValue.Result = new L6TA_STTwDC_1146();

            Guid AppointmentTypeId = Guid.Empty;
            if (!Parameter.BaseData.IsDeleted)
            {
                AppointmentTypeId = cls_Save_TaskTemplate.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                
                if(Parameter.UpdateSlots)
                    cls_Update_Slots_for_AppointmentTypeChange.Invoke(Connection, Transaction, new P_L5S_CSfATC_1242() { AppointmentTypeID = AppointmentTypeId }, securityTicket);
            }
            else
            {
                List<ORM_PPS_TSK_Task> existingAppointment = ORM_PPS_TSK_Task.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    InstantiatedFrom_TaskTemplate_RefID = Parameter.BaseData.PPS_TSK_Task_TemplateID
                }).ToList();

                if (existingAppointment.Count > 0) //cannot delete
                {
                    List<L6TA_STTwDC_1146_UsedInAppointment> usedAppointmentList = new List<L6TA_STTwDC_1146_UsedInAppointment>();

                    foreach (var appointment in existingAppointment)
                    {
                        usedAppointmentList.Add(new L6TA_STTwDC_1146_UsedInAppointment { AppointmentName = appointment.DisplayName });
                    }
                    returnValue.Result.UsedInAppointment = usedAppointmentList.ToArray();
                }

                List<ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability> existingOrgUnit = ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query.Search(Connection, Transaction, new ORM_PPS_TSK_Task_Template_OrganizationalUnitAvailability.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    PPS_TSK_Task_Template_RefID = Parameter.BaseData.PPS_TSK_Task_TemplateID
                }).ToList();

                if (existingOrgUnit.Count > 0) //cannot delete
                {
                    List<L6TA_STTwDC_1146_UsedInOrgUnit> usedOrgUnitList = new List<L6TA_STTwDC_1146_UsedInOrgUnit>();

                    foreach (var orgUnit in existingOrgUnit)
                    {
                        ORM_CMN_STR_Office officeName = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office.Query
                        {
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID,
                            CMN_STR_OfficeID = orgUnit.CMN_STR_Office_RefID
                        }).Single();

                        usedOrgUnitList.Add(new L6TA_STTwDC_1146_UsedInOrgUnit { OrgUnitName = officeName.Office_Name });
                    }

                    returnValue.Result.UsedInOrgUnit = usedOrgUnitList.ToArray();
                }

                if (existingAppointment.Count == 0 && existingOrgUnit.Count == 0)
                {
                    AppointmentTypeId = cls_Save_TaskTemplate.Invoke(Connection, Transaction, Parameter.BaseData, securityTicket).Result;
                    if(Parameter.UpdateSlots)
                        cls_Delete_Slots_for_AppointmentTypeID.Invoke(Connection, Transaction, new P_L5BTS_DSfATID_1111() { AppointmentTypeID = Parameter.BaseData.PPS_TSK_Task_TemplateID }, securityTicket);
                }
            }
            returnValue.Result.ID = AppointmentTypeId;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6TA_STTwDC_1146 Invoke(string ConnectionString,P_L6TA_STTwDC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6TA_STTwDC_1146 Invoke(DbConnection Connection,P_L6TA_STTwDC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6TA_STTwDC_1146 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TA_STTwDC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6TA_STTwDC_1146 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TA_STTwDC_1146 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6TA_STTwDC_1146 functionReturn = new FR_L6TA_STTwDC_1146();
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

				throw new Exception("Exception occured in method cls_Save_TaskTemplate_wihtDeleteCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6TA_STTwDC_1146 : FR_Base
	{
		public L6TA_STTwDC_1146 Result	{ get; set; }

		public FR_L6TA_STTwDC_1146() : base() {}

		public FR_L6TA_STTwDC_1146(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6TA_STTwDC_1146 for attribute P_L6TA_STTwDC_1146
		[DataContract]
		public class P_L6TA_STTwDC_1146 
		{
			//Standard type parameters
			[DataMember]
			public P_L5TA_STT_1548 BaseData { get; set; } 
			[DataMember]
			public bool UpdateSlots { get; set; } 

		}
		#endregion
		#region SClass L6TA_STTwDC_1146 for attribute L6TA_STTwDC_1146
		[DataContract]
		public class L6TA_STTwDC_1146 
		{
			[DataMember]
			public L6TA_STTwDC_1146_UsedInAppointment[] UsedInAppointment { get; set; }
			[DataMember]
			public L6TA_STTwDC_1146_UsedInOrgUnit[] UsedInOrgUnit { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L6TA_STTwDC_1146_UsedInAppointment for attribute UsedInAppointment
		[DataContract]
		public class L6TA_STTwDC_1146_UsedInAppointment 
		{
			//Standard type parameters
			[DataMember]
			public String AppointmentName { get; set; } 

		}
		#endregion
		#region SClass L6TA_STTwDC_1146_UsedInOrgUnit for attribute UsedInOrgUnit
		[DataContract]
		public class L6TA_STTwDC_1146_UsedInOrgUnit 
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
FR_L6TA_STTwDC_1146 cls_Save_TaskTemplate_wihtDeleteCheck(,P_L6TA_STTwDC_1146 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6TA_STTwDC_1146 invocationResult = cls_Save_TaskTemplate_wihtDeleteCheck.Invoke(connectionString,P_L6TA_STTwDC_1146 Parameter,securityTicket);
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
var parameter = new CL6_MyHealthClub_Appoitments.Complex.Manipulation.P_L6TA_STTwDC_1146();
parameter.BaseData = ...;
parameter.UpdateSlots = ...;

*/
