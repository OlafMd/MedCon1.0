/* 
 * Generated on 12/10/2014 10:26:24 AM
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
using CL1_TMS_PRO;
using CL3_ProjectMember.Atomic.Retrieval;
using CL3_User.Atomic.Retrieval;

namespace CL6_DanuTask_Project.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProjectMembers_with_SharedInfo_for_ProjectNote.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectMembers_with_SharedInfo_for_ProjectNote
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_GPMwSIfPN_1832_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_GPMwSIfPN_1832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PR_GPMwSIfPN_1832_Array();
			//Put your code here
            List<L6PR_GPMwSIfPN_1832> tempResult = new List<L6PR_GPMwSIfPN_1832>();

            ORM_TMS_PRO_Project_Notes projectNote = new ORM_TMS_PRO_Project_Notes();
            projectNote.Load(Connection, Transaction, Parameter.ProjectNote_ID);

            #region ProjectMembers
            ORM_TMS_PRO_ProjectMember.Query membersQuery = new ORM_TMS_PRO_ProjectMember.Query();
            membersQuery.Project_RefID = projectNote.Project_RefID;
            membersQuery.IsDeleted = false;

            List<ORM_TMS_PRO_ProjectMember> currentProject_Members = ORM_TMS_PRO_ProjectMember.Query.Search(Connection, Transaction, membersQuery);
            P_L3US_GUBIfUA_1057 userAccountInfoParameter = new P_L3US_GUBIfUA_1057();
            if (currentProject_Members.Count > 0)
            {
                foreach(var currentMember in currentProject_Members){
                    L6PR_GPMwSIfPN_1832 tempResultItem = new L6PR_GPMwSIfPN_1832();
                    tempResultItem.ProjectMember_AccountID = currentMember.USR_Account_RefID;
                    tempResultItem.ProjectMember_ID = currentMember.TMS_PRO_ProjectMemberID;
                    userAccountInfoParameter.UserAccountID = currentMember.USR_Account_RefID;
                    var userAccountInfoResult = cls_Get_UserBasicInfo_for_UserAccountID.Invoke(Connection, Transaction, userAccountInfoParameter, securityTicket).Result;
                    tempResultItem.ProjectMember_FirstName = userAccountInfoResult.FirstName;
                    tempResultItem.ProjectMember_LastName = userAccountInfoResult.LastName;
                    tempResultItem.ProjectMember_ProfileImage_ServerLocation = userAccountInfoResult.File_ServerLocation;
                    tempResult.Add(tempResultItem);
                }
            }
            
            #endregion

            #region Is member note collaborator
            ORM_TMS_PRO_Project_Note_Collaborators.Query noteCollaboratorsQuery = new ORM_TMS_PRO_Project_Note_Collaborators.Query();
            noteCollaboratorsQuery.IsDeleted = false;
            noteCollaboratorsQuery.ProjectNote_RefID = Parameter.ProjectNote_ID;
            foreach (var currentMember in tempResult)
            {
                noteCollaboratorsQuery.Account_RefID = currentMember.ProjectMember_AccountID;
                currentMember.ProjectMember_IsNoteCollaborator = ORM_TMS_PRO_Project_Note_Collaborators.Query.Exists(Connection, Transaction, noteCollaboratorsQuery);
            }
            #endregion

            returnValue.Result = tempResult.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PR_GPMwSIfPN_1832_Array Invoke(string ConnectionString,P_L6PR_GPMwSIfPN_1832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PR_GPMwSIfPN_1832_Array Invoke(DbConnection Connection,P_L6PR_GPMwSIfPN_1832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PR_GPMwSIfPN_1832_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_GPMwSIfPN_1832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PR_GPMwSIfPN_1832_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_GPMwSIfPN_1832 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_GPMwSIfPN_1832_Array functionReturn = new FR_L6PR_GPMwSIfPN_1832_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProjectMembers_with_SharedInfo_for_ProjectNote",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_GPMwSIfPN_1832_Array : FR_Base
	{
		public L6PR_GPMwSIfPN_1832[] Result	{ get; set; } 
		public FR_L6PR_GPMwSIfPN_1832_Array() : base() {}

		public FR_L6PR_GPMwSIfPN_1832_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_GPMwSIfPN_1832 for attribute P_L6PR_GPMwSIfPN_1832
		[DataContract]
		public class P_L6PR_GPMwSIfPN_1832 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectNote_ID { get; set; } 

		}
		#endregion
		#region SClass L6PR_GPMwSIfPN_1832 for attribute L6PR_GPMwSIfPN_1832
		[DataContract]
		public class L6PR_GPMwSIfPN_1832 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMember_AccountID { get; set; } 
			[DataMember]
			public Guid ProjectMember_ID { get; set; } 
			[DataMember]
			public String ProjectMember_FirstName { get; set; } 
			[DataMember]
			public String ProjectMember_LastName { get; set; } 
			[DataMember]
			public String ProjectMember_ProfileImage_ServerLocation { get; set; } 
			[DataMember]
			public bool ProjectMember_IsNoteCollaborator { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_GPMwSIfPN_1832_Array cls_Get_ProjectMembers_with_SharedInfo_for_ProjectNote(,P_L6PR_GPMwSIfPN_1832 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_GPMwSIfPN_1832_Array invocationResult = cls_Get_ProjectMembers_with_SharedInfo_for_ProjectNote.Invoke(connectionString,P_L6PR_GPMwSIfPN_1832 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Complex.Retrieval.P_L6PR_GPMwSIfPN_1832();
parameter.ProjectNote_ID = ...;

*/
