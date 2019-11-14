/* 
 * Generated on 8/11/2014 11:29:46 AM
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

namespace CL5_MyHealthClub_OrgUnits.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OrgUnitData_for_AppointmentTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrgUnitData_for_AppointmentTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_GOUDfATID_1507_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_GOUDfATID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OU_GOUDfATID_1507_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.SQL.cls_Get_OrgUnitData_for_AppointmentTypeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AppointmentTypeID", Parameter.AppointmentTypeID);



			List<L5OU_GOUDfATID_1507_raw> results = new List<L5OU_GOUDfATID_1507_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OfficeID","Office_Name_DictID","Street_Name","Street_Number","City_Name","CMN_CAL_WeeklyOfficeHours_IntervalID","TimeFrom_InMinutes","TimeTo_InMinutes","IsMonday","IsTuesday","IsWednesday","IsThursday","IsFriday" });
				while(reader.Read())
				{
					L5OU_GOUDfATID_1507_raw resultItem = new L5OU_GOUDfATID_1507_raw();
					//0:Parameter OfficeID of type Guid
					resultItem.OfficeID = reader.GetGuid(0);
					//1:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(1);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//2:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(2);
					//3:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(3);
					//4:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(4);
					//5:Parameter CMN_CAL_WeeklyOfficeHours_IntervalID of type Guid
					resultItem.CMN_CAL_WeeklyOfficeHours_IntervalID = reader.GetGuid(5);
					//6:Parameter TimeFrom_InMinutes of type int
					resultItem.TimeFrom_InMinutes = reader.GetInteger(6);
					//7:Parameter TimeTo_InMinutes of type int
					resultItem.TimeTo_InMinutes = reader.GetInteger(7);
					//8:Parameter IsMonday of type bool
					resultItem.IsMonday = reader.GetBoolean(8);
					//9:Parameter IsTuesday of type bool
					resultItem.IsTuesday = reader.GetBoolean(9);
					//10:Parameter IsWednesday of type bool
					resultItem.IsWednesday = reader.GetBoolean(10);
					//11:Parameter IsThursday of type bool
					resultItem.IsThursday = reader.GetBoolean(11);
					//12:Parameter IsFriday of type bool
					resultItem.IsFriday = reader.GetBoolean(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OrgUnitData_for_AppointmentTypeID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OU_GOUDfATID_1507_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_GOUDfATID_1507_Array Invoke(string ConnectionString,P_L5OU_GOUDfATID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDfATID_1507_Array Invoke(DbConnection Connection,P_L5OU_GOUDfATID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDfATID_1507_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_GOUDfATID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_GOUDfATID_1507_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_GOUDfATID_1507 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_GOUDfATID_1507_Array functionReturn = new FR_L5OU_GOUDfATID_1507_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrgUnitData_for_AppointmentTypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OU_GOUDfATID_1507_raw 
	{
		public Guid OfficeID; 
		public Dict Office_Name; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_Name; 
		public Guid CMN_CAL_WeeklyOfficeHours_IntervalID; 
		public int TimeFrom_InMinutes; 
		public int TimeTo_InMinutes; 
		public bool IsMonday; 
		public bool IsTuesday; 
		public bool IsWednesday; 
		public bool IsThursday; 
		public bool IsFriday; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OU_GOUDfATID_1507[] Convert(List<L5OU_GOUDfATID_1507_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OU_GOUDfATID_1507 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.OfficeID)).ToArray()
	group el_L5OU_GOUDfATID_1507 by new 
	{ 
		el_L5OU_GOUDfATID_1507.OfficeID,

	}
	into gfunct_L5OU_GOUDfATID_1507
	select new L5OU_GOUDfATID_1507
	{     
		OfficeID = gfunct_L5OU_GOUDfATID_1507.Key.OfficeID ,
		Office_Name = gfunct_L5OU_GOUDfATID_1507.FirstOrDefault().Office_Name ,
		Street_Name = gfunct_L5OU_GOUDfATID_1507.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5OU_GOUDfATID_1507.FirstOrDefault().Street_Number ,
		City_Name = gfunct_L5OU_GOUDfATID_1507.FirstOrDefault().City_Name ,

		StandardHours = 
		(
			from el_StandardHours in gfunct_L5OU_GOUDfATID_1507.Where(element => !EqualsDefaultValue(element.CMN_CAL_WeeklyOfficeHours_IntervalID)).ToArray()
			group el_StandardHours by new 
			{ 
				el_StandardHours.CMN_CAL_WeeklyOfficeHours_IntervalID,

			}
			into gfunct_StandardHours
			select new L5OU_GOUDfATID_1507_StandardHours
			{     
				CMN_CAL_WeeklyOfficeHours_IntervalID = gfunct_StandardHours.Key.CMN_CAL_WeeklyOfficeHours_IntervalID ,
				TimeFrom_InMinutes = gfunct_StandardHours.FirstOrDefault().TimeFrom_InMinutes ,
				TimeTo_InMinutes = gfunct_StandardHours.FirstOrDefault().TimeTo_InMinutes ,
				IsMonday = gfunct_StandardHours.FirstOrDefault().IsMonday ,
				IsTuesday = gfunct_StandardHours.FirstOrDefault().IsTuesday ,
				IsWednesday = gfunct_StandardHours.FirstOrDefault().IsWednesday ,
				IsThursday = gfunct_StandardHours.FirstOrDefault().IsThursday ,
				IsFriday = gfunct_StandardHours.FirstOrDefault().IsFriday ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_GOUDfATID_1507_Array : FR_Base
	{
		public L5OU_GOUDfATID_1507[] Result	{ get; set; } 
		public FR_L5OU_GOUDfATID_1507_Array() : base() {}

		public FR_L5OU_GOUDfATID_1507_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OU_GOUDfATID_1507 for attribute P_L5OU_GOUDfATID_1507
		[DataContract]
		public class P_L5OU_GOUDfATID_1507 
		{
			//Standard type parameters
			[DataMember]
			public Guid AppointmentTypeID { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDfATID_1507 for attribute L5OU_GOUDfATID_1507
		[DataContract]
		public class L5OU_GOUDfATID_1507 
		{
			[DataMember]
			public L5OU_GOUDfATID_1507_StandardHours[] StandardHours { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDfATID_1507_StandardHours for attribute StandardHours
		[DataContract]
		public class L5OU_GOUDfATID_1507_StandardHours 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CAL_WeeklyOfficeHours_IntervalID { get; set; } 
			[DataMember]
			public int TimeFrom_InMinutes { get; set; } 
			[DataMember]
			public int TimeTo_InMinutes { get; set; } 
			[DataMember]
			public bool IsMonday { get; set; } 
			[DataMember]
			public bool IsTuesday { get; set; } 
			[DataMember]
			public bool IsWednesday { get; set; } 
			[DataMember]
			public bool IsThursday { get; set; } 
			[DataMember]
			public bool IsFriday { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_GOUDfATID_1507_Array cls_Get_OrgUnitData_for_AppointmentTypeID(,P_L5OU_GOUDfATID_1507 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_GOUDfATID_1507_Array invocationResult = cls_Get_OrgUnitData_for_AppointmentTypeID.Invoke(connectionString,P_L5OU_GOUDfATID_1507 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.P_L5OU_GOUDfATID_1507();
parameter.AppointmentTypeID = ...;

*/
