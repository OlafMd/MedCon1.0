/* 
 * Generated on 18/10/2014 04:11:14
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
using CL2_Warehouse.Complex.Manipulation;
using CL2_Address.Atomic.Manipulation;
using CL1_LOG_WRH;
using CL1_CMN_PRO;

namespace CL5_Zugseil_Warehouse.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Warehouse_with_BillingAddress_and_DeliveryAddress.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Warehouse_with_BillingAddress_and_DeliveryAddress
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5WH_SWwBAaDA_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            //  Create delivery address for warehouse
            Guid deliveryAddressID = Guid.Empty;
            if (Parameter.SaveDeliveryAddressParam.City_Name != null && Parameter.SaveDeliveryAddressParam.City_Name != String.Empty)
            {
                deliveryAddressID = cls_Save_Address.Invoke(Connection, Transaction, Parameter.SaveDeliveryAddressParam, securityTicket).Result;
                Parameter.SaveWarehouseParam.DeliveryAddress_RefID = deliveryAddressID;
            }

            //  Create warehouse
            if (Parameter.SaveWarehouseParam.IsDefaultShipmentWarehouse)
            {
                var defaultWarehouseParam = new ORM_LOG_WRH_Warehouse.Query() { IsDefaultShipmentWarehouse = true, Tenant_RefID = securityTicket.TenantID, IsDeleted=false };
                var defaultWarehouses = ORM_LOG_WRH_Warehouse.Query.Search(Connection, Transaction, defaultWarehouseParam);

                if (defaultWarehouses != null && defaultWarehouses.Count > 0)
                {
                    foreach (var defaultWH in defaultWarehouses)
                    {
                        defaultWH.IsDefaultShipmentWarehouse = false;
                        defaultWH.Save(Connection, Transaction);
                    } 
                }
            }
            var savedWarehouseID = cls_Save_Warehouse.Invoke(Connection, Transaction, Parameter.SaveWarehouseParam, securityTicket).Result;

            if (Parameter.SaveWarehouseParam.IsDeleted)
            {
                ORM_CMN_PRO_DistributionCenter.Query distributionCentersQuery = new ORM_CMN_PRO_DistributionCenter.Query();
                distributionCentersQuery.Warehouse_RefID = savedWarehouseID;
                distributionCentersQuery.Tenant_RefID = securityTicket.TenantID;
                distributionCentersQuery.IsDeleted = false;
                List<ORM_CMN_PRO_DistributionCenter> distributionCentersList = ORM_CMN_PRO_DistributionCenter.Query.Search(Connection, Transaction, distributionCentersQuery);

                foreach (var distributionCenter in distributionCentersList)
                {
                    distributionCenter.IsDeleted = true;
                    distributionCenter.Save(Connection, Transaction);
                }
            }

            returnValue.Result = savedWarehouseID;

            return returnValue;
            #endregion UserCode
        }
        #endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5WH_SWwBAaDA_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5WH_SWwBAaDA_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5WH_SWwBAaDA_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5WH_SWwBAaDA_1608 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Warehouse_with_BillingAddress_and_DeliveryAddress",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5WH_SWwBAaDA_1608 for attribute P_L5WH_SWwBAaDA_1608
		[DataContract]
		public class P_L5WH_SWwBAaDA_1608 
		{
			//Standard type parameters
			[DataMember]
			public P_L2WH_SWH_1339 SaveWarehouseParam { get; set; } 
			[DataMember]
			public P_L2AD_SA_1755 SaveDeliveryAddressParam { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Warehouse_with_BillingAddress_and_DeliveryAddress(,P_L5WH_SWwBAaDA_1608 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Warehouse_with_BillingAddress_and_DeliveryAddress.Invoke(connectionString,P_L5WH_SWwBAaDA_1608 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Warehouse.Complex.Manipulation.P_L5WH_SWwBAaDA_1608();
parameter.SaveWarehouseParam = ...;
parameter.SaveDeliveryAddressParam = ...;

*/
