/* 
 * Generated on 7/8/2013 11:03:33 AM
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

namespace CL3_Document.Atomic.Retrieval
{
	/// <summary>
    /// Get DocumentStructure  for DocumentHeaderID
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DocumentStructures_for_DHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DocumentStructures_for_DHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3DO_GDfDH_1108_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3DO_GDfDH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3DO_GDfDH_1108_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Document.Atomic.Retrieval.SQL.cls_Get_DocumentStructures_for_DHeaderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DHeaderID", Parameter.DHeaderID);


			List<L3DO_GDfDH_1108> results = new List<L3DO_GDfDH_1108>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "DOC_StructureID","Label","Parent_RefID","Structure_Header_RefID" });
				while(reader.Read())
				{
					L3DO_GDfDH_1108 resultItem = new L3DO_GDfDH_1108();
					//0:Parameter DOC_StructureID of type Guid
					resultItem.DOC_StructureID = reader.GetGuid(0);
					//1:Parameter Label of type string
					resultItem.Label = reader.GetString(1);
					//2:Parameter Parent_RefID of type Guid
					resultItem.Parent_RefID = reader.GetGuid(2);
					//3:Parameter Structure_Header_RefID of type Guid
					resultItem.Structure_Header_RefID = reader.GetGuid(3);

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
		public static FR_L3DO_GDfDH_1108_Array Invoke(string ConnectionString,P_L3DO_GDfDH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3DO_GDfDH_1108_Array Invoke(DbConnection Connection,P_L3DO_GDfDH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3DO_GDfDH_1108_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3DO_GDfDH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3DO_GDfDH_1108_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3DO_GDfDH_1108 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3DO_GDfDH_1108_Array functionReturn = new FR_L3DO_GDfDH_1108_Array();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3DO_GDfDH_1108_Array : FR_Base
	{
		public L3DO_GDfDH_1108[] Result	{ get; set; } 
		public FR_L3DO_GDfDH_1108_Array() : base() {}

		public FR_L3DO_GDfDH_1108_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3DO_GDfDH_1108 for attribute P_L3DO_GDfDH_1108
		[DataContract]
		public class P_L3DO_GDfDH_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid DHeaderID { get; set; } 

		}
		#endregion
		#region SClass L3DO_GDfDH_1108 for attribute L3DO_GDfDH_1108
		[DataContract]
		public class L3DO_GDfDH_1108 
		{
			//Standard type parameters
			[DataMember]
			public Guid DOC_StructureID { get; set; } 
			[DataMember]
			public string Label { get; set; } 
			[DataMember]
			public Guid Parent_RefID { get; set; } 
			[DataMember]
			public Guid Structure_Header_RefID { get; set; } 

		}
		#endregion

	#endregion
}
