/* 
 * Generated on 09/01/2014 10:05:10
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
using CL1_CMN;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_CMN_COM;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOCustomerAdmin_Customer.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Company_Customer.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Company_Customer
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ACACU_SCC_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if(Parameter.IsDelete && (Parameter.CMN_BPT_CTM_CustomerID == Guid.Empty))
                return returnValue;

            ORM_CMN_BPT_CTM_Customer customer;
            if (Parameter.CMN_BPT_CTM_CustomerID != Guid.Empty)
            {
                var customerQ = new ORM_CMN_BPT_CTM_Customer.Query();
                customerQ.Tenant_RefID = securityTicket.TenantID;
                customerQ.IsDeleted = false;
                customerQ.CMN_BPT_CTM_CustomerID = Parameter.CMN_BPT_CTM_CustomerID;
                customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQ).First();
                customer.InternalCustomerNumber = Parameter.Number;
                customer.IsCustomerOrderAutomaticallyApprovedOnReceipt =
                    Parameter.IsCustomerOrderAutomaticallyApprovedOnReceipt;
            }
            else
            {
                customer = new ORM_CMN_BPT_CTM_Customer();
                customer.Tenant_RefID = securityTicket.TenantID;
                customer.CMN_BPT_CTM_CustomerID = Guid.NewGuid();
                customer.InternalCustomerNumber = Parameter.Number;
                customer.IsCustomerOrderAutomaticallyApprovedOnReceipt =
                    Parameter.IsCustomerOrderAutomaticallyApprovedOnReceipt;
            }

            ORM_CMN_BPT_CTM_AvailablePaymentType customer2PaymentType;

            var customer2PaymentTypeQ = new ORM_CMN_BPT_CTM_AvailablePaymentType.Query();
            customer2PaymentTypeQ.Tenant_RefID = securityTicket.TenantID;
            customer2PaymentTypeQ.IsDeleted = false;
            customer2PaymentTypeQ.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;

            customer2PaymentType = ORM_CMN_BPT_CTM_AvailablePaymentType.Query.Search(Connection, Transaction, customer2PaymentTypeQ).FirstOrDefault();
            if (customer2PaymentType == null)
            {
                customer2PaymentType = new ORM_CMN_BPT_CTM_AvailablePaymentType();
                customer2PaymentType.ACC_PAY_Type_RefID = Guid.NewGuid();
                customer2PaymentType.Tenant_RefID = securityTicket.TenantID;
                customer2PaymentType.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;
            }
            customer2PaymentType.ACC_PAY_Type_RefID = Parameter.PaymentTypeID;
            customer2PaymentType.Save(Connection, Transaction);

            #region payment condition

            ORM_CMN_BPT_CTM_AvailablePaymentCondition customer2PaymentCondition;

            var customer2PaymentConditionQ = new ORM_CMN_BPT_CTM_AvailablePaymentCondition.Query();
            customer2PaymentConditionQ.Tenant_RefID = securityTicket.TenantID;
            customer2PaymentConditionQ.IsDeleted = false;
            customer2PaymentConditionQ.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;

            customer2PaymentCondition = ORM_CMN_BPT_CTM_AvailablePaymentCondition.Query.Search(Connection, Transaction, customer2PaymentConditionQ).FirstOrDefault();
            if (customer2PaymentCondition == null)
            {
                customer2PaymentCondition = new ORM_CMN_BPT_CTM_AvailablePaymentCondition();
                customer2PaymentCondition.ACC_PAY_Condition_RefID = Guid.NewGuid();
                customer2PaymentCondition.Tenant_RefID = securityTicket.TenantID;
                customer2PaymentCondition.Customer_RefID = customer.CMN_BPT_CTM_CustomerID;
            }
            customer2PaymentCondition.ACC_PAY_Condition_RefID = Parameter.PaymentConditionID;
            customer2PaymentCondition.Save(Connection, Transaction);

            #endregion

            ORM_CMN_BPT_BusinessParticipant bParticipant;
            if (customer.Ext_BusinessParticipant_RefID != Guid.Empty)
            {
                var bParticipantQ = new ORM_CMN_BPT_BusinessParticipant.Query();
                bParticipantQ.Tenant_RefID = securityTicket.TenantID;
                bParticipantQ.IsDeleted = false;
                bParticipantQ.CMN_BPT_BusinessParticipantID = customer.Ext_BusinessParticipant_RefID;
                bParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, bParticipantQ).First();
            }
            else
            {
                bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                bParticipant.Tenant_RefID = securityTicket.TenantID;
                bParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                bParticipant.IsCompany = true;
                customer.Ext_BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            }

            bParticipant.DisplayName = Parameter.FirmName;

            ORM_CMN_COM_CompanyInfo company;
            if (bParticipant.IfCompany_CMN_COM_CompanyInfo_RefID != Guid.Empty)
            {
                var companyQ = new ORM_CMN_COM_CompanyInfo.Query();
                companyQ.Tenant_RefID = securityTicket.TenantID;
                companyQ.IsDeleted = false;
                companyQ.CMN_COM_CompanyInfoID = bParticipant.IfCompany_CMN_COM_CompanyInfo_RefID;
                company = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, companyQ).First();
            }
            else
            {
                company = new ORM_CMN_COM_CompanyInfo();
                company.Tenant_RefID = securityTicket.TenantID;
                company.CMN_COM_CompanyInfoID = Guid.NewGuid();
                bParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = company.CMN_COM_CompanyInfoID;
            }

            ORM_CMN_UniversalContactDetail ucd;
            if (company.Contact_UCD_RefID != Guid.Empty)
            {
                var ucdQ = new ORM_CMN_UniversalContactDetail.Query();
                ucdQ.Tenant_RefID = securityTicket.TenantID;
                ucdQ.IsDeleted = false;
                ucdQ.CMN_UniversalContactDetailID = company.Contact_UCD_RefID;
                ucd = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, ucdQ).First();
            }
            else
            {
                ucd = new ORM_CMN_UniversalContactDetail();
                ucd.Tenant_RefID = securityTicket.TenantID;
                ucd.CMN_UniversalContactDetailID = Guid.NewGuid();
                ucd.IsCompany = true;
                company.Contact_UCD_RefID = ucd.CMN_UniversalContactDetailID;
            }

            ucd.CompanyName_Line1 = Parameter.FirmName;
            ucd.CompanyName_Line2 = Parameter.Additional;
            ucd.IsDeleted = Parameter.IsDelete;
            company.IsDeleted = Parameter.IsDelete;
            bParticipant.IsDeleted = Parameter.IsDelete;
            customer.IsDeleted = Parameter.IsDelete;

            ucd.Save(Connection, Transaction);
            company.Save(Connection, Transaction);
            bParticipant.Save(Connection, Transaction);
            customer.Save(Connection, Transaction);

            returnValue.Result = customer.CMN_BPT_CTM_CustomerID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5ACACU_SCC_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ACACU_SCC_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ACACU_SCC_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ACACU_SCC_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Company_Customer",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ACACU_SCC_1051 for attribute P_L5ACACU_SCC_1051
		[DataContract]
		public class P_L5ACACU_SCC_1051 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public String FirmName { get; set; } 
			[DataMember]
			public String Additional { get; set; } 
			[DataMember]
			public String Number { get; set; } 
			[DataMember]
			public Guid PaymentTypeID { get; set; } 
			[DataMember]
			public bool IsDelete { get; set; } 
			[DataMember]
			public Guid PaymentConditionID { get; set; } 
			[DataMember]
			public bool IsCustomerOrderAutomaticallyApprovedOnReceipt  { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Company_Customer(,P_L5ACACU_SCC_1051 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Company_Customer.Invoke(connectionString,P_L5ACACU_SCC_1051 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Customer.Atomic.Manipulation.P_L5ACACU_SCC_1051();
parameter.CMN_BPT_CTM_CustomerID = ...;
parameter.FirmName = ...;
parameter.Additional = ...;
parameter.Number = ...;
parameter.PaymentTypeID = ...;
parameter.IsDelete = ...;
parameter.PaymentConditionID = ...;
parameter.IsCustomerOrderAutomaticallyApprovedOnReceipt  = ...;

*/
