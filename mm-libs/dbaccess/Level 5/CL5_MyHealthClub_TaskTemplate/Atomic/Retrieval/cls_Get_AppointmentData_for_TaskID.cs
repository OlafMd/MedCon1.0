/* 
 * Generated on 8/15/2014 3:35:28 PM
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

namespace CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AppointmentData_for_TaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AppointmentData_for_TaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AP_GADfTID_1529 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AP_GADfTID_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AP_GADfTID_1529();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.SQL.cls_Get_AppointmentData_for_TaskID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TaskID", Parameter.TaskID);



			List<L5AP_GADfTID_1529> results = new List<L5AP_GADfTID_1529>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TaskTemplateName_DictID","DisplayName","PlannedStartDate","PlannedDuration_in_sec","Office_Name_DictID","Street_Name","Street_Number","City_Name" });
				while(reader.Read())
				{
					L5AP_GADfTID_1529 resultItem = new L5AP_GADfTID_1529();
					//0:Parameter TaskTemplateName of type Dict
					resultItem.TaskTemplateName = reader.GetDictionary(0);
					resultItem.TaskTemplateName.SourceTable = "pps_tsk_task_templates";
					loader.Append(resultItem.TaskTemplateName);
					//1:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(1);
					//2:Parameter PlannedStartDate of type DateTime
					resultItem.PlannedStartDate = reader.GetDate(2);
					//3:Parameter PlannedDuration_in_sec of type String
					resultItem.PlannedDuration_in_sec = reader.GetString(3);
					//4:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(4);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//5:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(5);
					//6:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(6);
					//7:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AppointmentData_for_TaskID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AP_GADfTID_1529 Invoke(string ConnectionString,P_L5AP_GADfTID_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AP_GADfTID_1529 Invoke(DbConnection Connection,P_L5AP_GADfTID_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AP_GADfTID_1529 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AP_GADfTID_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AP_GADfTID_1529 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AP_GADfTID_1529 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AP_GADfTID_1529 functionReturn = new FR_L5AP_GADfTID_1529();
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

				throw new Exception("Exception occured in method cls_Get_AppointmentData_for_TaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AP_GADfTID_1529 : FR_Base
	{
		public L5AP_GADfTID_1529 Result	{ get; set; }

		public FR_L5AP_GADfTID_1529() : base() {}

		public FR_L5AP_GADfTID_1529(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AP_GADfTID_1529 for attribute P_L5AP_GADfTID_1529
		[DataContract]
		public class P_L5AP_GADfTID_1529 
		{
			//Standard type parameters
			[DataMember]
			public Guid TaskID { get; set; } 

		}
		#endregion
		#region SClass L5AP_GADfTID_1529 for attribute L5AP_GADfTID_1529
		[DataContract]
		public class L5AP_GADfTID_1529 
		{
			//Standard type parameters
			[DataMember]
			public Dict TaskTemplateName { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public DateTime PlannedStartDate { get; set; } 
			[DataMember]
			public String PlannedDuration_in_sec { get; set; } 
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

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AP_GADfTID_1529 cls_Get_AppointmentData_for_TaskID(,P_L5AP_GADfTID_1529 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AP_GADfTID_1529 invocationResult = cls_Get_AppointmentData_for_TaskID.Invoke(connectionString,P_L5AP_GADfTID_1529 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TaskTemplate.Atomic.Retrieval.P_L5AP_GADfTID_1529();
parameter.TaskID = ...;

*/
