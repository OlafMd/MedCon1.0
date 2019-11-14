/* 
 * Generated on 12/16/2013 3:02:09 PM
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
using CL3_EconomicRegion.Atomic.Manipulation;
using CL1_CMN;
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_TypesOfSalary.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_TypesOfSalary.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_TypesOfSalary
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5TS_STS_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

			//Put your code here
            var type = new ORM_CMN_BPT_EMP_SalaryType();
            if (Parameter.CMN_BPT_EMP_SalaryTypeID != Guid.Empty)
            {
                var result = type.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_SalaryTypeID);
                if (result.Status != FR_Status.Success || type.CMN_BPT_EMP_SalaryTypeID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }

            type.SalaryType_Name = Parameter.SalaryType_Name;
            type.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
            type.SalaryTypeStatus = Parameter.SalaryTypeStatus;
            type.Tenant_RefID = securityTicket.TenantID;
            type.Save(Connection, Transaction);

            returnValue.Result = type.CMN_BPT_EMP_SalaryTypeID;

            if (Parameter.Country_ISO != "")
            {

                ORM_CMN_Country.Query countryQuery = new ORM_CMN_Country.Query();
                countryQuery.Country_ISOCode_Alpha2 = Parameter.Country_ISO;
                countryQuery.Tenant_RefID = securityTicket.TenantID;
                countryQuery.IsDeleted = false;

                ORM_CMN_Country country = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery).FirstOrDefault();

                ORM_CMN_Country_2_EconomicRegion.Query country2EconomicRegionQuery = new ORM_CMN_Country_2_EconomicRegion.Query();
                country2EconomicRegionQuery.CMN_Country_RefID = country.CMN_CountryID;
                country2EconomicRegionQuery.IsDeleted = false;
                country2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;

                List<ORM_CMN_Country_2_EconomicRegion> country2EconomicRegion = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction, country2EconomicRegionQuery);

                Guid economicRegionID;

                if (country2EconomicRegion.Count == 0)
                {
                    P_L3ER_SERAC_1621 param = new P_L3ER_SERAC_1621();
                    param.Country_ISO = Parameter.Country_ISO;
                    economicRegionID = cls_Save_EconomicRegion_As_Country.Invoke(Connection, Transaction, param, securityTicket).Result;
                }
                else
                    economicRegionID = country2EconomicRegion.FirstOrDefault().CMN_EconomicRegion_RefID;

                if (Parameter.CMN_BPT_EMP_SalaryTypeID != Guid.Empty)
                {
                    ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query salaryType2EconomicRegionQuery = new ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query();
                    salaryType2EconomicRegionQuery.CMN_BPT_EMP_SalaryType_RefID = type.CMN_BPT_EMP_SalaryTypeID;
                    salaryType2EconomicRegionQuery.CMN_EconomicRegion_RefID = economicRegionID;
                    salaryType2EconomicRegionQuery.IsDeleted = false;
                    salaryType2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;

                    var existingSalaryType2EconomicRegion = ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query.Search(Connection, Transaction, salaryType2EconomicRegionQuery).FirstOrDefault();

                    if (existingSalaryType2EconomicRegion != null)
                    {
                        existingSalaryType2EconomicRegion.SalaryType_Code = Parameter.SalaryType_Code;
                        existingSalaryType2EconomicRegion.Save(Connection, Transaction);
                    }
                    else
                    {
                        ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion salaryType2EconomicRegion = new ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion();
                        salaryType2EconomicRegion.CMN_BPT_EMP_SalaryType_RefID = type.CMN_BPT_EMP_SalaryTypeID;
                        salaryType2EconomicRegion.CMN_EconomicRegion_RefID = economicRegionID;
                        salaryType2EconomicRegion.SalaryType_Code = Parameter.SalaryType_Code;
                        salaryType2EconomicRegion.Tenant_RefID = securityTicket.TenantID;
                        salaryType2EconomicRegion.Save(Connection, Transaction);
                    }
                }
                else
                {
                    ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion salaryType2EconomicRegion = new ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion();
                    salaryType2EconomicRegion.CMN_BPT_EMP_SalaryType_RefID = type.CMN_BPT_EMP_SalaryTypeID;
                    salaryType2EconomicRegion.CMN_EconomicRegion_RefID = economicRegionID;
                    salaryType2EconomicRegion.SalaryType_Code = Parameter.SalaryType_Code;
                    salaryType2EconomicRegion.Tenant_RefID = securityTicket.TenantID;
                    salaryType2EconomicRegion.Save(Connection, Transaction);
                }

                
            }
            else if (Parameter.CMN_BPT_EMP_SalaryTypeID != Guid.Empty)
            {
                ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query salaryType2EconomicRegionQuery = new ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query();
                salaryType2EconomicRegionQuery.CMN_BPT_EMP_SalaryType_RefID = type.CMN_BPT_EMP_SalaryTypeID;
                salaryType2EconomicRegionQuery.IsDeleted = false;
                salaryType2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;

                var existingSalaryType2EconomicRegion = ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query.Search(Connection, Transaction, salaryType2EconomicRegionQuery).FirstOrDefault();

                if (existingSalaryType2EconomicRegion != null)
                {
                    existingSalaryType2EconomicRegion.SalaryType_Code = Parameter.SalaryType_Code;
                    existingSalaryType2EconomicRegion.Save(Connection, Transaction);
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5TS_STS_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5TS_STS_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TS_STS_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TS_STS_1503 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Save_TypesOfSalary",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_TypesOfSalary(,P_L5TS_STS_1503 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_TypesOfSalary.Invoke(connectionString,P_L5TS_STS_1503 Parameter,securityTicket);
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
var parameter = new CL5_Plannico_TypesOfSalary.Atomic.Manipulation.P_L5TS_STS_1503();
parameter.CMN_BPT_EMP_SalaryTypeID = ...;
parameter.GlobalPropertyMatchingID = ...;
parameter.SalaryType_Name = ...;
parameter.Country_ISO = ...;
parameter.SalaryType_Code = ...;
parameter.SalaryTypeStatus = ...;

*/