/* 
 * Generated on 12/11/2013 12:44:04 PM
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

namespace CL5_APOAdmin_User.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AccountRights_for_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AccountRights_for_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GARfA_1523 Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_GARfA_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5US_GARfA_1523();

            var rightQuery = new ORM_USR_Account_2_FunctionLevelRight.Query();
            rightQuery.Account_RefID = Parameter.UserAccountID;
            rightQuery.IsDeleted = false;

            var rights = ORM_USR_Account_2_FunctionLevelRight.Query.Search(Connection, Transaction, rightQuery);

            returnValue.Result = new L5US_GARfA_1523();
            returnValue.Result.AllowedRights = rights.Select(i=>i.FunctionLevelRight_RefID).ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5US_GARfA_1523 Invoke(string ConnectionString,P_L5US_GARfA_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GARfA_1523 Invoke(DbConnection Connection,P_L5US_GARfA_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GARfA_1523 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_GARfA_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GARfA_1523 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_GARfA_1523 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GARfA_1523 functionReturn = new FR_L5US_GARfA_1523();
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

				throw new Exception("Exception occured in method cls_Get_AccountRights_for_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GARfA_1523 : FR_Base
	{
		public L5US_GARfA_1523 Result	{ get; set; }

		public FR_L5US_GARfA_1523() : base() {}

		public FR_L5US_GARfA_1523(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5US_GARfA_1523 for attribute P_L5US_GARfA_1523
		[DataContract]
		public class P_L5US_GARfA_1523 
		{
			//Standard type parameters
			[DataMember]
			public Guid UserAccountID { get; set; } 

		}
		#endregion
		#region SClass L5US_GARfA_1523 for attribute L5US_GARfA_1523
		[DataContract]
		public class L5US_GARfA_1523 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] AllowedRights { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GARfA_1523 cls_Get_AccountRights_for_AccountID(,P_L5US_GARfA_1523 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GARfA_1523 invocationResult = cls_Get_AccountRights_for_AccountID.Invoke(connectionString,P_L5US_GARfA_1523 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Complex.Retrieval.P_L5US_GARfA_1523();
parameter.UserAccountID = ...;

*/
