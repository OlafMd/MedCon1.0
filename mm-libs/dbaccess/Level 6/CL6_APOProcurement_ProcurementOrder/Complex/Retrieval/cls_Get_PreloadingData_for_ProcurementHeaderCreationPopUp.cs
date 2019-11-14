/* 
 * Generated on 6/16/2014 1:32:18 PM
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
using CL2_NumberRange.Complex.Retrieval;
using CL3_Supplier.Atomic.Retrieval;

namespace CL6_APOProcurement_ProcurementOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadingData_for_ProcurementHeaderCreationPopUp.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadingData_for_ProcurementHeaderCreationPopUp
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PO_GPDfPHCPP_1035 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PO_GPDfPHCPP_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6PO_GPDfPHCPP_1035();
            returnValue.Result = new L6PO_GPDfPHCPP_1035();

            var resultIncreasingNumber = cls_Get_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction, Parameter.TypeOfHeader, securityTicket).Result;

            
            var resultSuppliers = cls_Get_SuppliersDisplayNames_with_ID_for_TenantID.Invoke(Connection, Transaction, securityTicket).Result;

            returnValue.Result.ProcurementOrderHeaderNumber = resultIncreasingNumber;
            returnValue.Result.Suppliers = resultSuppliers;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PO_GPDfPHCPP_1035 Invoke(string ConnectionString,P_L6PO_GPDfPHCPP_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PO_GPDfPHCPP_1035 Invoke(DbConnection Connection,P_L6PO_GPDfPHCPP_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PO_GPDfPHCPP_1035 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PO_GPDfPHCPP_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PO_GPDfPHCPP_1035 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PO_GPDfPHCPP_1035 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PO_GPDfPHCPP_1035 functionReturn = new FR_L6PO_GPDfPHCPP_1035();
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

				throw new Exception("Exception occured in method cls_Get_PreloadingData_for_ProcurementHeaderCreationPopUp",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PO_GPDfPHCPP_1035 : FR_Base
	{
		public L6PO_GPDfPHCPP_1035 Result	{ get; set; }

		public FR_L6PO_GPDfPHCPP_1035() : base() {}

		public FR_L6PO_GPDfPHCPP_1035(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PO_GPDfPHCPP_1035 for attribute P_L6PO_GPDfPHCPP_1035
		[DataContract]
		public class P_L6PO_GPDfPHCPP_1035 
		{
			//Standard type parameters
			[DataMember]
			public CL2_NumberRange.Complex.Retrieval.P_L2NR_GINfUA_1113 TypeOfHeader { get; set; } 

		}
		#endregion
		#region SClass L6PO_GPDfPHCPP_1035 for attribute L6PO_GPDfPHCPP_1035
		[DataContract]
		public class L6PO_GPDfPHCPP_1035 
		{
			//Standard type parameters
			[DataMember]
			public CL2_NumberRange.Complex.Retrieval.L2NR_GINfUA_1113 ProcurementOrderHeaderNumber { get; set; } 
			[DataMember]
			public CL3_Supplier.Atomic.Retrieval.L3SP_GSDNwIfT_1328[] Suppliers { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PO_GPDfPHCPP_1035 cls_Get_PreloadingData_for_ProcurementHeaderCreationPopUp(,P_L6PO_GPDfPHCPP_1035 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PO_GPDfPHCPP_1035 invocationResult = cls_Get_PreloadingData_for_ProcurementHeaderCreationPopUp.Invoke(connectionString,P_L6PO_GPDfPHCPP_1035 Parameter,securityTicket);
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
var parameter = new CL6_APOProcurement_ProcurementOrder.Complex.Retrieval.P_L6PO_GPDfPHCPP_1035();
parameter.TypeOfHeader = ...;

*/
