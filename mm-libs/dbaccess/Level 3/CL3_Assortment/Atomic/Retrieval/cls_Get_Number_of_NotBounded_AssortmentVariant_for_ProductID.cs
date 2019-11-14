/* 
 * Generated on 2/1/2015 21:05:35
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

namespace CL3_Assortment.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Number_of_NotBounded_AssortmentVariant_for_ProductID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Number_of_NotBounded_AssortmentVariant_for_ProductID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3ASS_GNoNBAVfP_2100 Execute(DbConnection Connection,DbTransaction Transaction,P_L3ASS_GNoNBAVfP_2100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3ASS_GNoNBAVfP_2100();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Assortment.Atomic.Retrieval.SQL.cls_Get_Number_of_NotBounded_AssortmentVariant_for_ProductID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProductID", Parameter.ProductID);



			List<L3ASS_GNoNBAVfP_2100> results = new List<L3ASS_GNoNBAVfP_2100>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "NumberOfNotBoundedVariants" });
				while(reader.Read())
				{
					L3ASS_GNoNBAVfP_2100 resultItem = new L3ASS_GNoNBAVfP_2100();
					//0:Parameter NumberOfNotBoundedVariants of type int
					resultItem.NumberOfNotBoundedVariants = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Number_of_NotBounded_AssortmentVariant_for_ProductID",ex);
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
		public static FR_L3ASS_GNoNBAVfP_2100 Invoke(string ConnectionString,P_L3ASS_GNoNBAVfP_2100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3ASS_GNoNBAVfP_2100 Invoke(DbConnection Connection,P_L3ASS_GNoNBAVfP_2100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3ASS_GNoNBAVfP_2100 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3ASS_GNoNBAVfP_2100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3ASS_GNoNBAVfP_2100 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3ASS_GNoNBAVfP_2100 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3ASS_GNoNBAVfP_2100 functionReturn = new FR_L3ASS_GNoNBAVfP_2100();
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

				throw new Exception("Exception occured in method cls_Get_Number_of_NotBounded_AssortmentVariant_for_ProductID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3ASS_GNoNBAVfP_2100 : FR_Base
	{
		public L3ASS_GNoNBAVfP_2100 Result	{ get; set; }

		public FR_L3ASS_GNoNBAVfP_2100() : base() {}

		public FR_L3ASS_GNoNBAVfP_2100(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3ASS_GNoNBAVfP_2100 for attribute P_L3ASS_GNoNBAVfP_2100
		[DataContract]
		public class P_L3ASS_GNoNBAVfP_2100 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProductID { get; set; } 

		}
		#endregion
		#region SClass L3ASS_GNoNBAVfP_2100 for attribute L3ASS_GNoNBAVfP_2100
		[DataContract]
		public class L3ASS_GNoNBAVfP_2100 
		{
			//Standard type parameters
			[DataMember]
			public int NumberOfNotBoundedVariants { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3ASS_GNoNBAVfP_2100 cls_Get_Number_of_NotBounded_AssortmentVariant_for_ProductID(,P_L3ASS_GNoNBAVfP_2100 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3ASS_GNoNBAVfP_2100 invocationResult = cls_Get_Number_of_NotBounded_AssortmentVariant_for_ProductID.Invoke(connectionString,P_L3ASS_GNoNBAVfP_2100 Parameter,securityTicket);
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
var parameter = new CL3_Assortment.Atomic.Retrieval.P_L3ASS_GNoNBAVfP_2100();
parameter.ProductID = ...;

*/
