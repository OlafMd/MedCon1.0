/* 
 * Generated on 2/5/2014 10:28:16 AM
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
using CL1_CMN_BPT;
using CL1_HEC_HIS;
using CL1_CMN_COM;
using CL1_CMN;
using PlannicoModel.Models;

namespace CL5_Plannico_HealthInsurances.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_HealthInsurances_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_HealthInsurances_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5HI_GHIFT_1138_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5HI_GHIFT_1138_Array();

            List<L5HI_GHIFT_1138> healthInsuranceResult=new List<L5HI_GHIFT_1138>();

            ORM_HEC_HIS_HealthInsurance_Company.Query healthInsurenceQuery = new ORM_HEC_HIS_HealthInsurance_Company.Query();
            healthInsurenceQuery.Tenant_RefID = securityTicket.TenantID;
            healthInsurenceQuery.IsDeleted = false;        
            List<ORM_HEC_HIS_HealthInsurance_Company> healthInsurances = ORM_HEC_HIS_HealthInsurance_Company.Query.Search(Connection, Transaction, healthInsurenceQuery);
            foreach(var healthInsurance in healthInsurances){


                if (healthInsurance.CMN_BPT_BusinessParticipant_RefID == Guid.Empty)
                    continue;

                L5HI_GHIFT_1138 item=new L5HI_GHIFT_1138();
                ORM_CMN_BPT_BusinessParticipant bpart =ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
                {
                    CMN_BPT_BusinessParticipantID = healthInsurance.CMN_BPT_BusinessParticipant_RefID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).FirstOrDefault();


                ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.Load(Connection, Transaction, bpart.IfCompany_CMN_COM_CompanyInfo_RefID);

                ORM_CMN_UniversalContactDetail ucd = new ORM_CMN_UniversalContactDetail();
                ucd.Load(Connection, Transaction, companyInfo.Contact_UCD_RefID);

                item.HEC_HealthInsurance_CompanyID = healthInsurance.HEC_HealthInsurance_CompanyID;
                item.DisplayName = bpart.DisplayName;
                item.HealthInsurance_IKNumber = healthInsurance.HealthInsurance_IKNumber;
                item.Country_ISO = ucd.Country_639_1_ISOCode;
                item.Town = ucd.Town;

                healthInsuranceResult.Add(item);
            }

            returnValue.Result=healthInsuranceResult.ToArray();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5HI_GHIFT_1138_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5HI_GHIFT_1138_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5HI_GHIFT_1138_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5HI_GHIFT_1138_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5HI_GHIFT_1138_Array functionReturn = new FR_L5HI_GHIFT_1138_Array();
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

				throw new Exception("Exception occured in method cls_Get_HealthInsurances_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5HI_GHIFT_1138_Array : FR_Base
	{
		public L5HI_GHIFT_1138[] Result	{ get; set; } 
		public FR_L5HI_GHIFT_1138_Array() : base() {}

		public FR_L5HI_GHIFT_1138_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5HI_GHIFT_1138_Array cls_Get_HealthInsurances_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5HI_GHIFT_1138_Array invocationResult = cls_Get_HealthInsurances_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
