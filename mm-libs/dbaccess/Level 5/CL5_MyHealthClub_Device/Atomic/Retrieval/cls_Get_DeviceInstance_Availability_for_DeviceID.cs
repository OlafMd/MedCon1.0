/* 
 * Generated on 9/2/2014 10:31:26 AM
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
    /// var result = cls_Get_DeviceInstance_Availability_for_DeviceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeviceInstance_Availability_for_DeviceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DE_GDIAfDID_1400_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DE_GDIAfDID_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DE_GDIAfDID_1400_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Device.Atomic.Retrieval.SQL.cls_Get_DeviceInstance_Availability_for_DeviceID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DeviceID", Parameter.DeviceID);



			List<L5DE_GDIAfDID_1400_raw> results = new List<L5DE_GDIAfDID_1400_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_DEV_DeviceID","DeviceDisplayName","DeviceName_DictID","PPS_DEV_Device_InstanceID","CMN_STR_Office_RefID","DeviceInventoryNumber","IsDefaultAvailabilityType","GlobalPropertyMatchingID","DateName","StartTime","EndTime","IsMonthly","IsYearly","IsWeekly","HasRepeatingOn_Mondays","HasRepeatingOn_Tuesdays","HasRepeatingOn_Wednesdays","HasRepeatingOn_Thursdays","HasRepeatingOn_Fridays","HasRepeatingOn_Saturdays","HasRepeatingOn_Sundays","CMN_CAL_AVA_AvailabilityID","IsAvailabilityExclusionItem","Reason","IsWholeDayEvent","IsRepetitive","IsDaily" });
				while(reader.Read())
				{
					L5DE_GDIAfDID_1400_raw resultItem = new L5DE_GDIAfDID_1400_raw();
					//0:Parameter PPS_DEV_DeviceID of type Guid
					resultItem.PPS_DEV_DeviceID = reader.GetGuid(0);
					//1:Parameter DeviceDisplayName of type String
					resultItem.DeviceDisplayName = reader.GetString(1);
					//2:Parameter DeviceName of type Dict
					resultItem.DeviceName = reader.GetDictionary(2);
					resultItem.DeviceName.SourceTable = "pps_dev_devices";
					loader.Append(resultItem.DeviceName);
					//3:Parameter PPS_DEV_Device_InstanceID of type Guid
					resultItem.PPS_DEV_Device_InstanceID = reader.GetGuid(3);
					//4:Parameter CMN_STR_Office_RefID of type Guid
					resultItem.CMN_STR_Office_RefID = reader.GetGuid(4);
					//5:Parameter DeviceInventoryNumber of type String
					resultItem.DeviceInventoryNumber = reader.GetString(5);
					//6:Parameter IsDefaultAvailabilityType of type bool
					resultItem.IsDefaultAvailabilityType = reader.GetBoolean(6);
					//7:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(7);
					//8:Parameter DateName of type String
					resultItem.DateName = reader.GetString(8);
					//9:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(9);
					//10:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(10);
					//11:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(11);
					//12:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(12);
					//13:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(13);
					//14:Parameter HasRepeatingOn_Mondays of type bool
					resultItem.HasRepeatingOn_Mondays = reader.GetBoolean(14);
					//15:Parameter HasRepeatingOn_Tuesdays of type bool
					resultItem.HasRepeatingOn_Tuesdays = reader.GetBoolean(15);
					//16:Parameter HasRepeatingOn_Wednesdays of type bool
					resultItem.HasRepeatingOn_Wednesdays = reader.GetBoolean(16);
					//17:Parameter HasRepeatingOn_Thursdays of type bool
					resultItem.HasRepeatingOn_Thursdays = reader.GetBoolean(17);
					//18:Parameter HasRepeatingOn_Fridays of type bool
					resultItem.HasRepeatingOn_Fridays = reader.GetBoolean(18);
					//19:Parameter HasRepeatingOn_Saturdays of type bool
					resultItem.HasRepeatingOn_Saturdays = reader.GetBoolean(19);
					//20:Parameter HasRepeatingOn_Sundays of type bool
					resultItem.HasRepeatingOn_Sundays = reader.GetBoolean(20);
					//21:Parameter CMN_CAL_AVA_AvailabilityID of type Guid
					resultItem.CMN_CAL_AVA_AvailabilityID = reader.GetGuid(21);
					//22:Parameter IsAvailabilityExclusionItem of type bool
					resultItem.IsAvailabilityExclusionItem = reader.GetBoolean(22);
					//23:Parameter Reason of type String
					resultItem.Reason = reader.GetString(23);
					//24:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(24);
					//25:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(25);
					//26:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(26);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeviceInstance_Availability_for_DeviceID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DE_GDIAfDID_1400_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DE_GDIAfDID_1400_Array Invoke(string ConnectionString,P_L5DE_GDIAfDID_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DE_GDIAfDID_1400_Array Invoke(DbConnection Connection,P_L5DE_GDIAfDID_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DE_GDIAfDID_1400_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DE_GDIAfDID_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DE_GDIAfDID_1400_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DE_GDIAfDID_1400 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DE_GDIAfDID_1400_Array functionReturn = new FR_L5DE_GDIAfDID_1400_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeviceInstance_Availability_for_DeviceID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DE_GDIAfDID_1400_raw 
	{
		public Guid PPS_DEV_DeviceID; 
		public String DeviceDisplayName; 
		public Dict DeviceName; 
		public Guid PPS_DEV_Device_InstanceID; 
		public Guid CMN_STR_Office_RefID; 
		public String DeviceInventoryNumber; 
		public bool IsDefaultAvailabilityType; 
		public String GlobalPropertyMatchingID; 
		public String DateName; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public bool IsMonthly; 
		public bool IsYearly; 
		public bool IsWeekly; 
		public bool HasRepeatingOn_Mondays; 
		public bool HasRepeatingOn_Tuesdays; 
		public bool HasRepeatingOn_Wednesdays; 
		public bool HasRepeatingOn_Thursdays; 
		public bool HasRepeatingOn_Fridays; 
		public bool HasRepeatingOn_Saturdays; 
		public bool HasRepeatingOn_Sundays; 
		public Guid CMN_CAL_AVA_AvailabilityID; 
		public bool IsAvailabilityExclusionItem; 
		public String Reason; 
		public bool IsWholeDayEvent; 
		public bool IsRepetitive; 
		public bool IsDaily; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DE_GDIAfDID_1400[] Convert(List<L5DE_GDIAfDID_1400_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DE_GDIAfDID_1400 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_DEV_Device_InstanceID)).ToArray()
	group el_L5DE_GDIAfDID_1400 by new 
	{ 
		el_L5DE_GDIAfDID_1400.PPS_DEV_Device_InstanceID,

	}
	into gfunct_L5DE_GDIAfDID_1400
	select new L5DE_GDIAfDID_1400
	{     
		PPS_DEV_DeviceID = gfunct_L5DE_GDIAfDID_1400.FirstOrDefault().PPS_DEV_DeviceID ,
		DeviceDisplayName = gfunct_L5DE_GDIAfDID_1400.FirstOrDefault().DeviceDisplayName ,
		DeviceName = gfunct_L5DE_GDIAfDID_1400.FirstOrDefault().DeviceName ,
		PPS_DEV_Device_InstanceID = gfunct_L5DE_GDIAfDID_1400.Key.PPS_DEV_Device_InstanceID ,
		CMN_STR_Office_RefID = gfunct_L5DE_GDIAfDID_1400.FirstOrDefault().CMN_STR_Office_RefID ,
		DeviceInventoryNumber = gfunct_L5DE_GDIAfDID_1400.FirstOrDefault().DeviceInventoryNumber ,

		DeviceInstancesAvailability = 
		(
			from el_DeviceInstancesAvailability in gfunct_L5DE_GDIAfDID_1400.Where(element => !EqualsDefaultValue(element.CMN_CAL_AVA_AvailabilityID)).ToArray()
			group el_DeviceInstancesAvailability by new 
			{ 
				el_DeviceInstancesAvailability.CMN_CAL_AVA_AvailabilityID,

			}
			into gfunct_DeviceInstancesAvailability
			select new L5DE_GDIAfDID_1400_DeviceInstancesAvailability
			{     
				IsDefaultAvailabilityType = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsDefaultAvailabilityType ,
				GlobalPropertyMatchingID = gfunct_DeviceInstancesAvailability.FirstOrDefault().GlobalPropertyMatchingID ,
				DateName = gfunct_DeviceInstancesAvailability.FirstOrDefault().DateName ,
				StartTime = gfunct_DeviceInstancesAvailability.FirstOrDefault().StartTime ,
				EndTime = gfunct_DeviceInstancesAvailability.FirstOrDefault().EndTime ,
				IsMonthly = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsMonthly ,
				IsYearly = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsYearly ,
				IsWeekly = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsWeekly ,
				HasRepeatingOn_Mondays = gfunct_DeviceInstancesAvailability.FirstOrDefault().HasRepeatingOn_Mondays ,
				HasRepeatingOn_Tuesdays = gfunct_DeviceInstancesAvailability.FirstOrDefault().HasRepeatingOn_Tuesdays ,
				HasRepeatingOn_Wednesdays = gfunct_DeviceInstancesAvailability.FirstOrDefault().HasRepeatingOn_Wednesdays ,
				HasRepeatingOn_Thursdays = gfunct_DeviceInstancesAvailability.FirstOrDefault().HasRepeatingOn_Thursdays ,
				HasRepeatingOn_Fridays = gfunct_DeviceInstancesAvailability.FirstOrDefault().HasRepeatingOn_Fridays ,
				HasRepeatingOn_Saturdays = gfunct_DeviceInstancesAvailability.FirstOrDefault().HasRepeatingOn_Saturdays ,
				HasRepeatingOn_Sundays = gfunct_DeviceInstancesAvailability.FirstOrDefault().HasRepeatingOn_Sundays ,
				CMN_CAL_AVA_AvailabilityID = gfunct_DeviceInstancesAvailability.Key.CMN_CAL_AVA_AvailabilityID ,
				IsAvailabilityExclusionItem = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsAvailabilityExclusionItem ,
				Reason = gfunct_DeviceInstancesAvailability.FirstOrDefault().Reason ,
				IsWholeDayEvent = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsWholeDayEvent ,
				IsRepetitive = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsRepetitive ,
				IsDaily = gfunct_DeviceInstancesAvailability.FirstOrDefault().IsDaily ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DE_GDIAfDID_1400_Array : FR_Base
	{
		public L5DE_GDIAfDID_1400[] Result	{ get; set; } 
		public FR_L5DE_GDIAfDID_1400_Array() : base() {}

		public FR_L5DE_GDIAfDID_1400_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DE_GDIAfDID_1400 for attribute P_L5DE_GDIAfDID_1400
		[DataContract]
		public class P_L5DE_GDIAfDID_1400 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeviceID { get; set; } 

		}
		#endregion
		#region SClass L5DE_GDIAfDID_1400 for attribute L5DE_GDIAfDID_1400
		[DataContract]
		public class L5DE_GDIAfDID_1400 
		{
			[DataMember]
			public L5DE_GDIAfDID_1400_DeviceInstancesAvailability[] DeviceInstancesAvailability { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_DEV_DeviceID { get; set; } 
			[DataMember]
			public String DeviceDisplayName { get; set; } 
			[DataMember]
			public Dict DeviceName { get; set; } 
			[DataMember]
			public Guid PPS_DEV_Device_InstanceID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public String DeviceInventoryNumber { get; set; } 

		}
		#endregion
		#region SClass L5DE_GDIAfDID_1400_DeviceInstancesAvailability for attribute DeviceInstancesAvailability
		[DataContract]
		public class L5DE_GDIAfDID_1400_DeviceInstancesAvailability 
		{
			//Standard type parameters
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
			public Guid CMN_CAL_AVA_AvailabilityID { get; set; } 
			[DataMember]
			public bool IsAvailabilityExclusionItem { get; set; } 
			[DataMember]
			public String Reason { get; set; } 
			[DataMember]
			public bool IsWholeDayEvent { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DE_GDIAfDID_1400_Array cls_Get_DeviceInstance_Availability_for_DeviceID(,P_L5DE_GDIAfDID_1400 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DE_GDIAfDID_1400_Array invocationResult = cls_Get_DeviceInstance_Availability_for_DeviceID.Invoke(connectionString,P_L5DE_GDIAfDID_1400 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Device.Atomic.Retrieval.P_L5DE_GDIAfDID_1400();
parameter.DeviceID = ...;

*/
