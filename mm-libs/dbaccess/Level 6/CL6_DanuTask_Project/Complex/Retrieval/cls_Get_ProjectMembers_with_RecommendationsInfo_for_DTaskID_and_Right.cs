/* 
<<<<<<< HEAD
 * Generated on 10/13/2014 4:31:45 PM
=======
 * Generated on 10/16/2014 12:36:26
>>>>>>> f048d425a43e3fa789dd28b363b035067b5e851a
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
namespace CL6_DanuTask_Project.Complex.Retrieval
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProjectMembers_with_RecommendationsInfo_for_DTaskID_and_Right.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProjectMembers_with_RecommendationsInfo_for_DTaskID_and_Right
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_GPMwRIfDTaR_1317_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_GPMwRIfDTaR_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PR_GPMwRIfDTaR_1317_Array();
			//Put your code here
            List<L6PR_GPMwRIfDTaR_1317> tempResult = new List<L6PR_GPMwRIfDTaR_1317>();

            ORM_TMS_PRO_DeveloperTask developerTask = new ORM_TMS_PRO_DeveloperTask();
            developerTask.Load(Connection, Transaction, Parameter.DeveloperTask_ID);

            P_L3PM_GPMfPaRP_1459 ParameterMembers = new P_L3PM_GPMfPaRP_1459();
            ParameterMembers.ProjectID = developerTask.Project_RefID;
            ParameterMembers.RightPackageID = Parameter.Right_ID;

            var tempMembers = cls_Get_ProjectMemebers_for_ProjectID_and_RightPackageID.Invoke(Connection, Transaction, ParameterMembers, securityTicket).Result;

            if (tempMembers != null)
            {
                ORM_TMS_PRO_DeveloperTask_Recommendation.Query recommendationsQuery = new ORM_TMS_PRO_DeveloperTask_Recommendation.Query();
                recommendationsQuery.DeveloperTask_RefID = Parameter.DeveloperTask_ID;
                recommendationsQuery.IsDeleted = false;

                foreach (var member in tempMembers)
                {
                    L6PR_GPMwRIfDTaR_1317 tempResultItem = new L6PR_GPMwRIfDTaR_1317();
                    tempResultItem.ProjectMember_FirstName = member.ProjectMember_FirstName;
                    tempResultItem.ProjectMember_ID = member.ProjectMember_ID;
                    tempResultItem.ProjectMember_AccountID = member.ProjectMember_AccountID;
                    tempResultItem.ProjectMember_LastName = member.ProjectMember_LastName;
                    tempResultItem.ProjectMember_ProfilePic_ServerLocation = member.ProjectMember_ProfilePic_ServerLocation;

                    recommendationsQuery.RecommendedTo_ProjectMember_RefID = member.ProjectMember_ID;
                    tempResultItem.ProjectMember_IsRecommended = ORM_TMS_PRO_DeveloperTask_Recommendation.Query.Exists(Connection, Transaction,recommendationsQuery);

                    tempResult.Add(tempResultItem);
                }
            }

            returnValue.Result = tempResult.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PR_GPMwRIfDTaR_1317_Array Invoke(string ConnectionString,P_L6PR_GPMwRIfDTaR_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PR_GPMwRIfDTaR_1317_Array Invoke(DbConnection Connection,P_L6PR_GPMwRIfDTaR_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PR_GPMwRIfDTaR_1317_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_GPMwRIfDTaR_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PR_GPMwRIfDTaR_1317_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_GPMwRIfDTaR_1317 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_GPMwRIfDTaR_1317_Array functionReturn = new FR_L6PR_GPMwRIfDTaR_1317_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProjectMembers_with_RecommendationsInfo_for_DTaskID_and_Right",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_GPMwRIfDTaR_1317_Array : FR_Base
	{
		public L6PR_GPMwRIfDTaR_1317[] Result	{ get; set; } 
		public FR_L6PR_GPMwRIfDTaR_1317_Array() : base() {}

		public FR_L6PR_GPMwRIfDTaR_1317_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_GPMwRIfDTaR_1317 for attribute P_L6PR_GPMwRIfDTaR_1317
		[DataContract]
		public class P_L6PR_GPMwRIfDTaR_1317 
		{
			//Standard type parameters
			[DataMember]
			public Guid DeveloperTask_ID { get; set; } 
			[DataMember]
			public Guid Right_ID { get; set; } 

		}
		#endregion
		#region SClass L6PR_GPMwRIfDTaR_1317 for attribute L6PR_GPMwRIfDTaR_1317
		[DataContract]
		public class L6PR_GPMwRIfDTaR_1317 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMember_ID { get; set; } 
			[DataMember]
			public Guid ProjectMember_AccountID { get; set; } 
			[DataMember]
			public String ProjectMember_FirstName { get; set; } 
			[DataMember]
			public String ProjectMember_LastName { get; set; } 
			[DataMember]
			public String ProjectMember_ProfilePic_ServerLocation { get; set; } 
			[DataMember]
			public bool ProjectMember_IsRecommended { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_GPMwRIfDTaR_1317_Array cls_Get_ProjectMembers_with_RecommendationsInfo_for_DTaskID_and_Right(,P_L6PR_GPMwRIfDTaR_1317 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_GPMwRIfDTaR_1317_Array invocationResult = cls_Get_ProjectMembers_with_RecommendationsInfo_for_DTaskID_and_Right.Invoke(connectionString,P_L6PR_GPMwRIfDTaR_1317 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Complex.Retrieval.P_L6PR_GPMwRIfDTaR_1317();
parameter.DeveloperTask_ID = ...;
parameter.Right_ID = ...;

*/
