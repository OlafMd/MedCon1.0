/* 
 * Generated on 3/25/2015 16:36:35
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

namespace CL5_MyHealthClub_Examanations.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientFindings_for_ExaminationID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientFindings_for_ExaminationID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EX_GPFfEID_1142_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5EX_GPFfEID_1142 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EX_GPFfEID_1142_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Examanations.Atomic.Retrieval.SQL.cls_Get_PatientFindings_for_ExaminationID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ExaminationID", Parameter.ExaminationID);



			List<L5EX_GPFfEID_1142> results = new List<L5EX_GPFfEID_1142>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "FindingID","PatientID","DateOfFindings","PracticeTypeID","Document_RefID","MedicalPracticeType_Name_DictID","Size","Type","Name" });
				while(reader.Read())
				{
					L5EX_GPFfEID_1142 resultItem = new L5EX_GPFfEID_1142();
					//0:Parameter FindingID of type Guid
					resultItem.FindingID = reader.GetGuid(0);
					//1:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(1);
					//2:Parameter DateOfFindings of type DateTime
					resultItem.DateOfFindings = reader.GetDate(2);
					//3:Parameter PracticeTypeID of type Guid
					resultItem.PracticeTypeID = reader.GetGuid(3);
					//4:Parameter Document_RefID of type Guid
					resultItem.Document_RefID = reader.GetGuid(4);
					//5:Parameter MedicalPracticeType_Name_DictID of type Dict
					resultItem.MedicalPracticeType_Name_DictID = reader.GetDictionary(5);
					resultItem.MedicalPracticeType_Name_DictID.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name_DictID);
					//6:Parameter Size of type String
					resultItem.Size = reader.GetString(6);
					//7:Parameter Type of type String
					resultItem.Type = reader.GetString(7);
					//8:Parameter Name of type String
					resultItem.Name = reader.GetString(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientFindings_for_ExaminationID",ex);
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
		public static FR_L5EX_GPFfEID_1142_Array Invoke(string ConnectionString,P_L5EX_GPFfEID_1142 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EX_GPFfEID_1142_Array Invoke(DbConnection Connection,P_L5EX_GPFfEID_1142 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EX_GPFfEID_1142_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EX_GPFfEID_1142 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EX_GPFfEID_1142_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EX_GPFfEID_1142 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EX_GPFfEID_1142_Array functionReturn = new FR_L5EX_GPFfEID_1142_Array();
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

				throw new Exception("Exception occured in method cls_Get_PatientFindings_for_ExaminationID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EX_GPFfEID_1142_Array : FR_Base
	{
		public L5EX_GPFfEID_1142[] Result	{ get; set; } 
		public FR_L5EX_GPFfEID_1142_Array() : base() {}

		public FR_L5EX_GPFfEID_1142_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5EX_GPFfEID_1142 for attribute P_L5EX_GPFfEID_1142
		[DataContract]
		public class P_L5EX_GPFfEID_1142 
		{
			//Standard type parameters
			[DataMember]
			public Guid ExaminationID { get; set; } 

		}
		#endregion
		#region SClass L5EX_GPFfEID_1142 for attribute L5EX_GPFfEID_1142
		[DataContract]
		public class L5EX_GPFfEID_1142 
		{
			//Standard type parameters
			[DataMember]
			public Guid FindingID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public DateTime DateOfFindings { get; set; } 
			[DataMember]
			public Guid PracticeTypeID { get; set; } 
			[DataMember]
			public Guid Document_RefID { get; set; } 
			[DataMember]
			public Dict MedicalPracticeType_Name_DictID { get; set; } 
			[DataMember]
			public String Size { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public String Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EX_GPFfEID_1142_Array cls_Get_PatientFindings_for_ExaminationID(,P_L5EX_GPFfEID_1142 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EX_GPFfEID_1142_Array invocationResult = cls_Get_PatientFindings_for_ExaminationID.Invoke(connectionString,P_L5EX_GPFfEID_1142 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Examanations.Atomic.Retrieval.P_L5EX_GPFfEID_1142();
parameter.ExaminationID = ...;

*/
