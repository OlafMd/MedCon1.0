/* 
 * Generated on 7/24/2013 11:59:12 AM
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
using CL1_USR;
using CL1_HEC;
using CL1_DOC;

namespace CL5_MS_Prescription.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_MS_Transaction.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_MS_Transaction
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5PS_ST_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
            var returnValue = new FR_Guid();

            #region Get Account By AccountID

            var account = new ORM_USR_Account();
            account.Load(Connection, Transaction, securityTicket.AccountID);

            #endregion

            #region PrescriptionTransaction_InternalNubmer

            var qtransaction = new ORM_HEC_Patient_Prescription_Transaction.Query();
            qtransaction.Tenant_RefID = securityTicket.TenantID;

            var count = ORM_HEC_Patient_Prescription_Transaction.Query.Search(Connection, Transaction, qtransaction).Count();
            var internalnumber = "0000000" + count;
            internalnumber = internalnumber.Substring(internalnumber.Length - 7, 7);

            #endregion

            var transaction = new ORM_HEC_Patient_Prescription_Transaction();
            transaction.HEC_Patient_Prescription_TransactionID = Guid.NewGuid();
            transaction.PrescriptionTransaction_InternalNubmer = internalnumber;
            transaction.PrescriptionTransaction_IsComplete = false;
            transaction.PrescriptionTransaction_RequestedDateOfDeliveryFrom = Parameter.PrescriptionTransaction_RequestedDateOfDeliveryFrom;
            transaction.PrescriptionTransaction_RequestedDateOfDeliveryTo = Parameter.PrescriptionTransaction_RequestedDateOfDeliveryTo;
            transaction.PrescriptionTransaction_CreatedByBusinessParticpant_RefID = account.BusinessParticipant_RefID;
            transaction.PrescriptionTransaction_Comment = Parameter.PrescriptionTransaction_Comment;
            transaction.PrescriptionTransaction_Patient_RefID = Parameter.PrescriptionTransaction_Patient_RefID;
            transaction.PerscriptionTransaction_DeliveryAddress_RefID = Parameter.PrescriptionTransaction_Address_RefID;
            transaction.PrescriptionTransaction_UseParticipationPolicyAddress = false;
            transaction.PrescriptionTransaction_UsePatientAddress = true;
            transaction.PrescriptionTransaction_UseReceiptAddress = false;
            transaction.Creation_Timestamp = DateTime.Now;
            transaction.Tenant_RefID = securityTicket.TenantID;
            transaction.Save(Connection, Transaction);

            if(Parameter.Prescriptions!=null)
            {
                var header = new ORM_HEC_Patient_Prescription_Header();
                header.HEC_Patient_Prescription_HeaderID = Guid.NewGuid();
                header.Patient_RefID = Parameter.PrescriptionTransaction_Patient_RefID;
                header.PrescribedBy_Doctor_RefID = Guid.Empty;
                header.Prescription_Date = new DateTime();
                header.Prescription_Comment = "";
                header.Prescription_InternalNumber = transaction.PrescriptionTransaction_InternalNubmer + "/" + 1;
                header.Perscription_UploadedByBusinessParticipant_RefID = account.BusinessParticipant_RefID;
                header.Creation_Timestamp = DateTime.Now;
                header.Tenant_RefID = securityTicket.TenantID;
                header.Save(Connection, Transaction);

                var transaction2header = new ORM_HEC_Patient_Prescription_2_PrescriptionTransaction();
                transaction2header.AssignmentID = Guid.NewGuid();
                transaction2header.HEC_Patient_Prescription_Header_RefID = header.HEC_Patient_Prescription_HeaderID;
                transaction2header.HEC_Patient_Prescription_Transaction_RefID = transaction.HEC_Patient_Prescription_TransactionID;
                transaction2header.Creation_Timestamp = DateTime.Now;
                transaction2header.Tenant_RefID = securityTicket.TenantID;
                transaction2header.Save(Connection, Transaction);

                var prescriptionDocument = new ORM_HEC_Patient_Prescription_Document();
                prescriptionDocument.HEC_Patient_Prescription_DocumentID = Guid.NewGuid();
                prescriptionDocument.PrescriptionHeader_RefID = header.HEC_Patient_Prescription_HeaderID;
                prescriptionDocument.Comment = "";
                prescriptionDocument.Document_RefID = Guid.NewGuid();
                prescriptionDocument.Creation_Timestamp = DateTime.Now;
                prescriptionDocument.Tenant_RefID = securityTicket.TenantID;
                prescriptionDocument.Save(Connection, Transaction);

                var document = new ORM_DOC_Document();
                document.DOC_DocumentID = prescriptionDocument.Document_RefID;
                document.Alias = Parameter.Prescriptions.File_Name;
                document.PrimaryType = Parameter.Prescriptions.File_Extension;
                document.Creation_Timestamp = DateTime.Now;
                document.Tenant_RefID = securityTicket.TenantID;
                document.Save(Connection, Transaction);

                var revision = new ORM_DOC_DocumentRevision();
                revision.DOC_DocumentRevisionID = Guid.NewGuid();
                revision.Document_RefID = prescriptionDocument.Document_RefID;
                revision.Revision = 1;
                revision.IsLastRevision = true;
                revision.UploadedByAccount = securityTicket.AccountID;
                revision.File_Name = Parameter.Prescriptions.File_Name;
                revision.File_ServerLocation = Parameter.Prescriptions.File_ServerLocation;
                revision.File_Extension = Parameter.Prescriptions.File_Extension;
                revision.File_Size_Bytes = Parameter.Prescriptions.File_Size_Bytes;
                revision.Creation_Timestamp = DateTime.Now;
                revision.Tenant_RefID = securityTicket.TenantID;
                revision.Save(Connection, Transaction);

            }
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5PS_ST_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5PS_ST_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PS_ST_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PS_ST_1157 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Save_MS_Transaction",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PS_ST_1157 for attribute P_L5PS_ST_1157
		[DataContract]
		public class P_L5PS_ST_1157 
		{
			[DataMember]
			public P_L5PS_ST_1157a Prescriptions { get; set; }

			//Standard type parameters
			[DataMember]
			public DateTime PrescriptionTransaction_RequestedDateOfDeliveryFrom { get; set; } 
			[DataMember]
			public DateTime PrescriptionTransaction_RequestedDateOfDeliveryTo { get; set; } 
			[DataMember]
			public String PrescriptionTransaction_Comment { get; set; } 
			[DataMember]
			public Guid PrescriptionTransaction_Patient_RefID { get; set; } 
			[DataMember]
			public Guid PrescriptionTransaction_Address_RefID { get; set; } 

		}
		#endregion
		#region SClass P_L5PS_ST_1157a for attribute Prescriptions
		[DataContract]
		public class P_L5PS_ST_1157a 
		{
			//Standard type parameters
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public int File_Size_Bytes { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_MS_Transaction(,P_L5PS_ST_1157 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_MS_Transaction.Invoke(connectionString,P_L5PS_ST_1157 Parameter,securityTicket);
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
var parameter = new CL5_MS_Prescription.Complex.Manipulation.P_L5PS_ST_1157();
parameter.Prescriptions = ...;

parameter.PrescriptionTransaction_RequestedDateOfDeliveryFrom = ...;
parameter.PrescriptionTransaction_RequestedDateOfDeliveryTo = ...;
parameter.PrescriptionTransaction_Comment = ...;
parameter.PrescriptionTransaction_Patient_RefID = ...;
parameter.PrescriptionTransaction_Address_RefID = ...;

*/
