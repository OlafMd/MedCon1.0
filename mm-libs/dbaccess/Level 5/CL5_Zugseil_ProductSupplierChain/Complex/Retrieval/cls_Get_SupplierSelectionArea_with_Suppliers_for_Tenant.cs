/* 
 * Generated on 2/19/2015 10:13:54 AM
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
using CL2_Supplier.Atomic.Retrieval;
using CL3_SupplierSelectionArea.Atomic.Retrieval;
using CL1_CMN_PRO;

namespace CL5_Zugseil_ProductSupplierChain.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_SupplierSelectionArea_with_Suppliers_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_SupplierSelectionArea_with_Suppliers_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PS_GSSAwSfT_1720 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PS_GSSAwSfT_1720 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5PS_GSSAwSfT_1720();

			//Put your code here
            L5PS_GSSAwSfT_1720 retVal = new L5PS_GSSAwSfT_1720();
            List<L5PS_GSSAwSfT_1720a> supplierSelectionAreaWithSuppliers = new List<L5PS_GSSAwSfT_1720a>();

            L2SP_GSfPaT_2351[] productSuppliers = new L2SP_GSfPaT_2351[0];

            #region Get Supplier Selection Areas

            var supplierSelectionAreasResult = cls_Get_SupplierSelectionAreas_for_Tenant.Invoke(Connection, Transaction, securityTicket);

            if (supplierSelectionAreasResult != null && supplierSelectionAreasResult.Result != null)
            {
                supplierSelectionAreaWithSuppliers.AddRange(supplierSelectionAreasResult.Result.Select(i => new L5PS_GSSAwSfT_1720a()
                {
                    SupplierID = Guid.Empty,
                    SupplierSelectionArea = i
                }).ToList());
            } 
            #endregion

            #region Get Product Suppliers
            P_L2SP_GSfPaT_2351 productSupplierParameter = new P_L2SP_GSfPaT_2351();
            productSupplierParameter.ProductID = Parameter.ProductID;
            var productSuppliersResult = cls_Get_Suppliers_for_Product_and_Tenant.Invoke(Connection, Transaction, productSupplierParameter, securityTicket);

            if (productSuppliersResult != null && productSuppliersResult.Result != null)
                productSuppliers = productSuppliersResult.Result;

            #endregion

            #region Get Supplier Area Bindings

            ORM_CMN_PRO_Product_SupplierAreaBinding.Query supplierAreaBindingQuery = new ORM_CMN_PRO_Product_SupplierAreaBinding.Query();
            supplierAreaBindingQuery.CMN_PRO_Product_RefID = Parameter.ProductID;
            supplierAreaBindingQuery.Tenant_RefID = securityTicket.TenantID;
            supplierAreaBindingQuery.IsDeleted = false;
            List<ORM_CMN_PRO_Product_SupplierAreaBinding> supplierAreaBindingList = ORM_CMN_PRO_Product_SupplierAreaBinding.Query.Search(Connection, Transaction, supplierAreaBindingQuery);

            foreach (var supplierArea in supplierAreaBindingList)
            {
                if (supplierArea.LOG_REG_SupplierSelectionArea_RefID == Guid.Empty)
                {
                    supplierSelectionAreaWithSuppliers.Add(new L5PS_GSSAwSfT_1720a()
                    {
                        SupplierID = supplierArea.CMN_BPT_Supplier_RefID,
                        SupplierSelectionArea = new L3SA_GSSAfT_1734()
                        {
                            LOG_REG_SupplierSelectionAreaID = Guid.Empty
                        }
                    });
                }
                else if (supplierSelectionAreaWithSuppliers.Any(i => i.SupplierSelectionArea.LOG_REG_SupplierSelectionAreaID == supplierArea.LOG_REG_SupplierSelectionArea_RefID)) 
                {
                    supplierSelectionAreaWithSuppliers
                        .First(i => i.SupplierSelectionArea.LOG_REG_SupplierSelectionAreaID == supplierArea.LOG_REG_SupplierSelectionArea_RefID)
                        .SupplierID = supplierArea.CMN_BPT_Supplier_RefID;
                }
            }

            #endregion

            retVal.SupplierSelectionAreaWithSuppliers = supplierSelectionAreaWithSuppliers.ToArray();
            retVal.Suppliers = productSuppliers;

            returnValue.Result = retVal;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PS_GSSAwSfT_1720 Invoke(string ConnectionString,P_L5PS_GSSAwSfT_1720 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PS_GSSAwSfT_1720 Invoke(DbConnection Connection,P_L5PS_GSSAwSfT_1720 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PS_GSSAwSfT_1720 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PS_GSSAwSfT_1720 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PS_GSSAwSfT_1720 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PS_GSSAwSfT_1720 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PS_GSSAwSfT_1720 functionReturn = new FR_L5PS_GSSAwSfT_1720();
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

				throw new Exception("Exception occured in method cls_Get_SupplierSelectionArea_with_Suppliers_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PS_GSSAwSfT_1720 : FR_Base
	{
		public L5PS_GSSAwSfT_1720 Result	{ get; set; }

		public FR_L5PS_GSSAwSfT_1720() : base() {}

		public FR_L5PS_GSSAwSfT_1720(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PS_GSSAwSfT_1720 for attribute P_L5PS_GSSAwSfT_1720
		[DataContract]
		public class P_L5PS_GSSAwSfT_1720 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5PS_GSSAwSfT_1720 for attribute L5PS_GSSAwSfT_1720
		[DataContract]
		public class L5PS_GSSAwSfT_1720 
		{
			[DataMember]
			public L5PS_GSSAwSfT_1720a[] SupplierSelectionAreaWithSuppliers { get; set; }

			//Standard type parameters
			[DataMember]
			public L2SP_GSfPaT_2351[] Suppliers { get; set; } 

		}
		#endregion
		#region SClass L5PS_GSSAwSfT_1720a for attribute SupplierSelectionAreaWithSuppliers
		[DataContract]
		public class L5PS_GSSAwSfT_1720a 
		{
			//Standard type parameters
			[DataMember]
			public L3SA_GSSAfT_1734 SupplierSelectionArea { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PS_GSSAwSfT_1720 cls_Get_SupplierSelectionArea_with_Suppliers_for_Tenant(,P_L5PS_GSSAwSfT_1720 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PS_GSSAwSfT_1720 invocationResult = cls_Get_SupplierSelectionArea_with_Suppliers_for_Tenant.Invoke(connectionString,P_L5PS_GSSAwSfT_1720 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_ProductSupplierChain.Complex.Retrieval.P_L5PS_GSSAwSfT_1720();
parameter.ProductID = ...;

*/
