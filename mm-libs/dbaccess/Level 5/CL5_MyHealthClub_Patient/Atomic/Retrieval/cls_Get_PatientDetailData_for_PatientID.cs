/* 
 * Generated on 29.01.2015 11:39:56
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

namespace CL5_MyHealthClub_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientDetailData_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientDetailData_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPDDfPID_1358 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPDDfPID_1358 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPDDfPID_1358();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Patient.Atomic.Retrieval.SQL.cls_Get_PatientDetailData_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<L5PA_GPDDfPID_1358_raw> results = new List<L5PA_GPDDfPID_1358_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FirstName","LastName","PrimaryEmail","Title","ID","Gender","AcademicTitle","BirthDate","ProfileImage_Document_RefID","Name_DictID","CMN_LanguageID","CMN_PER_CommunicationContactID","Content","Type","CMN_PER_PersonInfo_SocialSecurityNumberID","SocialSecurityNumber","CMN_AddressID","Street_Name","Street_Number","City_Name","City_PostalCode","Country_ISOCode" });
				while(reader.Read())
				{
					L5PA_GPDDfPID_1358_raw resultItem = new L5PA_GPDDfPID_1358_raw();
					//0:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(0);
					//1:Parameter LastName of type String
					resultItem.LastName = reader.GetString(1);
					//2:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(2);
					//3:Parameter Title of type String
					resultItem.Title = reader.GetString(3);
					//4:Parameter ID of type Guid
					resultItem.ID = reader.GetGuid(4);
					//5:Parameter Gender of type String
					resultItem.Gender = reader.GetString(5);
					//6:Parameter AcademicTitle of type String
					resultItem.AcademicTitle = reader.GetString(6);
					//7:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(7);
					//8:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(8);
					//9:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(9);
					resultItem.Name.SourceTable = "cmn_languages";
					loader.Append(resultItem.Name);
					//10:Parameter CMN_LanguageID of type Guid
					resultItem.CMN_LanguageID = reader.GetGuid(10);
					//11:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(11);
					//12:Parameter Content of type String
					resultItem.Content = reader.GetString(12);
					//13:Parameter Type of type String
					resultItem.Type = reader.GetString(13);
					//14:Parameter CMN_PER_PersonInfo_SocialSecurityNumberID of type Guid
					resultItem.CMN_PER_PersonInfo_SocialSecurityNumberID = reader.GetGuid(14);
					//15:Parameter SocialSecurityNumber of type String
					resultItem.SocialSecurityNumber = reader.GetString(15);
					//16:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(16);
					//17:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(17);
					//18:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(18);
					//19:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(19);
					//20:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(20);
					//21:Parameter Country_ISOCode of type String
					resultItem.Country_ISOCode = reader.GetString(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientDetailData_for_PatientID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PA_GPDDfPID_1358_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPDDfPID_1358 Invoke(string ConnectionString,P_L5PA_GPDDfPID_1358 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPDDfPID_1358 Invoke(DbConnection Connection,P_L5PA_GPDDfPID_1358 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPDDfPID_1358 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPDDfPID_1358 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPDDfPID_1358 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPDDfPID_1358 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPDDfPID_1358 functionReturn = new FR_L5PA_GPDDfPID_1358();
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

				throw new Exception("Exception occured in method cls_Get_PatientDetailData_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PA_GPDDfPID_1358_raw 
	{
		public String FirstName; 
		public String LastName; 
		public String PrimaryEmail; 
		public String Title; 
		public Guid ID; 
		public String Gender; 
		public String AcademicTitle; 
		public DateTime BirthDate; 
		public Guid ProfileImage_Document_RefID; 
		public Dict Name; 
		public Guid CMN_LanguageID; 
		public Guid CMN_PER_CommunicationContactID; 
		public String Content; 
		public String Type; 
		public Guid CMN_PER_PersonInfo_SocialSecurityNumberID; 
		public String SocialSecurityNumber; 
		public Guid CMN_AddressID; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_Name; 
		public String City_PostalCode; 
		public String Country_ISOCode; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PA_GPDDfPID_1358[] Convert(List<L5PA_GPDDfPID_1358_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PA_GPDDfPID_1358 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.ID)).ToArray()
	group el_L5PA_GPDDfPID_1358 by new 
	{ 
		el_L5PA_GPDDfPID_1358.ID,

	}
	into gfunct_L5PA_GPDDfPID_1358
	select new L5PA_GPDDfPID_1358
	{     
		FirstName = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().FirstName ,
		LastName = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().PrimaryEmail ,
		Title = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().Title ,
		ID = gfunct_L5PA_GPDDfPID_1358.Key.ID ,
		Gender = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().Gender ,
		AcademicTitle = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().AcademicTitle ,
		BirthDate = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().BirthDate ,
		ProfileImage_Document_RefID = gfunct_L5PA_GPDDfPID_1358.FirstOrDefault().ProfileImage_Document_RefID ,

		Languages = 
		(
			from el_Languages in gfunct_L5PA_GPDDfPID_1358.Where(element => !EqualsDefaultValue(element.CMN_LanguageID)).ToArray()
			group el_Languages by new 
			{ 
				el_Languages.CMN_LanguageID,

			}
			into gfunct_Languages
			select new L5PA_GPDDfPID_1358_Languages
			{     
				Name = gfunct_Languages.FirstOrDefault().Name ,
				CMN_LanguageID = gfunct_Languages.Key.CMN_LanguageID ,

			}
		).ToArray(),
		ContactTypes = 
		(
			from el_ContactTypes in gfunct_L5PA_GPDDfPID_1358.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContactID)).ToArray()
			group el_ContactTypes by new 
			{ 
				el_ContactTypes.CMN_PER_CommunicationContactID,

			}
			into gfunct_ContactTypes
			select new L5PA_GPDDfPID_1358_ContactTypes
			{     
				CMN_PER_CommunicationContactID = gfunct_ContactTypes.Key.CMN_PER_CommunicationContactID ,
				Content = gfunct_ContactTypes.FirstOrDefault().Content ,
				Type = gfunct_ContactTypes.FirstOrDefault().Type ,

			}
		).ToArray(),
		SSNumber = 
		(
			from el_SSNumber in gfunct_L5PA_GPDDfPID_1358.Where(element => !EqualsDefaultValue(element.CMN_PER_PersonInfo_SocialSecurityNumberID)).ToArray()
			group el_SSNumber by new 
			{ 
				el_SSNumber.CMN_PER_PersonInfo_SocialSecurityNumberID,

			}
			into gfunct_SSNumber
			select new L5PA_GPDDfPID_1358_SSNumber
			{     
				CMN_PER_PersonInfo_SocialSecurityNumberID = gfunct_SSNumber.Key.CMN_PER_PersonInfo_SocialSecurityNumberID ,
				SocialSecurityNumber = gfunct_SSNumber.FirstOrDefault().SocialSecurityNumber ,

			}
		).FirstOrDefault(),
		Address = 
		(
			from el_Address in gfunct_L5PA_GPDDfPID_1358.Where(element => !EqualsDefaultValue(element.CMN_AddressID)).ToArray()
			group el_Address by new 
			{ 
				el_Address.CMN_AddressID,

			}
			into gfunct_Address
			select new L5PA_GPDDfPID_1358_Address
			{     
				CMN_AddressID = gfunct_Address.Key.CMN_AddressID ,
				Street_Name = gfunct_Address.FirstOrDefault().Street_Name ,
				Street_Number = gfunct_Address.FirstOrDefault().Street_Number ,
				City_Name = gfunct_Address.FirstOrDefault().City_Name ,
				City_PostalCode = gfunct_Address.FirstOrDefault().City_PostalCode ,
				Country_ISOCode = gfunct_Address.FirstOrDefault().Country_ISOCode ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPDDfPID_1358 : FR_Base
	{
		public L5PA_GPDDfPID_1358 Result	{ get; set; }

		public FR_L5PA_GPDDfPID_1358() : base() {}

		public FR_L5PA_GPDDfPID_1358(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPDDfPID_1358 for attribute P_L5PA_GPDDfPID_1358
		[DataContract]
		public class P_L5PA_GPDDfPID_1358 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPDDfPID_1358 for attribute L5PA_GPDDfPID_1358
		[DataContract]
		public class L5PA_GPDDfPID_1358 
		{
			[DataMember]
			public L5PA_GPDDfPID_1358_Languages[] Languages { get; set; }
			[DataMember]
			public L5PA_GPDDfPID_1358_ContactTypes[] ContactTypes { get; set; }
			[DataMember]
			public L5PA_GPDDfPID_1358_SSNumber SSNumber { get; set; }
			[DataMember]
			public L5PA_GPDDfPID_1358_Address Address { get; set; }

			//Standard type parameters
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public String Gender { get; set; } 
			[DataMember]
			public String AcademicTitle { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid ProfileImage_Document_RefID { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPDDfPID_1358_Languages for attribute Languages
		[DataContract]
		public class L5PA_GPDDfPID_1358_Languages 
		{
			//Standard type parameters
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid CMN_LanguageID { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPDDfPID_1358_ContactTypes for attribute ContactTypes
		[DataContract]
		public class L5PA_GPDDfPID_1358_ContactTypes 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public String Type { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPDDfPID_1358_SSNumber for attribute SSNumber
		[DataContract]
		public class L5PA_GPDDfPID_1358_SSNumber 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_PersonInfo_SocialSecurityNumberID { get; set; } 
			[DataMember]
			public String SocialSecurityNumber { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPDDfPID_1358_Address for attribute Address
		[DataContract]
		public class L5PA_GPDDfPID_1358_Address 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_ISOCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GPDDfPID_1358 cls_Get_PatientDetailData_for_PatientID(,P_L5PA_GPDDfPID_1358 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPDDfPID_1358 invocationResult = cls_Get_PatientDetailData_for_PatientID.Invoke(connectionString,P_L5PA_GPDDfPID_1358 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Patient.Atomic.Retrieval.P_L5PA_GPDDfPID_1358();
parameter.PatientID = ...;

*/
