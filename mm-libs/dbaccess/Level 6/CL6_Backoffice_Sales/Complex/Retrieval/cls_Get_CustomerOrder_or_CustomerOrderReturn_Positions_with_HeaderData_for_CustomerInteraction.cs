/* 
 * Generated on 6/20/2014 3:56:01 PM
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
using CL5_APOBackoffice_CustomerOrder.Complex.Retrieval;
using CL1_ORD_CUO;
using CL1_CMN_POS;
using CL3_CustomerOrder.Atomic.Retrieval;

namespace CL6_Backoffice_Sales.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrder_or_CustomerOrderReturn_Positions_with_HeaderData_for_CustomerInteraction.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrder_or_CustomerOrderReturn_Positions_with_HeaderData_for_CustomerInteraction
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL6_GCOoCORPwHDfCI_1312 Execute(DbConnection Connection,DbTransaction Transaction,P_CL6_GCOoCORPwHDfCI_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_CL6_GCOoCORPwHDfCI_1312();

            #region Get CustomerInteraction
            var customerInteraction = new ORM_CMN_POS_CustomerInteraction();
            customerInteraction.Load(Connection, Transaction, Parameter.CustomerInteractionID);
            #endregion

            #region Get CustomerOrder Header Data and Positions
            CL3_GCODfH_1537 customerOrderHeaderData = null;
            L5CO_GCOPwDfH_1421[] customerOrderPositions = null;
            if (customerInteraction.IsCustomerOrderInteraction)
            {
                var resultCustomerOrderHeaderWithPositions = cls_Get_CustomerOrderPositions_with_HeaderData_for_HeaderID.Invoke(
                    Connection,
                    Transaction,
                    new P_L6BS_GCOPwHDfH_0748() { CustomerOrderHeaderID = customerInteraction.CustomerOrderHeader_RefID },
                    securityTicket);
                if (resultCustomerOrderHeaderWithPositions.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }
                customerOrderHeaderData = resultCustomerOrderHeaderWithPositions.Result.HeaderData;
                customerOrderPositions = resultCustomerOrderHeaderWithPositions.Result.Positions;
            }
            #endregion

            #region Get CustomerOrderReturn Header Data and Positions
            CL6_GCOoCORPwHDfCI_1312a customerOrderReturnHeaderData = null;
            L5CO_GCORPwDfH_1521[] customerOrderReturnPositions = null;
            if (customerInteraction.IsCustomerOrderReturnInteraction)
            {
                var resultCustomerOrderReturnHeader = new ORM_ORD_CUO_CustomerOrderReturn_Header();
                resultCustomerOrderReturnHeader.Load(Connection, Transaction, customerInteraction.CustomerOrderReturnHeader_RefID);
                customerOrderReturnHeaderData = new CL6_GCOoCORPwHDfCI_1312a()
                {
                    CustomerOrderReturnHeaderID = resultCustomerOrderReturnHeader.ORD_CUO_CustomerOrderReturn_HeaderID,
                    CustomerOrderReturnHeaderNumber = resultCustomerOrderReturnHeader.CustomerOrderReturnNumber,
                    CustomerOrderReturnHeaderOrderDate = resultCustomerOrderReturnHeader.DateOfCustomerReturn
                };
                var resultCustomerOrderReturnPositions = cls_Get_CustomerOrderReturnPositions_with_Details_for_HeaderID.Invoke(
                    Connection,
                    Transaction,
                    new P_L5CO_GCORPwDfH_1521() { CustomerOrderReturnHeaderID = customerInteraction.CustomerOrderReturnHeader_RefID },
                    securityTicket);
                if (resultCustomerOrderReturnPositions.Status != FR_Status.Success)
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }
                customerOrderReturnPositions = resultCustomerOrderReturnPositions.Result;
            }
            #endregion

            #region Set Result
            returnValue.Result = new CL6_GCOoCORPwHDfCI_1312();
            returnValue.Result.CustomerOrderHeaderData = customerOrderHeaderData;
            returnValue.Result.CustomerOrderPositions = customerOrderPositions;
            returnValue.Result.CustomerOrderReturnHeaderData = customerOrderReturnHeaderData;
            returnValue.Result.CustomerOrderReturnPositions = customerOrderReturnPositions;
            returnValue.Status = FR_Status.Success;
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CL6_GCOoCORPwHDfCI_1312 Invoke(string ConnectionString,P_CL6_GCOoCORPwHDfCI_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL6_GCOoCORPwHDfCI_1312 Invoke(DbConnection Connection,P_CL6_GCOoCORPwHDfCI_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL6_GCOoCORPwHDfCI_1312 Invoke(DbConnection Connection, DbTransaction Transaction,P_CL6_GCOoCORPwHDfCI_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL6_GCOoCORPwHDfCI_1312 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL6_GCOoCORPwHDfCI_1312 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL6_GCOoCORPwHDfCI_1312 functionReturn = new FR_CL6_GCOoCORPwHDfCI_1312();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrder_or_CustomerOrderReturn_Positions_with_HeaderData_for_CustomerInteraction",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL6_GCOoCORPwHDfCI_1312 : FR_Base
	{
		public CL6_GCOoCORPwHDfCI_1312 Result	{ get; set; }

		public FR_CL6_GCOoCORPwHDfCI_1312() : base() {}

		public FR_CL6_GCOoCORPwHDfCI_1312(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL6_GCOoCORPwHDfCI_1312 for attribute P_CL6_GCOoCORPwHDfCI_1312
		[DataContract]
		public class P_CL6_GCOoCORPwHDfCI_1312 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerInteractionID { get; set; } 

		}
		#endregion
		#region SClass CL6_GCOoCORPwHDfCI_1312 for attribute CL6_GCOoCORPwHDfCI_1312
		[DataContract]
		public class CL6_GCOoCORPwHDfCI_1312 
		{
			[DataMember]
			public CL6_GCOoCORPwHDfCI_1312a CustomerOrderReturnHeaderData { get; set; }

			//Standard type parameters
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.CL3_GCODfH_1537 CustomerOrderHeaderData { get; set; } 
			[DataMember]
			public CL5_APOBackoffice_CustomerOrder.Complex.Retrieval.L5CO_GCOPwDfH_1421[] CustomerOrderPositions { get; set; } 
			[DataMember]
			public CL5_APOBackoffice_CustomerOrder.Complex.Retrieval.L5CO_GCORPwDfH_1521[] CustomerOrderReturnPositions { get; set; } 

		}
		#endregion
		#region SClass CL6_GCOoCORPwHDfCI_1312a for attribute CustomerOrderReturnHeaderData
		[DataContract]
		public class CL6_GCOoCORPwHDfCI_1312a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderReturnHeaderID { get; set; } 
			[DataMember]
			public string CustomerOrderReturnHeaderNumber { get; set; } 
			[DataMember]
			public DateTime CustomerOrderReturnHeaderOrderDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL6_GCOoCORPwHDfCI_1312 cls_Get_CustomerOrder_or_CustomerOrderReturn_Positions_with_HeaderData_for_CustomerInteraction(,P_CL6_GCOoCORPwHDfCI_1312 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL6_GCOoCORPwHDfCI_1312 invocationResult = cls_Get_CustomerOrder_or_CustomerOrderReturn_Positions_with_HeaderData_for_CustomerInteraction.Invoke(connectionString,P_CL6_GCOoCORPwHDfCI_1312 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_Sales.Complex.Retrieval.P_CL6_GCOoCORPwHDfCI_1312();
parameter.CustomerInteractionID = ...;

*/
