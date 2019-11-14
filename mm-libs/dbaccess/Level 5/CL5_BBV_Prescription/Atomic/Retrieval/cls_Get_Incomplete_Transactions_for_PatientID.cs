/* 
 * Generated on 10/16/2013 3:20:55 PM
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

namespace CL5_BBV_Prescription.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Incomplete_Transactions_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Incomplete_Transactions_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5_GITfP_1444_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5_GITfP_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5_GITfP_1444_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_BBV_Prescription.Atomic.Retrieval.SQL.cls_Get_Incomplete_Transactions_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HEC_PatientID", Parameter.HEC_PatientID);


			List<L5_GITfP_1444> results = new List<L5_GITfP_1444>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PrescriptionTransaction_InternalNubmer","Creation_Timestamp","IsPatientParticipationPolicyValidated","HEC_Patient_Prescription_TransactionID","PrescriptionTransaction_IsComplete","HEC_PatientID","CMN_PER_PersonInfoID","CMN_BPT_BusinessParticipantID","LastName","FirstName","DisplayName","CompanyName_Line1" });
				while(reader.Read())
				{
					L5_GITfP_1444 resultItem = new L5_GITfP_1444();
					//0:Parameter PrescriptionTransaction_InternalNubmer of type String
					resultItem.PrescriptionTransaction_InternalNubmer = reader.GetString(0);
					//1:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(1);
					//2:Parameter IsPatientParticipationPolicyValidated of type bool
					resultItem.IsPatientParticipationPolicyValidated = reader.GetBoolean(2);
					//3:Parameter HEC_Patient_Prescription_TransactionID of type Guid
					resultItem.HEC_Patient_Prescription_TransactionID = reader.GetGuid(3);
					//4:Parameter PrescriptionTransaction_IsComplete of type String
					resultItem.PrescriptionTransaction_IsComplete = reader.GetString(4);
					//5:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(5);
					//6:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(6);
					//7:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(7);
					//8:Parameter LastName of type String
					resultItem.LastName = reader.GetString(8);
					//9:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(9);
					//10:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(10);
					//11:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5_GITfP_1444_Array Invoke(string ConnectionString,P_L5_GITfP_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5_GITfP_1444_Array Invoke(DbConnection Connection,P_L5_GITfP_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5_GITfP_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5_GITfP_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5_GITfP_1444_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5_GITfP_1444 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5_GITfP_1444_Array functionReturn = new FR_L5_GITfP_1444_Array();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5_GITfP_1444_Array : FR_Base
	{
		public L5_GITfP_1444[] Result	{ get; set; } 
		public FR_L5_GITfP_1444_Array() : base() {}

		public FR_L5_GITfP_1444_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5_GITfP_1444 for attribute P_L5_GITfP_1444
		[DataContract]
		public class P_L5_GITfP_1444 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 

		}
		#endregion
		#region SClass L5_GITfP_1444 for attribute L5_GITfP_1444
		[DataContract]
		public class L5_GITfP_1444 
		{
			//Standard type parameters
			[DataMember]
			public String PrescriptionTransaction_InternalNubmer { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsPatientParticipationPolicyValidated { get; set; } 
			[DataMember]
			public Guid HEC_Patient_Prescription_TransactionID { get; set; } 
			[DataMember]
			public String PrescriptionTransaction_IsComplete { get; set; } 
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 

		}
		#endregion

	#endregion
}
