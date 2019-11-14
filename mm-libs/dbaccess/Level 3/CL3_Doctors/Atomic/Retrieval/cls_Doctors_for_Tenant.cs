/* 
 * Generated on 3/4/2015 4:03:34 PM
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

namespace CL3_Doctors.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Doctors_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Doctors_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_DfT_1425_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_DfT_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_DfT_1425_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Doctors.Atomic.Retrieval.SQL.cls_Doctors_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L3_DfT_1425> results = new List<L3_DfT_1425>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_PER_PersonInfoID","FirstName","LastName","PrimaryEmail","BirthDate","Gender","DefaultLanguage_RefID","HEC_DoctorID","Tenant_RefID","IsDeleted","Creation_Timestamp","Account_RefID","Modification_TimestampDoctors","Modification_TimestampBpart","Modification_TimestampPersonInfo","AgeCalculation_YearOfBirth","Initials","Office_Name_DictID","MedicalPracticeType_Name_DictID","Default_PhoneNumber","Street_Name","Street_Number","City_Name","City_PostalCode","Country_Name","Modification_TimestampAdress","Title","Default_Email","Default_Website","DoctorIDNumber" });
				while(reader.Read())
				{
					L3_DfT_1425 resultItem = new L3_DfT_1425();
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
					//5:Parameter Gender of type String
					resultItem.Gender = reader.GetString(5);
					//6:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(6);
					//7:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(7);
					//8:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(8);
					//9:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(9);
					//10:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(10);
					//11:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(11);
					//12:Parameter Modification_TimestampDoctors of type DateTime
					resultItem.Modification_TimestampDoctors = reader.GetDate(12);
					//13:Parameter Modification_TimestampBpart of type DateTime
					resultItem.Modification_TimestampBpart = reader.GetDate(13);
					//14:Parameter Modification_TimestampPersonInfo of type DateTime
					resultItem.Modification_TimestampPersonInfo = reader.GetDate(14);
					//15:Parameter AgeCalculation_YearOfBirth of type int
					resultItem.AgeCalculation_YearOfBirth = reader.GetInteger(15);
					//16:Parameter Initials of type String
					resultItem.Initials = reader.GetString(16);
					//17:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(17);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//18:Parameter MedicalPracticeType_Name of type Dict
					resultItem.MedicalPracticeType_Name = reader.GetDictionary(18);
					resultItem.MedicalPracticeType_Name.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name);
					//19:Parameter Default_PhoneNumber of type String
					resultItem.Default_PhoneNumber = reader.GetString(19);
					//20:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(20);
					//21:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(21);
					//22:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(22);
					//23:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(23);
					//24:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(24);
					//25:Parameter Modification_TimestampAdress of type DateTime
					resultItem.Modification_TimestampAdress = reader.GetDate(25);
					//26:Parameter Title of type String
					resultItem.Title = reader.GetString(26);
					//27:Parameter Default_Email of type String
					resultItem.Default_Email = reader.GetString(27);
					//28:Parameter Default_Website of type String
					resultItem.Default_Website = reader.GetString(28);
					//29:Parameter DoctorIDNumber of type String
					resultItem.DoctorIDNumber = reader.GetString(29);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Doctors_for_Tenant",ex);
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
		public static FR_L3_DfT_1425_Array Invoke(string ConnectionString,P_L3_DfT_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_DfT_1425_Array Invoke(DbConnection Connection,P_L3_DfT_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_DfT_1425_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_DfT_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_DfT_1425_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_DfT_1425 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_DfT_1425_Array functionReturn = new FR_L3_DfT_1425_Array();
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

				throw new Exception("Exception occured in method cls_Doctors_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_DfT_1425_Array : FR_Base
	{
		public L3_DfT_1425[] Result	{ get; set; } 
		public FR_L3_DfT_1425_Array() : base() {}

		public FR_L3_DfT_1425_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_DfT_1425 for attribute P_L3_DfT_1425
		[DataContract]
		public class P_L3_DfT_1425 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L3_DfT_1425 for attribute L3_DfT_1425
		[DataContract]
		public class L3_DfT_1425 
		{
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
			public String Gender { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampDoctors { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampBpart { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampPersonInfo { get; set; } 
			[DataMember]
			public int AgeCalculation_YearOfBirth { get; set; } 
			[DataMember]
			public String Initials { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public Dict MedicalPracticeType_Name { get; set; } 
			[DataMember]
			public String Default_PhoneNumber { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Country_Name { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampAdress { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String Default_Email { get; set; } 
			[DataMember]
			public String Default_Website { get; set; } 
			[DataMember]
			public String DoctorIDNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_DfT_1425_Array cls_Doctors_for_Tenant(,P_L3_DfT_1425 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_DfT_1425_Array invocationResult = cls_Doctors_for_Tenant.Invoke(connectionString,P_L3_DfT_1425 Parameter,securityTicket);
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
var parameter = new CL3_Doctors.Atomic.Retrieval.P_L3_DfT_1425();
parameter.Tenant = ...;

*/
