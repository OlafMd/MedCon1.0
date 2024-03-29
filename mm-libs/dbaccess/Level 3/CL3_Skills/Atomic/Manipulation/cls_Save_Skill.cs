/* 
 * Generated on 5/27/2014 2:27:12 PM
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
using CL1_CMN_STR;

namespace CL3_Skills.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Skill.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Skill
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3S_SS_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            if (Parameter.SkillID == Guid.Empty)
            {
                ORM_CMN_STR_Skill skill = new ORM_CMN_STR_Skill();
                skill.CMN_STR_SkillID = Guid.NewGuid();
                skill.Skill_Name = Parameter.Name;
                skill.IsDeleted = false;
                skill.Tenant_RefID = securityTicket.TenantID;
                skill.Save(Connection, Transaction);
                returnValue.Result = skill.CMN_STR_SkillID;
            }
            else
            {
                var skill = ORM_CMN_STR_Skill.Query.Search(Connection, Transaction, new ORM_CMN_STR_Skill.Query { CMN_STR_SkillID = Parameter.SkillID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).FirstOrDefault();
                if (Parameter.IsDeleted == false)
                {
                    skill.Skill_Name = Parameter.Name;
                }
                skill.IsDeleted = Parameter.IsDeleted;
                skill.Save(Connection, Transaction);
                returnValue.Result = skill.CMN_STR_SkillID;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3S_SS_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3S_SS_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3S_SS_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3S_SS_1408 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Skill",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3S_SS_1408 for attribute P_L3S_SS_1408
		[DataContract]
		public class P_L3S_SS_1408 
		{
			//Standard type parameters
			[DataMember]
			public Guid SkillID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Dict Description { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Skill(,P_L3S_SS_1408 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Skill.Invoke(connectionString,P_L3S_SS_1408 Parameter,securityTicket);
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
var parameter = new CL3_Skills.Atomic.Manipulation.P_L3S_SS_1408();
parameter.SkillID = ...;
parameter.Name = ...;
parameter.Description = ...;
parameter.IsDeleted = ...;

*/
