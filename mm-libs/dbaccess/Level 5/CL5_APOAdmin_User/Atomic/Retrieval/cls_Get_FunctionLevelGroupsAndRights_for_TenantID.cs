/* 
 * Generated on 12/6/2013 11:20:17 AM
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

namespace CL5_APOAdmin_User.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_FunctionLevelGroupsAndRights_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_FunctionLevelGroupsAndRights_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5US_GFLGaRfT_1432_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5US_GFLGaRfT_1432_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOAdmin_User.Atomic.Retrieval.SQL.cls_Get_FunctionLevelGroupsAndRights_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5US_GFLGaRfT_1432_raw> results = new List<L5US_GFLGaRfT_1432_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "USR_Account_FunctionLevelRights_GroupID","GroupName","Groups_GlobalPropertyMatchingID","USR_Account_FunctionLevelRightID","RightName","GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5US_GFLGaRfT_1432_raw resultItem = new L5US_GFLGaRfT_1432_raw();
					//0:Parameter USR_Account_FunctionLevelRights_GroupID of type Guid
					resultItem.USR_Account_FunctionLevelRights_GroupID = reader.GetGuid(0);
					//1:Parameter GroupName of type String
					resultItem.GroupName = reader.GetString(1);
					//2:Parameter Groups_GlobalPropertyMatchingID of type String
					resultItem.Groups_GlobalPropertyMatchingID = reader.GetString(2);
					//3:Parameter USR_Account_FunctionLevelRightID of type Guid
					resultItem.USR_Account_FunctionLevelRightID = reader.GetGuid(3);
					//4:Parameter RightName of type String
					resultItem.RightName = reader.GetString(4);
					//5:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_FunctionLevelGroupsAndRights_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5US_GFLGaRfT_1432_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5US_GFLGaRfT_1432_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5US_GFLGaRfT_1432_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5US_GFLGaRfT_1432_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5US_GFLGaRfT_1432_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5US_GFLGaRfT_1432_Array functionReturn = new FR_L5US_GFLGaRfT_1432_Array();
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

				throw new Exception("Exception occured in method cls_Get_FunctionLevelGroupsAndRights_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5US_GFLGaRfT_1432_raw 
	{
		public Guid USR_Account_FunctionLevelRights_GroupID; 
		public String GroupName; 
		public String Groups_GlobalPropertyMatchingID; 
		public Guid USR_Account_FunctionLevelRightID; 
		public String RightName; 
		public String GlobalPropertyMatchingID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5US_GFLGaRfT_1432[] Convert(List<L5US_GFLGaRfT_1432_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5US_GFLGaRfT_1432 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.USR_Account_FunctionLevelRights_GroupID)).ToArray()
	group el_L5US_GFLGaRfT_1432 by new 
	{ 
		el_L5US_GFLGaRfT_1432.USR_Account_FunctionLevelRights_GroupID,

	}
	into gfunct_L5US_GFLGaRfT_1432
	select new L5US_GFLGaRfT_1432
	{     
		USR_Account_FunctionLevelRights_GroupID = gfunct_L5US_GFLGaRfT_1432.Key.USR_Account_FunctionLevelRights_GroupID ,
		GroupName = gfunct_L5US_GFLGaRfT_1432.FirstOrDefault().GroupName ,
		Groups_GlobalPropertyMatchingID = gfunct_L5US_GFLGaRfT_1432.FirstOrDefault().Groups_GlobalPropertyMatchingID ,

		FLRights = 
		(
			from el_FLRights in gfunct_L5US_GFLGaRfT_1432.Where(element => !EqualsDefaultValue(element.USR_Account_FunctionLevelRightID)).ToArray()
			group el_FLRights by new 
			{ 
				el_FLRights.USR_Account_FunctionLevelRightID,

			}
			into gfunct_FLRights
			select new L5US_GFLGaRfT_1432a
			{     
				USR_Account_FunctionLevelRightID = gfunct_FLRights.Key.USR_Account_FunctionLevelRightID ,
				RightName = gfunct_FLRights.FirstOrDefault().RightName ,
				GlobalPropertyMatchingID = gfunct_FLRights.FirstOrDefault().GlobalPropertyMatchingID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5US_GFLGaRfT_1432_Array : FR_Base
	{
		public L5US_GFLGaRfT_1432[] Result	{ get; set; } 
		public FR_L5US_GFLGaRfT_1432_Array() : base() {}

		public FR_L5US_GFLGaRfT_1432_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5US_GFLGaRfT_1432 for attribute L5US_GFLGaRfT_1432
		[DataContract]
		public class L5US_GFLGaRfT_1432 
		{
			[DataMember]
			public L5US_GFLGaRfT_1432a[] FLRights { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid USR_Account_FunctionLevelRights_GroupID { get; set; } 
			[DataMember]
			public String GroupName { get; set; } 
			[DataMember]
			public String Groups_GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass L5US_GFLGaRfT_1432a for attribute FLRights
		[DataContract]
		public class L5US_GFLGaRfT_1432a 
		{
			//Standard type parameters
			[DataMember]
			public Guid USR_Account_FunctionLevelRightID { get; set; } 
			[DataMember]
			public String RightName { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5US_GFLGaRfT_1432_Array cls_Get_FunctionLevelGroupsAndRights_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5US_GFLGaRfT_1432_Array invocationResult = cls_Get_FunctionLevelGroupsAndRights_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

