/* 
 * Generated on 9/10/2013 1:47:07 PM
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

namespace CL3_MedicalPractices.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Practice_BaseInfo_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Practice_BaseInfo_For_Tenant
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L3MP_GPBIfT_1706_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3MP_GPBIfT_1706_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MedicalPractices.Atomic.Retrieval.SQL.cls_Get_Practice_BaseInfo_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L3MP_GPBIfT_1706> results = new List<L3MP_GPBIfT_1706>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Street_Number","Street_Name","CompanyName_Line1","PracticeName","BSNR","Street_Name_Line2","PracticeEmail","Town","ZIP","CMN_UniversalContactDetailID","Contact_EmergencyPhoneNumber","CMN_COM_CompanyInfoID","CMN_BPT_BusinessParticipantID","CompanyType_RefID","AssociatedWith_PhysitianAssociation_RefID","WeeklyOfficeHours_Template_RefID","WeeklySurgeryHours_Template_RefID","HEC_MedicalPractiseID","ContactPerson_RefID","Contact_Website_URL","Region_Name" });
				while(reader.Read())
				{
					L3MP_GPBIfT_1706 resultItem = new L3MP_GPBIfT_1706();
					//0:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(0);
					//1:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(1);
					//2:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(2);
					//3:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(3);
					//4:Parameter BSNR of type String
					resultItem.BSNR = reader.GetString(4);
					//5:Parameter Street_Name_Line2 of type String
					resultItem.Street_Name_Line2 = reader.GetString(5);
					//6:Parameter PracticeEmail of type String
					resultItem.PracticeEmail = reader.GetString(6);
					//7:Parameter Town of type String
					resultItem.Town = reader.GetString(7);
					//8:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(8);
					//9:Parameter CMN_UniversalContactDetailID of type Guid
					resultItem.CMN_UniversalContactDetailID = reader.GetGuid(9);
					//10:Parameter Contact_EmergencyPhoneNumber of type String
					resultItem.Contact_EmergencyPhoneNumber = reader.GetString(10);
					//11:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(11);
					//12:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(12);
					//13:Parameter CompanyType_RefID of type Guid
					resultItem.CompanyType_RefID = reader.GetGuid(13);
					//14:Parameter AssociatedWith_PhysitianAssociation_RefID of type Guid
					resultItem.AssociatedWith_PhysitianAssociation_RefID = reader.GetGuid(14);
					//15:Parameter WeeklyOfficeHours_Template_RefID of type Guid
					resultItem.WeeklyOfficeHours_Template_RefID = reader.GetGuid(15);
					//16:Parameter WeeklySurgeryHours_Template_RefID of type Guid
					resultItem.WeeklySurgeryHours_Template_RefID = reader.GetGuid(16);
					//17:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(17);
					//18:Parameter ContactPerson_RefID of type Guid
					resultItem.ContactPerson_RefID = reader.GetGuid(18);
					//19:Parameter Contact_Website_URL of type String
					resultItem.Contact_Website_URL = reader.GetString(19);
					//20:Parameter Region_Name of type String
					resultItem.Region_Name = reader.GetString(20);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Practice_BaseInfo_For_Tenant",ex);
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
		public static FR_L3MP_GPBIfT_1706_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_GPBIfT_1706_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_GPBIfT_1706_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_GPBIfT_1706_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_GPBIfT_1706_Array functionReturn = new FR_L3MP_GPBIfT_1706_Array();
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

				throw new Exception("Exception occured in method cls_Get_Practice_BaseInfo_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3MP_GPBIfT_1706_Array : FR_Base
	{
		public L3MP_GPBIfT_1706[] Result	{ get; set; } 
		public FR_L3MP_GPBIfT_1706_Array() : base() {}

		public FR_L3MP_GPBIfT_1706_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3MP_GPBIfT_1706 for attribute L3MP_GPBIfT_1706
		[DataContract]
		public class L3MP_GPBIfT_1706 
		{
			//Standard type parameters
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public String BSNR { get; set; } 
			[DataMember]
			public String Street_Name_Line2 { get; set; } 
			[DataMember]
			public String PracticeEmail { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public String Contact_EmergencyPhoneNumber { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CompanyType_RefID { get; set; } 
			[DataMember]
			public Guid AssociatedWith_PhysitianAssociation_RefID { get; set; } 
			[DataMember]
			public Guid WeeklyOfficeHours_Template_RefID { get; set; } 
			[DataMember]
			public Guid WeeklySurgeryHours_Template_RefID { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public Guid ContactPerson_RefID { get; set; } 
			[DataMember]
			public String Contact_Website_URL { get; set; } 
			[DataMember]
			public String Region_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3MP_GPBIfT_1706_Array cls_Get_Practice_BaseInfo_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = VerifySessionToken(sessionToken);
		FR_L3MP_GPBIfT_1706_Array invocationResult = cls_Get_Practice_BaseInfo_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

