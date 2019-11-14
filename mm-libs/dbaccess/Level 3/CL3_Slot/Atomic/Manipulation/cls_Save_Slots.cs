/* 
 * Generated on 30.09.2014 14:25:36
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
using CL1_PPS_TSK;

namespace CL3_TaskTemplateSlot.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Slots.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Slots
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3TTS_SS_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Base();

            foreach (var time in Parameter.Times)
            {
                //var slot = new ORM_PPS_TSK_FreeSlotsForTaskTemplate()
                //{
                //    Tenant_RefID = securityTicket.TenantID,
                //    Office_RefID = Parameter.OfficeID,
                //    PPS_TSK_FreeSlotsForTaskTemplateID = Guid.NewGuid(),
                //    FreeSlotsForTaskTemplateITPL = Guid.NewGuid().ToString(),
                //    TaskTemplate_RefID = Parameter.AppointmentTypeID,
                //    FreeInterval_Start = time.Start,
                //    FreeInterval_End = time.End
                //};

                //slot.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3TTS_SS_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3TTS_SS_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TTS_SS_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TTS_SS_1423 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Slots",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3TTS_SS_1423 for attribute P_L3TTS_SS_1423
		[DataContract]
		public class P_L3TTS_SS_1423 
		{
			[DataMember]
			public P_L3TTS_SS_1423_Time[] Times { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid AppointmentTypeID { get; set; } 

		}
		#endregion
		#region SClass P_L3TTS_SS_1423_Time for attribute Times
		[DataContract]
		public class P_L3TTS_SS_1423_Time 
		{
			//Standard type parameters
			[DataMember]
			public DateTime Start { get; set; } 
			[DataMember]
			public DateTime End { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_Slots(,P_L3TTS_SS_1423 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_Slots.Invoke(connectionString,P_L3TTS_SS_1423 Parameter,securityTicket);
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
var parameter = new CL3_TaskTemplateSlot.Atomic.Manipulation.P_L3TTS_SS_1423();
parameter.Times = ...;

parameter.OfficeID = ...;
parameter.AppointmentTypeID = ...;

*/
