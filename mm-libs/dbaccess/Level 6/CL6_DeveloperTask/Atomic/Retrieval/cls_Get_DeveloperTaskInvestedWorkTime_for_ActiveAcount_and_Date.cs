/* 
 * Generated on 11/14/2014 5:47:53 PM
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
    /// Retrieval of basic info for invested worktimes of developer task per active account.
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTIWTfAUaST_1046_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6DT_GDTIWTfAUaST_1046_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartDate", Parameter.StartDate);



			List<L6DT_GDTIWTfAUaST_1046> results = new List<L6DT_GDTIWTfAUaST_1046>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","IdentificationNumber","DeveloperTask_Name","DeveloperTask_Description","WorkTime_Start","DeveloperTask_Type_RefID","TMS_PRO_ProjectID","Name_DictID","WorkTime_Amount_min" });
				while(reader.Read())
				{
					L6DT_GDTIWTfAUaST_1046 resultItem = new L6DT_GDTIWTfAUaST_1046();
					//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
					resultItem.TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
					//1:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(1);
					//2:Parameter DeveloperTask_Name of type String
					resultItem.DeveloperTask_Name = reader.GetString(2);
					//3:Parameter DeveloperTask_Description of type String
					resultItem.DeveloperTask_Description = reader.GetString(3);
					//4:Parameter WorkTime_Start of type DateTime
					resultItem.WorkTime_Start = reader.GetDate(4);
					//5:Parameter DeveloperTask_Type_RefID of type Guid
					resultItem.DeveloperTask_Type_RefID = reader.GetGuid(5);
					//6:Parameter TMS_PRO_ProjectID of type Guid
					resultItem.TMS_PRO_ProjectID = reader.GetGuid(6);
					//7:Parameter Project_Name of type Dict
					resultItem.Project_Name = reader.GetDictionary(7);
					resultItem.Project_Name.SourceTable = "tms_pro_projects";
					loader.Append(resultItem.Project_Name);
					//8:Parameter WorkTime_Amount_min of type Double
					resultItem.WorkTime_Amount_min = reader.GetDouble(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date",ex);
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
		public static FR_L6DT_GDTIWTfAUaST_1046_Array Invoke(string ConnectionString,P_L6DT_GDTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIWTfAUaST_1046_Array Invoke(DbConnection Connection,P_L6DT_GDTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTIWTfAUaST_1046_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTIWTfAUaST_1046_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDTIWTfAUaST_1046 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTIWTfAUaST_1046_Array functionReturn = new FR_L6DT_GDTIWTfAUaST_1046_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTIWTfAUaST_1046_Array : FR_Base
	{
		public L6DT_GDTIWTfAUaST_1046[] Result	{ get; set; } 
		public FR_L6DT_GDTIWTfAUaST_1046_Array() : base() {}

		public FR_L6DT_GDTIWTfAUaST_1046_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDTIWTfAUaST_1046 for attribute P_L6DT_GDTIWTfAUaST_1046
		[DataContract]
		public class P_L6DT_GDTIWTfAUaST_1046 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTIWTfAUaST_1046 for attribute L6DT_GDTIWTfAUaST_1046
		[DataContract]
		public class L6DT_GDTIWTfAUaST_1046 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTaskID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public String DeveloperTask_Name { get; set; } 
			[DataMember]
			public String DeveloperTask_Description { get; set; } 
			[DataMember]
			public DateTime WorkTime_Start { get; set; } 
			[DataMember]
			public Guid DeveloperTask_Type_RefID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectID { get; set; } 
			[DataMember]
			public Dict Project_Name { get; set; } 
			[DataMember]
			public Double WorkTime_Amount_min { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTIWTfAUaST_1046_Array cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date(,P_L6DT_GDTIWTfAUaST_1046 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTIWTfAUaST_1046_Array invocationResult = cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date.Invoke(connectionString,P_L6DT_GDTIWTfAUaST_1046 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_DeveloperTask.Atomic.Retrieval.P_L6DT_GDTIWTfAUaST_1046();
parameter.StartDate = ...;

*/
