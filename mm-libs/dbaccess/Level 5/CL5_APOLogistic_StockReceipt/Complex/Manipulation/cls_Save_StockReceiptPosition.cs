/* 
 * Generated on 4/9/2014 11:02:23
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
using CL1_LOG_RCP;
using CL2_DiscountType.Atomic.Retrieval;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;
using CL1_ORD_PRC;

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_StockReceiptPosition.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_StockReceiptPosition
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_SRP_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            List<Guid> positionIDs = new List<Guid>();

            var positionToEdit = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position();
            positionToEdit.Load(Connection, Transaction, Parameter.PositionID);
            positionToEdit.PriceOnSupplierBill = Convert.ToDecimal(Parameter.PositionValue);
            positionToEdit.Save(Connection, Transaction);
            
            if (Parameter.PositionDiscounts != null)
            {
                if (Parameter.SaveNaturalRabatForAllPos)
                {
                    var headerID = positionToEdit.Receipt_Header_RefID;

                    var headerPositions = ORM_LOG_RCP_Receipt_Position.Query.Search(Connection, Transaction,
                        new ORM_LOG_RCP_Receipt_Position.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            Receipt_Header_RefID = headerID
                        }).ToList();

                    positionIDs.AddRange(headerPositions.Select(x => x.LOG_RCP_Receipt_PositionID));
                }

                #region Load position discounts

                var positionDiscountAmounts =  ORM_LOG_RCP_Receipt_Position_DiscountAmount.Query.Search(Connection, Transaction, 
                    new ORM_LOG_RCP_Receipt_Position_DiscountAmount.Query
                    {
                        LOG_RCP_Receipt_Position_RefID = Parameter.PositionID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).ToArray();

                #endregion

                #region Preload discount types and choose those that are applying to stock reciept positions

                var discountTypesParam = new P_L2DT_GDTfGPMIL_1546();
                discountTypesParam.GlobalPropertyMatchingID_List = new string[] 
                {
                    EnumUtils.GetEnumDescription(EDiscountType.MainDiscount),
                    EnumUtils.GetEnumDescription(EDiscountType.Discount2),
                    EnumUtils.GetEnumDescription(EDiscountType.Discount3),
                    EnumUtils.GetEnumDescription(EDiscountType.NaturalDiscount)
                };
                var discountTypes = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(Connection, Transaction, discountTypesParam, securityTicket).Result;

                #endregion

                ORM_LOG_RCP_Receipt_Position_DiscountAmount discountAmount = null;
                foreach (var item in discountTypes)
                {
                    var paramDiscount = Parameter.PositionDiscounts.SingleOrDefault(x => x.DiscountTypeID == item.ORD_PRC_DiscountTypeID);
                    if (paramDiscount == null)
                    {
                        // if no discount type is in the parameters
                        continue;
                    }

                    discountAmount = positionDiscountAmounts.SingleOrDefault(x => x.ORD_PRC_DiscountType_RefID == item.ORD_PRC_DiscountTypeID);
                    if (discountAmount == null)
                    {
                        // create new position discount amount
                        discountAmount = new ORM_LOG_RCP_Receipt_Position_DiscountAmount
                        {
                            LOG_RCP_Receipt_Position_DiscountAmountID = Guid.NewGuid(),
                            LOG_RCP_Receipt_Position_RefID = Parameter.PositionID,
                            ORD_PRC_DiscountType_RefID = item.ORD_PRC_DiscountTypeID,

                            Tenant_RefID = securityTicket.TenantID
                        };
                    }

                    discountAmount.PositionDiscountValue = paramDiscount.Amount;
                    discountAmount.Save(Connection, Transaction);
                }
            }

            if (Parameter.SaveNaturalRabatForAllPos)
            {
                foreach (var currentPosID in positionIDs)
                {
                    if (currentPosID != Parameter.PositionID)
                    {
                        var posDiscounts = ORM_LOG_RCP_Receipt_Position_DiscountAmount.Query.Search(Connection, Transaction,
                        new ORM_LOG_RCP_Receipt_Position_DiscountAmount.Query
                        {
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            LOG_RCP_Receipt_Position_RefID = currentPosID
                        }
                        ).ToArray();

                        //Preload discount types and choose those that are applying to stock reciept positions
                        var discountTypesPar = new P_L2DT_GDTfGPMIL_1546();
                        discountTypesPar.GlobalPropertyMatchingID_List = new string[] 
                                {
                                    EnumUtils.GetEnumDescription(EDiscountType.NaturalDiscount)
                                };
                        var discNaturalType = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(Connection, Transaction, discountTypesPar, securityTicket).Result;

                        ORM_LOG_RCP_Receipt_Position_DiscountAmount discountNatural = null;
                        foreach (var item in discNaturalType)
                        {
                            var paramDiscount = Parameter.PositionDiscounts.SingleOrDefault(x => x.DiscountTypeID == discNaturalType.First().ORD_PRC_DiscountTypeID);
                            if (paramDiscount == null)
                            {
                                continue;
                            }

                            discountNatural = posDiscounts.SingleOrDefault(x => x.ORD_PRC_DiscountType_RefID == discNaturalType.First().ORD_PRC_DiscountTypeID);
                            if (discountNatural == null)
                            {
                                discountNatural = new ORM_LOG_RCP_Receipt_Position_DiscountAmount
                                {
                                    LOG_RCP_Receipt_Position_DiscountAmountID = Guid.NewGuid(),
                                    ORD_PRC_DiscountType_RefID = item.ORD_PRC_DiscountTypeID,
                                    LOG_RCP_Receipt_Position_RefID = currentPosID,
                                    Tenant_RefID = securityTicket.TenantID,
                                    Creation_Timestamp = DateTime.Now,
                                    IsDeleted = false
                                };
                            }

                            discountNatural.PositionDiscountValue = paramDiscount.Amount;
                            discountNatural.Save(Connection, Transaction);                        
                        }
                    }
                }
            }

            //just forwarding the input value
            returnValue.Result = Parameter.PositionID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5SR_SRP_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5SR_SRP_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_SRP_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_SRP_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_StockReceiptPosition",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5SR_SRP_1141 for attribute P_L5SR_SRP_1141
		[DataContract]
		public class P_L5SR_SRP_1141 
		{
			[DataMember]
			public P_L5SR_SRP_1141a[] PositionDiscounts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid PositionID { get; set; } 
			[DataMember]
			public double PositionValue { get; set; } 
			[DataMember]
			public bool SaveNaturalRabatForAllPos { get; set; } 

		}
		#endregion
		#region SClass P_L5SR_SRP_1141a for attribute PositionDiscounts
		[DataContract]
		public class P_L5SR_SRP_1141a 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiscountTypeID { get; set; } 
			[DataMember]
			public Double Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_StockReceiptPosition(,P_L5SR_SRP_1141 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_StockReceiptPosition.Invoke(connectionString,P_L5SR_SRP_1141 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5SR_SRP_1141();
parameter.PositionDiscounts = ...;

parameter.PositionID = ...;
parameter.PositionValue = ...;
parameter.SaveNaturalRabatForAllPos = ...;

*/
