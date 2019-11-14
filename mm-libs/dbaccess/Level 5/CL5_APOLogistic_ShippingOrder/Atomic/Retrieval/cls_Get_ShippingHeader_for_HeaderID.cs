/* 
 * Generated on 2/27/2014 11:45:05 AM
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

namespace CL5_APOLogistic_ShippingOrder.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShippingHeader_for_HeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShippingHeader_for_HeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5SO_GSHfH_1040 Execute(DbConnection Connection,DbTransaction Transaction,P_L5SO_GSHfH_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5SO_GSHfH_1040();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.SQL.cls_Get_ShippingHeader_for_HeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"HeaderID", Parameter.HeaderID);



			List<L5SO_GSHfH_1040> results = new List<L5SO_GSHfH_1040>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "LOG_SHP_Shipment_HeaderID","CompanyName_Line1","IsDeleted","IsReadyForPicking","CustomerOrder_Number" });
				while(reader.Read())
				{
					L5SO_GSHfH_1040 resultItem = new L5SO_GSHfH_1040();
					//0:Parameter LOG_SHP_Shipment_HeaderID of type Guid
					resultItem.LOG_SHP_Shipment_HeaderID = reader.GetGuid(0);
					//1:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(1);
					//2:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(2);
					//3:Parameter IsReadyForPicking of type bool
					resultItem.IsReadyForPicking = reader.GetBoolean(3);
					//4:Parameter CustomerOrder_Number of type String
					resultItem.CustomerOrder_Number = reader.GetString(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_ShippingHeader_for_HeaderID",ex);
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
		public static FR_L5SO_GSHfH_1040 Invoke(string ConnectionString,P_L5SO_GSHfH_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5SO_GSHfH_1040 Invoke(DbConnection Connection,P_L5SO_GSHfH_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5SO_GSHfH_1040 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5SO_GSHfH_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5SO_GSHfH_1040 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5SO_GSHfH_1040 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5SO_GSHfH_1040 functionReturn = new FR_L5SO_GSHfH_1040();
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

				throw new Exception("Exception occured in method cls_Get_ShippingHeader_for_HeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5SO_GSHfH_1040 : FR_Base
	{
		public L5SO_GSHfH_1040 Result	{ get; set; }

		public FR_L5SO_GSHfH_1040() : base() {}

		public FR_L5SO_GSHfH_1040(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5SO_GSHfH_1040 for attribute P_L5SO_GSHfH_1040
		[DataContract]
		public class P_L5SO_GSHfH_1040 
		{
			//Standard type parameters
			[DataMember]
			public Guid HeaderID { get; set; } 

		}
		#endregion
		#region SClass L5SO_GSHfH_1040 for attribute L5SO_GSHfH_1040
		[DataContract]
		public class L5SO_GSHfH_1040 
		{
			//Standard type parameters
			[DataMember]
			public Guid LOG_SHP_Shipment_HeaderID { get; set; } 
			[DataMember]
			public String CompanyName_Line1 { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public bool IsReadyForPicking { get; set; } 
			[DataMember]
			public String CustomerOrder_Number { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5SO_GSHfH_1040 cls_Get_ShippingHeader_for_HeaderID(,P_L5SO_GSHfH_1040 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5SO_GSHfH_1040 invocationResult = cls_Get_ShippingHeader_for_HeaderID.Invoke(connectionString,P_L5SO_GSHfH_1040 Parameter,securityTicket);
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
var parameter = new CL5_APOLogistic_ShippingOrder.Atomic.Retrieval.P_L5SO_GSHfH_1040();
parameter.HeaderID = ...;

*/
