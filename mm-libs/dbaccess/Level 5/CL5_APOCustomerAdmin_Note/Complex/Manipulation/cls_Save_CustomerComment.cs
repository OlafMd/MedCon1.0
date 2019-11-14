/* 
 * Generated on 9/24/2014 4:21:17 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL1_CMN_BPT;

namespace CL5_APOCustomerAdmin_Customer.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_CustomerComment.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_CustomerComment
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5CN_SCC_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here          

            ORM_CMN_BPT_Memo memo = new ORM_CMN_BPT_Memo();
            ORM_CMN_BPT_Memo_RelatedParticipant memoRelatedParticipant = new ORM_CMN_BPT_Memo_RelatedParticipant();

            if (Parameter.IsDeleted)
            {
                memo.Load(Connection, Transaction, Parameter.CMN_BPT_MemoID);
                memo.IsDeleted = true;

                memoRelatedParticipant = ORM_CMN_BPT_Memo_RelatedParticipant.Query.Search(Connection, Transaction,
                    new ORM_CMN_BPT_Memo_RelatedParticipant.Query()
                    {
                        CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID,
                        IsDeleted = false,
                        Tenant_RefID = securityTicket.TenantID
                    }
                    ).Single();
                memoRelatedParticipant.IsDeleted = true;

                memo.Save(Connection, Transaction);
                memoRelatedParticipant.Save(Connection, Transaction);
                returnValue.Result = memo.CMN_BPT_MemoID;
            }

            //Initialy create customer note
            if (Parameter.CMN_BPT_MemoID == Guid.Empty)
            {
                memo.CMN_BPT_MemoID = Guid.NewGuid();              
                memo.CreatedBy_Account_RefID = securityTicket.AccountID;
                memo.Creation_Timestamp = DateTime.Now;               
                memo.Tenant_RefID = securityTicket.TenantID;
                
                memoRelatedParticipant.CMN_BPT_Memo_RelatedParticipantID = Guid.NewGuid();
                memoRelatedParticipant.CMN_BPT_BusinessParticipant_RefID = Parameter.Memo_BusinessParticipant_RefID;
                memoRelatedParticipant.CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID;
                memoRelatedParticipant.Tenant_RefID = securityTicket.TenantID;
                memoRelatedParticipant.Save(Connection, Transaction);
            }
            //Load memo if already exist
            else
            {
                memo.Load(Connection, Transaction, Parameter.CMN_BPT_MemoID);
                memo.UpdatedOn = DateTime.Now;
                memo.UpdatedBy_Account_RefID = securityTicket.AccountID;
            }

            memo.Memo_Text = Parameter.Memo_Text;
            memo.IsImportant = Parameter.IsImportant;
            memo.Save(Connection, Transaction);
            memoRelatedParticipant.Save(Connection, Transaction);

            returnValue.Result = memo.CMN_BPT_MemoID;
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5CN_SCC_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5CN_SCC_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CN_SCC_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CN_SCC_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_CustomerComment",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5CN_SCC_1544 for attribute P_L5CN_SCC_1544
		[DataContract]
		public class P_L5CN_SCC_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_MemoID { get; set; } 
			[DataMember]
			public Guid Memo_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String Memo_Text { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public Boolean IsImportant { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_CustomerComment(,P_L5CN_SCC_1544 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_CustomerComment.Invoke(connectionString,P_L5CN_SCC_1544 Parameter,securityTicket);
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
var parameter = new CL5_APOCustomerAdmin_Customer.Complex.Manipulation.P_L5CN_SCC_1544();
parameter.CMN_BPT_MemoID = ...;
parameter.Memo_BusinessParticipant_RefID = ...;
parameter.Memo_Text = ...;
parameter.IsDeleted = ...;
parameter.IsImportant = ...;

*/
