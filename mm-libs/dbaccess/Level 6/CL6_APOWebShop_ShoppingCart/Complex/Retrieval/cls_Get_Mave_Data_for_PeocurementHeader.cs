/* 
 * Generated on 4/7/2014 3:05:21 PM
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
using CL5_APOWebShop_ShoppingCart.Atomic.Retrieval;
using CL1_ORD_PRC;
using CL3_Account.Atomic.Retrieval;
using CL1_CMN_PRO;
using CL3_OrganizationalStructure.Atomic.Retrieval;
using CL5_APOWebShop_ProcurementOrder.Atomic.Retrieval;
using CL3_Supplier.Atomic.Retrieval;
using CL1_CMN_BPT_CTM;


namespace CL6_APOWebShop_ShoppingCart.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Mave_Data_for_PeocurementHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Mave_Data_for_PeocurementHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SH_GMDfPH_0500_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6SH_GMDfPH_0500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6SH_GMDfPH_0500_Array();
			//Put your code here

            var supplier = cls_Get_Suppliers_for_PrivateSubscribedCatalogs.Invoke(Connection, Transaction, securityTicket).Result.FirstOrDefault();

            #region Get All OrganizationalUnits

            //TODO: This is quick and dirty solution, remove it as soon as SLorenz remove MaveFile

            var organizationalUnits = ORM_CMN_BPT_CTM_OrganizationalUnit.Query.Search(Connection, Transaction, new ORM_CMN_BPT_CTM_OrganizationalUnit.Query()
            {
                Tenant_RefID = Guid.Parse(supplier.TenantITL)
            });

            #endregion

            var paramShoppingProducts = new P_L5PO_GPPaSCIfH_1750();
            paramShoppingProducts.ProcurementOrderHeaderID = Parameter.ProcurementHeaderID;
            var shoppingCartProcurementPositions = cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID.Invoke(Connection, Transaction, paramShoppingProducts, securityTicket)
                .Result.OrderBy(x => x.ORD_PRC_ShoppingCart_RefID);

            var maveResults = new List<L6SH_GMDfPH_0500>();

            var procurementHeader = new ORM_ORD_PRC_ProcurementOrder_Header();
            procurementHeader.Load(Connection, Transaction, Parameter.ProcurementHeaderID);

            var previousShoppingCartID = Guid.Empty;
            var currentShoppingCart = new ORM_ORD_PRC_ShoppingCart(); 

            var accountsForTenant = cls_Get_AllDisplayNames_of_Accounts_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            foreach (var shoppingCartProcurementPosition in shoppingCartProcurementPositions)
            {
                var maveResult = new L6SH_GMDfPH_0500();

                var currentProduct = new ORM_CMN_PRO_Product();
                currentProduct.Load(Connection, Transaction, shoppingCartProcurementPosition.CMN_PRO_Product_RefID);

                if (currentShoppingCart.ORD_PRC_ShoppingCartID == Guid.Empty || shoppingCartProcurementPosition.ORD_PRC_ShoppingCart_RefID != previousShoppingCartID)
                {
                    currentShoppingCart.Load(Connection, Transaction, shoppingCartProcurementPosition.ORD_PRC_ShoppingCart_RefID);
                }

                var userThatApproved = accountsForTenant.FirstOrDefault(x => x.USR_AccountID == currentShoppingCart.CreatedBy_Account_RefID);

                #region Add ShoppingCart Position

                //TODO: This is quick and dirty solution, remove it as soon as SLorenz remove MaveFile
                var organizationalUnit = organizationalUnits.Where(i => i.CustomerTenant_OfficeITL == shoppingCartProcurementPosition.CMN_STR_OfficeID.ToString()).Single();

                maveResult.CustomerNumber = supplier.ExternalSupplierProvidedIdentifier;
                maveResult.OrgUnitNumber = organizationalUnit.InternalOrganizationalUnitNumber;
                maveResult.OrderDateTime = procurementHeader.ProcurementOrder_Date;
                maveResult.PriceOfAllPositionsOverAll = procurementHeader.TotalValue_BeforeTax;
                maveResult.PZNorTXT = currentProduct.Product_Number;
                maveResult.UserThatApproved = userThatApproved.DisplayName;
                maveResult.OrderQuantity = Convert.ToInt32(shoppingCartProcurementPosition.Position_Quantity);
                maveResult.PositionPricePerUnit = shoppingCartProcurementPosition.Position_ValuePerUnit;
                maveResult.Comment = string.Empty;
                maveResult.IncreasingNumber = "108384";

                maveResults.Add(maveResult);
                #endregion

                #region Add ShoppingCart Comment
                // get all comments for current shopping chart and do that just once!
                if (currentShoppingCart.ORD_PRC_ShoppingCartID != previousShoppingCartID)
                {
                    previousShoppingCartID = currentShoppingCart.ORD_PRC_ShoppingCartID;

                    var shoppingNoteParameter = new P_L5AWSAR_GSCNfSC_1454();
                    shoppingNoteParameter.ShoppingCartID = currentShoppingCart.ORD_PRC_ShoppingCartID;
                    var shoppingCartNotes = cls_Get_ShoppingCart_Notes_for_ShoppingCartID.Invoke(Connection, Transaction, shoppingNoteParameter, securityTicket).Result;

                    foreach (var note in shoppingCartNotes)
                    {
                        if (!note.IsNoteForProcurementOrder)
                            continue;

                        maveResult = new L6SH_GMDfPH_0500();

                        maveResult.CustomerNumber = supplier.ExternalSupplierProvidedIdentifier;
                        maveResult.OrgUnitNumber = organizationalUnit.InternalOrganizationalUnitNumber;
                        maveResult.OrderDateTime = procurementHeader.ProcurementOrder_Date;
                        maveResult.PriceOfAllPositionsOverAll = procurementHeader.TotalValue_BeforeTax;
                        maveResult.PZNorTXT = "TEXT";
                        maveResult.UserThatApproved = userThatApproved.DisplayName;
                        maveResult.OrderQuantity = 0;
                        maveResult.PositionPricePerUnit = 0;
                        maveResult.Comment = note.Memo_Text;
                        maveResult.IncreasingNumber = "108384"; 

                        maveResults.Add(maveResult);
                    }
                }
                
                #endregion
            }


            returnValue.Result = maveResults.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SH_GMDfPH_0500_Array Invoke(string ConnectionString,P_L6SH_GMDfPH_0500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SH_GMDfPH_0500_Array Invoke(DbConnection Connection,P_L6SH_GMDfPH_0500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SH_GMDfPH_0500_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SH_GMDfPH_0500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SH_GMDfPH_0500_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SH_GMDfPH_0500 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SH_GMDfPH_0500_Array functionReturn = new FR_L6SH_GMDfPH_0500_Array();
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

				throw new Exception("Exception occured in method cls_Get_Mave_Data_for_PeocurementHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SH_GMDfPH_0500_Array : FR_Base
	{
		public L6SH_GMDfPH_0500[] Result	{ get; set; } 
		public FR_L6SH_GMDfPH_0500_Array() : base() {}

		public FR_L6SH_GMDfPH_0500_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SH_GMDfPH_0500 for attribute P_L6SH_GMDfPH_0500
		[DataContract]
		public class P_L6SH_GMDfPH_0500 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SH_GMDfPH_0500 for attribute L6SH_GMDfPH_0500
		[DataContract]
		public class L6SH_GMDfPH_0500 
		{
			//Standard type parameters
			[DataMember]
			public string CustomerNumber { get; set; } 
			[DataMember]
			public string OrgUnitNumber { get; set; } 
			[DataMember]
			public DateTime OrderDateTime { get; set; } 
			[DataMember]
			public decimal PriceOfAllPositionsOverAll { get; set; } 
			[DataMember]
			public string PZNorTXT { get; set; } 
			[DataMember]
			public string UserThatApproved { get; set; } 
			[DataMember]
			public int OrderQuantity { get; set; } 
			[DataMember]
			public decimal PositionPricePerUnit { get; set; } 
			[DataMember]
			public string Comment { get; set; } 
			[DataMember]
			public string IncreasingNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SH_GMDfPH_0500_Array cls_Get_Mave_Data_for_PeocurementHeader(,P_L6SH_GMDfPH_0500 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SH_GMDfPH_0500_Array invocationResult = cls_Get_Mave_Data_for_PeocurementHeader.Invoke(connectionString,P_L6SH_GMDfPH_0500 Parameter,securityTicket);
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
var parameter = new CL6_APOWebShop_ShoppingCart.Complex.Retrieval.P_L6SH_GMDfPH_0500();
parameter.ProcurementHeaderID = ...;

*/
