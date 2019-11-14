/* 
 * Generated on 2/19/2015 9:45:20 AM
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
using CL2_Warehouse.Atomic.Retrieval;
using CL3_DistributionArea.Atomic.Retrieval;
using CL1_CMN_PRO;

namespace CL5_Zugseil_ProductDistribution.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_EconomicRegions_with_Warehouses_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EconomicRegions_with_Warehouses_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PD_GERwWfT_0955 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PD_GERwWfT_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PD_GERwWfT_0955();

			//Put your code here
            L5PD_GERwWfT_0955 retVal = new L5PD_GERwWfT_0955();
            List<L5PD_GERwWfT_0955a> distributionAreasWithWarehouses = new List<L5PD_GERwWfT_0955a>();

            L2WH_GWHfIoT_1442[] warehouses = new L2WH_GWHfIoT_1442[0];


            #region Get Distribution Areas

            var distributionAreaResult = cls_Get_DistributionAreas_for_Tenant.Invoke(Connection, Transaction, securityTicket);

            if (distributionAreaResult != null && distributionAreaResult.Result != null)
            {
                distributionAreasWithWarehouses.AddRange(distributionAreaResult.Result.Select(i => new L5PD_GERwWfT_0955a()
                {
                    DistributionArea = i,
                    WarehouseID = Guid.Empty
                }).ToList());
            }
            #endregion

            #region Get Warehouses

            P_L2WH_GWHfIoT_1442 warehousesParameter = new P_L2WH_GWHfIoT_1442();
            warehousesParameter.WarehouseID = null;
            var warehousesResult = cls_Get_Warehouse_for_ID_or_TenantID.Invoke(Connection, Transaction, warehousesParameter, securityTicket);

            if (warehousesResult != null && warehousesResult.Result != null)
                warehouses = warehousesResult.Result.OrderBy(i => i.Warehouse_Name).ToArray();

            #endregion

            #region Get Distribution Centers
            ORM_CMN_PRO_DistributionCenter.Query distributionCentersQuery = new ORM_CMN_PRO_DistributionCenter.Query();
            distributionCentersQuery.Product_RefID = Parameter.ProductID;
            distributionCentersQuery.Tenant_RefID = securityTicket.TenantID;
            distributionCentersQuery.IsDeleted = false;
            List<ORM_CMN_PRO_DistributionCenter> distributionCentersList = ORM_CMN_PRO_DistributionCenter.Query.Search(Connection, Transaction, distributionCentersQuery);

            foreach (var center in distributionCentersList)
            {
                if (center.LOG_REG_DistributionArea_RefID == Guid.Empty)
                {
                    distributionAreasWithWarehouses.Add(new L5PD_GERwWfT_0955a()
                    {
                        WarehouseID = center.Warehouse_RefID,
                        DistributionArea = new L3DA_GDAfT_1442()
                        {
                            LOG_REG_DistributionAreaID = Guid.Empty
                        }
                    });
                }
                else if (distributionAreasWithWarehouses.Any(i => i.DistributionArea.LOG_REG_DistributionAreaID == center.LOG_REG_DistributionArea_RefID))
                {
                    distributionAreasWithWarehouses
                        .First(i => i.DistributionArea.LOG_REG_DistributionAreaID == center.LOG_REG_DistributionArea_RefID)
                        .WarehouseID = center.Warehouse_RefID;
                }
            }

            #endregion

            retVal.DistributionAreasWithWarehouses = distributionAreasWithWarehouses.ToArray();
            retVal.Warehouses = warehouses;

            returnValue.Result = retVal;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PD_GERwWfT_0955 Invoke(string ConnectionString,P_L5PD_GERwWfT_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PD_GERwWfT_0955 Invoke(DbConnection Connection,P_L5PD_GERwWfT_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PD_GERwWfT_0955 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PD_GERwWfT_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PD_GERwWfT_0955 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PD_GERwWfT_0955 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PD_GERwWfT_0955 functionReturn = new FR_L5PD_GERwWfT_0955();
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

				throw new Exception("Exception occured in method cls_Get_EconomicRegions_with_Warehouses_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PD_GERwWfT_0955 : FR_Base
	{
		public L5PD_GERwWfT_0955 Result	{ get; set; }

		public FR_L5PD_GERwWfT_0955() : base() {}

		public FR_L5PD_GERwWfT_0955(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PD_GERwWfT_0955 for attribute P_L5PD_GERwWfT_0955
		[DataContract]
		public class P_L5PD_GERwWfT_0955 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5PD_GERwWfT_0955 for attribute L5PD_GERwWfT_0955
		[DataContract]
		public class L5PD_GERwWfT_0955 
		{
			[DataMember]
			public L5PD_GERwWfT_0955a[] DistributionAreasWithWarehouses { get; set; }

			//Standard type parameters
			[DataMember]
			public L2WH_GWHfIoT_1442[] Warehouses { get; set; } 

		}
		#endregion
		#region SClass L5PD_GERwWfT_0955a for attribute DistributionAreasWithWarehouses
		[DataContract]
		public class L5PD_GERwWfT_0955a 
		{
			//Standard type parameters
			[DataMember]
			public L3DA_GDAfT_1442 DistributionArea { get; set; } 
			[DataMember]
			public Guid WarehouseID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PD_GERwWfT_0955 cls_Get_EconomicRegions_with_Warehouses_for_Tenant(,P_L5PD_GERwWfT_0955 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PD_GERwWfT_0955 invocationResult = cls_Get_EconomicRegions_with_Warehouses_for_Tenant.Invoke(connectionString,P_L5PD_GERwWfT_0955 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_ProductDistribution.Complex.Retrieval.P_L5PD_GERwWfT_0955();
parameter.ProductID = ...;

*/
