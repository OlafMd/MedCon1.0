/* 
 * Generated on 7/23/2013 1:42:37 PM
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

namespace CL6_MS_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 

    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_MS_Patients_For_DeviceCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_MS_Patients_For_DeviceCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PA_GMSPfDC_1338 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_GMSPfDC_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PA_GMSPfDC_1338();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_MS_Patient.Atomic.Retrieval.SQL.cls_Get_MS_Patients_For_DeviceCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CodeValue", Parameter.CodeValue);



			List<L6PA_GMSPfDC_1338_raw> results = new List<L6PA_GMSPfDC_1338_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "USR_AccountID","USR_Device_AccountCodeID","AccountCode_Value","Salutation_General","FirstName","LastName","PrimaryEmail","HealthInsurance_Number","PatientComment","HasFulfilledParticipationPolicyRequirements","CMN_PER_PersonInfoID","CMN_BPT_BusinessParticipantID","HEC_Patient_HealthInsurancesID","HEC_PatientID","HEC_STU_Study_ParticipatingPatientID","Participation_DateOfSigning","Participation_Comment","Content","CMN_PER_CommunicationContactID","Contact_Type","Street_Number","Street_Name","City_Name","City_PostalCode","Province_Name","SequenceNumber","IsPrimary","CMN_AddressID","AssignmentID" });
				while(reader.Read())
				{
					L6PA_GMSPfDC_1338_raw resultItem = new L6PA_GMSPfDC_1338_raw();
					//0:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(0);
					//1:Parameter USR_Device_AccountCodeID of type Guid
					resultItem.USR_Device_AccountCodeID = reader.GetGuid(1);
					//2:Parameter AccountCode_Value of type string
					resultItem.AccountCode_Value = reader.GetString(2);
					//3:Parameter Salutation_General of type string
					resultItem.Salutation_General = reader.GetString(3);
					//4:Parameter FirstName of type string
					resultItem.FirstName = reader.GetString(4);
					//5:Parameter LastName of type string
					resultItem.LastName = reader.GetString(5);
					//6:Parameter PrimaryEmail of type string
					resultItem.PrimaryEmail = reader.GetString(6);
					//7:Parameter HealthInsurance_Number of type string
					resultItem.HealthInsurance_Number = reader.GetString(7);
					//8:Parameter PatientComment of type string
					resultItem.PatientComment = reader.GetString(8);
					//9:Parameter HasFulfilledParticipationPolicyRequirements of type bool
					resultItem.HasFulfilledParticipationPolicyRequirements = reader.GetBoolean(9);
					//10:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(10);
					//11:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(11);
					//12:Parameter HEC_Patient_HealthInsurancesID of type Guid
					resultItem.HEC_Patient_HealthInsurancesID = reader.GetGuid(12);
					//13:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(13);
					//14:Parameter HEC_STU_Study_ParticipatingPatientID of type Guid
					resultItem.HEC_STU_Study_ParticipatingPatientID = reader.GetGuid(14);
					//15:Parameter Participation_DateOfSigning of type DateTime
					resultItem.Participation_DateOfSigning = reader.GetDate(15);
					//16:Parameter Participation_Comment of type string
					resultItem.Participation_Comment = reader.GetString(16);
					//17:Parameter Content of type String
					resultItem.Content = reader.GetString(17);
					//18:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(18);
					//19:Parameter Contact_Type of type Guid
					resultItem.Contact_Type = reader.GetGuid(19);
					//20:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(20);
					//21:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(21);
					//22:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(22);
					//23:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(23);
					//24:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(24);
					//25:Parameter SequenceNumber of type int
					resultItem.SequenceNumber = reader.GetInteger(25);
					//26:Parameter IsPrimary of type bool
					resultItem.IsPrimary = reader.GetBoolean(26);
					//27:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(27);
					//28:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(28);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_MS_Patients_For_DeviceCode",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6PA_GMSPfDC_1338_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PA_GMSPfDC_1338 Invoke(string ConnectionString,P_L6PA_GMSPfDC_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PA_GMSPfDC_1338 Invoke(DbConnection Connection,P_L6PA_GMSPfDC_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PA_GMSPfDC_1338 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_GMSPfDC_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PA_GMSPfDC_1338 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_GMSPfDC_1338 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PA_GMSPfDC_1338 functionReturn = new FR_L6PA_GMSPfDC_1338();
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

				throw new Exception("Exception occured in method cls_Get_MS_Patients_For_DeviceCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6PA_GMSPfDC_1338_raw 
	{
		public Guid USR_AccountID; 
		public Guid USR_Device_AccountCodeID; 
		public string AccountCode_Value; 
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


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6PA_GMSPfDC_1338[] Convert(List<L6PA_GMSPfDC_1338_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6PA_GMSPfDC_1338 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_PatientID)).ToArray()
	group el_L6PA_GMSPfDC_1338 by new 
	{ 
		el_L6PA_GMSPfDC_1338.HEC_PatientID,

	}
	into gfunct_L6PA_GMSPfDC_1338
	select new L6PA_GMSPfDC_1338
	{     
		USR_AccountID = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().USR_AccountID ,
		USR_Device_AccountCodeID = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().USR_Device_AccountCodeID ,
		AccountCode_Value = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().AccountCode_Value ,
		Salutation_General = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().Salutation_General ,
		FirstName = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().FirstName ,
		LastName = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().PrimaryEmail ,
		HealthInsurance_Number = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().HealthInsurance_Number ,
		PatientComment = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().PatientComment ,
		HasFulfilledParticipationPolicyRequirements = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().HasFulfilledParticipationPolicyRequirements ,
		CMN_PER_PersonInfoID = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().CMN_PER_PersonInfoID ,
		CMN_BPT_BusinessParticipantID = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		HEC_Patient_HealthInsurancesID = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().HEC_Patient_HealthInsurancesID ,
		HEC_PatientID = gfunct_L6PA_GMSPfDC_1338.Key.HEC_PatientID ,
		HEC_STU_Study_ParticipatingPatientID = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().HEC_STU_Study_ParticipatingPatientID ,
		Participation_DateOfSigning = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().Participation_DateOfSigning ,
		Participation_Comment = gfunct_L6PA_GMSPfDC_1338.FirstOrDefault().Participation_Comment ,

		Contacts = 
		(
			from el_Contacts in gfunct_L6PA_GMSPfDC_1338.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContactID)).ToArray()
			group el_Contacts by new 
			{ 
				el_Contacts.CMN_PER_CommunicationContactID,

			}
			into gfunct_Contacts
			select new L6PA_GMSPfDC_1338_Contact
			{     
				Content = gfunct_Contacts.FirstOrDefault().Content ,
				CMN_PER_CommunicationContactID = gfunct_Contacts.Key.CMN_PER_CommunicationContactID ,
				Contact_Type = gfunct_Contacts.FirstOrDefault().Contact_Type ,

			}
		).ToArray(),
		Addresses = 
		(
			from el_Addresses in gfunct_L6PA_GMSPfDC_1338.Where(element => !EqualsDefaultValue(element.CMN_AddressID)).ToArray()
			group el_Addresses by new 
			{ 
				el_Addresses.CMN_AddressID,

			}
			into gfunct_Addresses
			select new L6PA_GMSPfDC_1338_Address
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

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6PA_GMSPfDC_1338 : FR_Base
	{
		public L6PA_GMSPfDC_1338 Result	{ get; set; }

		public FR_L6PA_GMSPfDC_1338() : base() {}

		public FR_L6PA_GMSPfDC_1338(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PA_GMSPfDC_1338 for attribute P_L6PA_GMSPfDC_1338
		[DataContract]
		public class P_L6PA_GMSPfDC_1338 
		{
			//Standard type parameters
			[DataMember]
			public string CodeValue { get; set; } 

		}
		#endregion
		#region SClass L6PA_GMSPfDC_1338 for attribute L6PA_GMSPfDC_1338
		[DataContract]
		public class L6PA_GMSPfDC_1338 
		{
			[DataMember]
			public L6PA_GMSPfDC_1338_Contact[] Contacts { get; set; }
			[DataMember]
			public L6PA_GMSPfDC_1338_Address[] Addresses { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid USR_Device_AccountCodeID { get; set; } 
			[DataMember]
			public string AccountCode_Value { get; set; } 
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

		}
		#endregion
		#region SClass L6PA_GMSPfDC_1338_Contact for attribute Contacts
		[DataContract]
		public class L6PA_GMSPfDC_1338_Contact 
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
		#region SClass L6PA_GMSPfDC_1338_Address for attribute Addresses
		[DataContract]
		public class L6PA_GMSPfDC_1338_Address 
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

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PA_GMSPfDC_1338 cls_Get_MS_Patients_For_DeviceCode(,P_L6PA_GMSPfDC_1338 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PA_GMSPfDC_1338 invocationResult = cls_Get_MS_Patients_For_DeviceCode.Invoke(connectionString,P_L6PA_GMSPfDC_1338 Parameter,securityTicket);
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
var parameter = new CL6_MS_Patient.Atomic.Retrieval.P_L6PA_GMSPfDC_1338();
parameter.CodeValue = ...;

*/
