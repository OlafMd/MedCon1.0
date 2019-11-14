/* 
 * Generated on 10.06.2014 16:15:14
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

namespace CL5_MyHealthClub_OrgUnits.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_NonWorkingTimesforOfficeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_NonWorkingTimesforOfficeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_GNWTfOID_1506_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OU_GNWTfOID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OU_GNWTfOID_1506_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.SQL.cls_Get_NonWorkingTimesforOfficeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L5OU_GNWTfOID_1506> results = new List<L5OU_GNWTfOID_1506>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Description","TimeID","IsRepetitive","IsWholeDayEvent","StartTime","EndTime","IsDaily","IsWeekly","IsMonthly","IsYearly" });
				while(reader.Read())
				{
					L5OU_GNWTfOID_1506 resultItem = new L5OU_GNWTfOID_1506();
					//0:Parameter Description of type String
					resultItem.Description = reader.GetString(0);
					//1:Parameter TimeID of type Guid
					resultItem.TimeID = reader.GetGuid(1);
					//2:Parameter IsRepetitive of type bool
					resultItem.IsRepetitive = reader.GetBoolean(2);
					//3:Parameter IsWholeDayEvent of type bool
					resultItem.IsWholeDayEvent = reader.GetBoolean(3);
					//4:Parameter StartTime of type DateTime
					resultItem.StartTime = reader.GetDate(4);
					//5:Parameter EndTime of type DateTime
					resultItem.EndTime = reader.GetDate(5);
					//6:Parameter IsDaily of type bool
					resultItem.IsDaily = reader.GetBoolean(6);
					//7:Parameter IsWeekly of type bool
					resultItem.IsWeekly = reader.GetBoolean(7);
					//8:Parameter IsMonthly of type bool
					resultItem.IsMonthly = reader.GetBoolean(8);
					//9:Parameter IsYearly of type bool
					resultItem.IsYearly = reader.GetBoolean(9);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_NonWorkingTimesforOfficeID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_GNWTfOID_1506_Array Invoke(string ConnectionString,P_L5OU_GNWTfOID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_GNWTfOID_1506_Array Invoke(DbConnection Connection,P_L5OU_GNWTfOID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_GNWTfOID_1506_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OU_GNWTfOID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_GNWTfOID_1506_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OU_GNWTfOID_1506 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_GNWTfOID_1506_Array functionReturn = new FR_L5OU_GNWTfOID_1506_Array();
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

				throw new Exception("Exception occured in method cls_Get_NonWorkingTimesforOfficeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_GNWTfOID_1506_Array : FR_Base
	{
		public L5OU_GNWTfOID_1506[] Result	{ get; set; } 
		public FR_L5OU_GNWTfOID_1506_Array() : base() {}

		public FR_L5OU_GNWTfOID_1506_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OU_GNWTfOID_1506 for attribute P_L5OU_GNWTfOID_1506
		[DataContract]
		public class P_L5OU_GNWTfOID_1506 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5OU_GNWTfOID_1506 for attribute L5OU_GNWTfOID_1506
		[DataContract]
		public class L5OU_GNWTfOID_1506 
		{
			//Standard type parameters
			[DataMember]
			public String Description { get; set; } 
			[DataMember]
			public Guid TimeID { get; set; } 
			[DataMember]
			public bool IsRepetitive { get; set; } 
			[DataMember]
			public bool IsWholeDayEvent { get; set; } 
			[DataMember]
			public DateTime StartTime { get; set; } 
			[DataMember]
			public DateTime EndTime { get; set; } 
			[DataMember]
			public bool IsDaily { get; set; } 
			[DataMember]
			public bool IsWeekly { get; set; } 
			[DataMember]
			public bool IsMonthly { get; set; } 
			[DataMember]
			public bool IsYearly { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_GNWTfOID_1506_Array cls_Get_NonWorkingTimesforOfficeID(,P_L5OU_GNWTfOID_1506 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_GNWTfOID_1506_Array invocationResult = cls_Get_NonWorkingTimesforOfficeID.Invoke(connectionString,P_L5OU_GNWTfOID_1506 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.P_L5OU_GNWTfOID_1506();
parameter.OfficeID = ...;

*/
