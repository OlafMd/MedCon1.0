/* 
 * Generated on 30.7.2014 12:12:57
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

namespace CL5_MyHealthClub_Device.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Device_Availability_for_DeviceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Device_Availability_for_DeviceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DE_GDAfDIID_1150_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DE_GDAfDIID_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DE_GDAfDIID_1150_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Device.Atomic.Retrieval.SQL.cls_Get_Device_Availability_for_DeviceID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeviceInstanceID", Parameter.DeviceInstanceID);



			List<L5DE_GDAfDIID_1150> results = new List<L5DE_GDAfDIID_1150>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_CAL_AVA_AvailabilityID","IsDefaultAvailabilityType","GlobalPropertyMatchingID","DateName","StartTime","EndTime","Creation_Timestamp","IsMonthly","IsYearly","IsWeekly","HasRepeatingOn_Mondays","HasRepeatingOn_Tuesdays","HasRepeatingOn_Wednesdays","HasRepeatingOn_Thursdays","HasRepeatingOn_Fridays","HasRepeatingOn_Saturdays","HasRepeatingOn_Sundays","IsAvailabilityExclusionItem","IsDaily","IsRepetitive","IsWholeDayEvent","Reason" });
				while(reader.Read())
				{
					L5DE_GDAfDIID_1150 resultItem = new L5DE_GDAfDIID_1150();
					//0:Parameter CMN_CAL_AVA_AvailabilityID of type Guid
					resultItem.CMN_CAL_AVA_AvailabilityID = reader.GetGuid(0);
					//1:Parameter IsDefaultAvailabilityType of type bool
					resultItem.IsDefaultAvailabilityType = reader.GetBoolean(1);
					//2:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(2);
					//3:Parameter DateName of type String
					resultItem.DateName = reader.GetString(3);
					//4:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(4);
					//5:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(5);
					//6:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(6);
					//7:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(7);
					//8:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(8);
					//9:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(9);
					//10:Parameter HasRepeatingOn_Mondays of type bool
					resultItem.HasRepeatingOn_Mondays = reader.GetBoolean(10);
					//11:Parameter HasRepeatingOn_Tuesdays of type bool
					resultItem.HasRepeatingOn_Tuesdays = reader.GetBoolean(11);
					//12:Parameter HasRepeatingOn_Wednesdays of type bool
					resultItem.HasRepeatingOn_Wednesdays = reader.GetBoolean(12);
					//13:Parameter HasRepeatingOn_Thursdays of type bool
					resultItem.HasRepeatingOn_Thursdays = reader.GetBoolean(13);
					//14:Parameter HasRepeatingOn_Fridays of type bool
					resultItem.HasRepeatingOn_Fridays = reader.GetBoolean(14);
					//15:Parameter HasRepeatingOn_Saturdays of type bool
					resultItem.HasRepeatingOn_Saturdays = reader.GetBoolean(15);
					//16:Parameter HasRepeatingOn_Sundays of type bool
					resultItem.HasRepeatingOn_Sundays = reader.GetBoolean(16);
					//17:Parameter IsAvailabilityExclusionItem of type bool
					resultItem.IsAvailabilityExclusionItem = reader.GetBoolean(17);
					//18:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(18);
					//19:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(19);
					//20:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(20);
					//21:Parameter Reason of type String
					resultItem.Reason = reader.GetString(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Device_Availability_for_DeviceID",ex);
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
		public static FR_L5DE_GDAfDIID_1150_Array Invoke(string ConnectionString,P_L5DE_GDAfDIID_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DE_GDAfDIID_1150_Array Invoke(DbConnection Connection,P_L5DE_GDAfDIID_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DE_GDAfDIID_1150_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DE_GDAfDIID_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DE_GDAfDIID_1150_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DE_GDAfDIID_1150 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DE_GDAfDIID_1150_Array functionReturn = new FR_L5DE_GDAfDIID_1150_Array();
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

				throw new Exception("Exception occured in method cls_Get_Device_Availability_for_DeviceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5DE_GDAfDIID_1150_Array : FR_Base
	{
		public L5DE_GDAfDIID_1150[] Result	{ get; set; } 
		public FR_L5DE_GDAfDIID_1150_Array() : base() {}

		public FR_L5DE_GDAfDIID_1150_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DE_GDAfDIID_1150 for attribute P_L5DE_GDAfDIID_1150
		[DataContract]
		public class P_L5DE_GDAfDIID_1150 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeviceInstanceID { get; set; } 

		}
		#endregion
		#region SClass L5DE_GDAfDIID_1150 for attribute L5DE_GDAfDIID_1150
		[DataContract]
		public class L5DE_GDAfDIID_1150 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CAL_AVA_AvailabilityID { get; set; } 
			[DataMember]
			public bool IsDefaultAvailabilityType { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String DateName { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsMonthly { get; set; } 
			[DataMember]
			public bool IsYearly { get; set; } 
			[DataMember]
			public bool IsWeekly { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Mondays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Tuesdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Wednesdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Thursdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Fridays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Saturdays { get; set; } 
			[DataMember]
			public bool HasRepeatingOn_Sundays { get; set; } 
			[DataMember]
			public bool IsAvailabilityExclusionItem { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public bool IsWholeDayEvent { get; set; } 
			[DataMember]
			public String Reason { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DE_GDAfDIID_1150_Array cls_Get_Device_Availability_for_DeviceID(,P_L5DE_GDAfDIID_1150 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DE_GDAfDIID_1150_Array invocationResult = cls_Get_Device_Availability_for_DeviceID.Invoke(connectionString,P_L5DE_GDAfDIID_1150 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Device.Atomic.Retrieval.P_L5DE_GDAfDIID_1150();
parameter.DeviceInstanceID = ...;

*/
