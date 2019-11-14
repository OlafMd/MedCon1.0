/* 
 * Generated on 9/12/2013 02:51:22
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
using CL1_CMN_BPT;

namespace CL5_APOWebShop_ShoppingCart.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ShoppingCart_Note.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ShoppingCart_Note
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5AWSAR_SSCN_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            ORM_ORD_PRC_ShoppingCart_Note note = new ORM_ORD_PRC_ShoppingCart_Note();
            ORM_CMN_BPT_Memo memo = new ORM_CMN_BPT_Memo();

            if (Parameter.ShoppingCart_NoteID != Guid.Empty)
            {
                var fetchedNote = note.Load(Connection, Transaction, Parameter.ShoppingCart_NoteID);
                if (fetchedNote.Status != FR_Status.Success || note.ORD_PRC_ShoppingCart_NoteID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                var fetchedMemo = memo.Load(Connection, Transaction, note.CMN_BPT_Memo_RefID);
                if (fetchedMemo.Status != FR_Status.Success || note.ORD_PRC_ShoppingCart_NoteID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                // Only original poster can change or delete comment
                if (memo.CreatedBy_Account_RefID != securityTicket.AccountID)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "Only original poster can change or delete this comment";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            else
            {
                // new memo - other fields will be copied in save region
                memo.CMN_BPT_MemoID = Guid.NewGuid();
                memo.CreatedBy_Account_RefID = securityTicket.AccountID;
                memo.Creation_Timestamp = DateTime.Now;
                // new note
                note.ORD_PRC_ShoppingCart_NoteID = Guid.NewGuid();
                note.CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID;
                note.ORD_PRC_ShoppingCart_RefID = Parameter.ShoppingCart_ShoppingCartID;
                note.Creation_Timestamp = DateTime.Now;
            }
            
            #region Delete
            if (Parameter.IsDeleted == true)
            {
                // delete note
                note.IsDeleted = true;
                note.Save(Connection, Transaction);
                // delete memo
                ORM_CMN_BPT_Memo.Query query = new ORM_CMN_BPT_Memo.Query();
                query.IsDeleted = true;
                query.CMN_BPT_MemoID = note.CMN_BPT_Memo_RefID;
                int rows = ORM_CMN_BPT_Memo.Query.SoftDelete(Connection, Transaction, query);
                if (rows != 1)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "Deleting memo has failed.";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            #endregion

            #region Save Note and Memo
            // save shopping cart note
            note.Tenant_RefID = securityTicket.TenantID;
            note.Save(Connection, Transaction);
            // save memo
            memo.CMN_BPT_MemoID = note.CMN_BPT_Memo_RefID;
            memo.Memo_Text = Parameter.Memo_Text;
            memo.UpdatedOn = DateTime.Now;
            memo.UpdatedBy_Account_RefID = securityTicket.AccountID;
            memo.Tenant_RefID = securityTicket.TenantID;
            memo.Save(Connection, Transaction);
            #endregion
            
            returnValue.Result = note.ORD_PRC_ShoppingCart_NoteID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5AWSAR_SSCN_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5AWSAR_SSCN_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AWSAR_SSCN_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AWSAR_SSCN_1344 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_ShoppingCart_Note",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5AWSAR_SSCN_1344 for attribute P_L5AWSAR_SSCN_1344
		[DataContract]
		public class P_L5AWSAR_SSCN_1344 
		{
			//Standard type parameters
			[DataMember]
			public Guid ShoppingCart_NoteID { get; set; } 
			[DataMember]
			public Guid ShoppingCart_ShoppingCartID { get; set; } 
			[DataMember]
			public String Memo_Text { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ShoppingCart_Note(,P_L5AWSAR_SSCN_1344 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ShoppingCart_Note.Invoke(connectionString,P_L5AWSAR_SSCN_1344 Parameter,securityTicket);
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
var parameter = new CL5_APOWebShop_ShoppingCart.Complex.Manipulation.P_L5AWSAR_SSCN_1344();
parameter.ShoppingCart_NoteID = ...;
parameter.ShoppingCart_ShoppingCartID = ...;
parameter.Memo_Text = ...;
parameter.IsDeleted = ...;

*/
