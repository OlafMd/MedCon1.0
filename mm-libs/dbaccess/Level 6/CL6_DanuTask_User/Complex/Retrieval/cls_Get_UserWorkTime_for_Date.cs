/* 
 * Generated on 10/31/2014 2:00:11 PM
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
using CL6_DanuTask_QuickTask.Atomic.Retrieval;
using CL6_DanuTask_DeveloperTask.Atomic.Retrieval;

namespace CL6_DanuTask_User.Complex.Retrieval
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_UserWorkTime_for_Date.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_UserWorkTime_for_Date
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6US_GUWTfD_1532_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6US_GUWTfD_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6US_GUWTfD_1532_Array();

            List<L6US_GUWTfD_1532> tempResult = new List<L6US_GUWTfD_1532>();

            #region Reported work times

            P_L6QT_GQTIWTfAUaST_1046 Parameter_ReportedTimes = new P_L6QT_GQTIWTfAUaST_1046();
            Parameter_ReportedTimes.StartDate = Parameter.StartDate;

            var ReportedTimes_Result = cls_Get_QuickTaskInvestedWorkTimes_for_ActiveUser_and_Date.Invoke(Connection, Transaction, Parameter_ReportedTimes, securityTicket);
            if (ReportedTimes_Result.Status == FR_Status.Success && ReportedTimes_Result.Result != null && ReportedTimes_Result.Result.Count() > 0)
            {
                foreach (var currentReportedTime in ReportedTimes_Result.Result)
                {
                    L6US_GUWTfD_1532 tempResultItem = new L6US_GUWTfD_1532();
                    tempResultItem.SourceItem_ID = currentReportedTime.TMS_QuickTaskID;
                    tempResultItem.SourceItem_Name = null;
                    tempResultItem.SourceItem_Name_Dict = currentReportedTime.QuickTask_Title;
                    tempResultItem.SourceItem_Description = null;
                    tempResultItem.SourceItem_Description_Dict = currentReportedTime.QuickTask_Description;
                    tempResultItem.SourceItem_IdentificationNumber = "W" + currentReportedTime.IdentificationNumber;
                    tempResultItem.SourceItem_ParentProjectID = currentReportedTime.TMS_PRO_ProjectID;
                    tempResultItem.SourceItem_ParentProjectName = currentReportedTime.Project_Name;
                    tempResultItem.SourceItem_StartTime = currentReportedTime.QuickTask_StartTime;
                    tempResultItem.SourceItem_TypeRefID = currentReportedTime.QuickTask_Type_RefID;
                    tempResultItem.SourceItem_WorkTimeDuration = currentReportedTime.R_QuickTask_InvestedTime_min;
                    tempResult.Add(tempResultItem);
                }
            }

            #endregion

            #region Developer Task related work times

            P_L6DT_GDTIWTfAUaST_1046 Parameter_DeveloperTaskTimes = new P_L6DT_GDTIWTfAUaST_1046();
            Parameter_DeveloperTaskTimes.StartDate = Parameter.StartDate;

            var DeveloperTaskTimes_Result = cls_Get_DeveloperTaskInvestedWorkTime_for_ActiveAcount_and_Date.Invoke(Connection, Transaction, Parameter_DeveloperTaskTimes, securityTicket);
            if (DeveloperTaskTimes_Result.Status == FR_Status.Success && DeveloperTaskTimes_Result.Result != null && DeveloperTaskTimes_Result.Result.Count() > 0)
            {
                foreach (var currentDeveloperTaskTime in DeveloperTaskTimes_Result.Result)
                {
                    L6US_GUWTfD_1532 tempResultItem = new L6US_GUWTfD_1532();
                    tempResultItem.SourceItem_Description = currentDeveloperTaskTime.DeveloperTask_Description;
                    tempResultItem.SourceItem_Description_Dict = null;
                    tempResultItem.SourceItem_ID = currentDeveloperTaskTime.TMS_PRO_DeveloperTaskID;
                    tempResultItem.SourceItem_IdentificationNumber = "D" + currentDeveloperTaskTime.IdentificationNumber;
                    tempResultItem.SourceItem_Name = currentDeveloperTaskTime.DeveloperTask_Name;
                    tempResultItem.SourceItem_Name_Dict = null;
                    tempResultItem.SourceItem_ParentProjectID = currentDeveloperTaskTime.TMS_PRO_ProjectID;
                    tempResultItem.SourceItem_ParentProjectName = currentDeveloperTaskTime.Project_Name;
                    tempResultItem.SourceItem_StartTime = currentDeveloperTaskTime.WorkTime_Start;
                    tempResultItem.SourceItem_TypeRefID = currentDeveloperTaskTime.DeveloperTask_Type_RefID;
                    tempResultItem.SourceItem_WorkTimeDuration = currentDeveloperTaskTime.WorkTime_Amount_min;
                    tempResult.Add(tempResultItem);
                }
            }

            #endregion

            returnValue.Result = tempResult.OrderBy(item => item.SourceItem_StartTime).ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6US_GUWTfD_1532_Array Invoke(string ConnectionString,P_L6US_GUWTfD_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6US_GUWTfD_1532_Array Invoke(DbConnection Connection,P_L6US_GUWTfD_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6US_GUWTfD_1532_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6US_GUWTfD_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6US_GUWTfD_1532_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6US_GUWTfD_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6US_GUWTfD_1532_Array functionReturn = new FR_L6US_GUWTfD_1532_Array();
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

				throw new Exception("Exception occured in method cls_Get_UserWorkTime_for_Date",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6US_GUWTfD_1532_Array : FR_Base
	{
		public L6US_GUWTfD_1532[] Result	{ get; set; } 
		public FR_L6US_GUWTfD_1532_Array() : base() {}

		public FR_L6US_GUWTfD_1532_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6US_GUWTfD_1532 for attribute P_L6US_GUWTfD_1532
		[DataContract]
		public class P_L6US_GUWTfD_1532 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 

		}
		#endregion
		#region SClass L6US_GUWTfD_1532 for attribute L6US_GUWTfD_1532
		[DataContract]
		public class L6US_GUWTfD_1532 
		{
			//Standard type parameters
			[DataMember]
			public Guid SourceItem_ID { get; set; } 
			[DataMember]
			public String SourceItem_IdentificationNumber { get; set; } 
			[DataMember]
			public String SourceItem_Name { get; set; } 
			[DataMember]
			public Dict SourceItem_Name_Dict { get; set; } 
			[DataMember]
			public String SourceItem_Description { get; set; } 
			[DataMember]
			public Dict SourceItem_Description_Dict { get; set; } 
			[DataMember]
			public DateTime SourceItem_StartTime { get; set; } 
			[DataMember]
			public Double SourceItem_WorkTimeDuration { get; set; } 
			[DataMember]
			public Guid SourceItem_ParentProjectID { get; set; } 
			[DataMember]
			public Dict SourceItem_ParentProjectName { get; set; } 
			[DataMember]
			public Guid SourceItem_TypeRefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6US_GUWTfD_1532_Array cls_Get_UserWorkTime_for_Date(,P_L6US_GUWTfD_1532 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6US_GUWTfD_1532_Array invocationResult = cls_Get_UserWorkTime_for_Date.Invoke(connectionString,P_L6US_GUWTfD_1532 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_User.Complex.Retrieval.P_L6US_GUWTfD_1532();
parameter.StartDate = ...;

*/
