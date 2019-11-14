/* 
 * Generated on 3/6/2014 4:31:15 PM
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
using Core_ClassLibrarySupport.Lucentis;
using CL6_Lucenits_Products.Atomic.Retrieval;
using CL1_HEC;

namespace CL6_Lucenits_Treatments.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_and_Order_QuickTreatments_with_ProcurementOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_and_Order_QuickTreatments_with_ProcurementOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6TR_SaOQTwPO_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            P_L6TR_SQT_1308 param = new P_L6TR_SQT_1308();
            param = Parameter.QuickTreatment;

            Guid TreatmentID = cls_Save_Quick_Treatment.Invoke(Connection, Transaction, param, securityTicket).Result;

            #region Save Order

            var status_query = new ORM_ORD_PRC_ProcurementOrder_Status.Query();
            status_query.IsDeleted = false;
            status_query.Tenant_RefID = securityTicket.TenantID;
            status_query.GlobalPropertyMatchingID = STLD_ORD_CUO_CustomerOrder_Status.Ordered.ToString();
            var notOrderedstatus = ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, status_query).First();

            var prod_param = new P_L6PD_GPaPOSfT_1702();
            prod_param.TreatmentID = TreatmentID;
            var products = cls_Get_Product_and_ProcurementOrderStatuses_for_TreatmentID.Invoke(Connection, Transaction, prod_param, securityTicket).Result;

            var notOrdered_Products = products.Where(i => i.BoundTo_ProcurementOrderPosition_RefID == Guid.Empty);

            if (notOrdered_Products.Count() == 0)
                return returnValue;

            #region Save Header and Status

            var header_query = new ORM_ORD_PRC_ProcurementOrder_Header.Query();
            header_query.IsDeleted = false;
            header_query.Tenant_RefID = securityTicket.TenantID;
            var headers = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction, header_query);

            var count = 0;
            if (headers != null)
                count = headers.Count();

            String ordernumber = "000000000000" + (count + 1).ToString();
            ordernumber = ordernumber.Substring(ordernumber.Length - 12);

            var header = new ORM_ORD_PRC_ProcurementOrder_Header();
            header.ORD_PRC_ProcurementOrder_HeaderID = Guid.NewGuid();
            header.Current_ProcurementOrderStatus_RefID = notOrderedstatus.ORD_PRC_ProcurementOrder_StatusID;
            header.ProcurementOrder_Number = ordernumber;
            header.ProcurementOrder_Date = DateTime.Now;
            header.Creation_Timestamp = DateTime.Now;
            header.Tenant_RefID = securityTicket.TenantID;
            header.Save(Connection, Transaction);

            var history = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
            history.ORD_PRC_ProcurementOrder_StatusHistoryID = Guid.NewGuid();
            history.ProcurementOrder_Header_RefID = header.ORD_PRC_ProcurementOrder_HeaderID;
            history.ProcurementOrder_Status_RefID = notOrderedstatus.ORD_PRC_ProcurementOrder_StatusID;
            history.StatusHistoryComment = "";
            history.Creation_Timestamp = DateTime.Now;
            history.Tenant_RefID = securityTicket.TenantID;
            history.Save(Connection, Transaction);


            #endregion

            int cnt = 0;

            foreach (var product in notOrdered_Products)
            {
                cnt++;

                var position = new ORM_ORD_PRC_ProcurementOrder_Position();
                position.ORD_PRC_ProcurementOrder_PositionID = Guid.NewGuid();
                position.ProcurementOrder_Header_RefID = header.ORD_PRC_ProcurementOrder_HeaderID;
                position.Position_OrdinalNumber = cnt;
                position.Position_Quantity = product.Quantity;
                position.Position_ValuePerUnit = 1;
                position.Position_ValueTotal = decimal.Parse(product.Quantity.ToString());
                position.CMN_PRO_Product_Variant_RefID = Guid.Empty;
                position.CMN_PRO_Product_RefID = product.CMN_PRO_ProductID;
                position.CMN_PRO_Product_Release_RefID = Guid.Empty;
                position.Position_RequestedDateOfDelivery = product.ExpectedDateOfDelivery;
                position.Creation_Timestamp = DateTime.Now;
                position.Tenant_RefID = securityTicket.TenantID;
                position.Save(Connection, Transaction);


                var item = new ORM_HEC_Patient_Treatment_RequiredProduct();
                item.Load(Connection, Transaction, product.HEC_Patient_Treatment_RequiredProductID);
                item.BoundTo_CustomerOrderPosition_RefID = position.ORD_PRC_ProcurementOrder_PositionID;
                item.Save(Connection, Transaction);
            }

            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6TR_SaOQTwPO_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6TR_SaOQTwPO_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6TR_SaOQTwPO_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6TR_SaOQTwPO_1620 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_and_Order_QuickTreatments_with_ProcurementOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6TR_SaOQTwPO_1620 for attribute P_L6TR_SaOQTwPO_1620
		[DataContract]
		public class P_L6TR_SaOQTwPO_1620 
		{
			//Standard type parameters
			[DataMember]
			public P_L6TR_SQT_1308 QuickTreatment { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_and_Order_QuickTreatments_with_ProcurementOrder(,P_L6TR_SaOQTwPO_1620 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_and_Order_QuickTreatments_with_ProcurementOrder.Invoke(connectionString,P_L6TR_SaOQTwPO_1620 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Treatments.Complex.Manipulation.P_L6TR_SaOQTwPO_1620();
parameter.QuickTreatment = ...;

*/
