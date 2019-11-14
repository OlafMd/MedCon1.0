/* 
 * Generated on 27-Nov-13 10:36:47
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
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_TypesOfSalary.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TypesOfSalary_For_Country.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TypesOfSalary_For_Country
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TS_GTOSFC_1031 Execute(DbConnection Connection,DbTransaction Transaction,P_L5TS_GTOSFC_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5TS_GTOSFC_1031();
            returnValue.Result = new L5TS_GTOSFC_1031();

            L5TS_GTOSFT_1419[] allTypes = cls_Get_TypesOfSalery_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            ORM_CMN_Country.Query countryQuery = new ORM_CMN_Country.Query();
            countryQuery.Country_ISOCode_Alpha2 = Parameter.Country_ISO;
            countryQuery.IsDeleted = false;
            countryQuery.Tenant_RefID = securityTicket.TenantID;

            ORM_CMN_Country country = ORM_CMN_Country.Query.Search(Connection, Transaction, countryQuery).FirstOrDefault();

            ORM_CMN_Country_2_EconomicRegion.Query country2EconomicRegionQuery = new ORM_CMN_Country_2_EconomicRegion.Query();
            country2EconomicRegionQuery.CMN_Country_RefID = country.CMN_CountryID;
            country2EconomicRegionQuery.IsDeleted = false;
            country2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;

            ORM_CMN_Country_2_EconomicRegion country2EconomicRegion = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction, country2EconomicRegionQuery).FirstOrDefault();

            if (country2EconomicRegion == null)
                return returnValue;

            ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query salaryType2EconomicRegionQuery = new ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query();
            salaryType2EconomicRegionQuery.CMN_EconomicRegion_RefID = country2EconomicRegion.CMN_EconomicRegion_RefID;
            salaryType2EconomicRegionQuery.IsDeleted = false;
            salaryType2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;

            List<ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion> listOfSalaryType2EconomicRegion = ORM_CMN_BPT_EMP_SalaryType_2_EconomicRegion.Query.Search(Connection, Transaction, salaryType2EconomicRegionQuery);

            List<L5TS_GTOSFT_1419> resultTypes = new List<L5TS_GTOSFT_1419>();

            if (allTypes != null)
            {
                foreach (var salaryType2EconomicRegion in listOfSalaryType2EconomicRegion)
                {
                    resultTypes.Add(allTypes.FirstOrDefault(x => x.CMN_BPT_EMP_SalaryTypeID == salaryType2EconomicRegion.CMN_BPT_EMP_SalaryType_RefID));
                }
            }
            else
                return returnValue;

            returnValue.Result.TypesOfSalary = resultTypes.ToArray();

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TS_GTOSFC_1031 Invoke(string ConnectionString,P_L5TS_GTOSFC_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TS_GTOSFC_1031 Invoke(DbConnection Connection,P_L5TS_GTOSFC_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TS_GTOSFC_1031 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TS_GTOSFC_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TS_GTOSFC_1031 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TS_GTOSFC_1031 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TS_GTOSFC_1031 functionReturn = new FR_L5TS_GTOSFC_1031();
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
	public class FR_L5TS_GTOSFC_1031 : FR_Base
	{
		public L5TS_GTOSFC_1031 Result	{ get; set; }

		public FR_L5TS_GTOSFC_1031() : base() {}

		public FR_L5TS_GTOSFC_1031(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}
