/* 
 * Generated on 12/10/2013 4:11:05 PM
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
using CL5_APOAdmin_User.Atomic.Retrieval;
using CL1_USR;

namespace CL5_APOAdmin_User.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_UserGroups_with_Rights_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_UserGroups_with_Rights_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GUGwRfT_1154_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5US_GUGwRfT_1154_Array();
            var groups = cls_Get_UserGroups_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            var result = new List<L5US_GUGwRfT_1154>();

            foreach (var group in groups) {

                var rightQuery = new ORM_USR_Groups_2_FunctionLevelRight.Query();
                rightQuery.USR_Group_RefID = group.USR_GroupID;
                rightQuery.IsDeleted = false;

                var rights = ORM_USR_Groups_2_FunctionLevelRight.Query.Search(Connection, Transaction, rightQuery);

                var item = new L5US_GUGwRfT_1154();
                item.USR_GroupID = group.USR_GroupID;
                item.Group_Name = group.Group_Name.CopyContents(ORM_USR_Group_2_FunctionLevelRightGroup.TableName);
                item.AllowedRights = rights.Select(i => i.USR_Account_FunctionLevelRight_RefID).ToArray();
                result.Add(item);
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
		public static FR_L5US_GUGwRfT_1154_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GUGwRfT_1154_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GUGwRfT_1154_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GUGwRfT_1154_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GUGwRfT_1154_Array functionReturn = new FR_L5US_GUGwRfT_1154_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_UserGroups_with_Rights_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GUGwRfT_1154_Array : FR_Base
	{
		public L5US_GUGwRfT_1154[] Result	{ get; set; } 
		public FR_L5US_GUGwRfT_1154_Array() : base() {}

		public FR_L5US_GUGwRfT_1154_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5US_GUGwRfT_1154 for attribute L5US_GUGwRfT_1154
		[DataContract]
		public class L5US_GUGwRfT_1154 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_GroupID { get; set; } 
			[DataMember]
			public Dict Group_Name { get; set; } 
			[DataMember]
			public Guid[] AllowedRights { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GUGwRfT_1154_Array cls_Get_UserGroups_with_Rights_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GUGwRfT_1154_Array invocationResult = cls_Get_UserGroups_with_Rights_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

