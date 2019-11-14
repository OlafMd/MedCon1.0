/* 
 * Generated on 28.1.2015 12:49:47
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

namespace CL2_EconomicRegion.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_EconomicRegion_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_EconomicRegion_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L2ER_GERfT_1643_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L2ER_GERfT_1643_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL2_EconomicRegion.Atomic.Retrieval.SQL.cls_Get_EconomicRegion_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L2ER_GERfT_1643> results = new List<L2ER_GERfT_1643>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_EconomicRegionID","ParentEconomicRegion_RefID","EconomicRegion_Name_DictID","EconomicRegion_Description_DictID","IsEconomicRegionCountry","Creation_Timestamp","IsDeleted","Tenant_RefID","Modification_Timestamp" });
				while(reader.Read())
				{
					L2ER_GERfT_1643 resultItem = new L2ER_GERfT_1643();
					//0:Parameter CMN_EconomicRegionID of type Guid
					resultItem.CMN_EconomicRegionID = reader.GetGuid(0);
					//1:Parameter ParentEconomicRegion_RefID of type Guid
					resultItem.ParentEconomicRegion_RefID = reader.GetGuid(1);
					//2:Parameter EconomicRegion_Name of type Dict
					resultItem.EconomicRegion_Name = reader.GetDictionary(2);
					resultItem.EconomicRegion_Name.SourceTable = "cmn_economicregion";
					loader.Append(resultItem.EconomicRegion_Name);
					//3:Parameter EconomicRegion_Description of type Dict
					resultItem.EconomicRegion_Description = reader.GetDictionary(3);
					resultItem.EconomicRegion_Description.SourceTable = "cmn_economicregion";
					loader.Append(resultItem.EconomicRegion_Description);
					//4:Parameter IsEconomicRegionCountry of type bool
					resultItem.IsEconomicRegionCountry = reader.GetBoolean(4);
					//5:Parameter Creation_Timestamp of type DateTime
					resultItem.Creation_Timestamp = reader.GetDate(5);
					//6:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(6);
					//7:Parameter Tenant_RefID of type Guid
					resultItem.Tenant_RefID = reader.GetGuid(7);
					//8:Parameter Modification_Timestamp of type DateTime
					resultItem.Modification_Timestamp = reader.GetDate(8);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_EconomicRegion_for_TenantID",ex);
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
		public static FR_L2ER_GERfT_1643_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L2ER_GERfT_1643_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L2ER_GERfT_1643_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L2ER_GERfT_1643_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L2ER_GERfT_1643_Array functionReturn = new FR_L2ER_GERfT_1643_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);

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

				throw new Exception("Exception occured in method cls_Get_EconomicRegion_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L2ER_GERfT_1643_Array : FR_Base
	{
		public L2ER_GERfT_1643[] Result	{ get; set; } 
		public FR_L2ER_GERfT_1643_Array() : base() {}

		public FR_L2ER_GERfT_1643_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L2ER_GERfT_1643 for attribute L2ER_GERfT_1643
		[DataContract]
		public class L2ER_GERfT_1643 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_EconomicRegionID { get; set; } 
			[DataMember]
			public Guid ParentEconomicRegion_RefID { get; set; } 
			[DataMember]
			public Dict EconomicRegion_Name { get; set; } 
			[DataMember]
			public Dict EconomicRegion_Description { get; set; } 
			[DataMember]
			public bool IsEconomicRegionCountry { get; set; } 
			[DataMember]
			public DateTime Creation_Timestamp { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 
			[DataMember]
			public Guid Tenant_RefID { get; set; } 
			[DataMember]
			public DateTime Modification_Timestamp { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L2ER_GERfT_1643_Array cls_Get_EconomicRegion_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L2ER_GERfT_1643_Array invocationResult = cls_Get_EconomicRegion_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

