/* 
 * Generated on 2/19/2015 11:55:13 AM
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

namespace CL5_Zugseil_ProductSupplierChain.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_SupplierSelectionAreaBindings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_SupplierSelectionAreaBindings
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5PS_SSSAB_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();

			//Put your code here
            ORM_CMN_PRO_Product_SupplierAreaBinding.Query supplierAreaBindingQuery = new ORM_CMN_PRO_Product_SupplierAreaBinding.Query();
            supplierAreaBindingQuery.CMN_PRO_Product_RefID = Parameter.ProductID;
            supplierAreaBindingQuery.Tenant_RefID = securityTicket.TenantID;
            supplierAreaBindingQuery.IsDeleted = false;
            List<ORM_CMN_PRO_Product_SupplierAreaBinding> supplierAreaBindingList = ORM_CMN_PRO_Product_SupplierAreaBinding.Query.Search(Connection, Transaction, supplierAreaBindingQuery);

            ORM_CMN_PRO_Product_SupplierAreaBinding supplierBinding;
            foreach (var binding in Parameter.SupplierSelectionAreasWithSuppliers)
            {
                if (supplierAreaBindingList.Any(i => i.LOG_REG_SupplierSelectionArea_RefID == binding.SupplierSelectionAreaID))
                {
                    // edit
                    supplierBinding = supplierAreaBindingList.First(i => i.LOG_REG_SupplierSelectionArea_RefID == binding.SupplierSelectionAreaID);

                    if (binding.SupplierID == Guid.Empty)
                    {
                        supplierBinding.Remove(Connection, Transaction);
                        continue;
                    }

                    supplierBinding.CMN_BPT_Supplier_RefID = binding.SupplierID;
                    supplierBinding.Save(Connection, Transaction);
                }
                else
                {
                    if (binding.SupplierID == Guid.Empty)
                        continue;

                    // create new 
                    supplierBinding = new ORM_CMN_PRO_Product_SupplierAreaBinding();
                    supplierBinding.CMN_BPT_Supplier_RefID = binding.SupplierID;
                    supplierBinding.CMN_PRO_Product_RefID = Parameter.ProductID;
                    supplierBinding.Tenant_RefID = securityTicket.TenantID;
                    supplierBinding.LOG_REG_SupplierSelectionArea_RefID = binding.SupplierSelectionAreaID;
                    supplierBinding.IsDefault_ProductSupplier = binding.SupplierSelectionAreaID == Guid.Empty;
                    supplierBinding.Save(Connection, Transaction);

                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5PS_SSSAB_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5PS_SSSAB_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PS_SSSAB_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PS_SSSAB_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Save_SupplierSelectionAreaBindings",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PS_SSSAB_1148 for attribute P_L5PS_SSSAB_1148
		[DataContract]
		public class P_L5PS_SSSAB_1148 
		{
			[DataMember]
			public P_L5PS_SSSAB_1148a[] SupplierSelectionAreasWithSuppliers { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass P_L5PS_SSSAB_1148a for attribute SupplierSelectionAreasWithSuppliers
		[DataContract]
		public class P_L5PS_SSSAB_1148a 
		{
			//Standard type parameters
			[DataMember]
			public Guid SupplierSelectionAreaID { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_SupplierSelectionAreaBindings(,P_L5PS_SSSAB_1148 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_SupplierSelectionAreaBindings.Invoke(connectionString,P_L5PS_SSSAB_1148 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_ProductSupplierChain.Complex.Manipulation.P_L5PS_SSSAB_1148();
parameter.SupplierSelectionAreasWithSuppliers = ...;

parameter.ProductID = ...;

*/
