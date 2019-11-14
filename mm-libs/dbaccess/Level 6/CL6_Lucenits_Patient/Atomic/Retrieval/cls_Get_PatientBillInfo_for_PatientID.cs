/* 
 * Generated on 8/20/2013 12:51:20 PM
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

namespace CL6_Lucenits_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientBillInfo_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientBillInfo_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PA_GPBIfPID_1155_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_GPBIfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PA_GPBIfPID_1155_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_Lucenits_Patient.Atomic.Retrieval.SQL.cls_Get_PatientBillInfo_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientID"," IN $$PatientID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientID$",Parameter.PatientID);


			List<L6PA_GPBIfPID_1155> results = new List<L6PA_GPBIfPID_1155>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_PatientID","FirstName","LastName","Birthdate","HealthInsurance_Number","HealthInsurance_State_RefID","InsuranceStateCode","Gender" });
				while(reader.Read())
				{
					L6PA_GPBIfPID_1155 resultItem = new L6PA_GPBIfPID_1155();
					//0:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter Birthdate of type DateTime
					resultItem.Birthdate = reader.GetDate(3);
					//4:Parameter HealthInsurance_Number of type String
					resultItem.HealthInsurance_Number = reader.GetString(4);
					//5:Parameter HealthInsurance_State_RefID of type Guid
					resultItem.HealthInsurance_State_RefID = reader.GetGuid(5);
					//6:Parameter InsuranceStateCode of type String
					resultItem.InsuranceStateCode = reader.GetString(6);
					//7:Parameter Gender of type int
					resultItem.Gender = reader.GetInteger(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientBillInfo_for_PatientID",ex);
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
		public static FR_L6PA_GPBIfPID_1155_Array Invoke(string ConnectionString,P_L6PA_GPBIfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PA_GPBIfPID_1155_Array Invoke(DbConnection Connection,P_L6PA_GPBIfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PA_GPBIfPID_1155_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_GPBIfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PA_GPBIfPID_1155_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_GPBIfPID_1155 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PA_GPBIfPID_1155_Array functionReturn = new FR_L6PA_GPBIfPID_1155_Array();
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

				throw new Exception("Exception occured in method cls_Get_PatientBillInfo_for_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PA_GPBIfPID_1155_Array : FR_Base
	{
		public L6PA_GPBIfPID_1155[] Result	{ get; set; } 
		public FR_L6PA_GPBIfPID_1155_Array() : base() {}

		public FR_L6PA_GPBIfPID_1155_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PA_GPBIfPID_1155 for attribute P_L6PA_GPBIfPID_1155
		[DataContract]
		public class P_L6PA_GPBIfPID_1155 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientID { get; set; } 

		}
		#endregion
		#region SClass L6PA_GPBIfPID_1155 for attribute L6PA_GPBIfPID_1155
		[DataContract]
		public class L6PA_GPBIfPID_1155 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public DateTime Birthdate { get; set; } 
			[DataMember]
			public String HealthInsurance_Number { get; set; } 
			[DataMember]
			public Guid HealthInsurance_State_RefID { get; set; } 
			[DataMember]
			public String InsuranceStateCode { get; set; } 
			[DataMember]
			public int Gender { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PA_GPBIfPID_1155_Array cls_Get_PatientBillInfo_for_PatientID(,P_L6PA_GPBIfPID_1155 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PA_GPBIfPID_1155_Array invocationResult = cls_Get_PatientBillInfo_for_PatientID.Invoke(connectionString,P_L6PA_GPBIfPID_1155 Parameter,securityTicket);
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
var parameter = new CL6_Lucenits_Patient.Atomic.Retrieval.P_L6PA_GPBIfPID_1155();
parameter.PatientID = ...;

*/
