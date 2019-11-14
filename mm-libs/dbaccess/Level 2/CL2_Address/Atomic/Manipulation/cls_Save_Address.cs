/* 
 * Generated on 10/31/2013 11:33:37 AM
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
using CL1_CMN;

namespace CL2_Address.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Address.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Address
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L2AD_SA_1755 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            var returnValue = new FR_Guid();

            var item = new ORM_CMN_Address();

            if (Parameter.CMN_AddressID != Guid.Empty)
            {
                item.Load(Connection, Transaction, Parameter.CMN_AddressID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_AddressID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.CMN_AddressID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.Street_Name = Parameter.Street_Name;
            item.Street_Number = Parameter.Street_Number;
            item.City_AdministrativeDistrict = Parameter.City_AdministrativeDistrict;
            item.City_Region = Parameter.City_Region;
            item.City_Name = Parameter.City_Name;
            item.City_PostalCode = Parameter.City_PostalCode;
            item.Province_Name = Parameter.Province_Name;
            item.Country_Name = Parameter.Country_Name;
            item.CareOf = Parameter.CareOf;
            item.Country_ISOCode = Parameter.Country_ISOCode;
            item.Province_EconomicRegion_RefID = Parameter.Province_EconomicRegion_RefID;
            
            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_AddressID);
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_L2AD_SA_1755 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L2AD_SA_1755 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L2AD_SA_1755 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L2AD_SA_1755 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_Address", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L2AD_SA_1755 for attribute P_L2AD_SA_1755
    [DataContract]
    public class P_L2AD_SA_1755
    {
        //Standard type parameters
        [DataMember]
        public Guid CMN_AddressID { get; set; }
        [DataMember]
        public String Street_Name { get; set; }
        [DataMember]
        public String Street_Number { get; set; }
        [DataMember]
        public String City_AdministrativeDistrict { get; set; }
        [DataMember]
        public String City_Region { get; set; }
        [DataMember]
        public String City_Name { get; set; }
        [DataMember]
        public String City_PostalCode { get; set; }
        [DataMember]
        public String Province_Name { get; set; }
        [DataMember]
        public String Country_Name { get; set; }
        [DataMember]
        public String CareOf { get; set; }
        [DataMember]
        public String Country_ISOCode { get; set; }
        [DataMember]
        public Guid Province_EconomicRegion_RefID { get; set; }
        [DataMember]
        public Boolean IsDeleted { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Address(,P_L2AD_SA_1755 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Address.Invoke(connectionString,P_L2AD_SA_1755 Parameter,securityTicket);
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
var parameter = new CL2_Address.Atomic.Manipulation.P_L2AD_SA_1755();
parameter.CMN_AddressID = ...;
parameter.Street_Name = ...;
parameter.Street_Number = ...;
parameter.City_AdministrativeDistrict = ...;
parameter.City_Region = ...;
parameter.City_Name = ...;
parameter.City_PostalCode = ...;
parameter.Province_Name = ...;
parameter.Country_Name = ...;
parameter.CareOf = ...;
parameter.Country_ISOCode = ...;
parameter.Province_EconomicRegion_RefID = ...;
parameter.IsDeleted = ...;

*/
