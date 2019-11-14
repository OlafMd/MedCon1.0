/* 
 * Generated on 11/13/2014 5:49:43 PM
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
using CL3_Tenant.Complex.Manipulation;
using CL1_CMN_BPT_CTM;
using CL2_FiscalYear.Complex.Retrieval;
using CL3_BookingAccounts.Complex.Manipulation;
using CL1_CMN_BPT;
using CL1_CMN_PER;

namespace CL3_Customer.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CreateCustomer_after_MessageReceive.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CreateCustomer_after_MessageReceive
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CU_CCaMR_1308 Execute(DbConnection Connection,DbTransaction Transaction,P_L3CU_CCaMR_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L3CU_CCaMR_1308();
            returnValue.Status = FR_Status.Error_Internal;
            returnValue.Result = new L3CU_CCaMR_1308();

            #region Load or Create Customer Tenant Initial Table Structure
            var customerTenantStructure = cls_Create_Tenant_Initial_Table_Structure.Invoke(
                Connection,
                Transaction,
                new P_L3TE_CTITS_1108()
                {
                    TenantITL = Parameter.Customer_TenantITL,
                    BusinessParticipantITL = Parameter.Customer_BusinessParticipantITL,
                    TenantUniversalContactDetailITL = Parameter.Customer_TenantUniversalContactDetailITL,
                    CompanyInfoUniversalContactDetailITL = Parameter.Customer_CompanyInfoUniversalContactDetailITL,
                    CompanyName = Parameter.Customer_CompanyName,
                    ContactEmail = Parameter.Customer_ContactEmail
                },
                securityTicket);
            #endregion
            if (customerTenantStructure.Status != FR_Status.Success)
            {
                return returnValue;
            }

            #region Load or Create Customer
            var cust = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_Customer.Query()
            {
                Ext_BusinessParticipant_RefID = customerTenantStructure.Result.BusinessParticipantID,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (cust == default(ORM_CMN_BPT_CTM_Customer))
            {
                cust = new ORM_CMN_BPT_CTM_Customer();
                cust.CMN_BPT_CTM_CustomerID = Guid.NewGuid();
                cust.Ext_BusinessParticipant_RefID = customerTenantStructure.Result.BusinessParticipantID;
                cust.Tenant_RefID = securityTicket.TenantID;
                cust.Creation_Timestamp = DateTime.Now;
                cust.Save(Connection, Transaction);
            }
            #endregion

            #region Create booking account
            var fiscalYear = cls_Get_Current_FiscalYear.Invoke(Connection, Transaction, securityTicket).Result;

            var bookingAccountParam = new P_L3BA_CCAfBP_1655()
            {
                BusinessParticipantIDs = new Guid[1] { customerTenantStructure.Result.BusinessParticipantID },
                FiscalYearID = fiscalYear.ACC_FiscalYearID
            };

            var result = cls_Create_Customer_Account_for_BusinessParticipants.Invoke(Connection, Transaction, bookingAccountParam, securityTicket).Result;
            #endregion

            #region create defaultPerson for customer

            var businessParticipantQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
            businessParticipantQuery.CMN_BPT_BusinessParticipantID = cust.Ext_BusinessParticipant_RefID;
            businessParticipantQuery.IsDeleted = false;
            var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantQuery).Single();

            if (businessParticipant.IsNaturalPerson)
            {
                if (businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID == null || businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID == Guid.Empty)
                {
                    var personInfo = new ORM_CMN_PER_PersonInfo();
                    personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                    personInfo.Tenant_RefID = securityTicket.TenantID;
                    personInfo.IsDeleted = false;
                    personInfo.FirstName = businessParticipant.DisplayName;
                    personInfo.LastName = businessParticipant.DisplayName;
                    personInfo.Creation_Timestamp = DateTime.Now;
                    personInfo.Save(Connection, Transaction);

                    businessParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                }
            }
            else if (businessParticipant.IsCompany)
            {
                Boolean needDefaultPerson = true;
                var associatedBPQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
                associatedBPQuery.AssociatedBusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                associatedBPQuery.Tenant_RefID = securityTicket.TenantID;
                associatedBPQuery.IsDeleted = false;
                List<ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant> associations = 
                    ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, associatedBPQuery);
                if (associations.Count > 0)
                {
                    foreach (var assotiation in associations)
                    {
                        if (assotiation.BusinessParticipant_RefID != Guid.Empty)
                        {
                            ORM_CMN_BPT_BusinessParticipant.Query businessParticipantPersonQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                            businessParticipantPersonQuery.CMN_BPT_BusinessParticipantID = assotiation.BusinessParticipant_RefID;
                            businessParticipantPersonQuery.IsDeleted = false;
                            businessParticipantPersonQuery.IsNaturalPerson = true;
                            List<ORM_CMN_BPT_BusinessParticipant> businessParticipantsPerson = 
                                ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, businessParticipantPersonQuery);
                            foreach (var person in businessParticipantsPerson)
                            {
                                if (person.IfNaturalPerson_CMN_PER_PersonInfo_RefID == Guid.Empty)
                                {
                                    ORM_CMN_PER_PersonInfo personInfoNew = new ORM_CMN_PER_PersonInfo();
                                    personInfoNew.CMN_PER_PersonInfoID = Guid.NewGuid();
                                    personInfoNew.Tenant_RefID = securityTicket.TenantID;
                                    personInfoNew.IsDeleted = false;
                                    personInfoNew.FirstName = person.DisplayName;
                                    personInfoNew.LastName = person.DisplayName;
                                    personInfoNew.Creation_Timestamp = DateTime.Now;
                                    personInfoNew.Save(Connection, Transaction);

                                    person.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfoNew.CMN_PER_PersonInfoID;
                                }

                                needDefaultPerson = false;
                                break;
                            }
                        }
                    }
                }

                if (needDefaultPerson)
                {
                    #region create personalInfo
                    ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                    personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                    personInfo.Tenant_RefID = securityTicket.TenantID;
                    personInfo.IsDeleted = false;
                    personInfo.FirstName = businessParticipant.DisplayName;
                    personInfo.LastName = businessParticipant.DisplayName;
                    personInfo.Creation_Timestamp = DateTime.Now;
                    personInfo.Save(Connection, Transaction);
                    #endregion

                    #region create new businessParticipiant
                    ORM_CMN_BPT_BusinessParticipant bParticipant = new ORM_CMN_BPT_BusinessParticipant();
                    bParticipant.CMN_BPT_BusinessParticipantID = Guid.NewGuid();
                    bParticipant.Tenant_RefID = securityTicket.TenantID;
                    bParticipant.IsNaturalPerson = true;
                    bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
                    bParticipant.DisplayName = businessParticipant.DisplayName;
                    bParticipant.Creation_Timestamp = DateTime.Now;
                    bParticipant.Save(Connection, Transaction);
                    #endregion

                    #region create associated businessParticipant table
                    ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant associatedBP = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();
                    associatedBP.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = Guid.NewGuid();
                    associatedBP.IsDeleted = false;
                    associatedBP.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                    associatedBP.AssociatedBusinessParticipant_RefID = businessParticipant.CMN_BPT_BusinessParticipantID;
                    associatedBP.Creation_Timestamp = DateTime.Now;
                    associatedBP.Tenant_RefID = securityTicket.TenantID;
                    associatedBP.Save(Connection, Transaction);
                    #endregion
                }
            }
            #endregion


            returnValue.Result.Customer_TenantID = customerTenantStructure.Result.TenantID;
            returnValue.Result.Customer_BusinessParticipantID = customerTenantStructure.Result.BusinessParticipantID;
            returnValue.Result.Customer_CompanyInfo_UniversalContactDetailID = customerTenantStructure.Result.CompanyInfoUniversalContactDetailID;
            returnValue.Result.Customer_Tenant_UniversalContactDetailID = customerTenantStructure.Result.TenantUniversalContactDetailID;
            returnValue.Result.Customer_CustomerID = cust.CMN_BPT_CTM_CustomerID;
            returnValue.Result.Customer_CompanyInfoID = customerTenantStructure.Result.CompanyInfoID;
            returnValue.Result.IsCustomerOrderAutomaticallyApprovedOnReceipt = cust.IsCustomerOrderAutomaticallyApprovedOnReceipt;
            returnValue.Status = FR_Status.Success;

            return returnValue;


            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CU_CCaMR_1308 Invoke(string ConnectionString,P_L3CU_CCaMR_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CU_CCaMR_1308 Invoke(DbConnection Connection,P_L3CU_CCaMR_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CU_CCaMR_1308 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CU_CCaMR_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CU_CCaMR_1308 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CU_CCaMR_1308 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CU_CCaMR_1308 functionReturn = new FR_L3CU_CCaMR_1308();
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

				throw new Exception("Exception occured in method cls_CreateCustomer_after_MessageReceive",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CU_CCaMR_1308 : FR_Base
	{
		public L3CU_CCaMR_1308 Result	{ get; set; }

		public FR_L3CU_CCaMR_1308() : base() {}

		public FR_L3CU_CCaMR_1308(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CU_CCaMR_1308 for attribute P_L3CU_CCaMR_1308
		[DataContract]
		public class P_L3CU_CCaMR_1308 
		{
			//Standard type parameters
			[DataMember]
			public String Customer_TenantITL { get; set; } 
			[DataMember]
			public String Customer_CompanyName { get; set; } 
			[DataMember]
			public String Customer_ContactEmail { get; set; } 
			[DataMember]
			public String Customer_BusinessParticipantITL { get; set; } 
			[DataMember]
			public String Customer_TenantUniversalContactDetailITL { get; set; } 
			[DataMember]
			public String Customer_CompanyInfoUniversalContactDetailITL { get; set; } 

		}
		#endregion
		#region SClass L3CU_CCaMR_1308 for attribute L3CU_CCaMR_1308
		[DataContract]
		public class L3CU_CCaMR_1308 
		{
			//Standard type parameters
			[DataMember]
			public Guid Customer_TenantID { get; set; } 
			[DataMember]
			public Guid Customer_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid Customer_CompanyInfo_UniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid Customer_Tenant_UniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid Customer_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid Customer_CustomerID { get; set; } 
			[DataMember]
			public Boolean IsCustomerOrderAutomaticallyApprovedOnReceipt { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CU_CCaMR_1308 cls_CreateCustomer_after_MessageReceive(,P_L3CU_CCaMR_1308 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CU_CCaMR_1308 invocationResult = cls_CreateCustomer_after_MessageReceive.Invoke(connectionString,P_L3CU_CCaMR_1308 Parameter,securityTicket);
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
var parameter = new CL3_Customer.Complex.Manipulation.P_L3CU_CCaMR_1308();
parameter.Customer_TenantITL = ...;
parameter.Customer_CompanyName = ...;
parameter.Customer_ContactEmail = ...;
parameter.Customer_BusinessParticipantITL = ...;
parameter.Customer_TenantUniversalContactDetailITL = ...;
parameter.Customer_CompanyInfoUniversalContactDetailITL = ...;

*/
