/* 
 * Generated on 5/28/2014 10:29:00 AM
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

namespace CL5_APOBilling_Dunning.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DunningDetails_for_BillHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DunningDetails_for_BillHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GDDfBHID_1027_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GDDfBHID_1027 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5BD_GDDfBHID_1027_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOBilling_Dunning.Atomic.Retrieval.SQL.cls_Get_DunningDetails_for_BillHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"BillHeader", Parameter.BillHeader);



			List<L5BD_GDDfBHID_1027> results = new List<L5BD_GDDfBHID_1027>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "ACC_DUN_DunningProcess_MemberBillID","BIL_BillHeader_RefID","ApplicableProcessDunningFees","CurrentUnpaidBillFraction","ACC_DUN_DunningProcessID","ACC_DUN_Dunning_ModelID" });
				while(reader.Read())
				{
					L5BD_GDDfBHID_1027 resultItem = new L5BD_GDDfBHID_1027();
					//0:Parameter ACC_DUN_DunningProcess_MemberBillID of type Guid
					resultItem.ACC_DUN_DunningProcess_MemberBillID = reader.GetGuid(0);
					//1:Parameter BIL_BillHeader_RefID of type Guid
					resultItem.BIL_BillHeader_RefID = reader.GetGuid(1);
					//2:Parameter ApplicableProcessDunningFees of type String
					resultItem.ApplicableProcessDunningFees = reader.GetString(2);
					//3:Parameter CurrentUnpaidBillFraction of type String
					resultItem.CurrentUnpaidBillFraction = reader.GetString(3);
					//4:Parameter ACC_DUN_DunningProcessID of type Guid
					resultItem.ACC_DUN_DunningProcessID = reader.GetGuid(4);
					//5:Parameter ACC_DUN_Dunning_ModelID of type Guid
					resultItem.ACC_DUN_Dunning_ModelID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_DunningDetails_for_BillHeaderID",ex);
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
		public static FR_L5BD_GDDfBHID_1027_Array Invoke(string ConnectionString,P_L5BD_GDDfBHID_1027 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GDDfBHID_1027_Array Invoke(DbConnection Connection,P_L5BD_GDDfBHID_1027 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GDDfBHID_1027_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GDDfBHID_1027 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GDDfBHID_1027_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GDDfBHID_1027 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GDDfBHID_1027_Array functionReturn = new FR_L5BD_GDDfBHID_1027_Array();
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

				throw new Exception("Exception occured in method cls_Get_DunningDetails_for_BillHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GDDfBHID_1027_Array : FR_Base
	{
		public L5BD_GDDfBHID_1027[] Result	{ get; set; } 
		public FR_L5BD_GDDfBHID_1027_Array() : base() {}

		public FR_L5BD_GDDfBHID_1027_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GDDfBHID_1027 for attribute P_L5BD_GDDfBHID_1027
		[DataContract]
		public class P_L5BD_GDDfBHID_1027 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeader { get; set; } 

		}
		#endregion
		#region SClass L5BD_GDDfBHID_1027 for attribute L5BD_GDDfBHID_1027
		[DataContract]
		public class L5BD_GDDfBHID_1027 
		{
			//Standard type parameters
			[DataMember]
			public Guid ACC_DUN_DunningProcess_MemberBillID { get; set; } 
			[DataMember]
			public Guid BIL_BillHeader_RefID { get; set; } 
			[DataMember]
			public String ApplicableProcessDunningFees { get; set; } 
			[DataMember]
			public String CurrentUnpaidBillFraction { get; set; } 
			[DataMember]
			public Guid ACC_DUN_DunningProcessID { get; set; } 
			[DataMember]
			public Guid ACC_DUN_Dunning_ModelID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_GDDfBHID_1027_Array cls_Get_DunningDetails_for_BillHeaderID(,P_L5BD_GDDfBHID_1027 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BD_GDDfBHID_1027_Array invocationResult = cls_Get_DunningDetails_for_BillHeaderID.Invoke(connectionString,P_L5BD_GDDfBHID_1027 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Dunning.Atomic.Retrieval.P_L5BD_GDDfBHID_1027();
parameter.BillHeader = ...;

*/
