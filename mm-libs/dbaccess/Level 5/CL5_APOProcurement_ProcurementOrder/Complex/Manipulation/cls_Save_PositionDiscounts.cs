/* 
 * Generated on 3/9/2014 03:03:00
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
using CL1_ORD_PRC;
using DLCore_DBCommons.APODemand;
using CL2_DiscountType.Atomic.Retrieval;
using DLCore_DBCommons.Utils;

namespace CL5_APOProcurement_ProcurementOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_PositionDiscounts.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_PositionDiscounts
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_SPD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guids();
			//Put your code here

            List<Guid> discountGuidList = new List<Guid>();

            if (Parameter.Discounts != null)
            {
                List<Guid> positionIDs = new List<Guid>();

                if (Parameter.SaveNaturalDiscountForAllPositions)
                {
                    var position = new ORM_ORD_PRC_ProcurementOrder_Position();
                    position.Load(Connection, Transaction, Parameter.ProcurementOrderPositionID);
                    var headerID = position.ProcurementOrder_Header_RefID;

                    var headerPositions = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction,
                        new ORM_ORD_PRC_ProcurementOrder_Position.Query { 
                            Tenant_RefID = securityTicket.TenantID,
                            IsDeleted = false,
                            ProcurementOrder_Header_RefID = headerID
                        }).ToList();

                    positionIDs.AddRange(headerPositions.Select(x => x.ORD_PRC_ProcurementOrder_PositionID));
                }

                var positionDiscounts = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query.Search(Connection, Transaction,
                    new ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query
                    {
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false,
                        ORD_PRC_ProcurementOrder_Position_RefID = Parameter.ProcurementOrderPositionID
                    }
                    ).ToArray();

                //Preload discount types and choose those that are applying to stock reciept positions
                var discountTypesParam = new P_L2DT_GDTfGPMIL_1546();
                discountTypesParam.GlobalPropertyMatchingID_List = new string[] 
                {
                    EnumUtils.GetEnumDescription(EDiscountType.MainDiscount),
                    EnumUtils.GetEnumDescription(EDiscountType.Discount2),
                    EnumUtils.GetEnumDescription(EDiscountType.Discount3),
                    EnumUtils.GetEnumDescription(EDiscountType.NaturalDiscount)
                };
                var discountTypes = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(Connection, Transaction, discountTypesParam, securityTicket).Result;

                ORM_ORD_PRC_ProcurementOrder_Position_Discount discount = null;
                foreach (var item in discountTypes)
                {
                    var paramDiscount = Parameter.Discounts.SingleOrDefault(x => x.DiscountTypeID == item.ORD_PRC_DiscountTypeID);
                    if (paramDiscount == null)
                    {
                        continue;
                    }

                    discount = positionDiscounts.SingleOrDefault(x => x.ORD_PRC_DiscountType_RefID == item.ORD_PRC_DiscountTypeID);
                    if (discount == null)
                    {
                        discount = new ORM_ORD_PRC_ProcurementOrder_Position_Discount
                        {
                            ORD_PRC_ProcurementOrder_Position_DiscountID = Guid.NewGuid(),
                            ORD_PRC_DiscountType_RefID = item.ORD_PRC_DiscountTypeID,
                            ORD_PRC_ProcurementOrder_Position_RefID = Parameter.ProcurementOrderPositionID,
                            Tenant_RefID = securityTicket.TenantID,
                            Creation_Timestamp = DateTime.Now,
                            IsDeleted = false
                        };
                    }

                    discount.DiscountValue = paramDiscount.DiscountValue;
                    discount.Save(Connection, Transaction);

                    discountGuidList.Add(discount.ORD_PRC_ProcurementOrder_Position_DiscountID);
                }
                
                //if SaveNaturalDiscountForAllPositions, change discount value for natural discount for all positions of procurement header
                if (Parameter.SaveNaturalDiscountForAllPositions)
                {
                    foreach (var currentPosID in positionIDs)
                    {
                        if (currentPosID != Parameter.ProcurementOrderPositionID)
                        {
                            var posDiscounts = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query.Search(Connection, Transaction,
                            new ORM_ORD_PRC_ProcurementOrder_Position_Discount.Query
                            {
                                Tenant_RefID = securityTicket.TenantID,
                                IsDeleted = false,
                                ORD_PRC_ProcurementOrder_Position_RefID = currentPosID
                            }
                            ).ToArray();

                            //Preload discount types and choose those that are applying to stock reciept positions
                            var discountTypesPar = new P_L2DT_GDTfGPMIL_1546();
                            discountTypesPar.GlobalPropertyMatchingID_List = new string[] 
                            {
                                EnumUtils.GetEnumDescription(EDiscountType.NaturalDiscount)
                            };
                            var discNaturalType = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(Connection, Transaction, discountTypesPar, securityTicket).Result;

                            ORM_ORD_PRC_ProcurementOrder_Position_Discount discountNatural = null;
                            foreach (var item in discNaturalType)
                            {
                                var paramDiscount = Parameter.Discounts.SingleOrDefault(x => x.DiscountTypeID == discNaturalType.First().ORD_PRC_DiscountTypeID);
                                if (paramDiscount == null)
                                {
                                    continue;
                                }

                                discountNatural = posDiscounts.SingleOrDefault(x => x.ORD_PRC_DiscountType_RefID == discNaturalType.First().ORD_PRC_DiscountTypeID);
                                if (discountNatural == null)
                                {
                                    discountNatural = new ORM_ORD_PRC_ProcurementOrder_Position_Discount
                                    {
                                        ORD_PRC_ProcurementOrder_Position_DiscountID = Guid.NewGuid(),
                                        ORD_PRC_DiscountType_RefID = item.ORD_PRC_DiscountTypeID,
                                        ORD_PRC_ProcurementOrder_Position_RefID = currentPosID,
                                        Tenant_RefID = securityTicket.TenantID,
                                        Creation_Timestamp = DateTime.Now,
                                        IsDeleted = false
                                    };
                                }

                                discountNatural.DiscountValue = paramDiscount.DiscountValue;
                                discountNatural.Save(Connection, Transaction);

                                discountGuidList.Add(discount.ORD_PRC_ProcurementOrder_Position_DiscountID);
                            }
                        }
                    }
                }

            }

            returnValue.Result = discountGuidList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L5PO_SPD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L5PO_SPD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_SPD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_SPD_1148 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Save_PositionDiscounts",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PO_SPD_1148 for attribute P_L5PO_SPD_1148
		[DataContract]
		public class P_L5PO_SPD_1148 
		{
			[DataMember]
			public L5PO_SPD_1148a[] Discounts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderPositionID { get; set; } 
			[DataMember]
			public bool SaveNaturalDiscountForAllPositions { get; set; } 

		}
		#endregion
		#region SClass L5PO_SPD_1148a for attribute Discounts
		[DataContract]
		public class L5PO_SPD_1148a 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiscountTypeID { get; set; } 
			[DataMember]
			public double DiscountValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_PositionDiscounts(,P_L5PO_SPD_1148 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_PositionDiscounts.Invoke(connectionString,P_L5PO_SPD_1148 Parameter,securityTicket);
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
var parameter = new CL5_APOProcurement_ProcurementOrder.Complex.Manipulation.P_L5PO_SPD_1148();
parameter.Discounts = ...;

parameter.ProcurementOrderPositionID = ...;
parameter.SaveNaturalDiscountForAllPositions = ...;

*/
