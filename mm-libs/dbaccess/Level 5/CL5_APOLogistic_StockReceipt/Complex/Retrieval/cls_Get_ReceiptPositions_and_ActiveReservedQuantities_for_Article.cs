/* 
 * Generated on 10/22/2014 3:12:33 PM
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
using CL5_APOLogistic_StockReceipt.Atomic.Retrieval;
using CL5_APOLogistic_ShippingOrder.Atomic.Retrieval;
using CL3_ShippingOrder.Atomic.Retrieval;

namespace CL5_APOLogistic_StockReceipt.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ReceiptPositions_and_ActiveReservedQuantities_for_Article.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ReceiptPositions_and_ActiveReservedQuantities_for_Article
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SR_GRPaARQfA_1501_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5SR_GRPaARQfA_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5SR_GRPaARQfA_1501_Array();

            var param = new P_L5SR_GRPfA_1343()
            {
                BatchNumber = Parameter.BatchNumber,
                ExpirationDate = Parameter.ExpirationDate,
                ProductID = Parameter.ProductID
            };
            var stockReceipts = cls_Get_ReceiptPositions_for_Article.Invoke(Connection, Transaction, param, securityTicket).Result;

            var activeResQuantitiesParam = new P_L3SO_GARQfMCFPSH_1450()
            {
                ProductTrackingInstanceList = stockReceipts.Select(i=>i.LOG_ProductTrackingInstance_RefID).ToArray()
            };

            var activeReservedQuantities = cls_Get_ActiveReservedQuantities_for_ManuallyClearedForPickingShippmentHeaders.Invoke(Connection, Transaction, activeResQuantitiesParam, securityTicket).Result;

            var result = new List<L5SR_GRPaARQfA_1501>();

            foreach (var item in stockReceipts) {

                var temp = activeReservedQuantities.SingleOrDefault(i=>i.LOG_ProductTrackingInstance_RefID == item.LOG_ProductTrackingInstance_RefID);


                result.Add(new L5SR_GRPaARQfA_1501()
                {
                    ReceiptPosition = item,
                    ActiveReservedQuantities = (temp == null ) ? 0: temp.ReservedQuantityFromTrackingInstance
                });
  
            }

            returnValue.Result = result.ToArray();
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5SR_GRPaARQfA_1501_Array Invoke(string ConnectionString,P_L5SR_GRPaARQfA_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SR_GRPaARQfA_1501_Array Invoke(DbConnection Connection,P_L5SR_GRPaARQfA_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SR_GRPaARQfA_1501_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SR_GRPaARQfA_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SR_GRPaARQfA_1501_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SR_GRPaARQfA_1501 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SR_GRPaARQfA_1501_Array functionReturn = new FR_L5SR_GRPaARQfA_1501_Array();
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

				throw new Exception("Exception occured in method cls_Get_ReceiptPositions_and_ActiveReservedQuantities_for_Article",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SR_GRPaARQfA_1501_Array : FR_Base
	{
		public L5SR_GRPaARQfA_1501[] Result	{ get; set; } 
		public FR_L5SR_GRPaARQfA_1501_Array() : base() {}

		public FR_L5SR_GRPaARQfA_1501_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SR_GRPaARQfA_1501 for attribute P_L5SR_GRPaARQfA_1501
		[DataContract]
		public class P_L5SR_GRPaARQfA_1501 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 
			[DataMember]
			public String BatchNumber { get; set; } 
			[DataMember]
			public DateTime? ExpirationDate { get; set; } 

		}
		#endregion
		#region SClass L5SR_GRPaARQfA_1501 for attribute L5SR_GRPaARQfA_1501
		[DataContract]
		public class L5SR_GRPaARQfA_1501 
		{
			//Standard type parameters
			[DataMember]
			public L5SR_GRPfA_1343 ReceiptPosition { get; set; } 
			[DataMember]
			public Double ActiveReservedQuantities { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SR_GRPaARQfA_1501_Array cls_Get_ReceiptPositions_and_ActiveReservedQuantities_for_Article(,P_L5SR_GRPaARQfA_1501 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SR_GRPaARQfA_1501_Array invocationResult = cls_Get_ReceiptPositions_and_ActiveReservedQuantities_for_Article.Invoke(connectionString,P_L5SR_GRPaARQfA_1501 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_StockReceipt.Complex.Retrieval.P_L5SR_GRPaARQfA_1501();
parameter.ProductID = ...;
parameter.BatchNumber = ...;
parameter.ExpirationDate = ...;

*/
