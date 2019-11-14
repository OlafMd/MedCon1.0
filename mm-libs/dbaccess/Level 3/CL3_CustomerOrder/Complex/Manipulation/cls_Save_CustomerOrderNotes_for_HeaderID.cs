/* 
 * Generated on 7/28/2014 2:47:30 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL2_CustomerOrder.Atomic.Manipulation;
using CL1_USR;

namespace CL3_CustomerOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomerOrderNotes_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomerOrderNotes_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guids Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_SCONfH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_Guids();
            var results = new List<Guid>();

            #region Get Account Bussiness participant id
            var resultAccount = new ORM_USR_Account();
            resultAccount.Load(Connection, Transaction, securityTicket.AccountID);
            #endregion

            foreach (var note in Parameter.Notes)
            {
                var result = cls_Save_ORD_CUO_CustomerOrder_Note.Invoke(
                    Connection
                    , Transaction
                    , new P_L2CO_SCON_1442()
                    {
                        CustomerOrder_Header_RefID = Parameter.CustomerOrderHeaderId,
                        CustomerOrder_Position_RefID = note.CustomerOrderPositionId,
                        CMN_BPT_CTM_OrganizationalUnit_RefID = note.OrganizationslUnitId,
                        CreatedBy_BusinessParticipant_RefID = resultAccount.BusinessParticipant_RefID,
                        Title = note.Title,
                        Comment = note.Comment,
                        NotePublishDate = note.NotePublichDate,
                        SequenceOrderNumber = -1  // TODO:Marko - leve it empty, for now
                    }
                    , securityTicket);
                if (result.Status != FR_Status.Success) 
                {
                    returnValue.Status = FR_Status.Error_Internal;
                    returnValue.Result = null;
                    return returnValue;
                }
                results.Add(result.Result);
            }
            returnValue.Status = FR_Status.Success;
            returnValue.Result = results.ToArray();

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guids Invoke(string ConnectionString,P_L3CO_SCONfH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection,P_L3CO_SCONfH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_SCONfH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_SCONfH_1413 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guids functionReturn = new FR_Guids();
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

				throw new Exception("Exception occured in method cls_Save_CustomerOrderNotes_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3CO_SCONfH_1413 for attribute P_L3CO_SCONfH_1413
		[DataContract]
		public class P_L3CO_SCONfH_1413 
		{
			[DataMember]
			public P_L3CO_SCONfH_1413a[] Notes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderId { get; set; } 
			[DataMember]
			public Guid CreatedByBusinessParticipantId { get; set; } 

		}
		#endregion
		#region SClass P_L3CO_SCONfH_1413a for attribute Notes
		[DataContract]
		public class P_L3CO_SCONfH_1413a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderPositionId { get; set; } 
			[DataMember]
			public Guid OrganizationslUnitId { get; set; } 
			[DataMember]
			public string Title { get; set; } 
			[DataMember]
			public string Comment { get; set; } 
			[DataMember]
			public DateTime NotePublichDate { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Save_CustomerOrderNotes_for_HeaderID(,P_L3CO_SCONfH_1413 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Save_CustomerOrderNotes_for_HeaderID.Invoke(connectionString,P_L3CO_SCONfH_1413 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Complex.Manipulation.P_L3CO_SCONfH_1413();
parameter.Notes = ...;

parameter.CustomerOrderHeaderId = ...;
parameter.CreatedByBusinessParticipantId = ...;

*/
