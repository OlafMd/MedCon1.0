/* 
 * Generated on 21/2/2014 12:15:04
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

namespace CL5_APOLogistic_StockReceipt.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Split_QualityControlItems.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Split_QualityControlItems
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5ALSR_SQCI_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var mainQualityControl = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem();
            mainQualityControl.Load(Connection, Transaction, Parameter.QualityControlItemID);

            if (mainQualityControl != null 
                && mainQualityControl.LOG_RCP_Receipt_Position_QualityControlItem != Guid.Empty 
                && Parameter.SplitPositions.Sum() == mainQualityControl.Quantity)
            {
                mainQualityControl.IsDeleted = true;
                mainQualityControl.Save(Connection, Transaction);

                foreach (var pos in Parameter.SplitPositions)
                {
                    var qualityControl = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Position_QualityControlItem();
                    // New position
                    qualityControl.Quantity = pos;

                    // Copy data
                    qualityControl.Tenant_RefID = securityTicket.TenantID;
                    qualityControl.Receipt_Position_RefID = mainQualityControl.Receipt_Position_RefID;
                    qualityControl.BatchNumber = mainQualityControl.BatchNumber;
                    qualityControl.SerialKey = mainQualityControl.SerialKey;
                    qualityControl.ExpiryDate = mainQualityControl.ExpiryDate;
                    qualityControl.ReceiptPositionCountedItemITL = mainQualityControl.ReceiptPositionCountedItemITL;
                    qualityControl.Target_WRH_Shelf_RefID = Guid.Empty;
                    qualityControl.QualityControl_PerformedByBusinessParticipant_RefID = mainQualityControl.QualityControl_PerformedByBusinessParticipant_RefID;
                    qualityControl.QualityControl_PerformedAtDate = mainQualityControl.QualityControl_PerformedAtDate;
                    qualityControl.Save(Connection, Transaction);
                }

                return new FR_Bool(true);
            }

            return new FR_Bool(false);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5ALSR_SQCI_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5ALSR_SQCI_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5ALSR_SQCI_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5ALSR_SQCI_1021 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Split_QualityControlItems",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5ALSR_SQCI_1021 for attribute P_L5ALSR_SQCI_1021
		[DataContract]
		public class P_L5ALSR_SQCI_1021 
		{
			//Standard type parameters
			[DataMember]
			public Guid QualityControlItemID { get; set; } 
			[DataMember]
			public int[] SplitPositions { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Split_QualityControlItems(,P_L5ALSR_SQCI_1021 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Split_QualityControlItems.Invoke(connectionString,P_L5ALSR_SQCI_1021 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Manipulation.P_L5ALSR_SQCI_1021();
parameter.QualityControlItemID = ...;
parameter.SplitPositions = ...;

*/
