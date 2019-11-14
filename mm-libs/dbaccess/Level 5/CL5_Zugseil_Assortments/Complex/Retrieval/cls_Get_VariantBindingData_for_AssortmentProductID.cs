/* 
 * Generated on 1/30/2015 04:35:00
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
using CL5_Zugseil_Assortments.Atomic.Retrieval;
using CL1_CMN_PRO_ASS;

namespace CL5_Zugseil_Assortments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_VariantBindingData_for_AssortmentProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_VariantBindingData_for_AssortmentProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AS_GVBDfAP_2226_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AS_GVBDfAP_2226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5AS_GVBDfAP_2226_Array();
            //Put your code here

            #region Get product id from assortmentProduct
            ORM_CMN_PRO_ASS_AssortmentProduct assortmentProduct = new ORM_CMN_PRO_ASS_AssortmentProduct();
            assortmentProduct.Load(Connection, Transaction, Parameter.AssortmentProductID);

            var productID = assortmentProduct.Ext_CMN_PRO_Product_RefID;
            #endregion

            #region Get all assortmentVariants
            var assortmentVariants = cls_Get_AssortmentVariants_for_ProductID.Invoke(Connection, Transaction, new P_L5AS_GAVfP_2216() { ProductID = productID }, securityTicket).Result.ToList();
            #endregion

            List<L5AS_GVBDfAP_2226> resultList = new List<L5AS_GVBDfAP_2226>();
            foreach (var assortmentVariant in assortmentVariants)
            {
                L5AS_GVBDfAP_2226 resultItem = new L5AS_GVBDfAP_2226();
                resultItem.AssProductVariantID = assortmentVariant.CMN_PRO_Product_VariantID;
                resultItem.AssProductVariantName = assortmentVariant.VariantName_DictID;
                resultItem.AssVariantID = assortmentVariant.CMN_PRO_ASS_AssortmentVariantID;

                var assortmentVendorVariants = cls_Get_AssortmentVendorVariants_for_AssortmentVariant.Invoke(Connection, Transaction, new P_L5AS_GAVVfAV_2218() { AssortmentVariantID = assortmentVariant.CMN_PRO_ASS_AssortmentVariantID }, securityTicket).Result;

                List<L5AS_GVBDfAP_2226a> assVendorVariants = new List<L5AS_GVBDfAP_2226a>();
                if (assortmentVendorVariants != null && assortmentVendorVariants.Count() > 0)
                {                  
                    foreach (var assortmentVendorVariant in assortmentVendorVariants)
                    {
                        L5AS_GVBDfAP_2226a assVendorVariant = new L5AS_GVBDfAP_2226a();
                        assVendorVariant.BoundedProductID = assortmentVendorVariant.BoundToProductID;
                        assVendorVariant.BoundedVariantID = assortmentVendorVariant.BoundToVariantID;
                        assVendorVariants.Add(assVendorVariant);
                    }
                }
                resultItem.VendorVariants = assVendorVariants.ToArray();

                resultList.Add(resultItem);
            }

            returnValue.Result = resultList.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AS_GVBDfAP_2226_Array Invoke(string ConnectionString,P_L5AS_GVBDfAP_2226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AS_GVBDfAP_2226_Array Invoke(DbConnection Connection,P_L5AS_GVBDfAP_2226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AS_GVBDfAP_2226_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AS_GVBDfAP_2226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AS_GVBDfAP_2226_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AS_GVBDfAP_2226 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AS_GVBDfAP_2226_Array functionReturn = new FR_L5AS_GVBDfAP_2226_Array();
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

				throw new Exception("Exception occured in method cls_Get_VariantBindingData_for_AssortmentProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AS_GVBDfAP_2226_Array : FR_Base
	{
		public L5AS_GVBDfAP_2226[] Result	{ get; set; } 
		public FR_L5AS_GVBDfAP_2226_Array() : base() {}

		public FR_L5AS_GVBDfAP_2226_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AS_GVBDfAP_2226 for attribute P_L5AS_GVBDfAP_2226
		[DataContract]
		public class P_L5AS_GVBDfAP_2226 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssortmentProductID { get; set; } 

		}
		#endregion
		#region SClass L5AS_GVBDfAP_2226 for attribute L5AS_GVBDfAP_2226
		[DataContract]
		public class L5AS_GVBDfAP_2226 
		{
			[DataMember]
			public L5AS_GVBDfAP_2226a[] VendorVariants { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid AssVariantID { get; set; } 
			[DataMember]
			public Guid AssProductVariantID { get; set; } 
			[DataMember]
			public Dict AssProductVariantName { get; set; } 

		}
		#endregion
		#region SClass L5AS_GVBDfAP_2226a for attribute VendorVariants
		[DataContract]
		public class L5AS_GVBDfAP_2226a 
		{
			//Standard type parameters
			[DataMember]
			public Guid BoundedProductID { get; set; } 
			[DataMember]
			public Guid BoundedVariantID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AS_GVBDfAP_2226_Array cls_Get_VariantBindingData_for_AssortmentProductID(,P_L5AS_GVBDfAP_2226 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AS_GVBDfAP_2226_Array invocationResult = cls_Get_VariantBindingData_for_AssortmentProductID.Invoke(connectionString,P_L5AS_GVBDfAP_2226 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_Assortments.Complex.Retrieval.P_L5AS_GVBDfAP_2226();
parameter.AssortmentProductID = ...;

*/
