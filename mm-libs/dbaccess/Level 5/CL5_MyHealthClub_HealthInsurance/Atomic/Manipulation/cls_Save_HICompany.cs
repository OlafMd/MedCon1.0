/* 
 * Generated on 26.06.2014 15:20:20
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
using CL1_HEC;
using CL1_HEC_HIS;
using CL1_CMN_BPT;
using CL1_CMN_COM;

namespace CL5_MyHealthClub_HealthInsurance.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_HICompany.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_HICompany
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5HI_SHIC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_HEC_HIS_HealthInsurance_Company hiCompany;
            if (Parameter.HEC_HealthInsurance_CompanyID != Guid.Empty)
            {
                if (Parameter.IsDeleted)
                {
                    ORM_HEC_HIS_HealthInsurance_Company.Query.SoftDelete(Connection, Transaction, new ORM_HEC_HIS_HealthInsurance_Company.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        HEC_HealthInsurance_CompanyID = Parameter.HEC_HealthInsurance_CompanyID
                    });
                    return returnValue;
                }

                hiCompany = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, new ORM_HEC_HIS_HealthInsurance_Company.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    HEC_HealthInsurance_CompanyID = Parameter.HEC_HealthInsurance_CompanyID
                }).Single();

            }
            else
            {
                hiCompany = new ORM_HEC_HIS_HealthInsurance_Company();
                hiCompany.HEC_HealthInsurance_CompanyID = Guid.NewGuid();
                hiCompany.Tenant_RefID = securityTicket.TenantID;
            }

            hiCompany.HealthInsurance_IKNumber = Parameter.HealthInsurance_IKNumber;
            if (hiCompany.CMN_BPT_BusinessParticipant_RefID == Guid.Empty)
                hiCompany.CMN_BPT_BusinessParticipant_RefID = Guid.NewGuid();

            hiCompany.Save(Connection, Transaction);

            var bussinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IsCompany = true,
                CMN_BPT_BusinessParticipantID = hiCompany.CMN_BPT_BusinessParticipant_RefID
            }).SingleOrDefault();
            if (bussinessParticipant == null)
            {
                bussinessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                bussinessParticipant.CMN_BPT_BusinessParticipantID = hiCompany.CMN_BPT_BusinessParticipant_RefID;
                bussinessParticipant.Tenant_RefID = securityTicket.TenantID;
                bussinessParticipant.IsCompany = true;
            }
            bussinessParticipant.DisplayName = Parameter.DisplayName;

            if (bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID == Guid.Empty)
                bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = Guid.NewGuid();
            bussinessParticipant.Save(Connection, Transaction);

            var comapny = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_COM_CompanyInfoID = bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID
            }).SingleOrDefault();
            if (comapny == null)
            {
                comapny = new ORM_CMN_COM_CompanyInfo();
                comapny.CMN_COM_CompanyInfoID = bussinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                comapny.Tenant_RefID = securityTicket.TenantID;
            }
            comapny.Save(Connection, Transaction);

            returnValue.Result = hiCompany.HEC_HealthInsurance_CompanyID;
            return returnValue;



			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5HI_SHIC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5HI_SHIC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5HI_SHIC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5HI_SHIC_1519 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_HICompany",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5HI_SHIC_1519 for attribute P_L5HI_SHIC_1519
		[DataContract]
		public class P_L5HI_SHIC_1519 
		{
			//Standard type parameters
			[DataMember]
			public String HealthInsurance_IKNumber { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid HEC_HealthInsurance_CompanyID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_HICompany(,P_L5HI_SHIC_1519 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_HICompany.Invoke(connectionString,P_L5HI_SHIC_1519 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_HealthInsurance.Atomic.Manipulation.P_L5HI_SHIC_1519();
parameter.HealthInsurance_IKNumber = ...;
parameter.DisplayName = ...;
parameter.HEC_HealthInsurance_CompanyID = ...;
parameter.IsDeleted = ...;

*/
