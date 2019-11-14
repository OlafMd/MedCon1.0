/* 
 * Generated on 6/11/2014 10:43:48 AM
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
using System.Runtime.Serialization;
using CL1_ORD_PRC;
using CL3_Warehouse.Atomic.Retrieval;
using CL3_Price.Complex.Retrieval;
using CL3_Articles.Atomic.Retrieval;

namespace CL3_ProcurementOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProcurementOrderPositions_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProcurementOrderPositions_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PO_GPOPfH_1015_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L3PO_GPOPfH_1015_Array();

            #region Get Procurement Order Positions
            var procurementOrderPositions = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction
                , new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                {
                    ProcurementOrder_Header_RefID = Parameter.ProcurementOrderHeaderID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
            if (procurementOrderPositions == null || procurementOrderPositions.Count() <= 0)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            var productIds = procurementOrderPositions.Select(i => i.CMN_PRO_Product_RefID).Distinct().ToArray();
            #endregion

            #region Get Articles For ShipmentPositions
            var articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction
                , new P_L3AR_GAfAL_0942()
                {
                    ProductID_List = productIds
                }
                , securityTicket).Result;
            #endregion

            #region Get Available Product Quantities
            var shelfContents = cls_Get_CurrentShelfContents_and_ActiveReservations_for_ProductIDList.Invoke(Connection, Transaction
                , new P_L3WH_GCSCaARfP_1835()
                {
                    ProductIDList = productIds
                }
                , securityTicket).Result.ToList();
            #endregion

            #region Get AEK Price
            var aekPrices = cls_Get_StandardPrices_for_ProductIDList.Invoke(Connection, Transaction
                , new P_L3PR_GSPfPIL_1645()
                {
                    ProductIDList = productIds
                }
                , securityTicket).Result;
            #endregion

            #region Set Result
            var results = new List<L3PO_GPOPfH_1015>();
            foreach (var pop in procurementOrderPositions)
            {
                var position = new L3PO_GPOPfH_1015a()
                {
                    ProcurementOrderHeaderId = pop.ProcurementOrder_Header_RefID,
                    ProcurementOrderPositionId = pop.ORD_PRC_ProcurementOrder_PositionID,
                    CreationTimestamp = pop.Creation_Timestamp,
                    PositionQuantity = pop.Position_Quantity,
                    PositionValuePerUnit = pop.Position_ValuePerUnit,
                    PositionValueTotal = pop.Position_ValueTotal,
                    QuantityInStock = shelfContents.Where(sc => sc.Product_RefID == pop.CMN_PRO_Product_RefID).Single().CurrentQuantity,
                    AEKPrice = aekPrices.Where(ap => ap.ProductID == pop.CMN_PRO_Product_RefID).Single().AbdaPrice
                };
                results.Add(new L3PO_GPOPfH_1015()
                {
                    Position = position,
                    Article = articles.Where(a => a.CMN_PRO_ProductID == pop.CMN_PRO_Product_RefID).Single()
                });
            }
            returnValue.Result = results.ToArray();
            returnValue.Status = FR_Status.Success;
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3PO_GPOPfH_1015_Array Invoke(string ConnectionString,P_L3PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PO_GPOPfH_1015_Array Invoke(DbConnection Connection,P_L3PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PO_GPOPfH_1015_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PO_GPOPfH_1015_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PO_GPOPfH_1015 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PO_GPOPfH_1015_Array functionReturn = new FR_L3PO_GPOPfH_1015_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProcurementOrderPositions_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PO_GPOPfH_1015_Array : FR_Base
	{
		public L3PO_GPOPfH_1015[] Result	{ get; set; } 
		public FR_L3PO_GPOPfH_1015_Array() : base() {}

		public FR_L3PO_GPOPfH_1015_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PO_GPOPfH_1015 for attribute P_L3PO_GPOPfH_1015
		[DataContract]
		public class P_L3PO_GPOPfH_1015 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L3PO_GPOPfH_1015 for attribute L3PO_GPOPfH_1015
		[DataContract]
		public class L3PO_GPOPfH_1015 
		{
			[DataMember]
			public L3PO_GPOPfH_1015a Position { get; set; }

			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 

		}
		#endregion
		#region SClass L3PO_GPOPfH_1015a for attribute Position
		[DataContract]
		public class L3PO_GPOPfH_1015a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderHeaderId { get; set; } 
			[DataMember]
			public Guid ProcurementOrderPositionId { get; set; } 
			[DataMember]
			public double PositionQuantity { get; set; } 
			[DataMember]
			public decimal PositionValuePerUnit { get; set; } 
			[DataMember]
			public decimal PositionValueTotal { get; set; } 
			[DataMember]
			public decimal AEKPrice { get; set; } 
			[DataMember]
			public DateTime CreationTimestamp { get; set; } 
			[DataMember]
			public double QuantityInStock { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PO_GPOPfH_1015_Array cls_Get_ProcurementOrderPositions_for_HeaderID(,P_L3PO_GPOPfH_1015 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PO_GPOPfH_1015_Array invocationResult = cls_Get_ProcurementOrderPositions_for_HeaderID.Invoke(connectionString,P_L3PO_GPOPfH_1015 Parameter,securityTicket);
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
var parameter = new CL3_ProcurementOrder.Complex.Retrieval.P_L3PO_GPOPfH_1015();
parameter.ProcurementOrderHeaderID = ...;

*/
