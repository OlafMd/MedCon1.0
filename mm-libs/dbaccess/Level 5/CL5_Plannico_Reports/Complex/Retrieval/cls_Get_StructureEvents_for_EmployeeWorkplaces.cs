/* 
 * Generated on 3/10/2014 4:41:16 PM
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
using CL3_Events.Atomic.Retrieval;
using CL1_CMN_STR_PPS;
using CL5_VacationPlanner_Employees.Complex.Retrieval;
using PlannicoModel.Models;
using VacationPlaner;

namespace CL5_Plannico_Reports.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_StructureEvents_for_EmployeeWorkplaces.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_StructureEvents_for_EmployeeWorkplaces
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5RP_GSEfEW_1438 Execute(DbConnection Connection,DbTransaction Transaction,P_L5RP_GSEfEW_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5RP_GSEfEW_1438();

			//Put your code here
            returnValue.Result = new L5RP_GSEfEW_1438();
            List<L3EV_GSEFCID_1042> retValList = new List<L3EV_GSEFCID_1042>();

            foreach (var workplaceHistory in Parameter.EmployeeWorkplaceHistory)
            {
                ORM_CMN_STR_PPS_Workplace workplace = new ORM_CMN_STR_PPS_Workplace();
                var workplaceRes = workplace.Load(Connection, Transaction, workplaceHistory.BoundTo_Workplace_RefID);

                if (workplaceRes.Status != FR_Status.Success || workplace.CMN_STR_PPS_WorkplaceID == Guid.Empty)
                    continue;

                P_L3EV_GSEFCID_1042 structureEventPar = new P_L3EV_GSEFCID_1042();
                structureEventPar.CalendarInstanceID = workplace.CMN_CAL_CalendarInstance_RefID;
                L3EV_GSEFCID_1042[] structureEvents = cls_get_StructureEvents_For_CalendarInstanceID.Invoke(Connection, Transaction, structureEventPar, securityTicket).Result;

                List<L3EV_GSEFCID_1042> eventItems;
                DateTime date;
                for (int i = 0; i < Parameter.EndTime.Day; i++)
                {
                    date = Parameter.StartTime.AddDays(i);
                    if (structureEvents.Any(s => s.StartTime.Ticks <= date.Date.Ticks && s.EndTime.Ticks >= date.Date.Ticks))
                    {
                        eventItems = structureEvents.Where(s => s.StartTime.Ticks <= date.Date.Ticks && s.EndTime.Ticks >= date.Date.Ticks).ToList();
                        foreach (var item in eventItems)
                        {
                            if (!retValList.Contains(item))
                                retValList.Add(item);
                        }
                    }
                }
            }

            returnValue.Result.StructureEvents = retValList.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5RP_GSEfEW_1438 Invoke(string ConnectionString,P_L5RP_GSEfEW_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5RP_GSEfEW_1438 Invoke(DbConnection Connection,P_L5RP_GSEfEW_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5RP_GSEfEW_1438 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5RP_GSEfEW_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5RP_GSEfEW_1438 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5RP_GSEfEW_1438 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5RP_GSEfEW_1438 functionReturn = new FR_L5RP_GSEfEW_1438();
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
	public class FR_L5RP_GSEfEW_1438 : FR_Base
	{
		public L5RP_GSEfEW_1438 Result	{ get; set; }

		public FR_L5RP_GSEfEW_1438() : base() {}

		public FR_L5RP_GSEfEW_1438(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

    #region SClass P_L5RP_GSEfEW_1438 for attribute P_L5RP_GSEfEW_1438
    [DataContract]
    public class P_L5RP_GSEfEW_1438
    {
        //Standard type parameters
        [DataMember]
        public L5EM_GEFE_1150_EmployeeWorkplaceHistory[] EmployeeWorkplaceHistory { get; set; }
        [DataMember]
        public DateTime StartTime { get; set; }
        [DataMember]
        public DateTime EndTime { get; set; }

    }
    #endregion
    #region SClass L5RP_GSEfEW_1438 for attribute L5RP_GSEfEW_1438
    [DataContract]
    public class L5RP_GSEfEW_1438
    {
        //Standard type parameters
        [DataMember]
        public L3EV_GSEFCID_1042[] StructureEvents { get; set; }

    }
    #endregion
	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5RP_GSEfEW_1438 cls_Get_StructureEvents_for_EmployeeWorkplaces(P_L5RP_GSEfEW_1438 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5RP_GSEfEW_1438 result = cls_Get_StructureEvents_for_EmployeeWorkplaces.Invoke(connectionString,P_L5RP_GSEfEW_1438 Parameter,securityTicket);
	 return result;
}
*/