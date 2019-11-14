/* 
 * Generated on 8/12/2014 3:16:14 PM
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
using CL5_APOLogistic_StockReceipt.Atomic.Retrieval;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOLogistic_StockReceipt.Complex.Retrieval
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Get_Filter_StockReceipt_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Get_Filter_StockReceipt_for_TenantID
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_L5SR_GFSRfT_1635 Execute(DbConnection Connection, DbTransaction Transaction, P_L5SR_GFSRfT_1635 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_L5SR_GFSRfT_1635();
            returnValue.Result = new L5SR_GFSRfT_1635();

            // if nothing has choosen then give nothing
            if (!Parameter.IsPriceConditionsManuallyCleared &&
                !Parameter.IsQualityControlPerformed &&
                !Parameter.IsReceiptForwardedToBookkeeping &&
                !Parameter.IsTakenIntoStock && !Parameter.IsErwartet)
            {

                returnValue.Result.StockReceipts = new L5ALSR_GSRfT_1016[0];
                return returnValue;
            }

            #region NoStatus StockReceipts

            var parameterForAll = new P_L5ALSR_GSRfT_1016
            {
                SupplierName = Parameter.SupplierName,
                ReceiptNumber = Parameter.ReceiptNumber,
                ProcurementOrderNumber = Parameter.ProcurementOrderNumber,
                DateFrom = Parameter.DateFrom,
                DateTo = Parameter.DateTo,
                SupplierTypeID = Parameter.SupplierTypeID
            };

            var AllList = new List<L5ALSR_GSRfT_1016>();

            // if we choose only those hwo doesn't have any status
            if ((Parameter.IsPriceConditionsManuallyCleared == false &&
                Parameter.IsQualityControlPerformed == false &&
                Parameter.IsReceiptForwardedToBookkeeping == false &&
                Parameter.IsTakenIntoStock == false) || Parameter.IsErwartet)
            {
                parameterForAll.IsPriceConditionsManuallyCleared = false;
                parameterForAll.IsQualityControlPerformed = false;
                parameterForAll.IsReceiptForwardedToBookkeeping = false;
                parameterForAll.IsTakenIntoStock = false;

                var listWithoutStatus =
                cls_Get_StockReceipts_for_TenantID.Invoke(Connection, Transaction, parameterForAll, securityTicket)
                    .Result.ToList();
                // add distinct members
                AllList.AddRange(listWithoutStatus.Where(x => !AllList.Select(y => y.LOG_RCP_Receipt_HeaderID).Contains(x.LOG_RCP_Receipt_HeaderID)));

            }

            #endregion

            #region QualityControlPerformed StockReceipts

            if (Parameter.IsQualityControlPerformed)
            {

                parameterForAll.IsQualityControlPerformed = true;
                parameterForAll.IsTakenIntoStock = false;
                parameterForAll.IsPriceConditionsManuallyCleared = false;
                parameterForAll.IsReceiptForwardedToBookkeeping = false;

                var listQuantityControl = cls_Get_StockReceipts_for_TenantID.Invoke(Connection, Transaction, parameterForAll, securityTicket)
                    .Result.ToList();
                if (listQuantityControl.Any())
                    // add distinct members
                    AllList.AddRange(listQuantityControl.Where(x => !AllList.Select(y => y.LOG_RCP_Receipt_HeaderID).Contains(x.LOG_RCP_Receipt_HeaderID)));
            }

            #endregion

            #region TakenIntoStock StockReceipts

            if (Parameter.IsTakenIntoStock)
            {
                parameterForAll.IsQualityControlPerformed = null;
                parameterForAll.IsTakenIntoStock = true;
                parameterForAll.IsPriceConditionsManuallyCleared = false;
                parameterForAll.IsReceiptForwardedToBookkeeping = false;

                var listTakenIntoStock = cls_Get_StockReceipts_for_TenantID.Invoke(Connection, Transaction, parameterForAll, securityTicket)
                    .Result.ToList();
                if (listTakenIntoStock.Any())
                    // add distinct members
                    AllList.AddRange(listTakenIntoStock.Where(x => !AllList.Select(y => y.LOG_RCP_Receipt_HeaderID).Contains(x.LOG_RCP_Receipt_HeaderID)));
            }

            #endregion

            #region PriceConditionsManuallyCleared StockReceipts

            if (Parameter.IsPriceConditionsManuallyCleared)
            {
                parameterForAll.IsQualityControlPerformed = null;
                parameterForAll.IsTakenIntoStock = null;
                parameterForAll.IsPriceConditionsManuallyCleared = true;
                parameterForAll.IsReceiptForwardedToBookkeeping = true;

                var listPriceConditions = cls_Get_StockReceipts_for_TenantID.Invoke(Connection, Transaction, parameterForAll, securityTicket)
                    .Result.ToList();
                if (listPriceConditions.Any())
                    // add distinct members
                    AllList.AddRange(listPriceConditions.Where(x => !AllList.Select(y => y.LOG_RCP_Receipt_HeaderID).Contains(x.LOG_RCP_Receipt_HeaderID)));
            }

            #endregion

            #region ForwardedToBookkeeping StockReceipts

            if (Parameter.IsReceiptForwardedToBookkeeping)
            {
                parameterForAll.IsQualityControlPerformed = null;
                parameterForAll.IsTakenIntoStock = null;
                parameterForAll.IsPriceConditionsManuallyCleared = null;
                parameterForAll.IsReceiptForwardedToBookkeeping = true;

                var listPriceConditions = cls_Get_StockReceipts_for_TenantID.Invoke(Connection, Transaction, parameterForAll, securityTicket)
                    .Result.ToList();
                if (listPriceConditions.Any())
                    // add distinct members
                    AllList.AddRange(listPriceConditions.Where(x => !AllList.Select(y => y.LOG_RCP_Receipt_HeaderID).Contains(x.LOG_RCP_Receipt_HeaderID)));
            }

            #endregion

            returnValue.Result.StockReceipts = new L5ALSR_GSRfT_1016[AllList.Count];
            returnValue.Result.StockReceipts = AllList.ToArray();

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_L5SR_GFSRfT_1635 Invoke(string ConnectionString, P_L5SR_GFSRfT_1635 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_L5SR_GFSRfT_1635 Invoke(DbConnection Connection, P_L5SR_GFSRfT_1635 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_L5SR_GFSRfT_1635 Invoke(DbConnection Connection, DbTransaction Transaction, P_L5SR_GFSRfT_1635 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_L5SR_GFSRfT_1635 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5SR_GFSRfT_1635 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_L5SR_GFSRfT_1635 functionReturn = new FR_L5SR_GFSRfT_1635();
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

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

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
                    if (cleanupTransaction == true && Transaction != null)
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

                throw new Exception("Exception occured in method cls_Get_Filter_StockReceipt_for_TenantID", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_L5SR_GFSRfT_1635 : FR_Base
    {
        public L5SR_GFSRfT_1635 Result { get; set; }

        public FR_L5SR_GFSRfT_1635() : base() { }

        public FR_L5SR_GFSRfT_1635(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_L5SR_GFSRfT_1635 for attribute P_L5SR_GFSRfT_1635
    [DataContract]
    public class P_L5SR_GFSRfT_1635
    {
        //Standard type parameters
        [DataMember]
        public string SupplierName { get; set; }
        [DataMember]
        public string ReceiptNumber { get; set; }
        [DataMember]
        public string ProcurementOrderNumber { get; set; }
        [DataMember]
        public DateTime? DateFrom { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
        [DataMember]
        public bool IsTakenIntoStock { get; set; }
        [DataMember]
        public bool IsQualityControlPerformed { get; set; }
        [DataMember]
        public bool IsPriceConditionsManuallyCleared { get; set; }
        [DataMember]
        public bool IsReceiptForwardedToBookkeeping { get; set; }
        [DataMember]
        public Guid? SupplierTypeID { get; set; }
        [DataMember]
        public bool IsErwartet { get; set; }

    }
    #endregion
    #region SClass L5SR_GFSRfT_1635 for attribute L5SR_GFSRfT_1635
    [DataContract]
    public class L5SR_GFSRfT_1635
    {
        //Standard type parameters
        [DataMember]
        public L5ALSR_GSRfT_1016[] StockReceipts { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GFSRfT_1635 cls_Get_Filter_StockReceipt_for_TenantID(,P_L5SR_GFSRfT_1635 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GFSRfT_1635 invocationResult = cls_Get_Filter_StockReceipt_for_TenantID.Invoke(connectionString,P_L5SR_GFSRfT_1635 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Retrieval.P_L5SR_GFSRfT_1635();
parameter.SupplierName = ...;
parameter.ReceiptNumber = ...;
parameter.ProcurementOrderNumber = ...;
parameter.DateFrom = ...;
parameter.DateTo = ...;
parameter.IsTakenIntoStock = ...;
parameter.IsQualityControlPerformed = ...;
parameter.IsPriceConditionsManuallyCleared = ...;
parameter.IsReceiptForwardedToBookkeeping = ...;
parameter.SupplierTypeID = ...;
parameter.IsErwartet = ...;

*/
