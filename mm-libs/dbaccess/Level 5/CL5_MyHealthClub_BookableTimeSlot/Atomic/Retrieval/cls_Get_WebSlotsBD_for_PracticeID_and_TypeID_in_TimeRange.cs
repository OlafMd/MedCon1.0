/* 
 * Generated on 17.01.2015 11:45:53
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

namespace CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_WebSlotsBD_for_PracticeID_and_TypeID_in_TimeRange.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_WebSlotsBD_for_PracticeID_and_TypeID_in_TimeRange
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BTS_GWSBD_fPTTR_1641_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BTS_GWSBD_fPTTR_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BTS_GWSBD_fPTTR_1641_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval.SQL.cls_Get_WebSlotsBD_for_PracticeID_and_TypeID_in_TimeRange.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TypeID", Parameter.TypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FromDate", Parameter.FromDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ToDate", Parameter.ToDate);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AvaTypeMachingID", Parameter.AvaTypeMachingID);



			List<L5BTS_GWSBD_fPTTR_1641> results = new List<L5BTS_GWSBD_fPTTR_1641>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_BOK_BookableTimeSlotID","TaskTemplate_RefID","FreeSlotsForTaskTemplateITPL","FreeInterval_End","FreeInterval_Start" });
				while(reader.Read())
				{
					L5BTS_GWSBD_fPTTR_1641 resultItem = new L5BTS_GWSBD_fPTTR_1641();
					//0:Parameter PPS_TSK_BOK_BookableTimeSlotID of type Guid
					resultItem.PPS_TSK_BOK_BookableTimeSlotID = reader.GetGuid(0);
					//1:Parameter TaskTemplate_RefID of type Guid
					resultItem.TaskTemplate_RefID = reader.GetGuid(1);
					//2:Parameter FreeSlotsForTaskTemplateITPL of type string
					resultItem.FreeSlotsForTaskTemplateITPL = reader.GetString(2);
					//3:Parameter FreeInterval_End of type DateTime
					resultItem.FreeInterval_End = reader.GetDate(3);
					//4:Parameter FreeInterval_Start of type DateTime
					resultItem.FreeInterval_Start = reader.GetDate(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_WebSlotsBD_for_PracticeID_and_TypeID_in_TimeRange",ex);
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
		public static FR_L5BTS_GWSBD_fPTTR_1641_Array Invoke(string ConnectionString,P_L5BTS_GWSBD_fPTTR_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BTS_GWSBD_fPTTR_1641_Array Invoke(DbConnection Connection,P_L5BTS_GWSBD_fPTTR_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BTS_GWSBD_fPTTR_1641_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BTS_GWSBD_fPTTR_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BTS_GWSBD_fPTTR_1641_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BTS_GWSBD_fPTTR_1641 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BTS_GWSBD_fPTTR_1641_Array functionReturn = new FR_L5BTS_GWSBD_fPTTR_1641_Array();
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

				throw new Exception("Exception occured in method cls_Get_WebSlotsBD_for_PracticeID_and_TypeID_in_TimeRange",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BTS_GWSBD_fPTTR_1641_Array : FR_Base
	{
		public L5BTS_GWSBD_fPTTR_1641[] Result	{ get; set; } 
		public FR_L5BTS_GWSBD_fPTTR_1641_Array() : base() {}

		public FR_L5BTS_GWSBD_fPTTR_1641_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BTS_GWSBD_fPTTR_1641 for attribute P_L5BTS_GWSBD_fPTTR_1641
		[DataContract]
		public class P_L5BTS_GWSBD_fPTTR_1641 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid TypeID { get; set; } 
			[DataMember]
			public DateTime FromDate { get; set; } 
			[DataMember]
			public DateTime ToDate { get; set; } 
			[DataMember]
			public string AvaTypeMachingID { get; set; } 

		}
		#endregion
		#region SClass L5BTS_GWSBD_fPTTR_1641 for attribute L5BTS_GWSBD_fPTTR_1641
		[DataContract]
		public class L5BTS_GWSBD_fPTTR_1641 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_BOK_BookableTimeSlotID { get; set; } 
			[DataMember]
			public Guid TaskTemplate_RefID { get; set; } 
			[DataMember]
			public string FreeSlotsForTaskTemplateITPL { get; set; } 
			[DataMember]
			public DateTime FreeInterval_End { get; set; } 
			[DataMember]
			public DateTime FreeInterval_Start { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BTS_GWSBD_fPTTR_1641_Array cls_Get_WebSlotsBD_for_PracticeID_and_TypeID_in_TimeRange(,P_L5BTS_GWSBD_fPTTR_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BTS_GWSBD_fPTTR_1641_Array invocationResult = cls_Get_WebSlotsBD_for_PracticeID_and_TypeID_in_TimeRange.Invoke(connectionString,P_L5BTS_GWSBD_fPTTR_1641 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_BookableTimeSlot.Atomic.Retrieval.P_L5BTS_GWSBD_fPTTR_1641();
parameter.OfficeID = ...;
parameter.TypeID = ...;
parameter.FromDate = ...;
parameter.ToDate = ...;
parameter.AvaTypeMachingID = ...;

*/
