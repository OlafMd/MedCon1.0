/* 
 * Generated on 10/14/2013 12:22:49 PM
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
using CL1_CMN_STR_SCE;

namespace CL3_Events.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_StructureEvent_Type.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_StructureEvent_Type
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3EV_SET_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

    var returnValue = new FR_Guid();

    var item = new ORM_CMN_STR_SCE_StructureCalendarEvent_Type();
    if (Parameter.CMN_STR_SCE_StructureCalendarEvent_TypeID != Guid.Empty)
    {
    var result = item.Load(Connection, Transaction, Parameter.CMN_STR_SCE_StructureCalendarEvent_TypeID);
    if (result.Status != FR_Status.Success || item.CMN_STR_SCE_StructureCalendarEvent_TypeID == Guid.Empty)
    {
    var error = new FR_Guid();
    error.ErrorMessage = "No Such ID";
    error.Status =  FR_Status.Error_Internal;
    return error;
    }
    }

    if(Parameter.IsDeleted == true){
    item.IsDeleted = true;
    return new FR_Guid(item.Save(Connection, Transaction),item.CMN_STR_SCE_StructureCalendarEvent_TypeID);
    }

    //Creation specific parameters (Tenant, Account ... )
    if (Parameter.CMN_STR_SCE_StructureCalendarEvent_TypeID == Guid.Empty)
    {
    item.Tenant_RefID = securityTicket.TenantID;
    }

    item.CalendaEventName = Parameter.CalendaEventName;
    item.EventIcon_RefID = Parameter.EventIcon_RefID;
    item.PriorityOrdinal = Parameter.PriorityOrdinal;
    item.ColorCode_Foreground = Parameter.ColorCode_Foreground;
    item.ColorCode_Background = Parameter.ColorCode_Background;
    item.ColorCode_Alpha = Parameter.ColorCode_Alpha;
    item.IsShowingNotification = Parameter.IsShowingNotification;
    item.IsWorkingDay = Parameter.IsWorkingDay;
    item.IsHalfWorkingDay = Parameter.IsHalfWorkingDay;
    item.IsNonWorkingDay = Parameter.IsNonWorkingDay;
    item.IsEventType_Imported = Parameter.IsEventType_Imported;
    item.InternalEventTypeID = Parameter.InternalEventTypeID;

    return new FR_Guid(item.Save(Connection, Transaction),item.CMN_STR_SCE_StructureCalendarEvent_TypeID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3EV_SET_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3EV_SET_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3EV_SET_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3EV_SET_1106 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_StructureEvent_Type",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3EV_SET_1106 for attribute P_L3EV_SET_1106
		[DataContract]
		public class P_L3EV_SET_1106 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_SCE_StructureCalendarEvent_TypeID { get; set; } 
			[DataMember]
			public Dict CalendaEventName { get; set; } 
			[DataMember]
			public Guid EventIcon_RefID { get; set; } 
			[DataMember]
			public int PriorityOrdinal { get; set; } 
			[DataMember]
			public String ColorCode_Foreground { get; set; } 
			[DataMember]
			public String ColorCode_Background { get; set; } 
			[DataMember]
			public Double ColorCode_Alpha { get; set; } 
			[DataMember]
			public Boolean IsShowingNotification { get; set; } 
			[DataMember]
			public Boolean IsWorkingDay { get; set; } 
			[DataMember]
			public Boolean IsHalfWorkingDay { get; set; } 
			[DataMember]
			public Boolean IsNonWorkingDay { get; set; } 
			[DataMember]
			public String InternalEventTypeID { get; set; } 
			[DataMember]
			public Boolean IsEventType_Imported { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_StructureEvent_Type(,P_L3EV_SET_1106 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_StructureEvent_Type.Invoke(connectionString,P_L3EV_SET_1106 Parameter,securityTicket);
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
var parameter = new CL3_Events.Atomic.Manipulation.P_L3EV_SET_1106();
parameter.CMN_STR_SCE_StructureCalendarEvent_TypeID = ...;
parameter.CalendaEventName = ...;
parameter.EventIcon_RefID = ...;
parameter.PriorityOrdinal = ...;
parameter.ColorCode_Foreground = ...;
parameter.ColorCode_Background = ...;
parameter.ColorCode_Alpha = ...;
parameter.IsShowingNotification = ...;
parameter.IsWorkingDay = ...;
parameter.IsHalfWorkingDay = ...;
parameter.IsNonWorkingDay = ...;
parameter.InternalEventTypeID = ...;
parameter.IsEventType_Imported = ...;
parameter.IsDeleted = ...;

*/