/* 
 * Generated on 8/13/2014 3:12:07 PM
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
    /// var result = cls_PersonInfo_by_AccountCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_PersonInfo_by_AccountCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_PIbAC_1618_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_PIbAC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_PIbAC_1618_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_MeasurementsMisc.Atomic.Retrieval.SQL.cls_PersonInfo_by_AccountCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"AccountCode", Parameter.AccountCode);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DownloadCode", Parameter.DownloadCode);



			List<L3_PIbAC_1618> results = new List<L3_PIbAC_1618>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Title","PrimaryEmail","LastName","FirstName","CMN_PER_PersonInfoID","ProfileImage_Document_RefID","BirthDate","Address_RefID","Creation_Timestamp","IsDeleted","Tenant_RefID","Salutation_General","Salutation_Letter","Gender","NumberOfChildren","IsRepresentedByLegalGuardian" });
				while(reader.Read())
				{
					L3_PIbAC_1618 resultItem = new L3_PIbAC_1618();
					//0:Parameter Title of type String
					resultItem.Title = reader.GetString(0);
					//1:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(3);
					//4:Parameter CMN_PER_PersonInfoID of type Guid
					resultItem.CMN_PER_PersonInfoID = reader.GetGuid(4);
					//5:Parameter ProfileImage_Document_RefID of type Guid
					resultItem.ProfileImage_Document_RefID = reader.GetGuid(5);
					//6:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(6);
					//7:Parameter Address_RefID of type Guid
					resultItem.Address_RefID = reader.GetGuid(7);
					//8:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(8);
					//9:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(9);
					//10:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(10);
					//11:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(11);
					//12:Parameter Salutation_Letter of type String
					resultItem.Salutation_Letter = reader.GetString(12);
					//13:Parameter Gender of type String
					resultItem.Gender = reader.GetString(13);
					//14:Parameter NumberOfChildren of type int
					resultItem.NumberOfChildren = reader.GetInteger(14);
					//15:Parameter IsRepresentedByLegalGuardian of type bool
					resultItem.IsRepresentedByLegalGuardian = reader.GetBoolean(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_PersonInfo_by_AccountCode",ex);
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
		public static FR_L3_PIbAC_1618_Array Invoke(string ConnectionString,P_L3_PIbAC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_PIbAC_1618_Array Invoke(DbConnection Connection,P_L3_PIbAC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_PIbAC_1618_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_PIbAC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_PIbAC_1618_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_PIbAC_1618 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_PIbAC_1618_Array functionReturn = new FR_L3_PIbAC_1618_Array();
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

				throw new Exception("Exception occured in method cls_PersonInfo_by_AccountCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_PIbAC_1618_Array : FR_Base
	{
		public L3_PIbAC_1618[] Result	{ get; set; } 
		public FR_L3_PIbAC_1618_Array() : base() {}

		public FR_L3_PIbAC_1618_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_PIbAC_1618 for attribute P_L3_PIbAC_1618
		[DataContract]
		public class P_L3_PIbAC_1618 
		{
			//Standard type parameters
			[DataMember]
			public string AccountCode { get; set; } 
			[DataMember]
			public string DownloadCode { get; set; } 

		}
		#endregion
		#region SClass L3_PIbAC_1618 for attribute L3_PIbAC_1618
		[DataContract]
		public class L3_PIbAC_1618 
		{
			//Standard type parameters
			[DataMember]
			public String Title { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfoID { get; set; } 
			[DataMember]
			public Guid ProfileImage_Document_RefID { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public Guid Address_RefID { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public String Salutation_Letter { get; set; } 
			[DataMember]
			public String Gender { get; set; } 
			[DataMember]
			public int NumberOfChildren { get; set; } 
			[DataMember]
			public bool IsRepresentedByLegalGuardian { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_PIbAC_1618_Array cls_PersonInfo_by_AccountCode(,P_L3_PIbAC_1618 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_PIbAC_1618_Array invocationResult = cls_PersonInfo_by_AccountCode.Invoke(connectionString,P_L3_PIbAC_1618 Parameter,securityTicket);
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
var parameter = new CL3_MeasurementsMisc.Atomic.Retrieval.P_L3_PIbAC_1618();
parameter.AccountCode = ...;
parameter.DownloadCode = ...;

*/
