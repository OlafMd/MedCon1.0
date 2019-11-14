/* 
 * Generated on 7/25/2014 1:29:35 PM
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

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GDaSAfBPID_1111 Execute(DbConnection Connection,DbTransaction Transaction,P_L5DO_GDaSAfBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GDaSAfBPID_1111();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval.SQL.cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StaffID", Parameter.StaffID);



			List<L5DO_GDaSAfBPID_1111_raw> results = new List<L5DO_GDaSAfBPID_1111_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FirstName","LastName","Title","CMN_BPT_BusinessParticipantID","CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID","CMN_BPT_BusinessParticipant_AvailabilityID","Office_RefID","IsDefaultAvailabilityType","GlobalPropertyMatchingID","DateName","StartTime","Creation_Timestamp","EndTime","IsMonthly","IsYearly","IsWeekly","HasRepeatingOn_Mondays","HasRepeatingOn_Tuesdays","HasRepeatingOn_Wednesdays","HasRepeatingOn_Thursdays","HasRepeatingOn_Fridays","HasRepeatingOn_Saturdays","HasRepeatingOn_Sundays","IsAvailabilityExclusionItem","IsDaily","IsRepetitive","IsWholeDayEvent","Reason" });
				while(reader.Read())
				{
					L5DO_GDaSAfBPID_1111_raw resultItem = new L5DO_GDaSAfBPID_1111_raw();
					//0:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(0);
					//1:Parameter LastName of type String
					resultItem.LastName = reader.GetString(1);
					//2:Parameter Title of type String
					resultItem.Title = reader.GetString(2);
					//3:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(3);
					//4:Parameter CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = reader.GetGuid(4);
					//5:Parameter CMN_BPT_BusinessParticipant_AvailabilityID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_AvailabilityID = reader.GetGuid(5);
					//6:Parameter Office_RefID of type Guid
					resultItem.Office_RefID = reader.GetGuid(6);
					//7:Parameter IsDefaultAvailabilityType of type bool
					resultItem.IsDefaultAvailabilityType = reader.GetBoolean(7);
					//8:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(8);
					//9:Parameter DateName of type String
					resultItem.DateName = reader.GetString(9);
					//10:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(10);
					//11:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(11);
					//12:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(12);
					//13:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(13);
					//14:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(14);
					//15:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(15);
					//16:Parameter HasRepeatingOn_Mondays of type bool
					resultItem.HasRepeatingOn_Mondays = reader.GetBoolean(16);
					//17:Parameter HasRepeatingOn_Tuesdays of type bool
					resultItem.HasRepeatingOn_Tuesdays = reader.GetBoolean(17);
					//18:Parameter HasRepeatingOn_Wednesdays of type bool
					resultItem.HasRepeatingOn_Wednesdays = reader.GetBoolean(18);
					//19:Parameter HasRepeatingOn_Thursdays of type bool
					resultItem.HasRepeatingOn_Thursdays = reader.GetBoolean(19);
					//20:Parameter HasRepeatingOn_Fridays of type bool
					resultItem.HasRepeatingOn_Fridays = reader.GetBoolean(20);
					//21:Parameter HasRepeatingOn_Saturdays of type bool
					resultItem.HasRepeatingOn_Saturdays = reader.GetBoolean(21);
					//22:Parameter HasRepeatingOn_Sundays of type bool
					resultItem.HasRepeatingOn_Sundays = reader.GetBoolean(22);
					//23:Parameter IsAvailabilityExclusionItem of type bool
					resultItem.IsAvailabilityExclusionItem = reader.GetBoolean(23);
					//24:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(24);
					//25:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(25);
					//26:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(26);
					//27:Parameter Reason of type String
					resultItem.Reason = reader.GetString(27);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DO_GDaSAfBPID_1111_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DO_GDaSAfBPID_1111 Invoke(string ConnectionString,P_L5DO_GDaSAfBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GDaSAfBPID_1111 Invoke(DbConnection Connection,P_L5DO_GDaSAfBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GDaSAfBPID_1111 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DO_GDaSAfBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GDaSAfBPID_1111 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DO_GDaSAfBPID_1111 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GDaSAfBPID_1111 functionReturn = new FR_L5DO_GDaSAfBPID_1111();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DO_GDaSAfBPID_1111_raw 
	{
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID; 
		public Guid CMN_BPT_BusinessParticipant_AvailabilityID; 
		public Guid Office_RefID; 
		public bool IsDefaultAvailabilityType; 
		public String GlobalPropertyMatchingID; 
		public String DateName; 
		public DateTime StartTime; 
		public DateTime Creation_Timestamp; 
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
		public bool IsAvailabilityExclusionItem; 
		public bool IsDaily; 
		public bool IsRepetitive; 
		public bool IsWholeDayEvent; 
		public String Reason; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DO_GDaSAfBPID_1111[] Convert(List<L5DO_GDaSAfBPID_1111_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DO_GDaSAfBPID_1111 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5DO_GDaSAfBPID_1111 by new 
	{ 
		el_L5DO_GDaSAfBPID_1111.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5DO_GDaSAfBPID_1111
	select new L5DO_GDaSAfBPID_1111
	{     
		FirstName = gfunct_L5DO_GDaSAfBPID_1111.FirstOrDefault().FirstName ,
		LastName = gfunct_L5DO_GDaSAfBPID_1111.FirstOrDefault().LastName ,
		Title = gfunct_L5DO_GDaSAfBPID_1111.FirstOrDefault().Title ,
		CMN_BPT_BusinessParticipantID = gfunct_L5DO_GDaSAfBPID_1111.Key.CMN_BPT_BusinessParticipantID ,
		CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = gfunct_L5DO_GDaSAfBPID_1111.FirstOrDefault().CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID ,

		AvailabilityDates = 
		(
			from el_AvailabilityDates in gfunct_L5DO_GDaSAfBPID_1111.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipant_AvailabilityID)).ToArray()
			group el_AvailabilityDates by new 
			{ 
				el_AvailabilityDates.CMN_BPT_BusinessParticipant_AvailabilityID,

			}
			into gfunct_AvailabilityDates
			select new L5DO_GDaSAfBPID_1111_AvailabilityDates
			{     
				CMN_BPT_BusinessParticipant_AvailabilityID = gfunct_AvailabilityDates.Key.CMN_BPT_BusinessParticipant_AvailabilityID ,
				Office_RefID = gfunct_AvailabilityDates.FirstOrDefault().Office_RefID ,
				IsDefaultAvailabilityType = gfunct_AvailabilityDates.FirstOrDefault().IsDefaultAvailabilityType ,
				GlobalPropertyMatchingID = gfunct_AvailabilityDates.FirstOrDefault().GlobalPropertyMatchingID ,
				DateName = gfunct_AvailabilityDates.FirstOrDefault().DateName ,
				StartTime = gfunct_AvailabilityDates.FirstOrDefault().StartTime ,
				Creation_Timestamp = gfunct_AvailabilityDates.FirstOrDefault().Creation_Timestamp ,
				EndTime = gfunct_AvailabilityDates.FirstOrDefault().EndTime ,
				IsMonthly = gfunct_AvailabilityDates.FirstOrDefault().IsMonthly ,
				IsYearly = gfunct_AvailabilityDates.FirstOrDefault().IsYearly ,
				IsWeekly = gfunct_AvailabilityDates.FirstOrDefault().IsWeekly ,
				HasRepeatingOn_Mondays = gfunct_AvailabilityDates.FirstOrDefault().HasRepeatingOn_Mondays ,
				HasRepeatingOn_Tuesdays = gfunct_AvailabilityDates.FirstOrDefault().HasRepeatingOn_Tuesdays ,
				HasRepeatingOn_Wednesdays = gfunct_AvailabilityDates.FirstOrDefault().HasRepeatingOn_Wednesdays ,
				HasRepeatingOn_Thursdays = gfunct_AvailabilityDates.FirstOrDefault().HasRepeatingOn_Thursdays ,
				HasRepeatingOn_Fridays = gfunct_AvailabilityDates.FirstOrDefault().HasRepeatingOn_Fridays ,
				HasRepeatingOn_Saturdays = gfunct_AvailabilityDates.FirstOrDefault().HasRepeatingOn_Saturdays ,
				HasRepeatingOn_Sundays = gfunct_AvailabilityDates.FirstOrDefault().HasRepeatingOn_Sundays ,
				IsAvailabilityExclusionItem = gfunct_AvailabilityDates.FirstOrDefault().IsAvailabilityExclusionItem ,
				IsDaily = gfunct_AvailabilityDates.FirstOrDefault().IsDaily ,
				IsRepetitive = gfunct_AvailabilityDates.FirstOrDefault().IsRepetitive ,
				IsWholeDayEvent = gfunct_AvailabilityDates.FirstOrDefault().IsWholeDayEvent ,
				Reason = gfunct_AvailabilityDates.FirstOrDefault().Reason ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GDaSAfBPID_1111 : FR_Base
	{
		public L5DO_GDaSAfBPID_1111 Result	{ get; set; }

		public FR_L5DO_GDaSAfBPID_1111() : base() {}

		public FR_L5DO_GDaSAfBPID_1111(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DO_GDaSAfBPID_1111 for attribute P_L5DO_GDaSAfBPID_1111
		[DataContract]
		public class P_L5DO_GDaSAfBPID_1111 
		{
			//Standard type parameters
			[DataMember]
			public Guid StaffID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSAfBPID_1111 for attribute L5DO_GDaSAfBPID_1111
		[DataContract]
		public class L5DO_GDaSAfBPID_1111 
		{
			[DataMember]
			public L5DO_GDaSAfBPID_1111_AvailabilityDates[] AvailabilityDates { get; set; }

			//Standard type parameters
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSAfBPID_1111_AvailabilityDates for attribute AvailabilityDates
		[DataContract]
		public class L5DO_GDaSAfBPID_1111_AvailabilityDates 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_AvailabilityID { get; set; } 
			[DataMember]
			public Guid Office_RefID { get; set; } 
			[DataMember]
			public bool IsDefaultAvailabilityType { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String DateName { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
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
FR_L5DO_GDaSAfBPID_1111 cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID(,P_L5DO_GDaSAfBPID_1111 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GDaSAfBPID_1111 invocationResult = cls_Get_Doctor_and_Staff_Availability_for_BusinessParticipantID.Invoke(connectionString,P_L5DO_GDaSAfBPID_1111 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval.P_L5DO_GDaSAfBPID_1111();
parameter.StaffID = ...;

*/
