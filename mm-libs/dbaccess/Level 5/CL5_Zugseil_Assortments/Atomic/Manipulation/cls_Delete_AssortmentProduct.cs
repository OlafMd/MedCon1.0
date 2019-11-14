/* 
 * Generated on 12/1/2014 04:33:16
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
using CL3_Assortment.Atomic.Retrieval;


namespace CL5_Zugseil_Assortments.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_AssortmentProduct.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_AssortmentProduct
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AS_DAP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            returnValue.Result = Parameter.AssortmentProductID;
			//Put your code here

            ORM_CMN_PRO_ASS_AssortmentProduct assProduct = new ORM_CMN_PRO_ASS_AssortmentProduct();
            assProduct.Load(Connection, Transaction, Parameter.AssortmentProductID);
            assProduct.IsDeleted = true;
            assProduct.Save(Connection, Transaction);

            ORM_CMN_PRO_ASS_Assortment_2_AssortmentProduct.Query ass2prodQuery = new ORM_CMN_PRO_ASS_Assortment_2_AssortmentProduct.Query();
            ass2prodQuery.CMN_PRO_ASS_Assortment_Product_RefID = assProduct.CMN_PRO_ASS_AssortmentProductID;
            var ass2prod = ORM_CMN_PRO_ASS_Assortment_2_AssortmentProduct.Query.Search(Connection, Transaction, ass2prodQuery);

            if (ass2prod != null)
            {
                foreach (var item in ass2prod)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }
            }

            ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query vendorsQuery = new ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query();
            vendorsQuery.CMN_PRO_ASS_AssortmentProduct_RefID = assProduct.CMN_PRO_ASS_AssortmentProductID;
            var vendors = ORM_CMN_PRO_ASS_AssortmentProduct_VendorProduct.Query.Search(Connection, Transaction, vendorsQuery);

            if (vendors != null)
            {
                foreach (var item in vendors)
                {
                    item.IsDeleted = true;
                    item.Save(Connection, Transaction);
                }
            }

            P_L3AS_GAVfAP_1128 variantsParam = new P_L3AS_GAVfAP_1128()
            {
                AssortmentProductID = Parameter.AssortmentProductID
            };
            var variants = cls_Get_AssortmentVariants_for_AssortmentProduct.Invoke(Connection, Transaction, variantsParam, securityTicket).Result;

            foreach (var variant in variants)
            {
                ORM_CMN_PRO_ASS_AssortmentVariant assortmentVariant = new ORM_CMN_PRO_ASS_AssortmentVariant();
                assortmentVariant.Load(Connection, Transaction, variant.CMN_PRO_ASS_AssortmentVariantID);
                assortmentVariant.IsDeleted = true;
                assortmentVariant.Save(Connection, Transaction);

                ORM_CMN_PRO_ASS_DistributionPrice distributionPrice = new ORM_CMN_PRO_ASS_DistributionPrice();
                distributionPrice.Load(Connection, Transaction, assortmentVariant.DistributionPrice_RefID);
                distributionPrice.IsDeleted = true;
                distributionPrice.Save(Connection, Transaction);
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AS_DAP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AS_DAP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AS_DAP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AS_DAP_1628 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_AssortmentProduct",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AS_DAP_1628 for attribute P_L5AS_DAP_1628
		[DataContract]
		public class P_L5AS_DAP_1628 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssortmentProductID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_AssortmentProduct(,P_L5AS_DAP_1628 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_AssortmentProduct.Invoke(connectionString,P_L5AS_DAP_1628 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Assortments.Atomic.Manipulation.P_L5AS_DAP_1628();
parameter.AssortmentProductID = ...;

*/
