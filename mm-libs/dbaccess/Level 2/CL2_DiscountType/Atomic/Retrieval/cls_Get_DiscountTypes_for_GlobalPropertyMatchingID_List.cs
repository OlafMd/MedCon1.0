/* 
 * Generated on 7/11/2014 10:08:23 AM
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

namespace CL2_DiscountType.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2DT_GDTfGPMIL_1546_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2DT_GDTfGPMIL_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2DT_GDTfGPMIL_1546_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_DiscountType.Atomic.Retrieval.SQL.cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@GlobalPropertyMatchingID_List"," IN $$GlobalPropertyMatchingID_List$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$GlobalPropertyMatchingID_List$",Parameter.GlobalPropertyMatchingID_List);


			List<L2DT_GDTfGPMIL_1546> results = new List<L2DT_GDTfGPMIL_1546>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ORD_PRC_DiscountTypeID","GlobalPropertyMatchingID","DisplayName" });
				while(reader.Read())
				{
					L2DT_GDTfGPMIL_1546 resultItem = new L2DT_GDTfGPMIL_1546();
					//0:Parameter ORD_PRC_DiscountTypeID of type Guid
					resultItem.ORD_PRC_DiscountTypeID = reader.GetGuid(0);
					//1:Parameter GlobalPropertyMatchingID of type String
					resultItem.GlobalPropertyMatchingID = reader.GetString(1);
					//2:Parameter DisplayName of type String
					resultItem.DisplayName = reader.GetString(2);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List",ex);
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
		public static FR_L2DT_GDTfGPMIL_1546_Array Invoke(string ConnectionString,P_L2DT_GDTfGPMIL_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2DT_GDTfGPMIL_1546_Array Invoke(DbConnection Connection,P_L2DT_GDTfGPMIL_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2DT_GDTfGPMIL_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2DT_GDTfGPMIL_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2DT_GDTfGPMIL_1546_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2DT_GDTfGPMIL_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2DT_GDTfGPMIL_1546_Array functionReturn = new FR_L2DT_GDTfGPMIL_1546_Array();
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

				throw new Exception("Exception occured in method cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2DT_GDTfGPMIL_1546_Array : FR_Base
	{
		public L2DT_GDTfGPMIL_1546[] Result	{ get; set; } 
		public FR_L2DT_GDTfGPMIL_1546_Array() : base() {}

		public FR_L2DT_GDTfGPMIL_1546_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2DT_GDTfGPMIL_1546 for attribute P_L2DT_GDTfGPMIL_1546
		[DataContract]
		public class P_L2DT_GDTfGPMIL_1546 
		{
			//Standard type parameters
			[DataMember]
			public String[] GlobalPropertyMatchingID_List { get; set; } 

		}
		#endregion
		#region SClass L2DT_GDTfGPMIL_1546 for attribute L2DT_GDTfGPMIL_1546
		[DataContract]
		public class L2DT_GDTfGPMIL_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid ORD_PRC_DiscountTypeID { get; set; } 
			[DataMember]
			public String GlobalPropertyMatchingID { get; set; } 
			[DataMember]
			public String DisplayName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2DT_GDTfGPMIL_1546_Array cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List(,P_L2DT_GDTfGPMIL_1546 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2DT_GDTfGPMIL_1546_Array invocationResult = cls_Get_DiscountTypes_for_GlobalPropertyMatchingID_List.Invoke(connectionString,P_L2DT_GDTfGPMIL_1546 Parameter,securityTicket);
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
var parameter = new CL2_DiscountType.Atomic.Retrieval.P_L2DT_GDTfGPMIL_1546();
parameter.GlobalPropertyMatchingID_List = ...;

*/
