/* 
 * Generated on 10/29/2013 10:52:55 AM
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
using CL1_HEC_HIS;
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_COM;
using PlannicoModel.Models;

namespace CL5_Plannico_HealthInsurances.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_HealthInsurances_For_HealthInsuranceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_HealthInsurances_For_HealthInsuranceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5HI_GHIFHIID_1329 Execute(DbConnection Connection,DbTransaction Transaction,P_L5HI_GHIFHIID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5HI_GHIFHIID_1329();

			//Put your code here
            returnValue.Result = new L5HI_GHIFHIID_1329();

            ORM_HEC_HIS_HealthInsurance_Company.Query healthInsurenceQuery = new ORM_HEC_HIS_HealthInsurance_Company.Query();
            healthInsurenceQuery.HEC_HealthInsurance_CompanyID = Parameter.HEC_HealthInsurance_CompanyID;
            healthInsurenceQuery.Tenant_RefID = securityTicket.TenantID;
            healthInsurenceQuery.IsDeleted = false;

           

            List<ORM_HEC_HIS_HealthInsurance_Company> healthInsurances = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, healthInsurenceQuery);
            if (healthInsurances.Count == 0)
            {
                return null;
            }
            else
            {

                ORM_CMN_BPT_BusinessParticipant bpart =ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
                {
                    CMN_BPT_BusinessParticipantID = healthInsurances[0].CMN_BPT_BusinessParticipant_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).FirstOrDefault();


                ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.Load(Connection, Transaction, bpart.IfCompany_CMN_COM_CompanyInfo_RefID);

                ORM_CMN_UniversalContactDetail ucd = new ORM_CMN_UniversalContactDetail();
                ucd.Load(Connection, Transaction, companyInfo.Contact_UCD_RefID);
               

                L5HI_GHIFT_1138 healthInsurance = new L5HI_GHIFT_1138();
                healthInsurance.HEC_HealthInsurance_CompanyID = healthInsurances[0].HEC_HealthInsurance_CompanyID;
                healthInsurance.DisplayName = bpart.DisplayName;
                healthInsurance.HealthInsurance_IKNumber = healthInsurances[0].HealthInsurance_IKNumber;
                healthInsurance.Country_ISO = ucd.Country_639_1_ISOCode;
                healthInsurance.Town = ucd.Town;

                returnValue.Result.HealthInsurance = healthInsurance;
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5HI_GHIFHIID_1329 Invoke(string ConnectionString,P_L5HI_GHIFHIID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5HI_GHIFHIID_1329 Invoke(DbConnection Connection,P_L5HI_GHIFHIID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5HI_GHIFHIID_1329 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5HI_GHIFHIID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5HI_GHIFHIID_1329 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5HI_GHIFHIID_1329 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5HI_GHIFHIID_1329 functionReturn = new FR_L5HI_GHIFHIID_1329();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5HI_GHIFHIID_1329 : FR_Base
	{
		public L5HI_GHIFHIID_1329 Result	{ get; set; }

		public FR_L5HI_GHIFHIID_1329() : base() {}

		public FR_L5HI_GHIFHIID_1329(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5HI_GHIFHIID_1329 cls_Get_HealthInsurances_For_HealthInsuranceID(P_L5HI_GHIFHIID_1329 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5HI_GHIFHIID_1329 result = cls_Get_HealthInsurances_For_HealthInsuranceID.Invoke(connectionString,P_L5HI_GHIFHIID_1329 Parameter,securityTicket);
	 return result;
}
*/