/* 
 * Generated on 12/9/2014 4:40:33 PM
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
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DeveloperTask_with_Features_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DeveloperTask_with_Features_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DT_GDTwFfT_1530_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DT_GDTwFfT_1530_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_DeveloperTask.Atomic.Retrieval.SQL.cls_Get_DeveloperTask_with_Features_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3DT_GDTwFfT_1530> results = new List<L3DT_GDTwFfT_1530>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TMS_PRO_DeveloperTaskID","AssignmentID","TMS_PRO_FeatureID","Project_RefID","GrabbedByMember_RefID","Completion_Deadline","Name","Description","Developer_Points","IsComplete","IsIncompleteInformation","IsBeingPrepared","DeveloperTime_RequiredEstimation_min","DeveloperTime_CurrentInvestment_min","PercentageComplete","Parent_RefID","Name_DictID","IdentificationNumber","TMS_PRO_ProjectMemberID" });
				while(reader.Read())
				{
					L3DT_GDTwFfT_1530 resultItem = new L3DT_GDTwFfT_1530();
					//0:Parameter TMS_PRO_DeveloperTaskID of type Guid
					resultItem.TMS_PRO_DeveloperTaskID = reader.GetGuid(0);
					//1:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(1);
					//2:Parameter TMS_PRO_FeatureID of type Guid
					resultItem.TMS_PRO_FeatureID = reader.GetGuid(2);
					//3:Parameter Project_RefID of type Guid
					resultItem.Project_RefID = reader.GetGuid(3);
					//4:Parameter GrabbedByMember_RefID of type Guid
					resultItem.GrabbedByMember_RefID = reader.GetGuid(4);
					//5:Parameter Completion_Deadline of type DateTime
					resultItem.Completion_Deadline = reader.GetDate(5);
					//6:Parameter Name of type String
					resultItem.Name = reader.GetString(6);
					//7:Parameter Description of type String
					resultItem.Description = reader.GetString(7);
					//8:Parameter Developer_Points of type int
					resultItem.Developer_Points = reader.GetInteger(8);
					//9:Parameter IsComplete of type Boolean
					resultItem.IsComplete = reader.GetBoolean(9);
					//10:Parameter IsIncompleteInformation of type Boolean
					resultItem.IsIncompleteInformation = reader.GetBoolean(10);
					//11:Parameter IsBeingPrepared of type Boolean
					resultItem.IsBeingPrepared = reader.GetBoolean(11);
					//12:Parameter DeveloperTime_RequiredEstimation_min of type double
					resultItem.DeveloperTime_RequiredEstimation_min = reader.GetDouble(12);
					//13:Parameter DeveloperTime_CurrentInvestment_min of type double
					resultItem.DeveloperTime_CurrentInvestment_min = reader.GetDouble(13);
					//14:Parameter PercentageComplete of type Double
					resultItem.PercentageComplete = reader.GetDouble(14);
					//15:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(15);
					//16:Parameter Name_DictID of type Dict
					resultItem.Name_DictID = reader.GetDictionary(16);
					resultItem.Name_DictID.SourceTable = "tms_pro_feature";
					loader.Append(resultItem.Name_DictID);
					//17:Parameter IdentificationNumber of type String
					resultItem.IdentificationNumber = reader.GetString(17);
					//18:Parameter TMS_PRO_ProjectMemberID of type Guid
					resultItem.TMS_PRO_ProjectMemberID = reader.GetGuid(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DeveloperTask_with_Features_for_Tenant",ex);
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
		public static FR_L3DT_GDTwFfT_1530_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTwFfT_1530_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DT_GDTwFfT_1530_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DT_GDTwFfT_1530_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DT_GDTwFfT_1530_Array functionReturn = new FR_L3DT_GDTwFfT_1530_Array();
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

				throw new Exception("Exception occured in method cls_Get_DeveloperTask_with_Features_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DT_GDTwFfT_1530_Array : FR_Base
	{
		public L3DT_GDTwFfT_1530[] Result	{ get; set; } 
		public FR_L3DT_GDTwFfT_1530_Array() : base() {}

		public FR_L3DT_GDTwFfT_1530_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3DT_GDTwFfT_1530 for attribute L3DT_GDTwFfT_1530
		[DataContract]
		public class L3DT_GDTwFfT_1530 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_DeveloperTaskID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_FeatureID { get; set; } 
			[DataMember]
			public Guid Project_RefID { get; set; } 
			[DataMember]
			public Guid GrabbedByMember_RefID { get; set; } 
			[DataMember]
			public DateTime Completion_Deadline { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public int Developer_Points { get; set; } 
			[DataMember]
			public Boolean IsComplete { get; set; } 
			[DataMember]
			public Boolean IsIncompleteInformation { get; set; } 
			[DataMember]
			public Boolean IsBeingPrepared { get; set; } 
			[DataMember]
			public double DeveloperTime_RequiredEstimation_min { get; set; } 
			[DataMember]
			public double DeveloperTime_CurrentInvestment_min { get; set; } 
			[DataMember]
			public Double PercentageComplete { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Dict Name_DictID { get; set; } 
			[DataMember]
			public String IdentificationNumber { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectMemberID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DT_GDTwFfT_1530_Array cls_Get_DeveloperTask_with_Features_for_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DT_GDTwFfT_1530_Array invocationResult = cls_Get_DeveloperTask_with_Features_for_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

