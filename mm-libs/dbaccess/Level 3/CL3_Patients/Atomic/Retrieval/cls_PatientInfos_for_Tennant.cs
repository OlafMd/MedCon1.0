/* 
 * Generated on 1/28/2015 10:49:57 AM
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

namespace CLE_L3_Patients.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_PatientInfos_for_Tennant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_PatientInfos_for_Tennant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_PIfT_1237_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_PIfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_PIfT_1237_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CLE_L3_Patients.Atomic.Retrieval.SQL.cls_PatientInfos_for_Tennant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L3_PIfT_1237_raw> results = new List<L3_PIfT_1237_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PER_PersonInfoID","FirstName","LastName","PrimaryEmail","BirthDate","HEC_PatientID","CMN_BPT_BusinessParticipant_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID","Gender","AgeCalculation_YearOfBirth","DefaultLanguage_RefID","Modification_TimestampBP","Modification_TimestampPatient","Modification_TimestampPersoInfo","Modification_TimestampCommunicationContact","Modification_TimestampContactType","CMN_PER_CommunicationContactID","Contact_Type","Content","IsDefaultForContactType" });
				while(reader.Read())
				{
					L3_PIfT_1237_raw resultItem = new L3_PIfT_1237_raw();
					//0:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(3);
					//4:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(4);
					//5:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(5);
					//6:Parameter CMN_BPT_BusinessParticipant_RefID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_RefID = reader.GetGuid(6);
					//7:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(7);
					//8:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(8);
					//9:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(9);
					//10:Parameter Gender of type int
					resultItem.Gender = reader.GetInteger(10);
					//11:Parameter AgeCalculation_YearOfBirth of type int
					resultItem.AgeCalculation_YearOfBirth = reader.GetInteger(11);
					//12:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(12);
					//13:Parameter Modification_TimestampBP of type DateTime
					resultItem.Modification_TimestampBP = reader.GetDate(13);
					//14:Parameter Modification_TimestampPatient of type DateTime
					resultItem.Modification_TimestampPatient = reader.GetDate(14);
					//15:Parameter Modification_TimestampPersoInfo of type DateTime
					resultItem.Modification_TimestampPersoInfo = reader.GetDate(15);
					//16:Parameter Modification_TimestampCommunicationContact of type DateTime
					resultItem.Modification_TimestampCommunicationContact = reader.GetDate(16);
					//17:Parameter Modification_TimestampContactType of type DateTime
					resultItem.Modification_TimestampContactType = reader.GetDate(17);
					//18:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(18);
					//19:Parameter Contact_Type of type Guid
					resultItem.Contact_Type = reader.GetGuid(19);
					//20:Parameter Content of type String
					resultItem.Content = reader.GetString(20);
					//21:Parameter IsDefaultForContactType of type bool
					resultItem.IsDefaultForContactType = reader.GetBoolean(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_PatientInfos_for_Tennant",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3_PIfT_1237_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3_PIfT_1237_Array Invoke(string ConnectionString,P_L3_PIfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_PIfT_1237_Array Invoke(DbConnection Connection,P_L3_PIfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_PIfT_1237_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_PIfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_PIfT_1237_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_PIfT_1237 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_PIfT_1237_Array functionReturn = new FR_L3_PIfT_1237_Array();
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

				throw new Exception("Exception occured in method cls_PatientInfos_for_Tennant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3_PIfT_1237_raw 
	{
		public Guid CMN_PER_PersonInfoID; 
		public String FirstName; 
		public String LastName; 
		public String PrimaryEmail; 
		public DateTime BirthDate; 
		public Guid HEC_PatientID; 
		public Guid CMN_BPT_BusinessParticipant_RefID; 
		public DateTime Creation_Timestamp; 
		public bool IsDeleted; 
		public Guid Tenant_RefID; 
		public int Gender; 
		public int AgeCalculation_YearOfBirth; 
		public Guid DefaultLanguage_RefID; 
		public DateTime Modification_TimestampBP; 
		public DateTime Modification_TimestampPatient; 
		public DateTime Modification_TimestampPersoInfo; 
		public DateTime Modification_TimestampCommunicationContact; 
		public DateTime Modification_TimestampContactType; 
		public Guid CMN_PER_CommunicationContactID; 
		public Guid Contact_Type; 
		public String Content; 
		public bool IsDefaultForContactType; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3_PIfT_1237[] Convert(List<L3_PIfT_1237_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3_PIfT_1237 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_PatientID)).ToArray()
	group el_L3_PIfT_1237 by new 
	{ 
		el_L3_PIfT_1237.HEC_PatientID,

	}
	into gfunct_L3_PIfT_1237
	select new L3_PIfT_1237
	{     
		CMN_PER_PersonInfoID = gfunct_L3_PIfT_1237.FirstOrDefault().CMN_PER_PersonInfoID ,
		FirstName = gfunct_L3_PIfT_1237.FirstOrDefault().FirstName ,
		LastName = gfunct_L3_PIfT_1237.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L3_PIfT_1237.FirstOrDefault().PrimaryEmail ,
		BirthDate = gfunct_L3_PIfT_1237.FirstOrDefault().BirthDate ,
		HEC_PatientID = gfunct_L3_PIfT_1237.Key.HEC_PatientID ,
		CMN_BPT_BusinessParticipant_RefID = gfunct_L3_PIfT_1237.FirstOrDefault().CMN_BPT_BusinessParticipant_RefID ,
		Creation_Timestamp = gfunct_L3_PIfT_1237.FirstOrDefault().Creation_Timestamp ,
		IsDeleted = gfunct_L3_PIfT_1237.FirstOrDefault().IsDeleted ,
		Tenant_RefID = gfunct_L3_PIfT_1237.FirstOrDefault().Tenant_RefID ,
		Gender = gfunct_L3_PIfT_1237.FirstOrDefault().Gender ,
		AgeCalculation_YearOfBirth = gfunct_L3_PIfT_1237.FirstOrDefault().AgeCalculation_YearOfBirth ,
		DefaultLanguage_RefID = gfunct_L3_PIfT_1237.FirstOrDefault().DefaultLanguage_RefID ,
		Modification_TimestampBP = gfunct_L3_PIfT_1237.FirstOrDefault().Modification_TimestampBP ,
		Modification_TimestampPatient = gfunct_L3_PIfT_1237.FirstOrDefault().Modification_TimestampPatient ,
		Modification_TimestampPersoInfo = gfunct_L3_PIfT_1237.FirstOrDefault().Modification_TimestampPersoInfo ,
		Modification_TimestampCommunicationContact = gfunct_L3_PIfT_1237.FirstOrDefault().Modification_TimestampCommunicationContact ,
		Modification_TimestampContactType = gfunct_L3_PIfT_1237.FirstOrDefault().Modification_TimestampContactType ,

		Contacts = 
		(
			from el_Contacts in gfunct_L3_PIfT_1237.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContactID)).ToArray()
			group el_Contacts by new 
			{ 
				el_Contacts.CMN_PER_CommunicationContactID,

			}
			into gfunct_Contacts
			select new L3_PIfT_Contacts
			{     
				CMN_PER_CommunicationContactID = gfunct_Contacts.Key.CMN_PER_CommunicationContactID ,
				Contact_Type = gfunct_Contacts.FirstOrDefault().Contact_Type ,
				Content = gfunct_Contacts.FirstOrDefault().Content ,
				IsDefaultForContactType = gfunct_Contacts.FirstOrDefault().IsDefaultForContactType ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3_PIfT_1237_Array : FR_Base
	{
		public L3_PIfT_1237[] Result	{ get; set; } 
		public FR_L3_PIfT_1237_Array() : base() {}

		public FR_L3_PIfT_1237_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_PIfT_1237 for attribute P_L3_PIfT_1237
		[DataContract]
		public class P_L3_PIfT_1237 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L3_PIfT_1237 for attribute L3_PIfT_1237
		[DataContract]
		public class L3_PIfT_1237 
		{
			[DataMember]
			public L3_PIfT_Contacts[] Contacts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public int Gender { get; set; } 
			[DataMember]
			public int AgeCalculation_YearOfBirth { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampBP { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampPatient { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampPersoInfo { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampCommunicationContact { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampContactType { get; set; } 

		}
		#endregion
		#region SClass L3_PIfT_Contacts for attribute Contacts
		[DataContract]
		public class L3_PIfT_Contacts 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
			[DataMember]
			public Guid Contact_Type { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public bool IsDefaultForContactType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_PIfT_1237_Array cls_PatientInfos_for_Tennant(,P_L3_PIfT_1237 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_PIfT_1237_Array invocationResult = cls_PatientInfos_for_Tennant.Invoke(connectionString,P_L3_PIfT_1237 Parameter,securityTicket);
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
var parameter = new CLE_L3_Patients.Atomic.Retrieval.P_L3_PIfT_1237();
parameter.Tenant = ...;

*/
