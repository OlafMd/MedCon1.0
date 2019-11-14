/* 
 * Generated on 8/23/2013 3:08:58 PM
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
    /// var result = cls_Get_Doctors_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctors_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_GDfTID_1408_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_GDfTID_1408_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Doctors.Atomic.Retrieval.SQL.cls_Get_Doctors_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<GDfTID_1408_raw> results = new List<GDfTID_1408_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","LANR","FirstName","LastName","Account_RefID","PracticeName","PracticeID","Content","Contact_Type" });
				while(reader.Read())
				{
					GDfTID_1408_raw resultItem = new GDfTID_1408_raw();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter LANR of type String
					resultItem.LANR = reader.GetString(1);
					//2:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(2);
					//3:Parameter LastName of type String
					resultItem.LastName = reader.GetString(3);
					//4:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(4);
					//5:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(5);
					//6:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(6);
					//7:Parameter Content of type String
					resultItem.Content = reader.GetString(7);
					//8:Parameter Contact_Type of type Guid
					resultItem.Contact_Type = reader.GetGuid(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctors_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = GDfTID_1408_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_GDfTID_1408_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_GDfTID_1408_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_GDfTID_1408_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_GDfTID_1408_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_GDfTID_1408_Array functionReturn = new FR_GDfTID_1408_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctors_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class GDfTID_1408_raw 
	{
		public Guid HEC_DoctorID; 
		public String LANR; 
		public String FirstName; 
		public String LastName; 
		public Guid Account_RefID; 
		public String PracticeName; 
		public Guid PracticeID; 
		public String Content; 
		public Guid Contact_Type; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static GDfTID_1408[] Convert(List<GDfTID_1408_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_GDfTID_1408 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DoctorID)).ToArray()
	group el_GDfTID_1408 by new 
	{ 
		el_GDfTID_1408.HEC_DoctorID,

	}
	into gfunct_GDfTID_1408
	select new GDfTID_1408
	{     
		HEC_DoctorID = gfunct_GDfTID_1408.Key.HEC_DoctorID ,
		LANR = gfunct_GDfTID_1408.FirstOrDefault().LANR ,
		FirstName = gfunct_GDfTID_1408.FirstOrDefault().FirstName ,
		LastName = gfunct_GDfTID_1408.FirstOrDefault().LastName ,
		Account_RefID = gfunct_GDfTID_1408.FirstOrDefault().Account_RefID ,

		Practices = 
		(
			from el_Practices in gfunct_GDfTID_1408.Where(element => !EqualsDefaultValue(element.PracticeID)).ToArray()
			group el_Practices by new 
			{ 
				el_Practices.PracticeID,

			}
			into gfunct_Practices
			select new GDfTID_1408_Practices
			{     
				PracticeName = gfunct_Practices.FirstOrDefault().PracticeName ,
				PracticeID = gfunct_Practices.Key.PracticeID ,

			}
		).ToArray(),
		ContactTypes = 
		(
			from el_ContactTypes in gfunct_GDfTID_1408.Where(element => !EqualsDefaultValue(element.Contact_Type)).ToArray()
			group el_ContactTypes by new 
			{ 
				el_ContactTypes.Contact_Type,

			}
			into gfunct_ContactTypes
			select new GDfTID_1408_ContactTypes
			{     
				Content = gfunct_ContactTypes.FirstOrDefault().Content ,
				Contact_Type = gfunct_ContactTypes.Key.Contact_Type ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_GDfTID_1408_Array : FR_Base
	{
		public GDfTID_1408[] Result	{ get; set; } 
		public FR_GDfTID_1408_Array() : base() {}

		public FR_GDfTID_1408_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass GDfTID_1408 for attribute GDfTID_1408
		[DataContract]
		public class GDfTID_1408 
		{
			[DataMember]
			public GDfTID_1408_Practices[] Practices { get; set; }
			[DataMember]
			public GDfTID_1408_ContactTypes[] ContactTypes { get; set; }

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
			public Guid Account_RefID { get; set; } 

		}
		#endregion
		#region SClass GDfTID_1408_Practices for attribute Practices
		[DataContract]
		public class GDfTID_1408_Practices 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass GDfTID_1408_ContactTypes for attribute ContactTypes
		[DataContract]
		public class GDfTID_1408_ContactTypes 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public Guid Contact_Type { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_GDfTID_1408_Array cls_Get_Doctors_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_GDfTID_1408_Array invocationResult = cls_Get_Doctors_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

