/* 
 * Generated on 6/4/2014 11:15:56 AM
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
using CL1_CMN_POS;
using CL1_CMN_BPT_CTM;
using CL2_NumberRange.Complex.Retrieval;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;

namespace CL5_APOBackoffice_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomerOrderReturnHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomerOrderReturnHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_SCORH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Guid();

            var returnHeader = new ORM_ORD_CUO_CustomerOrderReturn_Header();
            ORM_CMN_POS_CustomerInteraction customerInteraction = null;

            if (Parameter.CustomerOrderReturnHeaderID == Guid.Empty)
            {
                #region Preload data

                var incrNumberParam = new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.CustomerReturnNumber)
                };
                var customerReturnNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;


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

                var customerId = ORM_CMN_BPT_CTM_Customer.Query.Search(
                    Connection,
                    Transaction,
                    new ORM_CMN_BPT_CTM_Customer.Query() { 
                        Ext_BusinessParticipant_RefID = Parameter.Customer_BusinessParticipantID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).Single().CMN_BPT_CTM_CustomerID;
                #endregion

                #region Customer Order Return Header Creation
                returnHeader = new ORM_ORD_CUO_CustomerOrderReturn_Header
                {
                    ORD_CUO_CustomerOrderReturn_HeaderID = Guid.NewGuid(),
                    Tenant_RefID = securityTicket.TenantID,
                    Creation_Timestamp = DateTime.Now,
                    Customer_RefID = customerId,
                    CustomerOrderReturnNumber = customerReturnNumber,
                    TotalValueBeforeTax = Parameter.TotalValueBeforeTax,
                    Currency_RefID = Parameter.CurencyId,
                    Customer_BillingAddressUCD_RefID = Parameter.Customer_BillingAddressUCD_RefID
                };
                #endregion

                #region Create or Update CustomerInteraction
                if (Parameter.CustomerInteractionsId == Guid.Empty) 
                {
                    var incrCustIntrNumberParam = new P_L2NR_GaIINfUA_1454()
                    {
                        GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.CustomerInteractionNumber)
                    };
                    var customerInteractionNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrCustIntrNumberParam, securityTicket).Result.Current_IncreasingNumber;

                    customerInteraction = new ORM_CMN_POS_CustomerInteraction()
                    {
                        CMN_POS_CustomerInteractionID = Guid.NewGuid(),
                        Creation_Timestamp = DateTime.Now,
                        IsCustomerOrderReturnInteraction = true,
                        CustomerOrderReturnHeader_RefID = returnHeader.ORD_CUO_CustomerOrderReturn_HeaderID,
                        CustomerInteractionNumber = customerInteractionNumber,
                        DateOfCustomerInteraction = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID
                    };
                    customerInteraction.Save(Connection, Transaction);
                }
                else
                {
                    customerInteraction = ORM_CMN_POS_CustomerInteraction.Query.Search(
                        Connection,
                        Transaction,
                        new ORM_CMN_POS_CustomerInteraction.Query()
                        {
                            CMN_POS_CustomerInteractionID = Parameter.CustomerInteractionsId,
                            IsDeleted = false,
                            Tenant_RefID = securityTicket.TenantID
                        }).FirstOrDefault();
                    customerInteraction.CustomerOrderReturnHeader_RefID = returnHeader.ORD_CUO_CustomerOrderReturn_HeaderID;
                    customerInteraction.IsCustomerOrderReturnInteraction = true;
                    customerInteraction.Save(Connection, Transaction);
                }
                #endregion
            }
            else
            {
                var fetched = returnHeader.Load(Connection, Transaction, Parameter.CustomerOrderReturnHeaderID);
                if (fetched.Status != FR_Status.Success || returnHeader.ORD_CUO_CustomerOrderReturn_HeaderID != Parameter.CustomerOrderReturnHeaderID)
                {
                    returnValue.ErrorMessage = fetched.ErrorMessage;
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = Guid.Empty;
                    return returnValue;
                }

                #region Update Customer Order Total Value
                var returnPositions = ORM_ORD_CUO_CustomerOrderReturn_Position.Query.Search(
                    Connection, 
                    Transaction,
                    new ORM_ORD_CUO_CustomerOrderReturn_Position.Query
                    {
                        CustomerOrderReturnHeader_RefID = Parameter.CustomerOrderReturnHeaderID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
                returnHeader.TotalValueBeforeTax = returnPositions.Sum(x => x.Position_ValueTotal);
                #endregion
            }

            returnHeader.DateOfCustomerReturn = Parameter.DateOfCustomerReturn;
            returnHeader.Save(Connection, Transaction);

            returnValue.Result = returnHeader.ORD_CUO_CustomerOrderReturn_HeaderID;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CO_SCORH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CO_SCORH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_SCORH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_SCORH_1326 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CustomerOrderReturnHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_SCORH_1326 for attribute P_L5CO_SCORH_1326
		[DataContract]
		public class P_L5CO_SCORH_1326 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderReturnHeaderID { get; set; } 
			[DataMember]
			public Guid Customer_BusinessParticipantID { get; set; } 
			[DataMember]
			public DateTime DateOfCustomerReturn { get; set; } 
			[DataMember]
			public Guid CustomerInteractionsId { get; set; } 
			[DataMember]
			public Guid ReceiptHeaderId { get; set; } 
			[DataMember]
			public Guid Customer_BillingAddressUCD_RefID { get; set; } 
			[DataMember]
			public Guid CurencyId { get; set; } 
			[DataMember]
			public decimal TotalValueBeforeTax { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CustomerOrderReturnHeader(,P_L5CO_SCORH_1326 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CustomerOrderReturnHeader.Invoke(connectionString,P_L5CO_SCORH_1326 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_SCORH_1326();
parameter.CustomerOrderReturnHeaderID = ...;
parameter.Customer_BusinessParticipantID = ...;
parameter.DateOfCustomerReturn = ...;
parameter.CustomerInteractionsId = ...;
parameter.ReceiptHeaderId = ...;
parameter.Customer_BillingAddressUCD_RefID = ...;
parameter.CurencyId = ...;
parameter.TotalValueBeforeTax = ...;

*/
