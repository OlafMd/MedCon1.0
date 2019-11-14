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
using CL1_HEC;
using CL3_Document.Atomic.Manipulation;

namespace CL5_OphthalDocuments.Complex.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Document_for_Patient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Document_for_Patient
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5OD_SDfP_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
            var item = new ORM_HEC_Patient_Document();
            item.Load(Connection, Transaction, Parameter.HEC_Patient_DocumentID);
            if (Parameter.IsDeleted == true)
            {
                #region Delete DOC_Document

                P_L3DO_SD_1409 param1 = new P_L3DO_SD_1409();
                param1.DOC_DocumentID = item.Document_RefID;
                param1.IsDeleted = true;
                cls_Save_DOC_Document.Invoke(Connection, Transaction, param1, securityTicket);

                #endregion

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.HEC_Patient_DocumentID);
            }

            //Creation specific parameters (Tenant, Account ... )
            if (Parameter.HEC_Patient_DocumentID == Guid.Empty)
            {
                #region Delete predefined doc if exists

                if (Parameter.IsDocument_PatientConsent)
                {
                    var query = new ORM_HEC_Patient_Document.Query();
                    query.Patient_RefID = Parameter.Patient_RefID;
                    query.IsDeleted = false;
                    query.IsDocument_PatientConsent = true;

                    var previousdoc = ORM_HEC_Patient_Document.Query.Search(Connection, Transaction, query);

                    foreach (var prev in previousdoc)
                    {
                        prev.IsDeleted = true;
                        prev.Save(Connection, Transaction);

                        #region Delete DOC_Document

                        P_L3DO_SD_1409 delDocParam = new P_L3DO_SD_1409();
                        delDocParam.DOC_DocumentID = item.Document_RefID;
                        delDocParam.IsDeleted = true;
                        cls_Save_DOC_Document.Invoke(Connection, Transaction, delDocParam, securityTicket);

                        #endregion

                    }
                }

                #endregion

                item.HEC_Patient_DocumentID = Guid.NewGuid();
                item.Tenant_RefID = securityTicket.TenantID;

                #region cls_Save_DOC_Document

                P_L3DO_SD_1409 param1 = new P_L3DO_SD_1409();
                param1.Alias = Parameter.File_Name;
                param1.PrimaryType = Parameter.File_Extension;
                Guid documentID = cls_Save_DOC_Document.Invoke(Connection, Transaction, param1, securityTicket).Result;

                #endregion

                #region cls_Save_DOC_DocumentRevision

                P_L3DO_SDR_1401 param3 = new P_L3DO_SDR_1401();
                param3.Document_RefID = documentID;
                param3.Revision = 1;
                param3.IsLocked = false;
                param3.IsLastRevision = true;
                param3.UploadedByAccount = securityTicket.AccountID;
                param3.File_Name = Parameter.File_Name;
                param3.File_Description = "";
                param3.File_SourceLocation = "";
                param3.File_ServerLocation = Parameter.File_ServerLocation;
                param3.File_MIMEType = Parameter.File_MIMEType;
                param3.File_Extension = Parameter.File_Extension;
                param3.File_Size_Bytes = Parameter.File_Size_Bytes;

                cls_Save_DOC_DocumentRevision.Invoke(Connection, Transaction, param3, securityTicket);

                #endregion

                item.Patient_RefID = Parameter.Patient_RefID;
                item.Document_RefID = documentID;
                item.IsDocument_Standard = Parameter.IsDocument_Standard;
                item.IsDocument_PatientConsent = Parameter.IsDocument_PatientConsent;
                item.IsDocument_PatientParticipationPolicy = Parameter.IsDocument_PatientParticipationPolicy;

                item.Save(Connection, Transaction);

            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5OD_SDfP_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5OD_SDfP_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OD_SDfP_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OD_SDfP_1534 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_Document_for_Patient",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5OD_SDfP_1534 for attribute P_L5OD_SDfP_1534
		[DataContract]
		public class P_L5OD_SDfP_1534 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_DocumentID { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public Boolean IsDocument_Standard { get; set; } 
			[DataMember]
			public Boolean IsDocument_PatientConsent { get; set; } 
			[DataMember]
			public Boolean IsDocument_PatientParticipationPolicy { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public String File_MIMEType { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public long File_Size_Bytes { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Document_for_Patient(,P_L5OD_SDfP_1534 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Document_for_Patient.Invoke(connectionString,P_L5OD_SDfP_1534 Parameter,securityTicket);
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
var parameter = new CL5_OphthalDocuments.Complex.Manipulation.P_L5OD_SDfP_1534();
parameter.HEC_Patient_DocumentID = ...;
parameter.Patient_RefID = ...;
parameter.IsDocument_Standard = ...;
parameter.IsDocument_PatientConsent = ...;
parameter.IsDocument_PatientParticipationPolicy = ...;
parameter.IsDeleted = ...;
parameter.File_Name = ...;
parameter.File_ServerLocation = ...;
parameter.File_MIMEType = ...;
parameter.File_Extension = ...;
parameter.File_Size_Bytes = ...;

*/
