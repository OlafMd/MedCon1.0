/* 
 * Generated on 11/14/2013 2:30:56 PM
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
using CL1_CMN_BPT_EMP;
using CL1_CMN;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_TypesOfSalary.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TypeOfSalary_For_SalaryTypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TypeOfSalary_For_SalaryTypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TS_GTOSFST_1427 Execute(DbConnection Connection,DbTransaction Transaction,P_L5TS_GTOSFST_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5TS_GTOSFST_1427();
            returnValue.Result = new L5TS_GTOSFST_1427();
            returnValue.Result.TypeOfSalary = new L5TS_GTOSFT_1419();

			//Put your code here
            if (Parameter.CMN_BPT_EMP_SalaryTypeID != Guid.Empty)
            {
                ORM_CMN_BPT_EMP_SalaryType.Query salaryTypeQuery = new ORM_CMN_BPT_EMP_SalaryType.Query();
                salaryTypeQuery.CMN_BPT_EMP_SalaryTypeID = Parameter.CMN_BPT_EMP_SalaryTypeID;
                salaryTypeQuery.Tenant_RefID = securityTicket.TenantID;
                salaryTypeQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_SalaryType> salaryTypesList = ORM_CMN_BPT_EMP_SalaryType.Query.Search(Connection, Transaction, salaryTypeQuery);

                if (salaryTypesList != null && salaryTypesList.Count > 0)
                {
                    L5TS_GTOSFT_1419 salaryType = new L5TS_GTOSFT_1419();
                    salaryType.CMN_BPT_EMP_SalaryTypeID = salaryTypesList[0].CMN_BPT_EMP_SalaryTypeID;
                    salaryType.GlobalPropertyMatchingID = salaryTypesList[0].GlobalPropertyMatchingID;
                    salaryType.SalaryType_Name = salaryTypesList[0].SalaryType_Name;
                    salaryType.SalaryTypeStatus = salaryTypesList[0].SalaryTypeStatus;
                    salaryType.Country_ISOCode_Alpha2 = Get_CountryISO_For_SalaryType(Connection, Transaction, securityTicket, salaryTypesList[0]);
                    returnValue.Result.TypeOfSalary = salaryType;
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

        #region
        private static string Get_CountryISO_For_SalaryType(DbConnection Connection, DbTransaction Transaction, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket, ORM_CMN_BPT_EMP_SalaryType salaryType)
        {
            string ISO = "";
            ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion salaryEconomicRegion;
            ORM_CMN_EconomicRegion economicRegion;
            FR_Base economicRegionRes;
            ORM_CMN_Country_2_EconomicRegion countryEconomicRegion;
            ORM_CMN_Country country;
            FR_Base countryRes;

            salaryEconomicRegion = ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query.Search(Connection, Transaction,
                    new ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query()
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        CMN_BPT_EMP_SalaryType_RefID = salaryType.CMN_BPT_EMP_SalaryTypeID
                    }).FirstOrDefault();

            if (salaryEconomicRegion == null)
                return "";

            economicRegion = new ORM_CMN_EconomicRegion();
            economicRegionRes = economicRegion.Load(Connection, Transaction, salaryEconomicRegion.CMN_EconomicRegion_RefID);

            if (economicRegionRes.Status != FR_Status.Success || economicRegion.CMN_EconomicRegionID == Guid.Empty)
                return "";

            countryEconomicRegion = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction,
                new ORM_CMN_Country_2_EconomicRegion.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    CMN_EconomicRegion_RefID = economicRegion.CMN_EconomicRegionID
                }).FirstOrDefault();

            if (countryEconomicRegion == null)
                return "";

            country = new ORM_CMN_Country();
            countryRes = country.Load(Connection, Transaction, countryEconomicRegion.CMN_Country_RefID);

            if (countryRes.Status != FR_Status.Success || country.CMN_CountryID == Guid.Empty)
                return "";

            ISO = country.Country_ISOCode_Alpha2;

            return ISO;
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TS_GTOSFST_1427 Invoke(string ConnectionString,P_L5TS_GTOSFST_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TS_GTOSFST_1427 Invoke(DbConnection Connection,P_L5TS_GTOSFST_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TS_GTOSFST_1427 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TS_GTOSFST_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TS_GTOSFST_1427 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TS_GTOSFST_1427 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TS_GTOSFST_1427 functionReturn = new FR_L5TS_GTOSFST_1427();
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
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TS_GTOSFST_1427 : FR_Base
	{
		public L5TS_GTOSFST_1427 Result	{ get; set; }

		public FR_L5TS_GTOSFST_1427() : base() {}

		public FR_L5TS_GTOSFST_1427(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TS_GTOSFST_1427 cls_Get_TypeOfSalary_For_SalaryTypeID(P_L5TS_GTOSFST_1427 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5TS_GTOSFST_1427 result = cls_Get_TypeOfSalary_For_SalaryTypeID.Invoke(connectionString,P_L5TS_GTOSFST_1427 Parameter,securityTicket);
	 return result;
}
*/