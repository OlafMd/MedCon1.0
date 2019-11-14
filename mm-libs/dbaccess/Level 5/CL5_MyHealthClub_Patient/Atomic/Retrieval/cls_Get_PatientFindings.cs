/* 
 * Generated on 3/26/2015 16:40:06
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

namespace CL5_MyHealthClub_Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientFindings.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientFindings
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5PA_GPF_1649_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_GPF_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5PA_GPF_1649_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_Patient.Atomic.Retrieval.SQL.cls_Get_PatientFindings.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);



			List<L5PA_GPF_1649_raw> results = new List<L5PA_GPF_1649_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "finding_id","referal_id","practice_id","doctor_id","modification_time","date","file_url","file_name" });
				while(reader.Read())
				{
					L5PA_GPF_1649_raw resultItem = new L5PA_GPF_1649_raw();
					//0:Parameter finding_id of type Guid
					resultItem.finding_id = reader.GetGuid(0);
					//1:Parameter referal_id of type Guid
					resultItem.referal_id = reader.GetGuid(1);
					//2:Parameter practice_id of type Guid
					resultItem.practice_id = reader.GetGuid(2);
					//3:Parameter doctor_id of type Guid
					resultItem.doctor_id = reader.GetGuid(3);
					//4:Parameter modification_time of type DateTime
					resultItem.modification_time = reader.GetDate(4);
					//5:Parameter date of type DateTime
					resultItem.date = reader.GetDate(5);
					//6:Parameter file_url of type Guid
					resultItem.file_url = reader.GetGuid(6);
					//7:Parameter file_name of type String
					resultItem.file_name = reader.GetString(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientFindings",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5PA_GPF_1649_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5PA_GPF_1649_Array Invoke(string ConnectionString,P_L5PA_GPF_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5PA_GPF_1649_Array Invoke(DbConnection Connection,P_L5PA_GPF_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5PA_GPF_1649_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_GPF_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5PA_GPF_1649_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_GPF_1649 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5PA_GPF_1649_Array functionReturn = new FR_L5PA_GPF_1649_Array();
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

				throw new Exception("Exception occured in method cls_Get_PatientFindings",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5PA_GPF_1649_raw 
	{
		public Guid finding_id; 
		public Guid referal_id; 
		public Guid practice_id; 
		public Guid doctor_id; 
		public DateTime modification_time; 
		public DateTime date; 
		public Guid file_url; 
		public String file_name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5PA_GPF_1649[] Convert(List<L5PA_GPF_1649_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5PA_GPF_1649 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.finding_id)).ToArray()
	group el_L5PA_GPF_1649 by new 
	{ 
		el_L5PA_GPF_1649.finding_id,

	}
	into gfunct_L5PA_GPF_1649
	select new L5PA_GPF_1649
	{     
		finding_id = gfunct_L5PA_GPF_1649.Key.finding_id ,
		referal_id = gfunct_L5PA_GPF_1649.FirstOrDefault().referal_id ,
		practice_id = gfunct_L5PA_GPF_1649.FirstOrDefault().practice_id ,
		doctor_id = gfunct_L5PA_GPF_1649.FirstOrDefault().doctor_id ,
		modification_time = gfunct_L5PA_GPF_1649.FirstOrDefault().modification_time ,
		date = gfunct_L5PA_GPF_1649.FirstOrDefault().date ,

		files = 
		(
			from el_files in gfunct_L5PA_GPF_1649.Where(element => !EqualsDefaultValue(element.file_url)).ToArray()
			group el_files by new 
			{ 
				el_files.file_url,

			}
			into gfunct_files
			select new L5PA_GPF_1649_Files
			{     
				file_url = gfunct_files.Key.file_url ,
				file_name = gfunct_files.FirstOrDefault().file_name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5PA_GPF_1649_Array : FR_Base
	{
		public L5PA_GPF_1649[] Result	{ get; set; } 
		public FR_L5PA_GPF_1649_Array() : base() {}

		public FR_L5PA_GPF_1649_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5PA_GPF_1649 for attribute P_L5PA_GPF_1649
		[DataContract]
		public class P_L5PA_GPF_1649 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPF_1649 for attribute L5PA_GPF_1649
		[DataContract]
		public class L5PA_GPF_1649 
		{
			[DataMember]
			public L5PA_GPF_1649_Files[] files { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid finding_id { get; set; } 
			[DataMember]
			public Guid referal_id { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public Guid doctor_id { get; set; } 
			[DataMember]
			public DateTime modification_time { get; set; } 
			[DataMember]
			public DateTime date { get; set; } 

		}
		#endregion
		#region SClass L5PA_GPF_1649_Files for attribute files
		[DataContract]
		public class L5PA_GPF_1649_Files 
		{
			//Standard type parameters
			[DataMember]
			public Guid file_url { get; set; } 
			[DataMember]
			public String file_name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5PA_GPF_1649_Array cls_Get_PatientFindings(,P_L5PA_GPF_1649 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5PA_GPF_1649_Array invocationResult = cls_Get_PatientFindings.Invoke(connectionString,P_L5PA_GPF_1649 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_Patient.Atomic.Retrieval.P_L5PA_GPF_1649();
parameter.PatientID = ...;

*/
