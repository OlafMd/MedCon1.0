/* 
 * Generated on 11/18/2014 9:53:52 AM
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

namespace CL6_DanuTask_QuickTask.Atomic.Retrieval
{
	/// <summary>
    /// Retrieval of basic info for invested worktimes per active account.
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6QT_GQTIWTfAUaST_1046_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6QT_GQTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6QT_GQTIWTfAUaST_1046_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_QuickTask.Atomic.Retrieval.SQL.cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartDate", Parameter.StartDate);



			List<L6QT_GQTIWTfAUaST_1046> results = new List<L6QT_GQTIWTfAUaST_1046>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_QuickTaskID","IdentificationNumber","QuickTask_Title_DictID","QuickTask_Description_DictID","QuickTask_StartTime","QuickTask_Type_RefID","TMS_PRO_ProjectID","Name_DictID","R_QuickTask_InvestedTime_min" });
				while(reader.Read())
				{
					L6QT_GQTIWTfAUaST_1046 resultItem = new L6QT_GQTIWTfAUaST_1046();
					//0:Parameter TMS_QuickTaskID of type Guid
					resultItem.TMS_QuickTaskID = reader.GetGuid(0);
					//1:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(1);
					//2:Parameter QuickTask_Title of type Dict
					resultItem.QuickTask_Title = reader.GetDictionary(2);
					resultItem.QuickTask_Title.SourceTable = "tms_quicktasks";
					loader.Append(resultItem.QuickTask_Title);
					//3:Parameter QuickTask_Description of type Dict
					resultItem.QuickTask_Description = reader.GetDictionary(3);
					resultItem.QuickTask_Description.SourceTable = "tms_quicktasks";
					loader.Append(resultItem.QuickTask_Description);
					//4:Parameter QuickTask_StartTime of type DateTime
					resultItem.QuickTask_StartTime = reader.GetDate(4);
					//5:Parameter QuickTask_Type_RefID of type Guid
					resultItem.QuickTask_Type_RefID = reader.GetGuid(5);
					//6:Parameter TMS_PRO_ProjectID of type Guid
					resultItem.TMS_PRO_ProjectID = reader.GetGuid(6);
					//7:Parameter Project_Name of type Dict
					resultItem.Project_Name = reader.GetDictionary(7);
					resultItem.Project_Name.SourceTable = "tms_pro_projects";
					loader.Append(resultItem.Project_Name);
					//8:Parameter R_QuickTask_InvestedTime_min of type Double
					resultItem.R_QuickTask_InvestedTime_min = reader.GetDouble(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date",ex);
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
		public static FR_L6QT_GQTIWTfAUaST_1046_Array Invoke(string ConnectionString,P_L6QT_GQTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6QT_GQTIWTfAUaST_1046_Array Invoke(DbConnection Connection,P_L6QT_GQTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6QT_GQTIWTfAUaST_1046_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6QT_GQTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6QT_GQTIWTfAUaST_1046_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6QT_GQTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6QT_GQTIWTfAUaST_1046_Array functionReturn = new FR_L6QT_GQTIWTfAUaST_1046_Array();
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

				throw new Exception("Exception occured in method cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6QT_GQTIWTfAUaST_1046_Array : FR_Base
	{
		public L6QT_GQTIWTfAUaST_1046[] Result	{ get; set; } 
		public FR_L6QT_GQTIWTfAUaST_1046_Array() : base() {}

		public FR_L6QT_GQTIWTfAUaST_1046_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6QT_GQTIWTfAUaST_1046 for attribute P_L6QT_GQTIWTfAUaST_1046
		[DataContract]
		public class P_L6QT_GQTIWTfAUaST_1046 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 

		}
		#endregion
		#region SClass L6QT_GQTIWTfAUaST_1046 for attribute L6QT_GQTIWTfAUaST_1046
		[DataContract]
		public class L6QT_GQTIWTfAUaST_1046 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_QuickTaskID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Dict QuickTask_Title { get; set; } 
			[DataMember]
			public Dict QuickTask_Description { get; set; } 
			[DataMember]
			public DateTime QuickTask_StartTime { get; set; } 
			[DataMember]
			public Guid QuickTask_Type_RefID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectID { get; set; } 
			[DataMember]
			public Dict Project_Name { get; set; } 
			[DataMember]
			public Double R_QuickTask_InvestedTime_min { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6QT_GQTIWTfAUaST_1046_Array cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date(,P_L6QT_GQTIWTfAUaST_1046 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6QT_GQTIWTfAUaST_1046_Array invocationResult = cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date.Invoke(connectionString,P_L6QT_GQTIWTfAUaST_1046 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_QuickTask.Atomic.Retrieval.P_L6QT_GQTIWTfAUaST_1046();
parameter.StartDate = ...;

*/
