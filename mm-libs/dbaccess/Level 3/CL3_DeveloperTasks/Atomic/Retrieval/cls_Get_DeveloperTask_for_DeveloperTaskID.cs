/* 
 * Generated on 7/16/2014 4:41:35 PM
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

namespace CL3_DeveloperTask.Atomic.Retrieval
{
	/// <summary>
    /// Get developer task for specified developer task ID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTask_for_DeveloperTaskID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTask_for_DeveloperTaskID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DT_GDTfDT_1509 Execute(DbConnection Connection,DbTransaction Transaction,P_L3DT_GDTfDT_1509 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DT_GDTfDT_1509();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTask_for_DeveloperTaskID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TaskID", Parameter.TaskID);



			List<L3DT_GDTfDT_1509> results = new List<L3DT_GDTfDT_1509>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IdentificationNumber","DOC_Structure_Header_RefID","CreatedBy_ProjectMember_RefID","Priority_RefID","Project_RefID","DeveloperTask_Type_RefID","GrabbedByMember_RefID","Completion_Deadline","Completion_Timestamp","Name","Description","Developer_Points","IsComplete","IsIncompleteInformation","IsArchived","IsBeingPrepared","Creation_Timestamp","IsDeleted","Tenant_RefID","DeveloperTime_CurrentInvestment_min","DeveloperTime_RequiredEstimation_min","PercentageComplete" });
				while(reader.Read())
				{
					L3DT_GDTfDT_1509 resultItem = new L3DT_GDTfDT_1509();
					//0:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(0);
					//1:Parameter DOC_Structure_Header_RefID of type Guid
					resultItem.DOC_Structure_Header_RefID = reader.GetGuid(1);
					//2:Parameter CreatedBy_ProjectMember_RefID of type Guid
					resultItem.CreatedBy_ProjectMember_RefID = reader.GetGuid(2);
					//3:Parameter Priority_RefID of type Guid
					resultItem.Priority_RefID = reader.GetGuid(3);
					//4:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(4);
					//5:Parameter DeveloperTask_Type_RefID of type Guid
					resultItem.DeveloperTask_Type_RefID = reader.GetGuid(5);
					//6:Parameter GrabbedByMember_RefID of type Guid
					resultItem.GrabbedByMember_RefID = reader.GetGuid(6);
					//7:Parameter Completion_Deadline of type DateTime
					resultItem.Completion_Deadline = reader.GetDate(7);
					//8:Parameter Completion_Timestamp of type DateTime
					resultItem.Completion_Timestamp = reader.GetDate(8);
					//9:Parameter Name of type String
					resultItem.Name = reader.GetString(9);
					//10:Parameter Description of type String
					resultItem.Description = reader.GetString(10);
					//11:Parameter Developer_Points of type int
					resultItem.Developer_Points = reader.GetInteger(11);
					//12:Parameter IsComplete of type bool
					resultItem.IsComplete = reader.GetBoolean(12);
					//13:Parameter IsIncompleteInformation of type bool
					resultItem.IsIncompleteInformation = reader.GetBoolean(13);
					//14:Parameter IsArchived of type bool
					resultItem.IsArchived = reader.GetBoolean(14);
					//15:Parameter IsBeingPrepared of type bool
					resultItem.IsBeingPrepared = reader.GetBoolean(15);
					//16:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(16);
					//17:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(17);
					//18:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(18);
					//19:Parameter DeveloperTime_CurrentInvestment_min of type Double
					resultItem.DeveloperTime_CurrentInvestment_min = reader.GetDouble(19);
					//20:Parameter DeveloperTime_RequiredEstimation_min of type Double
					resultItem.DeveloperTime_RequiredEstimation_min = reader.GetDouble(20);
					//21:Parameter PercentageComplete of type Double
					resultItem.PercentageComplete = reader.GetDouble(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTask_for_DeveloperTaskID",ex);
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
		public static FR_L3DT_GDTfDT_1509 Invoke(string ConnectionString,P_L3DT_GDTfDT_1509 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTfDT_1509 Invoke(DbConnection Connection,P_L3DT_GDTfDT_1509 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTfDT_1509 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DT_GDTfDT_1509 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DT_GDTfDT_1509 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DT_GDTfDT_1509 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DT_GDTfDT_1509 functionReturn = new FR_L3DT_GDTfDT_1509();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTask_for_DeveloperTaskID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DT_GDTfDT_1509 : FR_Base
	{
		public L3DT_GDTfDT_1509 Result	{ get; set; }

		public FR_L3DT_GDTfDT_1509() : base() {}

		public FR_L3DT_GDTfDT_1509(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DT_GDTfDT_1509 for attribute P_L3DT_GDTfDT_1509
		[DataContract]
		public class P_L3DT_GDTfDT_1509 
		{
			//Standard type parameters
			[DataMember]
			public Guid TaskID { get; set; } 

		}
		#endregion
		#region SClass L3DT_GDTfDT_1509 for attribute L3DT_GDTfDT_1509
		[DataContract]
		public class L3DT_GDTfDT_1509 
		{
			//Standard type parameters
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid DOC_Structure_Header_RefID { get; set; } 
			[DataMember]
			public Guid CreatedBy_ProjectMember_RefID { get; set; } 
			[DataMember]
			public Guid Priority_RefID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Guid DeveloperTask_Type_RefID { get; set; } 
			[DataMember]
			public Guid GrabbedByMember_RefID { get; set; } 
			[DataMember]
			public DateTime Completion_Deadline { get; set; } 
			[DataMember]
			public DateTime Completion_Timestamp { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public int Developer_Points { get; set; } 
			[DataMember]
			public bool IsComplete { get; set; } 
			[DataMember]
			public bool IsIncompleteInformation { get; set; } 
			[DataMember]
			public bool IsArchived { get; set; } 
			[DataMember]
			public bool IsBeingPrepared { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Double DeveloperTime_CurrentInvestment_min { get; set; } 
			[DataMember]
			public Double DeveloperTime_RequiredEstimation_min { get; set; } 
			[DataMember]
			public Double PercentageComplete { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DT_GDTfDT_1509 cls_Get_DeveloperTask_for_DeveloperTaskID(,P_L3DT_GDTfDT_1509 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DT_GDTfDT_1509 invocationResult = cls_Get_DeveloperTask_for_DeveloperTaskID.Invoke(connectionString,P_L3DT_GDTfDT_1509 Parameter,securityTicket);
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
var parameter = new CL3_DeveloperTask.Atomic.Retrieval.P_L3DT_GDTfDT_1509();
parameter.TaskID = ...;

*/
