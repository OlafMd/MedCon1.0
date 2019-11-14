/* 
 * Generated on 6/19/2014 8:17:12 AM
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
using CL1_CMN_POS;
using CL3_CustomerOrder.Atomic.Retrieval;
using CL3_CustomerOrder.Complex.Retrieval;

namespace CL6_Backoffice_OrderHistory.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_relatedTo_CustomerInteractions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_relatedTo_CustomerInteractions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6OH_GCOoCORHwPrCI_1643 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6OH_GCOoCORHwPrCI_1643();

            #region Get CustomerInteractions
            var customerInteractions = ORM_CMN_POS_CustomerInteraction.Query.Search(
                Connection,
                Transaction,
                new ORM_CMN_POS_CustomerInteraction.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                });
            if (customerInteractions == null || customerInteractions.Count <= 0)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get CustomerOrder Headers with Positions
            var customerInteractionsWithoutReturnOrderHeaders = customerInteractions
                    .Where(ci => ci.IsCustomerOrderInteraction == true && ci.IsCustomerOrderReturnInteraction == false);
            var parameterCustomerOrderHeaders = new P_L3CO_GCOHwPbH_1604()
            {
                CustomerOrderHeaderIDs = customerInteractionsWithoutReturnOrderHeaders
                    .Select(ci => ci.CustomerOrderHeader_RefID).ToArray()
            };
            L3CO_GCOHwPbH_1604[] customerOrderHeaders = null;
            if (parameterCustomerOrderHeaders.CustomerOrderHeaderIDs != null && parameterCustomerOrderHeaders.CustomerOrderHeaderIDs.Count() > 0)
            {
                customerOrderHeaders =
                    cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs.Invoke(
                        Connection,
                        Transaction,
                        new P_L3CO_GCOHwPbH_1604() { CustomerOrderHeaderIDs = parameterCustomerOrderHeaders.CustomerOrderHeaderIDs.ToArray() },
                        securityTicket).Result;
            }
            if (customerOrderHeaders != null && customerOrderHeaders.Count() != customerInteractionsWithoutReturnOrderHeaders.Count())
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get CustomerOrderReturn Headers with Positions
            var customerInteractionsWithoutOrderHeaders = customerInteractions
                    .Where(ci => ci.IsCustomerOrderInteraction == false && ci.IsCustomerOrderReturnInteraction == true);
            var parameterCustomerOrderReturnHeaders = new P_L3CO_GCORHwPbH_1610()
            {
                CustomerOrderReturnHeaderIDs = customerInteractionsWithoutOrderHeaders
                    .Select(ci => ci.CustomerOrderReturnHeader_RefID).ToArray()
            };
            L3CO_GCORHwPbH_1610[] customerOrderReturnHeaders = null;
            if (parameterCustomerOrderReturnHeaders.CustomerOrderReturnHeaderIDs != null && parameterCustomerOrderReturnHeaders.CustomerOrderReturnHeaderIDs.Count() > 0)
            {
                customerOrderReturnHeaders =
                    cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs.Invoke(
                        Connection,
                        Transaction,
                        new P_L3CO_GCORHwPbH_1610() { CustomerOrderReturnHeaderIDs = parameterCustomerOrderReturnHeaders.CustomerOrderReturnHeaderIDs.ToArray() },
                        securityTicket).Result;
            }
            if (customerOrderReturnHeaders != null && customerOrderReturnHeaders.Count() != customerInteractionsWithoutOrderHeaders.Count())
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get Both Headers with Positions
            var customerInteractionsWithBothHeaders =
                customerInteractions.Where(ci => ci.IsCustomerOrderInteraction == true && ci.IsCustomerOrderReturnInteraction == true);
            var bothHeaders =
                cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_by_HeaderIDs.Invoke(
                    Connection,
                    Transaction,
                    new P_L3CO_GCOoCORHwPbH_1622()
                    {
                        CustomerOrderHeaderIDs = customerInteractionsWithBothHeaders.Select(ci => ci.CustomerOrderHeader_RefID).ToArray(),
                        CustomerOrderReturnHeaderIDs = customerInteractionsWithBothHeaders.Select(ci => ci.CustomerOrderReturnHeader_RefID).ToArray()
                    },
                    securityTicket).Result;
            if ((bothHeaders != null 
                && bothHeaders.CustomerOrderHeaders != null 
                && bothHeaders.CustomerOrderHeaders.Count() != customerInteractionsWithBothHeaders.Count()) 
                || 
                (bothHeaders != null 
                && bothHeaders.CustomerOrderReturnHeaders != null 
                && bothHeaders.CustomerOrderReturnHeaders.Count() != customerInteractionsWithBothHeaders.Count()))
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Set Result
            returnValue.Result = new L6OH_GCOoCORHwPrCI_1643();

            #region Set CustomerOrder Result
            var resultOrderHeaders = new List<L6OH_GCOoCORHwPrCI_1643a>();
            foreach (var interaction in customerInteractionsWithoutReturnOrderHeaders)
            {
                resultOrderHeaders.Add(new L6OH_GCOoCORHwPrCI_1643a()
                {
                    CustomerInteractionID = interaction.CMN_POS_CustomerInteractionID,
                    CustomerOrderHeader = 
                        customerOrderHeaders.Where(coh => coh.ORD_CUO_CustomerOrder_HeaderID == interaction.CustomerOrderHeader_RefID).FirstOrDefault()
                });
            }
            returnValue.Result.OrderHeaders = resultOrderHeaders.ToArray();
            #endregion

            #region Set CustomerOrderReturn Result
            var resultReturnOrderHeaders = new List<L6OH_GCOoCORHwPrCI_1643b>();
            foreach (var interaction in customerInteractionsWithoutOrderHeaders)
            {
                resultReturnOrderHeaders.Add(new L6OH_GCOoCORHwPrCI_1643b()
                {
                    CustomerInteractionID = interaction.CMN_POS_CustomerInteractionID,
                    CustomerOrderReturnHeader = 
                        customerOrderReturnHeaders.Where(corh => corh.ORD_CUO_CustomerOrderReturn_HeaderID == interaction.CustomerOrderReturnHeader_RefID).FirstOrDefault()
                });
            }
            returnValue.Result.ReturnOrderHeaders = resultReturnOrderHeaders.ToArray();
            #endregion

            #region Set Both Headers Result
            var resultBothHeaders = new List<L6OH_GCOoCORHwPrCI_1643c>();
            foreach (var interaction in customerInteractionsWithBothHeaders)
            {
                resultBothHeaders.Add(new L6OH_GCOoCORHwPrCI_1643c()
                {
                    CustomerInteractionID = interaction.CMN_POS_CustomerInteractionID,
                    CustomerOrderHeader =
                        bothHeaders.CustomerOrderHeaders.Where(coh => coh.ORD_CUO_CustomerOrder_HeaderID == interaction.CustomerOrderHeader_RefID).FirstOrDefault(),
                    CustomerOrderReturnHeader =
                        bothHeaders.CustomerOrderReturnHeaders.Where(corh => corh.ORD_CUO_CustomerOrderReturn_HeaderID == interaction.CustomerOrderReturnHeader_RefID).FirstOrDefault()
                });
            }
            returnValue.Result.BothHeaders = resultBothHeaders.ToArray();
            #endregion

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
		public static FR_L6OH_GCOoCORHwPrCI_1643 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6OH_GCOoCORHwPrCI_1643 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6OH_GCOoCORHwPrCI_1643 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6OH_GCOoCORHwPrCI_1643 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6OH_GCOoCORHwPrCI_1643 functionReturn = new FR_L6OH_GCOoCORHwPrCI_1643();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_relatedTo_CustomerInteractions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6OH_GCOoCORHwPrCI_1643 : FR_Base
	{
		public L6OH_GCOoCORHwPrCI_1643 Result	{ get; set; }

		public FR_L6OH_GCOoCORHwPrCI_1643() : base() {}

		public FR_L6OH_GCOoCORHwPrCI_1643(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6OH_GCOoCORHwPrCI_1643 for attribute L6OH_GCOoCORHwPrCI_1643
		[DataContract]
		public class L6OH_GCOoCORHwPrCI_1643 
		{
			[DataMember]
			public L6OH_GCOoCORHwPrCI_1643a[] OrderHeaders { get; set; }
			[DataMember]
			public L6OH_GCOoCORHwPrCI_1643b[] ReturnOrderHeaders { get; set; }
			[DataMember]
			public L6OH_GCOoCORHwPrCI_1643c[] BothHeaders { get; set; }

			//Standard type parameters
		}
		#endregion
		#region SClass L6OH_GCOoCORHwPrCI_1643a for attribute OrderHeaders
		[DataContract]
		public class L6OH_GCOoCORHwPrCI_1643a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerInteractionID { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GCOHwPbH_1604 CustomerOrderHeader { get; set; } 

		}
		#endregion
		#region SClass L6OH_GCOoCORHwPrCI_1643b for attribute ReturnOrderHeaders
		[DataContract]
		public class L6OH_GCOoCORHwPrCI_1643b 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerInteractionID { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GCORHwPbH_1610 CustomerOrderReturnHeader { get; set; } 

		}
		#endregion
		#region SClass L6OH_GCOoCORHwPrCI_1643c for attribute BothHeaders
		[DataContract]
		public class L6OH_GCOoCORHwPrCI_1643c 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerInteractionID { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GCOHwPbH_1604 CustomerOrderHeader { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GCORHwPbH_1610 CustomerOrderReturnHeader { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6OH_GCOoCORHwPrCI_1643 cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_relatedTo_CustomerInteractions(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6OH_GCOoCORHwPrCI_1643 invocationResult = cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_relatedTo_CustomerInteractions.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

