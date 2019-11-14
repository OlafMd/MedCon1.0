/* 
 * Generated on 10/22/2014 3:08:34 PM
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

namespace CL6_DanuTask_Project.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_UsersFunctionLevelRights_for_UserID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_UsersFunctionLevelRights_for_UserID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6PR_GUFLRfU_1714 Execute(DbConnection Connection,DbTransaction Transaction,P_L6PR_GUFLRfU_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L6PR_GUFLRfU_1714();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL6_DanuTask_Project.Atomic.Retrieval.SQL.cls_Get_UsersFunctionLevelRights_for_UserID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ApplicationID", Parameter.ApplicationID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProjectMemberID", Parameter.ProjectMemberID);



			List<L6PR_GUFLRfU_1714_raw> results = new List<L6PR_GUFLRfU_1714_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Username","AccountType","AssignmentID","USR_Account_FunctionLevelRightID","RightName" });
				while(reader.Read())
				{
					L6PR_GUFLRfU_1714_raw resultItem = new L6PR_GUFLRfU_1714_raw();
					//0:Parameter Username of type String
					resultItem.Username = reader.GetString(0);
					//1:Parameter AccountType of type int
					resultItem.AccountType = reader.GetInteger(1);
					//2:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(2);
					//3:Parameter USR_Account_FunctionLevelRightID of type Guid
					resultItem.USR_Account_FunctionLevelRightID = reader.GetGuid(3);
					//4:Parameter RightName of type String
					resultItem.RightName = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_UsersFunctionLevelRights_for_UserID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L6PR_GUFLRfU_1714_raw.Convert(results).FirstOrDefault();

			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6PR_GUFLRfU_1714 Invoke(string ConnectionString,P_L6PR_GUFLRfU_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6PR_GUFLRfU_1714 Invoke(DbConnection Connection,P_L6PR_GUFLRfU_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6PR_GUFLRfU_1714 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6PR_GUFLRfU_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6PR_GUFLRfU_1714 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6PR_GUFLRfU_1714 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6PR_GUFLRfU_1714 functionReturn = new FR_L6PR_GUFLRfU_1714();
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

				throw new Exception("Exception occured in method cls_Get_UsersFunctionLevelRights_for_UserID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L6PR_GUFLRfU_1714_raw 
	{
		public String Username; 
		public int AccountType; 
		public Guid AssignmentID; 
		public Guid USR_Account_FunctionLevelRightID; 
		public String RightName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L6PR_GUFLRfU_1714[] Convert(List<L6PR_GUFLRfU_1714_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L6PR_GUFLRfU_1714 in gfunct_rawResult.ToArray()
	group el_L6PR_GUFLRfU_1714 by new 
	{ 
	}
	into gfunct_L6PR_GUFLRfU_1714
	select new L6PR_GUFLRfU_1714
	{     
		Username = gfunct_L6PR_GUFLRfU_1714.FirstOrDefault().Username ,
		AccountType = gfunct_L6PR_GUFLRfU_1714.FirstOrDefault().AccountType ,

		FunctionLevelRights = 
		(
			from el_FunctionLevelRights in gfunct_L6PR_GUFLRfU_1714.Where(element => !EqualsDefaultValue(element.USR_Account_FunctionLevelRightID)).ToArray()
			group el_FunctionLevelRights by new 
			{ 
				el_FunctionLevelRights.USR_Account_FunctionLevelRightID,

			}
			into gfunct_FunctionLevelRights
			select new L6PR_GUFLRfU_1714a
			{     
				AssignmentID = gfunct_FunctionLevelRights.FirstOrDefault().AssignmentID ,
				USR_Account_FunctionLevelRightID = gfunct_FunctionLevelRights.Key.USR_Account_FunctionLevelRightID ,
				RightName = gfunct_FunctionLevelRights.FirstOrDefault().RightName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L6PR_GUFLRfU_1714 : FR_Base
	{
		public L6PR_GUFLRfU_1714 Result	{ get; set; }

		public FR_L6PR_GUFLRfU_1714() : base() {}

		public FR_L6PR_GUFLRfU_1714(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6PR_GUFLRfU_1714 for attribute P_L6PR_GUFLRfU_1714
		[DataContract]
		public class P_L6PR_GUFLRfU_1714 
		{
			//Standard type parameters
			[DataMember]
			public Guid ApplicationID { get; set; } 
			[DataMember]
			public Guid ProjectMemberID { get; set; } 

		}
		#endregion
		#region SClass L6PR_GUFLRfU_1714 for attribute L6PR_GUFLRfU_1714
		[DataContract]
		public class L6PR_GUFLRfU_1714 
		{
			[DataMember]
			public L6PR_GUFLRfU_1714a[] FunctionLevelRights { get; set; }

			//Standard type parameters
			[DataMember]
			public String Username { get; set; } 
			[DataMember]
			public int AccountType { get; set; } 

		}
		#endregion
		#region SClass L6PR_GUFLRfU_1714a for attribute FunctionLevelRights
		[DataContract]
		public class L6PR_GUFLRfU_1714a 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Guid USR_Account_FunctionLevelRightID { get; set; } 
			[DataMember]
			public String RightName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6PR_GUFLRfU_1714 cls_Get_UsersFunctionLevelRights_for_UserID(,P_L6PR_GUFLRfU_1714 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6PR_GUFLRfU_1714 invocationResult = cls_Get_UsersFunctionLevelRights_for_UserID.Invoke(connectionString,P_L6PR_GUFLRfU_1714 Parameter,securityTicket);
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
var parameter = new CL6_DanuTask_Project.Atomic.Retrieval.P_L6PR_GUFLRfU_1714();
parameter.ApplicationID = ...;
parameter.ProjectMemberID = ...;

*/
