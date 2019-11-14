/* 
 * Generated on 1/29/2015 11:08:52 AM
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

namespace CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctors_and_Staff_allData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctors_and_Staff_allData_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DO_GDaSaDfT_1613_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DO_GDaSaDfT_1613_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_DoctorsAndStaff.Atomic.Retrieval.SQL.cls_Get_Doctors_and_Staff_allData_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5DO_GDaSaDfT_1613_raw> results = new List<L5DO_GDaSaDfT_1613_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","CMN_BPT_EMP_EmployeeID","DisplayName","FirstName","LastName","Gender","IsTreatingChildren","PrimaryEmail","Initials","Title","DoctorIDNumber","Staff_Number","hasOpeningTime","ProfessionName_DictID","DisplayImage_RefID","CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID","Account_RefID","CMN_STR_OfficeID","Office_Name_DictID","Office_InternalNumber","Name_DictID","CMN_LanguageID","CMN_STR_SkillID","Skill_Name_DictID","PPS_TSK_Task_TemplateID","TaskTemplateName_DictID","CMN_STR_ProfessionID","IsPrimary","CMN_PER_CommunicationContact_TypeID","Type","Content" });
				while(reader.Read())
				{
					L5DO_GDaSaDfT_1613_raw resultItem = new L5DO_GDaSaDfT_1613_raw();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter Gender of type int
					resultItem.Gender = reader.GetInteger(5);
					//6:Parameter IsTreatingChildren of type Boolean
					resultItem.IsTreatingChildren = reader.GetBoolean(6);
					//7:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(7);
					//8:Parameter Initials of type String
					resultItem.Initials = reader.GetString(8);
					//9:Parameter Title of type String
					resultItem.Title = reader.GetString(9);
					//10:Parameter DoctorIDNumber of type String
					resultItem.DoctorIDNumber = reader.GetString(10);
					//11:Parameter Staff_Number of type String
					resultItem.Staff_Number = reader.GetString(11);
					//12:Parameter hasOpeningTime of type bool
					resultItem.hasOpeningTime = reader.GetBoolean(12);
					//13:Parameter ProfessionName of type Dict
					resultItem.ProfessionName = reader.GetDictionary(13);
					resultItem.ProfessionName.SourceTable = "cmn_str_professions";
					loader.Append(resultItem.ProfessionName);
					//14:Parameter DisplayImage_RefID of type Guid
					resultItem.DisplayImage_RefID = reader.GetGuid(14);
					//15:Parameter CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = reader.GetGuid(15);
					//16:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(16);
					//17:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(17);
					//18:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(18);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//19:Parameter Office_InternalNumber of type String
					resultItem.Office_InternalNumber = reader.GetString(19);
					//20:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(20);
					resultItem.Name.SourceTable = "cmn_languages";
					loader.Append(resultItem.Name);
					//21:Parameter CMN_LanguageID of type Guid
					resultItem.CMN_LanguageID = reader.GetGuid(21);
					//22:Parameter CMN_STR_SkillID of type Guid
					resultItem.CMN_STR_SkillID = reader.GetGuid(22);
					//23:Parameter Skill_Name of type Dict
					resultItem.Skill_Name = reader.GetDictionary(23);
					resultItem.Skill_Name.SourceTable = "cmn_str_skills";
					loader.Append(resultItem.Skill_Name);
					//24:Parameter PPS_TSK_Task_TemplateID of type Guid
					resultItem.PPS_TSK_Task_TemplateID = reader.GetGuid(24);
					//25:Parameter AppointmentType_Name of type Dict
					resultItem.AppointmentType_Name = reader.GetDictionary(25);
					resultItem.AppointmentType_Name.SourceTable = "pps_tsk_task_templates";
					loader.Append(resultItem.AppointmentType_Name);
					//26:Parameter CMN_STR_ProfessionID of type Guid
					resultItem.CMN_STR_ProfessionID = reader.GetGuid(26);
					//27:Parameter IsPrimary of type bool
					resultItem.IsPrimary = reader.GetBoolean(27);
					//28:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(28);
					//29:Parameter Type of type String
					resultItem.Type = reader.GetString(29);
					//30:Parameter Content of type String
					resultItem.Content = reader.GetString(30);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctors_and_Staff_allData_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DO_GDaSaDfT_1613_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DO_GDaSaDfT_1613_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DO_GDaSaDfT_1613_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DO_GDaSaDfT_1613_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DO_GDaSaDfT_1613_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DO_GDaSaDfT_1613_Array functionReturn = new FR_L5DO_GDaSaDfT_1613_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctors_and_Staff_allData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DO_GDaSaDfT_1613_raw 
	{
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public String DisplayName; 
		public String FirstName; 
		public String LastName; 
		public int Gender; 
		public Boolean IsTreatingChildren; 
		public String PrimaryEmail; 
		public String Initials; 
		public String Title; 
		public String DoctorIDNumber; 
		public String Staff_Number; 
		public bool hasOpeningTime; 
		public Dict ProfessionName; 
		public Guid DisplayImage_RefID; 
		public Guid CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID; 
		public Guid Account_RefID; 
		public Guid CMN_STR_OfficeID; 
		public Dict Office_Name; 
		public String Office_InternalNumber; 
		public Dict Name; 
		public Guid CMN_LanguageID; 
		public Guid CMN_STR_SkillID; 
		public Dict Skill_Name; 
		public Guid PPS_TSK_Task_TemplateID; 
		public Dict AppointmentType_Name; 
		public Guid CMN_STR_ProfessionID; 
		public bool IsPrimary; 
		public Guid CMN_PER_CommunicationContact_TypeID; 
		public String Type; 
		public String Content; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DO_GDaSaDfT_1613[] Convert(List<L5DO_GDaSaDfT_1613_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DO_GDaSaDfT_1613 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5DO_GDaSaDfT_1613 by new 
	{ 
		el_L5DO_GDaSaDfT_1613.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5DO_GDaSaDfT_1613
	select new L5DO_GDaSaDfT_1613
	{     
		CMN_BPT_BusinessParticipantID = gfunct_L5DO_GDaSaDfT_1613.Key.CMN_BPT_BusinessParticipantID ,
		CMN_BPT_EMP_EmployeeID = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().CMN_BPT_EMP_EmployeeID ,
		DisplayName = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().DisplayName ,
		FirstName = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().FirstName ,
		LastName = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().LastName ,
		Gender = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().Gender ,
		IsTreatingChildren = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().IsTreatingChildren ,
		PrimaryEmail = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().PrimaryEmail ,
		Initials = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().Initials ,
		Title = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().Title ,
		DoctorIDNumber = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().DoctorIDNumber ,
		Staff_Number = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().Staff_Number ,
		hasOpeningTime = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().hasOpeningTime ,
		ProfessionName = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().ProfessionName ,
		DisplayImage_RefID = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().DisplayImage_RefID ,
		CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID ,
		Account_RefID = gfunct_L5DO_GDaSaDfT_1613.FirstOrDefault().Account_RefID ,

		Offices = 
		(
			from el_Offices in gfunct_L5DO_GDaSaDfT_1613.Where(element => !EqualsDefaultValue(element.CMN_STR_OfficeID)).ToArray()
			group el_Offices by new 
			{ 
				el_Offices.CMN_STR_OfficeID,

			}
			into gfunct_Offices
			select new L5DO_GDaSaDfT_1613_OganisationalUnits
			{     
				CMN_STR_OfficeID = gfunct_Offices.Key.CMN_STR_OfficeID ,
				Office_Name = gfunct_Offices.FirstOrDefault().Office_Name ,
				Office_InternalNumber = gfunct_Offices.FirstOrDefault().Office_InternalNumber ,

			}
		).ToArray(),
		Languages = 
		(
			from el_Languages in gfunct_L5DO_GDaSaDfT_1613.Where(element => !EqualsDefaultValue(element.CMN_LanguageID)).ToArray()
			group el_Languages by new 
			{ 
				el_Languages.CMN_LanguageID,

			}
			into gfunct_Languages
			select new L5DO_GDaSaDfT_1613_Languages
			{     
				Name = gfunct_Languages.FirstOrDefault().Name ,
				CMN_LanguageID = gfunct_Languages.Key.CMN_LanguageID ,

			}
		).ToArray(),
		Skills = 
		(
			from el_Skills in gfunct_L5DO_GDaSaDfT_1613.Where(element => !EqualsDefaultValue(element.CMN_STR_SkillID)).ToArray()
			group el_Skills by new 
			{ 
				el_Skills.CMN_STR_SkillID,

			}
			into gfunct_Skills
			select new L5DO_GDaSaDfT_1613_Skills
			{     
				CMN_STR_SkillID = gfunct_Skills.Key.CMN_STR_SkillID ,
				Skill_Name = gfunct_Skills.FirstOrDefault().Skill_Name ,

			}
		).ToArray(),
		AppointmentType = 
		(
			from el_AppointmentType in gfunct_L5DO_GDaSaDfT_1613.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_TemplateID)).ToArray()
			group el_AppointmentType by new 
			{ 
				el_AppointmentType.PPS_TSK_Task_TemplateID,

			}
			into gfunct_AppointmentType
			select new L5DO_GDaSaDfT_1613_Appointmenttype
			{     
				PPS_TSK_Task_TemplateID = gfunct_AppointmentType.Key.PPS_TSK_Task_TemplateID ,
				AppointmentType_Name = gfunct_AppointmentType.FirstOrDefault().AppointmentType_Name ,

			}
		).ToArray(),
		StaffProfesions = 
		(
			from el_StaffProfesions in gfunct_L5DO_GDaSaDfT_1613.Where(element => !EqualsDefaultValue(element.CMN_STR_ProfessionID)).ToArray()
			group el_StaffProfesions by new 
			{ 
				el_StaffProfesions.CMN_STR_ProfessionID,

			}
			into gfunct_StaffProfesions
			select new L5DO_GDaSaDfT_1613_StaffProfesions
			{     
				CMN_STR_ProfessionID = gfunct_StaffProfesions.Key.CMN_STR_ProfessionID ,
				IsPrimary = gfunct_StaffProfesions.FirstOrDefault().IsPrimary ,

			}
		).ToArray(),
		ContactTypes = 
		(
			from el_ContactTypes in gfunct_L5DO_GDaSaDfT_1613.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContact_TypeID)).ToArray()
			group el_ContactTypes by new 
			{ 
				el_ContactTypes.CMN_PER_CommunicationContact_TypeID,

			}
			into gfunct_ContactTypes
			select new L5DO_GDaSaDfT_1613_ContactTypeContent
			{     
				CMN_PER_CommunicationContact_TypeID = gfunct_ContactTypes.Key.CMN_PER_CommunicationContact_TypeID ,
				Type = gfunct_ContactTypes.FirstOrDefault().Type ,
				Content = gfunct_ContactTypes.FirstOrDefault().Content ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DO_GDaSaDfT_1613_Array : FR_Base
	{
		public L5DO_GDaSaDfT_1613[] Result	{ get; set; } 
		public FR_L5DO_GDaSaDfT_1613_Array() : base() {}

		public FR_L5DO_GDaSaDfT_1613_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5DO_GDaSaDfT_1613 for attribute L5DO_GDaSaDfT_1613
		[DataContract]
		public class L5DO_GDaSaDfT_1613 
		{
			[DataMember]
			public L5DO_GDaSaDfT_1613_OganisationalUnits[] Offices { get; set; }
			[DataMember]
			public L5DO_GDaSaDfT_1613_Languages[] Languages { get; set; }
			[DataMember]
			public L5DO_GDaSaDfT_1613_Skills[] Skills { get; set; }
			[DataMember]
			public L5DO_GDaSaDfT_1613_Appointmenttype[] AppointmentType { get; set; }
			[DataMember]
			public L5DO_GDaSaDfT_1613_StaffProfesions[] StaffProfesions { get; set; }
			[DataMember]
			public L5DO_GDaSaDfT_1613_ContactTypeContent[] ContactTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_EMP_EmployeeID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public int Gender { get; set; } 
			[DataMember]
			public Boolean IsTreatingChildren { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Initials { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String DoctorIDNumber { get; set; } 
			[DataMember]
			public String Staff_Number { get; set; } 
			[DataMember]
			public bool hasOpeningTime { get; set; } 
			[DataMember]
			public Dict ProfessionName { get; set; } 
			[DataMember]
			public Guid DisplayImage_RefID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_ExcludedAvailabilityTypeID { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSaDfT_1613_OganisationalUnits for attribute Offices
		[DataContract]
		public class L5DO_GDaSaDfT_1613_OganisationalUnits 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String Office_InternalNumber { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSaDfT_1613_Languages for attribute Languages
		[DataContract]
		public class L5DO_GDaSaDfT_1613_Languages 
		{
			//Standard type parameters
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public Guid CMN_LanguageID { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSaDfT_1613_Skills for attribute Skills
		[DataContract]
		public class L5DO_GDaSaDfT_1613_Skills 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_SkillID { get; set; } 
			[DataMember]
			public Dict Skill_Name { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSaDfT_1613_Appointmenttype for attribute AppointmentType
		[DataContract]
		public class L5DO_GDaSaDfT_1613_Appointmenttype 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 
			[DataMember]
			public Dict AppointmentType_Name { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSaDfT_1613_StaffProfesions for attribute StaffProfesions
		[DataContract]
		public class L5DO_GDaSaDfT_1613_StaffProfesions 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_ProfessionID { get; set; } 
			[DataMember]
			public bool IsPrimary { get; set; } 

		}
		#endregion
		#region SClass L5DO_GDaSaDfT_1613_ContactTypeContent for attribute ContactTypes
		[DataContract]
		public class L5DO_GDaSaDfT_1613_ContactTypeContent 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public String Content { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5DO_GDaSaDfT_1613_Array cls_Get_Doctors_and_Staff_allData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5DO_GDaSaDfT_1613_Array invocationResult = cls_Get_Doctors_and_Staff_allData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

