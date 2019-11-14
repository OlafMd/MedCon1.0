/* 
 * Generated on 14.9.2015 17:17:38
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
    /// var result = cls_Get_Communication_Contact_Info_for_User_Person_Info.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Communication_Contact_Info_for_User_Person_Info
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_MD_GCCIFUPID_1716 Execute(DbConnection Connection,DbTransaction Transaction,P_MD_GCCIFUPID_1716 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_MD_GCCIFUPID_1716();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.MainData.Atomic.Retrieval.SQL.cls_Get_Communication_Contact_Info_for_User_Person_Info.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PersonRefID", Parameter.PersonRefID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CommunicationType", Parameter.CommunicationType);



			List<MD_GCCIFUPID_1716> results = new List<MD_GCCIFUPID_1716>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Content","CMN_PER_CommunicationContactID","CMN_PER_CommunicationContact_TypeID" });
				while(reader.Read())
				{
					MD_GCCIFUPID_1716 resultItem = new MD_GCCIFUPID_1716();
					//0:Parameter Content of type string
					resultItem.Content = reader.GetString(0);
					//1:Parameter CMN_PER_CommunicationContactID of type Guid
					resultItem.CMN_PER_CommunicationContactID = reader.GetGuid(1);
					//2:Parameter CMN_PER_CommunicationContact_TypeID of type Guid
					resultItem.CMN_PER_CommunicationContact_TypeID = reader.GetGuid(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Communication_Contact_Info_for_User_Person_Info",ex);
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
		public static FR_MD_GCCIFUPID_1716 Invoke(string ConnectionString,P_MD_GCCIFUPID_1716 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_MD_GCCIFUPID_1716 Invoke(DbConnection Connection,P_MD_GCCIFUPID_1716 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_MD_GCCIFUPID_1716 Invoke(DbConnection Connection, DbTransaction Transaction,P_MD_GCCIFUPID_1716 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_MD_GCCIFUPID_1716 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_MD_GCCIFUPID_1716 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_MD_GCCIFUPID_1716 functionReturn = new FR_MD_GCCIFUPID_1716();
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

				throw new Exception("Exception occured in method cls_Get_Communication_Contact_Info_for_User_Person_Info",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_MD_GCCIFUPID_1716 : FR_Base
	{
		public MD_GCCIFUPID_1716 Result	{ get; set; }

		public FR_MD_GCCIFUPID_1716() : base() {}

		public FR_MD_GCCIFUPID_1716(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_MD_GCCIFUPID_1716 for attribute P_MD_GCCIFUPID_1716
		[DataContract]
		public class P_MD_GCCIFUPID_1716 
		{
			//Standard type parameters
			[DataMember]
			public Guid PersonRefID { get; set; } 
			[DataMember]
			public string CommunicationType { get; set; } 

		}
		#endregion
		#region SClass MD_GCCIFUPID_1716 for attribute MD_GCCIFUPID_1716
		[DataContract]
		public class MD_GCCIFUPID_1716 
		{
			//Standard type parameters
			[DataMember]
			public string Content { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContactID { get; set; } 
			[DataMember]
			public Guid CMN_PER_CommunicationContact_TypeID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_MD_GCCIFUPID_1716 cls_Get_Communication_Contact_Info_for_User_Person_Info(,P_MD_GCCIFUPID_1716 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_MD_GCCIFUPID_1716 invocationResult = cls_Get_Communication_Contact_Info_for_User_Person_Info.Invoke(connectionString,P_MD_GCCIFUPID_1716 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.MainData.Atomic.Retrieval.P_MD_GCCIFUPID_1716();
parameter.PersonRefID = ...;
parameter.CommunicationType = ...;

*/
