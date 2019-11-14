/* 
 * Generated on 13.06.2014 14:47:38
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
    /// var result = cls_Get_AllDoctors_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDoctors_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_GADfTID_1642_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_GADfTID_1642_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Doctors.Atomic.Retrieval.SQL.cls_Get_AllDoctors_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<GADfTID_1642_raw> results = new List<GADfTID_1642_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","LANR","FirstName","LastName","PrimaryEmail","Account_RefID","HEC_MedicalPractiseID","PracticeName","PracticeID" });
				while(reader.Read())
				{
					GADfTID_1642_raw resultItem = new GADfTID_1642_raw();
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
					//6:Parameter HEC_MedicalPractiseID of type Guid
					resultItem.HEC_MedicalPractiseID = reader.GetGuid(6);
					//7:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(7);
					//8:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllDoctors_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = GADfTID_1642_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_GADfTID_1642_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_GADfTID_1642_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_GADfTID_1642_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_GADfTID_1642_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_GADfTID_1642_Array functionReturn = new FR_GADfTID_1642_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllDoctors_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class GADfTID_1642_raw 
	{
		public Guid HEC_DoctorID; 
		public String LANR; 
		public String FirstName; 
		public String LastName; 
		public String PrimaryEmail; 
		public Guid Account_RefID; 
		public Guid HEC_MedicalPractiseID; 
		public String PracticeName; 
		public Guid PracticeID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static GADfTID_1642[] Convert(List<GADfTID_1642_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_GADfTID_1642 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DoctorID)).ToArray()
	group el_GADfTID_1642 by new 
	{ 
		el_GADfTID_1642.HEC_DoctorID,

	}
	into gfunct_GADfTID_1642
	select new GADfTID_1642
	{     
		HEC_DoctorID = gfunct_GADfTID_1642.Key.HEC_DoctorID ,
		LANR = gfunct_GADfTID_1642.FirstOrDefault().LANR ,
		FirstName = gfunct_GADfTID_1642.FirstOrDefault().FirstName ,
		LastName = gfunct_GADfTID_1642.FirstOrDefault().LastName ,
		PrimaryEmail = gfunct_GADfTID_1642.FirstOrDefault().PrimaryEmail ,
		Account_RefID = gfunct_GADfTID_1642.FirstOrDefault().Account_RefID ,

		Practices = 
		(
			from el_Practices in gfunct_GADfTID_1642.Where(element => !EqualsDefaultValue(element.PracticeID)).ToArray()
			group el_Practices by new 
			{ 
				el_Practices.PracticeID,

			}
			into gfunct_Practices
			select new GADfTID_1642_Practices
			{     
				HEC_MedicalPractiseID = gfunct_Practices.FirstOrDefault().HEC_MedicalPractiseID ,
				PracticeName = gfunct_Practices.FirstOrDefault().PracticeName ,
				PracticeID = gfunct_Practices.Key.PracticeID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_GADfTID_1642_Array : FR_Base
	{
		public GADfTID_1642[] Result	{ get; set; } 
		public FR_GADfTID_1642_Array() : base() {}

		public FR_GADfTID_1642_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass GADfTID_1642 for attribute GADfTID_1642
		[DataContract]
		public class GADfTID_1642 
		{
			[DataMember]
			public GADfTID_1642_Practices[] Practices { get; set; }

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

		}
		#endregion
		#region SClass GADfTID_1642_Practices for attribute Practices
		[DataContract]
		public class GADfTID_1642_Practices 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_MedicalPractiseID { get; set; } 
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_GADfTID_1642_Array cls_Get_AllDoctors_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_GADfTID_1642_Array invocationResult = cls_Get_AllDoctors_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

