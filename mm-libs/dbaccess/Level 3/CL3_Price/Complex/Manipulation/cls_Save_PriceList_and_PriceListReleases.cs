/* 
 * Generated on 12/23/2014 11:00:23
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
using CL2_Price.Atomic.Manipulation;
using CL2_Tenant.Atomic.Manipulation;

namespace CL3_Price.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PriceList_and_PriceListReleases.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PriceList_and_PriceListReleases
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PL_SPLaPLR_2050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Base();
            FR_Base saveStatus = new FR_Base();
            #region Save Price List

            P_L2PL_SP_1407 parameterPriceList = Parameter.PriceList;

            var savingStatus = cls_Save_CMN_SLS_Pricelist.Invoke(Connection, Transaction, parameterPriceList, securityTicket);
            var priceListID=savingStatus.Result;
            if (Parameter.IsDefaultPriceList == true)
            {
                P_L2_ST_1149 tenantParameter = new P_L2_ST_1149();
                tenantParameter.CMN_TenantID = securityTicket.TenantID;
                tenantParameter.Customers_DefaultPricelist_RefID = priceListID;
                savingStatus = cls_Save_CMN_Tenant.Invoke(Connection, Transaction, tenantParameter, securityTicket);
            }
            #endregion
            if (saveStatus.Status == FR_Status.Success)
            {
                foreach (var parameterPriceListRelease in Parameter.PriceListReleasesList.ToList())
                {
                    parameterPriceListRelease.Pricelist_RefID = priceListID;
                    saveStatus = cls_Save_CMN_SLS_Pricelist_Release.Invoke(Connection, Transaction, parameterPriceListRelease, securityTicket);

                }
            }
            returnValue = saveStatus;



            return savingStatus;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PL_SPLaPLR_2050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PL_SPLaPLR_2050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PL_SPLaPLR_2050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PL_SPLaPLR_2050 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_PriceList_and_PriceListReleases",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PL_SPLaPLR_2050 for attribute P_L3PL_SPLaPLR_2050
		[DataContract]
		public class P_L3PL_SPLaPLR_2050 
		{
			//Standard type parameters
			[DataMember]
			public P_L2PL_SP_1407 PriceList { get; set; } 
			[DataMember]
			public P_L2PL_SPR_1629[] PriceListReleasesList { get; set; } 
			[DataMember]
			public bool IsDefaultPriceList { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_PriceList_and_PriceListReleases(,P_L3PL_SPLaPLR_2050 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_PriceList_and_PriceListReleases.Invoke(connectionString,P_L3PL_SPLaPLR_2050 Parameter,securityTicket);
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
var parameter = new CL3_Price.Complex.Manipulation.P_L3PL_SPLaPLR_2050();
parameter.PriceList = ...;
parameter.PriceListReleasesList = ...;
parameter.IsDefaultPriceList = ...;

*/
