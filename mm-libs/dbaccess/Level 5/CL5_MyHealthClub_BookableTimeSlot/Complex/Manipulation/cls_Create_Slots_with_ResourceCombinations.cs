/* 
 * Generated on 14.11.2014 11:22:03
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
using CL1_PPS_TSK_BOK;
using CL1_CMN_CAL_AVA;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;

namespace CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Slots_with_ResourceCombinations.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Slots_with_ResourceCombinations
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L5BTS_CSwRC_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();

            var webAvailabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query()
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.WebBooking),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var standardAvailabilityType = ORM_CMN_CAL_AVA_Availability_Type.Query.Search(Connection, Transaction, new ORM_CMN_CAL_AVA_Availability_Type.Query()
            {
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(AvailabilityType.Standard),
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).Single();

            var slot2ATs = ORM_PPS_TSK_BOK_BookableTimeSlots_2_AvailabilityType.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_BookableTimeSlots_2_AvailabilityType.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).ToArray();

            foreach (var time in Parameter.Slots)
            {
                var slot = ORM_PPS_TSK_BOK_BookableTimeSlot.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_BookableTimeSlot.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    PPS_TSK_BOK_BookableTimeSlotID = time.SlotID,
                    TaskTemplate_RefID = Parameter.AppointmentTypeID,
                    Office_RefID = Parameter.OfficeID
                }).SingleOrDefault();
                if (slot == null)
                {
                    slot = new ORM_PPS_TSK_BOK_BookableTimeSlot()
                    {
                        PPS_TSK_BOK_BookableTimeSlotID = Guid.NewGuid(),
                        FreeSlotsForTaskTemplateITPL = Guid.NewGuid().ToString(),
                        FreeInterval_Start = time.Start,
                        FreeInterval_End = time.End,
                        Office_RefID = Parameter.OfficeID,
                        TaskTemplate_RefID = Parameter.AppointmentTypeID,
                        Tenant_RefID = securityTicket.TenantID
                    };
                }

                var slot2AT = slot2ATs.SingleOrDefault(s => s.PPS_TSK_BOK_BookableTimeSlot_RefID == slot.PPS_TSK_BOK_BookableTimeSlotID);

                if (slot2AT == null)
                {
                    slot2AT = new ORM_PPS_TSK_BOK_BookableTimeSlots_2_AvailabilityType()
                    {
                        CMN_CAL_AVA_Availability_TypeID = time.IsWebBookable ? webAvailabilityType.CMN_CAL_AVA_Availability_TypeID : standardAvailabilityType.CMN_CAL_AVA_Availability_TypeID,
                        AssignmentID = Guid.NewGuid(),
                        Tenant_RefID = securityTicket.TenantID,
                        PPS_TSK_BOK_BookableTimeSlot_RefID = slot.PPS_TSK_BOK_BookableTimeSlotID,                           
                    };
                    slot2AT.Save(Connection, Transaction);
                }
                else
                {
                    if (slot2AT.CMN_CAL_AVA_Availability_TypeID != webAvailabilityType.CMN_CAL_AVA_Availability_TypeID && time.IsWebBookable)
                    {
                        slot2AT.CMN_CAL_AVA_Availability_TypeID = webAvailabilityType.CMN_CAL_AVA_Availability_TypeID;
                        slot2AT.Save(Connection, Transaction);
                    }
                    if (slot2AT.CMN_CAL_AVA_Availability_TypeID != standardAvailabilityType.CMN_CAL_AVA_Availability_TypeID && !time.IsWebBookable)
                    {
                        slot2AT.CMN_CAL_AVA_Availability_TypeID = standardAvailabilityType.CMN_CAL_AVA_Availability_TypeID;
                        slot2AT.Save(Connection, Transaction);
                    }

                }

                slot.Save(Connection, Transaction);

                foreach (var combination in time.Combinations)
                {
                    var resourceCombination = new ORM_PPS_TSK_BOK_AvailableResourceCombination()
                    {
                        PPS_TSK_BOK_AvailableResourceCombinationID = Guid.NewGuid(),
                        BookableTimeSlot_RefID = slot.PPS_TSK_BOK_BookableTimeSlotID,
                        IsAvailable = true,
                        Tenant_RefID = securityTicket.TenantID
                    };
                    resourceCombination.Save(Connection, Transaction);

                    foreach (var device in combination.DeviceInstance)
                    {
                        var reqDeviceInstance = new ORM_PPS_TSK_BOK_DeviceResource()
                        {
                            PPS_TSK_BOK_DeviceResourceID = Guid.NewGuid(),
                            PPS_DEV_Device_Instance_RefID = device.DeviceInstanceID,
                            AvailableResourceCombination_RefID = resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        reqDeviceInstance.Save(Connection, Transaction);
                    }

                    foreach (var staff in combination.Staff)
                    {
                        var reqStaff = new ORM_PPS_TSK_BOK_StaffResource()
                        {
                            PPS_TSK_BOK_StaffResourceID = Guid.NewGuid(),
                            CMN_BPT_EMP_Employee_RefID = staff.StaffID,
                            CreatedFor_TaskTemplateRequiredStaff_RefID = staff.CreatedFor_TaskTemplateRequiredStaff_RefID,
                            AvailableResourceCombination_RefID = resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID,
                            Tenant_RefID = securityTicket.TenantID
                        };
                        reqStaff.Save(Connection, Transaction);
                    }
                }

                if(time.CombinationForDelete != null)
                    foreach (var combinationID in time.CombinationForDelete.CombinationIDs)
                    {
                        var resourceCombination = ORM_PPS_TSK_BOK_AvailableResourceCombination.Query.Search(Connection, Transaction, new ORM_PPS_TSK_BOK_AvailableResourceCombination.Query()
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            BookableTimeSlot_RefID = slot.PPS_TSK_BOK_BookableTimeSlotID,
                            PPS_TSK_BOK_AvailableResourceCombinationID = combinationID
                        }).SingleOrDefault();
                        if (resourceCombination != null)
                        {
                            ORM_PPS_TSK_BOK_StaffResource.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_BOK_StaffResource.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                AvailableResourceCombination_RefID = resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID
                            });

                            ORM_PPS_TSK_BOK_DeviceResource.Query.SoftDelete(Connection, Transaction, new ORM_PPS_TSK_BOK_DeviceResource.Query()
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                AvailableResourceCombination_RefID = resourceCombination.PPS_TSK_BOK_AvailableResourceCombinationID
                            });

                            resourceCombination.IsDeleted = true;
                            resourceCombination.Save(Connection, Transaction);
                        }
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
		public static FR_Base Invoke(string ConnectionString,P_L5BTS_CSwRC_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L5BTS_CSwRC_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BTS_CSwRC_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BTS_CSwRC_1156 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Create_Slots_with_ResourceCombinations",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BTS_CSwRC_1156 for attribute P_L5BTS_CSwRC_1156
		[DataContract]
		public class P_L5BTS_CSwRC_1156 
		{
			[DataMember]
			public P_L5BTS_CSwRC_1156_Slot[] Slots { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid AppointmentTypeID { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_CSwRC_1156_Slot for attribute Slots
		[DataContract]
		public class P_L5BTS_CSwRC_1156_Slot 
		{
			[DataMember]
			public P_L5BTS_CSwRC_1156_Slot_Combination[] Combinations { get; set; }
			[DataMember]
			public P_L5BTS_CSwRC_1156_Slot_CombinationsForDelete CombinationForDelete { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid SlotID { get; set; } 
			[DataMember]
			public DateTime Start { get; set; } 
			[DataMember]
			public DateTime End { get; set; } 
			[DataMember]
			public bool IsWebBookable { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_CSwRC_1156_Slot_Combination for attribute Combinations
		[DataContract]
		public class P_L5BTS_CSwRC_1156_Slot_Combination 
		{
			[DataMember]
			public P_L5BTS_CSwRC_1156_Slot_Combination_DeviceInstance[] DeviceInstance { get; set; }
			[DataMember]
			public P_L5BTS_CSwRC_1156_Slot_Combination_Staff[] Staff { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass P_L5BTS_CSwRC_1156_Slot_Combination_DeviceInstance for attribute DeviceInstance
		[DataContract]
		public class P_L5BTS_CSwRC_1156_Slot_Combination_DeviceInstance 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeviceInstanceID { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_CSwRC_1156_Slot_Combination_Staff for attribute Staff
		[DataContract]
		public class P_L5BTS_CSwRC_1156_Slot_Combination_Staff 
		{
			//Standard type parameters
			[DataMember]
			public Guid StaffID { get; set; } 
			[DataMember]
			public Guid CreatedFor_TaskTemplateRequiredStaff_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L5BTS_CSwRC_1156_Slot_CombinationsForDelete for attribute CombinationForDelete
		[DataContract]
		public class P_L5BTS_CSwRC_1156_Slot_CombinationsForDelete 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CombinationIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Create_Slots_with_ResourceCombinations(,P_L5BTS_CSwRC_1156 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Create_Slots_with_ResourceCombinations.Invoke(connectionString,P_L5BTS_CSwRC_1156 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Complex.Manipulation.P_L5BTS_CSwRC_1156();
parameter.Slots = ...;

parameter.OfficeID = ...;
parameter.AppointmentTypeID = ...;

*/
