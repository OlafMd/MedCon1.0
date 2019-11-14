/* 
 * Generated on 2/19/2014 3:32:27 PM
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

namespace CL5_Lucentis_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllHealthInsuranceCompanies_for_Patient.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllHealthInsuranceCompanies_for_Patient
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GAHICfP_1137_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GAHICfP_1137_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Patient.Atomic.Retrieval.SQL.cls_Get_AllHealthInsuranceCompanies_for_Patient.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PA_GAHICfP_1137_raw> results = new List<L5PA_GAHICfP_1137_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_HealthInsurance_CompanyID","CompanyName","HealthInsurance_IKNumber" });
				while(reader.Read())
				{
					L5PA_GAHICfP_1137_raw resultItem = new L5PA_GAHICfP_1137_raw();
					//0:Parameter HEC_HealthInsurance_CompanyID of type Guid
					resultItem.HEC_HealthInsurance_CompanyID = reader.GetGuid(0);
					//1:Parameter CompanyName of type String
					resultItem.CompanyName = reader.GetString(1);
					//2:Parameter HealthInsurance_IKNumber of type String
					resultItem.HealthInsurance_IKNumber = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllHealthInsuranceCompanies_for_Patient",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PA_GAHICfP_1137_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GAHICfP_1137_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GAHICfP_1137_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GAHICfP_1137_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GAHICfP_1137_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GAHICfP_1137_Array functionReturn = new FR_L5PA_GAHICfP_1137_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllHealthInsuranceCompanies_for_Patient",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PA_GAHICfP_1137_raw 
	{
		public Guid HEC_HealthInsurance_CompanyID; 
		public String CompanyName; 
		public String HealthInsurance_IKNumber; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PA_GAHICfP_1137[] Convert(List<L5PA_GAHICfP_1137_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PA_GAHICfP_1137 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_HealthInsurance_CompanyID)).ToArray()
	group el_L5PA_GAHICfP_1137 by new 
	{ 
		el_L5PA_GAHICfP_1137.HEC_HealthInsurance_CompanyID,

	}
	into gfunct_L5PA_GAHICfP_1137
	select new L5PA_GAHICfP_1137
	{     
		HEC_HealthInsurance_CompanyID = gfunct_L5PA_GAHICfP_1137.Key.HEC_HealthInsurance_CompanyID ,
		CompanyName = gfunct_L5PA_GAHICfP_1137.FirstOrDefault().CompanyName ,
		HealthInsurance_IKNumber = gfunct_L5PA_GAHICfP_1137.FirstOrDefault().HealthInsurance_IKNumber ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GAHICfP_1137_Array : FR_Base
	{
		public L5PA_GAHICfP_1137[] Result	{ get; set; } 
		public FR_L5PA_GAHICfP_1137_Array() : base() {}

		public FR_L5PA_GAHICfP_1137_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PA_GAHICfP_1137 for attribute L5PA_GAHICfP_1137
		[DataContract]
		public class L5PA_GAHICfP_1137 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_HealthInsurance_CompanyID { get; set; } 
			[DataMember]
			public String CompanyName { get; set; } 
			[DataMember]
			public String HealthInsurance_IKNumber { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GAHICfP_1137_Array cls_Get_AllHealthInsuranceCompanies_for_Patient(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GAHICfP_1137_Array invocationResult = cls_Get_AllHealthInsuranceCompanies_for_Patient.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

