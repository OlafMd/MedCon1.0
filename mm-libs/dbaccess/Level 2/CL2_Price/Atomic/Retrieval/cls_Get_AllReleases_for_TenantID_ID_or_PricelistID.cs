/* 
 * Generated on 12/13/2013 4:05:33 PM
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

namespace CL2_Price.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllReleases_for_TenantID_ID_or_PricelistID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllReleases_for_TenantID_ID_or_PricelistID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2PL_GARfToPID_1730_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L2PL_GARfToPID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2PL_GARfToPID_1730_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_Price.Atomic.Retrieval.SQL.cls_Get_AllReleases_for_TenantID_ID_or_PricelistID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PricelistID", Parameter.PricelistID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ReleaseID", Parameter.ReleaseID);



			List<L2PL_GARfToPID_1730> results = new List<L2PL_GARfToPID_1730>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "PricelistRelease_Comment","PricelistRelease_ValidFrom","PricelistRelease_ValidTo","Release_Version","Pricelist_RefID","CMN_SLS_Pricelist_ReleaseID" });
				while(reader.Read())
				{
					L2PL_GARfToPID_1730 resultItem = new L2PL_GARfToPID_1730();
					//0:Parameter PricelistRelease_Comment of type String
					resultItem.PricelistRelease_Comment = reader.GetString(0);
					//1:Parameter PricelistRelease_ValidFrom of type DateTime
					resultItem.PricelistRelease_ValidFrom = reader.GetDate(1);
					//2:Parameter PricelistRelease_ValidTo of type DateTime
					resultItem.PricelistRelease_ValidTo = reader.GetDate(2);
					//3:Parameter Release_Version of type String
					resultItem.Release_Version = reader.GetString(3);
					//4:Parameter Pricelist_RefID of type Guid
					resultItem.Pricelist_RefID = reader.GetGuid(4);
					//5:Parameter CMN_SLS_Pricelist_ReleaseID of type Guid
					resultItem.CMN_SLS_Pricelist_ReleaseID = reader.GetGuid(5);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_AllReleases_for_TenantID_ID_or_PricelistID",ex);
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
		public static FR_L2PL_GARfToPID_1730_Array Invoke(string ConnectionString,P_L2PL_GARfToPID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2PL_GARfToPID_1730_Array Invoke(DbConnection Connection,P_L2PL_GARfToPID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2PL_GARfToPID_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L2PL_GARfToPID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2PL_GARfToPID_1730_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L2PL_GARfToPID_1730 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2PL_GARfToPID_1730_Array functionReturn = new FR_L2PL_GARfToPID_1730_Array();
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

				throw new Exception("Exception occured in method cls_Get_AllReleases_for_TenantID_ID_or_PricelistID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2PL_GARfToPID_1730_Array : FR_Base
	{
		public L2PL_GARfToPID_1730[] Result	{ get; set; } 
		public FR_L2PL_GARfToPID_1730_Array() : base() {}

		public FR_L2PL_GARfToPID_1730_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L2PL_GARfToPID_1730 for attribute P_L2PL_GARfToPID_1730
		[DataContract]
		public class P_L2PL_GARfToPID_1730 
		{
			//Standard type parameters
			[DataMember]
			public Guid? PricelistID { get; set; } 
			[DataMember]
			public Guid? ReleaseID { get; set; } 

		}
		#endregion
		#region SClass L2PL_GARfToPID_1730 for attribute L2PL_GARfToPID_1730
		[DataContract]
		public class L2PL_GARfToPID_1730 
		{
			//Standard type parameters
			[DataMember]
			public String PricelistRelease_Comment { get; set; } 
			[DataMember]
			public DateTime PricelistRelease_ValidFrom { get; set; } 
			[DataMember]
			public DateTime PricelistRelease_ValidTo { get; set; } 
			[DataMember]
			public String Release_Version { get; set; } 
			[DataMember]
			public Guid Pricelist_RefID { get; set; } 
			[DataMember]
			public Guid CMN_SLS_Pricelist_ReleaseID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2PL_GARfToPID_1730_Array cls_Get_AllReleases_for_TenantID_ID_or_PricelistID(,P_L2PL_GARfToPID_1730 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2PL_GARfToPID_1730_Array invocationResult = cls_Get_AllReleases_for_TenantID_ID_or_PricelistID.Invoke(connectionString,P_L2PL_GARfToPID_1730 Parameter,securityTicket);
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
var parameter = new CL2_Price.Atomic.Retrieval.P_L2PL_GARfToPID_1730();
parameter.PricelistID = ...;
parameter.ReleaseID = ...;

*/
