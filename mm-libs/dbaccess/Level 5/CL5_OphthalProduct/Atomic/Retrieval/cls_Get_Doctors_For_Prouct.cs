/* 
 * Generated on 9/3/2013 10:59:52 AM
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

namespace CL5_OphthalProduct.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Doctors_For_Prouct.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Doctors_For_Prouct
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OP_GDFP_1055_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5OP_GDFP_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OP_GDFP_1055_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_OphthalProduct.Atomic.Retrieval.SQL.cls_Get_Doctors_For_Prouct.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TennantID", Parameter.TennantID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L5OP_GDFP_1055> results = new List<L5OP_GDFP_1055>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Doctor_RefID" });
				while(reader.Read())
				{
					L5OP_GDFP_1055 resultItem = new L5OP_GDFP_1055();
					//0:Parameter HEC_Doctor_RefID of type Guid
					resultItem.HEC_Doctor_RefID = reader.GetGuid(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Doctors_For_Prouct",ex);
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
		public static FR_L5OP_GDFP_1055_Array Invoke(string ConnectionString,P_L5OP_GDFP_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OP_GDFP_1055_Array Invoke(DbConnection Connection,P_L5OP_GDFP_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OP_GDFP_1055_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5OP_GDFP_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OP_GDFP_1055_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5OP_GDFP_1055 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OP_GDFP_1055_Array functionReturn = new FR_L5OP_GDFP_1055_Array();
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

				throw new Exception("Exception occured in method cls_Get_Doctors_For_Prouct",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5OP_GDFP_1055_Array : FR_Base
	{
		public L5OP_GDFP_1055[] Result	{ get; set; } 
		public FR_L5OP_GDFP_1055_Array() : base() {}

		public FR_L5OP_GDFP_1055_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5OP_GDFP_1055 for attribute P_L5OP_GDFP_1055
		[DataContract]
		public class P_L5OP_GDFP_1055 
		{
			//Standard type parameters
			[DataMember]
			public Guid TennantID { get; set; } 
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L5OP_GDFP_1055 for attribute L5OP_GDFP_1055
		[DataContract]
		public class L5OP_GDFP_1055 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Doctor_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OP_GDFP_1055_Array cls_Get_Doctors_For_Prouct(,P_L5OP_GDFP_1055 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OP_GDFP_1055_Array invocationResult = cls_Get_Doctors_For_Prouct.Invoke(connectionString,P_L5OP_GDFP_1055 Parameter,securityTicket);
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
var parameter = new CL5_OphthalProduct.Atomic.Retrieval.P_L5OP_GDFP_1055();
parameter.TennantID = ...;
parameter.ProductID = ...;

*/
