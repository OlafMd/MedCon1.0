/* 
 * Generated on 1/16/2015 9:24:15 AM
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

namespace CL5_MyHealthClub_Actions.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DiagnosesStatistics_for_DiagnosisID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiagnosesStatistics_for_DiagnosisID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GDSfDID_1433_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GDSfDID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GDSfDID_1433_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Actions.Atomic.Retrieval.SQL.cls_Get_DiagnosesStatistics_for_DiagnosisID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnosisID", Parameter.DiagnosisID);



			List<L5AC_GDSfDID_1433> results = new List<L5AC_GDSfDID_1433>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PotentialDiagnosis_Name_DictID","IfPerfomed_DateOfAction","Office_Name_DictID","HEC_DIA_PotentialDiagnosisID","CMN_STR_OfficeID","HEC_Doctor_RefID","HEC_ACT_PerformedActionID","IsDiagnosisNegated","DoctorTitle","DoctorFirstName","DoctorLastName","ICD10_Code" });
				while(reader.Read())
				{
					L5AC_GDSfDID_1433 resultItem = new L5AC_GDSfDID_1433();
					//0:Parameter PotentialDiagnosis_Name of type Dict
					resultItem.PotentialDiagnosis_Name = reader.GetDictionary(0);
					resultItem.PotentialDiagnosis_Name.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name);
					//1:Parameter IfPerfomed_DateOfAction of type DateTime
					resultItem.IfPerfomed_DateOfAction = reader.GetDate(1);
					//2:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(2);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//3:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(3);
					//4:Parameter CMN_STR_OfficeID of type Guid
					resultItem.CMN_STR_OfficeID = reader.GetGuid(4);
					//5:Parameter HEC_Doctor_RefID of type Guid
					resultItem.HEC_Doctor_RefID = reader.GetGuid(5);
					//6:Parameter HEC_ACT_PerformedActionID of type Guid
					resultItem.HEC_ACT_PerformedActionID = reader.GetGuid(6);
					//7:Parameter IsDiagnosisNegated of type bool
					resultItem.IsDiagnosisNegated = reader.GetBoolean(7);
					//8:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(8);
					//9:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(9);
					//10:Parameter DoctorLastName of type String
					resultItem.DoctorLastName = reader.GetString(10);
					//11:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DiagnosesStatistics_for_DiagnosisID",ex);
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
		public static FR_L5AC_GDSfDID_1433_Array Invoke(string ConnectionString,P_L5AC_GDSfDID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GDSfDID_1433_Array Invoke(DbConnection Connection,P_L5AC_GDSfDID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GDSfDID_1433_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GDSfDID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GDSfDID_1433_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GDSfDID_1433 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GDSfDID_1433_Array functionReturn = new FR_L5AC_GDSfDID_1433_Array();
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

				throw new Exception("Exception occured in method cls_Get_DiagnosesStatistics_for_DiagnosisID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GDSfDID_1433_Array : FR_Base
	{
		public L5AC_GDSfDID_1433[] Result	{ get; set; } 
		public FR_L5AC_GDSfDID_1433_Array() : base() {}

		public FR_L5AC_GDSfDID_1433_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GDSfDID_1433 for attribute P_L5AC_GDSfDID_1433
		[DataContract]
		public class P_L5AC_GDSfDID_1433 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GDSfDID_1433 for attribute L5AC_GDSfDID_1433
		[DataContract]
		public class L5AC_GDSfDID_1433 
		{
			//Standard type parameters
			[DataMember]
			public Dict PotentialDiagnosis_Name { get; set; } 
			[DataMember]
			public DateTime IfPerfomed_DateOfAction { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public Guid CMN_STR_OfficeID { get; set; } 
			[DataMember]
			public Guid HEC_Doctor_RefID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PerformedActionID { get; set; } 
			[DataMember]
			public bool IsDiagnosisNegated { get; set; } 
			[DataMember]
			public String DoctorTitle { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GDSfDID_1433_Array cls_Get_DiagnosesStatistics_for_DiagnosisID(,P_L5AC_GDSfDID_1433 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GDSfDID_1433_Array invocationResult = cls_Get_DiagnosesStatistics_for_DiagnosisID.Invoke(connectionString,P_L5AC_GDSfDID_1433 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Actions.Atomic.Retrieval.P_L5AC_GDSfDID_1433();
parameter.DiagnosisID = ...;

*/
