/* 
 * Generated on 10/16/2014 10:19:31 AM
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
using CL3_Articles.Atomic.Retrieval;
using CL3_APOStatistic.Complex.Retrieval;
using CL6_APOLogistic_ExpiryDateControl.Atomic.Retrieval;
using CL3_Warehouse.Atomic.Retrieval;

namespace CL6_APOLogistic_ExpiryDateControl.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ProductTrackingInstance_with_Articles_and_Suppliers.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ProductTrackingInstance_with_Articles_and_Suppliers
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6ED_GPTIwAaS_0816_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6ED_GPTIwAaS_0816 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6ED_GPTIwAaS_0816_Array();

            #region Get Storage Places
            var filterCriteria = new P_L3WH_GSPfFC_1504()
            {
                WarehouseGroupID = null,
                WarehouseID = null,
                AreaID = null,
                RackID = null,
                UseShelfIDList = false,
                ShelfIDs = new Guid[] { Guid.Empty },
                UseProductIDList = false,
                ProductIDs = new Guid[] { Guid.Empty },
                BottomShelfQuantity = 1,
                TopShelfQuantity = null,
                UseProductTrackingInstanceIDList = Parameter.ProductTrackingInstanceIds != null,
                ProductTrackingInstanceIDs = Parameter.ProductTrackingInstanceIds == null
                    ? new Guid[] { Guid.Empty } : Parameter.ProductTrackingInstanceIds,
                StartExpirationDate = Parameter.StartDate,
                EndExpirationDate = Parameter.EndDate
            };
            var resultStoragePlaces = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(
                Connection,
                Transaction,
                filterCriteria,
                securityTicket);

            if (resultStoragePlaces.Status != FR_Status.Success || resultStoragePlaces.Result == null || resultStoragePlaces.Result.Count() == 0)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = new L6ED_GPTIwAaS_0816[] { };
                return returnValue;
            }
            #endregion

            #region Get Articles
            var parameterProductIds = new P_L3AR_GAfAL_0942();
            parameterProductIds.ProductID_List = resultStoragePlaces.Result.Select(rsp => rsp.Product_RefID).Distinct().ToArray<Guid>();
            var articles = new L3AR_GAfAL_0942[0];
            if (parameterProductIds.ProductID_List.Length != 0)
            {
                articles = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, parameterProductIds, securityTicket).Result;
            }
            #endregion

            #region Get Supplier
            var parameterProductsBatchNumbers = new P_L6ED_GSRtTIbBNaP_1353();
            parameterProductsBatchNumbers.ProductIDs = parameterProductIds.ProductID_List;
            parameterProductsBatchNumbers.BatchNumbers = resultStoragePlaces.Result.Select(rsp => rsp.BatchNumber).Distinct().ToArray<string>();
            var resultSuppliers = cls_Get_StockReceipt_through_TrackingInstance_by_BatchNumbers_and_ProductIDs.Invoke(Connection, Transaction, parameterProductsBatchNumbers, securityTicket);
            if (resultSuppliers.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = new L6ED_GPTIwAaS_0816[] { };
                return returnValue;
            }
            #endregion

            #region Get MSR
            Guid[] productIds = articles.Select(x => x.CMN_PRO_ProductID).ToArray();
            var msrForProducts = cls_Get_MSR_for_ProductIDList.Invoke(
                Connection, 
                Transaction, 
                new P_L3AS_GSMRfPL_1508 { ProductIDList = productIds }, 
                securityTicket
            ).Result;
            #endregion


            #region Set Result
            var result = new List<L6ED_GPTIwAaS_0816>();
            foreach (var storagePlace in resultStoragePlaces.Result)
            {
                var suppliers = resultSuppliers.Result
                    .Where(rs => rs.BatchNumber == storagePlace.BatchNumber && rs.ReceiptPosition_Product_RefID == storagePlace.Product_RefID)
                    .GroupBy(s => s.SupplierId, (key, group) => group.First());

                var msrForProduct = msrForProducts.SingleOrDefault(x => x.ProductID == storagePlace.Product_RefID);

                result.Add(new L6ED_GPTIwAaS_0816()
                {
                    StoragePlaces = storagePlace,
                    Article = articles.FirstOrDefault(a => a.CMN_PRO_ProductID == storagePlace.Product_RefID),
                    Suppliers = suppliers.ToArray(),
                    MSR = (msrForProduct != null) ? msrForProduct.MSR : 0.0
                });

            }
            returnValue.Result = result.ToArray();
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
		public static FR_L6ED_GPTIwAaS_0816_Array Invoke(string ConnectionString,P_L6ED_GPTIwAaS_0816 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6ED_GPTIwAaS_0816_Array Invoke(DbConnection Connection,P_L6ED_GPTIwAaS_0816 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6ED_GPTIwAaS_0816_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6ED_GPTIwAaS_0816 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6ED_GPTIwAaS_0816_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6ED_GPTIwAaS_0816 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6ED_GPTIwAaS_0816_Array functionReturn = new FR_L6ED_GPTIwAaS_0816_Array();
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

				throw new Exception("Exception occured in method cls_Get_ProductTrackingInstance_with_Articles_and_Suppliers",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6ED_GPTIwAaS_0816_Array : FR_Base
	{
		public L6ED_GPTIwAaS_0816[] Result	{ get; set; } 
		public FR_L6ED_GPTIwAaS_0816_Array() : base() {}

		public FR_L6ED_GPTIwAaS_0816_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6ED_GPTIwAaS_0816 for attribute P_L6ED_GPTIwAaS_0816
		[DataContract]
		public class P_L6ED_GPTIwAaS_0816 
		{
			//Standard type parameters
			[DataMember]
			public DateTime StartDate { get; set; } 
			[DataMember]
			public DateTime EndDate { get; set; } 
			[DataMember]
			public Guid[] ProductTrackingInstanceIds { get; set; } 

		}
		#endregion
		#region SClass L6ED_GPTIwAaS_0816 for attribute L6ED_GPTIwAaS_0816
		[DataContract]
		public class L6ED_GPTIwAaS_0816 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public CL3_Warehouse.Atomic.Retrieval.L3WH_GSPfFC_1504 StoragePlaces { get; set; } 
			[DataMember]
			public L6ED_GSRtTIbBNaP_1353[] Suppliers { get; set; } 
			[DataMember]
			public double MSR { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6ED_GPTIwAaS_0816_Array cls_Get_ProductTrackingInstance_with_Articles_and_Suppliers(,P_L6ED_GPTIwAaS_0816 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6ED_GPTIwAaS_0816_Array invocationResult = cls_Get_ProductTrackingInstance_with_Articles_and_Suppliers.Invoke(connectionString,P_L6ED_GPTIwAaS_0816 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ExpiryDateControl.Complex.Retrieval.P_L6ED_GPTIwAaS_0816();
parameter.StartDate = ...;
parameter.EndDate = ...;
parameter.ProductTrackingInstanceIds = ...;

*/
