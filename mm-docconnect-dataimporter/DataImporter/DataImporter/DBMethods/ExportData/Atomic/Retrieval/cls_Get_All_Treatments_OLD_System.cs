/* 
 * Generated on 1/20/2017 2:34:28 PM
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

namespace DataImporter.DBMethods.ExportData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Treatments_OLD_System.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Treatments_OLD_System
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ED_GATOS_1212_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ED_GATOS_1212_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.ExportData.Atomic.Retrieval.SQL.cls_Get_All_Treatments_OLD_System.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<ED_GATOS_1212_raw> results = new List<ED_GATOS_1212_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_TreatmentID","isTreatmentScheduled","isTreatmentBilled","treatmentScheduledDate","treatmentPerformedDate","isTreatmentPerformed","PatientFirstName","PatientLastName","HealthInsurance_Number","OPperformedDoctorLANR","OPperformedDoctorFirstName","OPperformedDoctorLastName","OPscheduledDoctorLANR","OPScheduledDoctorFirstName","OPScheduledDoctorLastName","BSNR","PracticeName","IsTreatmentOfLeftEye","IsTreatmentOfRightEye","ICD10_Code","diagnnoseID","DiagnosedOnDate","HEC_Patient_Treatment_RequiredProductID","ArticleName","PZN" });
				while(reader.Read())
				{
					ED_GATOS_1212_raw resultItem = new ED_GATOS_1212_raw();
					//0:Parameter HEC_Patient_TreatmentID of type Guid
					resultItem.HEC_Patient_TreatmentID = reader.GetGuid(0);
					//1:Parameter isTreatmentScheduled of type bool
					resultItem.isTreatmentScheduled = reader.GetBoolean(1);
					//2:Parameter isTreatmentBilled of type bool
					resultItem.isTreatmentBilled = reader.GetBoolean(2);
					//3:Parameter treatmentScheduledDate of type DateTime
					resultItem.treatmentScheduledDate = reader.GetDate(3);
					//4:Parameter treatmentPerformedDate of type DateTime
					resultItem.treatmentPerformedDate = reader.GetDate(4);
					//5:Parameter isTreatmentPerformed of type bool
					resultItem.isTreatmentPerformed = reader.GetBoolean(5);
					//6:Parameter PatientFirstName of type String
					resultItem.PatientFirstName = reader.GetString(6);
					//7:Parameter PatientLastName of type String
					resultItem.PatientLastName = reader.GetString(7);
					//8:Parameter HealthInsurance_Number of type String
					resultItem.HealthInsurance_Number = reader.GetString(8);
					//9:Parameter OPperformedDoctorLANR of type String
					resultItem.OPperformedDoctorLANR = reader.GetString(9);
					//10:Parameter OPperformedDoctorFirstName of type String
					resultItem.OPperformedDoctorFirstName = reader.GetString(10);
					//11:Parameter OPperformedDoctorLastName of type String
					resultItem.OPperformedDoctorLastName = reader.GetString(11);
					//12:Parameter OPscheduledDoctorLANR of type String
					resultItem.OPscheduledDoctorLANR = reader.GetString(12);
					//13:Parameter OPScheduledDoctorFirstName of type String
					resultItem.OPScheduledDoctorFirstName = reader.GetString(13);
					//14:Parameter OPScheduledDoctorLastName of type String
					resultItem.OPScheduledDoctorLastName = reader.GetString(14);
					//15:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(15);
					//16:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(16);
					//17:Parameter IsTreatmentOfLeftEye of type bool
					resultItem.IsTreatmentOfLeftEye = reader.GetBoolean(17);
					//18:Parameter IsTreatmentOfRightEye of type bool
					resultItem.IsTreatmentOfRightEye = reader.GetBoolean(18);
					//19:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(19);
					//20:Parameter diagnnoseID of type Guid
					resultItem.diagnnoseID = reader.GetGuid(20);
					//21:Parameter DiagnosedOnDate of type DateTime
					resultItem.DiagnosedOnDate = reader.GetDate(21);
					//22:Parameter HEC_Patient_Treatment_RequiredProductID of type Guid
					resultItem.HEC_Patient_Treatment_RequiredProductID = reader.GetGuid(22);
					//23:Parameter ArticleName of type String
					resultItem.ArticleName = reader.GetString(23);
					//24:Parameter PZN of type String
					resultItem.PZN = reader.GetString(24);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_All_Treatments_OLD_System",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = ED_GATOS_1212_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_ED_GATOS_1212_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ED_GATOS_1212_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ED_GATOS_1212_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ED_GATOS_1212_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ED_GATOS_1212_Array functionReturn = new FR_ED_GATOS_1212_Array();
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

				throw new Exception("Exception occured in method cls_Get_All_Treatments_OLD_System",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class ED_GATOS_1212_raw 
	{
		public Guid HEC_Patient_TreatmentID; 
		public bool isTreatmentScheduled; 
		public bool isTreatmentBilled; 
		public DateTime treatmentScheduledDate; 
		public DateTime treatmentPerformedDate; 
		public bool isTreatmentPerformed; 
		public String PatientFirstName; 
		public String PatientLastName; 
		public String HealthInsurance_Number; 
		public String OPperformedDoctorLANR; 
		public String OPperformedDoctorFirstName; 
		public String OPperformedDoctorLastName; 
		public String OPscheduledDoctorLANR; 
		public String OPScheduledDoctorFirstName; 
		public String OPScheduledDoctorLastName; 
		public String BSNR; 
		public String PracticeName; 
		public bool IsTreatmentOfLeftEye; 
		public bool IsTreatmentOfRightEye; 
		public String ICD10_Code; 
		public Guid diagnnoseID; 
		public DateTime DiagnosedOnDate; 
		public Guid HEC_Patient_Treatment_RequiredProductID; 
		public String ArticleName; 
		public String PZN; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static ED_GATOS_1212[] Convert(List<ED_GATOS_1212_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_ED_GATOS_1212 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_TreatmentID)).ToArray()
	group el_ED_GATOS_1212 by new 
	{ 
		el_ED_GATOS_1212.HEC_Patient_TreatmentID,

	}
	into gfunct_ED_GATOS_1212
	select new ED_GATOS_1212
	{     
		HEC_Patient_TreatmentID = gfunct_ED_GATOS_1212.Key.HEC_Patient_TreatmentID ,
		isTreatmentScheduled = gfunct_ED_GATOS_1212.FirstOrDefault().isTreatmentScheduled ,
		isTreatmentBilled = gfunct_ED_GATOS_1212.FirstOrDefault().isTreatmentBilled ,
		treatmentScheduledDate = gfunct_ED_GATOS_1212.FirstOrDefault().treatmentScheduledDate ,
		treatmentPerformedDate = gfunct_ED_GATOS_1212.FirstOrDefault().treatmentPerformedDate ,
		isTreatmentPerformed = gfunct_ED_GATOS_1212.FirstOrDefault().isTreatmentPerformed ,
		PatientFirstName = gfunct_ED_GATOS_1212.FirstOrDefault().PatientFirstName ,
		PatientLastName = gfunct_ED_GATOS_1212.FirstOrDefault().PatientLastName ,
		HealthInsurance_Number = gfunct_ED_GATOS_1212.FirstOrDefault().HealthInsurance_Number ,
		OPperformedDoctorLANR = gfunct_ED_GATOS_1212.FirstOrDefault().OPperformedDoctorLANR ,
		OPperformedDoctorFirstName = gfunct_ED_GATOS_1212.FirstOrDefault().OPperformedDoctorFirstName ,
		OPperformedDoctorLastName = gfunct_ED_GATOS_1212.FirstOrDefault().OPperformedDoctorLastName ,
		OPscheduledDoctorLANR = gfunct_ED_GATOS_1212.FirstOrDefault().OPscheduledDoctorLANR ,
		OPScheduledDoctorFirstName = gfunct_ED_GATOS_1212.FirstOrDefault().OPScheduledDoctorFirstName ,
		OPScheduledDoctorLastName = gfunct_ED_GATOS_1212.FirstOrDefault().OPScheduledDoctorLastName ,
		BSNR = gfunct_ED_GATOS_1212.FirstOrDefault().BSNR ,
		PracticeName = gfunct_ED_GATOS_1212.FirstOrDefault().PracticeName ,
		IsTreatmentOfLeftEye = gfunct_ED_GATOS_1212.FirstOrDefault().IsTreatmentOfLeftEye ,
		IsTreatmentOfRightEye = gfunct_ED_GATOS_1212.FirstOrDefault().IsTreatmentOfRightEye ,

		Diagnoses = 
		(
			from el_Diagnoses in gfunct_ED_GATOS_1212.Where(element => !EqualsDefaultValue(element.diagnnoseID)).ToArray()
			group el_Diagnoses by new 
			{ 
				el_Diagnoses.diagnnoseID,

			}
			into gfunct_Diagnoses
			select new ED_GATOS_1212_Diagnoses
			{     
				ICD10_Code = gfunct_Diagnoses.FirstOrDefault().ICD10_Code ,
				diagnnoseID = gfunct_Diagnoses.Key.diagnnoseID ,
				DiagnosedOnDate = gfunct_Diagnoses.FirstOrDefault().DiagnosedOnDate ,

			}
		).ToArray(),
		Articles = 
		(
			from el_Articles in gfunct_ED_GATOS_1212.Where(element => !EqualsDefaultValue(element.HEC_Patient_Treatment_RequiredProductID)).ToArray()
			group el_Articles by new 
			{ 
				el_Articles.HEC_Patient_Treatment_RequiredProductID,

			}
			into gfunct_Articles
			select new ED_GATOS_1212_Articles
			{     
				HEC_Patient_Treatment_RequiredProductID = gfunct_Articles.Key.HEC_Patient_Treatment_RequiredProductID ,
				ArticleName = gfunct_Articles.FirstOrDefault().ArticleName ,
				PZN = gfunct_Articles.FirstOrDefault().PZN ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_ED_GATOS_1212_Array : FR_Base
	{
		public ED_GATOS_1212[] Result	{ get; set; } 
		public FR_ED_GATOS_1212_Array() : base() {}

		public FR_ED_GATOS_1212_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass ED_GATOS_1212 for attribute ED_GATOS_1212
		[DataContract]
		public class ED_GATOS_1212 
		{
			[DataMember]
			public ED_GATOS_1212_Diagnoses[] Diagnoses { get; set; }
			[DataMember]
			public ED_GATOS_1212_Articles[] Articles { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_TreatmentID { get; set; } 
			[DataMember]
			public bool isTreatmentScheduled { get; set; } 
			[DataMember]
			public bool isTreatmentBilled { get; set; } 
			[DataMember]
			public DateTime treatmentScheduledDate { get; set; } 
			[DataMember]
			public DateTime treatmentPerformedDate { get; set; } 
			[DataMember]
			public bool isTreatmentPerformed { get; set; } 
			[DataMember]
			public String PatientFirstName { get; set; } 
			[DataMember]
			public String PatientLastName { get; set; } 
			[DataMember]
			public String HealthInsurance_Number { get; set; } 
			[DataMember]
			public String OPperformedDoctorLANR { get; set; } 
			[DataMember]
			public String OPperformedDoctorFirstName { get; set; } 
			[DataMember]
			public String OPperformedDoctorLastName { get; set; } 
			[DataMember]
			public String OPscheduledDoctorLANR { get; set; } 
			[DataMember]
			public String OPScheduledDoctorFirstName { get; set; } 
			[DataMember]
			public String OPScheduledDoctorLastName { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public bool IsTreatmentOfLeftEye { get; set; } 
			[DataMember]
			public bool IsTreatmentOfRightEye { get; set; } 

		}
		#endregion
		#region SClass ED_GATOS_1212_Diagnoses for attribute Diagnoses
		[DataContract]
		public class ED_GATOS_1212_Diagnoses 
		{
			//Standard type parameters
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public Guid diagnnoseID { get; set; } 
			[DataMember]
			public DateTime DiagnosedOnDate { get; set; } 

		}
		#endregion
		#region SClass ED_GATOS_1212_Articles for attribute Articles
		[DataContract]
		public class ED_GATOS_1212_Articles 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_Treatment_RequiredProductID { get; set; } 
			[DataMember]
			public String ArticleName { get; set; } 
			[DataMember]
			public String PZN { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ED_GATOS_1212_Array cls_Get_All_Treatments_OLD_System(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ED_GATOS_1212_Array invocationResult = cls_Get_All_Treatments_OLD_System.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

