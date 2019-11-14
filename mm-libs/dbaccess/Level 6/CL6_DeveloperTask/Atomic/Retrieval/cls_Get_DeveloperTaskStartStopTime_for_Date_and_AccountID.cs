/* 
 * Generated on 8/26/2014 14:36:58
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

namespace CL6_DanuTask_DeveloperTask.Atomic.Retrieval
{
	/// <summary>
    /// Get developer task start and stop date for selected date and account
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTaskStartStopTime_for_Date_and_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTaskStartStopTime_for_Date_and_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTSSTfDaA_1356_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDTSSTfDaA_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GDTSSTfDaA_1356_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
            var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTaskStartStopTime_for_Date_and_AccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StatusStopped", Parameter.StatusStopped);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StatusFinished", Parameter.StatusFinished);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StatusStarted", Parameter.StatusStarted);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DateTime", Parameter.DateTime);



			List<L6DT_GDTSSTfDaA_1356> results = new List<L6DT_GDTSSTfDaA_1356>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","IdentificationNumber","Name","Start_Time","End_Time","StatusName" });
				while(reader.Read())
				{
					L6DT_GDTSSTfDaA_1356 resultItem = new L6DT_GDTSSTfDaA_1356();
					//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
					resultItem.TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
					//1:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(1);
					//2:Parameter Name of type String
					resultItem.Name = reader.GetString(2);
					//3:Parameter Start_Time of type DateTime
					resultItem.Start_Time = reader.GetDate(3);
					//4:Parameter End_Time of type DateTime
					resultItem.End_Time = reader.GetDate(4);
					//5:Parameter StatusLabel of type Dict
					resultItem.StatusLabel = reader.GetDictionary(5);
					resultItem.StatusLabel.SourceTable = "tms_pro_developertask_statuses";
					loader.Append(resultItem.StatusLabel);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTaskStartStopTime_for_Date_and_AccountID",ex);
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
		public static FR_L6DT_GDTSSTfDaA_1356_Array Invoke(string ConnectionString,P_L6DT_GDTSSTfDaA_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTSSTfDaA_1356_Array Invoke(DbConnection Connection,P_L6DT_GDTSSTfDaA_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTSSTfDaA_1356_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDTSSTfDaA_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTSSTfDaA_1356_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDTSSTfDaA_1356 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTSSTfDaA_1356_Array functionReturn = new FR_L6DT_GDTSSTfDaA_1356_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTaskStartStopTime_for_Date_and_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTSSTfDaA_1356_Array : FR_Base
	{
		public L6DT_GDTSSTfDaA_1356[] Result	{ get; set; } 
		public FR_L6DT_GDTSSTfDaA_1356_Array() : base() {}

		public FR_L6DT_GDTSSTfDaA_1356_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDTSSTfDaA_1356 for attribute P_L6DT_GDTSSTfDaA_1356
		[DataContract]
		public class P_L6DT_GDTSSTfDaA_1356 
		{
			//Standard type parameters
			[DataMember]
			public string StatusStopped { get; set; } 
			[DataMember]
			public string StatusFinished { get; set; } 
			[DataMember]
			public string StatusStarted { get; set; } 
			[DataMember]
			public DateTime DateTime { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTSSTfDaA_1356 for attribute L6DT_GDTSSTfDaA_1356
		[DataContract]
		public class L6DT_GDTSSTfDaA_1356 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTaskID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public DateTime Start_Time { get; set; } 
			[DataMember]
			public DateTime End_Time { get; set; } 
			[DataMember]
			public Dict StatusLabel { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTSSTfDaA_1356_Array cls_Get_DeveloperTaskStartStopTime_for_Date_and_AccountID(,P_L6DT_GDTSSTfDaA_1356 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTSSTfDaA_1356_Array invocationResult = cls_Get_DeveloperTaskStartStopTime_for_Date_and_AccountID.Invoke(connectionString,P_L6DT_GDTSSTfDaA_1356 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Atomic.Retrieval.P_L6DT_GDTSSTfDaA_1356();
parameter.StatusStopped = ...;
parameter.StatusFinished = ...;
parameter.StatusStarted = ...;
parameter.DateTime = ...;

*/
