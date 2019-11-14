/* 
 * Generated on 7/12/2013 2:56:47 PM
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

namespace CL3_Country.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_All_Regions.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_All_Regions
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CTR_GAR_1440_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3CTR_GAR_1440_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Country.Atomic.Retrieval.SQL.cls_Get_All_Regions.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L3CTR_GAR_1440> results = new List<L3CTR_GAR_1440>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_LOC_RegionID","Region_Name_DictID","Parent_RefID","RegionExternalID" });
				while(reader.Read())
				{
					L3CTR_GAR_1440 resultItem = new L3CTR_GAR_1440();
					//0:Parameter CMN_LOC_RegionID of type Guid
					resultItem.CMN_LOC_RegionID = reader.GetGuid(0);
					//1:Parameter Region_Name of type Dict
					resultItem.Region_Name = reader.GetDictionary(1);
					resultItem.Region_Name.SourceTable = "cmn_loc_regions";
					loader.Append(resultItem.Region_Name);
					//2:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(2);
					//3:Parameter RegionExternalID of type Guid
					resultItem.RegionExternalID = reader.GetGuid(3);

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

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CTR_GAR_1440_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CTR_GAR_1440_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CTR_GAR_1440_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CTR_GAR_1440_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CTR_GAR_1440_Array functionReturn = new FR_L3CTR_GAR_1440_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CTR_GAR_1440_Array : FR_Base
	{
		public L3CTR_GAR_1440[] Result	{ get; set; } 
		public FR_L3CTR_GAR_1440_Array() : base() {}

		public FR_L3CTR_GAR_1440_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3CTR_GAR_1440 for attribute L3CTR_GAR_1440
		[DataContract]
		public class L3CTR_GAR_1440 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_LOC_RegionID { get; set; } 
			[DataMember]
			public Dict Region_Name { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid RegionExternalID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CTR_GAR_1440_Array cls_Get_All_Regions(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L3CTR_GAR_1440_Array result = cls_Get_All_Regions.Invoke(connectionString,securityTicket);
	 return result;
}
*/