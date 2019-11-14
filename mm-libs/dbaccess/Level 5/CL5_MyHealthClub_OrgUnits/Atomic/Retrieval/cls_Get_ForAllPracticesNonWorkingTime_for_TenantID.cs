/* 
 * Generated on 8/13/2014 5:05:56 PM
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
    /// var result = cls_Get_ForAllPracticesNonWorkingTime_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ForAllPracticesNonWorkingTime_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_GFAPNWTfTID_1514_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OU_GFAPNWTfTID_1514_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.SQL.cls_Get_ForAllPracticesNonWorkingTime_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5OU_GFAPNWTfTID_1514_raw> results = new List<L5OU_GFAPNWTfTID_1514_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Office_RefID","CMN_CAL_EventID","IsRepetitive","IsWholeDayEvent","StartTime","EndTime","IsDaily","IsWeekly","IsMonthly","IsYearly" });
				while(reader.Read())
				{
					L5OU_GFAPNWTfTID_1514_raw resultItem = new L5OU_GFAPNWTfTID_1514_raw();
					//0:Parameter Office_RefID of type Guid
					resultItem.Office_RefID = reader.GetGuid(0);
					//1:Parameter CMN_CAL_EventID of type Guid
					resultItem.CMN_CAL_EventID = reader.GetGuid(1);
					//2:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(2);
					//3:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(3);
					//4:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(4);
					//5:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(5);
					//6:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(6);
					//7:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(7);
					//8:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(8);
					//9:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ForAllPracticesNonWorkingTime_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OU_GFAPNWTfTID_1514_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_GFAPNWTfTID_1514_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_GFAPNWTfTID_1514_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_GFAPNWTfTID_1514_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_GFAPNWTfTID_1514_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_GFAPNWTfTID_1514_Array functionReturn = new FR_L5OU_GFAPNWTfTID_1514_Array();
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

				throw new Exception("Exception occured in method cls_Get_ForAllPracticesNonWorkingTime_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OU_GFAPNWTfTID_1514_raw 
	{
		public Guid Office_RefID; 
		public Guid CMN_CAL_EventID; 
		public bool IsRepetitive; 
		public bool IsWholeDayEvent; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public bool IsDaily; 
		public bool IsWeekly; 
		public bool IsMonthly; 
		public bool IsYearly; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OU_GFAPNWTfTID_1514[] Convert(List<L5OU_GFAPNWTfTID_1514_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OU_GFAPNWTfTID_1514 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.Office_RefID)).ToArray()
	group el_L5OU_GFAPNWTfTID_1514 by new 
	{ 
		el_L5OU_GFAPNWTfTID_1514.Office_RefID,

	}
	into gfunct_L5OU_GFAPNWTfTID_1514
	select new L5OU_GFAPNWTfTID_1514
	{     
		Office_RefID = gfunct_L5OU_GFAPNWTfTID_1514.Key.Office_RefID ,

		Events = 
		(
			from el_Events in gfunct_L5OU_GFAPNWTfTID_1514.Where(element => !EqualsDefaultValue(element.CMN_CAL_EventID)).ToArray()
			group el_Events by new 
			{ 
				el_Events.CMN_CAL_EventID,

			}
			into gfunct_Events
			select new L5OU_GFAPNWTfTID_1514_Events
			{     
				CMN_CAL_EventID = gfunct_Events.Key.CMN_CAL_EventID ,
				IsRepetitive = gfunct_Events.FirstOrDefault().IsRepetitive ,
				IsWholeDayEvent = gfunct_Events.FirstOrDefault().IsWholeDayEvent ,
				StartTime = gfunct_Events.FirstOrDefault().StartTime ,
				EndTime = gfunct_Events.FirstOrDefault().EndTime ,
				IsDaily = gfunct_Events.FirstOrDefault().IsDaily ,
				IsWeekly = gfunct_Events.FirstOrDefault().IsWeekly ,
				IsMonthly = gfunct_Events.FirstOrDefault().IsMonthly ,
				IsYearly = gfunct_Events.FirstOrDefault().IsYearly ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_GFAPNWTfTID_1514_Array : FR_Base
	{
		public L5OU_GFAPNWTfTID_1514[] Result	{ get; set; } 
		public FR_L5OU_GFAPNWTfTID_1514_Array() : base() {}

		public FR_L5OU_GFAPNWTfTID_1514_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OU_GFAPNWTfTID_1514 for attribute L5OU_GFAPNWTfTID_1514
		[DataContract]
		public class L5OU_GFAPNWTfTID_1514 
		{
			[DataMember]
			public L5OU_GFAPNWTfTID_1514_Events[] Events { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid Office_RefID { get; set; } 

		}
		#endregion
		#region SClass L5OU_GFAPNWTfTID_1514_Events for attribute Events
		[DataContract]
		public class L5OU_GFAPNWTfTID_1514_Events 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_CAL_EventID { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public bool IsWholeDayEvent { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 
			[DataMember]
			public bool IsWeekly { get; set; } 
			[DataMember]
			public bool IsMonthly { get; set; } 
			[DataMember]
			public bool IsYearly { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_GFAPNWTfTID_1514_Array cls_Get_ForAllPracticesNonWorkingTime_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_GFAPNWTfTID_1514_Array invocationResult = cls_Get_ForAllPracticesNonWorkingTime_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

