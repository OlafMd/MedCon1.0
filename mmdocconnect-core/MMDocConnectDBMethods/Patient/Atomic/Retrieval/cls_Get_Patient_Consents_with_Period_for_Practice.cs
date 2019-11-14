/* 
 * Generated on 03/02/17 17:51:27
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

namespace MMDocConnectDBMethods.Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Patient_Consents_with_Period_for_Practice.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Patient_Consents_with_Period_for_Practice
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GPCwPfP_1538_Array Execute(DbConnection Connection,DbTransaction Transaction,P_PA_GPCwPfP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GPCwPfP_1538_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_Patient_Consents_with_Period_for_Practice.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PracticeID", Parameter.PracticeID);



			List<PA_GPCwPfP_1538> results = new List<PA_GPCwPfP_1538>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_RefID","Ext_CMN_CTR_Contract_RefID","ValidThrough","ValidFrom","HealthcareProduct_RefID" });
				while(reader.Read())
				{
					PA_GPCwPfP_1538 resultItem = new PA_GPCwPfP_1538();
					//0:Parameter HEC_Patient_RefID of type Guid
					resultItem.HEC_Patient_RefID = reader.GetGuid(0);
					//1:Parameter Ext_CMN_CTR_Contract_RefID of type Guid
					resultItem.Ext_CMN_CTR_Contract_RefID = reader.GetGuid(1);
					//2:Parameter ValidThrough of type DateTime
					resultItem.ValidThrough = reader.GetDate(2);
					//3:Parameter ValidFrom of type DateTime
					resultItem.ValidFrom = reader.GetDate(3);
					//4:Parameter HealthcareProduct_RefID of type Guid
					resultItem.HealthcareProduct_RefID = reader.GetGuid(4);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Patient_Consents_with_Period_for_Practice",ex);
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
		public static FR_PA_GPCwPfP_1538_Array Invoke(string ConnectionString,P_PA_GPCwPfP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GPCwPfP_1538_Array Invoke(DbConnection Connection,P_PA_GPCwPfP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GPCwPfP_1538_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_PA_GPCwPfP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GPCwPfP_1538_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_PA_GPCwPfP_1538 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GPCwPfP_1538_Array functionReturn = new FR_PA_GPCwPfP_1538_Array();
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

				throw new Exception("Exception occured in method cls_Get_Patient_Consents_with_Period_for_Practice",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GPCwPfP_1538_Array : FR_Base
	{
		public PA_GPCwPfP_1538[] Result	{ get; set; } 
		public FR_PA_GPCwPfP_1538_Array() : base() {}

		public FR_PA_GPCwPfP_1538_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_PA_GPCwPfP_1538 for attribute P_PA_GPCwPfP_1538
		[DataContract]
		public class P_PA_GPCwPfP_1538 
		{
			//Standard type parameters
			[DataMember]
			public Guid PracticeID { get; set; } 

		}
		#endregion
		#region SClass PA_GPCwPfP_1538 for attribute PA_GPCwPfP_1538
		[DataContract]
		public class PA_GPCwPfP_1538 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_RefID { get; set; } 
			[DataMember]
			public Guid Ext_CMN_CTR_Contract_RefID { get; set; } 
			[DataMember]
			public DateTime ValidThrough { get; set; } 
			[DataMember]
			public DateTime ValidFrom { get; set; } 
			[DataMember]
			public Guid HealthcareProduct_RefID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GPCwPfP_1538_Array cls_Get_Patient_Consents_with_Period_for_Practice(,P_PA_GPCwPfP_1538 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GPCwPfP_1538_Array invocationResult = cls_Get_Patient_Consents_with_Period_for_Practice.Invoke(connectionString,P_PA_GPCwPfP_1538 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Patient.Atomic.Retrieval.P_PA_GPCwPfP_1538();
parameter.PracticeID = ...;

*/
