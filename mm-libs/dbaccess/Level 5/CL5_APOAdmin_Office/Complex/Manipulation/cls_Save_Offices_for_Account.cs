/* 
 * Generated on 1/17/2014 12:04:48 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_USR;
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;

namespace CL5_APOAdmin_Office.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Offices_for_Account.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Offices_for_Account
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_SOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            var userAccount = new ORM_USR_Account();
            userAccount.Load(Connection, Transaction, Parameter.AccountID);

            //Get business participant for current user account
            var businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            businessParticipantQuery.CMN_BPT_BusinessParticipantID = userAccount.BusinessParticipant_RefID;
            businessParticipantQuery.Tenant_RefID = securityTicket.TenantID;
            var foundBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).Single();

            //Get employee using business participant 
            var employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            employeeQuery.BusinessParticipant_RefID = foundBusinessParticipant.CMN_BPT_BusinessParticipantID;
            employeeQuery.Tenant_RefID = securityTicket.TenantID;
            var foundEmployee = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, employeeQuery).Single();

            //clear all assignment tables (connection with offices) for found employee before new save
            var assignmentQuery = new ORM_CMN_BPT_EMP_Employee_2_Office.Query();
            if (foundEmployee != null)
            {
                assignmentQuery.CMN_BPT_EMP_Employee_RefID = foundEmployee.CMN_BPT_EMP_EmployeeID;
                assignmentQuery.Tenant_RefID = securityTicket.TenantID;
            }
            else
            {
                return new FR_Guid("Employee not created", FR_Status.Error_Internal);
            }

            var foundAssignments = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, assignmentQuery);

            foreach (var assignment in foundAssignments)
            {
                assignment.IsDeleted = true;
                assignment.Save(Connection, Transaction);
            }

            //save offices
            foreach (var office in Parameter.Offices)
            {
                P_L5OF_SSOfA_1652 officeSaveParam = new P_L5OF_SSOfA_1652();
                officeSaveParam.OfficeID = office;                
                officeSaveParam.EmployeeID = foundEmployee.CMN_BPT_EMP_EmployeeID;
                cls_Save_SingleOffice_for_Account.Invoke(Connection, Transaction, officeSaveParam, securityTicket);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OF_SOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OF_SOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_SOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_SOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Offices_for_Account",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OF_SOfA_1652 for attribute P_L5OF_SOfA_1652
		[DataContract]
		public class P_L5OF_SOfA_1652 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] Offices { get; set; } 
			[DataMember]
			public Guid AccountID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Offices_for_Account(,P_L5OF_SOfA_1652 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Offices_for_Account.Invoke(connectionString,P_L5OF_SOfA_1652 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Office.Complex.Manipulation.P_L5OF_SOfA_1652();
parameter.Offices = ...;
parameter.AccountID = ...;

*/
