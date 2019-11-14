/* 
 * Generated on 6/26/2013 1:39:42 PM
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

namespace CL6_BBV_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BBV_PatientsSimpleInfo_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BBV_PatientsSimpleInfo_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PA_GPSIfT_1055_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6PA_GPSIfT_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PA_GPSIfT_1055_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_BBV_Patient.Atomic.Retrieval.SQL.cls_Get_BBV_PatientsSimpleInfo_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"IncludeOnlyConfirmedPolicy", Parameter.IncludeOnlyConfirmedPolicy);


			List<L6PA_GPSIfT_1055> results = new List<L6PA_GPSIfT_1055>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_PatientID","FirstName","LastName","Salutation_General","CMN_BPT_BusinessParticipantID","HealthInsurance_Number","IsPatientParticipationPolicyValidated" });
				while(reader.Read())
				{
					L6PA_GPSIfT_1055 resultItem = new L6PA_GPSIfT_1055();
					//0:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter Salutation_General of type String
					resultItem.Salutation_General = reader.GetString(3);
					//4:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(4);
					//5:Parameter HealthInsurance_Number of type String
					resultItem.HealthInsurance_Number = reader.GetString(5);
					//6:Parameter IsPatientParticipationPolicyValidated of type bool
					resultItem.IsPatientParticipationPolicyValidated = reader.GetBoolean(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L6PA_GPSIfT_1055_Array Invoke(string ConnectionString,P_L6PA_GPSIfT_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PA_GPSIfT_1055_Array Invoke(DbConnection Connection,P_L6PA_GPSIfT_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PA_GPSIfT_1055_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PA_GPSIfT_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PA_GPSIfT_1055_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PA_GPSIfT_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PA_GPSIfT_1055_Array functionReturn = new FR_L6PA_GPSIfT_1055_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6PA_GPSIfT_1055_Array : FR_Base
	{
		public L6PA_GPSIfT_1055[] Result	{ get; set; } 
		public FR_L6PA_GPSIfT_1055_Array() : base() {}

		public FR_L6PA_GPSIfT_1055_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PA_GPSIfT_1055 for attribute P_L6PA_GPSIfT_1055
		[DataContract]
		public class P_L6PA_GPSIfT_1055 
		{
			//Standard type parameters
			[DataMember]
			public Boolean IncludeOnlyConfirmedPolicy { get; set; } 

		}
		#endregion
		#region SClass L6PA_GPSIfT_1055 for attribute L6PA_GPSIfT_1055
		[DataContract]
		public class L6PA_GPSIfT_1055 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String Salutation_General { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 
			[DataMember]
			public String HealthInsurance_Number { get; set; } 
			[DataMember]
			public bool IsPatientParticipationPolicyValidated { get; set; } 

		}
		#endregion

	#endregion
}
