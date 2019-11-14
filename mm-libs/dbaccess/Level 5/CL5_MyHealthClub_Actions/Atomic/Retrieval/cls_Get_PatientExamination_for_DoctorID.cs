/* 
 * Generated on 1/16/2015 1:06:51 PM
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
    /// var result = cls_Get_PatientExamination_for_DoctorID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientExamination_for_DoctorID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GPEfDID_1228_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GPEfDID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GPEfDID_1228_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Actions.Atomic.Retrieval.SQL.cls_Get_PatientExamination_for_DoctorID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@ListDoctorID"," IN $$ListDoctorID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$ListDoctorID$",Parameter.ListDoctorID);


			List<L5AC_GPEfDID_1228> results = new List<L5AC_GPEfDID_1228>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IfPerfomed_DateOfAction","Office_Name_DictID","HEC_Doctor_RefID","HEC_ACT_PerformedActionID","DoctorTitle","DoctorFirstName","DoctorLastName" });
				while(reader.Read())
				{
					L5AC_GPEfDID_1228 resultItem = new L5AC_GPEfDID_1228();
					//0:Parameter IfPerfomed_DateOfAction of type DateTime
					resultItem.IfPerfomed_DateOfAction = reader.GetDate(0);
					//1:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(1);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//2:Parameter HEC_Doctor_RefID of type Guid
					resultItem.HEC_Doctor_RefID = reader.GetGuid(2);
					//3:Parameter HEC_ACT_PerformedActionID of type Guid
					resultItem.HEC_ACT_PerformedActionID = reader.GetGuid(3);
					//4:Parameter DoctorTitle of type String
					resultItem.DoctorTitle = reader.GetString(4);
					//5:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(5);
					//6:Parameter DoctorLastName of type String
					resultItem.DoctorLastName = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientExamination_for_DoctorID",ex);
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
		public static FR_L5AC_GPEfDID_1228_Array Invoke(string ConnectionString,P_L5AC_GPEfDID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GPEfDID_1228_Array Invoke(DbConnection Connection,P_L5AC_GPEfDID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GPEfDID_1228_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GPEfDID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GPEfDID_1228_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GPEfDID_1228 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GPEfDID_1228_Array functionReturn = new FR_L5AC_GPEfDID_1228_Array();
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

				throw new Exception("Exception occured in method cls_Get_PatientExamination_for_DoctorID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GPEfDID_1228_Array : FR_Base
	{
		public L5AC_GPEfDID_1228[] Result	{ get; set; } 
		public FR_L5AC_GPEfDID_1228_Array() : base() {}

		public FR_L5AC_GPEfDID_1228_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GPEfDID_1228 for attribute P_L5AC_GPEfDID_1228
		[DataContract]
		public class P_L5AC_GPEfDID_1228 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] ListDoctorID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GPEfDID_1228 for attribute L5AC_GPEfDID_1228
		[DataContract]
		public class L5AC_GPEfDID_1228 
		{
			//Standard type parameters
			[DataMember]
			public DateTime IfPerfomed_DateOfAction { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public Guid HEC_Doctor_RefID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PerformedActionID { get; set; } 
			[DataMember]
			public String DoctorTitle { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GPEfDID_1228_Array cls_Get_PatientExamination_for_DoctorID(,P_L5AC_GPEfDID_1228 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GPEfDID_1228_Array invocationResult = cls_Get_PatientExamination_for_DoctorID.Invoke(connectionString,P_L5AC_GPEfDID_1228 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Actions.Atomic.Retrieval.P_L5AC_GPEfDID_1228();
parameter.ListDoctorID = ...;

*/
