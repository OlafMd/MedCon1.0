/* 
 * Generated on 4/11/2014 5:47:10 PM
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
using CL3_ShippingOrder.Complex.Manipulation;
using CL3_ShippingOrder.Complex.Retrieval;
using CSV2Core.Core;
using System.Runtime.Serialization;
using DLCore_DBCommons.APODemand;
using DLCore_DBCommons.Utils;
using CL2_NumberRange.Complex.Retrieval;

namespace CL5_APOBackoffice_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_ShipmentHeader_for_CustomerOrderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_ShipmentHeader_for_CustomerOrderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_CSHfCO_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Get CustomerOrderHeader

            var customerOrderHeader = new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Header();
            customerOrderHeader.Load(Connection, Transaction, Parameter.CustomerOrderHeaderID);

            #endregion

            var incrNumberParam = new P_L2NR_GaIINfUA_1454()
            {
                GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.ShipmentNumber)
            };
            var shipmentHeaderNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, incrNumberParam, securityTicket).Result.Current_IncreasingNumber;

            var shipmentHeader = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Header();
            shipmentHeader.LOG_SHP_Shipment_HeaderID = Guid.NewGuid();
            shipmentHeader.ShipmentHeader_Number = shipmentHeaderNumber;
            shipmentHeader.Tenant_RefID = securityTicket.TenantID;
            shipmentHeader.IsPartiallyReadyForPicking = false;
            shipmentHeader.IsReadyForPicking = false;
            shipmentHeader.HasPickingFinished = false;
            shipmentHeader.HasPickingStarted = false;
            shipmentHeader.IsShipped = false;
            shipmentHeader.IsBilled = false;
            shipmentHeader.IsPartialShippingAllowed = true;
            shipmentHeader.ShipmentHeader_Currency_RefID = customerOrderHeader.CustomerOrder_Currency_RefID;
            shipmentHeader.RecipientBusinessParticipant_RefID = customerOrderHeader.OrderingCustomer_BusinessParticipant_RefID;
            shipmentHeader.Shippipng_AddressUCD_RefID = customerOrderHeader.ShippingAddressUCD_RefID;
            shipmentHeader.Save(Connection, Transaction);

            if (shipmentHeader.Shippipng_AddressUCD_RefID == Guid.Empty)
            {
                var AllAddressForShipmentHeader =
                    cls_Get_AllAddresses_for_ShipmentHeaderID.Invoke(Connection, Transaction,
                        new P_L3SO_GAAfSHI_1612 {ShipmentHeaderID = shipmentHeader.LOG_SHP_Shipment_HeaderID},
                        securityTicket).Result.ToList();

                var defaultAddressForOU = AllAddressForShipmentHeader.Where(x=> x.hasOrganizationUnit).SingleOrDefault(x => x.IsDefault);
                if (defaultAddressForOU != null) shipmentHeader.Shippipng_AddressUCD_RefID =  cls_Save_Address_for_ShipmentHeaderID.Invoke(Connection, Transaction,
                    new P_L3SO_SA_f_SHI_1535
                    {
                        LOG_SHP_Shipment_HeaderID = shipmentHeader.LOG_SHP_Shipment_HeaderID,
                        StreetName = defaultAddressForOU.Street_Name,
                        StreetNumber = defaultAddressForOU.Street_Number,
                        Town = defaultAddressForOU.Town,
                        ZIP = defaultAddressForOU.ZIP,
                        IsCompany = defaultAddressForOU.IsCompany
                    }, securityTicket).Result;
                else
                {
                    var defaultAddressForCustomer =
                        AllAddressForShipmentHeader.Where(x => !x.hasOrganizationUnit && x.IsCompany && x.IsShipping).SingleOrDefault(x => x.IsDefault);
                    if (defaultAddressForCustomer != null)
                        shipmentHeader.Shippipng_AddressUCD_RefID = cls_Save_Address_for_ShipmentHeaderID.Invoke(Connection, Transaction,
                    new P_L3SO_SA_f_SHI_1535
                    {
                        LOG_SHP_Shipment_HeaderID = shipmentHeader.LOG_SHP_Shipment_HeaderID,
                        StreetName = defaultAddressForCustomer.Street_Name,
                        StreetNumber = defaultAddressForCustomer.Street_Number,
                        Town = defaultAddressForCustomer.Town,
                        ZIP = defaultAddressForCustomer.ZIP,
                        IsCompany = defaultAddressForCustomer.IsCompany
                    }, securityTicket).Result;
                    else
                    {
                        var defaultPersonAddress = AllAddressForShipmentHeader.Where(x => !x.IsCompany).SingleOrDefault(x => x.IsDefault);
                        if (defaultPersonAddress != null)
                            shipmentHeader.Shippipng_AddressUCD_RefID = cls_Save_Address_for_ShipmentHeaderID.Invoke(Connection, Transaction,
                        new P_L3SO_SA_f_SHI_1535
                        {
                            LOG_SHP_Shipment_HeaderID = shipmentHeader.LOG_SHP_Shipment_HeaderID,
                            StreetName = defaultPersonAddress.Street_Name,
                            StreetNumber = defaultPersonAddress.Street_Number,
                            Town = defaultPersonAddress.Town,
                            ZIP = defaultPersonAddress.ZIP,
                            IsCompany = defaultPersonAddress.IsCompany
                        }, securityTicket).Result;
                    }
                }
            }

            

            var shipmentToCustomerOrderHeader = new CL1_LOG_SHP.ORM_LOG_SHP_ShipmentHeader_2_CustomerOrderHeader();
            shipmentToCustomerOrderHeader.ORD_CUO_CustomerOrder_Header_RefID = Parameter.CustomerOrderHeaderID;
            shipmentToCustomerOrderHeader.LOG_SHP_Shipment_Header_RefID = shipmentHeader.LOG_SHP_Shipment_HeaderID;
            shipmentToCustomerOrderHeader.Tenant_RefID = securityTicket.TenantID;
            shipmentToCustomerOrderHeader.Save(Connection, Transaction);

            #region Status

            #region Get Current Account

            var account = new CL1_USR.ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            #endregion

            var statusCreated = CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query.Search(Connection, Transaction,
                 new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_Status.Query()
                 {
                     GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Created),
                     Tenant_RefID = securityTicket.TenantID,
                     IsDeleted = false
                 }).Single();

            var shipmentStatusHistory = new CL1_LOG_SHP.ORM_LOG_SHP_Shipment_StatusHistory();
            shipmentStatusHistory.LOG_SHP_Shipment_Header_RefID = shipmentHeader.LOG_SHP_Shipment_HeaderID;
            shipmentStatusHistory.LOG_SHP_Shipment_Status_RefID = statusCreated.LOG_SHP_Shipment_StatusID;
            shipmentStatusHistory.PerformedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            shipmentStatusHistory.Tenant_RefID = (account == null) ? Guid.Empty : account.Tenant_RefID;
            shipmentStatusHistory.Save(Connection, Transaction);

            #endregion

            returnValue.Result = shipmentHeader.LOG_SHP_Shipment_HeaderID;
			return returnValue;
			#endregion UserCode
		}

        
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CO_CSHfCO_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CO_CSHfCO_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_CSHfCO_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_CSHfCO_1528 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Create_ShipmentHeader_for_CustomerOrderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CO_CSHfCO_1528 for attribute P_L5CO_CSHfCO_1528
		[DataContract]
		public class P_L5CO_CSHfCO_1528 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_ShipmentHeader_for_CustomerOrderID(,P_L5CO_CSHfCO_1528 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_ShipmentHeader_for_CustomerOrderID.Invoke(connectionString,P_L5CO_CSHfCO_1528 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_CSHfCO_1528();
parameter.CustomerOrderHeaderID = ...;

*/
