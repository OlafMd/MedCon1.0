/* 
 * Generated on 10/7/2013 9:20:13 AM
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
    /// var result = cls_Get_Doctor_for_TenantID_and_DoctorID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_for_TenantID_and_DoctorID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_GDfTIDaDI_1208 Execute(DbConnection Connection,DbTransaction Transaction,P_GDfTIDaDI_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_GDfTIDaDI_1208();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Doctors.Atomic.Retrieval.SQL.cls_Get_Doctor_for_TenantID_and_DoctorID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);



			List<GDfTIDaDI_1208_raw> results = new List<GDfTIDaDI_1208_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","LANR","FirstName","LastName","Title","LoginEmail","Account_RefID","PracticeName","PracticeID","CMN_BPT_BusinessParticipantID","Content","Contact_Type" });
				while(reader.Read())
				{
					GDfTIDaDI_1208_raw resultItem = new GDfTIDaDI_1208_raw();
					//0:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(0);
					//1:Parameter LANR of type String
					resultItem.LANR = reader.GetString(1);
					//2:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(2);
					//3:Parameter LastName of type String
					resultItem.LastName = reader.GetString(3);
					//4:Parameter Title of type String
					resultItem.Title = reader.GetString(4);
					//5:Parameter LoginEmail of type String
					resultItem.LoginEmail = reader.GetString(5);
					//6:Parameter Account_RefID of type Guid
					resultItem.Account_RefID = reader.GetGuid(6);
					//7:Parameter PracticeName of type String
					resultItem.PracticeName = reader.GetString(7);
					//8:Parameter PracticeID of type Guid
					resultItem.PracticeID = reader.GetGuid(8);
					//9:Parameter CMN_BPT_BusinessParticipantID of type Guid
					resultItem.CMN_BPT_BusinessParticipantID = reader.GetGuid(9);
					//10:Parameter Content of type String
					resultItem.Content = reader.GetString(10);
					//11:Parameter Contact_Type of type Guid
					resultItem.Contact_Type = reader.GetGuid(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_for_TenantID_and_DoctorID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = GDfTIDaDI_1208_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_GDfTIDaDI_1208 Invoke(string ConnectionString,P_GDfTIDaDI_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_GDfTIDaDI_1208 Invoke(DbConnection Connection,P_GDfTIDaDI_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_GDfTIDaDI_1208 Invoke(DbConnection Connection, DbTransaction Transaction,P_GDfTIDaDI_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_GDfTIDaDI_1208 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_GDfTIDaDI_1208 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_GDfTIDaDI_1208 functionReturn = new FR_GDfTIDaDI_1208();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_for_TenantID_and_DoctorID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class GDfTIDaDI_1208_raw 
	{
		public Guid HEC_DoctorID; 
		public String LANR; 
		public String FirstName; 
		public String LastName; 
		public String Title; 
		public String LoginEmail; 
		public Guid Account_RefID; 
		public String PracticeName; 
		public Guid PracticeID; 
		public Guid CMN_BPT_BusinessParticipantID; 
		public String Content; 
		public Guid Contact_Type; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static GDfTIDaDI_1208[] Convert(List<GDfTIDaDI_1208_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_GDfTIDaDI_1208 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DoctorID)).ToArray()
	group el_GDfTIDaDI_1208 by new 
	{ 
		el_GDfTIDaDI_1208.HEC_DoctorID,

	}
	into gfunct_GDfTIDaDI_1208
	select new GDfTIDaDI_1208
	{     
		HEC_DoctorID = gfunct_GDfTIDaDI_1208.Key.HEC_DoctorID ,
		LANR = gfunct_GDfTIDaDI_1208.FirstOrDefault().LANR ,
		FirstName = gfunct_GDfTIDaDI_1208.FirstOrDefault().FirstName ,
		LastName = gfunct_GDfTIDaDI_1208.FirstOrDefault().LastName ,
		Title = gfunct_GDfTIDaDI_1208.FirstOrDefault().Title ,
		LoginEmail = gfunct_GDfTIDaDI_1208.FirstOrDefault().LoginEmail ,
		Account_RefID = gfunct_GDfTIDaDI_1208.FirstOrDefault().Account_RefID ,

		Practices = 
		(
			from el_Practices in gfunct_GDfTIDaDI_1208.Where(element => !EqualsDefaultValue(element.CMN_BPT_BusinessParticipantID)).ToArray()
			group el_Practices by new 
			{ 
				el_Practices.CMN_BPT_BusinessParticipantID,

			}
			into gfunct_Practices
			select new GDfTIDaDI_1208_Practices
			{     
				PracticeName = gfunct_Practices.FirstOrDefault().PracticeName ,
				PracticeID = gfunct_Practices.FirstOrDefault().PracticeID ,
				CMN_BPT_BusinessParticipantID = gfunct_Practices.Key.CMN_BPT_BusinessParticipantID ,

			}
		).ToArray(),
		ContactTypes = 
		(
			from el_ContactTypes in gfunct_GDfTIDaDI_1208.Where(element => !EqualsDefaultValue(element.Contact_Type)).ToArray()
			group el_ContactTypes by new 
			{ 
				el_ContactTypes.Contact_Type,

			}
			into gfunct_ContactTypes
			select new GDfTIDaDI_1208_ContactTypes
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
	public class FR_GDfTIDaDI_1208 : FR_Base
	{
		public GDfTIDaDI_1208 Result	{ get; set; }

		public FR_GDfTIDaDI_1208() : base() {}

		public FR_GDfTIDaDI_1208(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_GDfTIDaDI_1208 for attribute P_GDfTIDaDI_1208
		[DataContract]
		public class P_GDfTIDaDI_1208 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass GDfTIDaDI_1208 for attribute GDfTIDaDI_1208
		[DataContract]
		public class GDfTIDaDI_1208 
		{
			[DataMember]
			public GDfTIDaDI_1208_Practices[] Practices { get; set; }
			[DataMember]
			public GDfTIDaDI_1208_ContactTypes[] ContactTypes { get; set; }

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
			public String Title { get; set; } 
			[DataMember]
			public String LoginEmail { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 

		}
		#endregion
		#region SClass GDfTIDaDI_1208_Practices for attribute Practices
		[DataContract]
		public class GDfTIDaDI_1208_Practices 
		{
			//Standard type parameters
			[DataMember]
			public String PracticeName { get; set; } 
			[DataMember]
			public Guid PracticeID { get; set; } 
			[DataMember]
			public Guid CMN_BPT_BusinessParticipantID { get; set; } 

		}
		#endregion
		#region SClass GDfTIDaDI_1208_ContactTypes for attribute ContactTypes
		[DataContract]
		public class GDfTIDaDI_1208_ContactTypes 
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
FR_GDfTIDaDI_1208 cls_Get_Doctor_for_TenantID_and_DoctorID(,P_GDfTIDaDI_1208 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_GDfTIDaDI_1208 invocationResult = cls_Get_Doctor_for_TenantID_and_DoctorID.Invoke(connectionString,P_GDfTIDaDI_1208 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Doctors.Atomic.Retrieval.P_GDfTIDaDI_1208();
parameter.DoctorID = ...;

*/
