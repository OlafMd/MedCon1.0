/* 
 * Generated on 14.9.2015 16:13:59
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

namespace MMDocConnectDBMethods.MainData.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Employees.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Employees
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GE_1449_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GE_1449_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_Employees.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<MD_GE_1449_raw> results = new List<MD_GE_1449_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "employee_id","employee_rights","employee_name","employee_signin_email","IsDeactivated","Content","Type","CMN_PER_CommunicationContact_TypeID" });
				while(reader.Read())
				{
					MD_GE_1449_raw resultItem = new MD_GE_1449_raw();
					//0:Parameter employee_id of type Guid
					resultItem.employee_id = reader.GetGuid(0);
					//1:Parameter employee_rights of type String
					resultItem.employee_rights = reader.GetString(1);
					//2:Parameter employee_name of type String
					resultItem.employee_name = reader.GetString(2);
					//3:Parameter employee_signin_email of type String
					resultItem.employee_signin_email = reader.GetString(3);
					//4:Parameter IsDeactivated of type bool
					resultItem.IsDeactivated = reader.GetBoolean(4);
					//5:Parameter Content of type String
					resultItem.Content = reader.GetString(5);
					//6:Parameter Type of type String
					resultItem.Type = reader.GetString(6);
					//7:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Employees",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = MD_GE_1449_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_MD_GE_1449_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GE_1449_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GE_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GE_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GE_1449_Array functionReturn = new FR_MD_GE_1449_Array();
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

				throw new Exception("Exception occured in method cls_Get_Employees",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class MD_GE_1449_raw 
	{
		public Guid employee_id; 
		public String employee_rights; 
		public String employee_name; 
		public String employee_signin_email; 
		public bool IsDeactivated; 
		public String Content; 
		public String Type; 
		public Guid CMN_PER_CommunicationContact_TypeID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static MD_GE_1449[] Convert(List<MD_GE_1449_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_MD_GE_1449 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.employee_id)).ToArray()
	group el_MD_GE_1449 by new 
	{ 
		el_MD_GE_1449.employee_id,

	}
	into gfunct_MD_GE_1449
	select new MD_GE_1449
	{     
		employee_id = gfunct_MD_GE_1449.Key.employee_id ,
		employee_rights = gfunct_MD_GE_1449.FirstOrDefault().employee_rights ,
		employee_name = gfunct_MD_GE_1449.FirstOrDefault().employee_name ,
		employee_signin_email = gfunct_MD_GE_1449.FirstOrDefault().employee_signin_email ,
		IsDeactivated = gfunct_MD_GE_1449.FirstOrDefault().IsDeactivated ,

		Contact = 
		(
			from el_Contact in gfunct_MD_GE_1449.Where(element => !EqualsDefaultValue(element.CMN_PER_CommunicationContact_TypeID)).ToArray()
			group el_Contact by new 
			{ 
				el_Contact.CMN_PER_CommunicationContact_TypeID,

			}
			into gfunct_Contact
			select new MD_GE_1449a
			{     
				Content = gfunct_Contact.FirstOrDefault().Content ,
				Type = gfunct_Contact.FirstOrDefault().Type ,
				CMN_PER_CommunicationContact_TypeID = gfunct_Contact.Key.CMN_PER_CommunicationContact_TypeID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GE_1449_Array : FR_Base
	{
		public MD_GE_1449[] Result	{ get; set; } 
		public FR_MD_GE_1449_Array() : base() {}

		public FR_MD_GE_1449_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass MD_GE_1449 for attribute MD_GE_1449
		[DataContract]
		public class MD_GE_1449 
		{
			[DataMember]
			public MD_GE_1449a[] Contact { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid employee_id { get; set; } 
			[DataMember]
			public String employee_rights { get; set; } 
			[DataMember]
			public String employee_name { get; set; } 
			[DataMember]
			public String employee_signin_email { get; set; } 
			[DataMember]
			public bool IsDeactivated { get; set; } 

		}
		#endregion
		#region SClass MD_GE_1449a for attribute Contact
		[DataContract]
		public class MD_GE_1449a 
		{
			//Standard type parameters
			[DataMember]
			public String Content { get; set; } 
			[DataMember]
			public String Type { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GE_1449_Array cls_Get_Employees(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GE_1449_Array invocationResult = cls_Get_Employees.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

