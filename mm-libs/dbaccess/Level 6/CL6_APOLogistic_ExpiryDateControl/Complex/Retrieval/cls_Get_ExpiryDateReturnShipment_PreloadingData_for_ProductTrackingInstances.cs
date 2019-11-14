/* 
 * Generated on 10/24/2014 5:59:24 PM
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
using CL3_Warehouse.Atomic.Retrieval;
using CL3_Articles.Atomic.Retrieval;

namespace CL6_APOLogistic_ExpiryDateControl.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ExpiryDateReturnShipment_PreloadingData_for_ProductTrackingInstances.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ExpiryDateReturnShipment_PreloadingData_for_ProductTrackingInstances
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6ED_GEDRSPDfPTI_1649_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6ED_GEDRSPDfPTI_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L6ED_GEDRSPDfPTI_1649_Array();

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
                UseProductTrackingInstanceIDList = true,
                ProductTrackingInstanceIDs = Parameter.ProductTrackingInstanceIdList,
                StartExpirationDate = null,
                EndExpirationDate = null
            };

            var resultStoragePlaces = cls_Get_StoragePlaces_for_FilterCriteria.Invoke(Connection, Transaction, filterCriteria, securityTicket);
            if (resultStoragePlaces.Status != FR_Status.Success || resultStoragePlaces.Result == null || resultStoragePlaces.Result.Count() <= 0)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = new L6ED_GEDRSPDfPTI_1649[] { };
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

            #region Set Result

            var groupingCriterias = resultStoragePlaces.Result.Select(i=> new {ProductID = i.Product_RefID, BatchNumber = i.BatchNumber, ExpirationDate = i.ExpirationDate}).Distinct();

            var result = new List<L6ED_GEDRSPDfPTI_1649>();
            foreach (var groupingCriteria in groupingCriterias)
            {
                var trackingInstances = resultStoragePlaces.Result.Where(i => i.Product_RefID == groupingCriteria.ProductID && i.BatchNumber == groupingCriteria.BatchNumber && i.ExpirationDate == groupingCriteria.ExpirationDate).ToList();

                result.Add(new L6ED_GEDRSPDfPTI_1649()
                {
                    FakeID = Guid.NewGuid(), //this is important, because we don't have unique criteria for id on Front
                    Article = articles.FirstOrDefault(a => a.CMN_PRO_ProductID == groupingCriteria.ProductID),
                    BachNumber = groupingCriteria.BatchNumber,
                    ExpiryDate = groupingCriteria.ExpirationDate,
                    TrackingInstances = trackingInstances.Select(i=> new L6ED_GEDRSPDfPTI_1649a(){
                        ProductTrackingInstanceID = i.LOG_ProductTrackingInstanceID,
                        ReceiptPositionID = Guid.Empty,
                        ShelfContentID = i.LOG_WRH_Shelf_ContentID,
                        SupplierID = Guid.Empty,
                        SupplierName = "",
                        ReturnableQuantity = 10,
                        PricePerUnit = 0
                    }).ToArray()
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
		public static FR_L6ED_GEDRSPDfPTI_1649_Array Invoke(string ConnectionString,P_L6ED_GEDRSPDfPTI_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6ED_GEDRSPDfPTI_1649_Array Invoke(DbConnection Connection,P_L6ED_GEDRSPDfPTI_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6ED_GEDRSPDfPTI_1649_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6ED_GEDRSPDfPTI_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6ED_GEDRSPDfPTI_1649_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6ED_GEDRSPDfPTI_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6ED_GEDRSPDfPTI_1649_Array functionReturn = new FR_L6ED_GEDRSPDfPTI_1649_Array();
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

				throw new Exception("Exception occured in method cls_Get_ExpiryDateReturnShipment_PreloadingData_for_ProductTrackingInstances",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6ED_GEDRSPDfPTI_1649_Array : FR_Base
	{
		public L6ED_GEDRSPDfPTI_1649[] Result	{ get; set; } 
		public FR_L6ED_GEDRSPDfPTI_1649_Array() : base() {}

		public FR_L6ED_GEDRSPDfPTI_1649_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6ED_GEDRSPDfPTI_1649 for attribute P_L6ED_GEDRSPDfPTI_1649
		[DataContract]
		public class P_L6ED_GEDRSPDfPTI_1649 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ProductTrackingInstanceIdList { get; set; } 

		}
		#endregion
		#region SClass L6ED_GEDRSPDfPTI_1649 for attribute L6ED_GEDRSPDfPTI_1649
		[DataContract]
		public class L6ED_GEDRSPDfPTI_1649 
		{
			[DataMember]
			public L6ED_GEDRSPDfPTI_1649a[] TrackingInstances { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid FakeID { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 Article { get; set; } 
			[DataMember]
			public String BachNumber { get; set; } 
			[DataMember]
			public DateTime ExpiryDate { get; set; } 

		}
		#endregion
		#region SClass L6ED_GEDRSPDfPTI_1649a for attribute TrackingInstances
		[DataContract]
		public class L6ED_GEDRSPDfPTI_1649a 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductTrackingInstanceID { get; set; } 
			[DataMember]
			public Guid ReceiptPositionID { get; set; } 
			[DataMember]
			public Guid ShelfContentID { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public String SupplierName { get; set; } 
			[DataMember]
			public int ReturnableQuantity { get; set; } 
			[DataMember]
			public int ReturnQuantity { get; set; } 
			[DataMember]
			public Decimal PricePerUnit { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6ED_GEDRSPDfPTI_1649_Array cls_Get_ExpiryDateReturnShipment_PreloadingData_for_ProductTrackingInstances(,P_L6ED_GEDRSPDfPTI_1649 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6ED_GEDRSPDfPTI_1649_Array invocationResult = cls_Get_ExpiryDateReturnShipment_PreloadingData_for_ProductTrackingInstances.Invoke(connectionString,P_L6ED_GEDRSPDfPTI_1649 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ExpiryDateControl.Complex.Retrieval.P_L6ED_GEDRSPDfPTI_1649();
parameter.ProductTrackingInstanceIdList = ...;

*/
