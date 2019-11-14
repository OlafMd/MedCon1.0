/* 
 * Generated on 19.09.2014 12:20:08
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using System.Runtime.Serialization;

namespace CL2_Correspondences.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Correspondences_for_BusinessParticipant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Correspondences_for_BusinessParticipant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2CO_GCfBP_1355_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2CO_GCfBP_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2CO_GCfBP_1355_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Correspondences.Atomic.Retrieval.SQL.cls_Get_Correspondences_for_BusinessParticipant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerID", Parameter.CustomerID);



			List<L2CO_GCfBP_1355> results = new List<L2CO_GCfBP_1355>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CorrespondenceText","CMN_PER_PersonInfo_CorrespondenceID","IsDefaultCorrespondence","CorrespondenceType_RefID" });
				while(reader.Read())
				{
					L2CO_GCfBP_1355 resultItem = new L2CO_GCfBP_1355();
					//0:Parameter CorrespondenceText of type String
					resultItem.CorrespondenceText = reader.GetString(0);
					//1:Parameter CMN_PER_PersonInfo_CorrespondenceID of type Guid
					resultItem.CMN_PER_PersonInfo_CorrespondenceID = reader.GetGuid(1);
					//2:Parameter IsDefaultCorrespondence of type bool
					resultItem.IsDefaultCorrespondence = reader.GetBoolean(2);
					//3:Parameter CorrespondenceType_RefID of type Guid
					resultItem.CorrespondenceType_RefID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Correspondences_for_BusinessParticipant",ex);
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
		public static FR_L2CO_GCfBP_1355_Array Invoke(string ConnectionString,P_L2CO_GCfBP_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2CO_GCfBP_1355_Array Invoke(DbConnection Connection,P_L2CO_GCfBP_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2CO_GCfBP_1355_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2CO_GCfBP_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2CO_GCfBP_1355_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2CO_GCfBP_1355 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2CO_GCfBP_1355_Array functionReturn = new FR_L2CO_GCfBP_1355_Array();
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

				throw new Exception("Exception occured in method cls_Get_Correspondences_for_BusinessParticipant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2CO_GCfBP_1355_Array : FR_Base
	{
		public L2CO_GCfBP_1355[] Result	{ get; set; } 
		public FR_L2CO_GCfBP_1355_Array() : base() {}

		public FR_L2CO_GCfBP_1355_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2CO_GCfBP_1355 for attribute P_L2CO_GCfBP_1355
		[DataContract]
		public class P_L2CO_GCfBP_1355 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerID { get; set; } 

		}
		#endregion
		#region SClass L2CO_GCfBP_1355 for attribute L2CO_GCfBP_1355
		[DataContract]
		public class L2CO_GCfBP_1355 
		{
			//Standard type parameters
			[DataMember]
			public String CorrespondenceText { get; set; } 
			[DataMember]
			public Guid CMN_PER_PersonInfo_CorrespondenceID { get; set; } 
			[DataMember]
			public bool IsDefaultCorrespondence { get; set; } 
			[DataMember]
			public Guid CorrespondenceType_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2CO_GCfBP_1355_Array cls_Get_Correspondences_for_BusinessParticipant(,P_L2CO_GCfBP_1355 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2CO_GCfBP_1355_Array invocationResult = cls_Get_Correspondences_for_BusinessParticipant.Invoke(connectionString,P_L2CO_GCfBP_1355 Parameter,securityTicket);
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
var parameter = new CL2_Correspondences.Atomic.Retrieval.P_L2CO_GCfBP_1355();
parameter.CustomerID = ...;

*/
