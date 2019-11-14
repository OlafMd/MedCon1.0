/* 
 * Generated on 10/10/2014 5:14:26 PM
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
using CL1_OCL;

namespace CL3_OrderCollective.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_OrderCollective.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_OrderCollective
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L3OC_DOC_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
			#region UserCode 
			var returnValue = new FR_Bool();
            returnValue.Status = FR_Status.Error_Internal;
            var result = false;

            var orderCollective = ORM_OCL_OrderCollective.Query.Search(
                Connection,
                Transaction,
                new ORM_OCL_OrderCollective.Query()
                {
                    OCL_OrderCollectiveID = Parameter.OCL_OrderCollectiveID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).FirstOrDefault();

            if (orderCollective != null)
            {
                var orderCollectiveMembers = ORM_OCL_OrderCollective_Member.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_OCL_OrderCollective_Member.Query()
                    {
                        OrderCollective_RefID = orderCollective.OCL_OrderCollectiveID,
                        IsDeleted = false
                    });
                if (orderCollectiveMembers != null && orderCollectiveMembers.Count > 0)
                {
                    foreach (var member in orderCollectiveMembers)
                    {
                        member.IsDeleted = true;
                        member.Save(Connection, Transaction);
                    }
                }
                orderCollective.IsDeleted = true;
                if (orderCollective.Save(Connection, Transaction).RowsUpdated > 0)
                {
                    result = true;
                }
            }
            returnValue.Status = FR_Status.Success;
            returnValue.Result = result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L3OC_DOC_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L3OC_DOC_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L3OC_DOC_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3OC_DOC_1705 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Delete_OrderCollective",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3OC_DOC_1705 for attribute P_L3OC_DOC_1705
		[DataContract]
		public class P_L3OC_DOC_1705 
		{
			//Standard type parameters
			[DataMember]
			public Guid OCL_OrderCollectiveID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Delete_OrderCollective(,P_L3OC_DOC_1705 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Delete_OrderCollective.Invoke(connectionString,P_L3OC_DOC_1705 Parameter,securityTicket);
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
var parameter = new CL3_OrderCollective.Complex.Manipulation.P_L3OC_DOC_1705();
parameter.OCL_OrderCollectiveID = ...;

*/
