/* 
 * Generated on 8/26/2013 12:33:31 PM
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_EmployeePhoneNumbers.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EmployeePhoneNumbers
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GEPN_1235 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GEPN_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EM_GEPN_1235();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Employees.Atomic.Retrieval.SQL.cls_Get_EmployeePhoneNumbers.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"EmployeeID", Parameter.EmployeeID);


			List<L5EM_GEPN_1235_raw> results = new List<L5EM_GEPN_1235_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmployeeID","FirstName","LastName","PrimaryEmail","Title","BirthDate","Address_RefID","ProfileImage_Document_RefID","Creation_Timestamp","CMN_BPT_BusinessParticipantID","CMN_PER_PersonInfoID","CMN_PER_CommunicationContactID","CMN_PER_CommunicationContact_TypeID","Content","Type" });
				while(reader.Read())
				{
					L5EM_GEPN_1235_raw resultItem = new L5EM_GEPN_1235_raw();
					//0:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(3);
					//4:Parameter Title of type String
					resultItem.Title = reader.GetString(4);
					//5:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(5);
					//6:Parameter Address_RefID of type Guid
					resultItem.Address_RefID = reader.GetGuid(6);
					//7:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(7);
					//8:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(8);
					//9:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(9);
					//10:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(10);
					//11:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(11);
					//12:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(12);
					//13:Parameter Content of type String
					resultItem.Content = reader.GetString(13);
					//14:Parameter Type of type String
					resultItem.Type = reader.GetString(14);

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

			returnStatus.Result = L5EM_GEPN_1235_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EM_GEPN_1235 Invoke(string ConnectionString,P_L5EM_GEPN_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GEPN_1235 Invoke(DbConnection Connection,P_L5EM_GEPN_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GEPN_1235 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GEPN_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GEPN_1235 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GEPN_1235 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GEPN_1235 functionReturn = new FR_L5EM_GEPN_1235();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5EM_GEPN_1235_raw 
	{
		public Guid CMN_BPT_EMP_EmployeeID; 
		public String FirstName; 
		public String LastName; 
		public String PrimaryEmail; 
		public String Title; 
		public DateTime BirthDate; 
		public Guid Address_RefID; 
		public Guid ProfileImage_Document_RefID; 
		public DateTime Creation_Timestamp; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid CMN_PER_PersonInfoID; 
		public Guid CMN_PER_CommunicationContactID; 
		public Guid CMN_PER_CommunicationContact_TypeID; 
		public String Content; 
		public String Type; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5EM_GEPN_1235[] Convert(List<L5EM_GEPN_1235_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5EM_GEPN_1235 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_EmployeeID)).ToArray()
	group el_L5EM_GEPN_1235 by new 
	{ 
		el_L5EM_GEPN_1235.CMN_BPT_EMP_EmployeeID,

	}
	into gfunct_L5EM_GEPN_1235
	select new L5EM_GEPN_1235
	{     
		CMN_BPT_EMP_EmployeeID = gfunct_L5EM_GEPN_1235.Key.CMN_BPT_EMP_EmployeeID ,
		FirstName = gfunct_L5EM_GEPN_1235.FirstOrDefault().FirstName ,
		LastName = gfunct_L5EM_GEPN_1235.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L5EM_GEPN_1235.FirstOrDefault().PrimaryEmail ,
		Title = gfunct_L5EM_GEPN_1235.FirstOrDefault().Title ,
		BirthDate = gfunct_L5EM_GEPN_1235.FirstOrDefault().BirthDate ,
		Address_RefID = gfunct_L5EM_GEPN_1235.FirstOrDefault().Address_RefID ,
		ProfileImage_Document_RefID = gfunct_L5EM_GEPN_1235.FirstOrDefault().ProfileImage_Document_RefID ,
		Creation_Timestamp = gfunct_L5EM_GEPN_1235.FirstOrDefault().Creation_Timestamp ,
		CMN_BPT_BusinessParticipantID = gfunct_L5EM_GEPN_1235.FirstOrDefault().CMN_BPT_BusinessParticipantID ,
		CMN_PER_PersonInfoID = gfunct_L5EM_GEPN_1235.FirstOrDefault().CMN_PER_PersonInfoID ,

		Contacts = 
		(
			from el_Contacts in gfunct_L5EM_GEPN_1235.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContactID)).ToArray()
			group el_Contacts by new 
			{ 
				el_Contacts.CMN_PER_CommunicationContactID,

			}
			into gfunct_Contacts
			select new L5EM_GEPN_1235_Contacts
			{     
				CMN_PER_CommunicationContactID = gfunct_Contacts.Key.CMN_PER_CommunicationContactID ,
				CMN_PER_CommunicationContact_TypeID = gfunct_Contacts.FirstOrDefault().CMN_PER_CommunicationContact_TypeID ,
				Content = gfunct_Contacts.FirstOrDefault().Content ,
				Type = gfunct_Contacts.FirstOrDefault().Type ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GEPN_1235 : FR_Base
	{
		public L5EM_GEPN_1235 Result	{ get; set; }

		public FR_L5EM_GEPN_1235() : base() {}

		public FR_L5EM_GEPN_1235(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GEPN_1235 cls_Get_EmployeePhoneNumbers(P_L5EM_GEPN_1235 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5EM_GEPN_1235 result = cls_Get_EmployeePhoneNumbers.Invoke(connectionString,P_L5EM_GEPN_1235 Parameter,securityTicket);
	 return result;
}
*/