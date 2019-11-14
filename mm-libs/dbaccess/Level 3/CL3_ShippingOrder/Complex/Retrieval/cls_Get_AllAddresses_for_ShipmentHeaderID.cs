/* 
 * Generated on 7/31/2014 10:35:50 AM
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
using CL1_LOG_SHP;
using CL3_CustomerAdresses.Complex.Retrieval;
using CL3_OrganizationalStructure.Atomic.Retrieval;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL3_ShippingOrder.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_AllAddresses_for_ShipmentHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_AllAddresses_for_ShipmentHeaderID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L3SO_GAAfSHI_1612_Array Execute(DbConnection Connection, DbTransaction Transaction, P_L3SO_GAAfSHI_1612 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L3SO_GAAfSHI_1612_Array();
            //Put your code here

            var list = new List<L3SO_GAAfSHI_1612>();

            #region Organization Addresses

            var param = new P_L3OS_GOAfSHI_1407 { 
                ShipmentHeaderID = Parameter.ShipmentHeaderID 
            };

            var OrganizationAddress = cls_Get_OrganizationAddress_for_ShipmentHeaderID.Invoke(Connection, Transaction, param, securityTicket).Result;

            if (OrganizationAddress.Any())
                foreach (var address in OrganizationAddress)
                {
                    L3SO_GAAfSHI_1612 item = new L3SO_GAAfSHI_1612();
                    item.AddressID = address.CMN_UniversalContactDetailID;
                    item.Street_Name = address.Street_Name;
                    item.Street_Number = address.Street_Number;
                    item.IsDefault = address.IsPrimary;
                    item.Town = address.Town;
                    item.ZIP = address.ZIP;
                    item.hasOrganizationUnit = true;
                    item.IsCompany = address.IsCompany;
                    list.Add(item);
                }

            #endregion

            #region Customer Addresses

            var Shipment = new ORM_LOG_SHP_Shipment_Header();
            Shipment.Load(Connection, Transaction, Parameter.ShipmentHeaderID);

            var Customer = CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT_CTM.ORM_CMN_BPT_CTM_Customer.Query
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    Ext_BusinessParticipant_RefID = Shipment.RecipientBusinessParticipant_RefID
                }).SingleOrDefault();

            List<L3ACAAD_GCAfT_1612> CustomerAddress = new List<L3ACAAD_GCAfT_1612>();
             CustomerAddress =
                   cls_Get_CustomerAddresses_for_CustomerID.Invoke(Connection, Transaction,
                       new P_L3ACAAD_GCAfCID_1612 { CustomerID = Customer.CMN_BPT_CTM_CustomerID }, securityTicket).Result.ToList();

            if (CustomerAddress.Any())
                foreach (var address in CustomerAddress)
                {
                    if (!string.IsNullOrEmpty(address.Street_Name))
                    {
                        L3SO_GAAfSHI_1612 item = new L3SO_GAAfSHI_1612();
                        item.AddressID = address.AddressID;
                        item.Street_Name = address.Street_Name;
                        item.Street_Number = address.Street_Number;
                        item.IsDefault = address.IsDefault;
                        item.IsBilling = address.IsBilling;
                        item.IsShipping = address.IsShipping;
                        item.IsContact = address.IsContact;
                        item.IsCompany = address.IsCompany;
                        item.Town = address.Town;
                        item.ZIP = address.ZIP;
                        item.hasOrganizationUnit = false;
                        
                        list.Add(item);
                    }
                }

            #endregion

            returnValue.Result = list.ToArray();
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L3SO_GAAfSHI_1612_Array Invoke(string ConnectionString, P_L3SO_GAAfSHI_1612 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L3SO_GAAfSHI_1612_Array Invoke(DbConnection Connection, P_L3SO_GAAfSHI_1612 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L3SO_GAAfSHI_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction, P_L3SO_GAAfSHI_1612 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L3SO_GAAfSHI_1612_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3SO_GAAfSHI_1612 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L3SO_GAAfSHI_1612_Array functionReturn = new FR_L3SO_GAAfSHI_1612_Array();
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

                throw new Exception("Exception occured in method cls_Get_AllAddresses_for_ShipmentHeaderID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L3SO_GAAfSHI_1612_Array : FR_Base
    {
        public L3SO_GAAfSHI_1612[] Result { get; set; }
        public FR_L3SO_GAAfSHI_1612_Array() : base() { }

        public FR_L3SO_GAAfSHI_1612_Array(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L3SO_GAAfSHI_1612 for attribute P_L3SO_GAAfSHI_1612
    [DataContract]
    public class P_L3SO_GAAfSHI_1612
    {
        //Standard type parameters
        [DataMember]
        public Guid ShipmentHeaderID { get; set; }

    }
    #endregion
    #region SClass L3SO_GAAfSHI_1612 for attribute L3SO_GAAfSHI_1612
    [DataContract]
    public class L3SO_GAAfSHI_1612
    {
        //Standard type parameters
        [DataMember]
        public Guid AddressID { get; set; }
        [DataMember]
        public bool IsContact { get; set; }
        [DataMember]
        public bool IsBilling { get; set; }
        [DataMember]
        public bool IsShipping { get; set; }
        [DataMember]
        public bool IsDefault { get; set; }
        [DataMember]
        public bool IsCompany { get; set; }
        [DataMember]
        public bool hasOrganizationUnit { get; set; }
        [DataMember]
        public string Street_Name { get; set; }
        [DataMember]
        public string Street_Number { get; set; }
        [DataMember]
        public string ZIP { get; set; }
        [DataMember]
        public string Town { get; set; }
        [DataMember]
        public string Country_639_1_ISOCode { get; set; }
        [DataMember]
        public Guid AssignmentID { get; set; }
        [DataMember]
        public Guid CMN_COM_CompanyInfo_AddressID { get; set; }
        [DataMember]
        public string Country_Name { get; set; }
        [DataMember]
        public string AddressName { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3SO_GAAfSHI_1612_Array cls_Get_AllAddresses_for_ShipmentHeaderID(,P_L3SO_GAAfSHI_1612 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3SO_GAAfSHI_1612_Array invocationResult = cls_Get_AllAddresses_for_ShipmentHeaderID.Invoke(connectionString,P_L3SO_GAAfSHI_1612 Parameter,securityTicket);
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
var parameter = new CL3_ShippingOrder.Complex.Retrieval.P_L3SO_GAAfSHI_1612();
parameter.ShipmentHeaderID = ...;

*/
