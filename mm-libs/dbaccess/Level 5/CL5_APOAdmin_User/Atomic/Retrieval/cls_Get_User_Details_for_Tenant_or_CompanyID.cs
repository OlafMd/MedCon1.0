/* 
 * Generated on 12/5/2013 4:10:52 PM
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
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;

namespace CL5_APOAdmin_User.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_User_Details_for_Tenant_or_CompanyID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_User_Details_for_Tenant_or_CompanyID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GUDfCId_1726_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5US_GUDfCId_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5US_GUDfCId_1726_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_User.Atomic.Retrieval.SQL.cls_Get_User_Details_for_Tenant_or_CompanyID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CMN_BPT_BusinessParticipantID", Parameter.CMN_BPT_BusinessParticipantID);



			List<L5US_GUDfCId_1726> results = new List<L5US_GUDfCId_1726>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DisplayName","CompanyName_Line1","Street_Name","Street_Number","ZIP","Town","Contact_Email","Contact_Telephone","CMN_BPT_BusinessParticipantID","IsCompany","FirstName","LastName","MedicalPracticeType_Name_DictID","HEC_MedicalPractice_Type_RefID" });
				while(reader.Read())
				{
					L5US_GUDfCId_1726 resultItem = new L5US_GUDfCId_1726();
					//0:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(0);
					//1:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(1);
					//2:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(2);
					//3:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(3);
					//4:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(4);
					//5:Parameter Town of type String
					resultItem.Town = reader.GetString(5);
					//6:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(6);
					//7:Parameter Contact_Telephone of type String
					resultItem.Contact_Telephone = reader.GetString(7);
					//8:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(8);
					//9:Parameter IsCompany of type bool
					resultItem.IsCompany = reader.GetBoolean(9);
					//10:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(10);
					//11:Parameter LastName of type String
					resultItem.LastName = reader.GetString(11);
					//12:Parameter MedicalPracticeType_Name of type Dict
					resultItem.MedicalPracticeType_Name = reader.GetDictionary(12);
					resultItem.MedicalPracticeType_Name.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name);
					//13:Parameter HEC_MedicalPractice_Type_RefID of type Guid
					resultItem.HEC_MedicalPractice_Type_RefID = reader.GetGuid(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_User_Details_for_Tenant_or_CompanyID",ex);
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
		public static FR_L5US_GUDfCId_1726_Array Invoke(string ConnectionString,P_L5US_GUDfCId_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GUDfCId_1726_Array Invoke(DbConnection Connection,P_L5US_GUDfCId_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GUDfCId_1726_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5US_GUDfCId_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GUDfCId_1726_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5US_GUDfCId_1726 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GUDfCId_1726_Array functionReturn = new FR_L5US_GUDfCId_1726_Array();
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

				throw new Exception("Exception occured in method cls_Get_User_Details_for_Tenant_or_CompanyID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GUDfCId_1726_Array : FR_Base
	{
		public L5US_GUDfCId_1726[] Result	{ get; set; } 
		public FR_L5US_GUDfCId_1726_Array() : base() {}

		public FR_L5US_GUDfCId_1726_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5US_GUDfCId_1726 for attribute P_L5US_GUDfCId_1726
		[DataContract]
		public class P_L5US_GUDfCId_1726 
		{
			//Standard type parameters
			[DataMember]
			public Guid? CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass L5US_GUDfCId_1726 for attribute L5US_GUDfCId_1726
		[DataContract]
		public class L5US_GUDfCId_1726 
		{
			//Standard type parameters
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public String Street_Name { get; set; } 
			[DataMember]
			public String Street_Number { get; set; } 
			[DataMember]
			public String ZIP { get; set; } 
			[DataMember]
			public String Town { get; set; } 
			[DataMember]
			public String Contact_Email { get; set; } 
			[DataMember]
			public String Contact_Telephone { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public bool IsCompany { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Dict MedicalPracticeType_Name { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractice_Type_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GUDfCId_1726_Array cls_Get_User_Details_for_Tenant_or_CompanyID(,P_L5US_GUDfCId_1726 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GUDfCId_1726_Array invocationResult = cls_Get_User_Details_for_Tenant_or_CompanyID.Invoke(connectionString,P_L5US_GUDfCId_1726 Parameter,securityTicket);
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
var parameter = new CL5_APOAdmin_User.Atomic.Retrieval.P_L5US_GUDfCId_1726();
parameter.CMN_BPT_BusinessParticipantID = ...;

*/
