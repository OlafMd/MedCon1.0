/* 
 * Generated on 26.06.2014 16:09:39
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

namespace CL5_MyHealthClub_HealthInsurance.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_HIStates_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_HIStates_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5HI_GHISaTID_1452_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5HI_GHISaTID_1452_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_HealthInsurance.Atomic.Retrieval.SQL.cls_Get_HIStates_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5HI_GHISaTID_1452_raw> results = new List<L5HI_GHISaTID_1452_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HealthInsuranceState_Abbreviation","HealthInsuranceState_Name_DictID","HEC_Patient_HealthInsurance_StateID" });
				while(reader.Read())
				{
					L5HI_GHISaTID_1452_raw resultItem = new L5HI_GHISaTID_1452_raw();
					//0:Parameter HealthInsuranceState_Abbreviation of type String
					resultItem.HealthInsuranceState_Abbreviation = reader.GetString(0);
					//1:Parameter HealthInsuranceState_Name of type Dict
					resultItem.HealthInsuranceState_Name = reader.GetDictionary(1);
					resultItem.HealthInsuranceState_Name.SourceTable = "hec_patient_healthinsurance_states";
					loader.Append(resultItem.HealthInsuranceState_Name);
					//2:Parameter HEC_Patient_HealthInsurance_StateID of type Guid
					resultItem.HEC_Patient_HealthInsurance_StateID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_HIStates_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5HI_GHISaTID_1452_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5HI_GHISaTID_1452_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5HI_GHISaTID_1452_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5HI_GHISaTID_1452_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5HI_GHISaTID_1452_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5HI_GHISaTID_1452_Array functionReturn = new FR_L5HI_GHISaTID_1452_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_HIStates_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5HI_GHISaTID_1452_raw 
	{
		public String HealthInsuranceState_Abbreviation; 
		public Dict HealthInsuranceState_Name; 
		public Guid HEC_Patient_HealthInsurance_StateID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5HI_GHISaTID_1452[] Convert(List<L5HI_GHISaTID_1452_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5HI_GHISaTID_1452 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_Patient_HealthInsurance_StateID)).ToArray()
	group el_L5HI_GHISaTID_1452 by new 
	{ 
		el_L5HI_GHISaTID_1452.HEC_Patient_HealthInsurance_StateID,

	}
	into gfunct_L5HI_GHISaTID_1452
	select new L5HI_GHISaTID_1452
	{     
		HealthInsuranceState_Abbreviation = gfunct_L5HI_GHISaTID_1452.FirstOrDefault().HealthInsuranceState_Abbreviation ,
		HealthInsuranceState_Name = gfunct_L5HI_GHISaTID_1452.FirstOrDefault().HealthInsuranceState_Name ,
		HEC_Patient_HealthInsurance_StateID = gfunct_L5HI_GHISaTID_1452.Key.HEC_Patient_HealthInsurance_StateID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5HI_GHISaTID_1452_Array : FR_Base
	{
		public L5HI_GHISaTID_1452[] Result	{ get; set; } 
		public FR_L5HI_GHISaTID_1452_Array() : base() {}

		public FR_L5HI_GHISaTID_1452_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5HI_GHISaTID_1452 for attribute L5HI_GHISaTID_1452
		[DataContract]
		public class L5HI_GHISaTID_1452 
		{
			//Standard type parameters
			[DataMember]
			public String HealthInsuranceState_Abbreviation { get; set; } 
			[DataMember]
			public Dict HealthInsuranceState_Name { get; set; } 
			[DataMember]
			public Guid HEC_Patient_HealthInsurance_StateID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5HI_GHISaTID_1452_Array cls_Get_HIStates_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5HI_GHISaTID_1452_Array invocationResult = cls_Get_HIStates_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

