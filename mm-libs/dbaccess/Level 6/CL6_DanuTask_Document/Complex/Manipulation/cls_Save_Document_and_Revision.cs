/* 
 * Generated on 7/14/2014 3:37:02 PM
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
using CL3_Document.Atomic.Manipulation;

namespace CL6_DanuTask_Document.Complex.Manipulation
{
	/// <summary>
    /// Save document and document revision
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Document_and_Revision.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Document_and_Revision
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L6DO_SDaR_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            #region Save Document
            P_L3DO_SD_1409 paramDoc = new P_L3DO_SD_1409();
            paramDoc.Alias = Parameter.File_Name;
            Guid documentID = cls_Save_DOC_Document.Invoke(Connection, Transaction, paramDoc, securityTicket).Result;
            #endregion

            #region cls_Save_DOC_Document_2_Structure
            P_L3DO_SD2S_1407 paramDocument2Structure = new P_L3DO_SD2S_1407();
            paramDocument2Structure.Document_RefID = documentID;
            paramDocument2Structure.Structure_RefID = Parameter.Structure_RefID;
            paramDocument2Structure.StructureHeader_RefID = Parameter.Structure_Header_RefID;

            Guid assigmentID = cls_Save_DOC_Document_2_Structure.Invoke(Connection, Transaction, paramDocument2Structure, securityTicket).Result;


            #endregion

            #region cls_Save_DOC_DocumentRevision
            P_L3DO_SDR_1401 paramDocumentRevision = new P_L3DO_SDR_1401();
            paramDocumentRevision.Document_RefID = documentID;
            paramDocumentRevision.Revision = 1;
            paramDocumentRevision.IsLocked = false;
            paramDocumentRevision.IsLastRevision = true;
            paramDocumentRevision.UploadedByAccount = securityTicket.AccountID;
            paramDocumentRevision.File_Name = Parameter.File_Name;
            paramDocumentRevision.File_SourceLocation = "";
            paramDocumentRevision.File_ServerLocation = Parameter.File_ServerLocation;
            paramDocumentRevision.File_MIMEType = Parameter.File_MIMEType;
            paramDocumentRevision.File_Extension = Parameter.File_Extension;
            paramDocumentRevision.File_Size_Bytes = Parameter.File_Size_Bytes;

            cls_Save_DOC_DocumentRevision.Invoke(Connection, Transaction, paramDocumentRevision, securityTicket);


            #endregion

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L6DO_SDaR_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L6DO_SDaR_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DO_SDaR_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DO_SDaR_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Document_and_Revision",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L6DO_SDaR_1536 for attribute P_L6DO_SDaR_1536
		[DataContract]
		public class P_L6DO_SDaR_1536 
		{
			//Standard type parameters
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_Description { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String File_MIMEType { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public long File_Size_Bytes { get; set; } 
			[DataMember]
			public Guid Structure_Header_RefID { get; set; } 
			[DataMember]
			public Guid Structure_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Document_and_Revision(,P_L6DO_SDaR_1536 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Document_and_Revision.Invoke(connectionString,P_L6DO_SDaR_1536 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Document.Complex.Manipulation.P_L6DO_SDaR_1536();
parameter.File_Name = ...;
parameter.File_Description = ...;
parameter.File_ServerLocation = ...;
parameter.File_MIMEType = ...;
parameter.File_Extension = ...;
parameter.File_Size_Bytes = ...;
parameter.Structure_Header_RefID = ...;
parameter.Structure_RefID = ...;

*/
