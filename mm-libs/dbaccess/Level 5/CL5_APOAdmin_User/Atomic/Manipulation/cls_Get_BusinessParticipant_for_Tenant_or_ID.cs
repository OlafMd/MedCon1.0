/* 
 * Generated on 12/6/2013 10:58:44 AM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_User.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BusinessParticipant_for_Tenant_or_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BusinessParticipant_for_Tenant_or_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GBPfToID_1419_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_GBPfToID_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5US_GBPfToID_1419_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_User.Atomic.Manipulation.SQL.cls_Get_BusinessParticipant_for_Tenant_or_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ID", Parameter.ID);



			List<L5US_GBPfToID_1419> results = new List<L5US_GBPfToID_1419>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_BusinessParticipantID","Tenant_RefID","DisplayName","IsNaturalPerson","IsCompany","IfNaturalPerson_CMN_PER_PersonInfo_RefID","IfCompany_CMN_COM_CompanyInfo_RefID","DisplayImage_RefID","DefaultLanguage_RefID","DefaultCurrency_RefID","LastContacted_Date","LastContacted_ByBusinessPartner_RefID","Audit_UpdatedByAccount_RefID","Audit_UpdatedOn","Audit_CreatedByAccount_RefID" });
				while(reader.Read())
				{
					L5US_GBPfToID_1419 resultItem = new L5US_GBPfToID_1419();
					//0:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(0);
					//1:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);
					//3:Parameter IsNaturalPerson of type bool
					resultItem.IsNaturalPerson = reader.GetBoolean(3);
					//4:Parameter IsCompany of type bool
					resultItem.IsCompany = reader.GetBoolean(4);
					//5:Parameter IfNaturalPerson_CMN_PER_PersonInfo_RefID of type Guid
					resultItem.IfNaturalPerson_CMN_PER_PersonInfo_RefID = reader.GetGuid(5);
					//6:Parameter IfCompany_CMN_COM_CompanyInfo_RefID of type Guid
					resultItem.IfCompany_CMN_COM_CompanyInfo_RefID = reader.GetGuid(6);
					//7:Parameter DisplayImage_RefID of type Guid
					resultItem.DisplayImage_RefID = reader.GetGuid(7);
					//8:Parameter DefaultLanguage_RefID of type Guid
					resultItem.DefaultLanguage_RefID = reader.GetGuid(8);
					//9:Parameter DefaultCurrency_RefID of type Guid
					resultItem.DefaultCurrency_RefID = reader.GetGuid(9);
					//10:Parameter LastContacted_Date of type DateTime
					resultItem.LastContacted_Date = reader.GetDate(10);
					//11:Parameter LastContacted_ByBusinessPartner_RefID of type Guid
					resultItem.LastContacted_ByBusinessPartner_RefID = reader.GetGuid(11);
					//12:Parameter Audit_UpdatedByAccount_RefID of type Guid
					resultItem.Audit_UpdatedByAccount_RefID = reader.GetGuid(12);
					//13:Parameter Audit_UpdatedOn of type String
					resultItem.Audit_UpdatedOn = reader.GetString(13);
					//14:Parameter Audit_CreatedByAccount_RefID of type Guid
					resultItem.Audit_CreatedByAccount_RefID = reader.GetGuid(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BusinessParticipant_for_Tenant_or_ID",ex);
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
		public static FR_L5US_GBPfToID_1419_Array Invoke(string ConnectionString,P_L5US_GBPfToID_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GBPfToID_1419_Array Invoke(DbConnection Connection,P_L5US_GBPfToID_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GBPfToID_1419_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_GBPfToID_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GBPfToID_1419_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_GBPfToID_1419 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GBPfToID_1419_Array functionReturn = new FR_L5US_GBPfToID_1419_Array();
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

				throw new Exception("Exception occured in method cls_Get_BusinessParticipant_for_Tenant_or_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GBPfToID_1419_Array : FR_Base
	{
		public L5US_GBPfToID_1419[] Result	{ get; set; } 
		public FR_L5US_GBPfToID_1419_Array() : base() {}

		public FR_L5US_GBPfToID_1419_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5US_GBPfToID_1419 for attribute P_L5US_GBPfToID_1419
		[DataContract]
		public class P_L5US_GBPfToID_1419 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 

		}
		#endregion
		#region SClass L5US_GBPfToID_1419 for attribute L5US_GBPfToID_1419
		[DataContract]
		public class L5US_GBPfToID_1419 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
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
			public String Audit_UpdatedOn { get; set; } 
			[DataMember]
			public Guid Audit_CreatedByAccount_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GBPfToID_1419_Array cls_Get_BusinessParticipant_for_Tenant_or_ID(,P_L5US_GBPfToID_1419 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GBPfToID_1419_Array invocationResult = cls_Get_BusinessParticipant_for_Tenant_or_ID.Invoke(connectionString,P_L5US_GBPfToID_1419 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Atomic.Manipulation.P_L5US_GBPfToID_1419();
parameter.ID = ...;

*/
