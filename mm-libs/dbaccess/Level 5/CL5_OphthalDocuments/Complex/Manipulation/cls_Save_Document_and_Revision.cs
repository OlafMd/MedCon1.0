/* 
 * Generated on 8/30/2013 10:57:03 AM
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

namespace CL5_OphthalDocuments.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
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
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_SDaR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            #region cls_Save_DOC_Document

            P_L3DO_SD_1409 param1 = new P_L3DO_SD_1409();
            param1.Alias = Parameter.File_Name;
            Guid documentID = cls_Save_DOC_Document.Invoke(Connection, Transaction, param1, securityTicket).Result;

            #endregion

            #region cls_Save_DOC_Document_2_Structure

            P_L3DO_SD2S_1407 param2 = new P_L3DO_SD2S_1407();
            param2.Document_RefID = documentID;
            param2.Structure_RefID = Parameter.Structure_RefID;
            param2.StructureHeader_RefID = Parameter.Structure_Header_RefID;

            Guid AssignmentID = cls_Save_DOC_Document_2_Structure.Invoke(Connection, Transaction, param2, securityTicket).Result;

            #endregion

            #region cls_Save_DOC_DocumentRevision

            P_L3DO_SDR_1401 param3 = new P_L3DO_SDR_1401();
            param3.Document_RefID = documentID;
            param3.Revision = 1;
            param3.IsLocked = false;
            param3.IsLastRevision = true;
            param3.UploadedByAccount = securityTicket.AccountID;
            param3.File_Name = Parameter.File_Name;
            param3.File_Description = Parameter.File_Description;
            param3.File_SourceLocation = "";
            param3.File_ServerLocation = Parameter.File_ServerLocation;
            param3.File_MIMEType = Parameter.File_MIMEType;
            param3.File_Extension = Parameter.File_Extension;
            param3.File_Size_Bytes = Parameter.File_Size_Bytes;

            cls_Save_DOC_DocumentRevision.Invoke(Connection, Transaction, param3, securityTicket);

            #endregion
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OD_SDaR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OD_SDaR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_SDaR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_SDaR_1351 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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
		#region SClass P_L5OD_SDaR_1351 for attribute P_L5OD_SDaR_1351
		[DataContract]
		public class P_L5OD_SDaR_1351 
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
FR_Guid cls_Save_Document_and_Revision(,P_L5OD_SDaR_1351 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Document_and_Revision.Invoke(connectionString,P_L5OD_SDaR_1351 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDocuments.Complex.Manipulation.P_L5OD_SDaR_1351();
parameter.File_Name = ...;
parameter.File_Description = ...;
parameter.File_ServerLocation = ...;
parameter.File_MIMEType = ...;
parameter.File_Extension = ...;
parameter.File_Size_Bytes = ...;
parameter.Structure_Header_RefID = ...;
parameter.Structure_RefID = ...;

*/
