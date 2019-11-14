/* 
 * Generated on 10/17/2014 10:04:28 AM
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

namespace CL3_Project.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_RightPackages_for_ProjectMemberID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_RightPackages_for_ProjectMemberID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3PR_GRPfPM_1029_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L3PR_GRPfPM_1029 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L3PR_GRPfPM_1029_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL3_Project.Atomic.Retrieval.SQL.cls_Get_RightPackages_for_ProjectMemberID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ProjectMemberID", Parameter.ProjectMemberID);



			List<L3PR_GRPfPM_1029> results = new List<L3PR_GRPfPM_1029>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "AssignmentID","Name_DictID","TMS_PRO_ACC_RightsPackageID","USR_AccountID" });
				while(reader.Read())
				{
					L3PR_GRPfPM_1029 resultItem = new L3PR_GRPfPM_1029();
					//0:Parameter AssignmentID of type Guid
					resultItem.AssignmentID = reader.GetGuid(0);
					//1:Parameter RightsPackage_Name of type Dict
					resultItem.RightsPackage_Name = reader.GetDictionary(1);
					resultItem.RightsPackage_Name.SourceTable = "tms_pro_acc_rightspackages";
					loader.Append(resultItem.RightsPackage_Name);
					//2:Parameter TMS_PRO_ACC_RightsPackageID of type Guid
					resultItem.TMS_PRO_ACC_RightsPackageID = reader.GetGuid(2);
					//3:Parameter USR_AccountID of type Guid
					resultItem.USR_AccountID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_RightPackages_for_ProjectMemberID",ex);
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
		public static FR_L3PR_GRPfPM_1029_Array Invoke(string ConnectionString,P_L3PR_GRPfPM_1029 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3PR_GRPfPM_1029_Array Invoke(DbConnection Connection,P_L3PR_GRPfPM_1029 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3PR_GRPfPM_1029_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PR_GRPfPM_1029 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3PR_GRPfPM_1029_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PR_GRPfPM_1029 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3PR_GRPfPM_1029_Array functionReturn = new FR_L3PR_GRPfPM_1029_Array();
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

				throw new Exception("Exception occured in method cls_Get_RightPackages_for_ProjectMemberID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3PR_GRPfPM_1029_Array : FR_Base
	{
		public L3PR_GRPfPM_1029[] Result	{ get; set; } 
		public FR_L3PR_GRPfPM_1029_Array() : base() {}

		public FR_L3PR_GRPfPM_1029_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3PR_GRPfPM_1029 for attribute P_L3PR_GRPfPM_1029
		[DataContract]
		public class P_L3PR_GRPfPM_1029 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectMemberID { get; set; } 

		}
		#endregion
		#region SClass L3PR_GRPfPM_1029 for attribute L3PR_GRPfPM_1029
		[DataContract]
		public class L3PR_GRPfPM_1029 
		{
			//Standard type parameters
			[DataMember]
			public Guid AssignmentID { get; set; } 
			[DataMember]
			public Dict RightsPackage_Name { get; set; } 
			[DataMember]
			public Guid TMS_PRO_ACC_RightsPackageID { get; set; } 
			[DataMember]
			public Guid USR_AccountID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3PR_GRPfPM_1029_Array cls_Get_RightPackages_for_ProjectMemberID(,P_L3PR_GRPfPM_1029 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3PR_GRPfPM_1029_Array invocationResult = cls_Get_RightPackages_for_ProjectMemberID.Invoke(connectionString,P_L3PR_GRPfPM_1029 Parameter,securityTicket);
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
var parameter = new CL3_Project.Atomic.Retrieval.P_L3PR_GRPfPM_1029();
parameter.ProjectMemberID = ...;

*/
