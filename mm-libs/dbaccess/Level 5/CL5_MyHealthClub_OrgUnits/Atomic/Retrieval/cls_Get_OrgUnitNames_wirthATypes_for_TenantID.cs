/* 
 * Generated on 19.11.2014 15:32:51
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

namespace CL5_MyHealthClub_OrgUnits.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_OrgUnitNames_wirthATypes_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_OrgUnitNames_wirthATypes_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5OU_GOUDNwATTID_1532_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5OU_GOUDNwATTID_1532_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MyHealthClub_OrgUnits.Atomic.Retrieval.SQL.cls_Get_OrgUnitNames_wirthATypes_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<L5OU_GOUDNwATTID_1532_raw> results = new List<L5OU_GOUDNwATTID_1532_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "OfficeID","Office_Name_DictID","PracticeIDString","PPS_TSK_Task_TemplateID","TaskTemplateName_DictID" });
				while(reader.Read())
				{
					L5OU_GOUDNwATTID_1532_raw resultItem = new L5OU_GOUDNwATTID_1532_raw();
					//0:Parameter OfficeID of type Guid
					resultItem.OfficeID = reader.GetGuid(0);
					//1:Parameter Office_Name of type Dict
					resultItem.Office_Name = reader.GetDictionary(1);
					resultItem.Office_Name.SourceTable = "cmn_str_offices";
					loader.Append(resultItem.Office_Name);
					//2:Parameter PracticeIDString of type String
					resultItem.PracticeIDString = reader.GetString(2);
					//3:Parameter PPS_TSK_Task_TemplateID of type Guid
					resultItem.PPS_TSK_Task_TemplateID = reader.GetGuid(3);
					//4:Parameter TaskTemplateName of type Dict
					resultItem.TaskTemplateName = reader.GetDictionary(4);
					resultItem.TaskTemplateName.SourceTable = "pps_tsk_task_templates";
					loader.Append(resultItem.TaskTemplateName);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_OrgUnitNames_wirthATypes_for_TenantID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5OU_GOUDNwATTID_1532_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5OU_GOUDNwATTID_1532_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDNwATTID_1532_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5OU_GOUDNwATTID_1532_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5OU_GOUDNwATTID_1532_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5OU_GOUDNwATTID_1532_Array functionReturn = new FR_L5OU_GOUDNwATTID_1532_Array();
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

				throw new Exception("Exception occured in method cls_Get_OrgUnitNames_wirthATypes_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Raw Grouping Class
	[Serializable]
	public class L5OU_GOUDNwATTID_1532_raw 
	{
		public Guid OfficeID; 
		public Dict Office_Name; 
		public String PracticeIDString; 
		public Guid PPS_TSK_Task_TemplateID; 
		public Dict TaskTemplateName; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5OU_GOUDNwATTID_1532[] Convert(List<L5OU_GOUDNwATTID_1532_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5OU_GOUDNwATTID_1532 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.OfficeID)).ToArray()
	group el_L5OU_GOUDNwATTID_1532 by new 
	{ 
		el_L5OU_GOUDNwATTID_1532.OfficeID,

	}
	into gfunct_L5OU_GOUDNwATTID_1532
	select new L5OU_GOUDNwATTID_1532
	{     
		OfficeID = gfunct_L5OU_GOUDNwATTID_1532.Key.OfficeID ,
		Office_Name = gfunct_L5OU_GOUDNwATTID_1532.FirstOrDefault().Office_Name ,
		PracticeIDString = gfunct_L5OU_GOUDNwATTID_1532.FirstOrDefault().PracticeIDString ,

		AppointmentTypeList = 
		(
			from el_AppointmentTypeList in gfunct_L5OU_GOUDNwATTID_1532.Where(element => !EqualsDefaultValue(element.PPS_TSK_Task_TemplateID)).ToArray()
			group el_AppointmentTypeList by new 
			{ 
				el_AppointmentTypeList.PPS_TSK_Task_TemplateID,

			}
			into gfunct_AppointmentTypeList
			select new L5OU_GOUDNwATTID_1532_ATIDL
			{     
				PPS_TSK_Task_TemplateID = gfunct_AppointmentTypeList.Key.PPS_TSK_Task_TemplateID ,
				TaskTemplateName = gfunct_AppointmentTypeList.FirstOrDefault().TaskTemplateName ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5OU_GOUDNwATTID_1532_Array : FR_Base
	{
		public L5OU_GOUDNwATTID_1532[] Result	{ get; set; } 
		public FR_L5OU_GOUDNwATTID_1532_Array() : base() {}

		public FR_L5OU_GOUDNwATTID_1532_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5OU_GOUDNwATTID_1532 for attribute L5OU_GOUDNwATTID_1532
		[DataContract]
		public class L5OU_GOUDNwATTID_1532 
		{
			[DataMember]
			public L5OU_GOUDNwATTID_1532_ATIDL[] AppointmentTypeList { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid OfficeID { get; set; } 
			[DataMember]
			public Dict Office_Name { get; set; } 
			[DataMember]
			public String PracticeIDString { get; set; } 

		}
		#endregion
		#region SClass L5OU_GOUDNwATTID_1532_ATIDL for attribute AppointmentTypeList
		[DataContract]
		public class L5OU_GOUDNwATTID_1532_ATIDL 
		{
			//Standard type parameters
			[DataMember]
			public Guid PPS_TSK_Task_TemplateID { get; set; } 
			[DataMember]
			public Dict TaskTemplateName { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5OU_GOUDNwATTID_1532_Array cls_Get_OrgUnitNames_wirthATypes_for_TenantID(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5OU_GOUDNwATTID_1532_Array invocationResult = cls_Get_OrgUnitNames_wirthATypes_for_TenantID.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

