/* 
 * Generated on 12/16/2014 2:08:34 PM
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
using CL1_CMN_STR;
using CL1_CMN;

namespace CL3_Address.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_All_ShippingAddresses_For_CostCenter.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_All_ShippingAddresses_For_CostCenter
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L3AD_GaSAfCC_1508_Array Execute(DbConnection Connection, DbTransaction Transaction, P_L3AD_GaSAfCC_1508 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L3AD_GaSAfCC_1508_Array();
            returnValue.Result = new L3AD_GaSAfCC_1508[0];

            var offices2CostCenter = ORM_CMN_STR_Office_2_CostCenter.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office_2_CostCenter.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                CostCenter_RefID = Parameter.CostCenterID
            }).ToArray();

            List<ORM_CMN_STR_Office> officesToSelect = new List<ORM_CMN_STR_Office>();

            if (offices2CostCenter != null && offices2CostCenter.Length > 0)
            {
                var offices = ORM_CMN_STR_Office.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });

                foreach (var office2CostCenter in offices2CostCenter)
                {
                    var office = offices.FirstOrDefault(o => o.CMN_STR_OfficeID == office2CostCenter.Office_RefID);
                    if (office != null)
                    {

                        if (!officesToSelect.Exists(o => o.CMN_STR_OfficeID == office.CMN_STR_OfficeID))
                        {
                            officesToSelect.Add(office);
                            FindAllChildren(officesToSelect, offices, office.CMN_STR_OfficeID);
                        }
                    }

                }

            }


            List<L3AD_GaSAfCC_1508> shippmentAddresses = new List<L3AD_GaSAfCC_1508>();
            int level = 0;
            foreach (var officeToSelect in officesToSelect)
            {

                var officeAddresses = ORM_CMN_STR_Office_Address.Query.Search(Connection, Transaction, new ORM_CMN_STR_Office_Address.Query()
                {
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID,
                    IsShippingAddress = true,
                    Office_RefID = officeToSelect.CMN_STR_OfficeID
                });

                foreach (var officeAddress in officeAddresses)
                {
                    var address = ORM_CMN_Address.Query.Search(Connection, Transaction, new ORM_CMN_Address.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_AddressID = officeAddress.CMN_Address_RefID
                    }).FirstOrDefault();


                    if (address != null)
                    {
                        var shippmentAddress = new L3AD_GaSAfCC_1508();
                        shippmentAddress.OfficeName = officeToSelect.Office_InternalName;
                        shippmentAddress.IsDefault = officeAddress.IsDefault;
                        shippmentAddress.OfficeLevel = level;
                        shippmentAddress.Address = address;
                        shippmentAddresses.Add(shippmentAddress);
                    }
                }

                level++;

            }

            returnValue.Result = shippmentAddresses.ToArray();
            return returnValue;
            #endregion UserCode
        }


        #region Method Invocation Extensions

        private static void FindAllChildren(List<ORM_CMN_STR_Office> officesToSelect, List<ORM_CMN_STR_Office> offices, Guid parentId)
        {
            foreach (var office in offices)
            {
                if (office.Parent_RefID == parentId)
                {
                    if (!officesToSelect.Exists(o => o.CMN_STR_OfficeID == office.CMN_STR_OfficeID))
                    {
                        officesToSelect.Add(office);
                        FindAllChildren(officesToSelect, offices, office.CMN_STR_OfficeID);
                    }
                }
            }
        }


        #endregion

        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L3AD_GaSAfCC_1508_Array Invoke(string ConnectionString, P_L3AD_GaSAfCC_1508 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L3AD_GaSAfCC_1508_Array Invoke(DbConnection Connection, P_L3AD_GaSAfCC_1508 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L3AD_GaSAfCC_1508_Array Invoke(DbConnection Connection, DbTransaction Transaction, P_L3AD_GaSAfCC_1508 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L3AD_GaSAfCC_1508_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3AD_GaSAfCC_1508 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L3AD_GaSAfCC_1508_Array functionReturn = new FR_L3AD_GaSAfCC_1508_Array();
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

                throw new Exception("Exception occured in method cls_Get_All_ShippingAddresses_For_CostCenter", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L3AD_GaSAfCC_1508_Array : FR_Base
    {
        public L3AD_GaSAfCC_1508[] Result { get; set; }
        public FR_L3AD_GaSAfCC_1508_Array() : base() { }

        public FR_L3AD_GaSAfCC_1508_Array(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L3AD_GaSAfCC_1508 for attribute P_L3AD_GaSAfCC_1508
    [DataContract]
    public class P_L3AD_GaSAfCC_1508
    {
        //Standard type parameters
        [DataMember]
        public Guid CostCenterID { get; set; }

    }
    #endregion
    #region SClass L3AD_GaSAfCC_1508 for attribute L3AD_GaSAfCC_1508
    [DataContract]
    public class L3AD_GaSAfCC_1508
    {
        //Standard type parameters
        [DataMember]
        public string OfficeName { get; set; }
        [DataMember]
        public bool IsDefault { get; set; }
        [DataMember]
        public int OfficeLevel { get; set; }
        [DataMember]
        public ORM_CMN_Address Address { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3AD_GaSAfCC_1508_Array cls_Get_All_ShippingAddresses_For_CostCenter(,P_L3AD_GaSAfCC_1508 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3AD_GaSAfCC_1508_Array invocationResult = cls_Get_All_ShippingAddresses_For_CostCenter.Invoke(connectionString,P_L3AD_GaSAfCC_1508 Parameter,securityTicket);
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
var parameter = new CL3_Address.Complex.Retrieval.P_L3AD_GaSAfCC_1508();
parameter.CostCenterID = ...;

*/
