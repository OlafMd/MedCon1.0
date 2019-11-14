/* 
 * Generated on 12/8/2014 11:03:59 AM
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

namespace CL5_Lucentis_Treatment_New.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_TreatmentlData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_TreatmentlData
	{
		public static readonly int QueryTimeout = 6000;

		#region Method Execution
		protected static FR_L5TR_GTD_1607_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5TR_GTD_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TR_GTD_1607_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Treatment_New.Atomic.Retrieval.SQL.cls_Get_TreatmentlData.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"S_Practice", Parameter.S_Practice);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"s_Patient", Parameter.s_Patient);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"s_HealthInsurance", Parameter.s_HealthInsurance);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"StartIndex", Parameter.StartIndex);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"NumberOfElements", Parameter.NumberOfElements);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"statusParameters", Parameter.statusParameters);

            /***Search parameters**/
            if (Parameter.S_Practice != "")
            {
                string newText = command.CommandText.Replace("@S_Practice", Parameter.S_Practice);
                command.CommandText = newText;
            }


            if (Parameter.s_Patient != "")
            {
                string newText = command.CommandText.Replace("@s_Patient", Parameter.s_Patient);
                command.CommandText = newText;
            }


            if (Parameter.s_HealthInsurance != "")
            {
                string newText = command.CommandText.Replace("@s_HealthInsurance", Parameter.s_HealthInsurance);
                command.CommandText = newText;
            }

            /***status parameters**/
            if (Parameter.statusParameters != "")
            {
                string newText = command.CommandText.Replace("@statusParameters", Parameter.statusParameters);
                command.CommandText = newText;
            }

			List<L5TR_GTD_1607> results = new List<L5TR_GTD_1607>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "patient_name","date","health_insurance","status","doctor","practice","id" });
				while(reader.Read())
				{
					L5TR_GTD_1607 resultItem = new L5TR_GTD_1607();
					//0:Parameter patient_name of type String
					resultItem.patient_name = reader.GetString(0);
					//1:Parameter date of type DateTime
					resultItem.date = reader.GetDate(1);
					//2:Parameter health_insurance of type String
					resultItem.health_insurance = reader.GetString(2);
					//3:Parameter status of type String
					resultItem.status = reader.GetString(3);
					//4:Parameter doctor of type String
					resultItem.doctor = reader.GetString(4);
					//5:Parameter practice of type String
					resultItem.practice = reader.GetString(5);
					//6:Parameter id of type Guid
					resultItem.id = reader.GetGuid(6);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_TreatmentlData",ex);
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
		public static FR_L5TR_GTD_1607_Array Invoke(string ConnectionString,P_L5TR_GTD_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TR_GTD_1607_Array Invoke(DbConnection Connection,P_L5TR_GTD_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TR_GTD_1607_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5TR_GTD_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TR_GTD_1607_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5TR_GTD_1607 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TR_GTD_1607_Array functionReturn = new FR_L5TR_GTD_1607_Array();
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

				throw new Exception("Exception occured in method cls_Get_TreatmentlData",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TR_GTD_1607_Array : FR_Base
	{
		public L5TR_GTD_1607[] Result	{ get; set; } 
		public FR_L5TR_GTD_1607_Array() : base() {}

		public FR_L5TR_GTD_1607_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5TR_GTD_1607 for attribute P_L5TR_GTD_1607
		[DataContract]
		public class P_L5TR_GTD_1607 
		{
			//Standard type parameters
			[DataMember]
			public String S_Practice { get; set; } 
			[DataMember]
			public String s_Patient { get; set; } 
			[DataMember]
			public String s_HealthInsurance { get; set; } 
			[DataMember]
			public int StartIndex { get; set; } 
			[DataMember]
			public int NumberOfElements { get; set; } 
			[DataMember]
			public String statusParameters { get; set; } 

		}
		#endregion
		#region SClass L5TR_GTD_1607 for attribute L5TR_GTD_1607
		[DataContract]
		public class L5TR_GTD_1607 
		{
			//Standard type parameters
			[DataMember]
			public String patient_name { get; set; } 
			[DataMember]
			public DateTime date { get; set; } 
			[DataMember]
			public String health_insurance { get; set; } 
			[DataMember]
			public String status { get; set; } 
			[DataMember]
			public String doctor { get; set; } 
			[DataMember]
			public String practice { get; set; } 
			[DataMember]
			public Guid id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TR_GTD_1607_Array cls_Get_TreatmentlData(,P_L5TR_GTD_1607 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5TR_GTD_1607_Array invocationResult = cls_Get_TreatmentlData.Invoke(connectionString,P_L5TR_GTD_1607 Parameter,securityTicket);
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
var parameter = new CL5_Lucentis_Treatment_New.Atomic.Retrieval.P_L5TR_GTD_1607();
parameter.S_Practice = ...;
parameter.s_Patient = ...;
parameter.s_HealthInsurance = ...;
parameter.StartIndex = ...;
parameter.NumberOfElements = ...;
parameter.statusParameters = ...;

*/
