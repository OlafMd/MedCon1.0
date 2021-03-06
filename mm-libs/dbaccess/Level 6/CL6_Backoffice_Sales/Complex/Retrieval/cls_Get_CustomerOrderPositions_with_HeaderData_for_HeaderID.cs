/* 
 * Generated on 6/20/2014 3:05:06 PM
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
using CL3_CustomerOrder.Atomic.Retrieval;
using CL5_APOBackoffice_CustomerOrder.Complex.Retrieval;

namespace CL6_Backoffice_Sales.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderPositions_with_HeaderData_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderPositions_with_HeaderData_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6BS_GCOPwHDfH_0748 Execute(DbConnection Connection,DbTransaction Transaction,P_L6BS_GCOPwHDfH_0748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L6BS_GCOPwHDfH_0748();

            #region Get CustomerOrder Header Data
            var resultHeader = cls_Get_CustomerOrderData_for_HeaderID.Invoke(
                Connection, 
                Transaction, 
                new P_CL3_GCODfH_1537() { CustomerOrderHeaderID = Parameter.CustomerOrderHeaderID }, 
                securityTicket);
            if (resultHeader.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get CustomerOrder Positions
            var resultPositions = cls_Get_CustomerOrderPositions_with_Details_for_HeaderID.Invoke(
                Connection,
                Transaction,
                new P_L5CO_GCOPwDfH_1421() { OrderHeaderID = Parameter.CustomerOrderHeaderID },
                securityTicket);
            if (resultHeader.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Set Result
            returnValue.Status = FR_Status.Success;
            returnValue.Result = new L6BS_GCOPwHDfH_0748();
            returnValue.Result.HeaderData = resultHeader.Result;
            returnValue.Result.Positions = resultPositions.Result.ToArray();
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6BS_GCOPwHDfH_0748 Invoke(string ConnectionString,P_L6BS_GCOPwHDfH_0748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6BS_GCOPwHDfH_0748 Invoke(DbConnection Connection,P_L6BS_GCOPwHDfH_0748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6BS_GCOPwHDfH_0748 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6BS_GCOPwHDfH_0748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6BS_GCOPwHDfH_0748 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6BS_GCOPwHDfH_0748 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6BS_GCOPwHDfH_0748 functionReturn = new FR_L6BS_GCOPwHDfH_0748();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderPositions_with_HeaderData_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6BS_GCOPwHDfH_0748 : FR_Base
	{
		public L6BS_GCOPwHDfH_0748 Result	{ get; set; }

		public FR_L6BS_GCOPwHDfH_0748() : base() {}

		public FR_L6BS_GCOPwHDfH_0748(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6BS_GCOPwHDfH_0748 for attribute P_L6BS_GCOPwHDfH_0748
		[DataContract]
		public class P_L6BS_GCOPwHDfH_0748 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass L6BS_GCOPwHDfH_0748 for attribute L6BS_GCOPwHDfH_0748
		[DataContract]
		public class L6BS_GCOPwHDfH_0748 
		{
			//Standard type parameters
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.CL3_GCODfH_1537 HeaderData { get; set; } 
			[DataMember]
			public CL5_APOBackoffice_CustomerOrder.Complex.Retrieval.L5CO_GCOPwDfH_1421[] Positions { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6BS_GCOPwHDfH_0748 cls_Get_CustomerOrderPositions_with_HeaderData_for_HeaderID(,P_L6BS_GCOPwHDfH_0748 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6BS_GCOPwHDfH_0748 invocationResult = cls_Get_CustomerOrderPositions_with_HeaderData_for_HeaderID.Invoke(connectionString,P_L6BS_GCOPwHDfH_0748 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_Sales.Complex.Retrieval.P_L6BS_GCOPwHDfH_0748();
parameter.CustomerOrderHeaderID = ...;

*/
