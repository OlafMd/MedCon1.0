/* 
 * Generated on 11/20/2013 4:02:04 PM
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
using CL5_Plannico_ExtraWorkCalculations.Atomic.Retrieval;
using CL1_CMN_BPT_EMP;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_ExtraWorkCalculations.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ExtraWork_For_ExtraWorkID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ExtraWork_For_ExtraWorkID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5EW_GEWFEWID_1552 Execute(DbConnection Connection,DbTransaction Transaction,P_L5EW_GEWFEWID_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5EW_GEWFEWID_1552();
            returnValue.Result = new L5EW_GEWFEWID_1552();
            returnValue.Result.ExtraWork = new L5EW_GEWCFT_1546();

			//Put your code here

            var orm_extraWork = new ORM_CMN_BPT_EMP_ExtraWorkCalculation();
            if(Parameter.CMN_BPT_EMP_ExtraWorkCalculationID != Guid.Empty)
            {
                var result = orm_extraWork.Load(Connection, Transaction, Parameter.CMN_BPT_EMP_ExtraWorkCalculationID);
                if (result.Status == FR_Status.Success || orm_extraWork.CMN_BPT_EMP_ExtraWorkCalculationID != Guid.Empty)
                {
                    L5EW_GEWCFT_1546 extraWork = new L5EW_GEWCFT_1546();
                    extraWork.CMN_BPT_EMP_ExtraWorkCalculationID = orm_extraWork.CMN_BPT_EMP_ExtraWorkCalculationID;
                    extraWork.AreAdditionalWorkDays_CalculatedIn_Days = orm_extraWork.AreAdditionalWorkDays_CalculatedIn_Days;
                    extraWork.AreAdditionalWorkDays_CalculatedIn_DaysAsHours = orm_extraWork.AreAdditionalWorkDays_CalculatedIn_DaysAsHours;
                    extraWork.AreAdditionalWorkDays_CalculatedIn_Hours = orm_extraWork.AreAdditionalWorkDays_CalculatedIn_Hours;
                    extraWork.ExtraWorkCalculation_Name = orm_extraWork.ExtraWorkCalculation_Name;
                    extraWork.IsCalculatingOvertimeEnabled = orm_extraWork.IsCalculatingOvertimeEnabled;
                    extraWork.IsDisplayedAs_DaysAndHours = orm_extraWork.IsDisplayedAs_DaysAndHours;
                    extraWork.IsDisplayedAs_HoursAsDays = orm_extraWork.IsDisplayedAs_HoursAsDays;
                    extraWork.MinimalOvertimeTreshold_in_minutes = orm_extraWork.MinimalOvertimeTreshold_in_minutes;
                    extraWork.StandardWorkDay_in_mins = orm_extraWork.StandardWorkDay_in_mins;

                    ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query structureBindingQuery = new ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query();
                    structureBindingQuery.ExtraWorkCalculation_RefID = extraWork.CMN_BPT_EMP_ExtraWorkCalculationID;
                    structureBindingQuery.IsDeleted = false;
                    structureBindingQuery.Tenant_RefID = securityTicket.TenantID;

                    var structureBindings = ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding.Query.Search(Connection, Transaction, structureBindingQuery);

                    if (structureBindings.Count != 0)
                    {
                        ORM_CMN_BPT_EMP_ExtraWorkCalculation_StructureBinding structureBinding = structureBindings.FirstOrDefault();
                        extraWork.BoundTo_Office_RefID = structureBinding.BoundTo_Office_RefID;
                        extraWork.BoundTo_WorkArea_RefID = structureBinding.BoundTo_WorkArea_RefID;
                        extraWork.BoundTo_Workplace_RefID = structureBinding.BoundTo_Workplace_RefID;
                    }
                    else
                    {
                        extraWork.BoundTo_Office_RefID = Guid.Empty;
                        extraWork.BoundTo_WorkArea_RefID = Guid.Empty;
                        extraWork.BoundTo_Workplace_RefID = Guid.Empty;
                    }

                    returnValue.Result.ExtraWork = extraWork;
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5EW_GEWFEWID_1552 Invoke(string ConnectionString,P_L5EW_GEWFEWID_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWFEWID_1552 Invoke(DbConnection Connection,P_L5EW_GEWFEWID_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5EW_GEWFEWID_1552 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5EW_GEWFEWID_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5EW_GEWFEWID_1552 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5EW_GEWFEWID_1552 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5EW_GEWFEWID_1552 functionReturn = new FR_L5EW_GEWFEWID_1552();
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

                Guid errorID = Guid.NewGuid();
                ServerLog.Instance.Fatal("Application error occured. ErrorID = " + errorID, ex);
				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5EW_GEWFEWID_1552 : FR_Base
	{
		public L5EW_GEWFEWID_1552 Result	{ get; set; }

		public FR_L5EW_GEWFEWID_1552() : base() {}

		public FR_L5EW_GEWFEWID_1552(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes


	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5EW_GEWFEWID_1552 cls_Get_ExtraWork_For_ExtraWorkID(P_L5EW_GEWFEWID_1552 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5EW_GEWFEWID_1552 result = cls_Get_ExtraWork_For_ExtraWorkID.Invoke(connectionString,P_L5EW_GEWFEWID_1552 Parameter,securityTicket);
	 return result;
}
*/