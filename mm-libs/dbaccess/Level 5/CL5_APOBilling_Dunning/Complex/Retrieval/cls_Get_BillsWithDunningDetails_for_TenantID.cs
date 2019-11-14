/* 
 * Generated on 6/2/2014 12:15:10 PM
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
using System.Runtime.Serialization;
using DLCore_DBCommons.APODemand;
using CL5_APOBilling_Shipment.Atomic.Retrieval;
using CL5_APOBilling_Bill.Atomic.Retrieval;
using CL5_APOBilling_Dunning.Atomic.Retrieval;
using DLCore_DBCommons.Utils;

namespace CL5_APOBilling_Dunning.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BillsWithDunningDetails_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BillsWithDunningDetails_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GBwDDfTID_1017_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GBwDDfTID_1017 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BD_GBwDDfTID_1017_Array();
			//Put your code here     
            var statusParam = new P_L5SH_GSSfGPMaT_1700 { GlobalPropertyMatchingID = EnumUtils.GetEnumDescription(EShipmentStatus.Shipped) };
            var frStatus = cls_Get_Shipment_Status_for_GlobalPropertyMatchingID_and_TenantID.Invoke(Connection, Transaction, statusParam, securityTicket);
            Parameter.GetBillsParameter.ShipmentStatusID = frStatus.Result.LOG_SHP_Shipment_StatusID;
            var bills = cls_Get_AllFilteredBills_for_TenantID.Invoke(Connection, Transaction, Parameter.GetBillsParameter, securityTicket).Result;

            List<Guid> billHeaderIDs = new List<Guid>();
            foreach (var bill in bills)
            {
                billHeaderIDs.Add(bill.BIL_BillHeaderID);
            }
            
            P_L5BD_GDDfBHL_1117 getDunningDetailsParameter = new P_L5BD_GDDfBHL_1117();
            getDunningDetailsParameter.BillHeaderID_List = billHeaderIDs.ToArray();
            getDunningDetailsParameter.DunningLevelID = Parameter.GetDunningDetailsParameter.DunningLevelID;
            getDunningDetailsParameter.DunningDateFrom = Parameter.GetDunningDetailsParameter.DunningDateFrom;
            getDunningDetailsParameter.DunningDateTo = Parameter.GetDunningDetailsParameter.DunningDateTo;
            getDunningDetailsParameter.IsReminded = Parameter.GetDunningDetailsParameter.IsReminded;
            
            var dunningDetailsForBills = new List<L5BD_GDDfBHL_1117>();
            if (billHeaderIDs.Count > 0)
            {
                dunningDetailsForBills = cls_Get_DunningDetails_for_BillHeaderList.Invoke(Connection, Transaction, getDunningDetailsParameter, securityTicket).Result.ToList();
            }

            List<L5BD_GBwDDfTID_1017> billsWithDunningDetails = new List<L5BD_GBwDDfTID_1017>();

            foreach (var bill in bills)
            {
                L5BD_GBwDDfTID_1017 billWithDunningDetails = new L5BD_GBwDDfTID_1017();

                if (dunningDetailsForBills.Where(x => x.BIL_BillHeader_RefID == bill.BIL_BillHeaderID) != null &&
                    dunningDetailsForBills.Where(x => x.BIL_BillHeader_RefID == bill.BIL_BillHeaderID).Count() > 0)
                {                    
                    billWithDunningDetails.DunningDetails = dunningDetailsForBills.Where(x => x.BIL_BillHeader_RefID == bill.BIL_BillHeaderID).Single();
                    billWithDunningDetails.Bill = bill;
                    billsWithDunningDetails.Add(billWithDunningDetails);
                }               
            }

            returnValue.Result = billsWithDunningDetails.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BD_GBwDDfTID_1017_Array Invoke(string ConnectionString,P_L5BD_GBwDDfTID_1017 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GBwDDfTID_1017_Array Invoke(DbConnection Connection,P_L5BD_GBwDDfTID_1017 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GBwDDfTID_1017_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GBwDDfTID_1017 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GBwDDfTID_1017_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GBwDDfTID_1017 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GBwDDfTID_1017_Array functionReturn = new FR_L5BD_GBwDDfTID_1017_Array();
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

				throw new Exception("Exception occured in method cls_Get_BillsWithDunningDetails_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GBwDDfTID_1017_Array : FR_Base
	{
		public L5BD_GBwDDfTID_1017[] Result	{ get; set; } 
		public FR_L5BD_GBwDDfTID_1017_Array() : base() {}

		public FR_L5BD_GBwDDfTID_1017_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GBwDDfTID_1017 for attribute P_L5BD_GBwDDfTID_1017
		[DataContract]
		public class P_L5BD_GBwDDfTID_1017 
		{
			//Standard type parameters
			[DataMember]
			public P_L5BL_GAFBfT_1508 GetBillsParameter { get; set; } 
			[DataMember]
			public P_L5BD_GDDfBHL_1117 GetDunningDetailsParameter { get; set; } 

		}
		#endregion
		#region SClass L5BD_GBwDDfTID_1017 for attribute L5BD_GBwDDfTID_1017
		[DataContract]
		public class L5BD_GBwDDfTID_1017 
		{
			//Standard type parameters
			[DataMember]
			public L5BL_GAFBfT_1508 Bill { get; set; } 
			[DataMember]
			public L5BD_GDDfBHL_1117 DunningDetails { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_GBwDDfTID_1017_Array cls_Get_BillsWithDunningDetails_for_TenantID(,P_L5BD_GBwDDfTID_1017 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BD_GBwDDfTID_1017_Array invocationResult = cls_Get_BillsWithDunningDetails_for_TenantID.Invoke(connectionString,P_L5BD_GBwDDfTID_1017 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Dunning.Complex.Retrieval.P_L5BD_GBwDDfTID_1017();
parameter.GetBillsParameter = ...;
parameter.GetDunningDetailsParameter = ...;

*/
