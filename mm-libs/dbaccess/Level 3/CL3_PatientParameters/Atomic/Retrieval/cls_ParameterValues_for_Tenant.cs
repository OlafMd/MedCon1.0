/* 
 * Generated on 10/10/2014 10:36:09 AM
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

namespace CLE_L3_PatientParameters.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_ParameterValues_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_ParameterValues_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_PVfT_1458_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_PVfT_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_PVfT_1458_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CLE_L3_PatientParameters.Atomic.Retrieval.SQL.cls_ParameterValues_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L3_PVfT_1458> results = new List<L3_PVfT_1458>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_ParameterValueID","Patient_RefID","PatientParameter_RefID","IsConfirmed","DateOfValue","ConfirmedBy_Doctor_RefID","EnteredBy_Doctor_RefID","DateOfEntry","StringValue","FloatValue","Creation_Timestamp","Tenant_RefID","IsDeleted","GlobalPropertyMatchingID","Modification_TimestampPatientParameters","Modification_TimestampParameterValues" });
				while(reader.Read())
				{
					L3_PVfT_1458 resultItem = new L3_PVfT_1458();
					//0:Parameter HEC_Patient_ParameterValueID of type Guid
					resultItem.HEC_Patient_ParameterValueID = reader.GetGuid(0);
					//1:Parameter Patient_RefID of type Guid
					resultItem.Patient_RefID = reader.GetGuid(1);
					//2:Parameter PatientParameter_RefID of type Guid
					resultItem.PatientParameter_RefID = reader.GetGuid(2);
					//3:Parameter IsConfirmed of type bool
					resultItem.IsConfirmed = reader.GetBoolean(3);
					//4:Parameter DateOfValue of type DateTime
					resultItem.DateOfValue = reader.GetDate(4);
					//5:Parameter ConfirmedBy_Doctor_RefID of type Guid
					resultItem.ConfirmedBy_Doctor_RefID = reader.GetGuid(5);
					//6:Parameter EnteredBy_Doctor_RefID of type Guid
					resultItem.EnteredBy_Doctor_RefID = reader.GetGuid(6);
					//7:Parameter DateOfEntry of type DateTime
					resultItem.DateOfEntry = reader.GetDate(7);
					//8:Parameter StringValue of type String
					resultItem.StringValue = reader.GetString(8);
					//9:Parameter FloatValue of type double
					resultItem.FloatValue = reader.GetDouble(9);
					//10:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(10);
					//11:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(11);
					//12:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(12);
					//13:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(13);
					//14:Parameter Modification_TimestampPatientParameters of type DateTime
					resultItem.Modification_TimestampPatientParameters = reader.GetDate(14);
					//15:Parameter Modification_TimestampParameterValues of type DateTime
					resultItem.Modification_TimestampParameterValues = reader.GetDate(15);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_ParameterValues_for_Tenant",ex);
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
		public static FR_L3_PVfT_1458_Array Invoke(string ConnectionString,P_L3_PVfT_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_PVfT_1458_Array Invoke(DbConnection Connection,P_L3_PVfT_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_PVfT_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_PVfT_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_PVfT_1458_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_PVfT_1458 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_PVfT_1458_Array functionReturn = new FR_L3_PVfT_1458_Array();
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

				throw new Exception("Exception occured in method cls_ParameterValues_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_PVfT_1458_Array : FR_Base
	{
		public L3_PVfT_1458[] Result	{ get; set; } 
		public FR_L3_PVfT_1458_Array() : base() {}

		public FR_L3_PVfT_1458_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_PVfT_1458 for attribute P_L3_PVfT_1458
		[DataContract]
		public class P_L3_PVfT_1458 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L3_PVfT_1458 for attribute L3_PVfT_1458
		[DataContract]
		public class L3_PVfT_1458 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_ParameterValueID { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public Guid PatientParameter_RefID { get; set; } 
			[DataMember]
			public bool IsConfirmed { get; set; } 
			[DataMember]
			public DateTime DateOfValue { get; set; } 
			[DataMember]
			public Guid ConfirmedBy_Doctor_RefID { get; set; } 
			[DataMember]
			public Guid EnteredBy_Doctor_RefID { get; set; } 
			[DataMember]
			public DateTime DateOfEntry { get; set; } 
			[DataMember]
			public String StringValue { get; set; } 
			[DataMember]
			public double FloatValue { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampPatientParameters { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampParameterValues { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_PVfT_1458_Array cls_ParameterValues_for_Tenant(,P_L3_PVfT_1458 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_PVfT_1458_Array invocationResult = cls_ParameterValues_for_Tenant.Invoke(connectionString,P_L3_PVfT_1458 Parameter,securityTicket);
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
var parameter = new CLE_L3_PatientParameters.Atomic.Retrieval.P_L3_PVfT_1458();
parameter.Tenant = ...;

*/
