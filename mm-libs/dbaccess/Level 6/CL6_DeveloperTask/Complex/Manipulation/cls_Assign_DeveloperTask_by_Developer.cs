/* 
 * Generated on 7/25/2014 1:15:58 PM
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
using CL2_DeveloperTask.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.DanuTask;
using CL1_TMS_PRO;
using CL3_DeveloperTask.Atomic.Retrieval;

namespace CL6_DanuTask_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// Assign developer task by developer
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Assign_DeveloperTask_by_Developer.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Assign_DeveloperTask_by_Developer
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_ADTbD_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_Guid();

            #region Assigned

            var assignedParam = new P_L2DT_GDTSfGPM_1121();
            assignedParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Assigned);

            var assignedID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, assignedParam, securityTicket).Result;

            #endregion

            #region GetProjectMemeberID and AssignmentID
            P_L3DT_GPMaAfDTaA_1326 param1 = new P_L3DT_GPMaAfDTaA_1326();
            param1.DTaskID = Parameter.DeveloperTask_RefID;

           L3DT_GPMaAfDTaA_1326 result1 = cls_Get_ProjectMemberID_and_AssignmentID_for_DTaskID_and_AccountID.Invoke(Connection, Transaction, param1, securityTicket).Result;
            #endregion

            #region ORM_DeveloperTask_2_ProjectMember

            #region cls_Get_AssignedTaskCount_for_Account

            L3DT_GATCfA_1333 result2 = cls_Get_AssignedTaskCount_for_Account.Invoke(Connection, Transaction, securityTicket).Result;

            if (result2 == null)
            {
                result2 = new L3DT_GATCfA_1333();
                result2.TaskCount = 0;
            }

            #endregion

            var assignItem = new ORM_TMS_PRO_DeveloperTask_Involvement();
            if (result1.TMS_PRO_DeveloperTask_InvolvementID != Guid.Empty)
            {
                assignItem.Load(Connection, Transaction, result1.TMS_PRO_DeveloperTask_InvolvementID);
            }
            else
            {
                assignItem.TMS_PRO_DeveloperTask_InvolvementID = Guid.NewGuid();
                assignItem.Tenant_RefID = securityTicket.TenantID;
            }
            assignItem.ProjectMember_RefID = result1.TMS_PRO_ProjectMemberID;
            assignItem.DeveloperTask_RefID = Parameter.DeveloperTask_RefID;
            assignItem.OrderSequence = result2.TaskCount + 1;
            assignItem.IsActive = false;
            assignItem.IsArchived = false;
            assignItem.IsDeleted = false;
            assignItem.Developer_CompletionTimeEstimation_min = Parameter.Developer_TimeEstimation_min;

            assignItem.Save(Connection, Transaction);

            #endregion

            #region ORM_TMS_PRO_DeveloperTask

            var developerTask = new ORM_TMS_PRO_DeveloperTask();
            if (Parameter.DeveloperTask_RefID != Guid.Empty)
            {
                developerTask.Load(Connection, Transaction, Parameter.DeveloperTask_RefID);
            }

            developerTask.GrabbedByMember_RefID = result1.TMS_PRO_ProjectMemberID;

            developerTask.Save(Connection, Transaction);

            #endregion

            #region ORM_DeveloperTask_StatusHistory

            ORM_TMS_PRO_DeveloperTask_StatusHistory statusHistory = new ORM_TMS_PRO_DeveloperTask_StatusHistory();

            statusHistory.DeveloperTask_RefID = Parameter.DeveloperTask_RefID;
            statusHistory.DeveloperTask_Status_RefID = assignedID.TMS_PRO_DeveloperTask_StatusID;
            statusHistory.TriggeredBy_ProjectMember_RefID = result1.TMS_PRO_ProjectMemberID;
            statusHistory.CreatedFor_ProjectMember_RefID = Guid.Empty;
            statusHistory.Comment = "Estimated time: " + Parameter.Developer_TimeEstimation_min + "[min]";
            statusHistory.Tenant_RefID = securityTicket.TenantID;

            statusHistory.Save(Connection, Transaction);

            #endregion ORM_DeveloperTask_StatusHistory

            #region projectInfo

            var project = new ORM_TMS_PRO_Project();
            project.Load(Connection, Transaction, developerTask.Project_RefID);

            ORM_TMS_PRO_Project_Status ProjectStatus = new ORM_TMS_PRO_Project_Status();
            ProjectStatus.Load(Connection, Transaction, project.Status_RefID);

            Guid language = Parameter.LanguageID;
            String statusLabel = ProjectStatus.Label.GetContent(language);
            String projectName = project.Name.GetContent(language);

            #endregion

            returnValue.Result = assignItem.TMS_PRO_DeveloperTask_InvolvementID;

            #region MailSandout

            //try
            //{


            //    L3US_GAAPI_1057 userInfo = cls_Get_ActiveAccount_PersonalInformation.Invoke(Connection, Transaction, securityTicket).Result;
            //    String frontHost = WebConfigurationManager.AppSettings["FrontHost"].ToString();
            //    String seeDetailsLink = String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_br_and_link"), frontHost, "DTask", developerTask.TMS_PRO_DeveloperTaskID);
            //    String unsubscribeLink = String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_Unsubscribe_Link"), frontHost, "dtask", developerTask.TMS_PRO_DeveloperTaskID.ToString());
            //    String subject = String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_AssignDeveloperTaskByDeveloper_subject"), projectName, statusLabel, developerTask.IdentificationNumber, developerTask.Name);

            //    P_L3DT_GPfDT_1659 prm = new P_L3DT_GPfDT_1659();
            //    prm.DTaskID = developerTask.TMS_PRO_DeveloperTaskID;

            //    List<L3DT_GPfDT_1659> ress = cls_Get_Peers_for_DTaskID.Invoke(Connection, Transaction, prm, securityTicket).Result.ToList();

            //    P_L3US_GUIfA_1241 usParameter = new P_L3US_GUIfA_1241();
            //    usParameter.UserAccountID = securityTicket.AccountID;
            //    L3US_GUIfA_1241 emailInfo = cls_Get_UserInformation_for_AccountID.Invoke(Connection, Transaction, usParameter, securityTicket).Result;

            //    MailMessage mail = DanuTaskMailGenerator.formatMailMessage(false, false, EnumMailTypes.DTask);

            //    foreach (var x in ress.Select(s => s.PrimaryEmail).Distinct())
            //    {
            //        if (!mail.To.Contains(new MailAddress(x)))
            //            mail.To.Add(x);
            //    }

            //    mail.Subject = subject;
            //    mail.Body = mail.Body.Replace("{ProjectName}", projectName);
            //    mail.Body = mail.Body.Replace("{Role}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Developer")));
            //    mail.Body = mail.Body.Replace("{status}", statusLabel);
            //    mail.Body = mail.Body.Replace("{DTaskNumber}", "D" + developerTask.IdentificationNumber);
            //    mail.Body = mail.Body.Replace("{DTaskName}", developerTask.Name);
            //    mail.Body = mail.Body.Replace("{action}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DTask_AssignedbyDeveloper")));
            //    mail.Body = mail.Body.Replace("{FirstName}", userInfo.FirstName);
            //    mail.Body = mail.Body.Replace("{LastName}", userInfo.LastName);
            //    mail.Body = mail.Body.Replace("{userName}", userInfo.Username);
            //    mail.Body = mail.Body.Replace("{UserFullName}", userInfo.FirstName + " " + userInfo.LastName);
            //    mail.Body = mail.Body.Replace("{bodyText}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DTask_AssignedDTask")) + " " + developerTask.Name + String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_inProject")) + " " + projectName + String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DTaskAssignedToHimself")));
            //    DateTime dateToDisplay = DateTime.Now;
            //    mail.Body = mail.Body.Replace("{date}", dateToDisplay.ToShortDateString());
            //    mail.Body = mail.Body.Replace("{time}", dateToDisplay.ToShortTimeString());
            //    mail.Body = mail.Body.Replace("{itemType}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DeveloperTask")));
            //    mail.Body = mail.Body.Replace("{ItemName}", developerTask.Name);
            //    mail.Body = mail.Body.Replace("$$$seeDetailsLink$$$", seeDetailsLink);
            //    mail.Body = mail.Body.Replace("$$$unsubscribeLink$$$", unsubscribeLink);
            //    if (mail.To.Count > 0)
            //    {
            //        SmtpClient smtpClient = new SmtpClient();
            //        smtpClient.Send(mail);
            //    }
            //}
            //catch
            //{

            //}

            #endregion

            return returnValue;

			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_ADTbD_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_ADTbD_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_ADTbD_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_ADTbD_1314 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Assign_DeveloperTask_by_Developer",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_ADTbD_1314 for attribute P_L6DT_ADTbD_1314
		[DataContract]
		public class P_L6DT_ADTbD_1314 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_RefID { get; set; } 
			[DataMember]
			public long Developer_TimeEstimation_min { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Assign_DeveloperTask_by_Developer(,P_L6DT_ADTbD_1314 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Assign_DeveloperTask_by_Developer.Invoke(connectionString,P_L6DT_ADTbD_1314 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Complex.Manipulation.P_L6DT_ADTbD_1314();
parameter.DeveloperTask_RefID = ...;
parameter.Developer_TimeEstimation_min = ...;
parameter.LanguageID = ...;

*/
