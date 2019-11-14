/* 
 * Generated on 3/14/2014 9:40:10 AM
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

namespace CL5_KPRS_Actions.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Actions_For_BasementProperty.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Actions_For_BasementProperty
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AT_GAFBP_1002_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AT_GAFBP_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AT_GAFBP_1002_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_KPRS_Actions.Atomic.Retrieval.SQL.cls_Get_Actions_For_BasementProperty.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PropertyID", Parameter.PropertyID);


			List<L5AT_GAFBP_1002> results = new List<L5AT_GAFBP_1002>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "Action_Name_DictID","RES_ACT_Action_VersionID","Default_PricePerUnit_RefID","Default_Unit_RefID","Default_UnitAmount","Action_Description_DictID" });
				while(reader.Read())
				{
					L5AT_GAFBP_1002 resultItem = new L5AT_GAFBP_1002();
					//0:Parameter Action_Name of type Dict
					resultItem.Action_Name = reader.GetDictionary(0);
					resultItem.Action_Name.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Name);
					//1:Parameter RES_ACT_Action_VersionID of type Guid
					resultItem.RES_ACT_Action_VersionID = reader.GetGuid(1);
					//2:Parameter Default_PricePerUnit_RefID of type Guid
					resultItem.Default_PricePerUnit_RefID = reader.GetGuid(2);
					//3:Parameter Default_Unit_RefID of type Guid
					resultItem.Default_Unit_RefID = reader.GetGuid(3);
					//4:Parameter Default_UnitAmount of type Double
					resultItem.Default_UnitAmount = reader.GetDouble(4);
					//5:Parameter Action_Description of type Dict
					resultItem.Action_Description = reader.GetDictionary(5);
					resultItem.Action_Description.SourceTable = "res_act_action_version";
					loader.Append(resultItem.Action_Description);

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
		public static FR_L5AT_GAFBP_1002_Array Invoke(string ConnectionString,P_L5AT_GAFBP_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AT_GAFBP_1002_Array Invoke(DbConnection Connection,P_L5AT_GAFBP_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AT_GAFBP_1002_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AT_GAFBP_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AT_GAFBP_1002_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AT_GAFBP_1002 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AT_GAFBP_1002_Array functionReturn = new FR_L5AT_GAFBP_1002_Array();
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
	public class FR_L5AT_GAFBP_1002_Array : FR_Base
	{
		public L5AT_GAFBP_1002[] Result	{ get; set; } 
		public FR_L5AT_GAFBP_1002_Array() : base() {}

		public FR_L5AT_GAFBP_1002_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AT_GAFBP_1002 for attribute P_L5AT_GAFBP_1002
		[DataContract]
		public class P_L5AT_GAFBP_1002 
		{
			//Standard type parameters
			[DataMember]
			public Guid PropertyID { get; set; } 

		}
		#endregion
		#region SClass L5AT_GAFBP_1002 for attribute L5AT_GAFBP_1002
		[DataContract]
		public class L5AT_GAFBP_1002 
		{
			//Standard type parameters
			[DataMember]
			public Dict Action_Name { get; set; } 
			[DataMember]
			public Guid RES_ACT_Action_VersionID { get; set; } 
			[DataMember]
			public Guid Default_PricePerUnit_RefID { get; set; } 
			[DataMember]
			public Guid Default_Unit_RefID { get; set; } 
			[DataMember]
			public Double Default_UnitAmount { get; set; } 
			[DataMember]
			public Dict Action_Description { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AT_GAFBP_1002_Array cls_Get_Actions_For_BasementProperty(P_L5AT_GAFBP_1002 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5AT_GAFBP_1002_Array result = cls_Get_Actions_For_BasementProperty.Invoke(connectionString,P_L5AT_GAFBP_1002 Parameter,securityTicket);
	 return result;
}
*/