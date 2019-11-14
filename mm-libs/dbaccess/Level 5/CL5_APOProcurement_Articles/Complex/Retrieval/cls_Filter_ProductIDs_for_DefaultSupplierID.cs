/* 
 * Generated on 10/16/2014 9:54:26 AM
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
using CL1_CMN_PRO;
using CL5_APOProcurement_Articles.Atomic.Retrieval;
using CL1_LOG_WRH;
using CL3_Supplier.Atomic.Retrieval;

namespace CL5_APOProcurement_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Filter_ProductIDs_for_DefaultSupplierID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Filter_ProductIDs_for_DefaultSupplierID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AR_FPfDS_1324_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AR_FPfDS_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5AR_FPfDS_1324_Array();
			
            /*  Explanation:
                    There are three levels of priority to retrieve a supplier for a product:
                        1. A supplier is assigned to a product in CMN_PRO_Product_Suppliers with CMN_PRO_Product_Suppliers.SupplierPriority = 1
                        2. A product is assigned to a LOG_WRH_QuantityLevels -> the supplier is retrieved by the default supplier of the corresponding storage level e.g. LOG_WRH_Rack_DefaultSuppliers
                        3. A product has neither 1. or 2. In that case retrieve the LOG_WRH_Area_DefaultSuppliers from the area with LOG_WRH_Areas.IsDefaultIntakeArea
             * */

            var result = new List<L5AR_FPfDS_1324>();
            var includeProducts = new List<Guid>();
            var excludeProducts = new List<Guid>();

            #region The first priority

            var productsSuppliersWithHighestPriority = ORM_CMN_PRO_Product_Supplier.Query.Search(Connection, Transaction,
            new ORM_CMN_PRO_Product_Supplier.Query()
            {
                SupplierPriority = 1,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            if(Parameter.SupplierID != null){
                includeProducts = productsSuppliersWithHighestPriority.Where(i => i.CMN_BPT_Supplier_RefID == Parameter.SupplierID).Select(i => i.CMN_PRO_Product_RefID).Intersect(Parameter.ProductIDList).ToList();
                excludeProducts = productsSuppliersWithHighestPriority.Where(i => i.CMN_BPT_Supplier_RefID != Parameter.SupplierID).Select(i => i.CMN_PRO_Product_RefID).Intersect(Parameter.ProductIDList).ToList();
            }
            else
            {
                includeProducts = productsSuppliersWithHighestPriority.Select(i=>i.CMN_PRO_Product_RefID).Intersect(Parameter.ProductIDList).ToList();
            }

            result = productsSuppliersWithHighestPriority.Where(i => includeProducts.Contains(i.CMN_PRO_Product_RefID)).Select(i => new L5AR_FPfDS_1324()
            {
                ProductID = i.CMN_PRO_Product_RefID,
                SupplierID = i.CMN_BPT_Supplier_RefID,
                SupplierName = String.Empty,
                PriorityLevel = 1
            }).ToList();

            //exclude already procesed elements
            Parameter.ProductIDList = Parameter.ProductIDList.Except(excludeProducts).ToArray();
            Parameter.ProductIDList = Parameter.ProductIDList.Except(includeProducts).ToArray();

            #endregion

            #region The second priority

            var param2 = new P_L5AR_FPfDSoQL_1410()
            {
                ProductIDList = Parameter.ProductIDList,
            };

            var defaultSuppliersOfQuantityLevels = cls_Filter_ProductIDs_for_DefaultSupplierOfQuantityLevels.Invoke(Connection, Transaction, param2, securityTicket).Result;

            if (defaultSuppliersOfQuantityLevels != null)
            {
                if (Parameter.SupplierID != null)
                {
                    includeProducts = defaultSuppliersOfQuantityLevels.Where(i => i.CMN_BPT_Supplier_RefID == Parameter.SupplierID).Select(i => i.Product_RefID).Intersect(Parameter.ProductIDList).ToList();
                    excludeProducts = defaultSuppliersOfQuantityLevels.Where(i => i.CMN_BPT_Supplier_RefID != Parameter.SupplierID).Select(i => i.Product_RefID).Intersect(Parameter.ProductIDList).ToList();
                }
                else
                {
                    includeProducts = defaultSuppliersOfQuantityLevels.Select(i => i.Product_RefID).Intersect(Parameter.ProductIDList).ToList();
                }

                result.AddRange(defaultSuppliersOfQuantityLevels.Where(i => includeProducts.Contains(i.Product_RefID)).Select(i => new L5AR_FPfDS_1324()
                {
                    ProductID = i.Product_RefID,
                    SupplierID = i.CMN_BPT_Supplier_RefID,
                    SupplierName = String.Empty,
                    PriorityLevel = 2
                }));

                //exclude already procesed elements
                Parameter.ProductIDList = Parameter.ProductIDList.Except(excludeProducts).ToArray();
                Parameter.ProductIDList = Parameter.ProductIDList.Except(includeProducts).ToArray();
            }

            #endregion

            #region The third priority

            var defaultIntakeArea = ORM_LOG_WRH_Area.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Area.Query()
            {
                IsDefaultIntakeArea = true,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (defaultIntakeArea != null) 
            {
                var defaultSupplierForIntakeArea = ORM_LOG_WRH_Area_DefaultSupplier.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Area_DefaultSupplier.Query()
                {
                    Area_RefID = defaultIntakeArea.LOG_WRH_AreaID,
                    IsDeleted = false,
                    CMN_BPT_Supplier_RefID = Parameter.SupplierID
                }).SingleOrDefault();

                if (defaultSupplierForIntakeArea != null) 
                {
                    includeProducts.AddRange(Parameter.ProductIDList);

                    result.AddRange(Parameter.ProductIDList.Select(i => new L5AR_FPfDS_1324()
                    {
                        ProductID = i,
                        SupplierID = defaultSupplierForIntakeArea.CMN_BPT_Supplier_RefID,
                        SupplierName = String.Empty,
                        PriorityLevel = 3
                    }));
                }
            }


            #endregion

            var suppliers = cls_Get_SuppliersDisplayNames_with_ID_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            foreach (var item in result) {
                item.SupplierName = suppliers.Where(i => i.CMN_BPT_SupplierID == item.SupplierID).Select(i => i.DisplayName).SingleOrDefault();
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
		public static FR_L5AR_FPfDS_1324_Array Invoke(string ConnectionString,P_L5AR_FPfDS_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AR_FPfDS_1324_Array Invoke(DbConnection Connection,P_L5AR_FPfDS_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AR_FPfDS_1324_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AR_FPfDS_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AR_FPfDS_1324_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AR_FPfDS_1324 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AR_FPfDS_1324_Array functionReturn = new FR_L5AR_FPfDS_1324_Array();
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

				throw new Exception("Exception occured in method cls_Filter_ProductIDs_for_DefaultSupplierID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AR_FPfDS_1324_Array : FR_Base
	{
		public L5AR_FPfDS_1324[] Result	{ get; set; } 
		public FR_L5AR_FPfDS_1324_Array() : base() {}

		public FR_L5AR_FPfDS_1324_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AR_FPfDS_1324 for attribute P_L5AR_FPfDS_1324
		[DataContract]
		public class P_L5AR_FPfDS_1324 
		{
			//Standard type parameters
			[DataMember]
			public Guid? SupplierID { get; set; } 
			[DataMember]
			public Guid[] ProductIDList { get; set; } 

		}
		#endregion
		#region SClass L5AR_FPfDS_1324 for attribute L5AR_FPfDS_1324
		[DataContract]
		public class L5AR_FPfDS_1324 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public int PriorityLevel { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AR_FPfDS_1324_Array cls_Filter_ProductIDs_for_DefaultSupplierID(,P_L5AR_FPfDS_1324 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AR_FPfDS_1324_Array invocationResult = cls_Filter_ProductIDs_for_DefaultSupplierID.Invoke(connectionString,P_L5AR_FPfDS_1324 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_Articles.Complex.Retrieval.P_L5AR_FPfDS_1324();
parameter.SupplierID = ...;
parameter.ProductIDList = ...;

*/
