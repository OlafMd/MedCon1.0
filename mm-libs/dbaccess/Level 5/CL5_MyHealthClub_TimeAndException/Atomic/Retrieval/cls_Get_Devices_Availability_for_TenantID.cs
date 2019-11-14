/* 
 * Generated on 30.10.2014 14:21:24
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

namespace CL5_MyHealthClub_TimeAndException.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Devices_Availability_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Devices_Availability_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TE_GDAfT_1844_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TE_GDAfT_1844_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TimeAndException.Atomic.Retrieval.SQL.cls_Get_Devices_Availability_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5TE_GDAfT_1844_raw> results = new List<L5TE_GDAfT_1844_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_DEV_Device_InstanceID","Device_RefID","CMN_STR_Office_RefID","CMN_CAL_AVA_AvailabilityID","IsDefaultAvailabilityType","GlobalPropertyMatchingID","DateName","StartTime","EndTime","Creation_Timestamp","IsMonthly","IsYearly","IsWeekly","HasRepeatingOn_Mondays","HasRepeatingOn_Tuesdays","HasRepeatingOn_Wednesdays","HasRepeatingOn_Thursdays","HasRepeatingOn_Fridays","HasRepeatingOn_Saturdays","HasRepeatingOn_Sundays","IsAvailabilityExclusionItem","IsDaily","IsRepetitive","IsWholeDayEvent","Reason" });
				while(reader.Read())
				{
					L5TE_GDAfT_1844_raw resultItem = new L5TE_GDAfT_1844_raw();
					//0:Parameter PPS_DEV_Device_InstanceID of type Guid
					resultItem.PPS_DEV_Device_InstanceID = reader.GetGuid(0);
					//1:Parameter Device_RefID of type Guid
					resultItem.Device_RefID = reader.GetGuid(1);
					//2:Parameter CMN_STR_Office_RefID of type Guid
					resultItem.CMN_STR_Office_RefID = reader.GetGuid(2);
					//3:Parameter CMN_CAL_AVA_AvailabilityID of type Guid
					resultItem.CMN_CAL_AVA_AvailabilityID = reader.GetGuid(3);
					//4:Parameter IsDefaultAvailabilityType of type bool
					resultItem.IsDefaultAvailabilityType = reader.GetBoolean(4);
					//5:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(5);
					//6:Parameter DateName of type String
					resultItem.DateName = reader.GetString(6);
					//7:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(7);
					//8:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(8);
					//9:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(9);
					//10:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(10);
					//11:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(11);
					//12:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(12);
					//13:Parameter HasRepeatingOn_Mondays of type bool
					resultItem.HasRepeatingOn_Mondays = reader.GetBoolean(13);
					//14:Parameter HasRepeatingOn_Tuesdays of type bool
					resultItem.HasRepeatingOn_Tuesdays = reader.GetBoolean(14);
					//15:Parameter HasRepeatingOn_Wednesdays of type bool
					resultItem.HasRepeatingOn_Wednesdays = reader.GetBoolean(15);
					//16:Parameter HasRepeatingOn_Thursdays of type bool
					resultItem.HasRepeatingOn_Thursdays = reader.GetBoolean(16);
					//17:Parameter HasRepeatingOn_Fridays of type bool
					resultItem.HasRepeatingOn_Fridays = reader.GetBoolean(17);
					//18:Parameter HasRepeatingOn_Saturdays of type bool
					resultItem.HasRepeatingOn_Saturdays = reader.GetBoolean(18);
					//19:Parameter HasRepeatingOn_Sundays of type bool
					resultItem.HasRepeatingOn_Sundays = reader.GetBoolean(19);
					//20:Parameter IsAvailabilityExclusionItem of type bool
					resultItem.IsAvailabilityExclusionItem = reader.GetBoolean(20);
					//21:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(21);
					//22:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(22);
					//23:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(23);
					//24:Parameter Reason of type String
					resultItem.Reason = reader.GetString(24);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Devices_Availability_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5TE_GDAfT_1844_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TE_GDAfT_1844_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TE_GDAfT_1844_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TE_GDAfT_1844_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TE_GDAfT_1844_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TE_GDAfT_1844_Array functionReturn = new FR_L5TE_GDAfT_1844_Array();
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

				throw new Exception("Exception occured in method cls_Get_Devices_Availability_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5TE_GDAfT_1844_raw 
	{
		public Guid PPS_DEV_Device_InstanceID; 
		public Guid Device_RefID; 
		public Guid CMN_STR_Office_RefID; 
		public Guid CMN_CAL_AVA_AvailabilityID; 
		public bool IsDefaultAvailabilityType; 
		public String GlobalPropertyMatchingID; 
		public String DateName; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public DateTime Creation_Timestamp; 
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
		public bool IsAvailabilityExclusionItem; 
		public bool IsDaily; 
		public bool IsRepetitive; 
		public bool IsWholeDayEvent; 
		public String Reason; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5TE_GDAfT_1844[] Convert(List<L5TE_GDAfT_1844_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5TE_GDAfT_1844 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.PPS_DEV_Device_InstanceID)).ToArray()
	group el_L5TE_GDAfT_1844 by new 
	{ 
		el_L5TE_GDAfT_1844.PPS_DEV_Device_InstanceID,

	}
	into gfunct_L5TE_GDAfT_1844
	select new L5TE_GDAfT_1844
	{     
		PPS_DEV_Device_InstanceID = gfunct_L5TE_GDAfT_1844.Key.PPS_DEV_Device_InstanceID ,
		Device_RefID = gfunct_L5TE_GDAfT_1844.FirstOrDefault().Device_RefID ,
		CMN_STR_Office_RefID = gfunct_L5TE_GDAfT_1844.FirstOrDefault().CMN_STR_Office_RefID ,

		Availabilities = 
		(
			from el_Availabilities in gfunct_L5TE_GDAfT_1844.Where(element => !EqualsDefaultValue(element.CMN_CAL_AVA_AvailabilityID)).ToArray()
			group el_Availabilities by new 
			{ 
				el_Availabilities.CMN_CAL_AVA_AvailabilityID,

			}
			into gfunct_Availabilities
			select new L5TE_GDAfT_1844_Availability
			{     
				CMN_CAL_AVA_AvailabilityID = gfunct_Availabilities.Key.CMN_CAL_AVA_AvailabilityID ,
				IsDefaultAvailabilityType = gfunct_Availabilities.FirstOrDefault().IsDefaultAvailabilityType ,
				GlobalPropertyMatchingID = gfunct_Availabilities.FirstOrDefault().GlobalPropertyMatchingID ,
				DateName = gfunct_Availabilities.FirstOrDefault().DateName ,
				StartTime = gfunct_Availabilities.FirstOrDefault().StartTime ,
				EndTime = gfunct_Availabilities.FirstOrDefault().EndTime ,
				Creation_Timestamp = gfunct_Availabilities.FirstOrDefault().Creation_Timestamp ,
				IsMonthly = gfunct_Availabilities.FirstOrDefault().IsMonthly ,
				IsYearly = gfunct_Availabilities.FirstOrDefault().IsYearly ,
				IsWeekly = gfunct_Availabilities.FirstOrDefault().IsWeekly ,
				HasRepeatingOn_Mondays = gfunct_Availabilities.FirstOrDefault().HasRepeatingOn_Mondays ,
				HasRepeatingOn_Tuesdays = gfunct_Availabilities.FirstOrDefault().HasRepeatingOn_Tuesdays ,
				HasRepeatingOn_Wednesdays = gfunct_Availabilities.FirstOrDefault().HasRepeatingOn_Wednesdays ,
				HasRepeatingOn_Thursdays = gfunct_Availabilities.FirstOrDefault().HasRepeatingOn_Thursdays ,
				HasRepeatingOn_Fridays = gfunct_Availabilities.FirstOrDefault().HasRepeatingOn_Fridays ,
				HasRepeatingOn_Saturdays = gfunct_Availabilities.FirstOrDefault().HasRepeatingOn_Saturdays ,
				HasRepeatingOn_Sundays = gfunct_Availabilities.FirstOrDefault().HasRepeatingOn_Sundays ,
				IsAvailabilityExclusionItem = gfunct_Availabilities.FirstOrDefault().IsAvailabilityExclusionItem ,
				IsDaily = gfunct_Availabilities.FirstOrDefault().IsDaily ,
				IsRepetitive = gfunct_Availabilities.FirstOrDefault().IsRepetitive ,
				IsWholeDayEvent = gfunct_Availabilities.FirstOrDefault().IsWholeDayEvent ,
				Reason = gfunct_Availabilities.FirstOrDefault().Reason ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5TE_GDAfT_1844_Array : FR_Base
	{
		public L5TE_GDAfT_1844[] Result	{ get; set; } 
		public FR_L5TE_GDAfT_1844_Array() : base() {}

		public FR_L5TE_GDAfT_1844_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5TE_GDAfT_1844 for attribute L5TE_GDAfT_1844
		[DataContract]
		public class L5TE_GDAfT_1844 
		{
			[DataMember]
			public L5TE_GDAfT_1844_Availability[] Availabilities { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PPS_DEV_Device_InstanceID { get; set; } 
			[DataMember]
			public Guid Device_RefID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 

		}
		#endregion
		#region SClass L5TE_GDAfT_1844_Availability for attribute Availabilities
		[DataContract]
		public class L5TE_GDAfT_1844_Availability 
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
FR_L5TE_GDAfT_1844_Array cls_Get_Devices_Availability_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TE_GDAfT_1844_Array invocationResult = cls_Get_Devices_Availability_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

