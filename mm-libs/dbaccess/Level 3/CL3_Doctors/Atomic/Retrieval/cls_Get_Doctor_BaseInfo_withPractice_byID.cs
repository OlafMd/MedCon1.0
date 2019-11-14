/* 
 * Generated on 10/28/2013 10:14:41 AM
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
    /// var result = cls_Get_Doctor_BaseInfo_withPractice_byID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_BaseInfo_withPractice_byID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MD_GDBIwPfID_1208 Execute(DbConnection Connection,DbTransaction Transaction,P_L3MD_GDBIwPfID_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3MD_GDBIwPfID_1208();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Doctors.Atomic.Retrieval.SQL.cls_Get_Doctor_BaseInfo_withPractice_byID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);



			List<L3MD_GDBIwPfID_1208_raw> results = new List<L3MD_GDBIwPfID_1208_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Doctor_CMN_BPT_BusinessParticipantID","HEC_DoctorID","LANR","FirstName","LastName","Title","LoginEmail","Account_RefID","Salutation_General","Salutation_Letter","AccountHolder","AccountNumber","BankName","BICCode","IBAN","BLZ","PracticeName","PracticeID","CMN_BPT_BusinessParticipantID","AssociatedParticipant_FunctionName","Creation_Timestamp","Content","Contact_Type" });
				while(reader.Read())
				{
					L3MD_GDBIwPfID_1208_raw resultItem = new L3MD_GDBIwPfID_1208_raw();
					//0:Parameter Doctor_CMN_BPT_BusinessParticipantID of type Guid
					resultItem.Doctor_CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(1);
					//2:Parameter LANR of type String
					resultItem.LANR = reader.GetString(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter LastName of type String
					resultItem.LastName = reader.GetString(4);
					//5:Parameter Title of type String
					resultItem.Title = reader.GetString(5);
					//6:Parameter LoginEmail of type String
					resultItem.LoginEmail = reader.GetString(6);
					//7:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(7);
					//8:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(8);
					//9:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(9);
					//10:Parameter AccountHolder of type String
					resultItem.AccountHolder = reader.GetString(10);
					//11:Parameter AccountNumber of type String
					resultItem.AccountNumber = reader.GetString(11);
					//12:Parameter BankName of type String
					resultItem.BankName = reader.GetString(12);
					//13:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(13);
					//14:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(14);
					//15:Parameter BLZ of type String
					resultItem.BLZ = reader.GetString(15);
					//16:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(16);
					//17:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(17);
					//18:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(18);
					//19:Parameter AssociatedParticipant_FunctionName of type String
					resultItem.AssociatedParticipant_FunctionName = reader.GetString(19);
					//20:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(20);
					//21:Parameter Content of type String
					resultItem.Content = reader.GetString(21);
					//22:Parameter Contact_Type of type Guid
					resultItem.Contact_Type = reader.GetGuid(22);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_BaseInfo_withPractice_byID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L3MD_GDBIwPfID_1208_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3MD_GDBIwPfID_1208 Invoke(string ConnectionString,P_L3MD_GDBIwPfID_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MD_GDBIwPfID_1208 Invoke(DbConnection Connection,P_L3MD_GDBIwPfID_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MD_GDBIwPfID_1208 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3MD_GDBIwPfID_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MD_GDBIwPfID_1208 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3MD_GDBIwPfID_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MD_GDBIwPfID_1208 functionReturn = new FR_L3MD_GDBIwPfID_1208();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_BaseInfo_withPractice_byID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L3MD_GDBIwPfID_1208_raw 
	{
		public Guid Doctor_CMN_BPT_BusinessParticipantID; 
		public Guid HEC_DoctorID; 
		public String LANR; 
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public String LoginEmail; 
		public Guid Account_RefID; 
		public String Salutation_General; 
		public String Salutation_Letter; 
		public String AccountHolder; 
		public String AccountNumber; 
		public String BankName; 
		public String BICCode; 
		public String IBAN; 
		public String BLZ; 
		public String PracticeName; 
		public Guid PracticeID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String AssociatedParticipant_FunctionName; 
		public DateTime Creation_Timestamp; 
		public String Content; 
		public Guid Contact_Type; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L3MD_GDBIwPfID_1208[] Convert(List<L3MD_GDBIwPfID_1208_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L3MD_GDBIwPfID_1208 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DoctorID)).ToArray()
	group el_L3MD_GDBIwPfID_1208 by new 
	{ 
		el_L3MD_GDBIwPfID_1208.HEC_DoctorID,

	}
	into gfunct_L3MD_GDBIwPfID_1208
	select new L3MD_GDBIwPfID_1208
	{     
		Doctor_CMN_BPT_BusinessParticipantID = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().Doctor_CMN_BPT_BusinessParticipantID ,
		HEC_DoctorID = gfunct_L3MD_GDBIwPfID_1208.Key.HEC_DoctorID ,
		LANR = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().LANR ,
		FirstName = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().FirstName ,
		LastName = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().LastName ,
		Title = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().Title ,
		LoginEmail = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().LoginEmail ,
		Account_RefID = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().Account_RefID ,
		Salutation_General = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().Salutation_General ,
		Salutation_Letter = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().Salutation_Letter ,
		AccountHolder = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().AccountHolder ,
		AccountNumber = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().AccountNumber ,
		BankName = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().BankName ,
		BICCode = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().BICCode ,
		IBAN = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().IBAN ,
		BLZ = gfunct_L3MD_GDBIwPfID_1208.FirstOrDefault().BLZ ,

		AllPractices = 
		(
			from el_AllPractices in gfunct_L3MD_GDBIwPfID_1208.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
			group el_AllPractices by new 
			{ 
				el_AllPractices.CMN_BPT_BusinessParticipantID,

			}
			into gfunct_AllPractices
			select new L3MD_GDBIwPfID_1208_Practices
			{     
				PracticeName = gfunct_AllPractices.FirstOrDefault().PracticeName ,
				PracticeID = gfunct_AllPractices.FirstOrDefault().PracticeID ,
				CMN_BPT_BusinessParticipantID = gfunct_AllPractices.Key.CMN_BPT_BusinessParticipantID ,
				AssociatedParticipant_FunctionName = gfunct_AllPractices.FirstOrDefault().AssociatedParticipant_FunctionName ,
				Creation_Timestamp = gfunct_AllPractices.FirstOrDefault().Creation_Timestamp ,

			}
		).ToArray(),
		ContactTypes = 
		(
			from el_ContactTypes in gfunct_L3MD_GDBIwPfID_1208.Where(element => !EqualsDefaultValue(element.Contact_Type)).ToArray()
			group el_ContactTypes by new 
			{ 
				el_ContactTypes.Contact_Type,

			}
			into gfunct_ContactTypes
			select new L3MD_GDBIwPfID_1208_ContactTypes
			{     
				Content = gfunct_ContactTypes.FirstOrDefault().Content ,
				Contact_Type = gfunct_ContactTypes.Key.Contact_Type ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L3MD_GDBIwPfID_1208 : FR_Base
	{
		public L3MD_GDBIwPfID_1208 Result	{ get; set; }

		public FR_L3MD_GDBIwPfID_1208() : base() {}

		public FR_L3MD_GDBIwPfID_1208(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3MD_GDBIwPfID_1208 for attribute P_L3MD_GDBIwPfID_1208
		[DataContract]
		public class P_L3MD_GDBIwPfID_1208 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass L3MD_GDBIwPfID_1208 for attribute L3MD_GDBIwPfID_1208
		[DataContract]
		public class L3MD_GDBIwPfID_1208 
		{
			[DataMember]
			public L3MD_GDBIwPfID_1208_Practices[] AllPractices { get; set; }
			[DataMember]
			public L3MD_GDBIwPfID_1208_ContactTypes[] ContactTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid Doctor_CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public String LANR { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String LoginEmail { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String AccountHolder { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BLZ { get; set; } 

		}
		#endregion
		#region SClass L3MD_GDBIwPfID_1208_Practices for attribute AllPractices
		[DataContract]
		public class L3MD_GDBIwPfID_1208_Practices 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String AssociatedParticipant_FunctionName { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 

		}
		#endregion
		#region SClass L3MD_GDBIwPfID_1208_ContactTypes for attribute ContactTypes
		[DataContract]
		public class L3MD_GDBIwPfID_1208_ContactTypes 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid Contact_Type { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MD_GDBIwPfID_1208 cls_Get_Doctor_BaseInfo_withPractice_byID(,P_L3MD_GDBIwPfID_1208 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3MD_GDBIwPfID_1208 invocationResult = cls_Get_Doctor_BaseInfo_withPractice_byID.Invoke(connectionString,P_L3MD_GDBIwPfID_1208 Parameter,securityTicket);
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
var parameter = new CL3_Doctors.Atomic.Retrieval.P_L3MD_GDBIwPfID_1208();
parameter.DoctorID = ...;

*/
