/* 
 * Generated on 10/14/2013 12:22:58 PM
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

namespace CL3_Events.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_EventTypes_For_EventTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EventTypes_For_EventTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3EV_GETFET_1105_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3EV_GETFET_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3EV_GETFET_1105_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Events.Atomic.Retrieval.SQL.cls_Get_EventTypes_For_EventTypeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"EventTypeID", Parameter.EventTypeID);



			List<L3EV_GETFET_1105> results = new List<L3EV_GETFET_1105>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_STR_SCE_StructureCalendarEvent_TypeID","CalendaEventName_DictID","EventIcon_RefID","PriorityOrdinal","ColorCode_Foreground","ColorCode_Background","ColorCode_Alpha","IsShowingNotification","IsWorkingDay","IsHalfWorkingDay","IsNonWorkingDay","IsDeleted","Tenant_RefID","InternalEventTypeID" });
				while(reader.Read())
				{
					L3EV_GETFET_1105 resultItem = new L3EV_GETFET_1105();
					//0:Parameter CMN_STR_SCE_StructureCalendarEvent_TypeID of type Guid
					resultItem.CMN_STR_SCE_StructureCalendarEvent_TypeID = reader.GetGuid(0);
					//1:Parameter CalendaEventName of type Dict
					resultItem.CalendaEventName = reader.GetDictionary(1);
					resultItem.CalendaEventName.SourceTable = "cmn_str_sce_structurecalendarevent_types";
					loader.Append(resultItem.CalendaEventName);
					//2:Parameter EventIcon_RefID of type Guid
					resultItem.EventIcon_RefID = reader.GetGuid(2);
					//3:Parameter PriorityOrdinal of type String
					resultItem.PriorityOrdinal = reader.GetString(3);
					//4:Parameter ColorCode_Foreground of type String
					resultItem.ColorCode_Foreground = reader.GetString(4);
					//5:Parameter ColorCode_Background of type String
					resultItem.ColorCode_Background = reader.GetString(5);
					//6:Parameter ColorCode_Alpha of type String
					resultItem.ColorCode_Alpha = reader.GetString(6);
					//7:Parameter IsShowingNotification of type bool
					resultItem.IsShowingNotification = reader.GetBoolean(7);
					//8:Parameter IsWorkingDay of type bool
					resultItem.IsWorkingDay = reader.GetBoolean(8);
					//9:Parameter IsHalfWorkingDay of type bool
					resultItem.IsHalfWorkingDay = reader.GetBoolean(9);
					//10:Parameter IsNonWorkingDay of type bool
					resultItem.IsNonWorkingDay = reader.GetBoolean(10);
					//11:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(11);
					//12:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(12);
					//13:Parameter InternalEventTypeID of type String
					resultItem.InternalEventTypeID = reader.GetString(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_EventTypes_For_EventTypeID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3EV_GETFET_1105_Array Invoke(string ConnectionString,P_L3EV_GETFET_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3EV_GETFET_1105_Array Invoke(DbConnection Connection,P_L3EV_GETFET_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3EV_GETFET_1105_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3EV_GETFET_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3EV_GETFET_1105_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3EV_GETFET_1105 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3EV_GETFET_1105_Array functionReturn = new FR_L3EV_GETFET_1105_Array();
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

				throw new Exception("Exception occured in method cls_Get_EventTypes_For_EventTypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3EV_GETFET_1105_Array : FR_Base
	{
		public L3EV_GETFET_1105[] Result	{ get; set; } 
		public FR_L3EV_GETFET_1105_Array() : base() {}

		public FR_L3EV_GETFET_1105_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3EV_GETFET_1105 for attribute P_L3EV_GETFET_1105
		[DataContract]
		public class P_L3EV_GETFET_1105 
		{
			//Standard type parameters
			[DataMember]
			public Guid EventTypeID { get; set; } 

		}
		#endregion
		#region SClass L3EV_GETFET_1105 for attribute L3EV_GETFET_1105
		[DataContract]
		public class L3EV_GETFET_1105 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_SCE_StructureCalendarEvent_TypeID { get; set; } 
			[DataMember]
			public Dict CalendaEventName { get; set; } 
			[DataMember]
			public Guid EventIcon_RefID { get; set; } 
			[DataMember]
			public String PriorityOrdinal { get; set; } 
			[DataMember]
			public String ColorCode_Foreground { get; set; } 
			[DataMember]
			public String ColorCode_Background { get; set; } 
			[DataMember]
			public String ColorCode_Alpha { get; set; } 
			[DataMember]
			public bool IsShowingNotification { get; set; } 
			[DataMember]
			public bool IsWorkingDay { get; set; } 
			[DataMember]
			public bool IsHalfWorkingDay { get; set; } 
			[DataMember]
			public bool IsNonWorkingDay { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public String InternalEventTypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3EV_GETFET_1105_Array cls_Get_EventTypes_For_EventTypeID(,P_L3EV_GETFET_1105 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3EV_GETFET_1105_Array invocationResult = cls_Get_EventTypes_For_EventTypeID.Invoke(connectionString,P_L3EV_GETFET_1105 Parameter,securityTicket);
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
var parameter = new CL3_Events.Atomic.Retrieval.P_L3EV_GETFET_1105();
parameter.EventTypeID = ...;

*/