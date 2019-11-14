/* 
 * Generated on 7/16/2013 11:02:13 AM
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

namespace CL6_BBV_Driver.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Drivers_for_Tennant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Drivers_for_Tennant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DR_RDIaV_1458_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DR_RDIaV_1458_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_BBV_Driver.Atomic.Retrieval.SQL.cls_Get_Drivers_for_Tennant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5DR_RDIaV_1458_raw> results = new List<L5DR_RDIaV_1458_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","AssociatedBusinessParticipant_RefID","AccountCode_Value","CMN_PER_PersonInfoID","FirstName","LastName","PrimaryEmail","Street_Name","Street_Number","City_PostalCode","Province_Name","Salutation_General","City_Name","Contact_Email","CMN_UniversalContactDetailID","CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID","CMN_AddressID","CMN_PER_CommunicationContactID","USR_AccountID","USR_Device_AccountCode_UsageHistoryID","USR_Device_AccountCodeID","CMN_BPT_SupplierID","CMN_PER_CommunicationContact_TypeID","Content" });
				while(reader.Read())
				{
					L5DR_RDIaV_1458_raw resultItem = new L5DR_RDIaV_1458_raw();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter AssociatedBusinessParticipant_RefID of type Guid
					resultItem.AssociatedBusinessParticipant_RefID = reader.GetGuid(1);
					//2:Parameter AccountCode_Value of type String
					resultItem.AccountCode_Value = reader.GetString(2);
					//3:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(3);
					//4:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(4);
					//5:Parameter LastName of type String
					resultItem.LastName = reader.GetString(5);
					//6:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(6);
					//7:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(7);
					//8:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(8);
					//9:Parameter City_PostalCode of type String
					resultItem.City_PostalCode = reader.GetString(9);
					//10:Parameter Province_Name of type String
					resultItem.Province_Name = reader.GetString(10);
					//11:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(11);
					//12:Parameter City_Name of type String
					resultItem.City_Name = reader.GetString(12);
					//13:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(13);
					//14:Parameter CMN_UniversalContactDetailID of type Guid
					resultItem.CMN_UniversalContactDetailID = reader.GetGuid(14);
					//15:Parameter CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = reader.GetGuid(15);
					//16:Parameter CMN_AddressID of type Guid
					resultItem.CMN_AddressID = reader.GetGuid(16);
					//17:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(17);
					//18:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(18);
					//19:Parameter USR_Device_AccountCode_UsageHistoryID of type Guid
					resultItem.USR_Device_AccountCode_UsageHistoryID = reader.GetGuid(19);
					//20:Parameter USR_Device_AccountCodeID of type Guid
					resultItem.USR_Device_AccountCodeID = reader.GetGuid(20);
					//21:Parameter CMN_BPT_SupplierID of type Guid
					resultItem.CMN_BPT_SupplierID = reader.GetGuid(21);
					//22:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(22);
					//23:Parameter Content of type String
					resultItem.Content = reader.GetString(23);

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

			returnStatus.Result = L5DR_RDIaV_1458_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DR_RDIaV_1458_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DR_RDIaV_1458_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DR_RDIaV_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DR_RDIaV_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DR_RDIaV_1458_Array functionReturn = new FR_L5DR_RDIaV_1458_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5DR_RDIaV_1458_raw 
	{
		public Guid CMN_BPT_BusinessParticipantID; 
		public Guid AssociatedBusinessParticipant_RefID; 
		public String AccountCode_Value; 
		public Guid CMN_PER_PersonInfoID; 
		public String FirstName; 
		public String LastName; 
		public String PrimaryEmail; 
		public String Street_Name; 
		public String Street_Number; 
		public String City_PostalCode; 
		public String Province_Name; 
		public String Salutation_General; 
		public String City_Name; 
		public String Contact_Email; 
		public Guid CMN_UniversalContactDetailID; 
		public Guid CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID; 
		public Guid CMN_AddressID; 
		public Guid CMN_PER_CommunicationContactID; 
		public Guid USR_AccountID; 
		public Guid USR_Device_AccountCode_UsageHistoryID; 
		public Guid USR_Device_AccountCodeID; 
		public Guid CMN_BPT_SupplierID; 
		public Guid CMN_PER_CommunicationContact_TypeID; 
		public String Content; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DR_RDIaV_1458[] Convert(List<L5DR_RDIaV_1458_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DR_RDIaV_1458 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
	group el_L5DR_RDIaV_1458 by new 
	{ 
		el_L5DR_RDIaV_1458.CMN_BPT_BusinessParticipantID,

	}
	into gfunct_L5DR_RDIaV_1458
	select new L5DR_RDIaV_1458
	{     
		CMN_BPT_BusinessParticipantID = gfunct_L5DR_RDIaV_1458.Key.CMN_BPT_BusinessParticipantID ,
		AssociatedBusinessParticipant_RefID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().AssociatedBusinessParticipant_RefID ,
		AccountCode_Value = gfunct_L5DR_RDIaV_1458.FirstOrDefault().AccountCode_Value ,
		CMN_PER_PersonInfoID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().CMN_PER_PersonInfoID ,
		FirstName = gfunct_L5DR_RDIaV_1458.FirstOrDefault().FirstName ,
		LastName = gfunct_L5DR_RDIaV_1458.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_L5DR_RDIaV_1458.FirstOrDefault().PrimaryEmail ,
		Street_Name = gfunct_L5DR_RDIaV_1458.FirstOrDefault().Street_Name ,
		Street_Number = gfunct_L5DR_RDIaV_1458.FirstOrDefault().Street_Number ,
		City_PostalCode = gfunct_L5DR_RDIaV_1458.FirstOrDefault().City_PostalCode ,
		Province_Name = gfunct_L5DR_RDIaV_1458.FirstOrDefault().Province_Name ,
		Salutation_General = gfunct_L5DR_RDIaV_1458.FirstOrDefault().Salutation_General ,
		City_Name = gfunct_L5DR_RDIaV_1458.FirstOrDefault().City_Name ,
		Contact_Email = gfunct_L5DR_RDIaV_1458.FirstOrDefault().Contact_Email ,
		CMN_UniversalContactDetailID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().CMN_UniversalContactDetailID ,
		CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID ,
		CMN_AddressID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().CMN_AddressID ,
		CMN_PER_CommunicationContactID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().CMN_PER_CommunicationContactID ,
		USR_AccountID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().USR_AccountID ,
		USR_Device_AccountCode_UsageHistoryID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().USR_Device_AccountCode_UsageHistoryID ,
		USR_Device_AccountCodeID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().USR_Device_AccountCodeID ,
		CMN_BPT_SupplierID = gfunct_L5DR_RDIaV_1458.FirstOrDefault().CMN_BPT_SupplierID ,

		Contacts = 
		(
			from el_Contacts in gfunct_L5DR_RDIaV_1458.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContact_TypeID)).ToArray()
			group el_Contacts by new 
			{ 
				el_Contacts.CMN_PER_CommunicationContact_TypeID,

			}
			into gfunct_Contacts
			select new L5DR_RDIaV_1458a
			{     
				CMN_PER_CommunicationContact_TypeID = gfunct_Contacts.Key.CMN_PER_CommunicationContact_TypeID ,
				Content = gfunct_Contacts.FirstOrDefault().Content ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DR_RDIaV_1458_Array : FR_Base
	{
		public L5DR_RDIaV_1458[] Result	{ get; set; } 
		public FR_L5DR_RDIaV_1458_Array() : base() {}

		public FR_L5DR_RDIaV_1458_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5DR_RDIaV_1458 for attribute L5DR_RDIaV_1458
		[DataContract]
		public class L5DR_RDIaV_1458 
		{
			[DataMember]
			public L5DR_RDIaV_1458a[] Contacts { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid AssociatedBusinessParticipant_RefID { get; set; } 
			[DataMember]
			public String AccountCode_Value { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String City_PostalCode { get; set; } 
			[DataMember]
			public String Province_Name { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String City_Name { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public Guid CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipant_AssociatedBusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_AddressID { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 
			[DataMember]
			public Guid USR_Device_AccountCode_UsageHistoryID { get; set; } 
			[DataMember]
			public Guid USR_Device_AccountCodeID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_SupplierID { get; set; } 

		}
		#endregion
		#region SClass L5DR_RDIaV_1458a for attribute Contacts
		[DataContract]
		public class L5DR_RDIaV_1458a 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 
			[DataMember]
			public String Content { get; set; } 

		}
		#endregion

	#endregion
}
