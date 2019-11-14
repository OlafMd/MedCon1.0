/* 
 * Generated on 15/10/2013 02:07:38
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL1_CMN;
using CL1_ACC_TAX;

namespace CL3_Taxes.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Tax.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Tax
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3TX_STX_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();

            // Set Economic region
            if (Parameter.EconomicRegion_RefID == Guid.Empty)
            {
                var countryRegion = ORM_CMN_Country_2_EconomicRegion.Query.Search(Connection, Transaction,
                    new ORM_CMN_Country_2_EconomicRegion.Query { IsDeleted = false, CMN_Country_RefID = Parameter.Country_RefID }).SingleOrDefault();

                if (countryRegion == null)
                {
                    var country = new ORM_CMN_Country();
                    country.Load(Connection, Transaction, Parameter.Country_RefID);
                    var region = new ORM_CMN_EconomicRegion();
                    region.EconomicRegion_Name = new Dict() { DictionaryID = Guid.NewGuid() };
                    region.Tenant_RefID = country.Tenant_RefID;
                    region.IsEconomicRegionCountry = true;
                    foreach (var content in country.Country_Name.Contents)
                    {
                        region.EconomicRegion_Name.AddEntry(content.LanguageID, content.Content);
                    }
                    region.Save(Connection, Transaction);
                    countryRegion = new ORM_CMN_Country_2_EconomicRegion();
                    countryRegion.CMN_EconomicRegion_RefID = region.CMN_EconomicRegionID;
                    countryRegion.CMN_Country_RefID = country.CMN_CountryID;
                    countryRegion.Tenant_RefID = country.Tenant_RefID;
                    countryRegion.Save(Connection, Transaction);
                }

                Parameter.EconomicRegion_RefID = countryRegion.CMN_EconomicRegion_RefID;
            }

            var item = new ORM_ACC_TAX_Tax();
            if (Parameter.ACC_TAX_TaxeID != Guid.Empty)
            {
                item.Load(Connection, Transaction, Parameter.ACC_TAX_TaxeID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.ACC_TAX_TaxeID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.ACC_TAX_TaxeID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.EconomicRegion_RefID = Parameter.EconomicRegion_RefID;
            item.TaxName = Parameter.TaxName;
            item.TaxRate = Parameter.TaxRate;

            return new FR_Guid(item.Save(Connection, Transaction), item.ACC_TAX_TaxeID);
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3TX_STX_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3TX_STX_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3TX_STX_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3TX_STX_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Tax",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3TX_STX_1119 for attribute P_L3TX_STX_1119
		[DataContract]
		public class P_L3TX_STX_1119 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_TAX_TaxeID { get; set; } 
			[DataMember]
			public Guid EconomicRegion_RefID { get; set; } 
			[DataMember]
			public Guid Country_RefID { get; set; } 
			[DataMember]
			public Dict TaxName { get; set; } 
			[DataMember]
			public double TaxRate { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Tax(,P_L3TX_STX_1119 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Tax.Invoke(connectionString,P_L3TX_STX_1119 Parameter,securityTicket);
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
var parameter = new CL3_Taxes.Atomic.Manipulation.P_L3TX_STX_1119();
parameter.ACC_TAX_TaxeID = ...;
parameter.EconomicRegion_RefID = ...;
parameter.Country_RefID = ...;
parameter.TaxName = ...;
parameter.TaxRate = ...;
parameter.IsDeleted = ...;

*/
