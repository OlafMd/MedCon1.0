/* 
 * Generated on 8/5/2014 9:19:12 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CL1_USR;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_Products.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Product_Note.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Product_Note
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2P_SPN_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here

            var account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            var item = new CL1_CMN_PRO.ORM_CMN_PRO_Product_Note();
            if (Parameter.Product_NoteID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.Product_NoteID);
            }

            if (Parameter.IsDeleted == true)
            {
                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.CMN_PRO_Product_NoteID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.Product_NoteID == Guid.Empty)
            {
                item.Tenant_RefID = securityTicket.TenantID;

                item.CMN_PRO_Product_NoteID = Guid.NewGuid();
            }

            item.Product_RefID = Parameter.Product_RefID;
		    item.IsImportant = Parameter.IsImportant;
		    item.NoteContent = Parameter.NoteContent;
            item.CreatedBy_BusinessParticipant_RefID = account.BusinessParticipant_RefID;
            
            return new FR_Guid(item.Save(Connection, Transaction), item.CMN_PRO_Product_NoteID);

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2P_SPN_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2P_SPN_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2P_SPN_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2P_SPN_1655 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Product_Note",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2P_SPN_1655 for attribute P_L2P_SPN_1655
		[DataContract]
		public class P_L2P_SPN_1655 
		{
			//Standard type parameters
			[DataMember]
			public Guid Product_NoteID { get; set; } 
			[DataMember]
			public Guid Product_RefID { get; set; } 
			[DataMember]
			public Boolean IsImportant { get; set; } 
			[DataMember]
			public String NoteContent { get; set; } 
			[DataMember]
			public Guid BusinessParticipient_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Product_Note(,P_L2P_SPN_1655 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Product_Note.Invoke(connectionString,P_L2P_SPN_1655 Parameter,securityTicket);
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
var parameter = new CL2_Products.Atomic.Manipulation.P_L2P_SPN_1655();
parameter.Product_NoteID = ...;
parameter.Product_RefID = ...;
parameter.IsImportant = ...;
parameter.NoteContent = ...;
parameter.BusinessParticipient_RefID = ...;
parameter.IsDeleted = ...;

*/
