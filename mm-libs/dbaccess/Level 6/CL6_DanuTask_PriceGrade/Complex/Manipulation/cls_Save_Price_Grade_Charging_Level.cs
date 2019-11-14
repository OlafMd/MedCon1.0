/* 
 * Generated on 11/11/2014 1:51:55 PM
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
using CL1_CMN_BPT;
using CL1_CMN_SLS;
using CL1_DOC;
using CL1_CMN_PRO;

namespace CL6_DanuTask_PriceGrade.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Price_Grade_Charging_Level.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Price_Grade_Charging_Level
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DTPG_SCL_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			
            var item = new ORM_CMN_BPT_InvestedWorkTime_ChargingLevel();

            #region Unnecessary

            if (Parameter.CMN_BPT_InvestedWorkTime_ChargingLevelID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.CMN_BPT_InvestedWorkTime_ChargingLevelID);

                if (result.Status != FR_Status.Success || item.CMN_BPT_InvestedWorkTime_ChargingLevelID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }


                if (Parameter.ChargingLevelName != null)
                    item.ChangingLevel_Name = Parameter.ChargingLevelName;

                item.Save(Connection, Transaction);

                ORM_CMN_SLS_Price.Query priceQuery = new ORM_CMN_SLS_Price.Query();
                priceQuery.Tenant_RefID = securityTicket.TenantID;
                priceQuery.IsDeleted = false;
                priceQuery.CMN_PRO_Product_RefID = item.CMN_PRO_Product_RefID;
                List<ORM_CMN_SLS_Price> prices = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, priceQuery);
                if (prices != null && prices.Count == 1)
                {
                    ORM_CMN_SLS_Price price = prices[0];
                    price.PriceAmount = Parameter.PricePerMinute;
                    price.CMN_Currency_RefID = Parameter.CurrencyID;
                    price.Save(Connection, Transaction);

                }

            }

            else
            {
                var structureHeader = new ORM_DOC_Structure_Header();
                structureHeader.Label = "document_header_for_product";
                structureHeader.Tenant_RefID = securityTicket.TenantID;
                var structureStatusSave = structureHeader.Save(Connection, Transaction);

                ORM_CMN_PRO_Product product = new ORM_CMN_PRO_Product();
                product.Product_Name = Parameter.ChargingLevelName;
                product.Product_DocumentationStructure_RefID = structureHeader.DOC_Structure_HeaderID;
                product.Product_Number = "product_number";
                product.Tenant_RefID = securityTicket.TenantID;

                product.Save(Connection, Transaction);

                ORM_CMN_BPT_InvestedWorkTime_ChargingLevel charginglevel = new ORM_CMN_BPT_InvestedWorkTime_ChargingLevel();
                charginglevel.ChangingLevel_Name = Parameter.ChargingLevelName;
                charginglevel.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                charginglevel.Tenant_RefID = securityTicket.TenantID;

                charginglevel.Save(Connection, Transaction);

                ORM_CMN_SLS_Price price = new ORM_CMN_SLS_Price();
                price.CMN_Currency_RefID = Parameter.CurrencyID;
                price.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                price.PriceAmount = Parameter.PricePerMinute;
                price.Tenant_RefID = securityTicket.TenantID;

                price.Save(Connection, Transaction);
            }

            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DTPG_SCL_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DTPG_SCL_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DTPG_SCL_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DTPG_SCL_1016 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Price_Grade_Charging_Level",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DTPG_SCL_1016 for attribute P_L6DTPG_SCL_1016
		[DataContract]
		public class P_L6DTPG_SCL_1016 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_InvestedWorkTime_ChargingLevelID { get; set; } 
			[DataMember]
			public Dict ChargingLevelName { get; set; } 
			[DataMember]
			public Decimal PricePerMinute { get; set; } 
			[DataMember]
			public Guid CurrencyID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Price_Grade_Charging_Level(,P_L6DTPG_SCL_1016 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Price_Grade_Charging_Level.Invoke(connectionString,P_L6DTPG_SCL_1016 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_PriceGrade.Complex.Manipulation.P_L6DTPG_SCL_1016();
parameter.CMN_BPT_InvestedWorkTime_ChargingLevelID = ...;
parameter.ChargingLevelName = ...;
parameter.PricePerMinute = ...;
parameter.CurrencyID = ...;
parameter.IsDeleted = ...;

*/
