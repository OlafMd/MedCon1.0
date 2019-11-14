/* 
 * Generated on 8/13/2014 2:49:21 PM
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

namespace CL3_MeasurementsMisc.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_BusinessParticipant_by_AccountCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_BusinessParticipant_by_AccountCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_BPbAC_1616_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_BPbAC_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_BPbAC_1616_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MeasurementsMisc.Atomic.Retrieval.SQL.cls_BusinessParticipant_by_AccountCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L3_BPbAC_1616> results = new List<L3_BPbAC_1616>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","DisplayName","IsNaturalPerson","IsCompany","IfNaturalPerson_CMN_PER_PersonInfo_RefID","IfCompany_CMN_COM_CompanyInfo_RefID","IsTenant","IfTenant_Tenant_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID","DisplayImage_RefID","DefaultLanguage_RefID","DefaultCurrency_RefID","LastContacted_Date","LastContacted_ByBusinessPartner_RefID","Audit_UpdatedByAccount_RefID","Audit_UpdatedOn","Audit_CreatedByAccount_RefID","BusinessParticipantITL" });
				while(reader.Read())
				{
					L3_BPbAC_1616 resultItem = new L3_BPbAC_1616();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(1);
					//2:Parameter IsNaturalPerson of type bool
					resultItem.IsNaturalPerson = reader.GetBoolean(2);
					//3:Parameter IsCompany of type bool
					resultItem.IsCompany = reader.GetBoolean(3);
					//4:Parameter IfNaturalPerson_CMN_PER_PersonInfo_RefID of type Guid
					resultItem.IfNaturalPerson_CMN_PER_PersonInfo_RefID = reader.GetGuid(4);
					//5:Parameter IfCompany_CMN_COM_CompanyInfo_RefID of type Guid
					resultItem.IfCompany_CMN_COM_CompanyInfo_RefID = reader.GetGuid(5);
					//6:Parameter IsTenant of type bool
					resultItem.IsTenant = reader.GetBoolean(6);
					//7:Parameter IfTenant_Tenant_RefID of type Guid
					resultItem.IfTenant_Tenant_RefID = reader.GetGuid(7);
					//8:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(8);
					//9:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(9);
					//10:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(10);
					//11:Parameter DisplayImage_RefID of type Guid
					resultItem.DisplayImage_RefID = reader.GetGuid(11);
					//12:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(12);
					//13:Parameter DefaultCurrency_RefID of type Guid
					resultItem.DefaultCurrency_RefID = reader.GetGuid(13);
					//14:Parameter LastContacted_Date of type DateTime
					resultItem.LastContacted_Date = reader.GetDate(14);
					//15:Parameter LastContacted_ByBusinessPartner_RefID of type Guid
					resultItem.LastContacted_ByBusinessPartner_RefID = reader.GetGuid(15);
					//16:Parameter Audit_UpdatedByAccount_RefID of type Guid
					resultItem.Audit_UpdatedByAccount_RefID = reader.GetGuid(16);
					//17:Parameter Audit_UpdatedOn of type DateTime
					resultItem.Audit_UpdatedOn = reader.GetDate(17);
					//18:Parameter Audit_CreatedByAccount_RefID of type Guid
					resultItem.Audit_CreatedByAccount_RefID = reader.GetGuid(18);
					//19:Parameter BusinessParticipantITL of type String
					resultItem.BusinessParticipantITL = reader.GetString(19);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_BusinessParticipant_by_AccountCode",ex);
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
		public static FR_L3_BPbAC_1616_Array Invoke(string ConnectionString,P_L3_BPbAC_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_BPbAC_1616_Array Invoke(DbConnection Connection,P_L3_BPbAC_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_BPbAC_1616_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_BPbAC_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_BPbAC_1616_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_BPbAC_1616 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_BPbAC_1616_Array functionReturn = new FR_L3_BPbAC_1616_Array();
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

				throw new Exception("Exception occured in method cls_BusinessParticipant_by_AccountCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_BPbAC_1616_Array : FR_Base
	{
		public L3_BPbAC_1616[] Result	{ get; set; } 
		public FR_L3_BPbAC_1616_Array() : base() {}

		public FR_L3_BPbAC_1616_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_BPbAC_1616 for attribute P_L3_BPbAC_1616
		[DataContract]
		public class P_L3_BPbAC_1616 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L3_BPbAC_1616 for attribute L3_BPbAC_1616
		[DataContract]
		public class L3_BPbAC_1616 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public bool IsNaturalPerson { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 
			[DataMember]
			public Guid IfNaturalPerson_CMN_PER_PersonInfo_RefID { get; set; } 
			[DataMember]
			public Guid IfCompany_CMN_COM_CompanyInfo_RefID { get; set; } 
			[DataMember]
			public bool IsTenant { get; set; } 
			[DataMember]
			public Guid IfTenant_Tenant_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public Guid DisplayImage_RefID { get; set; } 
			[DataMember]
			public Guid DefaultLanguage_RefID { get; set; } 
			[DataMember]
			public Guid DefaultCurrency_RefID { get; set; } 
			[DataMember]
			public DateTime LastContacted_Date { get; set; } 
			[DataMember]
			public Guid LastContacted_ByBusinessPartner_RefID { get; set; } 
			[DataMember]
			public Guid Audit_UpdatedByAccount_RefID { get; set; } 
			[DataMember]
			public DateTime Audit_UpdatedOn { get; set; } 
			[DataMember]
			public Guid Audit_CreatedByAccount_RefID { get; set; } 
			[DataMember]
			public String BusinessParticipantITL { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_BPbAC_1616_Array cls_BusinessParticipant_by_AccountCode(,P_L3_BPbAC_1616 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_BPbAC_1616_Array invocationResult = cls_BusinessParticipant_by_AccountCode.Invoke(connectionString,P_L3_BPbAC_1616 Parameter,securityTicket);
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
var parameter = new CL3_MeasurementsMisc.Atomic.Retrieval.P_L3_BPbAC_1616();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
