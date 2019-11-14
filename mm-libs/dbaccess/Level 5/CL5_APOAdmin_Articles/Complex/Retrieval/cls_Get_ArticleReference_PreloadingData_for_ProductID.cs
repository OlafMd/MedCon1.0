/* 
 * Generated on 7/10/2014 4:02:08 PM
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
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using CL2_DiscountType.Atomic.Retrieval;
using CL5_APOAdmin_Articles.Atomic.Retrieval;
using CL1_CMN_PRO;
using CL3_Price.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_APOAdmin_Articles.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ArticleReference_PreloadingData_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ArticleReference_PreloadingData_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AA_GARPDfPI_3535 Execute(DbConnection Connection,DbTransaction Transaction,P_L5AA_GARPDfPI_3535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5AA_GARPDfPI_3535();
            returnValue.Result = new L5AA_GARPDfPI_3535();

            #region ArticleInfo

            var articleQuery = new ORM_CMN_PRO_Product.Query();
            articleQuery.CMN_PRO_ProductID = Parameter.ArticleID;
            articleQuery.Tenant_RefID = securityTicket.TenantID;
            var articleFound = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, articleQuery).SingleOrDefault();

            returnValue.Result.PZN = articleFound.Product_Number;
            returnValue.Result.ArticleName = articleFound.Product_Name;

            #endregion

            #region Standard Prices

            var standardPriceParam = new P_L3PR_GSPfPIL_1645()
            {
                ProductIDList = new Guid[1]{ Parameter.ArticleID }
            };

            var standardPrice = cls_Get_StandardPrices_for_ProductIDList.Invoke(
                Connection, Transaction, standardPriceParam, securityTicket).Result.SingleOrDefault();

            returnValue.Result.StandardPrices = standardPrice;

            #endregion

            #region Suppliers for Product

            var suppliersParam = new P_L5AA_GPSfPI_1248()
            {
                ProductID = Parameter.ArticleID
            };

            var SupplierProducts = cls_Get_ProductSuppliers_for_ProductID.Invoke(
                Connection, Transaction, suppliersParam, securityTicket).Result;
            
            returnValue.Result.ProductSuppliers = SupplierProducts;

            #endregion

            #region Predefined DiscountTypes

            var discountTypesParam = new P_L2DT_GDTfGPMIL_1546
            {
                GlobalPropertyMatchingID_List = EnumUtils.GetAllEnumDescriptions<EDiscountType>().ToArray()
            };
            returnValue.Result.DiscountTypes = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(
                Connection, Transaction, discountTypesParam, securityTicket).Result;

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5AA_GARPDfPI_3535 Invoke(string ConnectionString,P_L5AA_GARPDfPI_3535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AA_GARPDfPI_3535 Invoke(DbConnection Connection,P_L5AA_GARPDfPI_3535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AA_GARPDfPI_3535 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AA_GARPDfPI_3535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AA_GARPDfPI_3535 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AA_GARPDfPI_3535 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AA_GARPDfPI_3535 functionReturn = new FR_L5AA_GARPDfPI_3535();
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

				throw new Exception("Exception occured in method cls_Get_ArticleReference_PreloadingData_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AA_GARPDfPI_3535 : FR_Base
	{
		public L5AA_GARPDfPI_3535 Result	{ get; set; }

		public FR_L5AA_GARPDfPI_3535() : base() {}

		public FR_L5AA_GARPDfPI_3535(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AA_GARPDfPI_3535 for attribute P_L5AA_GARPDfPI_3535
		[DataContract]
		public class P_L5AA_GARPDfPI_3535 
		{
			//Standard type parameters
			[DataMember]
			public Guid ArticleID { get; set; } 

		}
		#endregion
		#region SClass L5AA_GARPDfPI_3535 for attribute L5AA_GARPDfPI_3535
		[DataContract]
		public class L5AA_GARPDfPI_3535 
		{
			//Standard type parameters
			[DataMember]
			public L5AA_GPSfPI_1248[] ProductSuppliers { get; set; } 
			[DataMember]
			public L3PR_GSPfPIL_1645 StandardPrices { get; set; } 
			[DataMember]
			public L2DT_GDTfGPMIL_1546[] DiscountTypes { get; set; } 
			[DataMember]
			public String PZN { get; set; } 
			[DataMember]
			public Dict ArticleName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AA_GARPDfPI_3535 cls_Get_ArticleReference_PreloadingData_for_ProductID(,P_L5AA_GARPDfPI_3535 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AA_GARPDfPI_3535 invocationResult = cls_Get_ArticleReference_PreloadingData_for_ProductID.Invoke(connectionString,P_L5AA_GARPDfPI_3535 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_Articles.Complex.Retrieval.P_L5AA_GARPDfPI_3535();
parameter.ArticleID = ...;

*/
