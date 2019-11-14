/* 
 * Generated on 20/5/2014 03:23:01
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
using System.Runtime.Serialization;
using CL1_CMN_BPT;
using CL1_CMN_PER;

namespace CL3_PersonInfo.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_DefaultPerson_for_Company.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_DefaultPerson_for_Company
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PI_CDPfC_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            #region get company tenant

            ORM_CMN_BPT_BusinessParticipant.Query tenantBPQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            tenantBPQuery.IsTenant = true;
            tenantBPQuery.IfTenant_Tenant_RefID = securityTicket.TenantID;
            tenantBPQuery.IsDeleted = false;
            ORM_CMN_BPT_BusinessParticipant tenantBP = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, tenantBPQuery).First();

            #endregion

            #region check if tenant need default person

            Boolean needDefaultPerson = tenantBP.IsNaturalPerson;
            if (needDefaultPerson)
            {
                ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query associatedBPQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                associatedBPQuery.AssociatedBusinessParticipant_RefID = tenantBP.CMN_BPT_BusinessParticipantID;
                associatedBPQuery.IsDeleted = false;
                List<ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant> association = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, associatedBPQuery);
                if (association.Count > 0)
                {
                    foreach (var item in association)
                    {
                        if ((item.BusinessParticipant_RefID != null) || (item.BusinessParticipant_RefID != Guid.Empty))
                            needDefaultPerson = false;
                        break;
                    }
                }
            }

            #endregion
            
            if (needDefaultPerson)
            {
                #region create personalInfo

                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.IsDeleted = false;
                personInfo.FirstName = tenantBP.DisplayName;
                personInfo.LastName = tenantBP.DisplayName;
                personInfo.Creation_Timestamp = DateTime.Now;
                personInfo.Save(Connection, Transaction);

                #endregion

                #region create new businessParticipiant

                ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                bParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bParticipant.Tenant_RefID = securityTicket.TenantID;
                bParticipant.IsNaturalPerson = true;
                bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                bParticipant.DisplayName = tenantBP.DisplayName;
                bParticipant.Creation_Timestamp = DateTime.Now;
                bParticipant.Save(Connection, Transaction);

                #endregion

                #region create associated businessParticipant table

                ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant associatedBP = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                associatedBP.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = Guid.NewGuid();
                associatedBP.IsDeleted = false;
                associatedBP.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                associatedBP.AssociatedBusinessParticipant_RefID = tenantBP.CMN_BPT_BusinessParticipantID;
                associatedBP.Creation_Timestamp = DateTime.Now;
                associatedBP.Tenant_RefID = securityTicket.TenantID;
                associatedBP.Save(Connection, Transaction);
                #endregion

                returnValue.Result = bParticipant.CMN_BPT_BusinessParticipantID;
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
		public static FR_Guid Invoke(string ConnectionString,P_L5PI_CDPfC_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PI_CDPfC_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PI_CDPfC_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PI_CDPfC_1134 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_DefaultPerson_for_Company",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PI_CDPfC_1134 for attribute P_L5PI_CDPfC_1134
		[DataContract]
		public class P_L5PI_CDPfC_1134 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CompanyBPIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_DefaultPerson_for_Company(,P_L5PI_CDPfC_1134 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_DefaultPerson_for_Company.Invoke(connectionString,P_L5PI_CDPfC_1134 Parameter,securityTicket);
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
var parameter = new CL3_PersonInfo.Complex.Manipulation.P_L5PI_CDPfC_1134();
parameter.CompanyBPIDs = ...;

*/
