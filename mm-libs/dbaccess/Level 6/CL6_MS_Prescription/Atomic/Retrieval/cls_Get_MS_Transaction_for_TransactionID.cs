/* 
 * Generated on 7/24/2013 5:38:58 PM
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

namespace CL6_MS_Prescription.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MS_Transaction_for_TransactionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MS_Transaction_for_TransactionID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PS_GTfT_1544 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PS_GTfT_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PS_GTfT_1544();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MS_Prescription.Atomic.Retrieval.SQL.cls_Get_MS_Transaction_for_TransactionID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TransactionID", Parameter.TransactionID);



			List<L6PS_GTfT_1544> results = new List<L6PS_GTfT_1544>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_Prescription_TransactionID","PrescriptionTransaction_InternalNubmer","PrescriptionTransaction_IsComplete","PrescriptionTransaction_RequestedDateOfDeliveryFrom","PrescriptionTransaction_RequestedDateOfDeliveryTo","PrescriptionTransaction_CreatedByBusinessParticpant_RefID","PrescriptionTransaction_Comment","PrescriptionTransaction_Patient_RefID","PerscriptionTransaction_DeliveryAddress_RefID","PrescriptionTransaction_UsePatientAddress","PrescriptionTransaction_UseReceiptAddress","PrescriptionTransaction_UseParticipationPolicyAddress","Creation_Timestamp","Street_Name","Street_Number","City_PostalCode","Province_Name","City_Name","Patient_FristName","Patient_LastName","Patient_InsuranceNumber","Salutation_General","HEC_Patient_Prescription_HeaderID","DOC_DocumentRevisionID","File_ServerLocation" });
				while(reader.Read())
				{
					L6PS_GTfT_1544 resultItem = new L6PS_GTfT_1544();
					//0:Parameter HEC_Patient_Prescription_TransactionID of type Guid
					resultItem.HEC_Patient_Prescription_TransactionID = reader.GetGuid(0);
					//1:Parameter PrescriptionTransaction_InternalNubmer of type String
					resultItem.PrescriptionTransaction_InternalNubmer = reader.GetString(1);
					//2:Parameter PrescriptionTransaction_IsComplete of type Boolean
					resultItem.PrescriptionTransaction_IsComplete = reader.GetBoolean(2);
					//3:Parameter PrescriptionTransaction_RequestedDateOfDeliveryFrom of type DateTime
					resultItem.PrescriptionTransaction_RequestedDateOfDeliveryFrom = reader.GetDate(3);
					//4:Parameter PrescriptionTransaction_RequestedDateOfDeliveryTo of type DateTime
					resultItem.PrescriptionTransaction_RequestedDateOfDeliveryTo = reader.GetDate(4);
					//5:Parameter PrescriptionTransaction_CreatedByBusinessParticpant_RefID of type Guid
					resultItem.PrescriptionTransaction_CreatedByBusinessParticpant_RefID = reader.GetGuid(5);
					//6:Parameter PrescriptionTransaction_Comment of type String
					resultItem.PrescriptionTransaction_Comment = reader.GetString(6);
					//7:Parameter PrescriptionTransaction_Patient_RefID of type Guid
					resultItem.PrescriptionTransaction_Patient_RefID = reader.GetGuid(7);
					//8:Parameter PerscriptionTransaction_DeliveryAddress_RefID of type Guid
					resultItem.PerscriptionTransaction_DeliveryAddress_RefID = reader.GetGuid(8);
					//9:Parameter PrescriptionTransaction_UsePatientAddress of type Boolean
					resultItem.PrescriptionTransaction_UsePatientAddress = reader.GetBoolean(9);
					//10:Parameter PrescriptionTransaction_UseReceiptAddress of type Boolean
					resultItem.PrescriptionTransaction_UseReceiptAddress = reader.GetBoolean(10);
					//11:Parameter PrescriptionTransaction_UseParticipationPolicyAddress of type Boolean
					resultItem.PrescriptionTransaction_UseParticipationPolicyAddress = reader.GetBoolean(11);
					//12:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(12);
					//13:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(13);
					//14:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(14);
					//15:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(15);
					//16:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(16);
					//17:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(17);
					//18:Parameter Patient_FristName of type String
					resultItem.Patient_FristName = reader.GetString(18);
					//19:Parameter Patient_LastName of type String
					resultItem.Patient_LastName = reader.GetString(19);
					//20:Parameter Patient_InsuranceNumber of type String
					resultItem.Patient_InsuranceNumber = reader.GetString(20);
					//21:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(21);
					//22:Parameter HEC_Patient_Prescription_HeaderID of type Guid
					resultItem.HEC_Patient_Prescription_HeaderID = reader.GetGuid(22);
					//23:Parameter DOC_DocumentRevisionID of type Guid
					resultItem.DOC_DocumentRevisionID = reader.GetGuid(23);
					//24:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(24);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_MS_Transaction_for_TransactionID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PS_GTfT_1544 Invoke(string ConnectionString,P_L6PS_GTfT_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PS_GTfT_1544 Invoke(DbConnection Connection,P_L6PS_GTfT_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PS_GTfT_1544 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PS_GTfT_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PS_GTfT_1544 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PS_GTfT_1544 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PS_GTfT_1544 functionReturn = new FR_L6PS_GTfT_1544();
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

				throw new Exception("Exception occured in method cls_Get_MS_Transaction_for_TransactionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PS_GTfT_1544 : FR_Base
	{
		public L6PS_GTfT_1544 Result	{ get; set; }

		public FR_L6PS_GTfT_1544() : base() {}

		public FR_L6PS_GTfT_1544(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PS_GTfT_1544 for attribute P_L6PS_GTfT_1544
		[DataContract]
		public class P_L6PS_GTfT_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid TransactionID { get; set; } 

		}
		#endregion
		#region SClass L6PS_GTfT_1544 for attribute L6PS_GTfT_1544
		[DataContract]
		public class L6PS_GTfT_1544 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Prescription_TransactionID { get; set; } 
			[DataMember]
			public String PrescriptionTransaction_InternalNubmer { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_IsComplete { get; set; } 
			[DataMember]
			public DateTime PrescriptionTransaction_RequestedDateOfDeliveryFrom { get; set; } 
			[DataMember]
			public DateTime PrescriptionTransaction_RequestedDateOfDeliveryTo { get; set; } 
			[DataMember]
			public Guid PrescriptionTransaction_CreatedByBusinessParticpant_RefID { get; set; } 
			[DataMember]
			public String PrescriptionTransaction_Comment { get; set; } 
			[DataMember]
			public Guid PrescriptionTransaction_Patient_RefID { get; set; } 
			[DataMember]
			public Guid PerscriptionTransaction_DeliveryAddress_RefID { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_UsePatientAddress { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_UseReceiptAddress { get; set; } 
			[DataMember]
			public Boolean PrescriptionTransaction_UseParticipationPolicyAddress { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Patient_FristName { get; set; } 
			[DataMember]
			public String Patient_LastName { get; set; } 
			[DataMember]
			public String Patient_InsuranceNumber { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public Guid HEC_Patient_Prescription_HeaderID { get; set; } 
			[DataMember]
			public Guid DOC_DocumentRevisionID { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PS_GTfT_1544 cls_Get_MS_Transaction_for_TransactionID(,P_L6PS_GTfT_1544 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PS_GTfT_1544 invocationResult = cls_Get_MS_Transaction_for_TransactionID.Invoke(connectionString,P_L6PS_GTfT_1544 Parameter,securityTicket);
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
var parameter = new CL6_MS_Prescription.Atomic.Retrieval.P_L6PS_GTfT_1544();
parameter.TransactionID = ...;

*/
