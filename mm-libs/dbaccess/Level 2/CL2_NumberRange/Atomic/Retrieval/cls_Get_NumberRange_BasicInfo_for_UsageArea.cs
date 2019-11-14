/* 
 * Generated on 6/9/2014 11:50:51 AM
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
using System.Runtime.Serialization;

namespace CL2_NumberRange.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_NumberRange_BasicInfo_for_UsageArea.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_NumberRange_BasicInfo_for_UsageArea
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2NR_GNRBIfUA_1000 Execute(DbConnection Connection,DbTransaction Transaction,P_L2NR_GNRBIfUA_1000 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2NR_GNRBIfUA_1000();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_NumberRange.Atomic.Retrieval.SQL.cls_Get_NumberRange_BasicInfo_for_UsageArea.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GlobalStaticMatchingID", Parameter.GlobalStaticMatchingID);



			List<L2NR_GNRBIfUA_1000> results = new List<L2NR_GNRBIfUA_1000>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_NumberRangeID","Value_Current","Value_Start","Value_End","FixedPrefix","Formatting_NumberLength","Formatting_LeadingFillCharacter" });
				while(reader.Read())
				{
					L2NR_GNRBIfUA_1000 resultItem = new L2NR_GNRBIfUA_1000();
					//0:Parameter CMN_NumberRangeID of type Guid
					resultItem.CMN_NumberRangeID = reader.GetGuid(0);
					//1:Parameter Value_Current of type long
					resultItem.Value_Current = reader.GetLong(1);
					//2:Parameter Value_Start of type long
					resultItem.Value_Start = reader.GetLong(2);
					//3:Parameter Value_End of type long
					resultItem.Value_End = reader.GetLong(3);
					//4:Parameter FixedPrefix of type String
					resultItem.FixedPrefix = reader.GetString(4);
					//5:Parameter Formatting_NumberLength of type int
					resultItem.Formatting_NumberLength = reader.GetInteger(5);
					//6:Parameter Formatting_LeadingFillCharacter of type String
					resultItem.Formatting_LeadingFillCharacter = reader.GetString(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_NumberRange_BasicInfo_for_UsageArea",ex);
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
		public static FR_L2NR_GNRBIfUA_1000 Invoke(string ConnectionString,P_L2NR_GNRBIfUA_1000 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2NR_GNRBIfUA_1000 Invoke(DbConnection Connection,P_L2NR_GNRBIfUA_1000 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2NR_GNRBIfUA_1000 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2NR_GNRBIfUA_1000 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2NR_GNRBIfUA_1000 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2NR_GNRBIfUA_1000 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2NR_GNRBIfUA_1000 functionReturn = new FR_L2NR_GNRBIfUA_1000();
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

				throw new Exception("Exception occured in method cls_Get_NumberRange_BasicInfo_for_UsageArea",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2NR_GNRBIfUA_1000 : FR_Base
	{
		public L2NR_GNRBIfUA_1000 Result	{ get; set; }

		public FR_L2NR_GNRBIfUA_1000() : base() {}

		public FR_L2NR_GNRBIfUA_1000(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2NR_GNRBIfUA_1000 for attribute P_L2NR_GNRBIfUA_1000
		[DataContract]
		public class P_L2NR_GNRBIfUA_1000 
		{
			//Standard type parameters
			[DataMember]
			public String GlobalStaticMatchingID { get; set; } 

		}
		#endregion
		#region SClass L2NR_GNRBIfUA_1000 for attribute L2NR_GNRBIfUA_1000
		[DataContract]
		public class L2NR_GNRBIfUA_1000 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_NumberRangeID { get; set; } 
			[DataMember]
			public long Value_Current { get; set; } 
			[DataMember]
			public long Value_Start { get; set; } 
			[DataMember]
			public long Value_End { get; set; } 
			[DataMember]
			public String FixedPrefix { get; set; } 
			[DataMember]
			public int Formatting_NumberLength { get; set; } 
			[DataMember]
			public String Formatting_LeadingFillCharacter { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2NR_GNRBIfUA_1000 cls_Get_NumberRange_BasicInfo_for_UsageArea(,P_L2NR_GNRBIfUA_1000 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2NR_GNRBIfUA_1000 invocationResult = cls_Get_NumberRange_BasicInfo_for_UsageArea.Invoke(connectionString,P_L2NR_GNRBIfUA_1000 Parameter,securityTicket);
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
var parameter = new CL2_NumberRange.Atomic.Retrieval.P_L2NR_GNRBIfUA_1000();
parameter.GlobalStaticMatchingID = ...;

*/
