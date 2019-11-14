/* 
 * Generated on 10/30/2014 2:31:34 PM
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
using CL1_USR;
using DLCore_DBCommons.DanuTask;
using CL3_QuickTask.Atomic.Manipulation;
using System.Xml.Linq;
using DLCore_DBCommons.Utils;
using CL1_TMS_PRO;
using CL1_TMS;

namespace CL6_DanuTask_User.Complex.Manipulation
{
	/// <summary>
    /// Save user account running times
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_UserRunningTimesReportedWorkTime.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_UserRunningTimesReportedWorkTime
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6US_SURTRWT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            ORM_USR_Account_ApplicationSetting.Query ApplicationSettingsQuery = new ORM_USR_Account_ApplicationSetting.Query();
            ApplicationSettingsQuery.Account_RefID = securityTicket.AccountID;
            ApplicationSettingsQuery.Tenant_RefID = securityTicket.TenantID;
            ApplicationSettingsQuery.ItemValue = EnumUtils.GetEnumDescription(RunningTimes.Item_Key);
            if (ORM_USR_Account_ApplicationSetting.Query.Exists(Connection, Transaction, ApplicationSettingsQuery))
            {
                Guid DefinitionID = ORM_USR_Account_ApplicationSetting.Query.Search(Connection, Transaction, ApplicationSettingsQuery).FirstOrDefault().ApplicationSetting_Definition_RefID;
                ORM_USR_Account_ApplicationSetting_Definition ApplicationDefinition = new ORM_USR_Account_ApplicationSetting_Definition();
                ApplicationDefinition.Load(Connection, Transaction, DefinitionID);
                String runningTimesXml = ApplicationDefinition.DefaultValue;
                XDocument runningTimesDoc = XDocument.Parse(runningTimesXml);
                XElement currentRunningTime = runningTimesDoc.Root.Elements("RunningTime").Where(rt => Boolean.Parse(rt.Element("IsToFinish").Value)).FirstOrDefault();
                P_L3QT_SQT_0905 SaveQuickTaskParameter = new P_L3QT_SQT_0905();
                SaveQuickTaskParameter.AssignedTo_Project_RefID = Parameter.AssignedToProject_ID;
                if (Parameter.AssignedToBusinessTask_ID != null && Parameter.AssignedToBusinessTask_ID != Guid.Empty)
                    SaveQuickTaskParameter.AssignedTo_BusinessTask_RefID = Parameter.AssignedToBusinessTask_ID;
                if (Parameter.AssignedToFeature_ID != null && Parameter.AssignedToFeature_ID != Guid.Empty)
                    SaveQuickTaskParameter.AssignedTo_Feature_RefID = Parameter.AssignedToFeature_ID;
                if (Parameter.AssignedToDeveloperTask_ID != null && Parameter.AssignedToDeveloperTask_ID != Guid.Empty)
                    SaveQuickTaskParameter.AssignedTo_DeveloperTask_RefID = Parameter.AssignedToDeveloperTask_ID;
                SaveQuickTaskParameter.IsDeleted = false;
                SaveQuickTaskParameter.LanguageID = Parameter.LanguageID;
                SaveQuickTaskParameter.QuickTask_Type_RefID = Parameter.WorkTimeType_ID;
                XElement LastInterval = currentRunningTime.Element("Intervals").Elements("Interval").Last();
                foreach (XElement runnigTimeInterval in currentRunningTime.Element("Intervals").Elements("Interval"))
                {
                    SaveQuickTaskParameter.QuickTask_Title = new Dict(ORM_TMS_QuickTask.TableName);
                    SaveQuickTaskParameter.QuickTask_Title.AddEntry(Parameter.LanguageID, currentRunningTime.Element("Title").Value);

                    SaveQuickTaskParameter.QuickTask_Description = new Dict(ORM_TMS_QuickTask.TableName);
                    SaveQuickTaskParameter.QuickTask_Description.AddEntry(Parameter.LanguageID, Parameter.WorkTimeDescription);

                    SaveQuickTaskParameter.QuickTask_StartTime = DateTime.Parse(runnigTimeInterval.Element("Start").Value);

                    if (runnigTimeInterval == LastInterval)
                        SaveQuickTaskParameter.R_QuickTask_InvestedTime_min = Parameter.WorkTimeLastIntervalDurationMinutes;
                    else
                        SaveQuickTaskParameter.R_QuickTask_InvestedTime_min = Double.Parse(runnigTimeInterval.Element("Duration").Value) / 60;
                    cls_Save_TMS_QuickTask.Invoke(Connection, Transaction, SaveQuickTaskParameter, securityTicket);
                }

                runningTimesDoc.Root.Elements("RunningTime").Where(rt => Boolean.Parse(rt.Element("IsToFinish").Value)).Remove();
                P_L6US_SURT_0947 UpdateRuningTimesParameter = new P_L6US_SURT_0947();
                UpdateRuningTimesParameter.RunningTimesXML = runningTimesDoc.ToString();
                cls_Save_UserRunningTimes.Invoke(Connection, Transaction, UpdateRuningTimesParameter, securityTicket);
            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6US_SURTRWT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6US_SURTRWT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6US_SURTRWT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6US_SURTRWT_0947 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_UserRunningTimesReportedWorkTime",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6US_SURTRWT_0947 for attribute P_L6US_SURTRWT_0947
		[DataContract]
		public class P_L6US_SURTRWT_0947 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignedToProject_ID { get; set; } 
			[DataMember]
			public Guid AssignedToBusinessTask_ID { get; set; } 
			[DataMember]
			public Guid AssignedToFeature_ID { get; set; } 
			[DataMember]
			public Guid AssignedToDeveloperTask_ID { get; set; } 
			[DataMember]
			public Guid WorkTimeType_ID { get; set; } 
			[DataMember]
			public String WorkTimeDescription { get; set; } 
			[DataMember]
			public Double WorkTimeLastIntervalDurationMinutes { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_UserRunningTimesReportedWorkTime(,P_L6US_SURTRWT_0947 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_UserRunningTimesReportedWorkTime.Invoke(connectionString,P_L6US_SURTRWT_0947 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_User.Complex.Manipulation.P_L6US_SURTRWT_0947();
parameter.AssignedToProject_ID = ...;
parameter.AssignedToBusinessTask_ID = ...;
parameter.AssignedToFeature_ID = ...;
parameter.AssignedToDeveloperTask_ID = ...;
parameter.WorkTimeType_ID = ...;
parameter.WorkTimeDescription = ...;
parameter.WorkTimeLastIntervalDurationMinutes = ...;
parameter.LanguageID = ...;

*/
