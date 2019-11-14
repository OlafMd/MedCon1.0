/* 
 * Generated on 7/19/2014 3:49:15 PM
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
using CL3_BookingAccounts.Atomic.Retrieval;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL3_BookingAccounts.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BookingAccounts_Purpose_for_BP.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BookingAccounts_Purpose_for_BP
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3BA_GBAPfBP_1535 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3BA_GBAPfBP_1535();
			//Put your code here
            var result = new L3BA_GBAPfBP_1535();

            var tenantBP = CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
            new CL1_CMN_BPT.ORM_CMN_BPT_BusinessParticipant.Query
            {
                IsTenant = true,
                IfTenant_Tenant_RefID = securityTicket.TenantID,
                Tenant_RefID = securityTicket.TenantID
            }).Single().CMN_BPT_BusinessParticipantID;

            Guid currentFiscalYearID = CL2_FiscalYear.Complex.Retrieval.cls_Get_Current_FiscalYear.Invoke(Connection, Transaction, securityTicket).Result.ACC_FiscalYearID;

            // bookingtypsAssignment
		    var bookingAccountAssignmentParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAPBPAfBP_1717
		    {
		        FiscalYearID = currentFiscalYearID,
		        BusinessParticipantID_List = new Guid[] { tenantBP }
		    };

            
            var res_BookingAccountAssignment = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_BookingAccount_Purpose_BPAssignment_for_BPID_List.Invoke(
                Connection, Transaction, bookingAccountAssignmentParam, securityTicket).Result;

            // bookingAccounts

		    var bookingAccountParam = new CL3_BookingAccounts.Atomic.Retrieval.P_L3BA_GBAfTaFYI_0930
		    {
		        FiscalYearID = currentFiscalYearID
		    };

            var res_BookingAccounts = CL3_BookingAccounts.Atomic.Retrieval.cls_Get_BookingAccounts_for_TenantID_and_FiscalYearID.Invoke(
                Connection,Transaction, bookingAccountParam, securityTicket).Result;
                

            result.BookingAccountsAssignment = new L3BA_GBAPBPAfBP_1717[res_BookingAccountAssignment.Count()];
            result.BookingAccountsAssignment = res_BookingAccountAssignment;

            result.BookingAccounts = new L3BA_GBAfTaFYI_0930[res_BookingAccounts.Count()];
		    result.BookingAccounts = res_BookingAccounts;

		    result.BusinessParticipantID = tenantBP;

		    returnValue.Result = result;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3BA_GBAPfBP_1535 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3BA_GBAPfBP_1535 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3BA_GBAPfBP_1535 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3BA_GBAPfBP_1535 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3BA_GBAPfBP_1535 functionReturn = new FR_L3BA_GBAPfBP_1535();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_BookingAccounts_Purpose_for_BP",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3BA_GBAPfBP_1535 : FR_Base
	{
		public L3BA_GBAPfBP_1535 Result	{ get; set; }

		public FR_L3BA_GBAPfBP_1535() : base() {}

		public FR_L3BA_GBAPfBP_1535(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3BA_GBAPfBP_1535 for attribute L3BA_GBAPfBP_1535
		[DataContract]
		public class L3BA_GBAPfBP_1535 
		{
			//Standard type parameters
			[DataMember]
			public Guid BusinessParticipantID { get; set; } 
			[DataMember]
			public L3BA_GBAPBPAfBP_1717[] BookingAccountsAssignment { get; set; } 
			[DataMember]
			public L3BA_GBAfTaFYI_0930[] BookingAccounts { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3BA_GBAPfBP_1535 cls_Get_BookingAccounts_Purpose_for_BP(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3BA_GBAPfBP_1535 invocationResult = cls_Get_BookingAccounts_Purpose_for_BP.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

