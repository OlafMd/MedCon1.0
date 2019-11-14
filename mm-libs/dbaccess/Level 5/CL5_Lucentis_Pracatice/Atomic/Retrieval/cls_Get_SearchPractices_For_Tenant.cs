/* 
 * Generated on 7/5/2013 11:17:17 AM
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

namespace CLE_L3_Practice.Atomic.Retrieval
{
	[DataContract]
	public class cls_Get_SearchPractices_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3MP_GSPRAFT_1020_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3MP_GSPRAFT_1020_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CLE_L3_Practice.Atomic.Retrieval.SQL.cls_Get_SearchPractices_For_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L3MP_GSPRAFT_1020> results = new List<L3MP_GSPRAFT_1020>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_MedicalPractiseID","PracticeName","Practice_CMN_BPT_BusinessParticipantID","CMN_COM_CompanyInfoID","Contact_UCD_RefID","Contact_CMN_UniversalContactDetailID","Contact_Email","Contact_Website_URL","Shipping_CMN_UniversalContactDetailID","CMN_COM_CompanyInfo_AddressID","ContactPerson_RefID","ContactPersonName","ZIP","Town","Street_Number","Street_Name","Region_Name","Street_Name1","Street_Number1","ZIP1","Town1","Region_Name1","Contact_EmergencyPhoneNumber" });
				while(reader.Read())
				{
					L3MP_GSPRAFT_1020 resultItem = new L3MP_GSPRAFT_1020();
					//0:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(0);
					//1:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(1);
					//2:Parameter Practice_CMN_BPT_BusinessParticipantID of type Guid
					resultItem.Practice_CMN_BPT_BusinessParticipantID = reader.GetGuid(2);
					//3:Parameter CMN_COM_CompanyInfoID of type Guid
					resultItem.CMN_COM_CompanyInfoID = reader.GetGuid(3);
					//4:Parameter Contact_UCD_RefID of type Guid
					resultItem.Contact_UCD_RefID = reader.GetGuid(4);
					//5:Parameter Contact_CMN_UniversalContactDetailID of type Guid
					resultItem.Contact_CMN_UniversalContactDetailID = reader.GetGuid(5);
					//6:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(6);
					//7:Parameter Contact_Website_URL of type String
					resultItem.Contact_Website_URL = reader.GetString(7);
					//8:Parameter Shipping_CMN_UniversalContactDetailID of type Guid
					resultItem.Shipping_CMN_UniversalContactDetailID = reader.GetGuid(8);
					//9:Parameter CMN_COM_CompanyInfo_AddressID of type Guid
					resultItem.CMN_COM_CompanyInfo_AddressID = reader.GetGuid(9);
					//10:Parameter ContactPerson_RefID of type Guid
					resultItem.ContactPerson_RefID = reader.GetGuid(10);
					//11:Parameter ContactPersonName of type String
					resultItem.ContactPersonName = reader.GetString(11);
					//12:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(12);
					//13:Parameter Town of type String
					resultItem.Town = reader.GetString(13);
					//14:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(14);
					//15:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(15);
					//16:Parameter Region_Name of type String
					resultItem.Region_Name = reader.GetString(16);
					//17:Parameter Street_Name1 of type String
					resultItem.Street_Name1 = reader.GetString(17);
					//18:Parameter Street_Number1 of type String
					resultItem.Street_Number1 = reader.GetString(18);
					//19:Parameter ZIP1 of type String
					resultItem.ZIP1 = reader.GetString(19);
					//20:Parameter Town1 of type String
					resultItem.Town1 = reader.GetString(20);
					//21:Parameter Region_Name1 of type String
					resultItem.Region_Name1 = reader.GetString(21);
					//22:Parameter Contact_EmergencyPhoneNumber of type String
					resultItem.Contact_EmergencyPhoneNumber = reader.GetString(22);

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

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3MP_GSPRAFT_1020_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3MP_GSPRAFT_1020_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3MP_GSPRAFT_1020_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3MP_GSPRAFT_1020_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3MP_GSPRAFT_1020_Array functionReturn = new FR_L3MP_GSPRAFT_1020_Array();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L3MP_GSPRAFT_1020_Array : FR_Base
	{
		public L3MP_GSPRAFT_1020[] Result	{ get; set; } 
		public FR_L3MP_GSPRAFT_1020_Array() : base() {}

		public FR_L3MP_GSPRAFT_1020_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3MP_GSPRAFT_1020 for attribute L3MP_GSPRAFT_1020
		[DataContract]
		public class L3MP_GSPRAFT_1020 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid Practice_CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfoID { get; set; } 
			[DataMember]
			public Guid Contact_UCD_RefID { get; set; } 
			[DataMember]
			public Guid Contact_CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public String Contact_Website_URL { get; set; } 
			[DataMember]
			public Guid Shipping_CMN_UniversalContactDetailID { get; set; } 
			[DataMember]
			public Guid CMN_COM_CompanyInfo_AddressID { get; set; } 
			[DataMember]
			public Guid ContactPerson_RefID { get; set; } 
			[DataMember]
			public String ContactPersonName { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Region_Name { get; set; } 
			[DataMember]
			public String Street_Name1 { get; set; } 
			[DataMember]
			public String Street_Number1 { get; set; } 
			[DataMember]
			public String ZIP1 { get; set; } 
			[DataMember]
			public String Town1 { get; set; } 
			[DataMember]
			public String Region_Name1 { get; set; } 
			[DataMember]
			public String Contact_EmergencyPhoneNumber { get; set; } 

		}
		#endregion

	#endregion
}
