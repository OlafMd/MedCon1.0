/* 
 * Generated on 8/26/2013 2:06:44 PM
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
using System.Runtime.Serialization;

namespace CL2_FunctionLevelRight.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AccountPersonalInformations_And_FunctionLevelRights_For_AccountID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AccountPersonalInformations_And_FunctionLevelRights_For_AccountID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2FL_GAPIAFLRFA_1238 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2FL_GAPIAFLRFA_1238();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_FunctionLevelRight.Atomic.Retrieval.SQL.cls_Get_AccountPersonalInformations_And_FunctionLevelRights_For_AccountID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2FL_GAPIAFLRFA_1238_raw> results = new List<L2FL_GAPIAFLRFA_1238_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DefaultLanguage_RefID","Username","BusinessParticipant_RefID","AccountType","USR_AccountID","Tenant_RefID","FunctionLevelRight_AssignmentID","USR_Account_FunctionLevelRightID","FunctionLevelRight_RefID","RightName","FunctionLevelRights_Group_RefID","PersonalInfo_AssignmentID","CMN_PER_PersonInfoID","Salutation_Letter","Salutation_General","Address_RefID","BirthDate","ProfileImage_Document_RefID","Title","PrimaryEmail","LastName","FirstName" });
				while(reader.Read())
				{
					L2FL_GAPIAFLRFA_1238_raw resultItem = new L2FL_GAPIAFLRFA_1238_raw();
					//0:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(0);
					//1:Parameter Username of type String
					resultItem.Username = reader.GetString(1);
					//2:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(2);
					//3:Parameter AccountType of type int
					resultItem.AccountType = reader.GetInteger(3);
					//4:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(4);
					//5:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(5);
					//6:Parameter FunctionLevelRight_AssignmentID of type Guid
					resultItem.FunctionLevelRight_AssignmentID = reader.GetGuid(6);
					//7:Parameter USR_Account_FunctionLevelRightID of type Guid
					resultItem.USR_Account_FunctionLevelRightID = reader.GetGuid(7);
					//8:Parameter FunctionLevelRight_RefID of type Guid
					resultItem.FunctionLevelRight_RefID = reader.GetGuid(8);
					//9:Parameter RightName of type String
					resultItem.RightName = reader.GetString(9);
					//10:Parameter FunctionLevelRights_Group_RefID of type Guid
					resultItem.FunctionLevelRights_Group_RefID = reader.GetGuid(10);
					//11:Parameter PersonalInfo_AssignmentID of type Guid
					resultItem.PersonalInfo_AssignmentID = reader.GetGuid(11);
					//12:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(12);
					//13:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(13);
					//14:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(14);
					//15:Parameter Address_RefID of type Guid
					resultItem.Address_RefID = reader.GetGuid(15);
					//16:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(16);
					//17:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(17);
					//18:Parameter Title of type String
					resultItem.Title = reader.GetString(18);
					//19:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(19);
					//20:Parameter LastName of type String
					resultItem.LastName = reader.GetString(20);
					//21:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AccountPersonalInformations_And_FunctionLevelRights_For_AccountID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L2FL_GAPIAFLRFA_1238_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L2FL_GAPIAFLRFA_1238 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2FL_GAPIAFLRFA_1238 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2FL_GAPIAFLRFA_1238 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2FL_GAPIAFLRFA_1238 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2FL_GAPIAFLRFA_1238 functionReturn = new FR_L2FL_GAPIAFLRFA_1238();
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

				throw new Exception("Exception occured in method cls_Get_AccountPersonalInformations_And_FunctionLevelRights_For_AccountID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L2FL_GAPIAFLRFA_1238_raw 
	{
		public Guid DefaultLanguage_RefID; 
		public String Username; 
		public Guid BusinessParticipant_RefID; 
		public int AccountType; 
		public Guid USR_AccountID; 
		public Guid Tenant_RefID; 
		public Guid FunctionLevelRight_AssignmentID; 
		public Guid USR_Account_FunctionLevelRightID; 
		public Guid FunctionLevelRight_RefID; 
		public String RightName; 
		public Guid FunctionLevelRights_Group_RefID; 
		public Guid PersonalInfo_AssignmentID; 
		public Guid CMN_PER_PersonInfoID; 
		public String Salutation_Letter; 
		public String Salutation_General; 
		public Guid Address_RefID; 
		public DateTime BirthDate; 
		public Guid ProfileImage_Document_RefID; 
		public String Title; 
		public String PrimaryEmail; 
		public String LastName; 
		public String FirstName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L2FL_GAPIAFLRFA_1238[] Convert(List<L2FL_GAPIAFLRFA_1238_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L2FL_GAPIAFLRFA_1238 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.USR_AccountID)).ToArray()
	group el_L2FL_GAPIAFLRFA_1238 by new 
	{ 
		el_L2FL_GAPIAFLRFA_1238.USR_AccountID,

	}
	into gfunct_L2FL_GAPIAFLRFA_1238
	select new L2FL_GAPIAFLRFA_1238
	{     
		DefaultLanguage_RefID = gfunct_L2FL_GAPIAFLRFA_1238.FirstOrDefault().DefaultLanguage_RefID ,
		Username = gfunct_L2FL_GAPIAFLRFA_1238.FirstOrDefault().Username ,
		BusinessParticipant_RefID = gfunct_L2FL_GAPIAFLRFA_1238.FirstOrDefault().BusinessParticipant_RefID ,
		AccountType = gfunct_L2FL_GAPIAFLRFA_1238.FirstOrDefault().AccountType ,
		USR_AccountID = gfunct_L2FL_GAPIAFLRFA_1238.Key.USR_AccountID ,
		Tenant_RefID = gfunct_L2FL_GAPIAFLRFA_1238.FirstOrDefault().Tenant_RefID ,

		USR_Account_FunctionLevelRights = 
		(
			from el_USR_Account_FunctionLevelRights in gfunct_L2FL_GAPIAFLRFA_1238.Where(element => !EqualsDefaultValue(element.USR_Account_FunctionLevelRightID)).ToArray()
			group el_USR_Account_FunctionLevelRights by new 
			{ 
				el_USR_Account_FunctionLevelRights.USR_Account_FunctionLevelRightID,

			}
			into gfunct_USR_Account_FunctionLevelRights
			select new L2FL_GAPIAFLRFA_1238_USR_Account_FunctionLevelRights
			{     
				FunctionLevelRight_AssignmentID = gfunct_USR_Account_FunctionLevelRights.FirstOrDefault().FunctionLevelRight_AssignmentID ,
				USR_Account_FunctionLevelRightID = gfunct_USR_Account_FunctionLevelRights.Key.USR_Account_FunctionLevelRightID ,
				FunctionLevelRight_RefID = gfunct_USR_Account_FunctionLevelRights.FirstOrDefault().FunctionLevelRight_RefID ,
				RightName = gfunct_USR_Account_FunctionLevelRights.FirstOrDefault().RightName ,
				FunctionLevelRights_Group_RefID = gfunct_USR_Account_FunctionLevelRights.FirstOrDefault().FunctionLevelRights_Group_RefID ,

			}
		).ToArray(),
		CMN_PER_PersonInfo_2_Account = 
		(
			from el_CMN_PER_PersonInfo_2_Account in gfunct_L2FL_GAPIAFLRFA_1238.Where(element => !EqualsDefaultValue(element.CMN_PER_PersonInfoID)).ToArray()
			group el_CMN_PER_PersonInfo_2_Account by new 
			{ 
				el_CMN_PER_PersonInfo_2_Account.CMN_PER_PersonInfoID,

			}
			into gfunct_CMN_PER_PersonInfo_2_Account
			select new L2FL_GAPIAFLRFA_1238_CMN_PER_PersonInfo_2_Account
			{     
				PersonalInfo_AssignmentID = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().PersonalInfo_AssignmentID ,
				CMN_PER_PersonInfoID = gfunct_CMN_PER_PersonInfo_2_Account.Key.CMN_PER_PersonInfoID ,
				Salutation_Letter = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().Salutation_Letter ,
				Salutation_General = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().Salutation_General ,
				Address_RefID = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().Address_RefID ,
				BirthDate = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().BirthDate ,
				ProfileImage_Document_RefID = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().ProfileImage_Document_RefID ,
				Title = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().Title ,
				PrimaryEmail = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().PrimaryEmail ,
				LastName = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().LastName ,
				FirstName = gfunct_CMN_PER_PersonInfo_2_Account.FirstOrDefault().FirstName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L2FL_GAPIAFLRFA_1238 : FR_Base
	{
		public L2FL_GAPIAFLRFA_1238 Result	{ get; set; }

		public FR_L2FL_GAPIAFLRFA_1238() : base() {}

		public FR_L2FL_GAPIAFLRFA_1238(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2FL_GAPIAFLRFA_1238 for attribute L2FL_GAPIAFLRFA_1238
		[DataContract]
		public class L2FL_GAPIAFLRFA_1238 
		{
			[DataMember]
			public L2FL_GAPIAFLRFA_1238_USR_Account_FunctionLevelRights[] USR_Account_FunctionLevelRights { get; set; }
			[DataMember]
			public L2FL_GAPIAFLRFA_1238_CMN_PER_PersonInfo_2_Account[] CMN_PER_PersonInfo_2_Account { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public Guid BusinessParticipant_RefID { get; set; } 
			[DataMember]
			public int AccountType { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion
		#region SClass L2FL_GAPIAFLRFA_1238_USR_Account_FunctionLevelRights for attribute USR_Account_FunctionLevelRights
		[DataContract]
		public class L2FL_GAPIAFLRFA_1238_USR_Account_FunctionLevelRights 
		{
			//Standard type parameters
			[DataMember]
			public Guid FunctionLevelRight_AssignmentID { get; set; } 
			[DataMember]
			public Guid USR_Account_FunctionLevelRightID { get; set; } 
			[DataMember]
			public Guid FunctionLevelRight_RefID { get; set; } 
			[DataMember]
			public String RightName { get; set; } 
			[DataMember]
			public Guid FunctionLevelRights_Group_RefID { get; set; } 

		}
		#endregion
		#region SClass L2FL_GAPIAFLRFA_1238_CMN_PER_PersonInfo_2_Account for attribute CMN_PER_PersonInfo_2_Account
		[DataContract]
		public class L2FL_GAPIAFLRFA_1238_CMN_PER_PersonInfo_2_Account 
		{
			//Standard type parameters
			[DataMember]
			public Guid PersonalInfo_AssignmentID { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public Guid Address_RefID { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid ProfileImage_Document_RefID { get; set; } 
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2FL_GAPIAFLRFA_1238 cls_Get_AccountPersonalInformations_And_FunctionLevelRights_For_AccountID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2FL_GAPIAFLRFA_1238 invocationResult = cls_Get_AccountPersonalInformations_And_FunctionLevelRights_For_AccountID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
