/* 
 * Generated on 13.10.2014 16:41:59
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

namespace CL5_MyHealthClub_TimeAndException.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StandardHours_for_OfficeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StandardHours_for_OfficeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TE_GSHfOID_1540_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5TE_GSHfOID_1540 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TE_GSHfOID_1540_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_TimeAndException.Atomic.Retrieval.SQL.cls_Get_StandardHours_for_OfficeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OfficeID", Parameter.OfficeID);



			List<L5TE_GSHfOID_1540> results = new List<L5TE_GSHfOID_1540>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "TimeID","IsWholeDay","TimeFrom_InMinutes","TimeTo_InMinutes","IsMonday","IsTuesday","IsWednesday","IsThursday","IsFriday","IsSaturday","IsSunday","OfficeHoursTemplate_Name" });
				while(reader.Read())
				{
					L5TE_GSHfOID_1540 resultItem = new L5TE_GSHfOID_1540();
					//0:Parameter TimeID of type Guid
					resultItem.TimeID = reader.GetGuid(0);
					//1:Parameter IsWholeDay of type bool
					resultItem.IsWholeDay = reader.GetBoolean(1);
					//2:Parameter TimeFrom_InMinutes of type long
					resultItem.TimeFrom_InMinutes = reader.GetLong(2);
					//3:Parameter TimeTo_InMinutes of type long
					resultItem.TimeTo_InMinutes = reader.GetLong(3);
					//4:Parameter IsMonday of type bool
					resultItem.IsMonday = reader.GetBoolean(4);
					//5:Parameter IsTuesday of type bool
					resultItem.IsTuesday = reader.GetBoolean(5);
					//6:Parameter IsWednesday of type bool
					resultItem.IsWednesday = reader.GetBoolean(6);
					//7:Parameter IsThursday of type bool
					resultItem.IsThursday = reader.GetBoolean(7);
					//8:Parameter IsFriday of type bool
					resultItem.IsFriday = reader.GetBoolean(8);
					//9:Parameter IsSaturday of type bool
					resultItem.IsSaturday = reader.GetBoolean(9);
					//10:Parameter IsSunday of type bool
					resultItem.IsSunday = reader.GetBoolean(10);
					//11:Parameter OfficeHoursTemplate_Name of type String
					resultItem.OfficeHoursTemplate_Name = reader.GetString(11);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_StandardHours_for_OfficeID",ex);
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
		public static FR_L5TE_GSHfOID_1540_Array Invoke(string ConnectionString,P_L5TE_GSHfOID_1540 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TE_GSHfOID_1540_Array Invoke(DbConnection Connection,P_L5TE_GSHfOID_1540 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TE_GSHfOID_1540_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TE_GSHfOID_1540 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TE_GSHfOID_1540_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TE_GSHfOID_1540 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TE_GSHfOID_1540_Array functionReturn = new FR_L5TE_GSHfOID_1540_Array();
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

				throw new Exception("Exception occured in method cls_Get_StandardHours_for_OfficeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TE_GSHfOID_1540_Array : FR_Base
	{
		public L5TE_GSHfOID_1540[] Result	{ get; set; } 
		public FR_L5TE_GSHfOID_1540_Array() : base() {}

		public FR_L5TE_GSHfOID_1540_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TE_GSHfOID_1540 for attribute P_L5TE_GSHfOID_1540
		[DataContract]
		public class P_L5TE_GSHfOID_1540 
		{
			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 

		}
		#endregion
		#region SClass L5TE_GSHfOID_1540 for attribute L5TE_GSHfOID_1540
		[DataContract]
		public class L5TE_GSHfOID_1540 
		{
			//Standard type parameters
			[DataMember]
			public Guid TimeID { get; set; } 
			[DataMember]
			public bool IsWholeDay { get; set; } 
			[DataMember]
			public long TimeFrom_InMinutes { get; set; } 
			[DataMember]
			public long TimeTo_InMinutes { get; set; } 
			[DataMember]
			public bool IsMonday { get; set; } 
			[DataMember]
			public bool IsTuesday { get; set; } 
			[DataMember]
			public bool IsWednesday { get; set; } 
			[DataMember]
			public bool IsThursday { get; set; } 
			[DataMember]
			public bool IsFriday { get; set; } 
			[DataMember]
			public bool IsSaturday { get; set; } 
			[DataMember]
			public bool IsSunday { get; set; } 
			[DataMember]
			public String OfficeHoursTemplate_Name { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TE_GSHfOID_1540_Array cls_Get_StandardHours_for_OfficeID(,P_L5TE_GSHfOID_1540 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TE_GSHfOID_1540_Array invocationResult = cls_Get_StandardHours_for_OfficeID.Invoke(connectionString,P_L5TE_GSHfOID_1540 Parameter,securityTicket);
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
var parameter = new CL5_MyHealthClub_TimeAndException.Atomic.Retrieval.P_L5TE_GSHfOID_1540();
parameter.OfficeID = ...;

*/
