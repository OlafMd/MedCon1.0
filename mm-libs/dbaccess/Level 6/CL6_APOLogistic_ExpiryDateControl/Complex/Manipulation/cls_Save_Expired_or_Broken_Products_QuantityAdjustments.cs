/* 
 * Generated on 5/29/2014 9:18:19 AM
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
using CL3_Warehouse.Complex.Manipulation;
using CL1_LOG_WRH;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL6_APOLogistic_ExpiryDateControl.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Expired_or_Broken_Products_QuantityAdjustments.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Expired_or_Broken_Products_QuantityAdjustments
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L6ED_SEoBPQA_0819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();

            #region Get and Set 'Broken/Expired' Invertory Change Reason
            var brokenExpiredReason = ORM_LOG_WRH_InventoryChangeReason.Query.Search(
                Connection,
                Transaction,
                new ORM_LOG_WRH_InventoryChangeReason.Query()
                {
                    GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EDefaultContentAdjustmentsReason.BrokenExpired),
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();
            if (brokenExpiredReason == null)
            {
                returnValue.Result = false;
                returnValue.Status = FR_Status.Error_Internal;
                return returnValue;
            }
            foreach (var adjustment in Parameter.Adjustments.Adjustments)
            {
                adjustment.IfManualCorrection_InventoryChangeReason_RefID = brokenExpiredReason.LOG_WRH_InventoryChangeReasonID;
            }
            #endregion

            var resultAdjustments = cls_Save_Shelf_ContentAdjustments.Invoke(Connection, Transaction, Parameter.Adjustments, securityTicket);

            returnValue.Result = resultAdjustments.Result;
            returnValue.Status = resultAdjustments.Result ? FR_Status.Success : FR_Status.Error_Internal;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L6ED_SEoBPQA_0819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L6ED_SEoBPQA_0819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L6ED_SEoBPQA_0819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6ED_SEoBPQA_0819 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Expired_or_Broken_Products_QuantityAdjustments",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6ED_SEoBPQA_0819 for attribute P_L6ED_SEoBPQA_0819
		[DataContract]
		public class P_L6ED_SEoBPQA_0819 
		{
			//Standard type parameters
			[DataMember]
			public CL3_Warehouse.Complex.Manipulation.P_L3WH_SSCA_1732 Adjustments { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Save_Expired_or_Broken_Products_QuantityAdjustments(,P_L6ED_SEoBPQA_0819 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Save_Expired_or_Broken_Products_QuantityAdjustments.Invoke(connectionString,P_L6ED_SEoBPQA_0819 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_ExpiryDateControl.Complex.Manipulation.P_L6ED_SEoBPQA_0819();
parameter.Adjustments = ...;

*/
