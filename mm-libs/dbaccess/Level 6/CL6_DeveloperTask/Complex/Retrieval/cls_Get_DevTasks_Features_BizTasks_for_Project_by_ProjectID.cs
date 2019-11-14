/* 
 * Generated on 8/7/2014 09:50:02
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
using CL3_Project.Atomic.Retrieval;

namespace CL6_DanuTask_DeveloperTask.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DevTasks_Features_BizTasks_for_Project_by_ProjectID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DevTasks_Features_BizTasks_for_Project_by_ProjectID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6DT_GDTFBTfPbP_1258_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L6DT_GDTFBTfPbP_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6DT_GDTFBTfPbP_1258_Array();
			//Put your code here
            List<L6DT_GDTFBTfPbP_1258> sortedList = new List<L6DT_GDTFBTfPbP_1258>();
         

            P_L3PR_GDTfPbP_1034 devParameter = new P_L3PR_GDTfPbP_1034();
            devParameter.ProjectID = Parameter.ProjectID;

            List<L3PR_GDTfPbP_1034> devTasks = cls_Get_DeveloperTasks_for_Project_by_ProjectID.Invoke(Connection, Transaction, devParameter, securityTicket).Result.ToList();

            if (devTasks.Count != 0)
            {
                sortedList = devTasks.Select(x => new L6DT_GDTFBTfPbP_1258

                {
                    ID = x.TMS_PRO_DeveloperTaskID,
                    Name = x.DeveloperTask,
                    TaskType = "devtask"

                }).OrderBy(x => x.Name).ToList();
            }


            P_L3PR_GFfPbP_1103 featureParameter = new P_L3PR_GFfPbP_1103();
            featureParameter.ProjectID = Parameter.ProjectID;

            List<L3PR_GFfPbP_1103> features = cls_Get_Features_for_Project_by_ProjectID.Invoke(Connection, Transaction, featureParameter, securityTicket).Result.ToList();

            if (features.Count != 0)
            {

                var sortedFeatures = features.Select(x => new L6DT_GDTFBTfPbP_1258

                {
                    ID = x.TMS_PRO_FeatureID,
                    Name = x.Name_DictID.GetContent(Parameter.LanguageID),
                    TaskType = "feature"

                }).OrderBy(x => x.Name).ToList();

                sortedList.AddRange(sortedFeatures);
            }


            P_L3PR_GBTfPbP_1241 bizParameter = new P_L3PR_GBTfPbP_1241();
            bizParameter.ProjectID = Parameter.ProjectID;

            List<L3PR_GBTfPbP_1241> bizTasks = cls_Get_BusinessTasks_for_Project_by_ProjectID.Invoke(Connection, Transaction, bizParameter, securityTicket).Result.ToList();

            if (bizTasks.Count != 0)
            {

                var sortedbiztasks = bizTasks.Select(x => new L6DT_GDTFBTfPbP_1258
                {
                    ID = x.TMS_PRO_BusinessTaskID,
                    Name = x.Task_Name_DictID.GetContent(Parameter.LanguageID),
                    TaskType = "biztask"

                }).OrderBy(x => x.Name).ToList();

                sortedList.AddRange(sortedbiztasks);
            }


            returnValue.Result = sortedList.ToArray();


			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6DT_GDTFBTfPbP_1258_Array Invoke(string ConnectionString,P_L6DT_GDTFBTfPbP_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTFBTfPbP_1258_Array Invoke(DbConnection Connection,P_L6DT_GDTFBTfPbP_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6DT_GDTFBTfPbP_1258_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L6DT_GDTFBTfPbP_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6DT_GDTFBTfPbP_1258_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6DT_GDTFBTfPbP_1258 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6DT_GDTFBTfPbP_1258_Array functionReturn = new FR_L6DT_GDTFBTfPbP_1258_Array();
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

				throw new Exception("Exception occured in method cls_Get_DevTasks_Features_BizTasks_for_Project_by_ProjectID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6DT_GDTFBTfPbP_1258_Array : FR_Base
	{
		public L6DT_GDTFBTfPbP_1258[] Result	{ get; set; } 
		public FR_L6DT_GDTFBTfPbP_1258_Array() : base() {}

		public FR_L6DT_GDTFBTfPbP_1258_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6DT_GDTFBTfPbP_1258 for attribute P_L6DT_GDTFBTfPbP_1258
		[DataContract]
		public class P_L6DT_GDTFBTfPbP_1258 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProjectID { get; set; } 
			[DataMember]
			public Guid LanguageID { get; set; } 

		}
		#endregion
		#region SClass L6DT_GDTFBTfPbP_1258 for attribute L6DT_GDTFBTfPbP_1258
		[DataContract]
		public class L6DT_GDTFBTfPbP_1258 
		{
			//Standard type parameters
			[DataMember]
			public Guid ID { get; set; } 
			[DataMember]
			public String Name { get; set; } 
			[DataMember]
			public String TaskType { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6DT_GDTFBTfPbP_1258_Array cls_Get_DevTasks_Features_BizTasks_for_Project_by_ProjectID(,P_L6DT_GDTFBTfPbP_1258 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6DT_GDTFBTfPbP_1258_Array invocationResult = cls_Get_DevTasks_Features_BizTasks_for_Project_by_ProjectID.Invoke(connectionString,P_L6DT_GDTFBTfPbP_1258 Parameter,securityTicket);
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
var parameter = new CL6_DeveloperTask.Complex.Retrieval.P_L6DT_GDTFBTfPbP_1258();
parameter.ProjectID = ...;
parameter.LanguageID = ...;

*/
