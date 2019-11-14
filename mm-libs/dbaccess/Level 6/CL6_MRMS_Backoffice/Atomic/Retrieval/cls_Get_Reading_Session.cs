/* 
 * Generated on 27.1.2015 21:44:12
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
    /// var result = cls_Get_Reading_Session.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Reading_Session
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6MRMS_GRS_2126 Execute(DbConnection Connection,DbTransaction Transaction,P_L6MRMS_GRS_2126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6MRMS_GRS_2126();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MRMS_Backoffice.Atomic.Retrieval.SQL.cls_Get_Reading_Session.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReadingSessionId", Parameter.ReadingSessionId);



			List<L6MRMS_GRS_2126_raw> results = new List<L6MRMS_GRS_2126_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MeasurementRunID","StatusGlobalID","StatusName","StatusChangedBy","StatusChangedOn" });
				while(reader.Read())
				{
					L6MRMS_GRS_2126_raw resultItem = new L6MRMS_GRS_2126_raw();
					//0:Parameter MeasurementRunID of type Guid
					resultItem.MeasurementRunID = reader.GetGuid(0);
					//1:Parameter StatusGlobalID of type string
					resultItem.StatusGlobalID = reader.GetString(1);
					//2:Parameter StatusName of type string
					resultItem.StatusName = reader.GetString(2);
					//3:Parameter StatusChangedBy of type string
					resultItem.StatusChangedBy = reader.GetString(3);
					//4:Parameter StatusChangedOn of type DateTime
					resultItem.StatusChangedOn = reader.GetDate(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Reading_Session",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6MRMS_GRS_2126_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6MRMS_GRS_2126 Invoke(string ConnectionString,P_L6MRMS_GRS_2126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GRS_2126 Invoke(DbConnection Connection,P_L6MRMS_GRS_2126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6MRMS_GRS_2126 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6MRMS_GRS_2126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6MRMS_GRS_2126 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6MRMS_GRS_2126 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6MRMS_GRS_2126 functionReturn = new FR_L6MRMS_GRS_2126();
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

				throw new Exception("Exception occured in method cls_Get_Reading_Session",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6MRMS_GRS_2126_raw 
	{
		public Guid MeasurementRunID; 
		public string StatusGlobalID; 
		public string StatusName; 
		public string StatusChangedBy; 
		public DateTime StatusChangedOn; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6MRMS_GRS_2126[] Convert(List<L6MRMS_GRS_2126_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6MRMS_GRS_2126 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.MeasurementRunID)).ToArray()
	group el_L6MRMS_GRS_2126 by new 
	{ 
		el_L6MRMS_GRS_2126.MeasurementRunID,

	}
	into gfunct_L6MRMS_GRS_2126
	select new L6MRMS_GRS_2126
	{     
		MeasurementRunID = gfunct_L6MRMS_GRS_2126.Key.MeasurementRunID ,

		StatusHistoryEntries = 
		(
			from el_StatusHistoryEntries in gfunct_L6MRMS_GRS_2126.ToArray()
			select new L6MRMS_GRS_2126a
			{     
				StatusGlobalID = el_StatusHistoryEntries.StatusGlobalID,
				StatusName = el_StatusHistoryEntries.StatusName,
				StatusChangedBy = el_StatusHistoryEntries.StatusChangedBy,
				StatusChangedOn = el_StatusHistoryEntries.StatusChangedOn,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6MRMS_GRS_2126 : FR_Base
	{
		public L6MRMS_GRS_2126 Result	{ get; set; }

		public FR_L6MRMS_GRS_2126() : base() {}

		public FR_L6MRMS_GRS_2126(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6MRMS_GRS_2126 for attribute P_L6MRMS_GRS_2126
		[DataContract]
		public class P_L6MRMS_GRS_2126 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReadingSessionId { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GRS_2126 for attribute L6MRMS_GRS_2126
		[DataContract]
		public class L6MRMS_GRS_2126 
		{
			[DataMember]
			public L6MRMS_GRS_2126a[] StatusHistoryEntries { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid MeasurementRunID { get; set; } 

		}
		#endregion
		#region SClass L6MRMS_GRS_2126a for attribute StatusHistoryEntries
		[DataContract]
		public class L6MRMS_GRS_2126a 
		{
			//Standard type parameters
			[DataMember]
			public string StatusGlobalID { get; set; } 
			[DataMember]
			public string StatusName { get; set; } 
			[DataMember]
			public string StatusChangedBy { get; set; } 
			[DataMember]
			public DateTime StatusChangedOn { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6MRMS_GRS_2126 cls_Get_Reading_Session(,P_L6MRMS_GRS_2126 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6MRMS_GRS_2126 invocationResult = cls_Get_Reading_Session.Invoke(connectionString,P_L6MRMS_GRS_2126 Parameter,securityTicket);
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
var parameter = new CL6_MRMS_Backoffice.Atomic.Retrieval.P_L6MRMS_GRS_2126();
parameter.ReadingSessionId = ...;

*/
