/* 
 * Generated on 5/19/2014 11:41:53 AM
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
    /// var result = cls_Get_AllPatientsSimpleData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPatientsSimpleData_for_TenantID
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L5PA_GPSDfTID_2257_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPSDfTID_2257_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Patient.Atomic.Retrieval.SQL.cls_Get_AllPatientsSimpleData_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5PA_GPSDfTID_2257_raw> results = new List<L5PA_GPSDfTID_2257_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_PatientID","FirstName","LastName","BirthDate","HealthInsurance_Number","InsuranceStateCode","Gender","HICompanyName" });
				while(reader.Read())
				{
					L5PA_GPSDfTID_2257_raw resultItem = new L5PA_GPSDfTID_2257_raw();
					//0:Parameter HEC_PatientID of type Guid
					resultItem.HEC_PatientID = reader.GetGuid(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter BirthDate of type DateTime
					resultItem.BirthDate = reader.GetDate(3);
					//4:Parameter HealthInsurance_Number of type String
					resultItem.HealthInsurance_Number = reader.GetString(4);
					//5:Parameter InsuranceStateCode of type String
					resultItem.InsuranceStateCode = reader.GetString(5);
					//6:Parameter Gender of type int
					resultItem.Gender = reader.GetInteger(6);
					//7:Parameter HICompanyName of type String
					resultItem.HICompanyName = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllPatientsSimpleData_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PA_GPSDfTID_2257_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPSDfTID_2257_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPSDfTID_2257_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPSDfTID_2257_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPSDfTID_2257_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPSDfTID_2257_Array functionReturn = new FR_L5PA_GPSDfTID_2257_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllPatientsSimpleData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PA_GPSDfTID_2257_raw 
	{
		public Guid HEC_PatientID; 
		public String FirstName; 
		public String LastName; 
		public DateTime BirthDate; 
		public String HealthInsurance_Number; 
		public String InsuranceStateCode; 
		public int Gender; 
		public String HICompanyName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PA_GPSDfTID_2257[] Convert(List<L5PA_GPSDfTID_2257_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PA_GPSDfTID_2257 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_PatientID)).ToArray()
	group el_L5PA_GPSDfTID_2257 by new 
	{ 
		el_L5PA_GPSDfTID_2257.HEC_PatientID,

	}
	into gfunct_L5PA_GPSDfTID_2257
	select new L5PA_GPSDfTID_2257
	{     
		HEC_PatientID = gfunct_L5PA_GPSDfTID_2257.Key.HEC_PatientID ,
		FirstName = gfunct_L5PA_GPSDfTID_2257.FirstOrDefault().FirstName ,
		LastName = gfunct_L5PA_GPSDfTID_2257.FirstOrDefault().LastName ,
		BirthDate = gfunct_L5PA_GPSDfTID_2257.FirstOrDefault().BirthDate ,
		HealthInsurance_Number = gfunct_L5PA_GPSDfTID_2257.FirstOrDefault().HealthInsurance_Number ,
		InsuranceStateCode = gfunct_L5PA_GPSDfTID_2257.FirstOrDefault().InsuranceStateCode ,
		Gender = gfunct_L5PA_GPSDfTID_2257.FirstOrDefault().Gender ,
		HICompanyName = gfunct_L5PA_GPSDfTID_2257.FirstOrDefault().HICompanyName ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPSDfTID_2257_Array : FR_Base
	{
		public L5PA_GPSDfTID_2257[] Result	{ get; set; } 
		public FR_L5PA_GPSDfTID_2257_Array() : base() {}

		public FR_L5PA_GPSDfTID_2257_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5PA_GPSDfTID_2257 for attribute L5PA_GPSDfTID_2257
		[DataContract]
		public class L5PA_GPSDfTID_2257 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_PatientID { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public DateTime BirthDate { get; set; } 
			[DataMember]
			public String HealthInsurance_Number { get; set; } 
			[DataMember]
			public String InsuranceStateCode { get; set; } 
			[DataMember]
			public int Gender { get; set; } 
			[DataMember]
			public String HICompanyName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GPSDfTID_2257_Array cls_Get_AllPatientsSimpleData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPSDfTID_2257_Array invocationResult = cls_Get_AllPatientsSimpleData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
