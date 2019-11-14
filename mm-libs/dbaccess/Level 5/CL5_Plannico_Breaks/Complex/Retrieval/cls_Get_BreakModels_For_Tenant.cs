/* 
 * Generated on 11/19/2013 11:02:02 AM
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
using CL1_CMN_PPS;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_Breaks.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_BreakModels_For_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BreakModels_For_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BR_GBMFT_1503_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BR_GBMFT_1503_Array();
            List<L5BR_GBMFT_1503> breakModelList=new List<L5BR_GBMFT_1503>();

            ORM_CMN_PPS_BreakTime_Template.Query breakteTimeTemplateQuery=new ORM_CMN_PPS_BreakTime_Template.Query();
            breakteTimeTemplateQuery.IsDeleted=false;
            breakteTimeTemplateQuery.Tenant_RefID=securityTicket.TenantID;
            List<ORM_CMN_PPS_BreakTime_Template> breakTimeTemplates=ORM_CMN_PPS_BreakTime_Template.Query.Search(Connection,Transaction,breakteTimeTemplateQuery);
            foreach(var breakTimeTemplate in breakTimeTemplates){
                L5BR_GBMFT_1503 breakModel=new L5BR_GBMFT_1503();
                breakModel.BreakTimeTemplate_Name_DictID=breakTimeTemplate.BreakTimeTemplate_Name;
                breakModel.CMN_PPS_BreakTime_TemplateID = breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
                int duration=0;
                ORM_CMN_PPS_BreakTime_Template_Assignment.Query breakeTimeAssigmentQuery=new ORM_CMN_PPS_BreakTime_Template_Assignment.Query();
                breakeTimeAssigmentQuery.IsDeleted=false;
                breakeTimeAssigmentQuery.Tenant_RefID=securityTicket.TenantID;
                breakeTimeAssigmentQuery.BreakTime_Template_RefID=breakTimeTemplate.CMN_PPS_BreakTime_TemplateID;
                List<ORM_CMN_PPS_BreakTime_Template_Assignment> breakTimeAssignemnts=ORM_CMN_PPS_BreakTime_Template_Assignment.Query.Search(Connection,Transaction,breakeTimeAssigmentQuery);
                foreach(var assignment in breakTimeAssignemnts){
                    ORM_CMN_PPS_BreakTime breakeTime=new ORM_CMN_PPS_BreakTime();
                    breakeTime.Load(Connection,Transaction,assignment.BreakTime_RefID);
                    if(breakeTime.IsBreakfastBreak){
                        breakModel.BreakfestDuration=breakeTime.Default_Duration_in_sec;
                    }
                    else if(breakeTime.IsDinnerBreak){
                        breakModel.DinnerDuration=breakeTime.Default_Duration_in_sec;
                    }
                    else if (breakeTime.IsLunchBreak)
                    {
                        breakModel.LunchDuration = breakeTime.Default_Duration_in_sec;
                    }
                    else
                    {
                        duration += breakeTime.Default_Duration_in_sec;
                    }
                            
                }
                breakModel.Duration = duration;
                breakModel.Office_RefID = breakTimeTemplate.BoundTo_Office_RefID;
                breakModel.Workarea_RefID = breakTimeTemplate.BoundTo_Workarea_RefID;
                breakModel.Workplace_RefID = breakTimeTemplate.BoundTo_Workplace_RefID;
                breakModelList.Add(breakModel);
            }
            returnValue.Result=breakModelList.ToArray();
            
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BR_GBMFT_1503_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BR_GBMFT_1503_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BR_GBMFT_1503_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BR_GBMFT_1503_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BR_GBMFT_1503_Array functionReturn = new FR_L5BR_GBMFT_1503_Array();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw new Exception("Exception occured in method cls_Get_BreakModels_For_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BR_GBMFT_1503_Array : FR_Base
	{
		public L5BR_GBMFT_1503[] Result	{ get; set; } 
		public FR_L5BR_GBMFT_1503_Array() : base() {}

		public FR_L5BR_GBMFT_1503_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BR_GBMFT_1503_Array cls_Get_BreakModels_For_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BR_GBMFT_1503_Array invocationResult = cls_Get_BreakModels_For_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/
