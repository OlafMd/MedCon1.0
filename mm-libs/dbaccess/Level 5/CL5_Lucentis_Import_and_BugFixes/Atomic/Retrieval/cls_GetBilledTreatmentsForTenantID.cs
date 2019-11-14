/* 
 * Generated on 2/2/2015 10:18:43 PM
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

namespace CL5_Lucentis_Import_and_BugFixes.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_GetBilledTreatmentsForTenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_GetBilledTreatmentsForTenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GBTFTID_1748_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GBTFTID_1748_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Import_and_BugFixes.Atomic.Retrieval.SQL.cls_GetBilledTreatmentsForTenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5TR_GBTFTID_1748> results = new List<L5TR_GBTFTID_1748>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TCode","PositionNumber","BillID","TreatmentDate","HealthInsurance_Number","InsuranceStateCode","PatientFirstName","PatientLastName","BSNR","LANR","GPOS","PositionValue_IncludingTax","BirthDate","PatientID","IsTreatmentBilled","DoctorFirstName","DoctorLastName","DoctorsTitle","HEC_Patient_TreatmentID","TransmittedOnDate","AOKComment","External_PositionType","BIL_BillPosition_TransmitionStatusID","BIL_BillPositionID","PrimaryComment","IsActive","IsDeleted" });
				while(reader.Read())
				{
					L5TR_GBTFTID_1748 resultItem = new L5TR_GBTFTID_1748();
					//0:Parameter TCode of type String
					resultItem.TCode = reader.GetString(0);
					//1:Parameter PositionNumber of type String
					resultItem.PositionNumber = reader.GetString(1);
					//2:Parameter BillID of type String
					resultItem.BillID = reader.GetString(2);
					//3:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(3);
					//4:Parameter HealthInsurance_Number of type String
					resultItem.HealthInsurance_Number = reader.GetString(4);
					//5:Parameter InsuranceStateCode of type String
					resultItem.InsuranceStateCode = reader.GetString(5);
					//6:Parameter PatientFirstName of type String
					resultItem.PatientFirstName = reader.GetString(6);
					//7:Parameter PatientLastName of type String
					resultItem.PatientLastName = reader.GetString(7);
					//8:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(8);
					//9:Parameter LANR of type String
					resultItem.LANR = reader.GetString(9);
					//10:Parameter GPOS of type String
					resultItem.GPOS = reader.GetString(10);
					//11:Parameter PositionValue_IncludingTax of type String
					resultItem.PositionValue_IncludingTax = reader.GetString(11);
					//12:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(12);
					//13:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(13);
					//14:Parameter IsTreatmentBilled of type bool
					resultItem.IsTreatmentBilled = reader.GetBoolean(14);
					//15:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(15);
					//16:Parameter DoctorLastName of type String
					resultItem.DoctorLastName = reader.GetString(16);
					//17:Parameter DoctorsTitle of type String
					resultItem.DoctorsTitle = reader.GetString(17);
					//18:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(18);
					//19:Parameter TransmittedOnDate of type DateTime
					resultItem.TransmittedOnDate = reader.GetDate(19);
					//20:Parameter AOKComment of type String
					resultItem.AOKComment = reader.GetString(20);
					//21:Parameter External_PositionType of type String
					resultItem.External_PositionType = reader.GetString(21);
					//22:Parameter BIL_BillPosition_TransmitionStatusID of type Guid
					resultItem.BIL_BillPosition_TransmitionStatusID = reader.GetGuid(22);
					//23:Parameter BIL_BillPositionID of type Guid
					resultItem.BIL_BillPositionID = reader.GetGuid(23);
					//24:Parameter PrimaryComment of type String
					resultItem.PrimaryComment = reader.GetString(24);
					//25:Parameter IsActive of type bool
					resultItem.IsActive = reader.GetBoolean(25);
					//26:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(26);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_GetBilledTreatmentsForTenantID",ex);
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
		public static FR_L5TR_GBTFTID_1748_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GBTFTID_1748_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GBTFTID_1748_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GBTFTID_1748_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GBTFTID_1748_Array functionReturn = new FR_L5TR_GBTFTID_1748_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_GetBilledTreatmentsForTenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GBTFTID_1748_Array : FR_Base
	{
		public L5TR_GBTFTID_1748[] Result	{ get; set; } 
		public FR_L5TR_GBTFTID_1748_Array() : base() {}

		public FR_L5TR_GBTFTID_1748_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5TR_GBTFTID_1748 for attribute L5TR_GBTFTID_1748
		[DataContract]
		public class L5TR_GBTFTID_1748 
		{
			//Standard type parameters
			[DataMember]
			public String TCode { get; set; } 
			[DataMember]
			public String PositionNumber { get; set; } 
			[DataMember]
			public String BillID { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public String HealthInsurance_Number { get; set; } 
			[DataMember]
			public String InsuranceStateCode { get; set; } 
			[DataMember]
			public String PatientFirstName { get; set; } 
			[DataMember]
			public String PatientLastName { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String LANR { get; set; } 
			[DataMember]
			public String GPOS { get; set; } 
			[DataMember]
			public String PositionValue_IncludingTax { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public bool IsTreatmentBilled { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 
			[DataMember]
			public String DoctorsTitle { get; set; } 
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public DateTime TransmittedOnDate { get; set; } 
			[DataMember]
			public String AOKComment { get; set; } 
			[DataMember]
			public String External_PositionType { get; set; } 
			[DataMember]
			public Guid BIL_BillPosition_TransmitionStatusID { get; set; } 
			[DataMember]
			public Guid BIL_BillPositionID { get; set; } 
			[DataMember]
			public String PrimaryComment { get; set; } 
			[DataMember]
			public bool IsActive { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GBTFTID_1748_Array cls_GetBilledTreatmentsForTenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GBTFTID_1748_Array invocationResult = cls_GetBilledTreatmentsForTenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

