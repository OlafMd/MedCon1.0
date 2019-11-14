/* 
 * Generated on 4/8/2014 10:07:07 AM
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
using CL1_ORD_PRC;

namespace CL2_ProcurementOrder.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProcurementOrder_Note.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProcurementOrder_Note
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2PO_SPON_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();

            var item = new ORM_ORD_PRC_ProcurementOrder_Note();
            if (Parameter.ORD_PRC_ProcurementOrder_NoteID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.ORD_PRC_ProcurementOrder_NoteID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.ORD_PRC_ProcurementOrder_NoteID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.ORD_PRC_ProcurementOrder_NoteID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;
            }

            item.ORD_PRC_ProcurementOrder_Header_RefID = Parameter.ORD_PRC_ProcurementOrder_Header_RefID;
            item.ORD_PRC_ProcurementOrder_Position_RefID = Parameter.ORD_PRC_ProcurementOrder_Position_RefID;
            item.CMN_STR_Office_RefID = Parameter.CMN_STR_Office_RefID;
            item.Comment = Parameter.Comment;
            item.Title = Parameter.Title;
            item.NotePublishDate = Parameter.NotePublishDate;
            item.SequenceOrderNumber = Parameter.SequenceOrderNumber;

            return new FR_Guid(item.Save(Connection, Transaction), item.ORD_PRC_ProcurementOrder_NoteID);
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2PO_SPON_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2PO_SPON_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PO_SPON_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PO_SPON_1005 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ProcurementOrder_Note",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2PO_SPON_1005 for attribute P_L2PO_SPON_1005
		[DataContract]
		public class P_L2PO_SPON_1005 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_NoteID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_Header_RefID { get; set; } 
			[DataMember]
			public Guid ORD_PRC_ProcurementOrder_Position_RefID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public DateTime NotePublishDate { get; set; } 
			[DataMember]
			public int SequenceOrderNumber { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ProcurementOrder_Note(,P_L2PO_SPON_1005 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ProcurementOrder_Note.Invoke(connectionString,P_L2PO_SPON_1005 Parameter,securityTicket);
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
var parameter = new CL2_ProcurementOrder.Atomic.Manipulation.P_L2PO_SPON_1005();
parameter.ORD_PRC_ProcurementOrder_NoteID = ...;
parameter.ORD_PRC_ProcurementOrder_Header_RefID = ...;
parameter.ORD_PRC_ProcurementOrder_Position_RefID = ...;
parameter.CMN_STR_Office_RefID = ...;
parameter.Comment = ...;
parameter.Title = ...;
parameter.NotePublishDate = ...;
parameter.SequenceOrderNumber = ...;
parameter.IsDeleted = ...;

*/
