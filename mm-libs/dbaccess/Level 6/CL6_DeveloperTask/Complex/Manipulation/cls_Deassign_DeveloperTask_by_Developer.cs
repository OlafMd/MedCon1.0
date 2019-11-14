/* 
 * Generated on 7/28/2014 10:02:40 AM
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
using DLCore_DBCommons.DanuTask;
using DLCore_DBCommons.Utils;
using CL1_TMS_PRO;

namespace CL6_DanuTask_DeveloperTask.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Deassign_DeveloperTask_by_Developer.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Deassign_DeveloperTask_by_Developer
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_DDTbD_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_Guid();
            //Put your code here

            #region Deassigned

            var deassignedParam = new P_L2DT_GDTSfGPM_1121();
            deassignedParam.GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDeveloperTaskHistory.Deassigned);

            var deassignedID = cls_Get_DeveloperTaskStatus_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, deassignedParam, securityTicket).Result;

            #endregion

            #region Delete Assignement

            ORM_TMS_PRO_DeveloperTask_Involvement assignment = new ORM_TMS_PRO_DeveloperTask_Involvement();
            assignment.Load(Connection, Transaction, Parameter.AssigmentID);
            assignment.IsActive = false;
            assignment.IsDeleted = true;

            assignment.Save(Connection, Transaction);

            #endregion

            #region Update Developer Task

            ORM_TMS_PRO_DeveloperTask task = new ORM_TMS_PRO_DeveloperTask();
            task.Load(Connection, Transaction, assignment.DeveloperTask_RefID);

            task.GrabbedByMember_RefID = Guid.Empty;

            task.Save(Connection, Transaction);

            #endregion

            #region Create Developer Task Status History

            ORM_TMS_PRO_DeveloperTask_StatusHistory statusHistory = new ORM_TMS_PRO_DeveloperTask_StatusHistory();

            statusHistory.TMS_PRO_DeveloperTask_StatusHistoryID = Guid.NewGuid();
            statusHistory.DeveloperTask_RefID = assignment.DeveloperTask_RefID;
            statusHistory.DeveloperTask_Status_RefID = deassignedID.TMS_PRO_DeveloperTask_StatusID;
            statusHistory.TriggeredBy_ProjectMember_RefID = assignment.ProjectMember_RefID;
            statusHistory.CreatedFor_ProjectMember_RefID = Guid.Empty;
            statusHistory.Comment = "Task has been deasigned.";
            statusHistory.Creation_Timestamp = DateTime.Now.AddSeconds(6);
            statusHistory.Tenant_RefID = securityTicket.TenantID;

            statusHistory.Save(Connection, Transaction);

            #endregion

            #region projectInfo

            var project = new ORM_TMS_PRO_Project();
            project.Load(Connection, Transaction, task.Project_RefID);

            ORM_TMS_PRO_Project_Status ProjectStatus = new ORM_TMS_PRO_Project_Status();
            ProjectStatus.Load(Connection, Transaction, project.Status_RefID);

            Guid language = Parameter.LanguageID;
            String statusLabel = ProjectStatus.Label.GetContent(language);
            String projectName = project.Name.GetContent(language);


            #endregion
            //TO DO:
            #region MailSandout

            //try
            //{


            //    var dt2pm = new ORM_TMS_PRO_DeveloperTask_Involvement();
            //    dt2pm.Load(Connection, Transaction, Parameter.AssigmentID);

            //    var projectMember = new ORM_TMS_PRO_ProjectMember();
            //    projectMember.Load(Connection, Transaction, dt2pm.ProjectMember_RefID);

            //    P_L3US_GUIfA_1241 userParam = new P_L3US_GUIfA_1241();
            //    userParam.UserAccountID = projectMember.USR_Account_RefID;

            //    L3US_GUIfA_1241 devInfo = cls_Get_UserInformation_for_AccountID.Invoke(Connection, Transaction, userParam, securityTicket).Result;

            //    String frontHost = WebConfigurationManager.AppSettings["FrontHost"].ToString();
            //    String unsubscribeLink = String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_Unsubscribe_Link"), frontHost, "dtask", task.TMS_PRO_DeveloperTaskID.ToString());
            //    String seeDetailsLink = String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_br_and_link"), frontHost, "DTask", task.TMS_PRO_DeveloperTaskID);
            //    String subject = String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DeasignDeveloperTask_subject"), projectName, statusLabel, task.IdentificationNumber, task.Name);
            //    P_L3DT_GPfDT_1659 prm = new P_L3DT_GPfDT_1659();
            //    prm.DTaskID = task.TMS_PRO_DeveloperTaskID;


            //    List<L3DT_GPfDT_1659> ress = cls_Get_Peers_for_DTaskID.Invoke(Connection, Transaction, prm, securityTicket).Result.ToList();

            //    P_L3US_GUIfA_1241 usParameter = new P_L3US_GUIfA_1241();
            //    usParameter.UserAccountID = securityTicket.AccountID;
            //    L3US_GUIfA_1241 emailInfo = cls_Get_UserInformation_for_AccountID.Invoke(Connection, Transaction, usParameter, securityTicket).Result;

            //    MailMessage mail = DanuTaskMailGenerator.formatMailMessage(true, false, EnumMailTypes.DTask);

            //    foreach (var x in ress.Select(s => s.PrimaryEmail).Distinct())
            //    {
            //        if (!mail.To.Contains(new MailAddress(x)))
            //            mail.To.Add(x);
            //    }

            //    mail.Subject = subject;
            //    mail.Body = mail.Body.Replace("{ProjectName}", projectName);
            //    mail.Body = mail.Body.Replace("{Role}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Developer")));
            //    mail.Body = mail.Body.Replace("{status}", statusLabel);
            //    mail.Body = mail.Body.Replace("{DTaskNumber}", "D" + task.IdentificationNumber);
            //    mail.Body = mail.Body.Replace("{DTaskName}", task.Name);
            //    mail.Body = mail.Body.Replace("{action}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DTask_Deassigned")));
            //    mail.Body = mail.Body.Replace("{FirstName}", devInfo.FirstName);
            //    mail.Body = mail.Body.Replace("{LastName}", devInfo.LastName);
            //    mail.Body = mail.Body.Replace("{userName}", devInfo.Username);
            //    mail.Body = mail.Body.Replace("{bodyText}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DTask_DeassignedDTask")) + " " + task.Name + String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_inProject")) + " " + projectName + " " + String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_Dtask_Deassigned_to")));
            //    mail.Body = mail.Body.Replace("{UserFullName}", devInfo.FirstName + " " + devInfo.LastName);
            //    DateTime dateToDisplay = DateTime.Now;
            //    mail.Body = mail.Body.Replace("{date}", dateToDisplay.ToShortDateString());
            //    mail.Body = mail.Body.Replace("{time}", dateToDisplay.ToShortTimeString());
            //    mail.Body = mail.Body.Replace("{itemType}", String.Format((String)HttpContext.GetGlobalResourceObject("Global", "Mail_DeveloperTask")));
            //    mail.Body = mail.Body.Replace("{ItemName}", task.Name);
            //    mail.Body = mail.Body.Replace("{commentText}", "Task has been deasigned.");
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
		public static FR_Guid Invoke(string ConnectionString,P_L6DT_DDTbD_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DT_DDTbD_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_DDTbD_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_DDTbD_0958 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Deassign_DeveloperTask_by_Developer",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DT_DDTbD_0958 for attribute P_L6DT_DDTbD_0958
		[DataContract]
		public class P_L6DT_DDTbD_0958 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssigmentID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Deassign_DeveloperTask_by_Developer(,P_L6DT_DDTbD_0958 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Deassign_DeveloperTask_by_Developer.Invoke(connectionString,P_L6DT_DDTbD_0958 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Complex.Manipulation.P_L6DT_DDTbD_0958();
parameter.AssigmentID = ...;
parameter.LanguageID = ...;

*/
