/* 
 * Generated on 5/7/2014 11:49:28 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_InstallmentPlan_for_Bill.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_InstallmentPlan_for_Bill
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3BL_SIPfB_0940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
            returnValue.Result = Guid.Empty;

            Guid installmentPlanID = CL3_InstallmentPlans.Complex.Manipulation.cls_Save_InstallmentPlan.Invoke(Connection, Transaction, Parameter.InstallmentPlan_Parameter, securityTicket).Result;

            if (Parameter.InstallmentPlan_Parameter.InstallmentPlanID == Guid.Empty)
            {
                var billHeader2InstallmentPlan = new CL1_BIL.ORM_BIL_BillHeader_2_InstallmentPlan
                    {
                        BIL_BillHeader_2_InstallmentPlanID = Guid.NewGuid(),
                        BIL_BillHeader_RefID = Parameter.BillHeaderID,
                        BIL_InstallmentPlan_RefID = installmentPlanID,
                        IsDeleted = false,
                        Creation_Timestamp = DateTime.Now,
                        Tenant_RefID = securityTicket.TenantID
                    };
                billHeader2InstallmentPlan.Save(Connection, Transaction);
            }

            returnValue.Result = installmentPlanID;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3BL_SIPfB_0940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3BL_SIPfB_0940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3BL_SIPfB_0940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3BL_SIPfB_0940 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_InstallmentPlan_for_Bill",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3BL_SIPfB_0940 for attribute P_L3BL_SIPfB_0940
		[DataContract]
		public class P_L3BL_SIPfB_0940 
		{
			//Standard type parameters
			[DataMember]
			public CL3_InstallmentPlans.Complex.Manipulation.P_L3IP_SIP_1718 InstallmentPlan_Parameter { get; set; } 
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_InstallmentPlan_for_Bill(,P_L3BL_SIPfB_0940 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_InstallmentPlan_for_Bill.Invoke(connectionString,P_L3BL_SIPfB_0940 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L3BL_SIPfB_0940();
parameter.InstallmentPlan_Parameter = ...;
parameter.BillHeaderID = ...;

*/
