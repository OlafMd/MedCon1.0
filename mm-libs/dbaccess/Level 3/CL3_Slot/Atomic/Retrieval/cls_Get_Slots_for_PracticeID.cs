/* 
 * Generated on 04.11.2014 16:13:27
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

namespace CL3_TaskTemplateSlot.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Slots_for_PracticeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Slots_for_PracticeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3TTS_SfPID_1542_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3TTS_SfPID_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3TTS_SfPID_1542_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_TaskTemplateSlot.Atomic.Retrieval.SQL.cls_Get_Slots_for_PracticeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L3TTS_SfPID_1542> results = new List<L3TTS_SfPID_1542>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PPS_TSK_FreeSlotsForTaskTemplateID","FreeSlotsForTaskTemplateITPL","TaskTemplate_RefID","FreeInterval_End","FreeInterval_Start","IsDeleted" });
				while(reader.Read())
				{
					L3TTS_SfPID_1542 resultItem = new L3TTS_SfPID_1542();
					//0:Parameter PPS_TSK_FreeSlotsForTaskTemplateID of type Guid
					resultItem.PPS_TSK_FreeSlotsForTaskTemplateID = reader.GetGuid(0);
					//1:Parameter FreeSlotsForTaskTemplateITPL of type string
					resultItem.FreeSlotsForTaskTemplateITPL = reader.GetString(1);
					//2:Parameter TaskTemplate_RefID of type Guid
					resultItem.TaskTemplate_RefID = reader.GetGuid(2);
					//3:Parameter FreeInterval_End of type DateTime
					resultItem.FreeInterval_End = reader.GetDate(3);
					//4:Parameter FreeInterval_Start of type DateTime
					resultItem.FreeInterval_Start = reader.GetDate(4);
					//5:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Slots_for_PracticeID",ex);
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
		public static FR_L3TTS_SfPID_1542_Array Invoke(string ConnectionString,P_L3TTS_SfPID_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3TTS_SfPID_1542_Array Invoke(DbConnection Connection,P_L3TTS_SfPID_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3TTS_SfPID_1542_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TTS_SfPID_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3TTS_SfPID_1542_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TTS_SfPID_1542 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3TTS_SfPID_1542_Array functionReturn = new FR_L3TTS_SfPID_1542_Array();
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

				throw new Exception("Exception occured in method cls_Get_Slots_for_PracticeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3TTS_SfPID_1542_Array : FR_Base
	{
		public L3TTS_SfPID_1542[] Result	{ get; set; } 
		public FR_L3TTS_SfPID_1542_Array() : base() {}

		public FR_L3TTS_SfPID_1542_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3TTS_SfPID_1542 for attribute P_L3TTS_SfPID_1542
		[DataContract]
		public class P_L3TTS_SfPID_1542 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L3TTS_SfPID_1542 for attribute L3TTS_SfPID_1542
		[DataContract]
		public class L3TTS_SfPID_1542 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_FreeSlotsForTaskTemplateID { get; set; } 
			[DataMember]
			public string FreeSlotsForTaskTemplateITPL { get; set; } 
			[DataMember]
			public Guid TaskTemplate_RefID { get; set; } 
			[DataMember]
			public DateTime FreeInterval_End { get; set; } 
			[DataMember]
			public DateTime FreeInterval_Start { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3TTS_SfPID_1542_Array cls_Get_Slots_for_PracticeID(,P_L3TTS_SfPID_1542 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3TTS_SfPID_1542_Array invocationResult = cls_Get_Slots_for_PracticeID.Invoke(connectionString,P_L3TTS_SfPID_1542 Parameter,securityTicket);
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
var parameter = new CL3_TaskTemplateSlot.Atomic.Retrieval.P_L3TTS_SfPID_1542();
parameter.OfficeID = ...;

*/
