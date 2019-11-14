/* 
 * Generated on 3/2/2015 10:29:32 PM
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

namespace CL6_MRMS_Backoffice.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Reading_Sessions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Reading_Sessions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6MRMS_GARS_1941_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6MRMS_GARS_1941_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MRMS_Backoffice.Atomic.Retrieval.SQL.cls_Get_All_Reading_Sessions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L6MRMS_GARS_1941_raw> results = new List<L6MRMS_GARS_1941_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MeasurementRunID","MeasuredCount","NotMeasuredCount","MRS_RUN_MeasurementRun_StatusHistoryID","StatusGlobalID","StatusName","StatusChangedBy","StatusChangedOn","FirstName","LastName" });
				while(reader.Read())
				{
					L6MRMS_GARS_1941_raw resultItem = new L6MRMS_GARS_1941_raw();
					//0:Parameter MeasurementRunID of type Guid
					resultItem.MeasurementRunID = reader.GetGuid(0);
					//1:Parameter MeasuredCount of type int
					resultItem.MeasuredCount = reader.GetInteger(1);
					//2:Parameter NotMeasuredCount of type int
					resultItem.NotMeasuredCount = reader.GetInteger(2);
					//3:Parameter MRS_RUN_MeasurementRun_StatusHistoryID of type Guid
					resultItem.MRS_RUN_MeasurementRun_StatusHistoryID = reader.GetGuid(3);
					//4:Parameter StatusGlobalID of type string
					resultItem.StatusGlobalID = reader.GetString(4);
					//5:Parameter StatusName of type string
					resultItem.StatusName = reader.GetString(5);
					//6:Parameter StatusChangedBy of type string
					resultItem.StatusChangedBy = reader.GetString(6);
					//7:Parameter StatusChangedOn of type DateTime
					resultItem.StatusChangedOn = reader.GetDate(7);
					//8:Parameter FirstName of type string
					resultItem.FirstName = reader.GetString(8);
					//9:Parameter LastName of type string
					resultItem.LastName = reader.GetString(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Reading_Sessions",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6MRMS_GARS_1941_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6MRMS_GARS_1941_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GARS_1941_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GARS_1941_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6MRMS_GARS_1941_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6MRMS_GARS_1941_Array functionReturn = new FR_L6MRMS_GARS_1941_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Reading_Sessions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6MRMS_GARS_1941_raw 
	{
		public Guid MeasurementRunID; 
		public int MeasuredCount; 
		public int NotMeasuredCount; 
		public Guid MRS_RUN_MeasurementRun_StatusHistoryID; 
		public string StatusGlobalID; 
		public string StatusName; 
		public string StatusChangedBy; 
		public DateTime StatusChangedOn; 
		public string FirstName; 
		public string LastName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6MRMS_GARS_1941[] Convert(List<L6MRMS_GARS_1941_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6MRMS_GARS_1941 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.MeasurementRunID)).ToArray()
	group el_L6MRMS_GARS_1941 by new 
	{ 
		el_L6MRMS_GARS_1941.MeasurementRunID,

	}
	into gfunct_L6MRMS_GARS_1941
	select new L6MRMS_GARS_1941
	{     
		MeasurementRunID = gfunct_L6MRMS_GARS_1941.Key.MeasurementRunID ,
		MeasuredCount = gfunct_L6MRMS_GARS_1941.FirstOrDefault().MeasuredCount ,
		NotMeasuredCount = gfunct_L6MRMS_GARS_1941.FirstOrDefault().NotMeasuredCount ,

		StatusHistoryEntries = 
		(
			from el_StatusHistoryEntries in gfunct_L6MRMS_GARS_1941.Where(element => !EqualsDefaultValue(element.MRS_RUN_MeasurementRun_StatusHistoryID)).ToArray()
			group el_StatusHistoryEntries by new 
			{ 
				el_StatusHistoryEntries.MRS_RUN_MeasurementRun_StatusHistoryID,

			}
			into gfunct_StatusHistoryEntries
			select new L6MRMS_GARS_1941a
			{     
				MRS_RUN_MeasurementRun_StatusHistoryID = gfunct_StatusHistoryEntries.Key.MRS_RUN_MeasurementRun_StatusHistoryID ,
				StatusGlobalID = gfunct_StatusHistoryEntries.FirstOrDefault().StatusGlobalID ,
				StatusName = gfunct_StatusHistoryEntries.FirstOrDefault().StatusName ,
				StatusChangedBy = gfunct_StatusHistoryEntries.FirstOrDefault().StatusChangedBy ,
				StatusChangedOn = gfunct_StatusHistoryEntries.FirstOrDefault().StatusChangedOn ,
				FirstName = gfunct_StatusHistoryEntries.FirstOrDefault().FirstName ,
				LastName = gfunct_StatusHistoryEntries.FirstOrDefault().LastName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6MRMS_GARS_1941_Array : FR_Base
	{
		public L6MRMS_GARS_1941[] Result	{ get; set; } 
		public FR_L6MRMS_GARS_1941_Array() : base() {}

		public FR_L6MRMS_GARS_1941_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6MRMS_GARS_1941 for attribute L6MRMS_GARS_1941
		[DataContract]
		public class L6MRMS_GARS_1941 
		{
			[DataMember]
			public L6MRMS_GARS_1941a[] StatusHistoryEntries { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid MeasurementRunID { get; set; } 
			[DataMember]
			public int MeasuredCount { get; set; } 
			[DataMember]
			public int NotMeasuredCount { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GARS_1941a for attribute StatusHistoryEntries
		[DataContract]
		public class L6MRMS_GARS_1941a 
		{
			//Standard type parameters
			[DataMember]
			public Guid MRS_RUN_MeasurementRun_StatusHistoryID { get; set; } 
			[DataMember]
			public string StatusGlobalID { get; set; } 
			[DataMember]
			public string StatusName { get; set; } 
			[DataMember]
			public string StatusChangedBy { get; set; } 
			[DataMember]
			public DateTime StatusChangedOn { get; set; } 
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6MRMS_GARS_1941_Array cls_Get_All_Reading_Sessions(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6MRMS_GARS_1941_Array invocationResult = cls_Get_All_Reading_Sessions.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

