/* 
 * Generated on 10/25/2013 4:51:18 PM
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
using CL5_Plannico_Qualifications.Atomic.Retrieval;
using CL1_CMN_STR;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_Qualifications.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Qualification_For_SkillID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Qualification_For_SkillID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5QF_GQFS_1447 Execute(DbConnection Connection,DbTransaction Transaction,P_L5QF_GQFS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5QF_GQFS_1447();

            ORM_CMN_STR_Skill.Query skillQuery = new ORM_CMN_STR_Skill.Query();
            skillQuery.CMN_STR_SkillID = Parameter.CMN_STR_SkillID;
            skillQuery.IsDeleted = false;
            skillQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_CMN_STR_Skill> skills = ORM_CMN_STR_Skill.Query.Search(Connection, Transaction, skillQuery);
            if (skills!=null&&skills.Count!= 0)
            {
                L5QF_GQFT_1443 qualification = new L5QF_GQFT_1443();

                ORM_CMN_STR_Skill skill = skills[0];
                qualification.CMN_STR_SkillID = skill.CMN_STR_SkillID;
                qualification.Skill_Name = skill.Skill_Name;
                qualification.Skill_Description = skill.Skill_Description;
                returnValue.Result = new L5QF_GQFS_1447();
                returnValue.Result.Qualification = qualification;
            }
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5QF_GQFS_1447 Invoke(string ConnectionString,P_L5QF_GQFS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5QF_GQFS_1447 Invoke(DbConnection Connection,P_L5QF_GQFS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5QF_GQFS_1447 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5QF_GQFS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5QF_GQFS_1447 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5QF_GQFS_1447 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5QF_GQFS_1447 functionReturn = new FR_L5QF_GQFS_1447();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Get_Qualification_For_SkillID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5QF_GQFS_1447 : FR_Base
	{
		public L5QF_GQFS_1447 Result	{ get; set; }

		public FR_L5QF_GQFS_1447() : base() {}

		public FR_L5QF_GQFS_1447(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5QF_GQFS_1447 cls_Get_Qualification_For_SkillID(,P_L5QF_GQFS_1447 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5QF_GQFS_1447 invocationResult = cls_Get_Qualification_For_SkillID.Invoke(connectionString,P_L5QF_GQFS_1447 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_Qualifications.Complex.Retrieval.P_L5QF_GQFS_1447();
parameter.CMN_STR_SkillID = ...;

*/