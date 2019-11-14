/* 
 * Generated on 10/14/2013 12:23:15 PM
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
using CL1_CMN_STR_SCE;
using CL1_CMN_CAL;

namespace CL3_Events.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Delete_StructureEvent.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Delete_StructureEvent
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Base Execute(DbConnection Connection,DbTransaction Transaction,P_L3EV_DSE_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Base();





			P_L3EV_GSEFSE_1102 par = new P_L3EV_GSEFSE_1102();
			par.StructureEventID=Parameter.CMN_STR_SCE_StructureCalendarEventID;
			L3EV_GSEFSE_1102 sEvent=cls_Get_StructureEvent_For_StructureEventID.Invoke(Connection, Transaction, par, securityTicket).Result;
					   

            ORM_CMN_CAL_Event whereInstanceEvent = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_Event>();
            whereInstanceEvent.CMN_CAL_EventID = sEvent.CMN_CAL_EventID;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceEvent);


                if (sEvent.IsRepetitive)
                {

                    ORM_CMN_CAL_Repetition whereInstanceRepetition = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_Repetition>();
                    whereInstanceRepetition.CMN_CAL_RepetitionID = sEvent.CMN_CAL_RepetitionID;
                    CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceRepetition);

                    if (sEvent.IsDaily)
                    {
                        ORM_CMN_CAL_RepetitionPatterns_Daily whereInstanceDaily = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_RepetitionPatterns_Daily>();
                        whereInstanceDaily.CMN_CAL_RepetitionPattern_DailyID = sEvent.dailyCMN_CAL_RepetitionPattern_DailyID;
                        CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceDaily);

                    }
                    else if (sEvent.IsWeekly)
                    {
                        ORM_CMN_CAL_RepetitionPatterns_Weekly whereInstanceWeekly = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_RepetitionPatterns_Weekly>();
                        whereInstanceWeekly.CMN_CAL_RepetitionPattern_WeeklyID = sEvent.weeklyCMN_CAL_RepetitionPattern_WeeklyID;
                        CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceWeekly);

                    }
                    else if (sEvent.IsMonthly)
                    {
                        ORM_CMN_CAL_RepetitionPatterns_Monthly whereInstanceMonthly = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_RepetitionPatterns_Monthly>();
                        whereInstanceMonthly.CMN_CAL_RepetitionPattern_MonthlyID = sEvent.monthlyCMN_CAL_RepetitionPattern_MonthlyID;
                        CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceMonthly);

                        if (sEvent.yearlyIsRelative)
                        {
                            ORM_CMN_CAL_RepetitionPatterns_Relative whereInstanceCapacityRelative = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_RepetitionPatterns_Relative>();
                            whereInstanceCapacityRelative.CMN_CAL_RepetitionPattern_RelativeID = sEvent.relativeCMN_CAL_RepetitionPattern_RelativeID;
                            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceCapacityRelative);
                        }
                    }
                    else if (sEvent.IsYearly)
                    {

                        ORM_CMN_CAL_RepetitionPatterns_Yearly whereInstanceYearly = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_RepetitionPatterns_Yearly>();
                        whereInstanceYearly.CMN_CAL_RepetitionPattern_YearlyID = sEvent.CMN_STR_SCE_CapacityRestrictionID;
                        CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceYearly);

                        if (sEvent.yearlyIsRelative)
                        {
                            ORM_CMN_CAL_RepetitionPatterns_Relative whereInstanceCapacityRelative = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_CAL_RepetitionPatterns_Relative>();
                            whereInstanceCapacityRelative.CMN_CAL_RepetitionPattern_RelativeID = sEvent.relativeCMN_CAL_RepetitionPattern_RelativeID;
                            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceCapacityRelative);
                        }
                    }

                }

			ORM_CMN_STR_SCE_CapacityRestriction whereInstanceCapacityRestriction = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_SCE_CapacityRestriction>();
			whereInstanceCapacityRestriction.CMN_STR_SCE_CapacityRestrictionID = sEvent.CMN_STR_SCE_CapacityRestrictionID;
			CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceCapacityRestriction);


			ORM_CMN_STR_SCE_StructureCalendarEvent whereInstanceStructureCalendarEvent = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_SCE_StructureCalendarEvent>();
			whereInstanceStructureCalendarEvent.CMN_STR_SCE_StructureCalendarEventID = Parameter.CMN_STR_SCE_StructureCalendarEventID;
			CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceStructureCalendarEvent);


            ORM_CMN_STR_SCE_ForbiddenLeaveType whereInstanceForbiddenLeaveType = CSV2Core_MySQL.Support.SQLClassFilter.GetDefaultInstance<ORM_CMN_STR_SCE_ForbiddenLeaveType>();
            whereInstanceForbiddenLeaveType.CMN_STR_SCE_ForbiddenLeaveTypeID = sEvent.CMN_STR_SCE_StructureCalendarEventID ;
            CSV2Core_MySQL.Support.SQLClassFilter.Delete(Connection, Transaction, whereInstanceForbiddenLeaveType);

			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Base Invoke(string ConnectionString,P_L3EV_DSE_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection,P_L3EV_DSE_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction,P_L3EV_DSE_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Base Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3EV_DSE_1353 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Base functionReturn = new FR_Base();
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

				throw new Exception("Exception occured in method cls_Delete_StructureEvent",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3EV_DSE_1353 for attribute P_L3EV_DSE_1353
		[DataContract]
		public class P_L3EV_DSE_1353 
		{
			//Standard type parameters
			[DataMember]
			public Guid CMN_STR_SCE_StructureCalendarEventID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Base cls_Delete_StructureEvent(,P_L3EV_DSE_1353 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Base invocationResult = cls_Delete_StructureEvent.Invoke(connectionString,P_L3EV_DSE_1353 Parameter,securityTicket);
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
var parameter = new CL3_Events.Complex.Manipulation.P_L3EV_DSE_1353();
parameter.CMN_STR_SCE_StructureCalendarEventID = ...;

*/