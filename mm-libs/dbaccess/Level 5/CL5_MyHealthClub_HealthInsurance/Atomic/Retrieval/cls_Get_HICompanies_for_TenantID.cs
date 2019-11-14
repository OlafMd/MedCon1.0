/* 
 * Generated on 23.10.2014 17:38:44
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
    /// var result = cls_Get_HICompanies_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_HICompanies_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5HI_GHICaTID_1450_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5HI_GHICaTID_1450_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_HealthInsurance.Atomic.Retrieval.SQL.cls_Get_HICompanies_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5HI_GHICaTID_1450_raw> results = new List<L5HI_GHICaTID_1450_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HealthInsurance_IKNumber","DisplayName","HEC_HealthInsurance_CompanyID" });
				while(reader.Read())
				{
					L5HI_GHICaTID_1450_raw resultItem = new L5HI_GHICaTID_1450_raw();
					//0:Parameter HealthInsurance_IKNumber of type String
					resultItem.HealthInsurance_IKNumber = reader.GetString(0);
					//1:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(1);
					//2:Parameter HEC_HealthInsurance_CompanyID of type Guid
					resultItem.HEC_HealthInsurance_CompanyID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_HICompanies_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5HI_GHICaTID_1450_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5HI_GHICaTID_1450_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5HI_GHICaTID_1450_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5HI_GHICaTID_1450_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5HI_GHICaTID_1450_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5HI_GHICaTID_1450_Array functionReturn = new FR_L5HI_GHICaTID_1450_Array();
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

				throw new Exception("Exception occured in method cls_Get_HICompanies_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5HI_GHICaTID_1450_raw 
	{
		public String HealthInsurance_IKNumber; 
		public String DisplayName; 
		public Guid HEC_HealthInsurance_CompanyID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5HI_GHICaTID_1450[] Convert(List<L5HI_GHICaTID_1450_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5HI_GHICaTID_1450 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_HealthInsurance_CompanyID)).ToArray()
	group el_L5HI_GHICaTID_1450 by new 
	{ 
		el_L5HI_GHICaTID_1450.HEC_HealthInsurance_CompanyID,

	}
	into gfunct_L5HI_GHICaTID_1450
	select new L5HI_GHICaTID_1450
	{     
		HealthInsurance_IKNumber = gfunct_L5HI_GHICaTID_1450.FirstOrDefault().HealthInsurance_IKNumber ,
		DisplayName = gfunct_L5HI_GHICaTID_1450.FirstOrDefault().DisplayName ,
		HEC_HealthInsurance_CompanyID = gfunct_L5HI_GHICaTID_1450.Key.HEC_HealthInsurance_CompanyID ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5HI_GHICaTID_1450_Array : FR_Base
	{
		public L5HI_GHICaTID_1450[] Result	{ get; set; } 
		public FR_L5HI_GHICaTID_1450_Array() : base() {}

		public FR_L5HI_GHICaTID_1450_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5HI_GHICaTID_1450 for attribute L5HI_GHICaTID_1450
		[DataContract]
		public class L5HI_GHICaTID_1450 
		{
			//Standard type parameters
			[DataMember]
			public String HealthInsurance_IKNumber { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 
			[DataMember]
			public Guid HEC_HealthInsurance_CompanyID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5HI_GHICaTID_1450_Array cls_Get_HICompanies_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5HI_GHICaTID_1450_Array invocationResult = cls_Get_HICompanies_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

