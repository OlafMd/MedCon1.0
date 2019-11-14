/* 
 * Generated on 12/9/2014 1:35:25 PM
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
using CL3_User.Atomic.Retrieval;
using CL1_TMS_PRO;

namespace CL6_DanuTask_Project.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllUsers_Info_and_ProjectMembers_for_ProjectID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllUsers_Info_and_ProjectMembers_for_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_GAUIaPMfPID_1515_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_GAUIaPMfPID_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6PR_GAUIaPMfPID_1515_Array();
			//Put your code here
            List<L6PR_GAUIaPMfPID_1515> allUsersInfo = new List<L6PR_GAUIaPMfPID_1515>();
            var allUsers = cls_Get_UsersBasicInfo_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            var allProjectMembersForProject = ORM_TMS_PRO_ProjectMember.Query.Search(Connection,Transaction, new ORM_TMS_PRO_ProjectMember.Query(){
                Project_RefID = Parameter.ProjectID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            } );
            foreach(var user in allUsers)
            {
                L6PR_GAUIaPMfPID_1515 userInfo = new L6PR_GAUIaPMfPID_1515();
                userInfo.UserID = user.USR_AccountID;
                userInfo.FirstName = user.FirstName;
                userInfo.LastName = user.LastName;
                userInfo.ProfileImage_File_ServerLocation = user.File_ServerLocation;
                if (allProjectMembersForProject.Exists(usr => usr.USR_Account_RefID == user.USR_AccountID))
                {
                    userInfo.ProjectMemberID = allProjectMembersForProject.Where(usr => usr.USR_Account_RefID == user.USR_AccountID).Single().TMS_PRO_ProjectMemberID;
                    userInfo.IsProjectMember = true;
                }
                allUsersInfo.Add(userInfo);
            }
            returnValue.Result = allUsersInfo.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PR_GAUIaPMfPID_1515_Array Invoke(string ConnectionString,P_L6PR_GAUIaPMfPID_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PR_GAUIaPMfPID_1515_Array Invoke(DbConnection Connection,P_L6PR_GAUIaPMfPID_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PR_GAUIaPMfPID_1515_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_GAUIaPMfPID_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PR_GAUIaPMfPID_1515_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_GAUIaPMfPID_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_GAUIaPMfPID_1515_Array functionReturn = new FR_L6PR_GAUIaPMfPID_1515_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllUsers_Info_and_ProjectMembers_for_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_GAUIaPMfPID_1515_Array : FR_Base
	{
		public L6PR_GAUIaPMfPID_1515[] Result	{ get; set; } 
		public FR_L6PR_GAUIaPMfPID_1515_Array() : base() {}

		public FR_L6PR_GAUIaPMfPID_1515_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_GAUIaPMfPID_1515 for attribute P_L6PR_GAUIaPMfPID_1515
		[DataContract]
		public class P_L6PR_GAUIaPMfPID_1515 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectID { get; set; } 

		}
		#endregion
		#region SClass L6PR_GAUIaPMfPID_1515 for attribute L6PR_GAUIaPMfPID_1515
		[DataContract]
		public class L6PR_GAUIaPMfPID_1515 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserID { get; set; } 
			[DataMember]
			public Guid ProjectMemberID { get; set; } 
			[DataMember]
			public Boolean IsProjectMember { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String ProfileImage_File_ServerLocation { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_GAUIaPMfPID_1515_Array cls_Get_AllUsers_Info_and_ProjectMembers_for_ProjectID(,P_L6PR_GAUIaPMfPID_1515 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_GAUIaPMfPID_1515_Array invocationResult = cls_Get_AllUsers_Info_and_ProjectMembers_for_ProjectID.Invoke(connectionString,P_L6PR_GAUIaPMfPID_1515 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Complex.Retrieval.P_L6PR_GAUIaPMfPID_1515();
parameter.ProjectID = ...;

*/
