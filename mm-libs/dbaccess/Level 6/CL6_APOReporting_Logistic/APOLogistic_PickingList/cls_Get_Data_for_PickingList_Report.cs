/* 
 * Generated on 22.10.2014 15:16:35
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
using CL1_LOG_SHP;
using CL1_CMN_BPT;
using CL1_CMN_BPT_CTM;
using CL6_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL5_APOLogistic_ShippingOrder.Atomic.Retrieval;


namespace CL6_APOReporting_Logistic.APOLogistic_PickingList
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_for_PickingList_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_for_PickingList_Report
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LG_GDfPLR_0956 Execute(DbConnection Connection,DbTransaction Transaction,P_L6LG_GDfPLR_0956 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6LG_GDfPLR_0956();

            L5SO_GSaCOHDfSH_1446 shipmentAndCustomerOrderDetails = null;

            #region Retrieve Shipment and CustomerOrder Details

            P_L5SO_GSaCOHDfSH_1446 shipmentAndCustomerOrderDetailsParameter = new P_L5SO_GSaCOHDfSH_1446();
            shipmentAndCustomerOrderDetailsParameter.ShippingHeaderID = Parameter.ShipmentHeaderId;
            FR_L5SO_GSaCOHDfSH_1446 shipmentAndCustomerOrderDetailsResult = CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.cls_Get_Shipment_and_CustomerOrderHeaderDetails_for_ShipmentHeaderID.Invoke(Connection, Transaction, shipmentAndCustomerOrderDetailsParameter, securityTicket);
            shipmentAndCustomerOrderDetails = shipmentAndCustomerOrderDetailsResult.Result;

            #endregion

            #region Customer name

            var customerName = "";
            if (shipmentAndCustomerOrderDetails != null && shipmentAndCustomerOrderDetails.OrderingCustomer_BusinessParticipant_RefID != Guid.Empty)
            {
                ORM_CMN_BPT_BusinessParticipant bp = new ORM_CMN_BPT_BusinessParticipant();
                var bpResult = bp.Load(Connection, Transaction, shipmentAndCustomerOrderDetails.OrderingCustomer_BusinessParticipant_RefID);
                if (bpResult.Status == FR_Status.Success && bp.CMN_BPT_BusinessParticipantID != Guid.Empty)
                    customerName = bp.DisplayName;
                
            }

            #endregion

            #region CustomerAddress


            var CustomerAddress = CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.cls_Get_CustomerAddress_from_ShipmentHeaderID.Invoke(Connection, Transaction, new P_L5SO_GCAfSHI_1127 { ShipmentHeaderID = Parameter.ShipmentHeaderId }, securityTicket);
            

            #endregion

            #region Organisational unit

            Dict organizationalUnitName = null;
            if (shipmentAndCustomerOrderDetails != null && shipmentAndCustomerOrderDetails.CMN_BPT_CTM_OrganizationalUnit_RefID != Guid.Empty)
            {
                ORM_CMN_BPT_CTM_OrganizationalUnit orgUnit = new ORM_CMN_BPT_CTM_OrganizationalUnit();
                var orgUnitResult = orgUnit.Load(Connection, Transaction, shipmentAndCustomerOrderDetails.CMN_BPT_CTM_OrganizationalUnit_RefID);
                if (orgUnitResult.Status == FR_Status.Success && orgUnit.CMN_BPT_CTM_OrganizationalUnitID != Guid.Empty)
                    organizationalUnitName = orgUnit.OrganizationalUnit_Name;
            }

            #endregion

            L6SO_GASPbtWSvR_1413[] shipmentPositionsForPickingList = new L6SO_GASPbtWSvR_1413[0];

            #region Retrieve Shipment Positions with reservation details (including storage place)

            P_L6SO_GASPbtWSvR_1413 shipmentPositionsForPickingListParameter = new P_L6SO_GASPbtWSvR_1413();
            shipmentPositionsForPickingListParameter.ShipmentHeaderID = Parameter.ShipmentHeaderId;
            FR_L6SO_GASPbtWSvR_1413_Array shipmentPositionsForPickingListResult = cls_Get_AllShipmentPositions_bound_to_WarehouseStructure_via_Reservations.Invoke(Connection, Transaction, shipmentPositionsForPickingListParameter, securityTicket);
            shipmentPositionsForPickingList = shipmentPositionsForPickingListResult.Result;

            #endregion

            //
            // Taking product array from shipment positions previously retrieved. 
            // Product array is used for taking product information
            //

            Guid[] productIdArray = shipmentPositionsForPickingList.Select(x => x.CMN_PRO_Product_RefID).Distinct().ToArray();
        
            L3AR_GAfAL_0942[] articlesForArticleList = new L3AR_GAfAL_0942[0];
            if (productIdArray != null && productIdArray.Length > 0)
            {
                #region Retrive product details

                P_L3AR_GAfAL_0942 articlesForArticleListParameter = new P_L3AR_GAfAL_0942();
                articlesForArticleListParameter.ProductID_List = productIdArray;
                FR_L3AR_GAfAL_0942_Array articlesForArticleListResult = cls_Get_Articles_for_ArticleList.Invoke(Connection, Transaction, articlesForArticleListParameter, securityTicket);
                articlesForArticleList = articlesForArticleListResult.Result;
                articlesForArticleList = articlesForArticleList.OrderBy(x => x.Product_Name.Contents[0].Content).ToArray();
                
                #endregion
            }


            #region Shipment Notes

            List<ORM_LOG_SHP_Shipment_Note> shipmentNoteList = new List<ORM_LOG_SHP_Shipment_Note>();

            if (shipmentAndCustomerOrderDetails != null)
            {
                shipmentNoteList = ORM_LOG_SHP_Shipment_Note.Query
                    .Search(Connection, Transaction,
                        new ORM_LOG_SHP_Shipment_Note.Query { IsDeleted = false, Shipment_Header_RefID = Parameter.ShipmentHeaderId})
                    .OrderBy(i => i.Creation_Timestamp).ToList();
            }

            List<L6LG_GDfPLR_0956b> commentList = new List<L6LG_GDfPLR_0956b>();
            foreach (ORM_LOG_SHP_Shipment_Note shipmentNote in shipmentNoteList)
            {
                L6LG_GDfPLR_0956b comment = new L6LG_GDfPLR_0956b();

                ORM_CMN_BPT_BusinessParticipant businessParticipant = new ORM_CMN_BPT_BusinessParticipant();
                FR_Base bpLoad = businessParticipant.Load(Connection, Transaction, shipmentNote.CreatedBy_BusinessParticipant_RefID);
                if (bpLoad.Status == FR_Status.Success)
                {
                    comment.Name = businessParticipant.DisplayName;
                }
                comment.Comment = shipmentNote.Comment;
                commentList.Add(comment);
            }

            #endregion


            #region Building return object

            List<L6LG_GDfPLR_0956a> tempShipmentPositions = new List<L6LG_GDfPLR_0956a>();

            foreach (L6SO_GASPbtWSvR_1413 shipmentPositionForPickingList in shipmentPositionsForPickingList)
            {
                L6LG_GDfPLR_0956a tempShipmentPosition = new L6LG_GDfPLR_0956a();
                tempShipmentPosition.ShipmentPositionDetails = shipmentPositionForPickingList;
                tempShipmentPosition.ProductDetails = articlesForArticleList.FirstOrDefault(a => a.CMN_PRO_ProductID == shipmentPositionForPickingList.CMN_PRO_Product_RefID);
                tempShipmentPositions.Add(tempShipmentPosition);
            }

            returnValue.Result = new L6LG_GDfPLR_0956();
            returnValue.Result.CustomerName = customerName;
            returnValue.Result.StreetAndNumber = CustomerAddress.Result != null ? CustomerAddress.Result.Street_Name + " " + CustomerAddress.Result.Street_Number : "keine Kundenadresse";
            returnValue.Result.ZIPAndCity = CustomerAddress.Result != null ? CustomerAddress.Result.ZIP + " " + CustomerAddress.Result.Town : "keine Kundenadresse";
            returnValue.Result.OrganizationalUnitName = organizationalUnitName;
            returnValue.Result.ShipmentPositionList = tempShipmentPositions.ToArray();
            returnValue.Result.ShipmentAndCustomerOrderDetails = shipmentAndCustomerOrderDetails;
            returnValue.Result.CommentList = commentList.ToArray();

            #endregion

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LG_GDfPLR_0956 Invoke(string ConnectionString,P_L6LG_GDfPLR_0956 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LG_GDfPLR_0956 Invoke(DbConnection Connection,P_L6LG_GDfPLR_0956 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LG_GDfPLR_0956 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LG_GDfPLR_0956 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LG_GDfPLR_0956 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LG_GDfPLR_0956 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LG_GDfPLR_0956 functionReturn = new FR_L6LG_GDfPLR_0956();
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

				throw new Exception("Exception occured in method cls_Get_Data_for_PickingList_Report",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LG_GDfPLR_0956 : FR_Base
	{
		public L6LG_GDfPLR_0956 Result	{ get; set; }

		public FR_L6LG_GDfPLR_0956() : base() {}

		public FR_L6LG_GDfPLR_0956(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6LG_GDfPLR_0956 for attribute P_L6LG_GDfPLR_0956
		[DataContract]
		public class P_L6LG_GDfPLR_0956 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderId { get; set; } 
			[DataMember]
			public Guid TenantId { get; set; } 

		}
		#endregion
		#region SClass L6LG_GDfPLR_0956 for attribute L6LG_GDfPLR_0956
		[DataContract]
		public class L6LG_GDfPLR_0956 
		{
			[DataMember]
			public L6LG_GDfPLR_0956a[] ShipmentPositionList { get; set; }
			[DataMember]
			public L6LG_GDfPLR_0956b[] CommentList { get; set; }

			//Standard type parameters
			[DataMember]
			public string CustomerName { get; set; } 
			[DataMember]
			public string StreetAndNumber { get; set; } 
			[DataMember]
			public string ZIPAndCity { get; set; } 
			[DataMember]
			public Dict OrganizationalUnitName { get; set; } 
			[DataMember]
			public CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.L5SO_GSaCOHDfSH_1446 ShipmentAndCustomerOrderDetails { get; set; } 

		}
		#endregion
		#region SClass L6LG_GDfPLR_0956a for attribute ShipmentPositionList
		[DataContract]
		public class L6LG_GDfPLR_0956a 
		{
			//Standard type parameters
			[DataMember]
			public CL6_APOLogistic_ShippingOrder.Atomic.Retrieval.L6SO_GASPbtWSvR_1413 ShipmentPositionDetails { get; set; } 
			[DataMember]
			public CL3_Articles.Atomic.Retrieval.L3AR_GAfAL_0942 ProductDetails { get; set; } 

		}
		#endregion
		#region SClass L6LG_GDfPLR_0956b for attribute CommentList
		[DataContract]
		public class L6LG_GDfPLR_0956b 
		{
			//Standard type parameters
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String Comment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LG_GDfPLR_0956 cls_Get_Data_for_PickingList_Report(,P_L6LG_GDfPLR_0956 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LG_GDfPLR_0956 invocationResult = cls_Get_Data_for_PickingList_Report.Invoke(connectionString,P_L6LG_GDfPLR_0956 Parameter,securityTicket);
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
var parameter = new CL6_APOReporting_Logistic.APOLogistic_PickingList.P_L6LG_GDfPLR_0956();
parameter.ShipmentHeaderId = ...;
parameter.TenantId = ...;

*/
