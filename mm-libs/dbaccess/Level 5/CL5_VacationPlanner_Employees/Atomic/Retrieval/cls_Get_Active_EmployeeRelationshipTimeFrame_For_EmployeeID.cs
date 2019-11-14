/* 
 * Generated on 2/13/2014 11:32:45 AM
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Employees.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EM_GAERCTFFE_1405 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EM_GAERCTFFE_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5EM_GAERCTFFE_1405();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Employees.Atomic.Retrieval.SQL.cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"EmployeeID", Parameter.EmployeeID);



			List<L5EM_GAERCTFFE_1405> results = new List<L5EM_GAERCTFFE_1405>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_BPT_EMP_EmployeeID","BusinessParticipant_RefID","Staff_Number","StandardFunction","EmployeeDocument_Structure_RefID","InstanceOf_EmploymentRelationships_Template_RefID","IsLockedFor_TemplateUpdates","Work_EndDate","Work_StartDate","HasWorkRelationEnded","CMN_BPT_EMP_EmploymentRelationshipID","CMN_BPT_EMP_EmploymentRelationship_TimeframeID","CMN_CAL_CalculationTimeframeID","CalculationTimeframe_StartDate","CalculationTimefrate_EndDate","CalculationTimeframe_EstimatedEndDate","IsCalculationTimeframe_Active" });
				while(reader.Read())
				{
					L5EM_GAERCTFFE_1405 resultItem = new L5EM_GAERCTFFE_1405();
					//0:Parameter CMN_BPT_EMP_EmployeeID of type Guid
					resultItem.CMN_BPT_EMP_EmployeeID = reader.GetGuid(0);
					//1:Parameter BusinessParticipant_RefID of type Guid
					resultItem.BusinessParticipant_RefID = reader.GetGuid(1);
					//2:Parameter Staff_Number of type String
					resultItem.Staff_Number = reader.GetString(2);
					//3:Parameter StandardFunction of type String
					resultItem.StandardFunction = reader.GetString(3);
					//4:Parameter EmployeeDocument_Structure_RefID of type Guid
					resultItem.EmployeeDocument_Structure_RefID = reader.GetGuid(4);
					//5:Parameter InstanceOf_EmploymentRelationships_Template_RefID of type Guid
					resultItem.InstanceOf_EmploymentRelationships_Template_RefID = reader.GetGuid(5);
					//6:Parameter IsLockedFor_TemplateUpdates of type bool
					resultItem.IsLockedFor_TemplateUpdates = reader.GetBoolean(6);
					//7:Parameter Work_EndDate of type DateTime
					resultItem.Work_EndDate = reader.GetDate(7);
					//8:Parameter Work_StartDate of type DateTime
					resultItem.Work_StartDate = reader.GetDate(8);
					//9:Parameter HasWorkRelationEnded of type bool
					resultItem.HasWorkRelationEnded = reader.GetBoolean(9);
					//10:Parameter CMN_BPT_EMP_EmploymentRelationshipID of type Guid
					resultItem.CMN_BPT_EMP_EmploymentRelationshipID = reader.GetGuid(10);
					//11:Parameter CMN_BPT_EMP_EmploymentRelationship_TimeframeID of type Guid
					resultItem.CMN_BPT_EMP_EmploymentRelationship_TimeframeID = reader.GetGuid(11);
					//12:Parameter CMN_CAL_CalculationTimeframeID of type Guid
					resultItem.CMN_CAL_CalculationTimeframeID = reader.GetGuid(12);
					//13:Parameter CalculationTimeframe_StartDate of type DateTime
					resultItem.CalculationTimeframe_StartDate = reader.GetDate(13);
					//14:Parameter CalculationTimefrate_EndDate of type DateTime
					resultItem.CalculationTimefrate_EndDate = reader.GetDate(14);
					//15:Parameter CalculationTimeframe_EstimatedEndDate of type DateTime
					resultItem.CalculationTimeframe_EstimatedEndDate = reader.GetDate(15);
					//16:Parameter IsCalculationTimeframe_Active of type bool
					resultItem.IsCalculationTimeframe_Active = reader.GetBoolean(16);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID",ex);
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
		public static FR_L5EM_GAERCTFFE_1405 Invoke(string ConnectionString,P_L5EM_GAERCTFFE_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EM_GAERCTFFE_1405 Invoke(DbConnection Connection,P_L5EM_GAERCTFFE_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EM_GAERCTFFE_1405 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EM_GAERCTFFE_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EM_GAERCTFFE_1405 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EM_GAERCTFFE_1405 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EM_GAERCTFFE_1405 functionReturn = new FR_L5EM_GAERCTFFE_1405();
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

				throw new Exception("Exception occured in method cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EM_GAERCTFFE_1405 : FR_Base
	{
		public L5EM_GAERCTFFE_1405 Result	{ get; set; }

		public FR_L5EM_GAERCTFFE_1405() : base() {}

		public FR_L5EM_GAERCTFFE_1405(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EM_GAERCTFFE_1405 cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID(,P_L5EM_GAERCTFFE_1405 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5EM_GAERCTFFE_1405 invocationResult = cls_Get_Active_EmployeeRelationshipTimeFrame_For_EmployeeID.Invoke(connectionString,P_L5EM_GAERCTFFE_1405 Parameter,securityTicket);
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
var parameter = new CL5_VacationPlanner_Employees.Atomic.Retrieval.P_L5EM_GAERCTFFE_1405();
parameter.EmployeeID = ...;

*/