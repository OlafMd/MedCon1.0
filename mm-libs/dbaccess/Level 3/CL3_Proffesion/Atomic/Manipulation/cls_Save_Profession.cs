/* 
 * Generated on 6/2/2014 3:01:54 PM
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

namespace CL3_Profession.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Profession.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Profession
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3P_SP_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (Parameter.StaffTypeID == Guid.Empty)
            {
                ORM_CMN_STR_Profession profession = new ORM_CMN_STR_Profession();
                profession.CMN_STR_ProfessionID = Guid.NewGuid();
                profession.ProfessionName = Parameter.Name;
                profession.IsDeleted = false;
                profession.Tenant_RefID = securityTicket.TenantID;

                if (Parameter.IsLANRNeeded)
                {
                    ORM_CMN_STR_ProfessionKey professionKey = new ORM_CMN_STR_ProfessionKey();
                    professionKey.CMN_STR_ProfessionKeyID = Guid.NewGuid();
                    professionKey.CMN_STR_Profession_RefID = profession.CMN_STR_ProfessionID;
                    professionKey.SocialSecurityProfessionKey = Parameter.ProfessionKey;
                    professionKey.IsDeleted = false;
                    professionKey.Tenant_RefID = securityTicket.TenantID;
                    professionKey.Save(Connection, Transaction);
                }

                if (Parameter.Skills != null)
                {
                    foreach (var skillParam in Parameter.Skills)
                    {
                        ORM_CMN_STR_Skill_2_Profession skill2profession = new ORM_CMN_STR_Skill_2_Profession();
                        skill2profession.AssignmentID = Guid.NewGuid();
                        skill2profession.Profession_RefID = profession.CMN_STR_ProfessionID;
                        skill2profession.Skill_RefID = skillParam.StaffSkillID;
                        skill2profession.IsDeleted = skillParam.IsDeleted;
                        skill2profession.Tenant_RefID = securityTicket.TenantID;
                        skill2profession.Save(Connection, Transaction);
                    }
                }
                profession.Save(Connection, Transaction);
                returnValue.Result = profession.CMN_STR_ProfessionID;
            }
            else
            {
                var profession = ORM_CMN_STR_Profession.Query.Search(Connection, Transaction, new ORM_CMN_STR_Profession.Query { CMN_STR_ProfessionID = Parameter.StaffTypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                if (Parameter.IsDeleted == false)
                {
                    profession.ProfessionName = Parameter.Name;
                    profession.IsDeleted = false;

                    var professionKey = ORM_CMN_STR_ProfessionKey.Query.Search(Connection, Transaction, new ORM_CMN_STR_ProfessionKey.Query { SocialSecurityProfessionKey = Parameter.ProfessionKey, CMN_STR_Profession_RefID = Parameter.StaffTypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                    if (professionKey != null)
                    {
                        if (Parameter.IsLANRNeeded)
                        {
                            professionKey.SocialSecurityProfessionKey = Parameter.ProfessionKey;
                        }
                        else
                        {
                            professionKey.IsDeleted = true;
                        }
                        professionKey.Save(Connection, Transaction);
                    }
                    else
                    {
                        if (Parameter.IsLANRNeeded)
                        {
                            professionKey = new ORM_CMN_STR_ProfessionKey();
                            professionKey.CMN_STR_ProfessionKeyID = Guid.NewGuid();
                            professionKey.CMN_STR_Profession_RefID = profession.CMN_STR_ProfessionID;
                            professionKey.SocialSecurityProfessionKey = Parameter.ProfessionKey;
                            professionKey.IsDeleted = false;
                            professionKey.Tenant_RefID = securityTicket.TenantID;
                            professionKey.Save(Connection, Transaction);
                        }
                    }

                    if (Parameter.Skills != null)
                    {
                        foreach (var skillParam in Parameter.Skills)
                        {
                            var skillsFromParam = ORM_CMN_STR_Skill_2_Profession.Query.Search(Connection, Transaction, new ORM_CMN_STR_Skill_2_Profession.Query { Skill_RefID = skillParam.StaffSkillID, Profession_RefID = Parameter.StaffTypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                            if (skillsFromParam == null)
                            {
                                ORM_CMN_STR_Skill_2_Profession skill2profession = new ORM_CMN_STR_Skill_2_Profession();
                                skill2profession.AssignmentID = Guid.NewGuid();
                                skill2profession.Profession_RefID = profession.CMN_STR_ProfessionID;
                                skill2profession.Skill_RefID = skillParam.StaffSkillID;
                                skill2profession.IsDeleted = skillParam.IsDeleted;
                                skill2profession.Tenant_RefID = securityTicket.TenantID;
                                skill2profession.Save(Connection, Transaction);
                            }
                            else
                            {
                                skillsFromParam.IsDeleted = skillParam.IsDeleted;
                                skillsFromParam.Tenant_RefID = securityTicket.TenantID;
                                skillsFromParam.Save(Connection, Transaction);
                            }
                        }
                    }
                }
                else
                {
                    var skillsForDelete = ORM_CMN_STR_Skill_2_Profession.Query.SoftDelete(Connection, Transaction, new ORM_CMN_STR_Skill_2_Profession.Query { Profession_RefID = Parameter.StaffTypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    var professionKey = ORM_CMN_STR_ProfessionKey.Query.SoftDelete(Connection, Transaction, new ORM_CMN_STR_ProfessionKey.Query { SocialSecurityProfessionKey = Parameter.ProfessionKey, CMN_STR_Profession_RefID = Parameter.StaffTypeID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID });
                    profession.IsDeleted = true;
                }
                
                profession.Save(Connection, Transaction);
                returnValue.Result = profession.CMN_STR_ProfessionID;
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
		public static FR_Guid Invoke(string ConnectionString,P_L3P_SP_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3P_SP_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3P_SP_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3P_SP_1653 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Profession",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3P_SP_1653 for attribute P_L3P_SP_1653
		[DataContract]
		public class P_L3P_SP_1653 
		{
			[DataMember]
			public P_L3P_SP_1653_Skill[] Skills { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid StaffTypeID { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsLANRNeeded { get; set; } 
			[DataMember]
			public string ProfessionKey { get; set; } 

		}
		#endregion
		#region SClass P_L3P_SP_1653_Skill for attribute Skills
		[DataContract]
		public class P_L3P_SP_1653_Skill 
		{
			//Standard type parameters
			[DataMember]
			public Guid StaffSkillID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Profession(,P_L3P_SP_1653 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Profession.Invoke(connectionString,P_L3P_SP_1653 Parameter,securityTicket);
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
var parameter = new CL3_Profession.Atomic.Manipulation.P_L3P_SP_1653();
parameter.Skills = ...;

parameter.StaffTypeID = ...;
parameter.Name = ...;
parameter.IsDeleted = ...;
parameter.IsLANRNeeded = ...;
parameter.ProfessionKey = ...;

*/
