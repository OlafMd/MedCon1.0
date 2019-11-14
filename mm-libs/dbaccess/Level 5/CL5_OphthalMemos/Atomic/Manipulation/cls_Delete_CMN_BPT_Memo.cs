/* 
 * Generated on 8/30/2013 4:27:47 PM
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
using CL1_CMN_BPT;
using CL1_DOC;

namespace CL5_OphthalMemos.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_CMN_BPT_Memo.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_CMN_BPT_Memo
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OM_DM_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();
			
            ORM_CMN_BPT_Memo memo = new ORM_CMN_BPT_Memo();
            if (Parameter.CMN_BPT_MemoID != Guid.Empty)
            {
                var result = memo.Load(Connection, Transaction, Parameter.CMN_BPT_MemoID);
                if (result.Status != FR_Status.Success || memo.CMN_BPT_MemoID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
                memo.IsDeleted = true;
                memo.Save(Connection, Transaction);

                var ORM_CMN_BPT_Memo_AdditionalFieldQuery = new ORM_CMN_BPT_Memo_AdditionalField.Query();
                ORM_CMN_BPT_Memo_AdditionalFieldQuery.Memo_RefID = Parameter.CMN_BPT_MemoID;
                ORM_CMN_BPT_Memo_AdditionalFieldQuery.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_BPT_Memo_AdditionalFieldQuery.IsDeleted = false;

                var additianFileds = ORM_CMN_BPT_Memo_AdditionalField.Query.SoftDelete(Connection, Transaction, ORM_CMN_BPT_Memo_AdditionalFieldQuery);

                var ORM_DOC_Structure_Header_Query = new ORM_DOC_Structure_Header.Query();
                ORM_DOC_Structure_Header_Query.IsDeleted = false;
                ORM_DOC_Structure_Header_Query.Tenant_RefID = securityTicket.TenantID;
                ORM_DOC_Structure_Header_Query.DOC_Structure_HeaderID = memo.DocumentStructureHeader_RefID;
                ORM_DOC_Structure_Header.Query.SoftDelete(Connection, Transaction, ORM_DOC_Structure_Header_Query);

                var ORM_DOC_Structure_Query = new ORM_DOC_Structure.Query();
                ORM_DOC_Structure_Query.IsDeleted = false;
                ORM_DOC_Structure_Query.Tenant_RefID = securityTicket.TenantID;
                ORM_DOC_Structure_Query.Structure_Header_RefID = memo.DocumentStructureHeader_RefID;
                ORM_DOC_Structure .Query.SoftDelete(Connection, Transaction, ORM_DOC_Structure_Query);

                var ORM_CMN_BPT_Memo_RelatedParticipant_Query = new ORM_CMN_BPT_Memo_RelatedParticipant.Query();
                ORM_CMN_BPT_Memo_RelatedParticipant_Query.IsDeleted = false;
                ORM_CMN_BPT_Memo_RelatedParticipant_Query.Tenant_RefID = securityTicket.TenantID;
                ORM_CMN_BPT_Memo_RelatedParticipant_Query.CMN_BPT_Memo_RefID = memo.CMN_BPT_MemoID;
                ORM_CMN_BPT_Memo_RelatedParticipant.Query.SoftDelete(Connection, Transaction, ORM_CMN_BPT_Memo_RelatedParticipant_Query);
            }
            

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OM_DM_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OM_DM_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OM_DM_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OM_DM_1011 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Delete_CMN_BPT_Memo",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OM_DM_1011 for attribute P_L5OM_DM_1011
		[DataContract]
		public class P_L5OM_DM_1011 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_MemoID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Delete_CMN_BPT_Memo(,P_L5OM_DM_1011 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Delete_CMN_BPT_Memo.Invoke(connectionString,P_L5OM_DM_1011 Parameter,securityTicket);
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
var parameter = new CL5_OphthalMemos.Atomic.Manipulation.P_L5OM_DM_1011();
parameter.CMN_BPT_MemoID = ...;

*/
