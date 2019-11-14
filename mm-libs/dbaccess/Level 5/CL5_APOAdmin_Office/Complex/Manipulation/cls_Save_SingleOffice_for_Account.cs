/* 
 * Generated on 1/17/2014 12:31:40 PM
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
using CL1_CMN_STR;
using CL1_CMN_BPT_EMP;

namespace CL5_APOAdmin_Office.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_SingleOffice_for_Account.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_SingleOffice_for_Account
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OF_SSOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            var officeQuery = new ORM_CMN_STR_Office.Query();
            officeQuery.CMN_STR_OfficeID = Parameter.OfficeID;
            officeQuery.Tenant_RefID = securityTicket.TenantID;
            var foundOffice = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, officeQuery).Single();
            
            if (foundOffice != null)
            {
                var assignmentQuery = new ORM_CMN_BPT_EMP_Employee_2_Office.Query();
                assignmentQuery.CMN_BPT_EMP_Employee_RefID = Parameter.EmployeeID;
                assignmentQuery.CMN_STR_Office_RefID = foundOffice.CMN_STR_OfficeID;
                assignmentQuery.Tenant_RefID = securityTicket.TenantID;
                var foundAssignment = ORM_CMN_BPT_EMP_Employee_2_Office.Query.Search(Connection, Transaction, assignmentQuery).SingleOrDefault();

                if (foundAssignment == null)
                {
                    foundAssignment = new ORM_CMN_BPT_EMP_Employee_2_Office();                             
                }

                foundAssignment.CMN_STR_Office_RefID = foundOffice.CMN_STR_OfficeID;
                foundAssignment.CMN_BPT_EMP_Employee_RefID = Parameter.EmployeeID;
                foundAssignment.Tenant_RefID = securityTicket.TenantID;
                foundAssignment.IsDeleted = false;
                foundAssignment.Save(Connection, Transaction);                
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OF_SSOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OF_SSOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OF_SSOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OF_SSOfA_1652 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_SingleOffice_for_Account",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OF_SSOfA_1652 for attribute P_L5OF_SSOfA_1652
		[DataContract]
		public class P_L5OF_SSOfA_1652 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Guid EmployeeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_SingleOffice_for_Account(,P_L5OF_SSOfA_1652 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_SingleOffice_for_Account.Invoke(connectionString,P_L5OF_SSOfA_1652 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Office.Complex.Manipulation.P_L5OF_SSOfA_1652();
parameter.OfficeID = ...;
parameter.EmployeeID = ...;

*/
