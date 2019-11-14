/* 
 * Generated on 7/28/2014 2:44:41 PM
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
using CL1_ORD_CUO;

namespace CL2_CustomerOrder.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ORD_CUO_CustomerOrder_Note.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ORD_CUO_CustomerOrder_Note
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2CO_SCON_1442 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_ORD_CUO_CustomerOrder_Note();
			if (Parameter.ORD_CUO_CustomerOrder_NoteID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.ORD_CUO_CustomerOrder_NoteID);
			    if (result.Status != FR_Status.Success || item.ORD_CUO_CustomerOrder_NoteID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.ORD_CUO_CustomerOrder_NoteID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.ORD_CUO_CustomerOrder_NoteID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.CustomerOrder_Header_RefID = Parameter.CustomerOrder_Header_RefID;
			item.CustomerOrder_Position_RefID = Parameter.CustomerOrder_Position_RefID;
			item.CMN_BPT_CTM_OrganizationalUnit_RefID = Parameter.CMN_BPT_CTM_OrganizationalUnit_RefID;
			item.CreatedBy_BusinessParticipant_RefID = Parameter.CreatedBy_BusinessParticipant_RefID;
			item.Title = Parameter.Title;
			item.Comment = Parameter.Comment;
			item.NotePublishDate = Parameter.NotePublishDate;
			item.SequenceOrderNumber = Parameter.SequenceOrderNumber;


			return new FR_Guid(item.Save(Connection, Transaction),item.ORD_CUO_CustomerOrder_NoteID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2CO_SCON_1442 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2CO_SCON_1442 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CO_SCON_1442 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CO_SCON_1442 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ORD_CUO_CustomerOrder_Note",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2CO_SCON_1442 for attribute P_L2CO_SCON_1442
		[DataContract]
		public class P_L2CO_SCON_1442 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_CUO_CustomerOrder_NoteID { get; set; } 
			[DataMember]
			public Guid CustomerOrder_Header_RefID { get; set; } 
			[DataMember]
			public Guid CustomerOrder_Position_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_CTM_OrganizationalUnit_RefID { get; set; } 
			[DataMember]
			public Guid CreatedBy_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Comment { get; set; } 
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
FR_Guid cls_Save_ORD_CUO_CustomerOrder_Note(,P_L2CO_SCON_1442 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ORD_CUO_CustomerOrder_Note.Invoke(connectionString,P_L2CO_SCON_1442 Parameter,securityTicket);
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
var parameter = new CL2_CustomerOrder.Atomic.Manipulation.P_L2CO_SCON_1442();
parameter.ORD_CUO_CustomerOrder_NoteID = ...;
parameter.CustomerOrder_Header_RefID = ...;
parameter.CustomerOrder_Position_RefID = ...;
parameter.CMN_BPT_CTM_OrganizationalUnit_RefID = ...;
parameter.CreatedBy_BusinessParticipant_RefID = ...;
parameter.Title = ...;
parameter.Comment = ...;
parameter.NotePublishDate = ...;
parameter.SequenceOrderNumber = ...;
parameter.IsDeleted = ...;

*/
