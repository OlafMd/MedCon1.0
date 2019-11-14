/* 
 * Generated on 10/23/2014 12:13:05 PM
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
using CL2_Project.Atomic.Retrieval;
using CL3_Project.Atomic.Retrieval;
namespace CL6_DanuTask_Project.Complex.Retrieval
{
	/// <summary>
    /// 
		
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Project_and_RightsPackage_for_Account.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Project_and_RightsPackage_for_Account
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_GPaRPfA_1351_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_GPaRPfA_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PR_GPaRPfA_1351_Array();
			//Put your code here
            //List<L2PR_GaPfA_1017> ProjectsAndProjectMembers = new List<L2PR_GaPfA_1017>();
            P_L2PR_GaPfA_1017 projectForAccountParameter = new P_L2PR_GaPfA_1017();
            projectForAccountParameter.UserAccountID=Parameter.UserAccount_ID;
            var ProjectsAndProjectMembers = cls_Get_All_Projects_for_Account.Invoke(Connection,Transaction,projectForAccountParameter,securityTicket).Result.ToList();
            var g = securityTicket.TenantID;
            List<L6PR_GPaRPfA_1351> result = new List<L6PR_GPaRPfA_1351>();
            foreach(var item in ProjectsAndProjectMembers){
                L6PR_GPaRPfA_1351 projectAndRightPackageForAccount = new L6PR_GPaRPfA_1351();
                projectAndRightPackageForAccount.ProjectName = item.Name;
                projectAndRightPackageForAccount.TMS_PRO_ProjectID = item.TMS_PRO_ProjectID;
                projectAndRightPackageForAccount.TMS_PRO_ProjectMemberID = item.TMS_PRO_ProjectMemberID;
                P_L3PR_GRPfPM_1029 rightsPackageParametersForProjMemberParameter = new P_L3PR_GRPfPM_1029();
                rightsPackageParametersForProjMemberParameter.ProjectMemberID = item.TMS_PRO_ProjectMemberID;
                var rightsPackageParametersForProjMemberResult = cls_Get_RightPackages_for_ProjectMemberID.Invoke(Connection,Transaction,rightsPackageParametersForProjMemberParameter,securityTicket).Result;
                projectAndRightPackageForAccount.RightPackage = rightsPackageParametersForProjMemberResult;
                result.Add(projectAndRightPackageForAccount);
            }
            returnValue.Result = result.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PR_GPaRPfA_1351_Array Invoke(string ConnectionString,P_L6PR_GPaRPfA_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PR_GPaRPfA_1351_Array Invoke(DbConnection Connection,P_L6PR_GPaRPfA_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PR_GPaRPfA_1351_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_GPaRPfA_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PR_GPaRPfA_1351_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_GPaRPfA_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_GPaRPfA_1351_Array functionReturn = new FR_L6PR_GPaRPfA_1351_Array();
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

				throw new Exception("Exception occured in method cls_Get_Project_and_RightsPackage_for_Account",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_GPaRPfA_1351_Array : FR_Base
	{
		public L6PR_GPaRPfA_1351[] Result	{ get; set; } 
		public FR_L6PR_GPaRPfA_1351_Array() : base() {}

		public FR_L6PR_GPaRPfA_1351_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_GPaRPfA_1351 for attribute P_L6PR_GPaRPfA_1351
		[DataContract]
		public class P_L6PR_GPaRPfA_1351 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserAccount_ID { get; set; } 

		}
		#endregion
		#region SClass L6PR_GPaRPfA_1351 for attribute L6PR_GPaRPfA_1351
		[DataContract]
		public class L6PR_GPaRPfA_1351 
		{
			//Standard type parameters
			[DataMember]
			public Guid TMS_PRO_ProjectMemberID { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectID { get; set; } 
			[DataMember]
			public Dict ProjectName { get; set; } 
			[DataMember]
			public L3PR_GRPfPM_1029[] RightPackage { get; set; } 
			[DataMember]
			public Boolean isProjectMember { get; set; } 
			[DataMember]
			public Boolean isTechManager { get; set; } 
			[DataMember]
			public Boolean isProjectManager { get; set; } 
			[DataMember]
			public Boolean isDeveloper { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_GPaRPfA_1351_Array cls_Get_Project_and_RightsPackage_for_Account(,P_L6PR_GPaRPfA_1351 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_GPaRPfA_1351_Array invocationResult = cls_Get_Project_and_RightsPackage_for_Account.Invoke(connectionString,P_L6PR_GPaRPfA_1351 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Complex.Retrieval.P_L6PR_GPaRPfA_1351();
parameter.UserAccount_ID = ...;

*/
