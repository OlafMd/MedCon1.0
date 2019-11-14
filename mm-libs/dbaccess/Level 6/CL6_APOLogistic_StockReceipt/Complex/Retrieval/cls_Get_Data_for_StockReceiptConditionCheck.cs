/* 
 * Generated on 7/18/2014 1:06:43 PM
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
using CL5_APOLogistic_StockReceipt.Complex.Retrieval;
using CL2_DiscountType.Atomic.Retrieval;
using DLCore_DBCommons.Utils;
using DLCore_DBCommons.APODemand;

namespace CL6_APOLogistic_StockReceipt.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Data_for_StockReceiptConditionCheck.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Data_for_StockReceiptConditionCheck
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6SR_GDfSRCC_1515 Execute(DbConnection Connection,DbTransaction Transaction,P_L6SR_GDfSRCC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6SR_GDfSRCC_1515();

            P_L5SR_GSRPfH_1544 getPositionsParameter = new P_L5SR_GSRPfH_1544();
            getPositionsParameter.ReceiptHeaderID = Parameter.ReceiptHeaderID;

            var receiptPositions = cls_Get_StockReceiptsPositions_for_ReceiptHeaderID.Invoke(Connection, Transaction, getPositionsParameter, securityTicket).Result;

            CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header receiptHeader = new CL1_LOG_RCP.ORM_LOG_RCP_Receipt_Header();
            receiptHeader.Load(Connection, Transaction, Parameter.ReceiptHeaderID);

            var expectedDeliveryHeader = CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query.Search(Connection, Transaction,
             new CL1_ORD_PRC.ORM_ORD_PRC_ExpectedDelivery_Header.Query()
             {
                 ORD_PRC_ExpectedDelivery_HeaderID = receiptHeader.ExpectedDeliveryHeader_RefID,
                 Tenant_RefID = securityTicket.TenantID,
                 IsDeleted = false
             }).Single();

            #region Discount types

            var discountTypesParam = new P_L2DT_GDTfGPMIL_1546();
            discountTypesParam.GlobalPropertyMatchingID_List = EnumUtils.GetAllEnumDescriptions<EDiscountType>().ToArray();

            var discountTypes = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(Connection, Transaction, discountTypesParam, securityTicket).Result;

            #endregion

            returnValue.Result = new L6SR_GDfSRCC_1515();
            returnValue.Result.Positions = receiptPositions;
            returnValue.Result.DeliveryDate = expectedDeliveryHeader.ExpectedDeliveryDate;
            returnValue.Result.DeliveryNumber = expectedDeliveryHeader.ExpectedDeliveryNumber;
            returnValue.Result.SupplierID = receiptHeader.ProvidingSupplier_RefID;
            returnValue.Result.DiscountTypes = discountTypes; 

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6SR_GDfSRCC_1515 Invoke(string ConnectionString,P_L6SR_GDfSRCC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6SR_GDfSRCC_1515 Invoke(DbConnection Connection,P_L6SR_GDfSRCC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6SR_GDfSRCC_1515 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SR_GDfSRCC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6SR_GDfSRCC_1515 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SR_GDfSRCC_1515 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6SR_GDfSRCC_1515 functionReturn = new FR_L6SR_GDfSRCC_1515();
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

				throw new Exception("Exception occured in method cls_Get_Data_for_StockReceiptConditionCheck",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6SR_GDfSRCC_1515 : FR_Base
	{
		public L6SR_GDfSRCC_1515 Result	{ get; set; }

		public FR_L6SR_GDfSRCC_1515() : base() {}

		public FR_L6SR_GDfSRCC_1515(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6SR_GDfSRCC_1515 for attribute P_L6SR_GDfSRCC_1515
		[DataContract]
		public class P_L6SR_GDfSRCC_1515 
		{
			//Standard type parameters
			[DataMember]
			public Guid ReceiptHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6SR_GDfSRCC_1515 for attribute L6SR_GDfSRCC_1515
		[DataContract]
		public class L6SR_GDfSRCC_1515 
		{
			//Standard type parameters
			[DataMember]
			public L5SR_GSRPfH_1544[] Positions { get; set; } 
			[DataMember]
			public L2DT_GDTfGPMIL_1546[] DiscountTypes { get; set; } 
			[DataMember]
			public DateTime DeliveryDate { get; set; } 
			[DataMember]
			public DateTime PaymentDeadline { get; set; } 
			[DataMember]
			public String DeliveryNumber { get; set; } 
			[DataMember]
			public Guid SupplierID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6SR_GDfSRCC_1515 cls_Get_Data_for_StockReceiptConditionCheck(,P_L6SR_GDfSRCC_1515 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6SR_GDfSRCC_1515 invocationResult = cls_Get_Data_for_StockReceiptConditionCheck.Invoke(connectionString,P_L6SR_GDfSRCC_1515 Parameter,securityTicket);
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
var parameter = new CL6_APOLogistic_StockReceipt.Complex.Retrieval.P_L6SR_GDfSRCC_1515();
parameter.ReceiptHeaderID = ...;

*/
