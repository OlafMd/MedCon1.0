/* 
 * Generated on 10/15/2014 2:49:01 PM
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
using CL1_CMN;

namespace CL3_Country.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Assign_Countries_To_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Assign_Countries_To_Tenant
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L3_ACTT_1438 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {

            #region UserCode

            var returnValue = new FR_Base();

            if (Parameter == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = "Assign_Countries_To_Tenant method returned error message: Parameter is null.";
                return returnValue;
            }

            ORM_CMN_Country[] countries = null;

            #region Retrieve all countries for tenant

            countries = ORM_CMN_Country.Query.Search(Connection, Transaction, new ORM_CMN_Country.Query()
            {
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();

            #endregion

            #region Assign/deassign countries

            foreach (var countryToAssign in Parameter.AssignedCountries)
            {
                var country = countries.FirstOrDefault(c => c.Country_ISOCode_Alpha3 == countryToAssign.CountryISOCode);
                if (country == null)
                {
                    country = new ORM_CMN_Country();
                    country.CMN_CountryID = Guid.NewGuid();
                    country.Country_ISOCode_Alpha3 = countryToAssign.CountryISOCode;
                    country.Country_Name = countryToAssign.CountryName;
                    country.Creation_Timestamp = DateTime.Now;
                    country.Default_Currency_RefID = Guid.Empty;
                    country.Default_Language_RefID = Guid.Empty;
                    country.Tenant_RefID = securityTicket.TenantID;
                    country.IsDeleted = false;
                    country.Save(Connection, Transaction);
                }

                if (country.IsDeleted == true)
                {
                    country.IsDeleted = false;
                    country.Save(Connection, Transaction);
                }
            }

            foreach (var country in countries.Where(c => c.IsDeleted == false))
            {
                var countryToAssign = Parameter.AssignedCountries.FirstOrDefault(cta => cta.CountryISOCode == country.Country_ISOCode_Alpha3);
                if (countryToAssign == null)
                {
                    country.IsDeleted = true;
                    country.Save(Connection, Transaction);
                }
            }

            #endregion

            #region Set default country for tenant

            if (Parameter.DefaultCountry != null)
            {
                foreach (var country in countries)
                {
                    if (country.IsDefault)
                    {
                        country.IsDefault = false;
                        country.Save(Connection, Transaction);
                    }
                }

                foreach (var country in countries)
                {
                    if (country.Country_ISOCode_Alpha3 == Parameter.DefaultCountry.CountryISOCode)
                    {
                        country.IsDefault = true;
                        country.Save(Connection, Transaction);
                        break;
                    }
                }
            }

            #endregion

            returnValue.Status = FR_Status.Success;

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Base Invoke(string ConnectionString, P_L3_ACTT_1438 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L3_ACTT_1438 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L3_ACTT_1438 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3_ACTT_1438 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Base functionReturn = new FR_Base();
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

                throw new Exception("Exception occured in method cls_Assign_Countries_To_Tenant", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3_ACTT_1438 for attribute P_L3_ACTT_1438
    [DataContract]
    public class P_L3_ACTT_1438
    {
        [DataMember]
        public P_L3_ACTT_1438a[] AssignedCountries { get; set; }

        //Standard type parameters
        [DataMember]
        public P_L3_ACTT_1438a DefaultCountry { get; set; }

    }
    #endregion
    #region SClass P_L3_ACTT_1438a for attribute AssignedCountries
    [DataContract]
    public class P_L3_ACTT_1438a
    {
        //Standard type parameters
        [DataMember]
        public string CountryISOCode { get; set; }
        [DataMember]
        public Dict CountryName { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Assign_Countries_To_Tenant(,P_L3_ACTT_1438 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Assign_Countries_To_Tenant.Invoke(connectionString,P_L3_ACTT_1438 Parameter,securityTicket);
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
var parameter = new CL3_Country.Atomic.Manipulation.P_L3_ACTT_1438();
parameter.AssignedCountries = ...;

parameter.DefaultCountry = ...;

*/
