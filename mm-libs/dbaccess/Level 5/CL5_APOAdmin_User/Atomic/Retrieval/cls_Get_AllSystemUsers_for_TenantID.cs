/* 
 * Generated on 1/30/2014 3:34:19 PM
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

namespace CL5_APOAdmin_User.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllSystemUsers_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllSystemUsers_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GASUPfToUID_1322_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_GASUPfToUID_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5US_GASUPfToUID_1322_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_User.Atomic.Retrieval.SQL.cls_Get_AllSystemUsers_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ApplicationID", Parameter.ApplicationID);



			List<L5US_GASUPfToUID_1322_raw> results = new List<L5US_GASUPfToUID_1322_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","FirstName","LastName","USR_AccountID","Username","AccountSignInEmailAddress","AccountType","Group_Name_DictID","USR_Account_RefID","USR_GroupID","Street_Name","Street_Number","City_PostalCode","City_Name","PrimaryEmail","CMN_PER_CommunicationContactID","Type","Content","IsDefaultForContactType" });
				while(reader.Read())
				{
					L5US_GASUPfToUID_1322_raw resultItem = new L5US_GASUPfToUID_1322_raw();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(3);
					//4:Parameter Username of type String
					resultItem.Username = reader.GetString(4);
					//5:Parameter AccountSignInEmailAddress of type String
					resultItem.AccountSignInEmailAddress = reader.GetString(5);
					//6:Parameter AccountType of type int
					resultItem.AccountType = reader.GetInteger(6);
					//7:Parameter Group_Name of type Dict
					resultItem.Group_Name = reader.GetDictionary(7);
					resultItem.Group_Name.SourceTable = "usr_groups";
					loader.Append(resultItem.Group_Name);
					//8:Parameter USR_Account_RefID of type Guid
					resultItem.USR_Account_RefID = reader.GetGuid(8);
					//9:Parameter USR_GroupID of type Guid
					resultItem.USR_GroupID = reader.GetGuid(9);
					//10:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(10);
					//11:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(11);
					//12:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(12);
					//13:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(13);
					//14:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(14);
					//15:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(15);
					//16:Parameter Type of type String
					resultItem.Type = reader.GetString(16);
					//17:Parameter Content of type String
					resultItem.Content = reader.GetString(17);
					//18:Parameter IsDefaultForContactType of type Boolean
					resultItem.IsDefaultForContactType = reader.GetBoolean(18);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllSystemUsers_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5US_GASUPfToUID_1322_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5US_GASUPfToUID_1322_Array Invoke(string ConnectionString,P_L5US_GASUPfToUID_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GASUPfToUID_1322_Array Invoke(DbConnection Connection,P_L5US_GASUPfToUID_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GASUPfToUID_1322_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_GASUPfToUID_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GASUPfToUID_1322_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_GASUPfToUID_1322 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GASUPfToUID_1322_Array functionReturn = new FR_L5US_GASUPfToUID_1322_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllSystemUsers_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5US_GASUPfToUID_1322_raw 
	{
		public Guid CMN_BPT_BusinessParticipantID; 
		public String FirstName; 
		public String LastName; 
		public Guid USR_AccountID; 
		public String Username; 
		public String AccountSignInEmailAddress; 
		public int AccountType; 
		public Dict Group_Name; 
		public Guid USR_Account_RefID; 
		public Guid USR_GroupID; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_PostalCode; 
		public String City_Name; 
		public String PrimaryEmail; 
		public Guid CMN_PER_CommunicationContactID; 
		public String Type; 
		public String Content; 
		public Boolean IsDefaultForContactType; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5US_GASUPfToUID_1322[] Convert(List<L5US_GASUPfToUID_1322_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5US_GASUPfToUID_1322 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5US_GASUPfToUID_1322 by new 
	{ 
		el_L5US_GASUPfToUID_1322.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5US_GASUPfToUID_1322
	select new L5US_GASUPfToUID_1322
	{     
		CMN_BPT_BusinessParticipantID = gfunct_L5US_GASUPfToUID_1322.Key.CMN_BPT_BusinessParticipantID ,
		FirstName = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().FirstName ,
		LastName = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().LastName ,
		USR_AccountID = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().USR_AccountID ,
		Username = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().Username ,
		AccountSignInEmailAddress = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().AccountSignInEmailAddress ,
		AccountType = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().AccountType ,
		Group_Name = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().Group_Name ,
		USR_Account_RefID = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().USR_Account_RefID ,
		USR_GroupID = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().USR_GroupID ,
		Street_Name = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().Street_Number ,
		City_PostalCode = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().City_PostalCode ,
		City_Name = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().City_Name ,
		PrimaryEmail = gfunct_L5US_GASUPfToUID_1322.FirstOrDefault().PrimaryEmail ,

		ContactTypes = 
		(
			from el_ContactTypes in gfunct_L5US_GASUPfToUID_1322.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContactID)).ToArray()
			group el_ContactTypes by new 
			{ 
				el_ContactTypes.CMN_PER_CommunicationContactID,

			}
			into gfunct_ContactTypes
			select new L5US_GASUPfToUID_1322a
			{     
				CMN_PER_CommunicationContactID = gfunct_ContactTypes.Key.CMN_PER_CommunicationContactID ,
				Type = gfunct_ContactTypes.FirstOrDefault().Type ,
				Content = gfunct_ContactTypes.FirstOrDefault().Content ,
				IsDefaultForContactType = gfunct_ContactTypes.FirstOrDefault().IsDefaultForContactType ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GASUPfToUID_1322_Array : FR_Base
	{
		public L5US_GASUPfToUID_1322[] Result	{ get; set; } 
		public FR_L5US_GASUPfToUID_1322_Array() : base() {}

		public FR_L5US_GASUPfToUID_1322_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5US_GASUPfToUID_1322 for attribute P_L5US_GASUPfToUID_1322
		[DataContract]
		public class P_L5US_GASUPfToUID_1322 
		{
			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion
		#region SClass L5US_GASUPfToUID_1322 for attribute L5US_GASUPfToUID_1322
		[DataContract]
		public class L5US_GASUPfToUID_1322 
		{
			[DataMember]
			public L5US_GASUPfToUID_1322a[] ContactTypes { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public String AccountSignInEmailAddress { get; set; } 
			[DataMember]
			public int AccountType { get; set; } 
			[DataMember]
			public Dict Group_Name { get; set; } 
			[DataMember]
			public Guid USR_Account_RefID { get; set; } 
			[DataMember]
			public Guid USR_GroupID { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 

		}
		#endregion
		#region SClass L5US_GASUPfToUID_1322a for attribute ContactTypes
		[DataContract]
		public class L5US_GASUPfToUID_1322a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Boolean IsDefaultForContactType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GASUPfToUID_1322_Array cls_Get_AllSystemUsers_for_TenantID(,P_L5US_GASUPfToUID_1322 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GASUPfToUID_1322_Array invocationResult = cls_Get_AllSystemUsers_for_TenantID.Invoke(connectionString,P_L5US_GASUPfToUID_1322 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Atomic.Retrieval.P_L5US_GASUPfToUID_1322();
parameter.ApplicationID = ...;

*/
