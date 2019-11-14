/* 
 * Generated on 7/29/2014 3:08:00 PM
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
using CL5_APOBackoffice_CustomerOrder.Complex.Manipulation;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL6_Backoffice_Sales.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_CustomerOrderReturn_with_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_CustomerOrderReturn_with_Positions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6SA_CCORwP_1743 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            #region Preload Data
            var CurrencyID = CL2_Currency.Atomic.Retrieval.cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.CMN_CurrencyID;

            var incrNumberParam = new P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.StockReceiptNumber)
            };
            var stockReceiptNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;


            var account = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction,
                new CL1_USR.ORM_USR_Account.Query
                {
                    USR_AccountID = securityTicket.AccountID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();
            #endregion
            
            #region Create Receipt Header
            var receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header
            {
                LOG_RCP_Receipt_HeaderID = Guid.NewGuid(),
                ReceiptNumber = stockReceiptNumber,
                ReceiptHeaderCurrency_RefID = CurrencyID,
                DeliveringBusinessParticipant_RefID = Parameter.BusinessParticipantID,
                // Quality control
                IsQualityControlPerformed = true,
                QualityControlPerformed_AtDate = DateTime.Now,
                QualityControlPerformed_ByAccount_RefID = securityTicket.AccountID,
                // Price conditions
                IsPriceConditionsManuallyCleared = true,
                PriceConditionsManuallyCleared_AtDate = DateTime.Now,
                PriceConditionsManuallyCleared_ByAccount_RefID = securityTicket.AccountID,
                IsCustomerReturnReceipt = true,
                Creation_Timestamp = DateTime.Now,
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            };
            receiptHeader.Save(Connection, Transaction);
            #endregion

            #region Create CustomerOrderReturnHeader
            var resultCustomerOrderReturnHeaderId = cls_Save_CustomerOrderReturnHeader.Invoke(
                Connection, 
                Transaction, 
                new P_L5CO_SCORH_1326() 
                {
                    CustomerOrderReturnHeaderID = Guid.Empty,
                    CurencyId = CurrencyID,
                    Customer_BillingAddressUCD_RefID = Guid.Empty,  // TODO:Marko - Not sure how to get this one!?
                    Customer_BusinessParticipantID = Parameter.BusinessParticipantID,
                    CustomerInteractionsId = Parameter.CustomerInteractionId,
                    ReceiptHeaderId = receiptHeader.LOG_RCP_Receipt_HeaderID,
                    DateOfCustomerReturn = DateTime.Now,    // TODO:Marko !?
                    TotalValueBeforeTax = Parameter.Positions.Sum(p => p.Price)
                } ,securityTicket).Result;
            #endregion

            #region Create and Load CustomerOrderReturn positions
            var returnPositionsParameter = new P_L5CO_SCORP_1459()
            {
                CustomerOrderReturnHeaderID = resultCustomerOrderReturnHeaderId,
                OrganizationalUnitID = Parameter.OrganizationalUnitID,
                Positions = Parameter.Positions.Select(x =>
                    new P_L5CO_SCORP_1459a
                    {
                        CustomerOrderReturnPositionId = Guid.Empty,
                        ArticleID = x.ProductID,
                        OrderPrice = x.Price,
                        Quantity = x.Quantity,
                        CorrespondingReceiptPosition_RefID = x.ReceiptPositionID
                    }
                ).ToArray()
            };
            cls_Save_CustomerOrderReturnPositions.Invoke(Connection, Transaction, returnPositionsParameter, securityTicket);
            #endregion

            #region Create Receipt Positions
            CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position receiptPosition = null;
            CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem qualityControlItem = null;

            foreach (var position in Parameter.Positions)
            {
                #region Receipt Position
                receiptPosition = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position
                {
                    LOG_RCP_Receipt_PositionID = position.ReceiptPositionID,
                    Receipt_Header_RefID = receiptHeader.LOG_RCP_Receipt_HeaderID,
                    ReceiptPosition_Product_RefID = position.ProductID,
                    ExpectedPositionPrice = position.Price,
                    TotalQuantityTakenIntoStock = position.Quantity,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                receiptPosition.Save(Connection, Transaction);
                #endregion

                #region Quality Control Item
                qualityControlItem = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem
                {
                    LOG_RCP_Receipt_Position_QualityControlItem = Guid.NewGuid(),
                    Receipt_Position_RefID = receiptPosition.LOG_RCP_Receipt_PositionID,
                    ReceiptPositionCountedItemITL = receiptPosition.LOG_RCP_Receipt_PositionID.ToString(),
                    BatchNumber = position.BatchNumber,
                    QualityControl_PerformedAtDate = DateTime.Now,
                    QualityControl_PerformedByBusinessParticipant_RefID = account.BusinessParticipant_RefID,
                    Quantity = position.Quantity,
                    Target_WRH_Shelf_RefID = position.ShelfID,
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                if (position.ExpiryDate.HasValue)
                {
                    qualityControlItem.ExpiryDate = position.ExpiryDate.Value;
                }
                qualityControlItem.Save(Connection, Transaction);
                #endregion
            }
            #endregion

            #region Place article on stock
            var intakeParam = new CL3_Warehouse.Complex.Manipulation.P_L3WH_SRIC_1421
            {
                ReceiptHeaderID = receiptHeader.LOG_RCP_Receipt_HeaderID,
                WithoutProcurement = true
            };
            CL3_Warehouse.Complex.Manipulation.cls_StockReceipt_IntakeConfirmation.Invoke(Connection, Transaction, intakeParam, securityTicket);
            #endregion

            returnValue.Result = resultCustomerOrderReturnHeaderId;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6SA_CCORwP_1743 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6SA_CCORwP_1743 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SA_CCORwP_1743 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SA_CCORwP_1743 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_CustomerOrderReturn_with_Positions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6SA_CCORwP_1743 for attribute P_L6SA_CCORwP_1743
		[DataContract]
		public class P_L6SA_CCORwP_1743 
		{
			[DataMember]
			public P_L6SA_CCORwP_1743a[] Positions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid OrganizationalUnitID { get; set; } 
			[DataMember]
			public Guid CustomerInteractionId { get; set; } 

		}
		#endregion
		#region SClass P_L6SA_CCORwP_1743a for attribute Positions
		[DataContract]
		public class P_L6SA_CCORwP_1743a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public Double Quantity { get; set; } 
			[DataMember]
			public Decimal Price { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime? ExpiryDate { get; set; } 
			[DataMember]
			public Guid ShelfID { get; set; } 
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_CustomerOrderReturn_with_Positions(,P_L6SA_CCORwP_1743 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_CustomerOrderReturn_with_Positions.Invoke(connectionString,P_L6SA_CCORwP_1743 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_Sales.Complex.Manipulation.P_L6SA_CCORwP_1743();
parameter.Positions = ...;

parameter.CustomerOrderHeaderID = ...;
parameter.BusinessParticipantID = ...;
parameter.OrganizationalUnitID = ...;
parameter.CustomerInteractionId = ...;

*/
