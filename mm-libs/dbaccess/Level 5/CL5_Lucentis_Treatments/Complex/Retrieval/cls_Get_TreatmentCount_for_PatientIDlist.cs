/* 
 * Generated on 8/22/2013 12:15:56 PM
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

namespace CL5_Lucentis_Treatments.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TreatmentCount_for_PatientIDlist.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TreatmentCount_for_PatientIDlist
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TR_GTCfPID_1152_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_GTCfPID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GTCfPID_1152_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Treatments.Complex.Retrieval.SQL.cls_Get_TreatmentCount_for_PatientIDlist.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@PatientID"," IN $$PatientID$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$PatientID$",Parameter.PatientID);


			List<L5TR_GTCfPID_1152> results = new List<L5TR_GTCfPID_1152>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_PatientID","treatmentCount" });
				while(reader.Read())
				{
					L5TR_GTCfPID_1152 resultItem = new L5TR_GTCfPID_1152();
					//0:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(0);
					//1:Parameter treatmentCount of type int
					resultItem.treatmentCount = reader.GetInteger(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_TreatmentCount_for_PatientIDlist",ex);
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
		public static FR_L5TR_GTCfPID_1152_Array Invoke(string ConnectionString,P_L5TR_GTCfPID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GTCfPID_1152_Array Invoke(DbConnection Connection,P_L5TR_GTCfPID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GTCfPID_1152_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_GTCfPID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GTCfPID_1152_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_GTCfPID_1152 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GTCfPID_1152_Array functionReturn = new FR_L5TR_GTCfPID_1152_Array();
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

				throw new Exception("Exception occured in method cls_Get_TreatmentCount_for_PatientIDlist",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GTCfPID_1152_Array : FR_Base
	{
		public L5TR_GTCfPID_1152[] Result	{ get; set; } 
		public FR_L5TR_GTCfPID_1152_Array() : base() {}

		public FR_L5TR_GTCfPID_1152_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TR_GTCfPID_1152 for attribute P_L5TR_GTCfPID_1152
		[DataContract]
		public class P_L5TR_GTCfPID_1152 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] PatientID { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTCfPID_1152 for attribute L5TR_GTCfPID_1152
		[DataContract]
		public class L5TR_GTCfPID_1152 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public int treatmentCount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GTCfPID_1152_Array cls_Get_TreatmentCount_for_PatientIDlist(,P_L5TR_GTCfPID_1152 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GTCfPID_1152_Array invocationResult = cls_Get_TreatmentCount_for_PatientIDlist.Invoke(connectionString,P_L5TR_GTCfPID_1152 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Treatments.Complex.Retrieval.P_L5TR_GTCfPID_1152();
parameter.PatientID = ...;

*/
