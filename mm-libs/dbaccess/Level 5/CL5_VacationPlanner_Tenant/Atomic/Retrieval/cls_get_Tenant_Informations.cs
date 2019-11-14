/* 
 * Generated on 14-Nov-13 17:17:40
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

namespace CL5_VacationPlanner_Tenant.Atomic.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_get_Tenant_Informations.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_get_Tenant_Informations
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TN_GTI_1646 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5TN_GTI_1646();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_VacationPlanner_Tenant.Atomic.Retrieval.SQL.cls_get_Tenant_Informations.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5TN_GTI_1646> results = new List<L5TN_GTI_1646>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CMN_TenantID","IsUsing_WorkAreas","IsUsing_Offices","IsUsing_Workplaces","DocumentServerRootURL","CMN_UniversalContactDetailID","IsCompany","CompanyName_Line1","CompanyName_Line2","WorkDescription","Salutation","Title","First_Name","Last_Name","CareOf","Country_Name","Country_639_1_ISOCode","Street_Number","Street_Name","PostalAddress_Number","PostalAddress_Formatted","ZIP","Town","Contact_Email","Contact_Telephone","Contact_Fax","CMN_BPT_STA_SettingProfileID","StafMember_Caption_DictID","IsLeaveTimeCalculated_InDays","IsLeaveTimeCalculated_InHours","IsUsingWorkflow_ForLeaveRequests","CMN_CAL_CalendarInstance_RefID","CMN_LOC_RegionID","Region_Name_DictID","Default_SurchargeCalculation_UseAccumulated","Default_SurchargeCalculation_UseMaximum" });
				while(reader.Read())
				{
					L5TN_GTI_1646 resultItem = new L5TN_GTI_1646();
					//0:Parameter CMN_TenantID of type Guid
					resultItem.CMN_TenantID = reader.GetGuid(0);
					//1:Parameter IsUsing_WorkAreas of type bool
					resultItem.IsUsing_WorkAreas = reader.GetBoolean(1);
					//2:Parameter IsUsing_Offices of type bool
					resultItem.IsUsing_Offices = reader.GetBoolean(2);
					//3:Parameter IsUsing_Workplaces of type bool
					resultItem.IsUsing_Workplaces = reader.GetBoolean(3);
					//4:Parameter DocumentServerRootURL of type String
					resultItem.DocumentServerRootURL = reader.GetString(4);
					//5:Parameter CMN_UniversalContactDetailID of type Guid
					resultItem.CMN_UniversalContactDetailID = reader.GetGuid(5);
					//6:Parameter IsCompany of type bool
					resultItem.IsCompany = reader.GetBoolean(6);
					//7:Parameter CompanyName_Line1 of type String
					resultItem.CompanyName_Line1 = reader.GetString(7);
					//8:Parameter CompanyName_Line2 of type String
					resultItem.CompanyName_Line2 = reader.GetString(8);
					//9:Parameter WorkDescription of type String
					resultItem.WorkDescription = reader.GetString(9);
					//10:Parameter Salutation of type String
					resultItem.Salutation = reader.GetString(10);
					//11:Parameter Title of type String
					resultItem.Title = reader.GetString(11);
					//12:Parameter First_Name of type String
					resultItem.First_Name = reader.GetString(12);
					//13:Parameter Last_Name of type String
					resultItem.Last_Name = reader.GetString(13);
					//14:Parameter CareOf of type String
					resultItem.CareOf = reader.GetString(14);
					//15:Parameter Country_Name of type String
					resultItem.Country_Name = reader.GetString(15);
					//16:Parameter Country_639_1_ISOCode of type String
					resultItem.Country_639_1_ISOCode = reader.GetString(16);
					//17:Parameter Street_Number of type String
					resultItem.Street_Number = reader.GetString(17);
					//18:Parameter Street_Name of type String
					resultItem.Street_Name = reader.GetString(18);
					//19:Parameter PostalAddress_Number of type String
					resultItem.PostalAddress_Number = reader.GetString(19);
					//20:Parameter PostalAddress_Formatted of type String
					resultItem.PostalAddress_Formatted = reader.GetString(20);
					//21:Parameter ZIP of type String
					resultItem.ZIP = reader.GetString(21);
					//22:Parameter Town of type String
					resultItem.Town = reader.GetString(22);
					//23:Parameter Contact_Email of type String
					resultItem.Contact_Email = reader.GetString(23);
					//24:Parameter Contact_Telephone of type String
					resultItem.Contact_Telephone = reader.GetString(24);
					//25:Parameter Contact_Fax of type String
					resultItem.Contact_Fax = reader.GetString(25);
					//26:Parameter CMN_BPT_STA_SettingProfileID of type Guid
					resultItem.CMN_BPT_STA_SettingProfileID = reader.GetGuid(26);
					//27:Parameter StafMember_Caption of type Dict
					resultItem.StafMember_Caption = reader.GetDictionary(27);
					resultItem.StafMember_Caption.SourceTable = "cmn_bpt_sta_settingprofiles";
					loader.Append(resultItem.StafMember_Caption);
					//28:Parameter IsLeaveTimeCalculated_InDays of type bool
					resultItem.IsLeaveTimeCalculated_InDays = reader.GetBoolean(28);
					//29:Parameter IsLeaveTimeCalculated_InHours of type bool
					resultItem.IsLeaveTimeCalculated_InHours = reader.GetBoolean(29);
					//30:Parameter IsUsingWorkflow_ForLeaveRequests of type bool
					resultItem.IsUsingWorkflow_ForLeaveRequests = reader.GetBoolean(30);
					//31:Parameter CMN_CAL_CalendarInstance_RefID of type Guid
					resultItem.CMN_CAL_CalendarInstance_RefID = reader.GetGuid(31);
					//32:Parameter CMN_LOC_RegionID of type Guid
					resultItem.CMN_LOC_RegionID = reader.GetGuid(32);
					//33:Parameter Region_Name_DictID of type Dict
					resultItem.Region_Name_DictID = reader.GetDictionary(33);
					resultItem.Region_Name_DictID.SourceTable = "cmn_loc_regions";
					loader.Append(resultItem.Region_Name_DictID);
					//34:Parameter Default_SurchargeCalculation_UseAccumulated of type bool
					resultItem.Default_SurchargeCalculation_UseAccumulated = reader.GetBoolean(34);
					//35:Parameter Default_SurchargeCalculation_UseMaximum of type bool
					resultItem.Default_SurchargeCalculation_UseMaximum = reader.GetBoolean(35);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
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
		public static FR_L5TN_GTI_1646 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TN_GTI_1646 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TN_GTI_1646 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TN_GTI_1646 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TN_GTI_1646 functionReturn = new FR_L5TN_GTI_1646();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5TN_GTI_1646 : FR_Base
	{
		public L5TN_GTI_1646 Result	{ get; set; }

		public FR_L5TN_GTI_1646() : base() {}

		public FR_L5TN_GTI_1646(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}
