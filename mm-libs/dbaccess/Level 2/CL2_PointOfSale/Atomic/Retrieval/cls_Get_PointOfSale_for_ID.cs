/* 
 * Generated on 12/18/2014 4:00:09 PM
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

namespace CL2_PointOfSale.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PointOfSale_for_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PointOfSale_for_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PUS_GAPUSFTID_1130 Execute(DbConnection Connection,DbTransaction Transaction,P_L2PUS_GAPUSFID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PUS_GAPUSFTID_1130();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_PointOfSale.Atomic.Retrieval.SQL.cls_Get_PointOfSale_for_ID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PointOfSaleID", Parameter.PointOfSaleID);



			List<L2PUS_GAPUSFTID_1130> results = new List<L2PUS_GAPUSFTID_1130>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_SLS_PointOfSaleID","CMN_STR_Office_RefID","PointOfSale_DisplayName","IsDeleted","Tenant_RefID" });
				while(reader.Read())
				{
					L2PUS_GAPUSFTID_1130 resultItem = new L2PUS_GAPUSFTID_1130();
					//0:Parameter CMN_SLS_PointOfSaleID of type Guid
					resultItem.CMN_SLS_PointOfSaleID = reader.GetGuid(0);
					//1:Parameter CMN_STR_Office_RefID of type Guid
					resultItem.CMN_STR_Office_RefID = reader.GetGuid(1);
					//2:Parameter PointOfSale_DisplayName of type String
					resultItem.PointOfSale_DisplayName = reader.GetString(2);
					//3:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(3);
					//4:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PointOfSale_for_ID",ex);
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
		public static FR_L2PUS_GAPUSFTID_1130 Invoke(string ConnectionString,P_L2PUS_GAPUSFID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PUS_GAPUSFTID_1130 Invoke(DbConnection Connection,P_L2PUS_GAPUSFID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PUS_GAPUSFTID_1130 Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PUS_GAPUSFID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PUS_GAPUSFTID_1130 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PUS_GAPUSFID_1130 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PUS_GAPUSFTID_1130 functionReturn = new FR_L2PUS_GAPUSFTID_1130();
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

				throw new Exception("Exception occured in method cls_Get_PointOfSale_for_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PUS_GAPUSFTID_1130 : FR_Base
	{
		public L2PUS_GAPUSFTID_1130 Result	{ get; set; }

		public FR_L2PUS_GAPUSFTID_1130() : base() {}

		public FR_L2PUS_GAPUSFTID_1130(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PUS_GAPUSFID_1130 for attribute P_L2PUS_GAPUSFID_1130
		[DataContract]
		public class P_L2PUS_GAPUSFID_1130 
		{
			//Standard type parameters
			[DataMember]
			public Guid PointOfSaleID { get; set; } 

		}
		#endregion
		#region SClass L2PUS_GAPUSFTID_1130 for attribute L2PUS_GAPUSFTID_1130
		[DataContract]
		public class L2PUS_GAPUSFTID_1130 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_SLS_PointOfSaleID { get; set; } 
			[DataMember]
			public Guid CMN_STR_Office_RefID { get; set; } 
			[DataMember]
			public String PointOfSale_DisplayName { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PUS_GAPUSFTID_1130 cls_Get_PointOfSale_for_ID(,P_L2PUS_GAPUSFID_1130 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PUS_GAPUSFTID_1130 invocationResult = cls_Get_PointOfSale_for_ID.Invoke(connectionString,P_L2PUS_GAPUSFID_1130 Parameter,securityTicket);
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
var parameter = new CL2_PointOfSale.Atomic.Retrieval.P_L2PUS_GAPUSFID_1130();
parameter.PointOfSaleID = ...;

*/
