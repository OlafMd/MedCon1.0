/* 
 * Generated on 7/2/2014 3:30:09 PM
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
using CL6_APOReporting_WebShop.Atomic.Retrieval;
using CL5_APOWebShop_ShoppingCart.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;
using CL1_CMN_PER;
using CL1_ORD_PRC;
using CL1_CMN_PRO;
using CL1_CMN_SLS;
using CL1_ACC_TAX;
using CL1_CMN;

namespace CL6_APOReporting_WebShop.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShoppingCartData_for_ShoppingCartID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShoppingCartData_for_ShoppingCartID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6WS_GSCDfSCID_1458 Execute(DbConnection Connection,DbTransaction Transaction,P_L6WS_GSCDfSCID_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6WS_GSCDfSCID_1458();

			//Put your code here
            if (Parameter.ShoppingCartID == Guid.Empty)
                return null;

            returnValue.Result = new L6WS_GSCDfSCID_1458();

            #region ShoppingCart

            returnValue.Result.ShoppingCart = cls_Get_ShoppingCart_for_ShoppingCartID.Invoke(Connection, Transaction, new P_L6WS_GSCfSCID_1448() { ShoppingCartID = Parameter.ShoppingCartID }, securityTicket).Result;
            if (returnValue.Result.ShoppingCart == null)
                return null;
            #endregion

            #region ShoppingCart_Notes

            returnValue.Result.ShoppingCart_Notes = cls_Get_ShoppingCart_Notes_for_ShoppingCartID.Invoke(Connection, Transaction, new P_L5AWSAR_GSCNfSC_1454() { ShoppingCartID = Parameter.ShoppingCartID }, securityTicket).Result.OrderBy(i=>i.UpdatedOn).ToArray();

            #endregion

            #region Articles

            ORM_ORD_PRC_ShoppingCart_Product.Query shoppingCartProductsQuery = new ORM_ORD_PRC_ShoppingCart_Product.Query();
            shoppingCartProductsQuery.ORD_PRC_ShoppingCart_RefID = returnValue.Result.ShoppingCart.ORD_PRC_ShoppingCartID;
            shoppingCartProductsQuery.IsDeleted = false;
            shoppingCartProductsQuery.IsCanceled = false;
            shoppingCartProductsQuery.Tenant_RefID = securityTicket.TenantID;
            List<ORM_ORD_PRC_ShoppingCart_Product> productList = ORM_ORD_PRC_ShoppingCart_Product.Query.Search(Connection, Transaction, shoppingCartProductsQuery);

            List<Guid> articleIds = new List<Guid>();
            if (productList != null && productList.Count > 0)
                 articleIds.AddRange(productList.Select(i => i.CMN_PRO_Product_RefID));

            List<L3AR_GAfAL_0942> articleInfos = new List<L3AR_GAfAL_0942>();
            
            if (articleIds.Count > 0)
            articleInfos = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction,
                    new P_L3AR_GAfAL_0942() { ProductID_List = articleIds.ToArray() }, securityTicket).Result.ToList();
            

            List<L6WS_GSCDfSCID_1458_Product> products = new List<L6WS_GSCDfSCID_1458_Product>();
            L6WS_GSCDfSCID_1458_Product product;
            L3AR_GAfAL_0942 articleInfo;
            double taxRate = 0;
            #region ORM and Querie objects
            ORM_CMN_PRO_Product orm_product;
            ORM_CMN_SLS_Price.Query priceQuery;
            ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query taxAssignmentQuery;
            ORM_ACC_TAX_Tax orm_tax;
            #endregion
            foreach (var productItem in productList)
            {
                #region check procurement order date and number
                if(returnValue.Result.OrderDate == null || returnValue.Result.OrderDate.Ticks == 0)
                {
                    ORM_ORD_PRC_ShoppingCart_2_ProcurementOrderPosition.Query shoppingCartOrderPositionQuery = new ORM_ORD_PRC_ShoppingCart_2_ProcurementOrderPosition.Query();
                    shoppingCartOrderPositionQuery.IsDeleted = false;
                    shoppingCartOrderPositionQuery.Tenant_RefID = securityTicket.TenantID;
                    shoppingCartOrderPositionQuery.ORD_PRC_ShoppingCart_Product_RefID = productItem.ORD_PRC_ShoppingCart_ProductID;
                    List<ORM_ORD_PRC_ShoppingCart_2_ProcurementOrderPosition> shoppingCartOrderPositionList = ORM_ORD_PRC_ShoppingCart_2_ProcurementOrderPosition.Query.Search(Connection, Transaction, shoppingCartOrderPositionQuery);
                    foreach(var shoppingCartOrderPosition in shoppingCartOrderPositionList)
                    {
                        ORM_ORD_PRC_ProcurementOrder_Position procurementOrder_Position = new ORM_ORD_PRC_ProcurementOrder_Position();
                        var procurementOrder_PositionResult = procurementOrder_Position.Load(Connection, Transaction, shoppingCartOrderPosition.ORD_PRC_ProcurementOrder_Position_RefID);
                        
                        if(procurementOrder_PositionResult.Status != FR_Status.Success || procurementOrder_Position.ORD_PRC_ProcurementOrder_PositionID == Guid.Empty)
                            continue;

                        ORM_ORD_PRC_ProcurementOrder_Header procurementOrder_Header = new ORM_ORD_PRC_ProcurementOrder_Header();
                        var procurementOrder_HeaderResult = procurementOrder_Header.Load(Connection, Transaction, procurementOrder_Position.ProcurementOrder_Header_RefID);

                        if(procurementOrder_HeaderResult.Status != FR_Status.Success || procurementOrder_Header.ORD_PRC_ProcurementOrder_HeaderID == Guid.Empty)
                            continue;

                        returnValue.Result.OrderDate = procurementOrder_Header.ProcurementOrder_Date;
                        returnValue.Result.OrderNumber = procurementOrder_Header.ProcurementOrder_Number;
                        break;
                    }
                }
                #endregion

                #region get product
                orm_product = new ORM_CMN_PRO_Product();
                var productResult = orm_product.Load(Connection, Transaction, productItem.CMN_PRO_Product_RefID);
                if (productResult.Status != FR_Status.Success || orm_product.CMN_PRO_ProductID == Guid.Empty)
                    continue;
                #endregion

                #region get price
                ORM_CMN_PRO_SubscribedCatalog.Query catalogQuery = new ORM_CMN_PRO_SubscribedCatalog.Query();
                catalogQuery.Tenant_RefID = securityTicket.TenantID;
                catalogQuery.IsDeleted = false;
                List<ORM_CMN_PRO_SubscribedCatalog> catalogList = ORM_CMN_PRO_SubscribedCatalog.Query.Search(Connection, Transaction, catalogQuery);

                priceQuery = new ORM_CMN_SLS_Price.Query();
                priceQuery.CMN_PRO_Product_RefID = orm_product.CMN_PRO_ProductID;
                priceQuery.Tenant_RefID = securityTicket.TenantID;
                priceQuery.IsDeleted = false;
                List<ORM_CMN_SLS_Price> prices = ORM_CMN_SLS_Price.Query.Search(Connection, Transaction, priceQuery);
                ORM_CMN_SLS_Price price = prices.Where(i => catalogList.Select(j=>j.SubscribedCatalog_PricelistRelease_RefID).Contains(i.PricelistRelease_RefID)).FirstOrDefault();
                #endregion

                #region get taxes
                taxRate = 0;
                taxAssignmentQuery = new ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query();
                taxAssignmentQuery.Product_RefID = orm_product.CMN_PRO_ProductID;
                taxAssignmentQuery.Tenant_RefID = securityTicket.TenantID;
                taxAssignmentQuery.IsDeleted = false;
                List<ORM_CMN_PRO_Product_SalesTaxAssignmnet> taxAssignmentList = ORM_CMN_PRO_Product_SalesTaxAssignmnet.Query.Search(Connection, Transaction, taxAssignmentQuery);

                foreach (var taxAssignment in taxAssignmentList)
                {
                    orm_tax = new ORM_ACC_TAX_Tax();
                    var taxResult = orm_tax.Load(Connection, Transaction, taxAssignment.ApplicableSalesTax_RefID);
                    if (taxResult.Status == FR_Status.Success && orm_tax.ACC_TAX_TaxeID != Guid.Empty)
                        taxRate += orm_tax.TaxRate;
                }
                #endregion

                #region set product item
                product = new L6WS_GSCDfSCID_1458_Product();
                product.CMN_PRO_Product_RefID = orm_product.CMN_PRO_ProductID;
                product.PriceAmount = price == null ? 0 : (price.PriceAmount == null ? 0 : Double.Parse(price.PriceAmount.ToString()));
                product.TaxRate = taxRate;
                product.Quantity = productItem.Quantity.ToString();
                product.IsProductCanceled = productItem.IsCanceled;
                if (!String.IsNullOrEmpty(productItem.Comment))
                {
                    string[] comments = productItem.Comment.Split('@');
                    if(comments.Length == 2)
                        product.ProductComment = comments[1];
                }
                product.IsProductReplacementAllowed = productItem.IsProductReplacementAllowed;

                articleInfo = articleInfos.FirstOrDefault(i => i.CMN_PRO_ProductID == orm_product.CMN_PRO_ProductID);
                if (articleInfo != null)
                {
                    product.Product_Name = articleInfo.Product_Name;
                    product.Product_Number = articleInfo.Product_Number;
                    product.UnitAmount = articleInfo.UnitAmount.ToString();
                    product.UnitIsoCode = articleInfo.UnitIsoCode;
                    product.DossageFormName = articleInfo.DossageFormName;
                }
                #endregion

                products.Add(product);
            }

            returnValue.Result.Products = products.ToArray();

            #endregion

            #region Person info
            // current user
            ORM_CMN_PER_PersonInfo_2_Account.Query accountQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
            accountQuery.USR_Account_RefID = securityTicket.AccountID;
            accountQuery.Tenant_RefID = securityTicket.TenantID;
            accountQuery.IsDeleted = false;
            ORM_CMN_PER_PersonInfo_2_Account account = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, accountQuery).FirstOrDefault();

            if (account != null)
            {
                ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                var personInfoResult = personInfo.Load(Connection, Transaction, account.CMN_PER_PersonInfo_RefID);
                if (personInfoResult.Status == FR_Status.Success && personInfo.CMN_PER_PersonInfoID != Guid.Empty)
                    returnValue.Result.CurrentUser = personInfo.FirstName + " " + personInfo.LastName;
            }

            #region Approved by user

            ORM_ORD_PRC_ShoppingCart_Status.Query stusesQuery = new ORM_ORD_PRC_ShoppingCart_Status.Query();
            stusesQuery.Tenant_RefID = securityTicket.TenantID;
            stusesQuery.IsDeleted = false;
            List<ORM_ORD_PRC_ShoppingCart_Status> statuses = ORM_ORD_PRC_ShoppingCart_Status.Query.Search(Connection, Transaction, stusesQuery);
            ORM_ORD_PRC_ShoppingCart_Status approvedStatus = statuses.FirstOrDefault(i => i.GlobalPropertyMatchingID.Contains("approved"));

            if (approvedStatus != null)
            {
                ORM_ORD_PRC_ShoppingCartStatus_History.Query statusHistoryQuery = new ORM_ORD_PRC_ShoppingCartStatus_History.Query();
                statusHistoryQuery.Tenant_RefID = securityTicket.TenantID;
                statusHistoryQuery.IsDeleted = false;
                statusHistoryQuery.ORD_PRC_ShoppingCart_RefID = returnValue.Result.ShoppingCart.ORD_PRC_ShoppingCartID;
                statusHistoryQuery.ORD_PRC_ShoppingCart_Status_RefID = approvedStatus.ORD_PRC_ShoppingCart_StatusID;
                ORM_ORD_PRC_ShoppingCartStatus_History statusHistory = ORM_ORD_PRC_ShoppingCartStatus_History.Query.Search(Connection, Transaction, statusHistoryQuery).FirstOrDefault();
                if (statusHistory != null)
                {
                    accountQuery = new ORM_CMN_PER_PersonInfo_2_Account.Query();
                    accountQuery.USR_Account_RefID = statusHistory.PerformedBy_Account_RefID;
                    accountQuery.Tenant_RefID = securityTicket.TenantID;
                    accountQuery.IsDeleted = false;
                    account = ORM_CMN_PER_PersonInfo_2_Account.Query.Search(Connection, Transaction, accountQuery).FirstOrDefault();

                    if (account != null)
                    {
                        ORM_CMN_PER_PersonInfo personInfo = new ORM_CMN_PER_PersonInfo();
                        var personInfoResult = personInfo.Load(Connection, Transaction, account.CMN_PER_PersonInfo_RefID);
                        if (personInfoResult.Status == FR_Status.Success && personInfo.CMN_PER_PersonInfoID != Guid.Empty)
                        {
                            returnValue.Result.ApprovedByUser = personInfo.FirstName + " " + personInfo.LastName;
                            returnValue.Result.DateOfApproval = statusHistory.Creation_Timestamp;
                        }
                    }
                }
            }

            #endregion

            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6WS_GSCDfSCID_1458 Invoke(string ConnectionString,P_L6WS_GSCDfSCID_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6WS_GSCDfSCID_1458 Invoke(DbConnection Connection,P_L6WS_GSCDfSCID_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6WS_GSCDfSCID_1458 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6WS_GSCDfSCID_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6WS_GSCDfSCID_1458 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6WS_GSCDfSCID_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6WS_GSCDfSCID_1458 functionReturn = new FR_L6WS_GSCDfSCID_1458();
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

				throw new Exception("Exception occured in method cls_Get_ShoppingCartData_for_ShoppingCartID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6WS_GSCDfSCID_1458 : FR_Base
	{
		public L6WS_GSCDfSCID_1458 Result	{ get; set; }

		public FR_L6WS_GSCDfSCID_1458() : base() {}

		public FR_L6WS_GSCDfSCID_1458(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6WS_GSCDfSCID_1458 for attribute P_L6WS_GSCDfSCID_1458
		[DataContract]
		public class P_L6WS_GSCDfSCID_1458 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCartID { get; set; } 

		}
		#endregion
		#region SClass L6WS_GSCDfSCID_1458 for attribute L6WS_GSCDfSCID_1458
		[DataContract]
		public class L6WS_GSCDfSCID_1458 
		{
			[DataMember]
			public L6WS_GSCDfSCID_1458_Product[] Products { get; set; }

			//Standard type parameters
			[DataMember]
			public L6WS_GSCfSCID_1448 ShoppingCart { get; set; } 
			[DataMember]
			public DateTime OrderDate { get; set; } 
			[DataMember]
			public String OrderNumber { get; set; } 
			[DataMember]
			public String CurrentUser { get; set; } 
			[DataMember]
			public String ApprovedByUser { get; set; } 
			[DataMember]
			public DateTime DateOfApproval { get; set; } 
			[DataMember]
			public L5AWSAR_GSCNfSC_1454[] ShoppingCart_Notes { get; set; } 

		}
		#endregion
		#region SClass L6WS_GSCDfSCID_1458_Product for attribute Products
		[DataContract]
		public class L6WS_GSCDfSCID_1458_Product 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PRO_Product_RefID { get; set; } 
			[DataMember]
			public Dict Product_Name { get; set; } 
			[DataMember]
			public String Product_Number { get; set; } 
			[DataMember]
			public String UnitAmount { get; set; } 
			[DataMember]
			public String UnitIsoCode { get; set; } 
			[DataMember]
			public string DossageFormName { get; set; } 
			[DataMember]
			public String Quantity { get; set; } 
			[DataMember]
			public bool IsProductCanceled { get; set; } 
			[DataMember]
			public String ProductComment { get; set; } 
			[DataMember]
			public bool IsProductReplacementAllowed { get; set; } 
			[DataMember]
			public Double PriceAmount { get; set; } 
			[DataMember]
			public Double TaxRate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6WS_GSCDfSCID_1458 cls_Get_ShoppingCartData_for_ShoppingCartID(,P_L6WS_GSCDfSCID_1458 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6WS_GSCDfSCID_1458 invocationResult = cls_Get_ShoppingCartData_for_ShoppingCartID.Invoke(connectionString,P_L6WS_GSCDfSCID_1458 Parameter,securityTicket);
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
var parameter = new CL6_APOReporting_WebShop.Complex.Retrieval.P_L6WS_GSCDfSCID_1458();
parameter.ShoppingCartID = ...;

*/
