/* 
 * Generated on 1/10/2014 4:46:22 PM
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
using CL1_DOC;

namespace CL2_Document.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_DOC_DocumentRevision.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_DOC_DocumentRevision
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L2DO_SDDR_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){

			var returnValue = new FR_Guid();

			var item = new ORM_DOC_DocumentRevision();
			if (Parameter.DOC_DocumentRevisionID != Guid.Empty)
			{
			    var result = item.Load(Connection, Transaction, Parameter.DOC_DocumentRevisionID);
			    if (result.Status != FR_Status.Success || item.DOC_DocumentRevisionID == Guid.Empty)
			    {
			        var error = new FR_Guid();
			        error.ErrorMessage = "No Such ID";
			        error.Status =  FR_Status.Error_Internal;
			        return error;
			    }
			}

			if(Parameter.IsDeleted == true){
				item.IsDeleted = true;
				return new FR_Guid(item.Save(Connection, Transaction),item.DOC_DocumentRevisionID);
			}

			//Creation specific parameters (Tenant, Account ... )
			if (Parameter.DOC_DocumentRevisionID == Guid.Empty)
			{
				item.Tenant_RefID = securityTicket.TenantID;
			}

			item.Document_RefID = Parameter.Document_RefID;
			item.Revision = Parameter.Revision;
			item.IsLocked = Parameter.IsLocked;
			item.IsLastRevision = Parameter.IsLastRevision;
			item.UploadedByAccount = Parameter.UploadedByAccount;
			item.File_Name = Parameter.File_Name;
			item.File_Description = Parameter.File_Description;
			item.File_SourceLocation = Parameter.File_SourceLocation;
			item.File_ServerLocation = Parameter.File_ServerLocation;
			item.File_MIMEType = Parameter.File_MIMEType;
			item.File_Extension = Parameter.File_Extension;
			item.File_Size_Bytes = Parameter.File_Size_Bytes;


			return new FR_Guid(item.Save(Connection, Transaction),item.DOC_DocumentRevisionID);
  
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L2DO_SDDR_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L2DO_SDDR_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L2DO_SDDR_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2DO_SDDR_1644 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_DOC_DocumentRevision",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L2DO_SDDR_1644 for attribute P_L2DO_SDDR_1644
		[DataContract]
		public class P_L2DO_SDDR_1644 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_DocumentRevisionID { get; set; } 
			[DataMember]
			public Guid Document_RefID { get; set; } 
			[DataMember]
			public int Revision { get; set; } 
			[DataMember]
			public Boolean IsLocked { get; set; } 
			[DataMember]
			public Boolean IsLastRevision { get; set; } 
			[DataMember]
			public Guid UploadedByAccount { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_Description { get; set; } 
			[DataMember]
			public String File_SourceLocation { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String File_MIMEType { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public long File_Size_Bytes { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_DOC_DocumentRevision(,P_L2DO_SDDR_1644 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_DOC_DocumentRevision.Invoke(connectionString,P_L2DO_SDDR_1644 Parameter,securityTicket);
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
var parameter = new CL2_Document.Atomic.Manipulation.P_L2DO_SDDR_1644();
parameter.DOC_DocumentRevisionID = ...;
parameter.Document_RefID = ...;
parameter.Revision = ...;
parameter.IsLocked = ...;
parameter.IsLastRevision = ...;
parameter.UploadedByAccount = ...;
parameter.File_Name = ...;
parameter.File_Description = ...;
parameter.File_SourceLocation = ...;
parameter.File_ServerLocation = ...;
parameter.File_MIMEType = ...;
parameter.File_Extension = ...;
parameter.File_Size_Bytes = ...;
parameter.IsDeleted = ...;

*/
