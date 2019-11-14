/* 
 * Generated on 7/9/2014 8:22:01 AM
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
using CL1_LOG_SHP_RSH;
using CL1_ACC_CRN;

namespace CL5_APOLogistic_ReturnShipment.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CreditNote_for_ReturnShipment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CreditNote_for_ReturnShipment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5RS_CNfRS_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            #region Create and Save ReceivedCreditNotes and ReturnShipmentCreditNoteHeader
            var newCreditNoteHeader = new ORM_LOG_SHP_ReturnShipment_ReceivableCreditNote_Header();
            var newReceivedCreditNotes = new ORM_ACC_CRN_ReceivedCreditNote();
            if (Parameter.headerId == Guid.Empty)
            {
                #region Create ReceivedCreditNotes
                newReceivedCreditNotes.ACC_CRN_ReceivedCreditNoteID = Guid.NewGuid();
                newReceivedCreditNotes.Creation_Timestamp = DateTime.Now;
                newReceivedCreditNotes.CreditNote_Number = Parameter.headerNumber;
                newReceivedCreditNotes.CreditNote_Value = Parameter.headerValue;
                newReceivedCreditNotes.CreditNote_Currency_RefID = Parameter.currencyRef;
                newReceivedCreditNotes.DateOnCreditNote = Parameter.creditNoteDate;
                newReceivedCreditNotes.Tenant_RefID = securityTicket.TenantID;
                newReceivedCreditNotes.CreditNoteITPL = ""; // TODO:Marko - Temporary! We are not sure how to set this field. Will be decided in the future.
                var resultReceivedCreditNote = newReceivedCreditNotes.Save(Connection, Transaction);
                if (resultReceivedCreditNote.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = Guid.Empty;
                    return returnValue;
                }
                #endregion

                #region Create ReturnShipment_ReceivableCreditNote_Header
                newCreditNoteHeader.LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID = Guid.NewGuid();
                newCreditNoteHeader.Ext_ACC_CRN_ReceivedCreditNote_RefID = newReceivedCreditNotes.ACC_CRN_ReceivedCreditNoteID;
                newCreditNoteHeader.Creation_Timestamp = DateTime.Now;
                newCreditNoteHeader.IsDeleted = false;
                newCreditNoteHeader.Tenant_RefID = securityTicket.TenantID;
                var resultCreditNoteHeader = newCreditNoteHeader.Save(Connection, Transaction);
                if (resultCreditNoteHeader.Status != FR_Status.Success)
                {

                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = Guid.Empty;
                    return returnValue;
                }
                #endregion
            }
            else
            {
                #region Load ReceivedCreditNotes and update Value
                newCreditNoteHeader.Load(Connection, Transaction, Parameter.headerId);
                if (newCreditNoteHeader.LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID == Guid.Empty)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = Guid.Empty;
                    return returnValue;
                }

                newReceivedCreditNotes.Load(Connection, Transaction, newCreditNoteHeader.Ext_ACC_CRN_ReceivedCreditNote_RefID);
                if (newReceivedCreditNotes.ACC_CRN_ReceivedCreditNoteID == Guid.Empty)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = Guid.Empty;
                    return returnValue;
                }

                newReceivedCreditNotes.CreditNote_Value = newReceivedCreditNotes.CreditNote_Value + Parameter.headerValue;
                var resultReceivedCreditNotes = newReceivedCreditNotes.Save(Connection, Transaction);
                if (resultReceivedCreditNotes.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = Guid.Empty;
                    return returnValue;
                }
                #endregion
            }
            #endregion

            #region Create CreditNote Positions with CreditNote 2 Receipt positions
            if (Parameter.receiptPositions != null)
            {
                foreach (var position in Parameter.receiptPositions)
                {
                    #region Create CreditNote Position
                    var newRetShpCreditNotePosition = new ORM_LOG_SHP_ReturnShipment_ReceivableCreditNote_Position();
                    newRetShpCreditNotePosition.LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID = Guid.NewGuid();
                    newRetShpCreditNotePosition.Creation_Timestamp = DateTime.Now;
                    newRetShpCreditNotePosition.IsDeleted = false;
                    newRetShpCreditNotePosition.Tenant_RefID = securityTicket.TenantID;
                    newRetShpCreditNotePosition.LOG_SHP_ReturnShipment_CreditNotes_Header_RefID = newCreditNoteHeader.LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID;
                    var resultRetShpCreditNotePosition = newRetShpCreditNotePosition.Save(Connection, Transaction);
                    if (resultRetShpCreditNotePosition.Status != FR_Status.Success)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        returnValue.Result = Guid.Empty;
                        return returnValue;
                    }
                    #endregion

                    #region Create CreditNote 2 Receipt Position
                    var newReceiptCreditNotePosition = new ORM_LOG_SHP_RSH_ReceivableCreditNote_2_ReceiptPosition();
                    newReceiptCreditNotePosition.AssignmentID = Guid.NewGuid();
                    newReceiptCreditNotePosition.Creation_Timestamp = DateTime.Now;
                    newReceiptCreditNotePosition.Tenant_RefID = securityTicket.TenantID;
                    newReceiptCreditNotePosition.LOG_SHP_ReturnShipment_ReceivableCreditNote_Position_RefID = newRetShpCreditNotePosition.LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID;
                    newReceiptCreditNotePosition.LOG_RCP_Receipt_Position_RefID = position.receiptPositionId;
                    newReceiptCreditNotePosition.IsFullCompensationForReceivableCreditNotePosition = position.IsFullCompesationForReceivableCreditNotePosition; 
                    newReceiptCreditNotePosition.CompensationValue = (float)position.compesationValue;
                    var resultReceiptCreditNotePosition = newReceiptCreditNotePosition.Save(Connection, Transaction);
                    if (resultReceiptCreditNotePosition.Status != FR_Status.Success)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        returnValue.Result = Guid.Empty;
                        return returnValue;
                    }
                    #endregion
                }
            }
            #endregion

            #region Create ReturnShipment Position 2 CreditNote
            if (Parameter.returnShipmentPositions != null)
            {
                foreach (Guid position in Parameter.returnShipmentPositions)
                {
                    var newRetShpCreditNotePosition = new ORM_LOG_SHP_ReturnShipment_ReceivableCreditNote_Position();
                    newRetShpCreditNotePosition.LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID = Guid.NewGuid();
                    newRetShpCreditNotePosition.Creation_Timestamp = DateTime.Now;
                    newRetShpCreditNotePosition.IsDeleted = false;
                    newRetShpCreditNotePosition.Tenant_RefID = securityTicket.TenantID;
                    newRetShpCreditNotePosition.LOG_SHP_ReturnShipment_CreditNotes_Header_RefID = newCreditNoteHeader.LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID;
                    var resultRetShpCreditNotePosition = newRetShpCreditNotePosition.Save(Connection, Transaction);
                    if (resultRetShpCreditNotePosition.Status != FR_Status.Success)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        returnValue.Result = Guid.Empty;
                        return returnValue;
                    }

                    var newRetShipmentPosForCN = new ORM_LOG_SHP_ReturnShipment_Position_2_ReceivableCreditNote();
                    newRetShipmentPosForCN.Creation_Timestamp = DateTime.Now;
                    newRetShipmentPosForCN.IsDeleted = false;
                    newRetShipmentPosForCN.Tenant_RefID = securityTicket.TenantID;
                    newRetShipmentPosForCN.AssignmentID = Guid.NewGuid();
                    newRetShipmentPosForCN.LOG_SHP_ReturnShipment_Position_RefID = position;
                    newRetShipmentPosForCN.LOG_SHP_ReturnShipment_ReceivableCreditNotes_Position_RefID = newRetShpCreditNotePosition.LOG_SHP_ReturnShipment_ReceivableCreditNote_PositionID;
                    var resultRetShipmentPosForCN = newRetShipmentPosForCN.Save(Connection, Transaction);
                    if (resultRetShipmentPosForCN.Status != FR_Status.Success)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        returnValue.Result = Guid.Empty;
                        return returnValue;
                    }
                }
            }
            #endregion

            returnValue.Status = FR_Status.Success;
            returnValue.Result = newCreditNoteHeader.LOG_SHP_ReturnShipment_ReceivableCreditNote_HeaderID;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5RS_CNfRS_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5RS_CNfRS_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RS_CNfRS_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RS_CNfRS_1119 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CreditNote_for_ReturnShipment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5RS_CNfRS_1119 for attribute P_L5RS_CNfRS_1119
		[DataContract]
		public class P_L5RS_CNfRS_1119 
		{
			[DataMember]
			public P_L5RS_CNfRS_1119a[] receiptPositions { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid headerId { get; set; } 
			[DataMember]
			public string headerNumber { get; set; } 
			[DataMember]
			public decimal headerValue { get; set; } 
			[DataMember]
			public Guid currencyRef { get; set; } 
			[DataMember]
			public DateTime creditNoteDate { get; set; } 
			[DataMember]
			public Guid[] returnShipmentPositions { get; set; } 

		}
		#endregion
		#region SClass P_L5RS_CNfRS_1119a for attribute receiptPositions
		[DataContract]
		public class P_L5RS_CNfRS_1119a 
		{
			//Standard type parameters
			[DataMember]
			public Guid receiptPositionId { get; set; } 
			[DataMember]
			public double compesationValue { get; set; } 
			[DataMember]
			public bool IsFullCompesationForReceivableCreditNotePosition { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CreditNote_for_ReturnShipment(,P_L5RS_CNfRS_1119 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CreditNote_for_ReturnShipment.Invoke(connectionString,P_L5RS_CNfRS_1119 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ReturnShipment.Atomic.Manipulation.P_L5RS_CNfRS_1119();
parameter.receiptPositions = ...;

parameter.headerId = ...;
parameter.headerNumber = ...;
parameter.headerValue = ...;
parameter.currencyRef = ...;
parameter.creditNoteDate = ...;
parameter.returnShipmentPositions = ...;

*/
