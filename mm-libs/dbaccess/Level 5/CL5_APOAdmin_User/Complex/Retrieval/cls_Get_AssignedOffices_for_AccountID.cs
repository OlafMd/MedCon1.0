/* 
 * Generated on 1/22/2014 5:54:42 PM
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
using CL2_Office.Atomic.Retrieval;
using CL1_USR;
using CL1_CMN_BPT_EMP;

namespace CL5_APOAdmin_User.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AssignedOffices_for_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AssignedOffices_for_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GAOfA_1742 Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_GAOfA_1742 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5US_GAOfA_1742();
			//Put your code here

            var allOfficesForTenant = cls_Get_AllOffices_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            ORM_USR_Account user = new ORM_USR_Account();
            user.Load(Connection, Transaction, Parameter.UserAccountID);

            ORM_CMN_BPT_EMP_Employee.Query employeeQuery = new ORM_CMN_BPT_EMP_Employee.Query();
            employeeQuery.BusinessParticipant_RefID = user.BusinessParticipant_RefID;
            employeeQuery.Tenant_RefID = securityTicket.TenantID;
            var foundEmployee = ORM_CMN_BPT_EMP_Employee.Query.Search(Connection, Transaction, employeeQuery).FirstOrDefault();
            
            if (foundEmployee == null)
            {
                foundEmployee = new ORM_CMN_BPT_EMP_Employee();
                foundEmployee.BusinessParticipant_RefID = user.BusinessParticipant_RefID;
                foundEmployee.Tenant_RefID = securityTicket.TenantID;
                foundEmployee.Save(Connection, Transaction);
            }            

            List<L5US_GAOfA_1742a> listOfOfficesWithAssignments = new List<L5US_GAOfA_1742a>();

            foreach (var office in allOfficesForTenant)
            {

                var assignmentQuery = new ORM_CMN_BPT_EMP_Employee_2_Office.Query();
                assignmentQuery.CMN_BPT_EMP_Employee_RefID = foundEmployee.CMN_BPT_EMP_EmployeeID;
                assignmentQuery.CMN_STR_Office_RefID = office.CMN_STR_OfficeID;
                assignmentQuery.Tenant_RefID = securityTicket.TenantID;
                assignmentQuery.IsDeleted = false;
                var foundAssignment = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, assignmentQuery);
                
                L5US_GAOfA_1742a temp = new L5US_GAOfA_1742a();
                if (foundAssignment.Count > 0)
                {
                    temp.AssignmentID = foundAssignment.First().AssignmentID;
                }
                temp.CMN_BPT_EMP_Employee_RefID = foundEmployee.CMN_BPT_EMP_EmployeeID;
                temp.CMN_STR_OfficeID = office.CMN_STR_OfficeID;                
                temp.Office_InternalName = office.Office_InternalName;
                temp.IsOfficeToAccountDeleted = foundAssignment.Count == 0;               
                temp.Office_Description = office.Office_Description;
                temp.Office_Name = office.Office_Name;
                temp.Parent_RefID = office.Parent_RefID;       

                temp.USR_AccountID = Parameter.UserAccountID;

                listOfOfficesWithAssignments.Add(temp);
            }

            returnValue.Result = new L5US_GAOfA_1742();
            returnValue.Result.OfficesWithAssignedUser = new List<L5US_GAOfA_1742a>().ToArray();
            returnValue.Result.OfficesWithAssignedUser = listOfOfficesWithAssignments.ToArray();           
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5US_GAOfA_1742 Invoke(string ConnectionString,P_L5US_GAOfA_1742 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GAOfA_1742 Invoke(DbConnection Connection,P_L5US_GAOfA_1742 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GAOfA_1742 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_GAOfA_1742 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GAOfA_1742 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_GAOfA_1742 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GAOfA_1742 functionReturn = new FR_L5US_GAOfA_1742();
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

				throw new Exception("Exception occured in method cls_Get_AssignedOffices_for_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GAOfA_1742 : FR_Base
	{
		public L5US_GAOfA_1742 Result	{ get; set; }

		public FR_L5US_GAOfA_1742() : base() {}

		public FR_L5US_GAOfA_1742(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5US_GAOfA_1742 for attribute P_L5US_GAOfA_1742
		[DataContract]
		public class P_L5US_GAOfA_1742 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserAccountID { get; set; } 

		}
		#endregion
		#region SClass L5US_GAOfA_1742 for attribute L5US_GAOfA_1742
		[DataContract]
		public class L5US_GAOfA_1742 
		{
			[DataMember]
			public L5US_GAOfA_1742a[] OfficesWithAssignedUser { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L5US_GAOfA_1742a for attribute OfficesWithAssignedUser
		[DataContract]
		public class L5US_GAOfA_1742a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public Dict Office_Description { get; set; } 
			[DataMember]
			public String Office_InternalName { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_Employee_RefID { get; set; } 
			[DataMember]
			public bool IsOfficeToAccountDeleted { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GAOfA_1742 cls_Get_AssignedOffices_for_AccountID(,P_L5US_GAOfA_1742 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GAOfA_1742 invocationResult = cls_Get_AssignedOffices_for_AccountID.Invoke(connectionString,P_L5US_GAOfA_1742 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Complex.Retrieval.P_L5US_GAOfA_1742();
parameter.UserAccountID = ...;

*/
