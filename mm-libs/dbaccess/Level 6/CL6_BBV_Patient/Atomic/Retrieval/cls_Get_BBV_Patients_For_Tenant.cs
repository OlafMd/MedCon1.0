/* 
 * Generated on 7/11/2013 3:37:02 PM
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

namespace CL6_BBV_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 

    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BBV_Patients_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BBV_Patients_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PA_GBBVPFT_1700_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PA_GBBVPFT_1700_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_BBV_Patient.Atomic.Retrieval.SQL.cls_Get_BBV_Patients_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L6PA_GBBVPFT_1700_raw> results = new List<L6PA_GBBVPFT_1700_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Salutation_General","FirstName","LastName","PrimaryEmail","HealthInsurance_Number","PatientComment","HasFulfilledParticipationPolicyRequirements","CMN_PER_PersonInfoID","CMN_BPT_BusinessParticipantID","HEC_Patient_HealthInsurancesID","HEC_PatientID","HEC_STU_Study_ParticipatingPatientID","Participation_DateOfSigning","Participation_Comment","Driver_FirstName","Driver_LastName","Content","CMN_PER_CommunicationContactID","Contact_Type","Street_Number","Street_Name","City_Name","City_PostalCode","Province_Name","SequenceNumber","IsPrimary","CMN_AddressID","AssignmentID","GlobalPropertyMatchingID","File_Name","File_Extension","File_ServerLocation","File_Size_Bytes","HEC_STU_Study_PatientDocumentID" });
				while(reader.Read())
				{
					L6PA_GBBVPFT_1700_raw resultItem = new L6PA_GBBVPFT_1700_raw();
					//0:Parameter Salutation_General of type string
					resultItem.Salutation_General = reader.GetString(0);
					//1:Parameter FirstName of type string
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type string
					resultItem.LastName = reader.GetString(2);
					//3:Parameter PrimaryEmail of type string
					resultItem.PrimaryEmail = reader.GetString(3);
					//4:Parameter HealthInsurance_Number of type string
					resultItem.HealthInsurance_Number = reader.GetString(4);
					//5:Parameter PatientComment of type string
					resultItem.PatientComment = reader.GetString(5);
					//6:Parameter HasFulfilledParticipationPolicyRequirements of type bool
					resultItem.HasFulfilledParticipationPolicyRequirements = reader.GetBoolean(6);
					//7:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(7);
					//8:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(8);
					//9:Parameter HEC_Patient_HealthInsurancesID of type Guid
					resultItem.HEC_Patient_HealthInsurancesID = reader.GetGuid(9);
					//10:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(10);
					//11:Parameter HEC_STU_Study_ParticipatingPatientID of type Guid
					resultItem.HEC_STU_Study_ParticipatingPatientID = reader.GetGuid(11);
					//12:Parameter Participation_DateOfSigning of type DateTime
					resultItem.Participation_DateOfSigning = reader.GetDate(12);
					//13:Parameter Participation_Comment of type string
					resultItem.Participation_Comment = reader.GetString(13);
					//14:Parameter Driver_FirstName of type string
					resultItem.Driver_FirstName = reader.GetString(14);
					//15:Parameter Driver_LastName of type string
					resultItem.Driver_LastName = reader.GetString(15);
					//16:Parameter Content of type String
					resultItem.Content = reader.GetString(16);
					//17:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(17);
					//18:Parameter Contact_Type of type Guid
					resultItem.Contact_Type = reader.GetGuid(18);
					//19:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(19);
					//20:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(20);
					//21:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(21);
					//22:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(22);
					//23:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(23);
					//24:Parameter SequenceNumber of type int
					resultItem.SequenceNumber = reader.GetInteger(24);
					//25:Parameter IsPrimary of type bool
					resultItem.IsPrimary = reader.GetBoolean(25);
					//26:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(26);
					//27:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(27);
					//28:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(28);
					//29:Parameter File_Name of type String
					resultItem.File_Name = reader.GetString(29);
					//30:Parameter File_Extension of type String
					resultItem.File_Extension = reader.GetString(30);
					//31:Parameter File_ServerLocation of type String
					resultItem.File_ServerLocation = reader.GetString(31);
					//32:Parameter File_Size_Bytes of type int
					resultItem.File_Size_Bytes = reader.GetInteger(32);
					//33:Parameter HEC_STU_Study_PatientDocumentID of type Guid
					resultItem.HEC_STU_Study_PatientDocumentID = reader.GetGuid(33);

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

			returnStatus.Result = L6PA_GBBVPFT_1700_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PA_GBBVPFT_1700_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PA_GBBVPFT_1700_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PA_GBBVPFT_1700_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PA_GBBVPFT_1700_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PA_GBBVPFT_1700_Array functionReturn = new FR_L6PA_GBBVPFT_1700_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6PA_GBBVPFT_1700_raw 
	{
		public string Salutation_General; 
		public string FirstName; 
		public string LastName; 
		public string PrimaryEmail; 
		public string HealthInsurance_Number; 
		public string PatientComment; 
		public bool HasFulfilledParticipationPolicyRequirements; 
		public Guid CMN_PER_PersonInfoID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid HEC_Patient_HealthInsurancesID; 
		public Guid HEC_PatientID; 
		public Guid HEC_STU_Study_ParticipatingPatientID; 
		public DateTime Participation_DateOfSigning; 
		public string Participation_Comment; 
		public string Driver_FirstName; 
		public string Driver_LastName; 
		public String Content; 
		public Guid CMN_PER_CommunicationContactID; 
		public Guid Contact_Type; 
		public String Street_Number; 
		public String Street_Name; 
		public String City_Name; 
		public String City_PostalCode; 
		public String Province_Name; 
		public int SequenceNumber; 
		public bool IsPrimary; 
		public Guid CMN_AddressID; 
		public Guid AssignmentID; 
		public String GlobalPropertyMatchingID; 
		public String File_Name; 
		public String File_Extension; 
		public String File_ServerLocation; 
		public int File_Size_Bytes; 
		public Guid HEC_STU_Study_PatientDocumentID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6PA_GBBVPFT_1700[] Convert(List<L6PA_GBBVPFT_1700_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6PA_GBBVPFT_1700 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_PatientID)).ToArray()
	group el_L6PA_GBBVPFT_1700 by new 
	{ 
		el_L6PA_GBBVPFT_1700.HEC_PatientID,

	}
	into gfunct_L6PA_GBBVPFT_1700
	select new L6PA_GBBVPFT_1700
	{     
		Salutation_General = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().Salutation_General ,
		FirstName = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().FirstName ,
		LastName = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().PrimaryEmail ,
		HealthInsurance_Number = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().HealthInsurance_Number ,
		PatientComment = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().PatientComment ,
		HasFulfilledParticipationPolicyRequirements = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().HasFulfilledParticipationPolicyRequirements ,
		CMN_PER_PersonInfoID = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().CMN_PER_PersonInfoID ,
		CMN_BPT_BusinessParticipantID = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		HEC_Patient_HealthInsurancesID = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().HEC_Patient_HealthInsurancesID ,
		HEC_PatientID = gfunct_L6PA_GBBVPFT_1700.Key.HEC_PatientID ,
		HEC_STU_Study_ParticipatingPatientID = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().HEC_STU_Study_ParticipatingPatientID ,
		Participation_DateOfSigning = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().Participation_DateOfSigning ,
		Participation_Comment = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().Participation_Comment ,
		Driver_FirstName = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().Driver_FirstName ,
		Driver_LastName = gfunct_L6PA_GBBVPFT_1700.FirstOrDefault().Driver_LastName ,

		Contacts = 
		(
			from el_Contacts in gfunct_L6PA_GBBVPFT_1700.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContactID)).ToArray()
			group el_Contacts by new 
			{ 
				el_Contacts.CMN_PER_CommunicationContactID,

			}
			into gfunct_Contacts
			select new L6PA_GBBVPFT_1700_Contact
			{     
				Content = gfunct_Contacts.FirstOrDefault().Content ,
				CMN_PER_CommunicationContactID = gfunct_Contacts.Key.CMN_PER_CommunicationContactID ,
				Contact_Type = gfunct_Contacts.FirstOrDefault().Contact_Type ,

			}
		).ToArray(),
		Addresses = 
		(
			from el_Addresses in gfunct_L6PA_GBBVPFT_1700.Where(element => !EqualsDefaultValue(element.CMN_AddressID)).ToArray()
			group el_Addresses by new 
			{ 
				el_Addresses.CMN_AddressID,

			}
			into gfunct_Addresses
			select new L6PA_GBBVPFT_1700_Addresses
			{     
				Street_Number = gfunct_Addresses.FirstOrDefault().Street_Number ,
				Street_Name = gfunct_Addresses.FirstOrDefault().Street_Name ,
				City_Name = gfunct_Addresses.FirstOrDefault().City_Name ,
				City_PostalCode = gfunct_Addresses.FirstOrDefault().City_PostalCode ,
				Province_Name = gfunct_Addresses.FirstOrDefault().Province_Name ,
				SequenceNumber = gfunct_Addresses.FirstOrDefault().SequenceNumber ,
				IsPrimary = gfunct_Addresses.FirstOrDefault().IsPrimary ,
				CMN_AddressID = gfunct_Addresses.Key.CMN_AddressID ,
				AssignmentID = gfunct_Addresses.FirstOrDefault().AssignmentID ,

			}
		).ToArray(),
		PoliciyImages = 
		(
			from el_PoliciyImages in gfunct_L6PA_GBBVPFT_1700.Where(element => !EqualsDefaultValue(element.HEC_STU_Study_PatientDocumentID)).ToArray()
			group el_PoliciyImages by new 
			{ 
				el_PoliciyImages.HEC_STU_Study_PatientDocumentID,

			}
			into gfunct_PoliciyImages
			select new L6PA_GBBVPFT_1700_PoliciyImage
			{     
				GlobalPropertyMatchingID = gfunct_PoliciyImages.FirstOrDefault().GlobalPropertyMatchingID ,
				File_Name = gfunct_PoliciyImages.FirstOrDefault().File_Name ,
				File_Extension = gfunct_PoliciyImages.FirstOrDefault().File_Extension ,
				File_ServerLocation = gfunct_PoliciyImages.FirstOrDefault().File_ServerLocation ,
				File_Size_Bytes = gfunct_PoliciyImages.FirstOrDefault().File_Size_Bytes ,
				HEC_STU_Study_PatientDocumentID = gfunct_PoliciyImages.Key.HEC_STU_Study_PatientDocumentID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6PA_GBBVPFT_1700_Array : FR_Base
	{
		public L6PA_GBBVPFT_1700[] Result	{ get; set; } 
		public FR_L6PA_GBBVPFT_1700_Array() : base() {}

		public FR_L6PA_GBBVPFT_1700_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6PA_GBBVPFT_1700 for attribute L6PA_GBBVPFT_1700
		[DataContract]
		public class L6PA_GBBVPFT_1700 
		{
			[DataMember]
			public L6PA_GBBVPFT_1700_Contact[] Contacts { get; set; }
			[DataMember]
			public L6PA_GBBVPFT_1700_Addresses[] Addresses { get; set; }
			[DataMember]
			public L6PA_GBBVPFT_1700_PoliciyImage[] PoliciyImages { get; set; }

			//Standard type parameters
			[DataMember]
			public string Salutation_General { get; set; } 
			[DataMember]
			public string FirstName { get; set; } 
			[DataMember]
			public string LastName { get; set; } 
			[DataMember]
			public string PrimaryEmail { get; set; } 
			[DataMember]
			public string HealthInsurance_Number { get; set; } 
			[DataMember]
			public string PatientComment { get; set; } 
			[DataMember]
			public bool HasFulfilledParticipationPolicyRequirements { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_HealthInsurancesID { get; set; } 
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public Guid HEC_STU_Study_ParticipatingPatientID { get; set; } 
			[DataMember]
			public DateTime Participation_DateOfSigning { get; set; } 
			[DataMember]
			public string Participation_Comment { get; set; } 
			[DataMember]
			public string Driver_FirstName { get; set; } 
			[DataMember]
			public string Driver_LastName { get; set; } 

		}
		#endregion
		#region SClass L6PA_GBBVPFT_1700_Contact for attribute Contacts
		[DataContract]
		public class L6PA_GBBVPFT_1700_Contact 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
			[DataMember]
			public Guid Contact_Type { get; set; } 

		}
		#endregion
		#region SClass L6PA_GBBVPFT_1700_Addresses for attribute Addresses
		[DataContract]
		public class L6PA_GBBVPFT_1700_Addresses 
		{
			//Standard type parameters
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public int SequenceNumber { get; set; } 
			[DataMember]
			public bool IsPrimary { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public Guid AssignmentID { get; set; } 

		}
		#endregion
		#region SClass L6PA_GBBVPFT_1700_PoliciyImage for attribute PoliciyImages
		[DataContract]
		public class L6PA_GBBVPFT_1700_PoliciyImage 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String File_Name { get; set; } 
			[DataMember]
			public String File_Extension { get; set; } 
			[DataMember]
			public String File_ServerLocation { get; set; } 
			[DataMember]
			public int File_Size_Bytes { get; set; } 
			[DataMember]
			public Guid HEC_STU_Study_PatientDocumentID { get; set; } 

		}
		#endregion

	#endregion
}
