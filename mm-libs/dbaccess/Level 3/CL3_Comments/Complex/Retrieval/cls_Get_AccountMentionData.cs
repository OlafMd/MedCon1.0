/* 
 * Generated on 5/15/2013 1:07:54 PM
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
using CL3_DeveloperTask.Atomic.Retrieval;
using CL3_Features.Atomic.Retrieval;
using CL3_BusinessTasks.Atomic.Retrieval;
using CL3_User.Atomic.Retrieval;
using CL3_Project.Atomic.Retrieval;

namespace CL3_Comments.Complex.Retrieval
{
	/// <summary>
    /// 
    
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AccountMentionData.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AccountMentionData
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CM_GAMD_1710 Execute(DbConnection Connection,DbTransaction Transaction,P_L3CM_GAMD_1710 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L3CM_GAMD_1710();
            returnValue.Result = new L3CM_GAMD_1710();

            #region Get Projects

            P_L3PR_GPfAaR_1344 param0 = new P_L3PR_GPfAaR_1344();
            param0.IsArchived = false;
            param0.RightPackIDList = Parameter.RightPackIDList;

            FR_L3PR_GPfAaR_1344_Array result1 = cls_Get_Projects_for_AccountID_and_RightPackIDList.Invoke(Connection, Transaction, param0, securityTicket);
            L3PR_GPfAaR_1344[] projects = result1.Result;

            #endregion

            if (projects.Count() == 0)
            {
                return returnValue;
            }

            #region DeveloperTasks

            P_L3DT_GDTSVfPL_1458 param1 = new P_L3DT_GDTSVfPL_1458();
            param1.ProjectIDList = projects.Select(i => i.TMS_PRO_ProjectID).ToArray();
            param1.ShowOnly_CompletedTasks = false;
            param1.ShowOnly_IncompleteInfo = false;
            param1.Is_ArchivedTasks_Included = false;

            var dtasks = cls_Get_DeveloperTasks_SimpleView_for_ProjectIDList.Invoke(Connection, Transaction, param1, securityTicket).Result;

            #endregion

            #region Featrues

            P_L3FE_GFSVfPL_1553 param2 = new P_L3FE_GFSVfPL_1553();
            param2.ProjectIDList = projects.Select(i => i.TMS_PRO_ProjectID).ToArray();
            param2.Is_ArchivedFeatures_Included = false;

            var features = cls_Get_Features_SimpleView_for_ProjectIDList.Invoke(Connection, Transaction, param2, securityTicket).Result;

            #endregion

            #region BusinessTasks 

            P_L3BT_GBTSVfPL_1423 param3 = new P_L3BT_GBTSVfPL_1423();
            param3.ProjectIDList = projects.Select(i => i.TMS_PRO_ProjectID).ToArray();
            param3.Is_ArchivedTasks_Included = false;

            var btasks = cls_Get_BusinessTasks_SimpleView_for_ProjectIDList.Invoke(Connection, Transaction, param3, securityTicket).Result;
           
            #endregion

            #region Accounts

            P_L3US_GAIfAaT_1157 param4 = new P_L3US_GAIfAaT_1157();
            param4.ApplicationID = Parameter.ApplicationID;

            var accounts =  cls_Get_AccountInfos_for_ApplicationIDandTenantID.Invoke(Connection, Transaction, param4, securityTicket).Result;

            #endregion


            returnValue.Result.DeveloperTasks = dtasks;
            returnValue.Result.Features = features;
            returnValue.Result.BusinessTasks = btasks;
            returnValue.Result.Accounts = accounts;
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CM_GAMD_1710 Invoke(string ConnectionString,P_L3CM_GAMD_1710 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CM_GAMD_1710 Invoke(DbConnection Connection,P_L3CM_GAMD_1710 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CM_GAMD_1710 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CM_GAMD_1710 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CM_GAMD_1710 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CM_GAMD_1710 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CM_GAMD_1710 functionReturn = new FR_L3CM_GAMD_1710();
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
	public class FR_L3CM_GAMD_1710 : FR_Base
	{
		public L3CM_GAMD_1710 Result	{ get; set; }

		public FR_L3CM_GAMD_1710() : base() {}

		public FR_L3CM_GAMD_1710(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CM_GAMD_1710 for attribute P_L3CM_GAMD_1710
		[DataContract]
		public class P_L3CM_GAMD_1710 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] RightPackIDList { get; set; } 
			[DataMember]
			public Guid ApplicationID { get; set; } 

		}
		#endregion
		#region SClass L3CM_GAMD_1710 for attribute L3CM_GAMD_1710
		[DataContract]
		public class L3CM_GAMD_1710 
		{
			//Standard type parameters
			[DataMember]
			public L3DT_GDTSVfPL_1458[] DeveloperTasks { get; set; } 
			[DataMember]
			public L3FE_GFSVfPL_1553[] Features { get; set; } 
			[DataMember]
			public L3BT_GBTSVfPL_1423[] BusinessTasks { get; set; } 
			[DataMember]
			public L3US_GAIfAaT_1157[] Accounts { get; set; } 

		}
		#endregion

	#endregion
}
