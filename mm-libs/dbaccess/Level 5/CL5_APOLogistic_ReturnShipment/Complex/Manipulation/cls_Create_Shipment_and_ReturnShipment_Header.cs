/* 
 * Generated on 7/23/2014 3:24:53 PM
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
using CL1_LOG_SHP;
using CL2_Currency.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;
using CL1_USR;
using CL2_NumberRange.Complex.Retrieval;

namespace CL5_APOLogistic_ReturnShipment.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Shipment_and_ReturnShipment_Header.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Shipment_and_ReturnShipment_Header
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RS_CSaRSH_0244 Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_CSaRSH_0244 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5RS_CSaRSH_0244();

            returnValue.Result = new L5RS_CSaRSH_0244();

            #region New ShipmentHeader
            var newShipmentHeaderId = Guid.NewGuid();

            #region Get Tenant Curency ID
            var defaultCurrency = cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;
            #endregion

            #region Create Shipment Status History
            #region Get 'Returned' Shipment status
            var returnedStatusId = ORM_LOG_SHP_Shipment_Status.Query.Search(
                Connection,
                Transaction,
                new ORM_LOG_SHP_Shipment_Status.Query()
                {
                    GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Returned),
                    Tenant_RefID = securityTicket.TenantID
                }).FirstOrDefault().LOG_SHP_Shipment_StatusID;
            #endregion

            #region Fetch Status History 'performed by' User Account
            var performedByAccount = new ORM_USR_Account();
            performedByAccount.Load(Connection, Transaction, securityTicket.AccountID);
            #endregion

            #region Get ShipmentHeader Number
            var shipmentHeaderNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(
                Connection,
                Transaction,
                new P_L2NR_GaIINfUA_1454() 
                {
                    GlobalStaticMatchingID = EnumUtils.GetEnumDescription(ENumberRangeUsageAreaType.SupplierReturnShipmentNumber)  
                },
                securityTicket).Result.Current_IncreasingNumber;
            #endregion

            var newShipmentStatusHistory = new ORM_LOG_SHP_Shipment_StatusHistory();
            newShipmentStatusHistory.Creation_Timestamp = DateTime.Now;
            newShipmentStatusHistory.IsDeleted = false;
            newShipmentStatusHistory.LOG_SHP_Shipment_Header_RefID = newShipmentHeaderId;
            newShipmentStatusHistory.LOG_SHP_Shipment_Status_RefID = returnedStatusId;
            newShipmentStatusHistory.LOG_SHP_Shipment_StatusHistoryID = Guid.NewGuid();
            newShipmentStatusHistory.PerformedBy_BusinessParticipant_RefID = 
                performedByAccount == null 
                ? Guid.Empty 
                : performedByAccount.BusinessParticipant_RefID;
            newShipmentStatusHistory.Tenant_RefID = securityTicket.TenantID;
            #endregion

            #region Create Shipment Header Object
            var newShipmentHeader = new ORM_LOG_SHP_Shipment_Header();
            newShipmentHeader.Creation_Timestamp = DateTime.Now;
            newShipmentHeader.LOG_SHP_Shipment_HeaderID = newShipmentHeaderId;
            newShipmentHeader.RecipientBusinessParticipant_RefID = Parameter.SupplierID;
            newShipmentHeader.ShipmentHeader_Currency_RefID = defaultCurrency.CMN_CurrencyID;
            newShipmentHeader.ShipmentHeader_Number = shipmentHeaderNumber;
            newShipmentHeader.ShipmentHeader_ValueWithoutTax = 0;
            newShipmentHeader.ShipmentPriority = 0;
            newShipmentHeader.ShipmentType_RefID = newShipmentStatusHistory.LOG_SHP_Shipment_StatusHistoryID;
            newShipmentHeader.Tenant_RefID = securityTicket.TenantID;
            #endregion
            #endregion

            #region New ReturnShipment Header
            var newReturnShipmentHeaderId = Guid.NewGuid();
            var newReturnShipmentHeader = new ORM_LOG_SHP_ReturnShipment_Header();
            newReturnShipmentHeader.Creation_Timestamp = DateTime.Now;
            newReturnShipmentHeader.Ext_Shipment_Header_RefID = newShipmentHeaderId;
            newReturnShipmentHeader.LOG_SHP_ReturnShipment_HeaderID = newReturnShipmentHeaderId;
            newReturnShipmentHeader.Tenant_RefID = securityTicket.TenantID;
            #endregion

            #region Save
            var resultHistory = newShipmentStatusHistory.Save(Connection, Transaction);
            var resultHeader = newShipmentHeader.Save(Connection, Transaction);
            var resultShipmentHeader = newReturnShipmentHeader.Save(Connection, Transaction);
            if (resultHistory.Status != FR_Status.Success || resultHeader.Status != FR_Status.Success || resultShipmentHeader.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
            }
            else
            {
                returnValue.Status = FR_Status.Success;
                returnValue.Result.ShipmentHeaderID = newShipmentHeaderId;
                returnValue.Result.ShipmentHeaderNumber = newShipmentHeader.ShipmentHeader_Number;
                returnValue.Result.ReturnShipmentHeaderID = newReturnShipmentHeaderId;
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
		public static FR_L5RS_CSaRSH_0244 Invoke(string ConnectionString,P_L5RS_CSaRSH_0244 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RS_CSaRSH_0244 Invoke(DbConnection Connection,P_L5RS_CSaRSH_0244 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RS_CSaRSH_0244 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_CSaRSH_0244 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RS_CSaRSH_0244 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_CSaRSH_0244 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RS_CSaRSH_0244 functionReturn = new FR_L5RS_CSaRSH_0244();
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

				throw new Exception("Exception occured in method cls_Create_Shipment_and_ReturnShipment_Header",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5RS_CSaRSH_0244 : FR_Base
	{
		public L5RS_CSaRSH_0244 Result	{ get; set; }

		public FR_L5RS_CSaRSH_0244() : base() {}

		public FR_L5RS_CSaRSH_0244(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5RS_CSaRSH_0244 for attribute P_L5RS_CSaRSH_0244
		[DataContract]
		public class P_L5RS_CSaRSH_0244 
		{
			//Standard type parameters
			[DataMember]
			public Guid SupplierID { get; set; } 

		}
		#endregion
		#region SClass L5RS_CSaRSH_0244 for attribute L5RS_CSaRSH_0244
		[DataContract]
		public class L5RS_CSaRSH_0244 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShipmentHeaderID { get; set; } 
			[DataMember]
			public string ShipmentHeaderNumber { get; set; } 
			[DataMember]
			public Guid ReturnShipmentHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RS_CSaRSH_0244 cls_Create_Shipment_and_ReturnShipment_Header(,P_L5RS_CSaRSH_0244 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5RS_CSaRSH_0244 invocationResult = cls_Create_Shipment_and_ReturnShipment_Header.Invoke(connectionString,P_L5RS_CSaRSH_0244 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Complex.Manipulation.P_L5RS_CSaRSH_0244();
parameter.SupplierID = ...;

*/
