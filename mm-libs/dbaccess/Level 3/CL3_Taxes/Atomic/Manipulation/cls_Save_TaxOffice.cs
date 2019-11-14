/* 
 * Generated on 11/6/2013 2:14:53 PM
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
using CL1_CMN_BPT;
using CL1_ACC_TAX;
using CL1_CMN_COM;
using CL2_Country.Atomic.Retrieval;
using CL1_CMN;

namespace CL3_Taxes.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TaxOffice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TaxOffice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3TX_STXO_0929 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            var item = new ORM_ACC_TAX_TaxOffice();
            if (Parameter.ACC_TAX_TaxOfficeID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.ACC_TAX_TaxOfficeID);
                if (result.Status != FR_Status.Success || item.ACC_TAX_TaxOfficeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }

                ORM_CMN_BPT_BusinessParticipant.Query bptQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                bptQuery.CMN_BPT_BusinessParticipantID = item.CMN_BPT_BusinessParticipant_RefID;
                bptQuery.Tenant_RefID = securityTicket.TenantID;
                bptQuery.IsDeleted = false;

                ORM_CMN_BPT_BusinessParticipant bparticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bptQuery).FirstOrDefault();

                bparticipant.DisplayName = Parameter.DisplayName;
                bparticipant.Save(Connection, Transaction);

                ORM_CMN_COM_CompanyInfo.Query cmpInfoQuery = new ORM_CMN_COM_CompanyInfo.Query();
                cmpInfoQuery.CMN_COM_CompanyInfoID = bparticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                cmpInfoQuery.IsDeleted = false;
                cmpInfoQuery.Tenant_RefID = securityTicket.TenantID;

                ORM_CMN_COM_CompanyInfo companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, cmpInfoQuery).FirstOrDefault();
                companyInfo.VATIdentificationNumber = Parameter.VATIdentificationNumber;
                companyInfo.Save(Connection, Transaction);
                returnValue.Result = item.ACC_TAX_TaxOfficeID;

                if (companyInfo.Contact_UCD_RefID != Guid.Empty)
                {
                    var countries = cls_Get_AllCountries.Invoke(Connection, Transaction, securityTicket).Result;

                    ORM_CMN_UniversalContactDetail.Query ucdQuery = new ORM_CMN_UniversalContactDetail.Query();
                    ucdQuery.CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID;
                    ucdQuery.Tenant_RefID = securityTicket.TenantID;
                    ucdQuery.IsDeleted = false;

                    ORM_CMN_UniversalContactDetail ucd = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, ucdQuery).FirstOrDefault();
                    ucd.Country_639_1_ISOCode = Parameter.Country_ISO;
                    ucd.Save(Connection, Transaction);

                }


            }
            else
            {
                ORM_CMN_COM_CompanyInfo companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.VATIdentificationNumber = Parameter.VATIdentificationNumber;
                companyInfo.Tenant_RefID = securityTicket.TenantID;


                ORM_CMN_BPT_BusinessParticipant bparticipant = new ORM_CMN_BPT_BusinessParticipant();
                bparticipant.DisplayName = Parameter.DisplayName;
                bparticipant.IsCompany=true;
                bparticipant.IfCompany_CMN_COM_CompanyInfo_RefID=companyInfo.CMN_COM_CompanyInfoID;
                bparticipant.Tenant_RefID = securityTicket.TenantID;
                bparticipant.Save(Connection, Transaction);

                ORM_ACC_TAX_TaxOffice taxOffice = new ORM_ACC_TAX_TaxOffice();
                taxOffice.CMN_BPT_BusinessParticipant_RefID = bparticipant.CMN_BPT_BusinessParticipantID;
                taxOffice.Tenant_RefID = securityTicket.TenantID;
                taxOffice.Save(Connection, Transaction);
                returnValue.Result = taxOffice.ACC_TAX_TaxOfficeID;

                if (Parameter.Country_ISO != "")
                {
                    var countries = cls_Get_AllCountries.Invoke(Connection, Transaction, securityTicket).Result;
                    ORM_CMN_UniversalContactDetail ucd = new ORM_CMN_UniversalContactDetail();
                    ucd.Country_639_1_ISOCode = Parameter.Country_ISO;
                    ucd.Tenant_RefID = securityTicket.TenantID;
                    ucd.Save(Connection, Transaction);
                    companyInfo.Contact_UCD_RefID = ucd.CMN_UniversalContactDetailID;
                }

                companyInfo.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L3TX_STXO_0929 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3TX_STXO_0929 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TX_STXO_0929 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TX_STXO_0929 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_TaxOffice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3TX_STXO_0929 for attribute P_L3TX_STXO_0929
		[DataContract]
		public class P_L3TX_STXO_0929 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_TAX_TaxOfficeID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String VATIdentificationNumber { get; set; } 
			[DataMember]
			public string Country_ISO { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TaxOffice(,P_L3TX_STXO_0929 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TaxOffice.Invoke(connectionString,P_L3TX_STXO_0929 Parameter,securityTicket);
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
var parameter = new CL3_Taxes.Atomic.Manipulation.P_L3TX_STXO_0929();
parameter.ACC_TAX_TaxOfficeID = ...;
parameter.DisplayName = ...;
parameter.VATIdentificationNumber = ...;
parameter.Country_ISO = ...;

*/