/* 
 * Generated on 3/12/2015 2:54:03 PM
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
    /// var result = cls_ParameterTypes_for_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_ParameterTypes_for_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3_PTfT_1429_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3_PTfT_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3_PTfT_1429_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CLE_L3_PatientParameters.Atomic.Retrieval.SQL.cls_ParameterTypes_for_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Tenant", Parameter.Tenant);



			List<L3_PTfT_1429> results = new List<L3_PTfT_1429>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_ParameterID","PatientParameterITL","GlobalPropertyMatchingID","Parameter_Name_DictID","IsFloat","IsFloat_ApplicableUnit_RefID","IsString","IsVitalParameter","Creation_Timestamp","Tenant_RefID","IsDeleted","HasHighRelevance","Modification_Timestamp","ParameterType_RefID","HEC_Patient_ParameterTypeID","GlobalPropertyMatchingIDParameterTypes","Name_DictID","Creation_TimestampParameterTypes","IsDeletedParameterTypes","Modification_TimestampParameterTypes","IfFloat_MinValue","IfFloat_MaxValue" });
				while(reader.Read())
				{
					L3_PTfT_1429 resultItem = new L3_PTfT_1429();
					//0:Parameter HEC_Patient_ParameterID of type Guid
					resultItem.HEC_Patient_ParameterID = reader.GetGuid(0);
					//1:Parameter PatientParameterITL of type String
					resultItem.PatientParameterITL = reader.GetString(1);
					//2:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(2);
					//3:Parameter Parameter_Name of type Dict
					resultItem.Parameter_Name = reader.GetDictionary(3);
					resultItem.Parameter_Name.SourceTable = "hec_patient_parameters";
					loader.Append(resultItem.Parameter_Name);
					//4:Parameter IsFloat of type bool
					resultItem.IsFloat = reader.GetBoolean(4);
					//5:Parameter IsFloat_ApplicableUnit_RefID of type Guid
					resultItem.IsFloat_ApplicableUnit_RefID = reader.GetGuid(5);
					//6:Parameter IsString of type bool
					resultItem.IsString = reader.GetBoolean(6);
					//7:Parameter IsVitalParameter of type bool
					resultItem.IsVitalParameter = reader.GetBoolean(7);
					//8:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(8);
					//9:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(9);
					//10:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(10);
					//11:Parameter HasHighRelevance of type bool
					resultItem.HasHighRelevance = reader.GetBoolean(11);
					//12:Parameter Modification_Timestamp of type DateTime
					resultItem.Modification_Timestamp = reader.GetDate(12);
					//13:Parameter ParameterType_RefID of type Guid
					resultItem.ParameterType_RefID = reader.GetGuid(13);
					//14:Parameter HEC_Patient_ParameterTypeID of type Guid
					resultItem.HEC_Patient_ParameterTypeID = reader.GetGuid(14);
					//15:Parameter GlobalPropertyMatchingIDParameterTypes of type String
					resultItem.GlobalPropertyMatchingIDParameterTypes = reader.GetString(15);
					//16:Parameter Name of type Dict
					resultItem.Name = reader.GetDictionary(16);
					resultItem.Name.SourceTable = "hec_patient_parametertypes";
					loader.Append(resultItem.Name);
					//17:Parameter Creation_TimestampParameterTypes of type DateTime
					resultItem.Creation_TimestampParameterTypes = reader.GetDate(17);
					//18:Parameter IsDeletedParameterTypes of type bool
					resultItem.IsDeletedParameterTypes = reader.GetBoolean(18);
					//19:Parameter Modification_TimestampParameterTypes of type DateTime
					resultItem.Modification_TimestampParameterTypes = reader.GetDate(19);
					//20:Parameter IfFloat_MinValue of type double
					resultItem.IfFloat_MinValue = reader.GetDouble(20);
					//21:Parameter IfFloat_MaxValue of type double
					resultItem.IfFloat_MaxValue = reader.GetDouble(21);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_ParameterTypes_for_Tenant",ex);
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
		public static FR_L3_PTfT_1429_Array Invoke(string ConnectionString,P_L3_PTfT_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3_PTfT_1429_Array Invoke(DbConnection Connection,P_L3_PTfT_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3_PTfT_1429_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3_PTfT_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3_PTfT_1429_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3_PTfT_1429 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3_PTfT_1429_Array functionReturn = new FR_L3_PTfT_1429_Array();
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

				throw new Exception("Exception occured in method cls_ParameterTypes_for_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3_PTfT_1429_Array : FR_Base
	{
		public L3_PTfT_1429[] Result	{ get; set; } 
		public FR_L3_PTfT_1429_Array() : base() {}

		public FR_L3_PTfT_1429_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3_PTfT_1429 for attribute P_L3_PTfT_1429
		[DataContract]
		public class P_L3_PTfT_1429 
		{
			//Standard type parameters
			[DataMember]
			public Guid Tenant { get; set; } 

		}
		#endregion
		#region SClass L3_PTfT_1429 for attribute L3_PTfT_1429
		[DataContract]
		public class L3_PTfT_1429 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_ParameterID { get; set; } 
			[DataMember]
			public String PatientParameterITL { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public Dict Parameter_Name { get; set; } 
			[DataMember]
			public bool IsFloat { get; set; } 
			[DataMember]
			public Guid IsFloat_ApplicableUnit_RefID { get; set; } 
			[DataMember]
			public bool IsString { get; set; } 
			[DataMember]
			public bool IsVitalParameter { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool HasHighRelevance { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 
			[DataMember]
			public Guid ParameterType_RefID { get; set; } 
			[DataMember]
			public Guid HEC_Patient_ParameterTypeID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingIDParameterTypes { get; set; } 
			[DataMember]
			public Dict Name { get; set; } 
			[DataMember]
			public DateTime Creation_TimestampParameterTypes { get; set; } 
			[DataMember]
			public bool IsDeletedParameterTypes { get; set; } 
			[DataMember]
			public DateTime Modification_TimestampParameterTypes { get; set; } 
			[DataMember]
			public double IfFloat_MinValue { get; set; } 
			[DataMember]
			public double IfFloat_MaxValue { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3_PTfT_1429_Array cls_ParameterTypes_for_Tenant(,P_L3_PTfT_1429 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3_PTfT_1429_Array invocationResult = cls_ParameterTypes_for_Tenant.Invoke(connectionString,P_L3_PTfT_1429 Parameter,securityTicket);
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
var parameter = new CLE_L3_PatientParameters.Atomic.Retrieval.P_L3_PTfT_1429();
parameter.Tenant = ...;

*/
