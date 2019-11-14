/* 
 * Generated on 8/1/2013 3:37:25 PM
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
using CL1_DOC;

namespace CL5_KPRS_Buildings.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_BuildingImage.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_BuildingImage
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_SBI_1360 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            //Put your code here
            ORM_DOC_Structure structure = new ORM_DOC_Structure();
            structure.Structure_Header_RefID = Parameter.DOC_StructureHeaderRefID;
            structure.CreatedBy_Account_RefID = securityTicket.AccountID;
            structure.Tenant_RefID = securityTicket.TenantID;
            structure.Save(Connection, Transaction);

            ORM_DOC_Document document = new ORM_DOC_Document();
            document.Tenant_RefID = securityTicket.TenantID;
            document.Save(Connection, Transaction);

            ORM_DOC_Document_2_Structure documentStructure = new ORM_DOC_Document_2_Structure();
            documentStructure.Document_RefID = document.DOC_DocumentID;
            documentStructure.Structure_RefID = structure.DOC_StructureID;
            documentStructure.StructureHeader_RefID = Parameter.DOC_StructureHeaderRefID;
            documentStructure.Tenant_RefID = securityTicket.TenantID;
            documentStructure.Save(Connection, Transaction);

            ORM_DOC_DocumentRevision documentRevision = new ORM_DOC_DocumentRevision();
            documentRevision.DOC_DocumentRevisionID = Parameter.DocumentID;
            documentRevision.Document_RefID = document.DOC_DocumentID;
            documentRevision.File_Name = Parameter.File_Name;
            documentRevision.File_Description = Parameter.File_Description;
            documentRevision.File_SourceLocation = Parameter.File_SourceLocation;
            documentRevision.File_ServerLocation = Parameter.File_ServerLocation;
            documentRevision.File_MIMEType = Parameter.File_MIMEType;
            documentRevision.File_Extension = Parameter.File_Extension;
            documentRevision.File_Size_Bytes = Parameter.File_Size_Bytes;
            documentRevision.UploadedByAccount = securityTicket.AccountID;
            documentRevision.Tenant_RefID = securityTicket.TenantID;
            documentRevision.Save(Connection, Transaction);

            returnValue.Result = documentRevision.DOC_DocumentRevisionID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5BD_SBI_1360 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5BD_SBI_1360 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_SBI_1360 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_SBI_1360 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BD_SBI_1360 for attribute P_L5BD_SBI_1360
		[DataContract]
		public class P_L5BD_SBI_1360 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_StructureHeaderRefID { get; set; } 
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
			public Int64 File_Size_Bytes { get; set; } 
			[DataMember]
			public Guid DocumentID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_BuildingImage(P_L5BD_SBI_1360 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_Guid result = cls_Save_BuildingImage.Invoke(connectionString,P_L5BD_SBI_1360 Parameter,securityTicket);
	 return result;
}
*/