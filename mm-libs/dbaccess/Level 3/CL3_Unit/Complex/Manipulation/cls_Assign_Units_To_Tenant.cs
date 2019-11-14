/* 
 * Generated on 10/20/2014 10:20:45 AM
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

namespace CL3_Unit.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Assign_Units_To_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Assign_Units_To_Tenant
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Base Execute(DbConnection Connection, DbTransaction Transaction, P_L3_AUTT_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Base();

            if (Parameter == null)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.ErrorMessage = "Assign_Units_To_Tenant method returned error message: Parameter is null.";
                return returnValue;
            }


            ORM_CMN_Unit[] units = null;

            #region Retrieve all units fro tenant

            units = ORM_CMN_Unit.Query.Search(Connection, Transaction, new ORM_CMN_Unit.Query()
            {
                Tenant_RefID = securityTicket.TenantID
            }).ToArray();

            #endregion

            #region Assign/deassign units

            foreach (var unitToAssign in Parameter.AssignedUnits)
            {
                var unit = units.FirstOrDefault(u => u.ISOCode == unitToAssign.UnitIsoCode);
                if (unit == null)
                {
                    unit = new ORM_CMN_Unit();
                    unit.CMN_UnitID = Guid.NewGuid();
                    unit.Creation_Timestamp = DateTime.Now;
                    unit.IsDeleted = false;
                    unit.ISOCode = unitToAssign.UnitIsoCode;
                    unit.Label = unitToAssign.UnitLabel;
                    unit.Tenant_RefID = securityTicket.TenantID;
                    unit.Abbreviation = unitToAssign.UnitAbbrevation;

                    unit.Save(Connection, Transaction);
                }

                if (unit.IsDeleted == true)
                {
                    unit.IsDeleted = false;
                    unit.Save(Connection, Transaction);
                }
            }

            foreach (var unit in units.Where(u => u.IsDeleted == false))
            {
                var unitToAssign = Parameter.AssignedUnits.FirstOrDefault(uta => uta.UnitIsoCode == unit.ISOCode);
                if (unitToAssign == null)
                {
                    unit.IsDeleted = true;
                    unit.Save(Connection, Transaction);
                }
            }

            #endregion

            #region Set default unit for tenant

            // TODO: When Stefan Martinov changes database then it will be possible to make this change

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
        public static FR_Base Invoke(string ConnectionString, P_L3_AUTT_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L3_AUTT_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L3_AUTT_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L3_AUTT_0950 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Assign_Units_To_Tenant", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L3_AUTT_0950 for attribute P_L3_AUTT_0950
    [DataContract]
    public class P_L3_AUTT_0950
    {
        [DataMember]
        public P_L3_AUTT_0950a[] AssignedUnits { get; set; }

        //Standard type parameters
        [DataMember]
        public P_L3_AUTT_0950a DefaultUnit { get; set; }

    }
    #endregion
    #region SClass P_L3_AUTT_0950a for attribute AssignedUnits
    [DataContract]
    public class P_L3_AUTT_0950a
    {
        //Standard type parameters
        [DataMember]
        public string UnitIsoCode { get; set; }
        [DataMember]
        public Dict UnitLabel { get; set; }
        [DataMember]
        public Dict UnitAbbrevation { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Assign_Units_To_Tenant(,P_L3_AUTT_0950 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Assign_Units_To_Tenant.Invoke(connectionString,P_L3_AUTT_0950 Parameter,securityTicket);
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
var parameter = new CL3_Unit.Complex.Manipulation.P_L3_AUTT_0950();
parameter.AssignedUnits = ...;

parameter.DefaultUnit = ...;

*/
