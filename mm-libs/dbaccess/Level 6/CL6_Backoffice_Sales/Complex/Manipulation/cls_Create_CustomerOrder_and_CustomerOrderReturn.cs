/* 
 * Generated on 7/28/2014 2:51:43 PM
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
using CL5_APOBackoffice_CustomerOrder.Complex.Manipulation;
using CL3_CustomerOrder.Complex.Manipulation;
using CL1_CMN_BPT;

namespace CL6_Backoffice_Sales.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_CustomerOrder_and_CustomerOrderReturn.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_CustomerOrder_and_CustomerOrderReturn
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L6SA_CCOaCOR_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_Bool();

            Guid customerInteractionsId = Guid.Empty;
            if (Parameter.CustomerOrder != null && Parameter.CustomerOrder.Positions.Positions.Count() > 0)
            {
                #region Save Customer Order with Positions
                var resultCustomerOrder = cls_Save_CustomerOrder_Header_and_Positions.Invoke(Connection, Transaction, Parameter.CustomerOrder, securityTicket).Result;
                if (resultCustomerOrder != null)
                {
                    customerInteractionsId = resultCustomerOrder.CustomerInteractionsId;
                }
                #endregion

                #region Save CustomerOrder Notes

                var businessParticipant = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction,
                    new ORM_CMN_BPT_BusinessParticipant.Query()
                    {
                        IfTenant_Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                if (Parameter.CustomerOrderNotes != null)
                {
                    Parameter.CustomerOrderNotes.CustomerOrderHeaderId = resultCustomerOrder.CustomerOrderHeaderId;
                    Parameter.CustomerOrderNotes.CreatedByBusinessParticipantId = businessParticipant.CMN_BPT_BusinessParticipantID;
                    var resultCustomerOrderNotes = cls_Save_CustomerOrderNotes_for_HeaderID.Invoke(Connection, Transaction, Parameter.CustomerOrderNotes, securityTicket);
                    if (resultCustomerOrderNotes.Status != FR_Status.Success)
                    {
                        returnValue.Status = FR_Status.Error_Internal;
                        returnValue.Result = false;
                    }
                }
                #endregion
            }
            if (Parameter.CustomerOrderReturn != null && Parameter.CustomerOrderReturn.Positions.Count() > 0)
            {
                #region Save Customer Order Return with Positions
                Parameter.CustomerOrderReturn.CustomerInteractionId = customerInteractionsId;
                cls_Create_CustomerOrderReturn_with_Positions.Invoke(Connection, Transaction, Parameter.CustomerOrderReturn, securityTicket);
                #endregion
            }

            returnValue.Result = true;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L6SA_CCOaCOR_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L6SA_CCOaCOR_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L6SA_CCOaCOR_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6SA_CCOaCOR_1732 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Create_CustomerOrder_and_CustomerOrderReturn",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6SA_CCOaCOR_1732 for attribute P_L6SA_CCOaCOR_1732
		[DataContract]
		public class P_L6SA_CCOaCOR_1732 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_SCOHaP_1043 CustomerOrder { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Complex.Manipulation.P_L3CO_SCONfH_1413 CustomerOrderNotes { get; set; } 
			[DataMember]
			public CL6_Backoffice_Sales.Complex.Manipulation.P_L6SA_CCORwP_1743 CustomerOrderReturn { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Create_CustomerOrder_and_CustomerOrderReturn(,P_L6SA_CCOaCOR_1732 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Create_CustomerOrder_and_CustomerOrderReturn.Invoke(connectionString,P_L6SA_CCOaCOR_1732 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_Sales.Complex.Manipulation.P_L6SA_CCOaCOR_1732();
parameter.CustomerOrder = ...;
parameter.CustomerOrderNotes = ...;
parameter.CustomerOrderReturn = ...;

*/
