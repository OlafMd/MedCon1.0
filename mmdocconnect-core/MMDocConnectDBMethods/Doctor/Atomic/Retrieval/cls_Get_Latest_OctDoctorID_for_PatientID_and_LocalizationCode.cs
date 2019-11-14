/* 
 * Generated on 12/13/16 08:43:17
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

namespace MMDocConnectDBMethods.Doctor.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_DO_GLOctDIDfPIDaLC_1939 Execute(DbConnection Connection,DbTransaction Transaction,P_DO_GLOctDIDfPIDaLC_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_DO_GLOctDIDfPIDaLC_1939();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Doctor.Atomic.Retrieval.SQL.cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OctPlannedActionTypeID", Parameter.OctPlannedActionTypeID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"LocalizationCode", Parameter.LocalizationCode);



			List<DO_GLOctDIDfPIDaLC_1939> results = new List<DO_GLOctDIDfPIDaLC_1939>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "oct_doctor_id" });
				while(reader.Read())
				{
					DO_GLOctDIDfPIDaLC_1939 resultItem = new DO_GLOctDIDfPIDaLC_1939();
					//0:Parameter oct_doctor_id of type Guid
					resultItem.oct_doctor_id = reader.GetGuid(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode",ex);
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
		public static FR_DO_GLOctDIDfPIDaLC_1939 Invoke(string ConnectionString,P_DO_GLOctDIDfPIDaLC_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_DO_GLOctDIDfPIDaLC_1939 Invoke(DbConnection Connection,P_DO_GLOctDIDfPIDaLC_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_DO_GLOctDIDfPIDaLC_1939 Invoke(DbConnection Connection, DbTransaction Transaction,P_DO_GLOctDIDfPIDaLC_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_DO_GLOctDIDfPIDaLC_1939 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_DO_GLOctDIDfPIDaLC_1939 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_DO_GLOctDIDfPIDaLC_1939 functionReturn = new FR_DO_GLOctDIDfPIDaLC_1939();
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

				throw new Exception("Exception occured in method cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_DO_GLOctDIDfPIDaLC_1939 : FR_Base
	{
		public DO_GLOctDIDfPIDaLC_1939 Result	{ get; set; }

		public FR_DO_GLOctDIDfPIDaLC_1939() : base() {}

		public FR_DO_GLOctDIDfPIDaLC_1939(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_DO_GLOctDIDfPIDaLC_1939 for attribute P_DO_GLOctDIDfPIDaLC_1939
		[DataContract]
		public class P_DO_GLOctDIDfPIDaLC_1939 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public Guid OctPlannedActionTypeID { get; set; } 
			[DataMember]
			public String LocalizationCode { get; set; } 

		}
		#endregion
		#region SClass DO_GLOctDIDfPIDaLC_1939 for attribute DO_GLOctDIDfPIDaLC_1939
		[DataContract]
		public class DO_GLOctDIDfPIDaLC_1939 
		{
			//Standard type parameters
			[DataMember]
			public Guid oct_doctor_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_DO_GLOctDIDfPIDaLC_1939 cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode(,P_DO_GLOctDIDfPIDaLC_1939 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_DO_GLOctDIDfPIDaLC_1939 invocationResult = cls_Get_Latest_OctDoctorID_for_PatientID_and_LocalizationCode.Invoke(connectionString,P_DO_GLOctDIDfPIDaLC_1939 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Retrieval.P_DO_GLOctDIDfPIDaLC_1939();
parameter.PatientID = ...;
parameter.OctPlannedActionTypeID = ...;
parameter.LocalizationCode = ...;

*/
