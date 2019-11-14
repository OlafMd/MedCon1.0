/* 
 * Generated on 4/8/2014 12:09:46 PM
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
using CL5_APOWebShop_ProcurementOrder.Atomic.Retrieval;
using CL1_ORD_PRC;
using CL2_Language.Atomic.Retrieval;
using CL1_CMN_PRO;

namespace CL6_APOWebShop_ProcurementOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Parameters_for_CustomerOrderCreationMessage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Parameters_for_CustomerOrderCreationMessage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PO_GPfCOCM_1502 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PO_GPfCOCM_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PO_GPfCOCM_1502();
            returnValue.Result = new L6PO_GPfCOCM_1502();

            #region Get Languages

            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            var LanguageID = DBLanguages.Where(i => i.ISO_639_1 == "DE").SingleOrDefault().CMN_LanguageID;

            #endregion

            #region ORM_ORD_PRC_ProcurementOrder_Header

            var procurementHeader = new ORM_ORD_PRC_ProcurementOrder_Header();
            procurementHeader.Load(Connection, Transaction, Parameter.ProcurementHeaderID);

            #endregion

            #region ORM_ORD_PRC_ProcurementOrder_Positions

            var paramShoppingProducts = new P_L5PO_GPPaSCIfH_1750();
            paramShoppingProducts.ProcurementOrderHeaderID = Parameter.ProcurementHeaderID;
            var shoppingProducts = cls_Get_ProcurementPositions_and_ShoppingCartInfo_for_HeaderID.Invoke(Connection, Transaction, paramShoppingProducts, securityTicket).Result;

            #endregion

            #region Positions

            var positions = new List<L6PO_GPfCOCM_1502a>();

            foreach (var shoppingProduct in shoppingProducts)
            {
                var product = new ORM_CMN_PRO_Product();
                product.Load(Connection, Transaction, shoppingProduct.CMN_PRO_Product_RefID);

                if (String.IsNullOrEmpty(product.ProductITL))
                {
                    product.ProductITL = Guid.NewGuid().ToString();
                    product.Save(Connection, Transaction);
                }

                var catalogSubscription = new ORM_CMN_PRO_SubscribedCatalog();
                catalogSubscription.Load(Connection, Transaction, product.IfImportedFromExternalCatalog_CatalogSubscription_RefID);

                var position = new L6PO_GPfCOCM_1502a();
                position.ProductITL = product.ProductITL;
                position.ProductNumber = product.Product_Number;
                position.ProductName = product.Product_Name.GetContent(LanguageID);
                position.ProductDescription = product.Product_Description.GetContent(LanguageID);
                position.Comment = "NotDefinedBySender";
                position.Quantity = shoppingProduct.Position_Quantity;
                position.IsProductReplacementAllowed = shoppingProduct.IsProductReplacementAllowed;
                position.SourceCatalogITL = catalogSubscription.CatalogCodeITL;
                position.UnitPrice = shoppingProduct.Position_ValuePerUnit;
                position.NetoPrice = shoppingProduct.Position_ValueTotal;

                var shoppingCart2Office = ORM_ORD_PRC_Office_ShoppingCart.Query.Search(Connection, Transaction,
                        new ORM_ORD_PRC_Office_ShoppingCart.Query{
                            ORD_PRC_ShoppingCart_RefID = shoppingProduct.ORD_PRC_ShoppingCart_RefID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }
                    ).Single();

                position.Quantites = new L6PO_GPfCOCM_1502b[]{
                    new L6PO_GPfCOCM_1502b()
                    {
                        OfficeID = shoppingCart2Office.CMN_STR_Office_RefID,
                        Quantity = shoppingProduct.Position_Quantity
                    }
                };

                positions.Add(position);
                
            }

            #endregion

            #region Comments

            var procurmentNotes = ORM_ORD_PRC_ProcurementOrder_Note.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Note.Query(){
                ORD_PRC_ProcurementOrder_Header_RefID = procurementHeader.ORD_PRC_ProcurementOrder_HeaderID,
                IsDeleted = false
            }).ToList();

            var comments = new List<L6PO_GPfCOCM_1502c>();

            foreach (var note in procurmentNotes)
            {
                comments.Add(
                    new L6PO_GPfCOCM_1502c()
                    {
                        OfficeID = note.CMN_STR_Office_RefID,
                        Content = note.Comment,
                        PublilshDate = note.NotePublishDate,
                        SequenceNumber = note.SequenceOrderNumber,
                        Title = note.Title
                    }
                );
            }

            #endregion
            
            returnValue.Result.ProcurProcurementHeaderID = procurementHeader.ORD_PRC_ProcurementOrder_HeaderID;
            returnValue.Result.OrderNumber = procurementHeader.ProcurementOrder_Number;
            returnValue.Result.ProcurementOrderDate = procurementHeader.ProcurementOrder_Date;
            returnValue.Result.Comments = comments.ToArray();

            returnValue.Result.Positions = positions.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PO_GPfCOCM_1502 Invoke(string ConnectionString,P_L6PO_GPfCOCM_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PO_GPfCOCM_1502 Invoke(DbConnection Connection,P_L6PO_GPfCOCM_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PO_GPfCOCM_1502 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PO_GPfCOCM_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PO_GPfCOCM_1502 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PO_GPfCOCM_1502 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PO_GPfCOCM_1502 functionReturn = new FR_L6PO_GPfCOCM_1502();
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

				throw new Exception("Exception occured in method cls_Get_Parameters_for_CustomerOrderCreationMessage",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PO_GPfCOCM_1502 : FR_Base
	{
		public L6PO_GPfCOCM_1502 Result	{ get; set; }

		public FR_L6PO_GPfCOCM_1502() : base() {}

		public FR_L6PO_GPfCOCM_1502(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PO_GPfCOCM_1502 for attribute P_L6PO_GPfCOCM_1502
		[DataContract]
		public class P_L6PO_GPfCOCM_1502 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6PO_GPfCOCM_1502 for attribute L6PO_GPfCOCM_1502
		[DataContract]
		public class L6PO_GPfCOCM_1502 
		{
			[DataMember]
			public L6PO_GPfCOCM_1502a[] Positions { get; set; }
			[DataMember]
			public L6PO_GPfCOCM_1502c[] Comments { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProcurProcurementHeaderID { get; set; } 
			[DataMember]
			public String OrderNumber { get; set; } 
			[DataMember]
			public DateTime ProcurementOrderDate { get; set; } 

		}
		#endregion
		#region SClass L6PO_GPfCOCM_1502a for attribute Positions
		[DataContract]
		public class L6PO_GPfCOCM_1502a 
		{
			[DataMember]
			public L6PO_GPfCOCM_1502b[] Quantites { get; set; }

			//Standard type parameters
			[DataMember]
			public String ProductITL { get; set; } 
			[DataMember]
			public String ProductNumber { get; set; } 
			[DataMember]
			public String ProductName { get; set; } 
			[DataMember]
			public String ProductDescription { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public Double Quantity { get; set; } 
			[DataMember]
			public Boolean IsProductReplacementAllowed { get; set; } 
			[DataMember]
			public String SourceCatalogITL { get; set; } 
			[DataMember]
			public Decimal UnitPrice { get; set; } 
			[DataMember]
			public Decimal NetoPrice { get; set; } 

		}
		#endregion
		#region SClass L6PO_GPfCOCM_1502b for attribute Quantites
		[DataContract]
		public class L6PO_GPfCOCM_1502b 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Double Quantity { get; set; } 

		}
		#endregion
		#region SClass L6PO_GPfCOCM_1502c for attribute Comments
		[DataContract]
		public class L6PO_GPfCOCM_1502c 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public DateTime PublilshDate { get; set; } 
			[DataMember]
			public int SequenceNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PO_GPfCOCM_1502 cls_Get_Parameters_for_CustomerOrderCreationMessage(,P_L6PO_GPfCOCM_1502 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PO_GPfCOCM_1502 invocationResult = cls_Get_Parameters_for_CustomerOrderCreationMessage.Invoke(connectionString,P_L6PO_GPfCOCM_1502 Parameter,securityTicket);
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
var parameter = new CL6_APOWebShop_ProcurementOrder.Complex.Retrieval.P_L6PO_GPfCOCM_1502();
parameter.ProcurementHeaderID = ...;

*/
