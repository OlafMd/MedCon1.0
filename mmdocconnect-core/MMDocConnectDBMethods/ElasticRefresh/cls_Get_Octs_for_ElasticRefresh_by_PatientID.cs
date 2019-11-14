/* 
 * Generated on 4/23/2017 12:27:58 PM
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

namespace MMDocConnectDBMethods.ElasticRefresh
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Octs_for_ElasticRefresh_by_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Octs_for_ElasticRefresh_by_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_ER_GOfERbPID_1818_Array Execute(DbConnection Connection,DbTransaction Transaction,P_ER_GOfERbPID_1818 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_ER_GOfERbPID_1818_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.ElasticRefresh.SQL.cls_Get_Octs_for_ElasticRefresh_by_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<ER_GOfERbPID_1818> results = new List<ER_GOfERbPID_1818>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OctDoctorName","OpDoctorName","PatientName","CaseID","ID","DiagnoseCode","Localization","DiagnoseID","OpDoctorID","OctDoctorID","OpPracticeID","OctPracticeID","OpPracticeName","PatientBirthDate","TreatmentDate","IsCancelled","IsOpPerformed" });
				while(reader.Read())
				{
					ER_GOfERbPID_1818 resultItem = new ER_GOfERbPID_1818();
					//0:Parameter OctDoctorName of type String
					resultItem.OctDoctorName = reader.GetString(0);
					//1:Parameter OpDoctorName of type String
					resultItem.OpDoctorName = reader.GetString(1);
					//2:Parameter PatientName of type String
					resultItem.PatientName = reader.GetString(2);
					//3:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(3);
					//4:Parameter ID of type Guid
					resultItem.ID = reader.GetGuid(4);
					//5:Parameter DiagnoseCode of type String
					resultItem.DiagnoseCode = reader.GetString(5);
					//6:Parameter Localization of type String
					resultItem.Localization = reader.GetString(6);
					//7:Parameter DiagnoseID of type Guid
					resultItem.DiagnoseID = reader.GetGuid(7);
					//8:Parameter OpDoctorID of type Guid
					resultItem.OpDoctorID = reader.GetGuid(8);
					//9:Parameter OctDoctorID of type Guid
					resultItem.OctDoctorID = reader.GetGuid(9);
					//10:Parameter OpPracticeID of type Guid
					resultItem.OpPracticeID = reader.GetGuid(10);
					//11:Parameter OctPracticeID of type Guid
					resultItem.OctPracticeID = reader.GetGuid(11);
					//12:Parameter OpPracticeName of type String
					resultItem.OpPracticeName = reader.GetString(12);
					//13:Parameter PatientBirthDate of type DateTime
					resultItem.PatientBirthDate = reader.GetDate(13);
					//14:Parameter TreatmentDate of type DateTime
					resultItem.TreatmentDate = reader.GetDate(14);
					//15:Parameter IsCancelled of type Boolean
					resultItem.IsCancelled = reader.GetBoolean(15);
					//16:Parameter IsOpPerformed of type Boolean
					resultItem.IsOpPerformed = reader.GetBoolean(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Octs_for_ElasticRefresh_by_PatientID",ex);
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
		public static FR_ER_GOfERbPID_1818_Array Invoke(string ConnectionString,P_ER_GOfERbPID_1818 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_ER_GOfERbPID_1818_Array Invoke(DbConnection Connection,P_ER_GOfERbPID_1818 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_ER_GOfERbPID_1818_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_ER_GOfERbPID_1818 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_ER_GOfERbPID_1818_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_ER_GOfERbPID_1818 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_ER_GOfERbPID_1818_Array functionReturn = new FR_ER_GOfERbPID_1818_Array();
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

				throw new Exception("Exception occured in method cls_Get_Octs_for_ElasticRefresh_by_PatientID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_ER_GOfERbPID_1818_Array : FR_Base
	{
		public ER_GOfERbPID_1818[] Result	{ get; set; } 
		public FR_ER_GOfERbPID_1818_Array() : base() {}

		public FR_ER_GOfERbPID_1818_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_ER_GOfERbPID_1818 for attribute P_ER_GOfERbPID_1818
		[DataContract]
		public class P_ER_GOfERbPID_1818 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass ER_GOfERbPID_1818 for attribute ER_GOfERbPID_1818
		[DataContract]
		public class ER_GOfERbPID_1818 
		{
			//Standard type parameters
			[DataMember]
			public String OctDoctorName { get; set; } 
			[DataMember]
			public String OpDoctorName { get; set; } 
			[DataMember]
			public String PatientName { get; set; } 
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public String DiagnoseCode { get; set; } 
			[DataMember]
			public String Localization { get; set; } 
			[DataMember]
			public Guid DiagnoseID { get; set; } 
			[DataMember]
			public Guid OpDoctorID { get; set; } 
			[DataMember]
			public Guid OctDoctorID { get; set; } 
			[DataMember]
			public Guid OpPracticeID { get; set; } 
			[DataMember]
			public Guid OctPracticeID { get; set; } 
			[DataMember]
			public String OpPracticeName { get; set; } 
			[DataMember]
			public DateTime PatientBirthDate { get; set; } 
			[DataMember]
			public DateTime TreatmentDate { get; set; } 
			[DataMember]
			public Boolean IsCancelled { get; set; } 
			[DataMember]
			public Boolean IsOpPerformed { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_ER_GOfERbPID_1818_Array cls_Get_Octs_for_ElasticRefresh_by_PatientID(,P_ER_GOfERbPID_1818 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_ER_GOfERbPID_1818_Array invocationResult = cls_Get_Octs_for_ElasticRefresh_by_PatientID.Invoke(connectionString,P_ER_GOfERbPID_1818 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.ElasticRefresh.P_ER_GOfERbPID_1818();
parameter.PatientID = ...;

*/
