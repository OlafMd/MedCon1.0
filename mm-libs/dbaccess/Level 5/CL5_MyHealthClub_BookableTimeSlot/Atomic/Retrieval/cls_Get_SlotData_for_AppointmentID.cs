/* 
 * Generated on 28.11.2014 12:01:26
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
using CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval;

namespace CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SlotData_for_AppointmentID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SlotData_for_AppointmentID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BTS_GSDfAID_1524 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BTS_GSDfAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BTS_GSDfAID_1524();

            var appointment = cls_Get_AllAppointment_Task_for_AppointmentID.Invoke(Connection, Transaction, new P_L5A_GAATfAID_1530() { AppointmentID = Parameter.AppointmentID }, securityTicket).Result;

            P_L5BTS_GBSfOTT_1618 slotParam = new P_L5BTS_GBSfOTT_1618()
            {
                OfficeID = appointment.Offices.CMN_STR_Office_RefID,
                StartTime = appointment.PlannedStartDate,
                TypeID = appointment.InstantiatedFrom_TaskTemplate_RefID
            };
            var slot = cls_Get_BookableSlot_for_OfficeTimeType.Invoke(Connection, Transaction, slotParam, securityTicket).Result;

            var usedCombinations = slot.Combinations.Where(c => !c.IsAvailable);


            L5BTS_GBSfOTT_1618_ResourceCombination selectedCombinaiton = null;
            foreach (var combination in usedCombinations)
            {
                bool isCombinationMatched = true;

                foreach (var emp in combination.Staff)
                {
                    if (appointment.Staff.SingleOrDefault(s => s.CMN_BPT_EMP_Employee_RefID == emp.CMN_BPT_EMP_Employee_RefID) == null)
                    {
                        isCombinationMatched = false;
                        break;
                    }
                }

                if (isCombinationMatched)
                {
                    foreach (var device in combination.Devices)
                    {
                        if (appointment.Devices.SingleOrDefault(s => s.PPS_DEV_Device_Instance_RefID == device.PPS_DEV_Device_Instance_RefID) == null)
                        {
                            isCombinationMatched = false;
                            break;
                        }
                    }
                }

                if (isCombinationMatched)
                    selectedCombinaiton = combination;
            }
            
            returnValue.Result = new L5BTS_GSDfAID_1524()
            {
                AppointmentTypeID = appointment.InstantiatedFrom_TaskTemplate_RefID,
                OfficeID = appointment.Offices.CMN_STR_Office_RefID,
                SlotID = slot.PPS_TSK_BOK_BookableTimeSlotID,
                SelectedCombinaitonID = selectedCombinaiton.PPS_TSK_BOK_AvailableResourceCombinationID,
                PatientID = appointment.Patients.Patient_RefID,
                Date = appointment.PlannedStartDate
                
            };

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BTS_GSDfAID_1524 Invoke(string ConnectionString,P_L5BTS_GSDfAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BTS_GSDfAID_1524 Invoke(DbConnection Connection,P_L5BTS_GSDfAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BTS_GSDfAID_1524 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BTS_GSDfAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BTS_GSDfAID_1524 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BTS_GSDfAID_1524 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BTS_GSDfAID_1524 functionReturn = new FR_L5BTS_GSDfAID_1524();
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

				throw new Exception("Exception occured in method cls_Get_SlotData_for_AppointmentID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BTS_GSDfAID_1524 : FR_Base
	{
		public L5BTS_GSDfAID_1524 Result	{ get; set; }

		public FR_L5BTS_GSDfAID_1524() : base() {}

		public FR_L5BTS_GSDfAID_1524(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BTS_GSDfAID_1524 for attribute P_L5BTS_GSDfAID_1524
		[DataContract]
		public class P_L5BTS_GSDfAID_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid AppointmentID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GSDfAID_1524 for attribute L5BTS_GSDfAID_1524
		[DataContract]
		public class L5BTS_GSDfAID_1524 
		{
			//Standard type parameters
			[DataMember]
			public Guid SlotID { get; set; } 
			[DataMember]
			public Guid SelectedCombinaitonID { get; set; } 
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public DateTime Date { get; set; } 
			[DataMember]
			public Guid AppointmentTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BTS_GSDfAID_1524 cls_Get_SlotData_for_AppointmentID(,P_L5BTS_GSDfAID_1524 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BTS_GSDfAID_1524 invocationResult = cls_Get_SlotData_for_AppointmentID.Invoke(connectionString,P_L5BTS_GSDfAID_1524 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval.P_L5BTS_GSDfAID_1524();
parameter.AppointmentID = ...;

*/
