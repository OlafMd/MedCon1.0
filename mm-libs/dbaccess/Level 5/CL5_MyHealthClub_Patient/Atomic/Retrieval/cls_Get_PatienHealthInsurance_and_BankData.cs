/* 
 * Generated on 7/2/2014 10:42:52 AM
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

namespace CL5_MyHealthClub_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatienHealthInsurance_and_BankData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatienHealthInsurance_and_BankData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPHIaBD_1536 Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPHIaBD_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPHIaBD_1536();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Patient.Atomic.Retrieval.SQL.cls_Get_PatienHealthInsurance_and_BankData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<L5PA_GPHIaBD_1536> results = new List<L5PA_GPHIaBD_1536>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HealthInsurance_Number","InsuranceValidFrom","InsuranceValidThrough","IsNotSelfInsured","IsNotSelfInsured_InsuredPersonName","IsNotSelfInsured_InsuredPersonBirthday","CompanyName","AccountNumber","OwnerText","IBAN","BICCode","BankName","HEC_Patient_HealthInsurance_StateID","HEC_HealthInsurance_CompanyID" });
				while(reader.Read())
				{
					L5PA_GPHIaBD_1536 resultItem = new L5PA_GPHIaBD_1536();
					//0:Parameter HealthInsurance_Number of type String
					resultItem.HealthInsurance_Number = reader.GetString(0);
					//1:Parameter InsuranceValidFrom of type DateTime
					resultItem.InsuranceValidFrom = reader.GetDate(1);
					//2:Parameter InsuranceValidThrough of type DateTime
					resultItem.InsuranceValidThrough = reader.GetDate(2);
					//3:Parameter IsNotSelfInsured of type bool
					resultItem.IsNotSelfInsured = reader.GetBoolean(3);
					//4:Parameter IsNotSelfInsured_InsuredPersonName of type String
					resultItem.IsNotSelfInsured_InsuredPersonName = reader.GetString(4);
					//5:Parameter IsNotSelfInsured_InsuredPersonBirthday of type DateTime
					resultItem.IsNotSelfInsured_InsuredPersonBirthday = reader.GetDate(5);
					//6:Parameter CompanyName of type String
					resultItem.CompanyName = reader.GetString(6);
					//7:Parameter AccountNumber of type String
					resultItem.AccountNumber = reader.GetString(7);
					//8:Parameter OwnerText of type String
					resultItem.OwnerText = reader.GetString(8);
					//9:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(9);
					//10:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(10);
					//11:Parameter BankName of type String
					resultItem.BankName = reader.GetString(11);
					//12:Parameter HEC_Patient_HealthInsurance_StateID of type Guid
					resultItem.HEC_Patient_HealthInsurance_StateID = reader.GetGuid(12);
					//13:Parameter HEC_HealthInsurance_CompanyID of type Guid
					resultItem.HEC_HealthInsurance_CompanyID = reader.GetGuid(13);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatienHealthInsurance_and_BankData",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPHIaBD_1536 Invoke(string ConnectionString,P_L5PA_GPHIaBD_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPHIaBD_1536 Invoke(DbConnection Connection,P_L5PA_GPHIaBD_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPHIaBD_1536 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPHIaBD_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPHIaBD_1536 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPHIaBD_1536 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPHIaBD_1536 functionReturn = new FR_L5PA_GPHIaBD_1536();
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

				throw new Exception("Exception occured in method cls_Get_PatienHealthInsurance_and_BankData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPHIaBD_1536 : FR_Base
	{
		public L5PA_GPHIaBD_1536 Result	{ get; set; }

		public FR_L5PA_GPHIaBD_1536() : base() {}

		public FR_L5PA_GPHIaBD_1536(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPHIaBD_1536 for attribute P_L5PA_GPHIaBD_1536
		[DataContract]
		public class P_L5PA_GPHIaBD_1536 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPHIaBD_1536 for attribute L5PA_GPHIaBD_1536
		[DataContract]
		public class L5PA_GPHIaBD_1536 
		{
			//Standard type parameters
			[DataMember]
			public String HealthInsurance_Number { get; set; } 
			[DataMember]
			public DateTime InsuranceValidFrom { get; set; } 
			[DataMember]
			public DateTime InsuranceValidThrough { get; set; } 
			[DataMember]
			public bool IsNotSelfInsured { get; set; } 
			[DataMember]
			public String IsNotSelfInsured_InsuredPersonName { get; set; } 
			[DataMember]
			public DateTime IsNotSelfInsured_InsuredPersonBirthday { get; set; } 
			[DataMember]
			public String CompanyName { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public String OwnerText { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public Guid HEC_Patient_HealthInsurance_StateID { get; set; } 
			[DataMember]
			public Guid HEC_HealthInsurance_CompanyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GPHIaBD_1536 cls_Get_PatienHealthInsurance_and_BankData(,P_L5PA_GPHIaBD_1536 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPHIaBD_1536 invocationResult = cls_Get_PatienHealthInsurance_and_BankData.Invoke(connectionString,P_L5PA_GPHIaBD_1536 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Patient.Atomic.Retrieval.P_L5PA_GPHIaBD_1536();
parameter.PatientID = ...;

*/
