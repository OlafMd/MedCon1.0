/* 
 * Generated on 8/19/2013 10:51:24 AM
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
    /// var result = cls_Get_Doctor_byID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctor_byID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_GDfDI_1051 Execute(DbConnection Connection,DbTransaction Transaction,P_GDfDI_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_GDfDI_1051();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Doctors.Atomic.Retrieval.SQL.cls_Get_Doctor_byID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DoctorID", Parameter.DoctorID);



			List<GDfDI_1051> results = new List<GDfDI_1051>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DoctorID","LANR","FirstName","LastName","Title","LoginEmail","Account_RefID" });
				while(reader.Read())
				{
					GDfDI_1051 resultItem = new GDfDI_1051();
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

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctor_byID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_GDfDI_1051 Invoke(string ConnectionString,P_GDfDI_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_GDfDI_1051 Invoke(DbConnection Connection,P_GDfDI_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_GDfDI_1051 Invoke(DbConnection Connection, DbTransaction Transaction,P_GDfDI_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_GDfDI_1051 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_GDfDI_1051 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_GDfDI_1051 functionReturn = new FR_GDfDI_1051();
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

				throw new Exception("Exception occured in method cls_Get_Doctor_byID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_GDfDI_1051 : FR_Base
	{
		public GDfDI_1051 Result	{ get; set; }

		public FR_GDfDI_1051() : base() {}

		public FR_GDfDI_1051(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_GDfDI_1051 for attribute P_GDfDI_1051
		[DataContract]
		public class P_GDfDI_1051 
		{
			//Standard type parameters
			[DataMember]
			public Guid DoctorID { get; set; } 

		}
		#endregion
		#region SClass GDfDI_1051 for attribute GDfDI_1051
		[DataContract]
		public class GDfDI_1051 
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
			public String Title { get; set; } 
			[DataMember]
			public String LoginEmail { get; set; } 
			[DataMember]
			public Guid Account_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_GDfDI_1051 cls_Get_Doctor_byID(,P_GDfDI_1051 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_GDfDI_1051 invocationResult = cls_Get_Doctor_byID.Invoke(connectionString,P_GDfDI_1051 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Doctors.Atomic.Retrieval.P_GDfDI_1051();
parameter.DoctorID = ...;

*/
