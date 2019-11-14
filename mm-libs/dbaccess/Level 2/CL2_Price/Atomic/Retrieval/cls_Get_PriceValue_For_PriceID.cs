/* 
 * Generated on 10/28/2013 3:21:26 PM
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

namespace CL2_Price.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PriceValue_For_PriceID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PriceValue_For_PriceID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PR_GPVFP_0932 Execute(DbConnection Connection,DbTransaction Transaction,P_L2PR_GPVFP_0932 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PR_GPVFP_0932();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Price.Atomic.Retrieval.SQL.cls_Get_PriceValue_For_PriceID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PriceID", Parameter.PriceID);


			List<L2PR_GPVFP_0932> results = new List<L2PR_GPVFP_0932>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PriceValue_Amount" });
				while(reader.Read())
				{
					L2PR_GPVFP_0932 resultItem = new L2PR_GPVFP_0932();
					//0:Parameter PriceValue_Amount of type Double
					resultItem.PriceValue_Amount = reader.GetDouble(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L2PR_GPVFP_0932 Invoke(string ConnectionString,P_L2PR_GPVFP_0932 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PR_GPVFP_0932 Invoke(DbConnection Connection,P_L2PR_GPVFP_0932 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PR_GPVFP_0932 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PR_GPVFP_0932 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PR_GPVFP_0932 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PR_GPVFP_0932 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PR_GPVFP_0932 functionReturn = new FR_L2PR_GPVFP_0932();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PR_GPVFP_0932 : FR_Base
	{
		public L2PR_GPVFP_0932 Result	{ get; set; }

		public FR_L2PR_GPVFP_0932() : base() {}

		public FR_L2PR_GPVFP_0932(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PR_GPVFP_0932 for attribute P_L2PR_GPVFP_0932
		[DataContract]
		public class P_L2PR_GPVFP_0932 
		{
			//Standard type parameters
			[DataMember]
			public Guid PriceID { get; set; } 

		}
		#endregion
		#region SClass L2PR_GPVFP_0932 for attribute L2PR_GPVFP_0932
		[DataContract]
		public class L2PR_GPVFP_0932 
		{
			//Standard type parameters
			[DataMember]
			public Double PriceValue_Amount { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PR_GPVFP_0932 cls_Get_PriceValue_For_PriceID(P_L2PR_GPVFP_0932 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L2PR_GPVFP_0932 result = cls_Get_PriceValue_For_PriceID.Invoke(connectionString,P_L2PR_GPVFP_0932 Parameter,securityTicket);
	 return result;
}
*/