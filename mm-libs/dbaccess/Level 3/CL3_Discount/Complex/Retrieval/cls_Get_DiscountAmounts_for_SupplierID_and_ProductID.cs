/* 
 * Generated on 7/18/2014 11:05:55 AM
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

namespace CL3_Discount.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DiscountAmounts_for_SupplierID_and_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiscountAmounts_for_SupplierID_and_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DC_GDAfSaP_0949 Execute(DbConnection Connection,DbTransaction Transaction,P_L3DC_GDAfSaP_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3DC_GDAfSaP_0949();
            returnValue.Result = new L3DC_GDAfSaP_0949();

            #region Discount Types
            
            var discountTypeParam = new CL2_DiscountType.Atomic.Retrieval.P_L2DT_GDTfGPMIL_1546();
            discountTypeParam.GlobalPropertyMatchingID_List = DLCore_DBCommons.Utils.EnumUtils.GetAllEnumDescriptions<DLCore_DBCommons.APODemand.EDiscountType>().ToArray();
            var discountTypes = CL2_DiscountType.Atomic.Retrieval.cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(
                Connection, Transaction, discountTypeParam, securityTicket).Result;

            #endregion

            #region Supplier Discounts

            var supplierDiscountValues = CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue.Query.Search(Connection, Transaction,
                new CL1_CMN_BPT.ORM_CMN_BPT_Supplier_DiscountValue.Query
                {
                    Supplier_RefID = Parameter.SupplierID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                });

            #endregion

            #region Product Supplier Discounts

            var paramProductSupplierDiscount = new CL3_Discount.Atomic.Retrieval.P_L3DC_GPSDAfSoP_0957
            {
                SupplierID = Parameter.SupplierID,
                ProductID  = Parameter.ProductID
            };
            var productSupplierDiscounts =  CL3_Discount.Atomic.Retrieval.cls_Get_Product_Supplier_DiscountAmounts_for_SupplierID_or_ProductID.Invoke(
                Connection, Transaction, paramProductSupplierDiscount, securityTicket).Result;
            
            #endregion

            #region Bind data to returnValue
            
            returnValue.Result.SupplierDiscounts = supplierDiscountValues.Select(x => new L3DC_GDAfSaP_0949a
                {
                    ORD_PRC_DiscountType_RefID = x.ORD_PRC_DiscountType_RefID,
                    DiscountValue = x.DiscountValue_in_percent,
                    DiscountType_GlobalPropertyMatchingID = discountTypes.Single(y => y.ORD_PRC_DiscountTypeID == x.ORD_PRC_DiscountType_RefID).GlobalPropertyMatchingID
                }).ToArray();

            returnValue.Result.ProductSupplierDiscounts = productSupplierDiscounts.ToArray();

            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3DC_GDAfSaP_0949 Invoke(string ConnectionString,P_L3DC_GDAfSaP_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DC_GDAfSaP_0949 Invoke(DbConnection Connection,P_L3DC_GDAfSaP_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DC_GDAfSaP_0949 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DC_GDAfSaP_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DC_GDAfSaP_0949 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DC_GDAfSaP_0949 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DC_GDAfSaP_0949 functionReturn = new FR_L3DC_GDAfSaP_0949();
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

				throw new Exception("Exception occured in method cls_Get_DiscountAmounts_for_SupplierID_and_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DC_GDAfSaP_0949 : FR_Base
	{
		public L3DC_GDAfSaP_0949 Result	{ get; set; }

		public FR_L3DC_GDAfSaP_0949() : base() {}

		public FR_L3DC_GDAfSaP_0949(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DC_GDAfSaP_0949 for attribute P_L3DC_GDAfSaP_0949
		[DataContract]
		public class P_L3DC_GDAfSaP_0949 
		{
			//Standard type parameters
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public Guid? ProductID { get; set; } 

		}
		#endregion
		#region SClass L3DC_GDAfSaP_0949 for attribute L3DC_GDAfSaP_0949
		[DataContract]
		public class L3DC_GDAfSaP_0949 
		{
			[DataMember]
			public L3DC_GDAfSaP_0949a[] SupplierDiscounts { get; set; }

			//Standard type parameters
			[DataMember]
			public CL3_Discount.Atomic.Retrieval.L3DC_GPSDAfSoP_0957[] ProductSupplierDiscounts { get; set; } 

		}
		#endregion
		#region SClass L3DC_GDAfSaP_0949a for attribute SupplierDiscounts
		[DataContract]
		public class L3DC_GDAfSaP_0949a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_DiscountType_RefID { get; set; } 
			[DataMember]
			public Double DiscountValue { get; set; } 
			[DataMember]
			public string DiscountType_GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3DC_GDAfSaP_0949 cls_Get_DiscountAmounts_for_SupplierID_and_ProductID(,P_L3DC_GDAfSaP_0949 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3DC_GDAfSaP_0949 invocationResult = cls_Get_DiscountAmounts_for_SupplierID_and_ProductID.Invoke(connectionString,P_L3DC_GDAfSaP_0949 Parameter,securityTicket);
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
var parameter = new CL3_Discount.Complex.Retrieval.P_L3DC_GDAfSaP_0949();
parameter.SupplierID = ...;
parameter.ProductID = ...;

*/
