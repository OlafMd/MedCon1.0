/* 
 * Generated on 12/16/2013 2:08:09 PM
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
using CL2_Country.Atomic.Retrieval;
using CL1_CMN_BPT;
using CL1_CMN_COM;
using PlannicoModel.Models;

namespace CL5_Plannico_HealthInsurances.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_HealthInsurance.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_HealthInsurance
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5HI_SHI_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();



            FR_Base result=new FR_Base();
			//Put your code here
            var item = new ORM_HEC_HIS_HealthInsurance_Company();
            if (Parameter.HEC_HealthInsurance_CompanyID != Guid.Empty)
            {
                result = item.Load(Connection, Transaction, Parameter.HEC_HealthInsurance_CompanyID);
                if (result.Status != FR_Status.Success || item.HEC_HealthInsurance_CompanyID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            item.HealthInsurance_IKNumber = Parameter.HealthInsurance_IKNumber;
            item.Tenant_RefID = securityTicket.TenantID;

            ORM_CMN_BPT_BusinessParticipant bpart = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
            {
                CMN_BPT_BusinessParticipantID = item.CMN_BPT_BusinessParticipant_RefID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).FirstOrDefault();
            if (bpart == null || bpart.CMN_BPT_BusinessParticipantID == Guid.Empty)
            {
                bpart = new ORM_CMN_BPT_BusinessParticipant();
            }
            bpart.DisplayName = Parameter.CompanyName;
            bpart.Tenant_RefID = securityTicket.TenantID;
  

            item.CMN_BPT_BusinessParticipant_RefID = bpart.CMN_BPT_BusinessParticipantID;

            ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
            result = companyInfo.Load(Connection, Transaction, bpart.IfCompany_CMN_COM_CompanyInfo_RefID);
            if (result.Status != FR_Status.Success || companyInfo.CMN_COM_CompanyInfoID == Guid.Empty)
            {
                    companyInfo=new ORM_CMN_COM_CompanyInfo();
            }
            bpart.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            bpart.Save(Connection, Transaction);

            ORM_CMN_UniversalContactDetail ucd = new ORM_CMN_UniversalContactDetail();
            result = ucd.Load(Connection, Transaction, companyInfo.Contact_UCD_RefID);
            if (result.Status != FR_Status.Success || ucd.CMN_UniversalContactDetailID == Guid.Empty)
            {
                ucd = new ORM_CMN_UniversalContactDetail();
            }
            companyInfo.Tenant_RefID = securityTicket.TenantID;
            companyInfo.Contact_UCD_RefID = ucd.CMN_UniversalContactDetailID;
            companyInfo.Save(Connection, Transaction);


            returnValue.Result = item.HEC_HealthInsurance_CompanyID;

            if (Parameter.Country_ISO != "")
            {
                ucd.Country_639_1_ISOCode = Parameter.Country_ISO;
                ucd.Town = Parameter.Town;
                ucd.Tenant_RefID = securityTicket.TenantID;

            }
            ucd.Save(Connection, Transaction);

            item.Save(Connection, Transaction);


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5HI_SHI_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5HI_SHI_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5HI_SHI_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5HI_SHI_1158 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_HealthInsurance",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_HealthInsurance(,P_L5HI_SHI_1158 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_HealthInsurance.Invoke(connectionString,P_L5HI_SHI_1158 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_HealthInsurances.Atomic.Manipulation.P_L5HI_SHI_1158();
parameter.HEC_HealthInsurance_CompanyID = ...;
parameter.CompanyName = ...;
parameter.HealthInsurance_IKNumber = ...;
parameter.Country_ISO = ...;
parameter.Town = ...;

*/