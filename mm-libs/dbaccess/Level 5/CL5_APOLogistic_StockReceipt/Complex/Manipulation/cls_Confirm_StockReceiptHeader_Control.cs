/* 
 * Generated on 2/18/2014 12:33:03 PM
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
using CL1_LOG_RCP;
using CL5_APOLogistic_Storage.Atomic.Retrieval;
using CL1_LOG_WRH;

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Confirm_StockReceiptHeader_Control.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Confirm_StockReceiptHeader_Control
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_L5ALSR_CSRHC_1057 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            var item = new ORM_LOG_RCP_Receipt_Header();
            item.Load(Connection, Transaction, Parameter.LOG_RCP_Receipt_HeaderID);

            item.LOG_RCP_Receipt_HeaderID = Parameter.LOG_RCP_Receipt_HeaderID;
            item.IsQualityControlPerformed = true;
            item.QualityControlPerformed_AtDate = DateTime.Now;
            item.QualityControlPerformed_ByAccount_RefID = securityTicket.AccountID;

            item.Save(Connection, Transaction);

            returnValue.Result = item.LOG_RCP_Receipt_HeaderID;


            #region StockReceipt Positions

            var stockReceiptPositions = ORM_LOG_RCP_Receipt_Position.Query.Search(Connection, Transaction, new ORM_LOG_RCP_Receipt_Position.Query()
            {
                Receipt_Header_RefID = Parameter.LOG_RCP_Receipt_HeaderID,
                IsDeleted = false
            });

            foreach (var position in stockReceiptPositions)
            {
                Guid predefinedShelfID = Guid.Empty;

                #region First Criteria

                var predefinedShelf = ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf.Query
                {
                    Predefined_Product_RefID = position.ReceiptPosition_Product_RefID,
                    IsDeleted = false
                }).FirstOrDefault();

                #endregion

                if (predefinedShelf != null)
                {
                    predefinedShelfID = predefinedShelf.LOG_WRH_ShelfID;
                }
                else
                {
                    #region Second Criteria

                    var intakeArea = ORM_LOG_WRH_Area.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Area.Query
                    {
                        IsDefaultIntakeArea = true,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }).FirstOrDefault();

                    if (intakeArea != null)
                    {
                        var shelf =
                            ORM_LOG_WRH_Shelf.Query.Search(Connection, Transaction, new ORM_LOG_WRH_Shelf.Query
                            {
                                R_Area_RefID = intakeArea.LOG_WRH_AreaID,
                                IsDeleted = false
                            }).FirstOrDefault();

                        if (shelf != null)
                        {
                            predefinedShelfID = shelf.LOG_WRH_ShelfID;
                        }
                    }

                    #endregion
                }

                if (predefinedShelfID != Guid.Empty)
                {
                    ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query.Update(Connection, Transaction,
                        new ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query()
                        {
                            Receipt_Position_RefID = position.LOG_RCP_Receipt_PositionID,
                            IsDeleted = false
                        },
                        new ORM_LOG_RCP_Receipt_Position_QualityControlItem.Query()
                        {
                            Target_WRH_Shelf_RefID = predefinedShelfID
                    });

                }
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
        public static FR_Guid Invoke(string ConnectionString, P_L5ALSR_CSRHC_1057 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_L5ALSR_CSRHC_1057 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_L5ALSR_CSRHC_1057 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_L5ALSR_CSRHC_1057 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Confirm_StockReceiptHeader_Control", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_L5ALSR_CSRHC_1057 for attribute P_L5ALSR_CSRHC_1057
    [DataContract]
    public class P_L5ALSR_CSRHC_1057
    {
        //Standard type parameters
        [DataMember]
        public Guid LOG_RCP_Receipt_HeaderID { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Confirm_StockReceiptHeader_Control(,P_L5ALSR_CSRHC_1057 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Confirm_StockReceiptHeader_Control.Invoke(connectionString,P_L5ALSR_CSRHC_1057 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5ALSR_CSRHC_1057();
parameter.LOG_RCP_Receipt_HeaderID = ...;

*/
