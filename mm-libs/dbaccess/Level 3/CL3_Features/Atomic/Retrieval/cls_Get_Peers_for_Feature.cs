/* 
 * Generated on 04-Dec-14 9:38:53 AM
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

namespace CL3_Feature.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Peers_for_Feature.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Peers_for_Feature
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3FE_GPfF_1445_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3FE_GPfF_1445 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3FE_GPfF_1445_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Feature.Atomic.Retrieval.SQL.cls_Get_Peers_for_Feature.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"FeatureID", Parameter.FeatureID);



			List<L3FE_GPfF_1445> results = new List<L3FE_GPfF_1445>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PrimaryEmail","FirstName","LastName","TMS_PRO_ProjectMemberID" });
				while(reader.Read())
				{
					L3FE_GPfF_1445 resultItem = new L3FE_GPfF_1445();
					//0:Parameter PrimaryEmail of type String
					resultItem.PrimaryEmail = reader.GetString(0);
					//1:Parameter FirstName of type String
					resultItem.FirstName = reader.GetString(1);
					//2:Parameter LastName of type String
					resultItem.LastName = reader.GetString(2);
					//3:Parameter TMS_PRO_ProjectMemberID of type Guid
					resultItem.TMS_PRO_ProjectMemberID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Peers_for_Feature",ex);
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
		public static FR_L3FE_GPfF_1445_Array Invoke(string ConnectionString,P_L3FE_GPfF_1445 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3FE_GPfF_1445_Array Invoke(DbConnection Connection,P_L3FE_GPfF_1445 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3FE_GPfF_1445_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3FE_GPfF_1445 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3FE_GPfF_1445_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3FE_GPfF_1445 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3FE_GPfF_1445_Array functionReturn = new FR_L3FE_GPfF_1445_Array();
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

				throw new Exception("Exception occured in method cls_Get_Peers_for_Feature",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3FE_GPfF_1445_Array : FR_Base
	{
		public L3FE_GPfF_1445[] Result	{ get; set; } 
		public FR_L3FE_GPfF_1445_Array() : base() {}

		public FR_L3FE_GPfF_1445_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3FE_GPfF_1445 for attribute P_L3FE_GPfF_1445
		[DataContract]
		public class P_L3FE_GPfF_1445 
		{
			//Standard type parameters
			[DataMember]
			public Guid FeatureID { get; set; } 

		}
		#endregion
		#region SClass L3FE_GPfF_1445 for attribute L3FE_GPfF_1445
		[DataContract]
		public class L3FE_GPfF_1445 
		{
			//Standard type parameters
			[DataMember]
			public String PrimaryEmail { get; set; } 
			[DataMember]
			public String FirstName { get; set; } 
			[DataMember]
			public String LastName { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ProjectMemberID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3FE_GPfF_1445_Array cls_Get_Peers_for_Feature(,P_L3FE_GPfF_1445 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3FE_GPfF_1445_Array invocationResult = cls_Get_Peers_for_Feature.Invoke(connectionString,P_L3FE_GPfF_1445 Parameter,securityTicket);
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
var parameter = new CL3_Feature.Atomic.Retrieval.P_L3FE_GPfF_1445();
parameter.FeatureID = ...;

*/
