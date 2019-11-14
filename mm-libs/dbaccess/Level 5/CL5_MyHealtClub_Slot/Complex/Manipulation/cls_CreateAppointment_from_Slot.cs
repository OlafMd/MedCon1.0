/* 
 * Generated on 09.10.2014 11:46:41
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
using CL5_MyHealtClub_Slot.Utils;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.MyHealthClub;
using CL5_MyHealtClub_Slot.Model;
using MHCWidget_Web.Models.Backoffice;
using CL5_MyHealthClub_TaskTemplate.Atomic.Manipulation;
using CL5_MyHealthClub_TimeAndException.Atomic.Retrieval;
using CL1_HEC;
using CL1_PPS_TSK;
using CL5_MyHealtClub_Slot.Model.AppointmentSpace;
using MHCWidget_Web.Models.Device;
using CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval;

namespace CL5_MyHealthClub_Slot.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CreateAppointment_from_Slot.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CreateAppointment_from_Slot
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5S_CAfS_1141 Execute(DbConnection Connection,DbTransaction Transaction,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5S_CAfS_1141();

           // var slot = cls_Get_Slots_for_SlotID.Invoke(Connection, Transaction, new P_L3TTS_SfSID_1211() { SlotID = Parameter.SlotID }, securityTicket).Result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5S_CAfS_1141 Invoke(string ConnectionString,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5S_CAfS_1141 Invoke(DbConnection Connection,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5S_CAfS_1141 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5S_CAfS_1141 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5S_CAfS_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5S_CAfS_1141 functionReturn = new FR_L5S_CAfS_1141();
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

				throw new Exception("Exception occured in method cls_CreateAppointment_from_Slot",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5S_CAfS_1141 : FR_Base
	{
		public L5S_CAfS_1141 Result	{ get; set; }

		public FR_L5S_CAfS_1141() : base() {}

		public FR_L5S_CAfS_1141(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5S_CAfS_1141 for attribute P_L5S_CAfS_1141
		[DataContract]
		public class P_L5S_CAfS_1141 
		{
			//Standard type parameters
			[DataMember]
			public Guid SlotID { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 

		}
		#endregion
		#region SClass L5S_CAfS_1141 for attribute L5S_CAfS_1141
		[DataContract]
		public class L5S_CAfS_1141 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5S_CAfS_1141 cls_CreateAppointment_from_Slot(,P_L5S_CAfS_1141 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5S_CAfS_1141 invocationResult = cls_CreateAppointment_from_Slot.Invoke(connectionString,P_L5S_CAfS_1141 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Slot.Complex.Manipulation.P_L5S_CAfS_1141();
parameter.SlotID = ...;
parameter.Patient_RefID = ...;

*/
