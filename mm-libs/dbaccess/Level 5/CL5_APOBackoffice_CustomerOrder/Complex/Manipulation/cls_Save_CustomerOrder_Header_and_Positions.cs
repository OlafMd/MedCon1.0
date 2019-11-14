/* 
 * Generated on 6/4/2014 7:43:50 AM
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

namespace CL5_APOBackoffice_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomerOrder_Header_and_Positions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomerOrder_Header_and_Positions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_SCOHaP_1043 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_SCOHaP_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5CO_SCOHaP_1043();
            returnValue.Result = new L5CO_SCOHaP_1043();

            var resultCustomerOrderHeader = cls_Save_CustomerOrderHeader.Invoke(Connection, Transaction, Parameter.Header, securityTicket).Result;
            returnValue.Result.CustomerOrderHeaderId = resultCustomerOrderHeader.CustomerOrderHeaderId;
            returnValue.Result.CustomerInteractionsId = resultCustomerOrderHeader.CustomerInteractionsId;
            Parameter.Positions.CustomerOrderHeaderID = resultCustomerOrderHeader.CustomerOrderHeaderId;
            var positionsResults = cls_Save_CustomerOrderPositions.Invoke(Connection, Transaction, Parameter.Positions, securityTicket).Result;

            #region Update Customer Order Total Value
            var header = new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Header();
            header.Load(Connection, Transaction, resultCustomerOrderHeader.CustomerOrderHeaderId);

            var positions = CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query.Search(Connection, Transaction,
                    new CL1_ORD_CUO.ORM_ORD_CUO_CustomerOrder_Position.Query
                    {
                        CustomerOrder_Header_RefID = resultCustomerOrderHeader.CustomerOrderHeaderId,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    });
            header.TotalValue_BeforeTax = positions.Sum(x => x.Position_ValueTotal);
            header.Save(Connection, Transaction);
            #endregion

            P_L5CO_AOWS_1447 acceptParameter = new P_L5CO_AOWS_1447
            {
                CustomerOrderHeaderID = resultCustomerOrderHeader.CustomerOrderHeaderId,
                Message = String.Empty
            };

            cls_AcceptOrderWithShipment.Invoke(Connection, Transaction, acceptParameter, securityTicket);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_SCOHaP_1043 Invoke(string ConnectionString,P_L5CO_SCOHaP_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_SCOHaP_1043 Invoke(DbConnection Connection,P_L5CO_SCOHaP_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_SCOHaP_1043 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_SCOHaP_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_SCOHaP_1043 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_SCOHaP_1043 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_SCOHaP_1043 functionReturn = new FR_L5CO_SCOHaP_1043();
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

				throw new Exception("Exception occured in method cls_Save_CustomerOrder_Header_and_Positions",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_SCOHaP_1043 : FR_Base
	{
		public L5CO_SCOHaP_1043 Result	{ get; set; }

		public FR_L5CO_SCOHaP_1043() : base() {}

		public FR_L5CO_SCOHaP_1043(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_SCOHaP_1043 for attribute P_L5CO_SCOHaP_1043
		[DataContract]
		public class P_L5CO_SCOHaP_1043 
		{
			//Standard type parameters
			[DataMember]
			public P_L5CO_COH_1326 Header { get; set; } 
			[DataMember]
			public P_L5CO_COP_1459 Positions { get; set; } 

		}
		#endregion
		#region SClass L5CO_SCOHaP_1043 for attribute L5CO_SCOHaP_1043
		[DataContract]
		public class L5CO_SCOHaP_1043 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderId { get; set; } 
			[DataMember]
			public Guid CustomerInteractionsId { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_SCOHaP_1043 cls_Save_CustomerOrder_Header_and_Positions(,P_L5CO_SCOHaP_1043 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_SCOHaP_1043 invocationResult = cls_Save_CustomerOrder_Header_and_Positions.Invoke(connectionString,P_L5CO_SCOHaP_1043 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Manipulation.P_L5CO_SCOHaP_1043();
parameter.Header = ...;
parameter.Positions = ...;

*/
