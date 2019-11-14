/* 
 * Generated on 16/9/2014 05:41:26
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

namespace CL5_APOBilling_Bill.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Open_Bills_Basic_Data_for_CustomerID_and_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Open_Bills_Basic_Data_for_CustomerID_and_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GOBBDfCaT_1438_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GOBBDfCaT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BL_GOBBDfCaT_1438_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Bill.Atomic.Retrieval.SQL.cls_Get_Open_Bills_Basic_Data_for_CustomerID_and_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillNumber", Parameter.BillNumber);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"CustomerID", Parameter.CustomerID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillStatusID", Parameter.BillStatusID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"Date", Parameter.Date);



			List<L5BL_GOBBDfCaT_1438> results = new List<L5BL_GOBBDfCaT_1438>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "BIL_BillHeaderID","BillNumber","DateOnBill","BillRecipientName","BillStatusCreationTime" });
				while(reader.Read())
				{
					L5BL_GOBBDfCaT_1438 resultItem = new L5BL_GOBBDfCaT_1438();
					//0:Parameter BIL_BillHeaderID of type Guid
					resultItem.BIL_BillHeaderID = reader.GetGuid(0);
					//1:Parameter BillNumber of type String
					resultItem.BillNumber = reader.GetString(1);
					//2:Parameter DateOnBill of type DateTime
					resultItem.DateOnBill = reader.GetDate(2);
					//3:Parameter BillRecipientName of type String
					resultItem.BillRecipientName = reader.GetString(3);
					//4:Parameter BillStatusCreationTime of type DateTime
					resultItem.BillStatusCreationTime = reader.GetDate(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Open_Bills_Basic_Data_for_CustomerID_and_TenantID",ex);
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
		public static FR_L5BL_GOBBDfCaT_1438_Array Invoke(string ConnectionString,P_L5BL_GOBBDfCaT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GOBBDfCaT_1438_Array Invoke(DbConnection Connection,P_L5BL_GOBBDfCaT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GOBBDfCaT_1438_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GOBBDfCaT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GOBBDfCaT_1438_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GOBBDfCaT_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GOBBDfCaT_1438_Array functionReturn = new FR_L5BL_GOBBDfCaT_1438_Array();
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

				throw new Exception("Exception occured in method cls_Get_Open_Bills_Basic_Data_for_CustomerID_and_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GOBBDfCaT_1438_Array : FR_Base
	{
		public L5BL_GOBBDfCaT_1438[] Result	{ get; set; } 
		public FR_L5BL_GOBBDfCaT_1438_Array() : base() {}

		public FR_L5BL_GOBBDfCaT_1438_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GOBBDfCaT_1438 for attribute P_L5BL_GOBBDfCaT_1438
		[DataContract]
		public class P_L5BL_GOBBDfCaT_1438 
		{
			//Standard type parameters
			[DataMember]
			public String BillNumber { get; set; } 
			[DataMember]
			public Guid CustomerID { get; set; } 
			[DataMember]
			public Guid BillStatusID { get; set; } 
			[DataMember]
			public DateTime? Date { get; set; } 

		}
		#endregion
		#region SClass L5BL_GOBBDfCaT_1438 for attribute L5BL_GOBBDfCaT_1438
		[DataContract]
		public class L5BL_GOBBDfCaT_1438 
		{
			//Standard type parameters
			[DataMember]
			public Guid BIL_BillHeaderID { get; set; } 
			[DataMember]
			public String BillNumber { get; set; } 
			[DataMember]
			public DateTime DateOnBill { get; set; } 
			[DataMember]
			public String BillRecipientName { get; set; } 
			[DataMember]
			public DateTime BillStatusCreationTime { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GOBBDfCaT_1438_Array cls_Get_Open_Bills_Basic_Data_for_CustomerID_and_TenantID(,P_L5BL_GOBBDfCaT_1438 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GOBBDfCaT_1438_Array invocationResult = cls_Get_Open_Bills_Basic_Data_for_CustomerID_and_TenantID.Invoke(connectionString,P_L5BL_GOBBDfCaT_1438 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Atomic.Retrieval.P_L5BL_GOBBDfCaT_1438();
parameter.BillNumber = ...;
parameter.CustomerID = ...;
parameter.BillStatusID = ...;
parameter.Date = ...;

*/
