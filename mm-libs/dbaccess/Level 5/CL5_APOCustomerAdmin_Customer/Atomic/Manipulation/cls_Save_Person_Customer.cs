/* 
 * Generated on 09/01/2014 10:28:06
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
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL1_CMN_PER;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOCustomerAdmin_Customer.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Person_Customer.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Person_Customer
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5ACACU_SPC_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            if (Parameter.IsDelete && (Parameter.CMN_BPT_CTM_CustomerID == Guid.Empty))
                return returnValue;

            ORM_CMN_BPT_CTM_Customer customer;
            if (Parameter.CMN_BPT_CTM_CustomerID != Guid.Empty)
            {
                var customerQ = new ORM_CMN_BPT_CTM_Customer.Query();
                customerQ.Tenant_RefID = securityTicket.TenantID;
                customerQ.IsDeleted = false;
                customerQ.CMN_BPT_CTM_CustomerID = Parameter.CMN_BPT_CTM_CustomerID;
                customer = ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction, customerQ).First();
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
                bParticipant.IsNaturalPerson = true;
                customer.Ext_BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            }

            bParticipant.DisplayName = Parameter.FirstName + " " + Parameter.LastName;

            ORM_CMN_PER_PersonInfo personInfo;
            if (bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID != Guid.Empty)
            {
                var personInfoQ = new ORM_CMN_PER_PersonInfo.Query();
                personInfoQ.Tenant_RefID = securityTicket.TenantID;
                personInfoQ.IsDeleted = false;
                personInfoQ.CMN_PER_PersonInfoID = bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID;
                personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, personInfoQ).First();
            }
            else
            {
                personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.Tenant_RefID = securityTicket.TenantID;
                personInfo.CMN_PER_PersonInfoID = Guid.NewGuid();
                bParticipant.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
            }

            #region connection with legal guardian
            //checking is there allready legal guardian associated with this business participant

            ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query LGCheckQuery = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query();
            LGCheckQuery.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
            LGCheckQuery.IsDeleted = false;

            Boolean oldLegalGuardianConnectionExist = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Exists(Connection, Transaction, LGCheckQuery);

            if (Parameter.IsRepresentedByLegalGuardian)
            {

                if (oldLegalGuardianConnectionExist)
                {
                    ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant oldLegalGuardianConnection = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, LGCheckQuery).First();
                    ORM_CMN_BPT_BusinessParticipant.Query oldLegalGuardianQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    oldLegalGuardianQuery.CMN_BPT_BusinessParticipantID = oldLegalGuardianConnection.AssociatedBusinessParticipant_RefID;
                    oldLegalGuardianQuery.IsDeleted = false;

                    ORM_CMN_BPT_BusinessParticipant oldLegalGuardian = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, oldLegalGuardianQuery).First();
                    oldLegalGuardian.DisplayName = Parameter.LegalGuardianName;
                    oldLegalGuardian.Save(Connection, Transaction);
                }
                else
                {
                    // creating a new legal guardian
                    ORM_CMN_BPT_BusinessParticipant newLegalGuardian = new ORM_CMN_BPT_BusinessParticipant();
                    ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant legalGuardianLink = new ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant();

                    newLegalGuardian.DisplayName = Parameter.LegalGuardianName;
                    legalGuardianLink.AssociatedBusinessParticipant_RefID = newLegalGuardian.CMN_BPT_BusinessParticipantID;
                    legalGuardianLink.BusinessParticipant_RefID = bParticipant.CMN_BPT_BusinessParticipantID;
                    newLegalGuardian.Save(Connection, Transaction);
                    legalGuardianLink.Save(Connection, Transaction);
                }

            }
            else {
                //delete old legal guardian if there is an old legal guardian
                if (oldLegalGuardianConnectionExist)
                {
                    ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant oldLegalGuardianConnection = ORM_CMN_BPT_BusinessParticipant_AssociatedBusinessParticipant.Query.Search(Connection, Transaction, LGCheckQuery).First();
                    ORM_CMN_BPT_BusinessParticipant.Query oldLegalGuardianQuery = new ORM_CMN_BPT_BusinessParticipant.Query();
                    oldLegalGuardianQuery.CMN_BPT_BusinessParticipantID = oldLegalGuardianConnection.AssociatedBusinessParticipant_RefID;
                    oldLegalGuardianQuery.IsDeleted = false;

                    //deleting old legal guardian from business participant table
                    if (ORM_CMN_BPT_BusinessParticipant.Query.Exists(Connection, Transaction, oldLegalGuardianQuery)) {
                        ORM_CMN_BPT_BusinessParticipant oldLegalGuardian = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, oldLegalGuardianQuery).First();
                        oldLegalGuardian.IsDeleted = true;
                        oldLegalGuardian.Save(Connection, Transaction);
                    }
                    // deleting connenction beetwen customer and legal guardian
                    oldLegalGuardianConnection.IsDeleted = true;
                    oldLegalGuardianConnection.Save(Connection,Transaction);
                }
            }

            #endregion

            personInfo.FirstName = Parameter.FirstName;
            personInfo.LastName = Parameter.LastName;
            personInfo.BirthDate = Parameter.BirthDate;
            personInfo.IsRepresentedByLegalGuardian = Parameter.IsRepresentedByLegalGuardian;

            personInfo.IsDeleted = Parameter.IsDelete;
            bParticipant.IsDeleted = Parameter.IsDelete;
            customer.IsDeleted = Parameter.IsDelete;

            personInfo.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_L5ACACU_SPC_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5ACACU_SPC_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ACACU_SPC_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ACACU_SPC_1047 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Person_Customer",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ACACU_SPC_1047 for attribute P_L5ACACU_SPC_1047
		[DataContract]
		public class P_L5ACACU_SPC_1047 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_CTM_CustomerID { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public String Number { get; set; } 
			[DataMember]
			public Guid PaymentTypeID { get; set; } 
			[DataMember]
			public bool IsDelete { get; set; } 
			[DataMember]
			public Guid PaymentConditionID { get; set; } 
			[DataMember]
			public bool IsRepresentedByLegalGuardian { get; set; } 
			[DataMember]
			public String LegalGuardianName { get; set; } 
			[DataMember]
			public bool IsCustomerOrderAutomaticallyApprovedOnReceipt { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Person_Customer(,P_L5ACACU_SPC_1047 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Person_Customer.Invoke(connectionString,P_L5ACACU_SPC_1047 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Customer.Atomic.Manipulation.P_L5ACACU_SPC_1047();
parameter.CMN_BPT_CTM_CustomerID = ...;
parameter.LastName = ...;
parameter.FirstName = ...;
parameter.BirthDate = ...;
parameter.Number = ...;
parameter.PaymentTypeID = ...;
parameter.IsDelete = ...;
parameter.PaymentConditionID = ...;
parameter.IsRepresentedByLegalGuardian = ...;
parameter.LegalGuardianName = ...;
parameter.IsCustomerOrderAutomaticallyApprovedOnReceipt = ...;

*/
