/* 
 * Generated on 30.10.2014 11:03:33
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
    /// var result = cls_Get_TimeExceptionsForAllStaff.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TimeExceptionsForAllStaff
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TE_GTEFAS_1440_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TE_GTEFAS_1440_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TimeAndException.Atomic.Retrieval.SQL.cls_Get_TimeExceptionsForAllStaff.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5TE_GTEFAS_1440_raw> results = new List<L5TE_GTEFAS_1440_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmployeeID","StartTime","EndTime","IsMonthly","IsYearly","IsWeekly","IsDaily","IsRepetitive","IsWholeDayEvent","CMN_CAL_EventID" });
				while(reader.Read())
				{
					L5TE_GTEFAS_1440_raw resultItem = new L5TE_GTEFAS_1440_raw();
					//0:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(0);
					//1:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(1);
					//2:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(2);
					//3:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(3);
					//4:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(4);
					//5:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(5);
					//6:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(6);
					//7:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(7);
					//8:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(8);
					//9:Parameter CMN_CAL_EventID of type Guid
					resultItem.CMN_CAL_EventID = reader.GetGuid(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_TimeExceptionsForAllStaff",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5TE_GTEFAS_1440_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TE_GTEFAS_1440_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TE_GTEFAS_1440_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TE_GTEFAS_1440_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TE_GTEFAS_1440_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TE_GTEFAS_1440_Array functionReturn = new FR_L5TE_GTEFAS_1440_Array();
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

				throw new Exception("Exception occured in method cls_Get_TimeExceptionsForAllStaff",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5TE_GTEFAS_1440_raw 
	{
		public Guid CMN_BPT_EMP_EmployeeID; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public bool IsMonthly; 
		public bool IsYearly; 
		public bool IsWeekly; 
		public bool IsDaily; 
		public bool IsRepetitive; 
		public bool IsWholeDayEvent; 
		public Guid CMN_CAL_EventID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5TE_GTEFAS_1440[] Convert(List<L5TE_GTEFAS_1440_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5TE_GTEFAS_1440 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_EmployeeID)).ToArray()
	group el_L5TE_GTEFAS_1440 by new 
	{ 
		el_L5TE_GTEFAS_1440.CMN_BPT_EMP_EmployeeID,

	}
	into gfunct_L5TE_GTEFAS_1440
	select new L5TE_GTEFAS_1440
	{     
		CMN_BPT_EMP_EmployeeID = gfunct_L5TE_GTEFAS_1440.Key.CMN_BPT_EMP_EmployeeID ,

		Events = 
		(
			from el_Events in gfunct_L5TE_GTEFAS_1440.Where(element => !EqualsDefaultValue(element.CMN_CAL_EventID)).ToArray()
			group el_Events by new 
			{ 
				el_Events.CMN_CAL_EventID,

			}
			into gfunct_Events
			select new L5TE_GTEFAS_1440_Events
			{     
				StartTime = gfunct_Events.FirstOrDefault().StartTime ,
				EndTime = gfunct_Events.FirstOrDefault().EndTime ,
				IsMonthly = gfunct_Events.FirstOrDefault().IsMonthly ,
				IsYearly = gfunct_Events.FirstOrDefault().IsYearly ,
				IsWeekly = gfunct_Events.FirstOrDefault().IsWeekly ,
				IsDaily = gfunct_Events.FirstOrDefault().IsDaily ,
				IsRepetitive = gfunct_Events.FirstOrDefault().IsRepetitive ,
				IsWholeDayEvent = gfunct_Events.FirstOrDefault().IsWholeDayEvent ,
				CMN_CAL_EventID = gfunct_Events.Key.CMN_CAL_EventID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5TE_GTEFAS_1440_Array : FR_Base
	{
		public L5TE_GTEFAS_1440[] Result	{ get; set; } 
		public FR_L5TE_GTEFAS_1440_Array() : base() {}

		public FR_L5TE_GTEFAS_1440_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5TE_GTEFAS_1440 for attribute L5TE_GTEFAS_1440
		[DataContract]
		public class L5TE_GTEFAS_1440 
		{
			[DataMember]
			public L5TE_GTEFAS_1440_Events[] Events { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_EMP_EmployeeID { get; set; } 

		}
		#endregion
		#region SClass L5TE_GTEFAS_1440_Events for attribute Events
		[DataContract]
		public class L5TE_GTEFAS_1440_Events 
		{
			//Standard type parameters
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
			public bool IsDaily { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public bool IsWholeDayEvent { get; set; } 
			[DataMember]
			public Guid CMN_CAL_EventID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TE_GTEFAS_1440_Array cls_Get_TimeExceptionsForAllStaff(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TE_GTEFAS_1440_Array invocationResult = cls_Get_TimeExceptionsForAllStaff.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

