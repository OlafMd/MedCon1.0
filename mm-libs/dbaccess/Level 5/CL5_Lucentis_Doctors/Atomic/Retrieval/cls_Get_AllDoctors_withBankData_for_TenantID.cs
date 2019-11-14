/* 
 * Generated on 2/6/2014 9:26:51 AM
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

namespace CL5_Lucentis_Doctors.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllDoctors_withBankData_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDoctors_withBankData_for_TenantID
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_GADwBDfTID_2213_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_GADwBDfTID_2213_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Doctors.Atomic.Retrieval.SQL.cls_Get_AllDoctors_withBankData_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<GADwBDfTID_2213_raw> results = new List<GADwBDfTID_2213_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","LANR","FirstName","LastName","PrimaryEmail","Account_RefID","BankName","BICCode","RoutingNumber","BankNumber","AccountNumber","IBAN","OwnerText" });
				while(reader.Read())
				{
					GADwBDfTID_2213_raw resultItem = new GADwBDfTID_2213_raw();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter LANR of type String
					resultItem.LANR = reader.GetString(1);
					//2:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(2);
					//3:Parameter LastName of type String
					resultItem.LastName = reader.GetString(3);
					//4:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(4);
					//5:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(5);
					//6:Parameter BankName of type String
					resultItem.BankName = reader.GetString(6);
					//7:Parameter BICCode of type String
					resultItem.BICCode = reader.GetString(7);
					//8:Parameter RoutingNumber of type String
					resultItem.RoutingNumber = reader.GetString(8);
					//9:Parameter BankNumber of type String
					resultItem.BankNumber = reader.GetString(9);
					//10:Parameter AccountNumber of type String
					resultItem.AccountNumber = reader.GetString(10);
					//11:Parameter IBAN of type String
					resultItem.IBAN = reader.GetString(11);
					//12:Parameter OwnerText of type String
					resultItem.OwnerText = reader.GetString(12);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllDoctors_withBankData_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = GADwBDfTID_2213_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_GADwBDfTID_2213_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_GADwBDfTID_2213_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_GADwBDfTID_2213_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_GADwBDfTID_2213_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_GADwBDfTID_2213_Array functionReturn = new FR_GADwBDfTID_2213_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllDoctors_withBankData_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class GADwBDfTID_2213_raw 
	{
		public Guid HEC_DoctorID; 
		public String LANR; 
		public String FirstName; 
		public String LastName; 
		public String PrimaryEmail; 
		public Guid Account_RefID; 
		public String BankName; 
		public String BICCode; 
		public String RoutingNumber; 
		public String BankNumber; 
		public String AccountNumber; 
		public String IBAN; 
		public String OwnerText; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static GADwBDfTID_2213[] Convert(List<GADwBDfTID_2213_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_GADwBDfTID_2213 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DoctorID)).ToArray()
	group el_GADwBDfTID_2213 by new 
	{ 
		el_GADwBDfTID_2213.HEC_DoctorID,

	}
	into gfunct_GADwBDfTID_2213
	select new GADwBDfTID_2213
	{     
		HEC_DoctorID = gfunct_GADwBDfTID_2213.Key.HEC_DoctorID ,
		LANR = gfunct_GADwBDfTID_2213.FirstOrDefault().LANR ,
		FirstName = gfunct_GADwBDfTID_2213.FirstOrDefault().FirstName ,
		LastName = gfunct_GADwBDfTID_2213.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_GADwBDfTID_2213.FirstOrDefault().PrimaryEmail ,
		Account_RefID = gfunct_GADwBDfTID_2213.FirstOrDefault().Account_RefID ,
		BankName = gfunct_GADwBDfTID_2213.FirstOrDefault().BankName ,
		BICCode = gfunct_GADwBDfTID_2213.FirstOrDefault().BICCode ,
		RoutingNumber = gfunct_GADwBDfTID_2213.FirstOrDefault().RoutingNumber ,
		BankNumber = gfunct_GADwBDfTID_2213.FirstOrDefault().BankNumber ,
		AccountNumber = gfunct_GADwBDfTID_2213.FirstOrDefault().AccountNumber ,
		IBAN = gfunct_GADwBDfTID_2213.FirstOrDefault().IBAN ,
		OwnerText = gfunct_GADwBDfTID_2213.FirstOrDefault().OwnerText ,

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_GADwBDfTID_2213_Array : FR_Base
	{
		public GADwBDfTID_2213[] Result	{ get; set; } 
		public FR_GADwBDfTID_2213_Array() : base() {}

		public FR_GADwBDfTID_2213_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass GADwBDfTID_2213 for attribute GADwBDfTID_2213
		[DataContract]
		public class GADwBDfTID_2213 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public String LANR { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 
			[DataMember]
			public String BankName { get; set; } 
			[DataMember]
			public String BICCode { get; set; } 
			[DataMember]
			public String RoutingNumber { get; set; } 
			[DataMember]
			public String BankNumber { get; set; } 
			[DataMember]
			public String AccountNumber { get; set; } 
			[DataMember]
			public String IBAN { get; set; } 
			[DataMember]
			public String OwnerText { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_GADwBDfTID_2213_Array cls_Get_AllDoctors_withBankData_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_GADwBDfTID_2213_Array invocationResult = cls_Get_AllDoctors_withBankData_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

