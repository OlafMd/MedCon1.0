/* 
 * Generated on 18.12.2014 15:52:15
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

namespace CL3_Offices.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PracticeType_MessageData_for_TypeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PracticeType_MessageData_for_TypeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3O_GPTMDFTID_1543 Execute(DbConnection Connection,DbTransaction Transaction,P_L3O_GPTMDFTID_1543 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3O_GPTMDFTID_1543();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Offices.Atomic.Retrieval.SQL.cls_Get_PracticeType_MessageData_for_TypeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"TypeID", Parameter.TypeID);



			List<L3O_GPTMDFTID_1543> results = new List<L3O_GPTMDFTID_1543>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "MedicalPracticeType_Name_DictID","HEC_MedicalPractice_TypeID","MedicalPracticeTypeITL","IsDeleted" });
				while(reader.Read())
				{
					L3O_GPTMDFTID_1543 resultItem = new L3O_GPTMDFTID_1543();
					//0:Parameter MedicalPracticeType_Name of type Dict
					resultItem.MedicalPracticeType_Name = reader.GetDictionary(0);
					resultItem.MedicalPracticeType_Name.SourceTable = "hec_medicalpractice_types";
					loader.Append(resultItem.MedicalPracticeType_Name);
					//1:Parameter HEC_MedicalPractice_TypeID of type Guid
					resultItem.HEC_MedicalPractice_TypeID = reader.GetGuid(1);
					//2:Parameter MedicalPracticeTypeITL of type String
					resultItem.MedicalPracticeTypeITL = reader.GetString(2);
					//3:Parameter IsDeleted of type bool
					resultItem.IsDeleted = reader.GetBoolean(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PracticeType_MessageData_for_TypeID",ex);
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
		public static FR_L3O_GPTMDFTID_1543 Invoke(string ConnectionString,P_L3O_GPTMDFTID_1543 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3O_GPTMDFTID_1543 Invoke(DbConnection Connection,P_L3O_GPTMDFTID_1543 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3O_GPTMDFTID_1543 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3O_GPTMDFTID_1543 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3O_GPTMDFTID_1543 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3O_GPTMDFTID_1543 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3O_GPTMDFTID_1543 functionReturn = new FR_L3O_GPTMDFTID_1543();
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

				throw new Exception("Exception occured in method cls_Get_PracticeType_MessageData_for_TypeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3O_GPTMDFTID_1543 : FR_Base
	{
		public L3O_GPTMDFTID_1543 Result	{ get; set; }

		public FR_L3O_GPTMDFTID_1543() : base() {}

		public FR_L3O_GPTMDFTID_1543(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3O_GPTMDFTID_1543 for attribute P_L3O_GPTMDFTID_1543
		[DataContract]
		public class P_L3O_GPTMDFTID_1543 
		{
			//Standard type parameters
			[DataMember]
			public Guid TypeID { get; set; } 

		}
		#endregion
		#region SClass L3O_GPTMDFTID_1543 for attribute L3O_GPTMDFTID_1543
		[DataContract]
		public class L3O_GPTMDFTID_1543 
		{
			//Standard type parameters
			[DataMember]
			public Dict MedicalPracticeType_Name { get; set; } 
			[DataMember]
			public Guid HEC_MedicalPractice_TypeID { get; set; } 
			[DataMember]
			public String MedicalPracticeTypeITL { get; set; } 
			[DataMember]
			public bool IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3O_GPTMDFTID_1543 cls_Get_PracticeType_MessageData_for_TypeID(,P_L3O_GPTMDFTID_1543 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3O_GPTMDFTID_1543 invocationResult = cls_Get_PracticeType_MessageData_for_TypeID.Invoke(connectionString,P_L3O_GPTMDFTID_1543 Parameter,securityTicket);
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
var parameter = new CL3_Offices.Atomic.Retrieval.P_L3O_GPTMDFTID_1543();
parameter.TypeID = ...;

*/
