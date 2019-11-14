/* 
 * Generated on 6/6/2014 1:45:57 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_SaveBill.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_SaveBill
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_SB_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            
            #region Bill Header

            Guid BillHeaderID;

            if (Parameter.BillHeaderData.BIL_BillHeaderID == Guid.Empty)
            {
                // Create bill header data
                P_L5CO_CBH_1606 paramHeader = new P_L5CO_CBH_1606 { Bill_Parameter = Parameter };
                BillHeaderID = cls_CreateBillHeader.Invoke(Connection, Transaction, paramHeader, securityTicket).Result;
            }
            else
            {
                //Edit bill header data
                P_L5CO_EBH_1108 paramHeader = new P_L5CO_EBH_1108 { Bill_Parameter = Parameter };
                BillHeaderID = cls_Edit_BillHeader.Invoke(Connection, Transaction, paramHeader, securityTicket).Result;
            }

            if (Parameter.InstallmentPlan != null)
            {
                var installmentParameter = Parameter.InstallmentPlan;
                installmentParameter.BillHeaderID = BillHeaderID;
                cls_Save_InstallmentPlan_for_Bill.Invoke(Connection, Transaction, installmentParameter, securityTicket);
            }

            #endregion

            #region Bill Positions

            if (Parameter.BillHeaderData.ShipmentHeaderIDs != null && Parameter.BillHeaderData.ShipmentHeaderIDs.Count() != 0)
            {
                var paramPos = new P_L5BL_CBPfSH();
                paramPos.BillHeaderID = BillHeaderID;
                paramPos.ShipmentHeaderIDs = Parameter.BillHeaderData.ShipmentHeaderIDs;
                cls_Create_BillPositions_for_ShipmentHeaders.Invoke(Connection, Transaction, paramPos, securityTicket);
            }

            #endregion

            returnValue.Result = BillHeaderID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BL_SB_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BL_SB_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_SB_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_SB_1645 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_SaveBill",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BL_SB_1645 for attribute P_L5BL_SB_1645
		[DataContract]
		public class P_L5BL_SB_1645 
		{
			[DataMember]
			public P_L5BL_SB_1645a BillHeaderData { get; set; }

			//Standard type parameters
			[DataMember]
			public CL5_APOBilling_Bill.Complex.Manipulation.P_L3BL_SIPfB_0940 InstallmentPlan { get; set; } 

		}
		#endregion
		#region SClass P_L5BL_SB_1645a for attribute BillHeaderData
		[DataContract]
		public class P_L5BL_SB_1645a 
		{
			//Standard type parameters
			[DataMember]
			public DateTime BillingDate { get; set; } 
			[DataMember]
			public Guid PaymentTypeID { get; set; } 
			[DataMember]
			public Guid PaymentTargetID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public CL5_APOBilling_Bill.Complex.Retrieval.L5BL_GCfTID_1006 BillingReceiverCustomer { get; set; } 
			[DataMember]
			public Guid BillingAddressID { get; set; } 
			[DataMember]
			public Guid[] ShipmentHeaderIDs { get; set; } 
			[DataMember]
			public Guid BIL_BillHeaderID { get; set; } 
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_SaveBill(,P_L5BL_SB_1645 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_SaveBill.Invoke(connectionString,P_L5BL_SB_1645 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5BL_SB_1645();
parameter.BillHeaderData = ...;

parameter.InstallmentPlan = ...;

*/
