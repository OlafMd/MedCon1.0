/* 
 * Generated on 5/20/2014 2:40:56 PM
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
using CL2_Language.Atomic.Retrieval;
using CL1_CMN;
using CL3_Taxes.Atomic.Retrieval;
using CL1_ACC_TAX;
using CL2_Country.Atomic.Retrieval;

namespace CL3_Taxes.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Taxes_for_DefaultCountry_and_ReturnResult.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Taxes_for_DefaultCountry_and_ReturnResult
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3TX_STfDCaRR_1119_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3TX_STfDCaRR_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3TX_STfDCaRR_1119_Array();

            var DBLanguages = cls_Get_All_Languages.Invoke(Connection, Transaction, securityTicket).Result.ToList();

            var defaultCountryISOCode = cls_Get_DefaultCountryISOCode_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            var defaultCountry = CL1_CMN.ORM_CMN_Country.Query.Search(Connection, Transaction,
            new ORM_CMN_Country.Query
            {
                Country_ISOCode_Alpha2 = defaultCountryISOCode.Country_639_1_ISOCode,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            var param = new P_L3TX_GTfCICaT_1359();
            param.CountryISOCode = defaultCountryISOCode.Country_639_1_ISOCode;
            var taxes = cls_Get_Taxes_for_CountryISOCode_and_TenantID.Invoke(Connection, Transaction, param, securityTicket).Result;

            var result = new List<L3TX_STfDCaRR_1119>();
            foreach (var taxRate in Parameter.TaxRates)
            {
                var tax = taxes.Where(i => i.TaxRate == taxRate).SingleOrDefault();

                if (tax == default(L3TX_GTfCICaT_1359))
                {
                    var saveTaxParam = new P_L3TX_STX_1119();
                    saveTaxParam.ACC_TAX_TaxeID = Guid.Empty;
                    saveTaxParam.EconomicRegion_RefID = Guid.Empty;
                    saveTaxParam.Country_RefID = defaultCountry.CMN_CountryID;
                    saveTaxParam.TaxRate = taxRate;
                    saveTaxParam.TaxName = new Dict(ORM_ACC_TAX_Tax.TableName);
                    foreach (var language in DBLanguages)
                    {
                        saveTaxParam.TaxName.AddEntry(language.CMN_LanguageID, taxRate.ToString());
                    }

                    var saveTaxResult = cls_Save_Tax.Invoke(Connection, Transaction, saveTaxParam, securityTicket).Result;

                    result.Add(new L3TX_STfDCaRR_1119()
                    {
                        TaxID = saveTaxResult,
                        TaxRate = taxRate
                    });
                }
                else 
                {
                    result.Add(new L3TX_STfDCaRR_1119()
                    {
                        TaxID = tax.ACC_TAX_TaxeID,
                        TaxRate = tax.TaxRate
                    });
                }
            }

            returnValue.Result = result.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3TX_STfDCaRR_1119_Array Invoke(string ConnectionString,P_L3TX_STfDCaRR_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3TX_STfDCaRR_1119_Array Invoke(DbConnection Connection,P_L3TX_STfDCaRR_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3TX_STfDCaRR_1119_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TX_STfDCaRR_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3TX_STfDCaRR_1119_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TX_STfDCaRR_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3TX_STfDCaRR_1119_Array functionReturn = new FR_L3TX_STfDCaRR_1119_Array();
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

				throw new Exception("Exception occured in method cls_Save_Taxes_for_DefaultCountry_and_ReturnResult",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3TX_STfDCaRR_1119_Array : FR_Base
	{
		public L3TX_STfDCaRR_1119[] Result	{ get; set; } 
		public FR_L3TX_STfDCaRR_1119_Array() : base() {}

		public FR_L3TX_STfDCaRR_1119_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3TX_STfDCaRR_1119 for attribute P_L3TX_STfDCaRR_1119
		[DataContract]
		public class P_L3TX_STfDCaRR_1119 
		{
			//Standard type parameters
			[DataMember]
			public double[] TaxRates { get; set; } 

		}
		#endregion
		#region SClass L3TX_STfDCaRR_1119 for attribute L3TX_STfDCaRR_1119
		[DataContract]
		public class L3TX_STfDCaRR_1119 
		{
			//Standard type parameters
			[DataMember]
			public Guid TaxID { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3TX_STfDCaRR_1119_Array cls_Save_Taxes_for_DefaultCountry_and_ReturnResult(,P_L3TX_STfDCaRR_1119 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3TX_STfDCaRR_1119_Array invocationResult = cls_Save_Taxes_for_DefaultCountry_and_ReturnResult.Invoke(connectionString,P_L3TX_STfDCaRR_1119 Parameter,securityTicket);
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
var parameter = new CL3_Taxes.Atomic.Manipulation.P_L3TX_STfDCaRR_1119();
parameter.TaxRates = ...;

*/
