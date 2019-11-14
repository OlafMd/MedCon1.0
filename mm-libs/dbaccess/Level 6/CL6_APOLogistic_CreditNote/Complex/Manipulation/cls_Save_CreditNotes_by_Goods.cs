/* 
 * Generated on 7/10/2014 9:48:15 AM
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

namespace CL6_APOLogistic_CreditNote.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CreditNotes_by_Goods.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CreditNotes_by_Goods
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L6CN_SCNbG_0735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Bool();

            #region Save CreditNotes by Value
            var resultCreditNotesByValue = cls_Save_CreditNotes_and_UpdateReturnShipments.Invoke(
                Connection,
                Transaction,
                Parameter.PositionsByValue,
                securityTicket);
            if (resultCreditNotesByValue.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = false;
                return returnValue;
            }
            #endregion

            #region Save CreditNotes by Goods
            if (Parameter.PositionsByGoods.Positions != null && Parameter.PositionsByGoods.Positions.Count() > 0)
            {
                Parameter.PositionsByGoods.CreditNoteHeaderID = resultCreditNotesByValue.Result.CreditNoteHeaderId;
                var resultCreditNotesByGoods = cls_Save_CreditNotes_with_StockReceipts_and_QualityControlItems.Invoke(
                    Connection,
                    Transaction,
                    Parameter.PositionsByGoods,
                    securityTicket);
                if (resultCreditNotesByGoods.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = false;
                    return returnValue;
                }
            }
            #endregion

            returnValue.Status = FR_Status.Success;
            returnValue.Result = true;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L6CN_SCNbG_0735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L6CN_SCNbG_0735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L6CN_SCNbG_0735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6CN_SCNbG_0735 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CreditNotes_by_Goods",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6CN_SCNbG_0735 for attribute P_L6CN_SCNbG_0735
		[DataContract]
		public class P_L6CN_SCNbG_0735 
		{
			//Standard type parameters
			[DataMember]
			public P_L6CN_SCNaURS_0910 PositionsByValue { get; set; } 
			[DataMember]
			public P_L6CN_SCNwSRaQCI_0739 PositionsByGoods { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_CreditNotes_by_Goods(,P_L6CN_SCNbG_0735 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_CreditNotes_by_Goods.Invoke(connectionString,P_L6CN_SCNbG_0735 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_CreditNote.Complex.Manipulation.P_L6CN_SCNbG_0735();
parameter.PositionsByValue = ...;
parameter.PositionsByGoods = ...;

*/
