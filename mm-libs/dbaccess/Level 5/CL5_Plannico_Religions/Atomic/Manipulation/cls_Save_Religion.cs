/* 
 * Generated on 3/3/2014 1:47:01 PM
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
using CL1_CMN_PER;
using CL1_CMN;
using CL3_EconomicRegion.Atomic.Manipulation;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_Religions.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Religion.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Religion
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5RL_SR_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var item = new ORM_CMN_PER_Religion();
            if (Parameter.CMN_PER_ReligionID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_PER_ReligionID);
                if (result.Status != FR_Status.Success || item.CMN_PER_ReligionID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            item.Religion_Name = Parameter.Religion_Name;
            item.GlobalPropertyMatchingID = Parameter.GlobalPropertyMatchingID;
            item.Tenant_RefID = securityTicket.TenantID;
            item.Save(Connection, Transaction);
            returnValue.Result = item.CMN_PER_ReligionID;

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

                if (Parameter.CMN_PER_ReligionID != Guid.Empty)
                {
                    ORM_CMN_PER_Religion_2_EconomicRegion.Query religion2EconomicRegionQuery = new ORM_CMN_PER_Religion_2_EconomicRegion.Query();
                    religion2EconomicRegionQuery.CMN_EconomicRegion_RefID = economicRegionID; 
                    religion2EconomicRegionQuery.CMN_PER_Religion_RefID = item.CMN_PER_ReligionID;
                    religion2EconomicRegionQuery.IsDeleted = false;
                    religion2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;
                    
                    var existingReligion2EconomicRegion = ORM_CMN_PER_Religion_2_EconomicRegion.Query.Search(Connection, Transaction, religion2EconomicRegionQuery).FirstOrDefault();

                    if (existingReligion2EconomicRegion != null)
                    {
                        existingReligion2EconomicRegion.Religion_Code = Parameter.Religion_Code;
                        existingReligion2EconomicRegion.Save(Connection, Transaction);
                    }
                    else
                    {
                        ORM_CMN_PER_Religion_2_EconomicRegion religion2EconomicRegion = new ORM_CMN_PER_Religion_2_EconomicRegion();
                        religion2EconomicRegion.CMN_EconomicRegion_RefID = economicRegionID;
                        religion2EconomicRegion.CMN_PER_Religion_RefID = item.CMN_PER_ReligionID;
                        religion2EconomicRegion.Religion_Code = Parameter.Religion_Code;
                        religion2EconomicRegion.Tenant_RefID = securityTicket.TenantID;
                        religion2EconomicRegion.Save(Connection, Transaction);
                    }
                }
                else
                {
                    ORM_CMN_PER_Religion_2_EconomicRegion religion2EconomicRegion = new ORM_CMN_PER_Religion_2_EconomicRegion();
                    religion2EconomicRegion.CMN_EconomicRegion_RefID = economicRegionID;
                    religion2EconomicRegion.CMN_PER_Religion_RefID = item.CMN_PER_ReligionID;
                    religion2EconomicRegion.Religion_Code = Parameter.Religion_Code;
                    religion2EconomicRegion.Tenant_RefID = securityTicket.TenantID;
                    religion2EconomicRegion.Save(Connection, Transaction);
                }


            }
            else if (Parameter.CMN_PER_ReligionID != Guid.Empty)
            {
                ORM_CMN_PER_Religion_2_EconomicRegion.Query religion2EconomicRegionQuery = new ORM_CMN_PER_Religion_2_EconomicRegion.Query();
                religion2EconomicRegionQuery.CMN_PER_Religion_RefID = item.CMN_PER_ReligionID;
                religion2EconomicRegionQuery.IsDeleted = false;
                religion2EconomicRegionQuery.Tenant_RefID = securityTicket.TenantID;

                var existingReligion2EconomicRegion = ORM_CMN_PER_Religion_2_EconomicRegion.Query.Search(Connection, Transaction, religion2EconomicRegionQuery).FirstOrDefault();

                if (existingReligion2EconomicRegion != null)
                {
                    existingReligion2EconomicRegion.Religion_Code = Parameter.Religion_Code;
                    existingReligion2EconomicRegion.Save(Connection, Transaction);
                }
            }



			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5RL_SR_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5RL_SR_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RL_SR_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RL_SR_0941 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
				throw ex;
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
FR_Guid cls_Save_Religion(P_L5RL_SR_0941 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_Religion.Invoke(connectionString,P_L5RL_SR_0941 Parameter,securityTicket);
	 return result;
}
*/