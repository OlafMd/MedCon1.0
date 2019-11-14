/* 
 * Generated on 1/29/2015 00:15:06
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
using CL1_CMN_PRO_ASS;

namespace CL3_Assortment.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Assortment_Vendor_Products.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Assortment_Vendor_Products
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3AS_SAVP_0004[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();
            foreach (var vendorProduct in Parameter)
            {
                ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct vendorProductToCreateUpdate = new ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct();
                var vendorProductExists = ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query.Exists(Connection, Transaction, new ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query()
                {
                    CMN_PRO_ASS_AssortmentProduct_VendorProductID = vendorProduct.AssortmentVendorProductID
                });
                if (vendorProduct.AssortmentVendorProductID == Guid.Empty)
                    vendorProductExists = false;
                if (vendorProductExists)
                    vendorProductToCreateUpdate.Load(Connection, Transaction, vendorProduct.AssortmentVendorProductID);

                vendorProductToCreateUpdate.CMN_PRO_ASS_AssortmentProduct_RefID = vendorProduct.AssortmentProductID;
                vendorProductToCreateUpdate.CMN_PRO_Product_RefID = vendorProduct.ProductRefID;
                vendorProductToCreateUpdate.IsDeleted = vendorProduct.IsDeleted;
                vendorProductToCreateUpdate.Tenant_RefID = securityTicket.TenantID;
                returnValue=vendorProductToCreateUpdate.Save(Connection, Transaction);

            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3AS_SAVP_0004[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
        public static FR_Base Invoke(DbConnection Connection, P_L3AS_SAVP_0004[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
        public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, P_L3AS_SAVP_0004[] Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3AS_SAVP_0004[] Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Save_Assortment_Vendor_Products",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3AS_SAVP_0004[] for attribute P_L3AS_SAVP_0004[]
		[DataContract]
		public class P_L3AS_SAVP_0004 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssortmentVendorProductID { get; set; } 
			[DataMember]
			public Guid AssortmentProductID { get; set; } 
			[DataMember]
			public Guid ProductRefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Save_Assortment_Vendor_Products(,P_L3AS_SAVP_0004 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Save_Assortment_Vendor_Products.Invoke(connectionString,P_L3AS_SAVP_0004 Parameter,securityTicket);
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
var parameter = new CL3_Assortment.Complex.Manipulation.P_L3AS_SAVP_0004();
parameter.AssortmentVendorProductID = ...;
parameter.AssortmentProductID = ...;
parameter.ProductRefID = ...;
parameter.IsDeleted = ...;

*/
