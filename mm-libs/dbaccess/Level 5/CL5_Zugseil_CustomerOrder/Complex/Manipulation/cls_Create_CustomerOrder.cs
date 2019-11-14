/* 
 * Generated on 3/3/2015 11:34:35
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
using CL1_ORD_CUO;
using CL1_CMN;
using DLCore_MessageListener.Messages.Zugseil;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.Zugseil;
using CL3_Variant.Atomic.Retrieval;
using CL3_Product.Atomic.Retrieval;

namespace CL5_Zugseil_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_CustomerOrder.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_CustomerOrder
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_CCO_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            //Find status
            var status = ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction, new ORM_ORD_CUO_CustomerOrder_Status.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(ECustomerOrderStatus.Ordered),
                IsDeleted = false
            }).SingleOrDefault();

            //Find currency
            var currency = ORM_CMN_Currency.Query.Search(Connection, Transaction, new ORM_CMN_Currency.Query() { 
                Tenant_RefID = securityTicket.TenantID,
                ISO4127 = Parameter.ProcurementOrderHeader.CurrencyISOCode.Trim()
            });

			//Put your code here
            ORM_ORD_CUO_CustomerOrder_Header customerOrderHeader = new ORM_ORD_CUO_CustomerOrder_Header();
            customerOrderHeader.ORD_CUO_CustomerOrder_HeaderID = Guid.NewGuid();
            customerOrderHeader.ProcurementOrderITL = Parameter.ProcurementOrderHeader.ProcurementOrderID.ToString();
            customerOrderHeader.CustomerOrder_Number = Parameter.ProcurementOrderHeader.OrderNumber;
            customerOrderHeader.CustomerOrder_Date = DateTime.Now;
            customerOrderHeader.OrderingCustomer_BusinessParticipant_RefID = Parameter.ProcurementOrderHeader.OrderingCustomerBusinessParticipantID;
            customerOrderHeader.CreatedBy_BusinessParticipant_RefID = Parameter.ProcurementOrderHeader.CreatedByBusinessParticipantID;
            customerOrderHeader.TotalValue_BeforeTax = Parameter.ProcurementOrderHeader.TotalValueBeforeTax;
            customerOrderHeader.Current_CustomerOrderStatus_RefID = status.ORD_CUO_CustomerOrder_StatusID;
            customerOrderHeader.Tenant_RefID = securityTicket.TenantID;
            //This should be changed when we figure out what to do with currencies that don't exist in s-adm database
            customerOrderHeader.CustomerOrder_Currency_RefID = (currency != null && currency.Count == 1) ? currency.First().CMN_CurrencyID : Guid.Empty;
            customerOrderHeader.Save(Connection, Transaction);

            ORM_ORD_CUO_CustomerOrder_StatusHistory statusHistory = new ORM_ORD_CUO_CustomerOrder_StatusHistory();
            statusHistory.ORD_CUO_CustomerOrder_StatusHistoryID = Guid.NewGuid();
            statusHistory.CustomerOrder_Status_RefID = status.ORD_CUO_CustomerOrder_StatusID;
            statusHistory.CustomerOrder_Header_RefID = customerOrderHeader.ORD_CUO_CustomerOrder_HeaderID;
            statusHistory.Tenant_RefID = securityTicket.TenantID; 
            statusHistory.Save(Connection, Transaction);

            //Get products and product variants for ITL Lists
            var productIDList = Parameter.ProcurementOrderHeader.Positions.Select(x => x.ProductRefID.ToString()).ToArray();
            L3PR_GPfPITL_1416[] products = null;
            if (productIDList != null && productIDList.Count() > 0)
                products = cls_Get_Producs_for_ProductITLList.Invoke(Connection, Transaction, new P_L3PR_GPfPITL_1416() { ProductITLList = productIDList }, securityTicket).Result;

            var variantIDList = Parameter.ProcurementOrderHeader.Positions.Select(x => x.ProductVariantRefID.ToString()).ToArray();
            L3PV_GPVfVITL_1421[] variants = null;
            if (variantIDList != null && variantIDList.Count() > 0)
                variants = cls_Get_ProductVariants_for_VariantITLList.Invoke(Connection, new P_L3PV_GPVfVITL_1421() { VariantITLList = variantIDList }, securityTicket).Result;

            foreach (var position in Parameter.ProcurementOrderHeader.Positions)
            {
                var newPosition = new ORM_ORD_CUO_CustomerOrder_Position();
                newPosition.ORD_CUO_CustomerOrder_PositionID = Guid.NewGuid();
                newPosition.CustomerProcurementOrderPositionITL = position.ProcurementOrderPositionID.ToString();
                newPosition.CustomerOrder_Header_RefID = customerOrderHeader.ORD_CUO_CustomerOrder_HeaderID;
                newPosition.Position_OrdinalNumber = position.OridinalNumber;
                newPosition.Position_Quantity = position.Quantity;
                newPosition.Position_ValuePerUnit = position.ValuePerunit;
                newPosition.Position_ValueTotal = position.ValueTotal;
                newPosition.Position_Comment = position.Comment;
                newPosition.Position_Description = position.Description;
                newPosition.IsProductReplacementAllowed = position.IsProductReplacementAllowed;
                newPosition.CMN_PRO_Product_RefID = products.Where(x => x.ProductITL == position.ProductRefID.ToString()).First().CMN_PRO_ProductID;
                newPosition.CMN_PRO_Product_Variant_RefID = variants.Where(x => x.ProductVariantITL == position.ProductVariantRefID.ToString()).First().CMN_PRO_Product_VariantID;
                newPosition.Tenant_RefID = securityTicket.TenantID;
                newPosition.Save(Connection, Transaction);

                foreach (var custom in position.PositionCustomizations)
                {
                    ORM_ORD_CUO_CustomerOrder_Position_Customization customization = new ORM_ORD_CUO_CustomerOrder_Position_Customization();
                    customization.ORD_CUO_CustomerOrder_Position_CustomizationID = Guid.NewGuid();
                    customization.Tenant_RefID = securityTicket.TenantID;
                    customization.CustomerOrder_Position_RefID = newPosition.ORD_CUO_CustomerOrder_PositionID;
                    customization.Customization_Name = custom.CustomizationName;
                    customization.CustomizationVariant_Name = custom.CustomizationVariantName;
                    customization.ValuePerUnit = custom.ValuePerUnit;
                    customization.ValueTotal = custom.ValueTotal;
                    customization.Save(Connection, Transaction);
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5CO_CCO_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5CO_CCO_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_CCO_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_CCO_1950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Create_CustomerOrder",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_CCO_1950 for attribute P_L5CO_CCO_1950
		[DataContract]
		public class P_L5CO_CCO_1950 
		{
			//Standard type parameters
			[DataMember]
			public ProcurementOrderHeader ProcurementOrderHeader { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Create_CustomerOrder(,P_L5CO_CCO_1950 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Create_CustomerOrder.Invoke(connectionString,P_L5CO_CCO_1950 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_CustomerOrder.Complex.Manipulation.P_L5CO_CCO_1950();
parameter.ProcurementOrderHeader = ...;

*/
