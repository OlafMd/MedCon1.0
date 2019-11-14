/* 
 * Generated on 2/1/2017 11:35:42 AM
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
using CL1_CMN_COM;
using CL1_CMN_BPT;
using CL1_CMN;
using MMDocConnectDBMethods.Pharmacy.Model;
using CL1_CMN_PER;
using MMDocConnectUtils;

namespace MMDocConnectDBMethods.Pharmacy.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Pharmacy.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Pharmacy
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_PH_SP_1124 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            #region Pharmacy
            var pharmacy = ORM_HEC_Pharmacy.Query.Search(Connection, Transaction, new ORM_HEC_Pharmacy.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_PharmacyID = Parameter.Pharmacy.PharmacyID
            }).SingleOrDefault();

            if (pharmacy == null)
            {
                pharmacy = new ORM_HEC_Pharmacy();
                pharmacy.Tenant_RefID = securityTicket.TenantID;
            }
            #endregion

            #region CompanyInfo

            var companyInfo = ORM_CMN_COM_CompanyInfo.Query.Search(Connection, Transaction, new ORM_CMN_COM_CompanyInfo.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_COM_CompanyInfoID = pharmacy.Ext_CompanyInfo_RefID
            }).SingleOrDefault();
            if (companyInfo == null)
            {
                companyInfo = new ORM_CMN_COM_CompanyInfo();
                companyInfo.Tenant_RefID = securityTicket.TenantID;


                pharmacy.Ext_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            }

            var contractUCD = ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction, new ORM_CMN_UniversalContactDetail.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_UniversalContactDetailID = companyInfo.Contact_UCD_RefID
            }).SingleOrDefault();
            if (contractUCD == null)
            {
                contractUCD = new ORM_CMN_UniversalContactDetail();
                contractUCD.Tenant_RefID = securityTicket.TenantID;
                contractUCD.IsCompany = true;
            }
            contractUCD.CompanyName_Line1 = Parameter.Pharmacy.PharmacyName;
            contractUCD.First_Name = Parameter.Pharmacy.PharmacyName;
            contractUCD.Contact_Email = Parameter.Pharmacy.Email;
            contractUCD.Contact_Telephone = Parameter.Pharmacy.PhoneNumber;
            contractUCD.Contact_Fax = Parameter.Pharmacy.Fax;
            contractUCD.Street_Name = Parameter.Pharmacy.Street;
            contractUCD.Street_Number = Parameter.Pharmacy.StreetNumber;
            contractUCD.ZIP = Parameter.Pharmacy.ZipCode;
            contractUCD.Town = Parameter.Pharmacy.Town;
            contractUCD.Save(Connection, Transaction);

            companyInfo.Contact_UCD_RefID = contractUCD.CMN_UniversalContactDetailID;
            companyInfo.Save(Connection, Transaction);

            var ciBusinessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID
            }).SingleOrDefault();
            if (ciBusinessParticipant == null)
            {
                ciBusinessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                ciBusinessParticipant.Tenant_RefID = securityTicket.TenantID;
                ciBusinessParticipant.IsCompany = true;
                ciBusinessParticipant.IfCompany_CMN_COM_CompanyInfo_RefID = companyInfo.CMN_COM_CompanyInfoID;
            }

            ciBusinessParticipant.Save(Connection, Transaction);

            var pharmacyType = EPharmacyType.Internal.Value();
            if (Parameter.Pharmacy.IsExternalPharmacy)
                pharmacyType = EPharmacyType.External.Value();

            var businessParticipantGroup = ORM_CMN_BPT_BusinessParticipant_Group.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_Group.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                GlobalPropertyMatchingID = pharmacyType
            }).SingleOrDefault();
            if (businessParticipantGroup == null)
            {
                businessParticipantGroup = new ORM_CMN_BPT_BusinessParticipant_Group();
                businessParticipantGroup.Tenant_RefID = securityTicket.TenantID;
                businessParticipantGroup.GlobalPropertyMatchingID = pharmacyType;
                businessParticipantGroup.Save(Connection, Transaction);
            }

            var bpToBpGroup = ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_BPT_BusinessParticipant_RefID = ciBusinessParticipant.CMN_BPT_BusinessParticipantID,
                CMN_BPT_BusinessParticipant_Group_RefID = businessParticipantGroup.CMN_BPT_BusinessParticipant_GroupID
            }).SingleOrDefault();
            if (bpToBpGroup == null)
            {
                bpToBpGroup = new ORM_CMN_BPT_BusinessParticipant_2_BusinessParticipantGroup();
                bpToBpGroup.Tenant_RefID = securityTicket.TenantID;
                bpToBpGroup.CMN_BPT_BusinessParticipant_Group_RefID = businessParticipantGroup.CMN_BPT_BusinessParticipant_GroupID;
                bpToBpGroup.CMN_BPT_BusinessParticipant_RefID = ciBusinessParticipant.CMN_BPT_BusinessParticipantID;
                bpToBpGroup.Save(Connection, Transaction);
            }
            #endregion

            #region ContactPersonInfo
            var contactInfo = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CMN_BPT_BusinessParticipantID = pharmacy.ContactPerson_BusinessParticipant_RefID
            }).SingleOrDefault();
            if (contactInfo == null)
            {
                contactInfo = new ORM_CMN_BPT_BusinessParticipant();
                contactInfo.Tenant_RefID = securityTicket.TenantID;
                contactInfo.IsNaturalPerson = true;
            }

            var personInfo = ORM_CMN_PER_PersonInfo.Query.Search(Connection, Transaction, new ORM_CMN_PER_PersonInfo.Query
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDead = false,
                CMN_PER_PersonInfoID = contactInfo.IfNaturalPerson_CMN_PER_PersonInfo_RefID
            }).SingleOrDefault();
            if (personInfo == null)
            {
                personInfo = new ORM_CMN_PER_PersonInfo();
                personInfo.Tenant_RefID = securityTicket.TenantID;
            }
            var splitedName = Parameter.Pharmacy.ContactPersonName.Split(' ');
            var firstName = splitedName.Length > 1 ? string.Join(" ", splitedName.Take(splitedName.Length - 1)) : splitedName[0];
            var lastName = splitedName.Length > 1 ? splitedName.Last() : "";

            personInfo.FirstName = firstName;
            personInfo.LastName = lastName;
            personInfo.Save(Connection, Transaction);

            contactInfo.IfNaturalPerson_CMN_PER_PersonInfo_RefID = personInfo.CMN_PER_PersonInfoID;
            contactInfo.Save(Connection, Transaction);

            pharmacy.ContactPerson_BusinessParticipant_RefID = contactInfo.CMN_BPT_BusinessParticipantID;

            #endregion

            pharmacy.Save(Connection, Transaction);

            returnValue.Result = pharmacy.HEC_PharmacyID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_PH_SP_1124 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_PH_SP_1124 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_PH_SP_1124 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_PH_SP_1124 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Save_Pharmacy", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_PH_SP_1124 for attribute P_PH_SP_1124
    [DataContract]
    public class P_PH_SP_1124
    {
        //Standard type parameters
        [DataMember]
        public MMDocConnectDBMethods.Pharmacy.Model.Pharmacy Pharmacy { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Pharmacy(,P_PH_SP_1124 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Pharmacy.Invoke(connectionString,P_PH_SP_1124 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Pharmacy.Atomic.Manipulation.P_PH_SP_1124();
parameter.Pharmacy = ...;

*/
