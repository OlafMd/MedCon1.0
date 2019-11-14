/* 
 * Generated on 7/28/2014 3:54:51 PM
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
using CL2_Currency.Atomic.Retrieval;
using CL1_CMN_POS;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL5_APOBackoffice_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomerOrderHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomerOrderHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_COH_1326 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_COH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5CO_COH_1326();
            returnValue.Result = new L5CO_COH_1326();

            var header = new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Header();
            ORM_CMN_POS_CustomerInteraction customerInteraction = null;

            if (Parameter.CustomerOrderHeaderID == Guid.Empty)
            {
                #region Preload data

                var incrNumberParam = new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.CustomerOrderNumber)
                };
                var customerOrderNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                var account = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction, new CL1_USR.ORM_USR_Account.Query
                {
                    USR_AccountID = securityTicket.AccountID,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

                var orderedStatusID = CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Status.Query.Search(Connection, Transaction,
                   new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Status.Query
                   {
                       GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.ECustomerOrderStatus.Ordered),
                       IsDeleted = false,
                       Tenant_RefID = securityTicket.TenantID
                   }).Single().ORD_CUO_CustomerOrder_StatusID;

                #endregion

                #region Customer Order Header Creation
                header = new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Header
                {
                    ORD_CUO_CustomerOrder_HeaderID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID,
                    Creation_Timestamp = DateTime.Now,
                    CreatedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID,
                    Current_CustomerOrderStatus_RefID = orderedStatusID,
                    CustomerOrder_Number = customerOrderNumber,
                    CustomerOrder_Currency_RefID = cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.CMN_CurrencyID
                };
                header.ProcurementOrderITL = Guid.Empty.ToString();
                header.TotalValue_BeforeTax = 0.0M;
                #endregion

                #region CustomerOrderStatusHistory
                var statusHistory = new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_StatusHistory
                {
                    ORD_CUO_CustomerOrder_StatusHistoryID = Guid.NewGuid(),
                    Creation_Timestamp = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID,
                    CustomerOrder_Header_RefID = header.ORD_CUO_CustomerOrder_HeaderID,
                    CustomerOrder_Status_RefID = orderedStatusID,
                    StatusHistoryComment = null,
                    PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID,
                };
                statusHistory.Save(Connection, Transaction);
                #endregion

                #region Create and Save CustomerInteraction

                var incrCustIntrNumberParam = new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.CustomerInteractionNumber)
                };
                var customerInteractionNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrCustIntrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                customerInteraction = new ORM_CMN_POS_CustomerInteraction()
                {
                    CMN_POS_CustomerInteractionID = Guid.NewGuid(),
                    Creation_Timestamp = DateTime.Now,
                    IsCustomerOrderInteraction = true,
                    CustomerOrderHeader_RefID = header.ORD_CUO_CustomerOrder_HeaderID,
                    CustomerInteractionNumber = customerInteractionNumber,
                    DateOfCustomerInteraction = DateTime.Now,
                    Tenant_RefID = securityTicket.TenantID
                };
                customerInteraction.Save(Connection, Transaction);

                #endregion
            }
            else
            {

                var fetched = header.Load(Connection, Transaction, Parameter.CustomerOrderHeaderID);
                if (fetched.Status != FR_Status.Success || header.ORD_CUO_CustomerOrder_HeaderID != Parameter.CustomerOrderHeaderID)
                {
                    returnValue.ErrorMessage = fetched.ErrorMessage;
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }

                #region Update Customer Order Total Value
                var positions = CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query.Search(Connection, Transaction,
                        new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query
                        {
                            CustomerOrder_Header_RefID = Parameter.CustomerOrderHeaderID,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        });
                header.TotalValue_BeforeTax = positions.Sum(x => x.Position_ValueTotal);
                #endregion

                #region Load CustomerInteraction
                customerInteraction = ORM_CMN_POS_CustomerInteraction.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_CMN_POS_CustomerInteraction.Query()
                    {
                        CustomerOrderHeader_RefID = header.ORD_CUO_CustomerOrder_HeaderID,
                        Tenant_RefID = securityTicket.TenantID
                    }).FirstOrDefault();
                #endregion
            }

            if (Parameter.OrganizationalUnitID != null)
            {
                Guid ucdID = Guid.Empty;

                //var ucd = CL1_CMN.ORM_CMN_UniversalContactDetail.Query.Search(Connection, Transaction,
                //    new CL1_CMN.ORM_CMN_UniversalContactDetail.Query
                //    {
                //        CMN_UniversalContactDetailID = ucdID,
                //        IsDeleted = false,
                //        Tenant_RefID = securityTicket.TenantID
                //    });
                // header.ShippingAddressUCD_RefID = 
            }

            header.CustomerOrder_Date = Parameter.CustomerOrderDate;
            header.DeliveryDeadline = Parameter.DeliveryDeadline;
            header.OrderingCustomer_BusinessParticipant_RefID = Parameter.Customer_BusinessParticipantID;
            header.Save(Connection, Transaction);

            returnValue.Result = new L5CO_COH_1326()
            {
                CustomerOrderHeaderId = header.ORD_CUO_CustomerOrder_HeaderID,
                CustomerInteractionsId = customerInteraction == null ? Guid.Empty : customerInteraction.CMN_POS_CustomerInteractionID
            };
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_COH_1326 Invoke(string ConnectionString,P_L5CO_COH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_COH_1326 Invoke(DbConnection Connection,P_L5CO_COH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_COH_1326 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_COH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_COH_1326 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_COH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_COH_1326 functionReturn = new FR_L5CO_COH_1326();
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

				throw new Exception("Exception occured in method cls_Save_CustomerOrderHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_COH_1326 : FR_Base
	{
		public L5CO_COH_1326 Result	{ get; set; }

		public FR_L5CO_COH_1326() : base() {}

		public FR_L5CO_COH_1326(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_COH_1326 for attribute P_L5CO_COH_1326
		[DataContract]
		public class P_L5CO_COH_1326 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public Guid Customer_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid PaymentTypeID { get; set; } 
			[DataMember]
			public DateTime CustomerOrderDate { get; set; } 
			[DataMember]
			public Guid ShipmentTypeID { get; set; } 
			[DataMember]
			public Guid OrganizationalUnitID { get; set; } 
			[DataMember]
			public DateTime DeliveryDeadline { get; set; } 

		}
		#endregion
		#region SClass L5CO_COH_1326 for attribute L5CO_COH_1326
		[DataContract]
		public class L5CO_COH_1326 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderId { get; set; } 
			[DataMember]
			public Guid CustomerInteractionsId { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_COH_1326 cls_Save_CustomerOrderHeader(,P_L5CO_COH_1326 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_COH_1326 invocationResult = cls_Save_CustomerOrderHeader.Invoke(connectionString,P_L5CO_COH_1326 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_COH_1326();
parameter.CustomerOrderHeaderID = ...;
parameter.Customer_BusinessParticipantID = ...;
parameter.PaymentTypeID = ...;
parameter.CustomerOrderDate = ...;
parameter.ShipmentTypeID = ...;
parameter.OrganizationalUnitID = ...;
parameter.DeliveryDeadline = ...;

*/
